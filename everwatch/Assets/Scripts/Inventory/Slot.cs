using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public bool hovered;
    public bool empty;

    public GameObject item;
    public Texture itemIcon;
    public Player player;

    private void Awake()
    {
        empty = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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

            if (thisItem.pickUpType == PickUp.PickUpType.consumable)
            {
                item.GetComponent<Consumables>().EatItem();
                Destroy(item);
            }

            if(thisItem.pickUpType == PickUp.PickUpType.weapon && !player.weaponEquipped)
            {
                thisItem.equipped = true;
                item.SetActive(true);
                player.weaponEquipped = true;
            } else if(thisItem.pickUpType == PickUp.PickUpType.weapon && player.weaponEquipped)
            {
                thisItem.equipped = false;
                item.SetActive(false);
                player.weaponEquipped = false;
            }
        }
    }
}
