using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    private bool hovered;
    public bool empty;

    public GameObject item;
    public Texture itemIcon;


    private void Awake()
    {
        empty = true;
    }

    private void Update()
    {
        if (item) {
            empty = false;

            itemIcon = item.GetComponent<PickUp>().icon;
            this.GetComponent<RawImage>().texture = itemIcon;
        }
        else
        {
            empty = true;
            itemIcon = null;
            this.GetComponent<RawImage>().texture = null;
        }


    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item)
        {
            PickUp thisItem = item.GetComponent<PickUp>();

            if (item.GetComponent<Consumables>())
            {
                item.GetComponent<Consumables>().EatItem();
                Destroy(item);
                print("eat");
            }
        }
        print("clicked");
    }
}
