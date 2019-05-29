using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    public enum ToolType {axe, pickaxe};
    public ToolType toolType;
    public int range;
    public Camera cam;
    public PickUp pickUp;

    public void Start()
    {
        pickUp = gameObject.GetComponent<PickUp>();
    }
    public void Update()
    {
        RaycastHit hit;

        if (Input.GetButtonDown("Fire1") && pickUp.equipped)
        {
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {

            }

        }
    }
}
