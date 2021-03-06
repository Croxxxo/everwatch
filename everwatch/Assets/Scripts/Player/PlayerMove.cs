﻿using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float normalMovementSpeed;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float runSpeed;
    public float stamina;
    [SerializeField] private float staminaDecreaseRate;
    [SerializeField] private float staminaIncreaseRate;
    [SerializeField] private bool isRunning;

    private CharacterController charController;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private KeyCode runKey;


    private bool isJumping;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
        JumpInput();

        if (isRunning && stamina > 0)
        {
            stamina -= staminaDecreaseRate;
        } else if (!isRunning && stamina < 100)
        {
            stamina += staminaIncreaseRate;
        }

        if(stamina > 100)
        {
            stamina = 100;
        } else if(stamina <= 0)
        {
            isRunning = false;
            movementSpeed = normalMovementSpeed;
            stamina = 0;
        }
    }

    private void PlayerMovement()
    {
        if (Input.GetKeyDown(runKey) && stamina > 0)
        {
            movementSpeed = runSpeed;
            isRunning = true;
        }
        if (Input.GetKeyUp(runKey))
        {
            movementSpeed = normalMovementSpeed;
            isRunning = false;
        }
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

        Vector3 forwardMovemnt = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovemnt + rightMovement);
    }

    private void JumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private  IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }
}
