using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject inventory;
    public GameObject slotHolder;

    private int slots;
    private Transform[] slot;


    public void Start()
    {
        slots = slotHolder.transform.childCount;
        slot = new Transform[slots];
        DetectInventorySlots();
    }

    public void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    public void AddItem(GameObject item)
    {

    }

    public void DetectInventorySlots()
    {
        for (int i = 0; i < slots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i);
            print(slot[i].name);
        }
    }
}
