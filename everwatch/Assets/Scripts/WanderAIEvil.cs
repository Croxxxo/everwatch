using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAIEvil : MonoBehaviour
{
    Transform tr_Player;

    public float moveSpeed = 3f;
    public float rotSpeed = 100f;
    [SerializeField] private int damage;
    [SerializeField] private float attackSpeed;

    private float otherrotSpeed = 3f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    private bool isChasing = false;
    private bool canAttack;
    private bool attacking;

    public Rigidbody rb;

    private PlayerVitals pv;
    // Start is called before the first frame update
    void Start()
    {
        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;

        Rigidbody rb = GetComponent<Rigidbody>();

        pv = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerVitals>();
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWandering == false && isChasing == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if (isWalking == true)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if(isChasing && !isWandering)
        {
            ChasePlayer();
        }
    }

    public void OnCollisionStay(Collision collision)
    {
      if (collision.gameObject.CompareTag("Player"))
        {
            if (canAttack)
            {
                StartCoroutine(Attack());
            }
        }
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 3);
        int rotateLorR = Random.Range(0, 3);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    }

    private void ChasePlayer()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, 
            Quaternion.LookRotation(tr_Player.position - transform.position), 
            otherrotSpeed * Time.deltaTime);

        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isChasing = true;
            isWandering = false;
            ChasePlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isChasing = false;
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            StartCoroutine(Wander());
        }
    }

    IEnumerator Attack()
    {
        if (!attacking)
        {
            canAttack = false;
            attacking = true;
            pv.health -= damage;
        }

        yield return new WaitForSeconds(attackSpeed);
        attacking = false;
        canAttack = true;
    }
}
