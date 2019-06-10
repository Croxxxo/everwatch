﻿using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{

    public GameObject inventory;
    public GameObject slotHolder;
    public GameObject itemManager;
    private Canvas invCanvas;
    private bool inventoryEnabled;
    public bool cursorLocked;

    private TextMeshProUGUI itemAmount;
    private int slots;
    private Transform[] slot;

    private GameObject itemPickedUp;
    private bool itemAdded;
    public bool weaponEquipped;


    public void Start()
    {
        slots = slotHolder.transform.childCount;
        slot = new Transform[slots];
        invCanvas = inventory.GetComponent<Canvas>();
        DetectInventorySlots();
        cursorLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
            if (cursorLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                cursorLocked = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                cursorLocked = true;
            }
        }

        if (inventoryEnabled)
            invCanvas.enabled = true;
        else
            invCanvas.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PickUp>() && other.GetComponent<PickUp>().pickedUp == false)
        {
            itemPickedUp = other.gameObject;
            if (itemPickedUp.CompareTag("Stump"))
            {
                itemPickedUp.GetComponentInParent<Tree>().StartTreePlant();
            } else if (itemPickedUp.CompareTag("Stone"))
            {
                itemPickedUp.GetComponentInParent<Rock>().StartRockRespawn();
            }
            AddItem(itemPickedUp);
        }
    }

    public void AddItem(GameObject item)
    {
        for (int i = 0; i < slots; i++)
        {
            if(slot[i].GetComponent<Slot>().itemHolding == itemPickedUp.transform.name && slot[i].GetComponent<Slot>().numberOfItems < slot[i].GetComponent<Slot>().maxNumberOfItems)
            {
                slot[i].GetComponent<Slot>().numberOfItems++;
                itemAmount = slot[i].GetComponentInChildren<TextMeshProUGUI>();
                itemAmount.text = slot[i].GetComponent<Slot>().numberOfItems.ToString();
                Destroy(item);
                break;
            }

            if (slot[i].GetComponent<Slot>().empty)
            {
                slot[i].GetComponent<Slot>().item = itemPickedUp;
                slot[i].GetComponent<Slot>().itemIcon = itemPickedUp.GetComponent<PickUp>().icon;
                slot[i].GetComponent<Slot>().itemHolding = item.transform.name;
                slot[i].GetComponent<Slot>().numberOfItems++;

                item.transform.parent = itemManager.transform;
                item.transform.position = itemManager.transform.position;

                item.transform.localPosition = item.GetComponent<PickUp>().position;
                item.transform.localEulerAngles = item.GetComponent<PickUp>().rotation;
                item.transform.localScale = item.GetComponent<PickUp>().scale;
                

                item.GetComponent<PickUp>().pickedUp = true;
                item.SetActive(false);
                break;
            }
        }
    }

    public void DetectInventorySlots()
    {
        for (int i = 0; i < slots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i);
        }
    }
}
