using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private bool hovered;
    private bool isUsed;

    private GameObject item;
    private Texture itemIcon;


    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }


}
