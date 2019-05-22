using UnityEngine;

public class Consumables : MonoBehaviour
{
    public enum ConsumableType {Food, Water, Health};
    public ConsumableType consumeableType;
    public int restoreAmount;
    public PlayerVitals pv;

    public bool eat;

    public void Start()
    {
        pv = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerVitals>();
    }

    public void Update()
    {
        if (eat)
            EatItem();
    }

    public void EatItem()
    {
        if (consumeableType == ConsumableType.Food)
        {
            pv.hunger -= restoreAmount;
        } else if(consumeableType == ConsumableType.Water)
        {
            pv.thirst -= restoreAmount;
        } else if(consumeableType == ConsumableType.Health)
        {
            pv.health += restoreAmount;
        }
    }
}
