using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVitals : MonoBehaviour
{

    //Variables

    public float maxHealth, maxThirst, maxHunger;
    public float health, thirst, hunger;
    public float hungerIncreaseRate, thirstIncreaseRate;
    public float healthDecreaseRate;



    public void Start()
    {
        health = maxHealth;
    }

    public void Update()
    {
        //Decrease thirst & hunger
        if (thirst < maxThirst)
            thirst += thirstIncreaseRate * Time.deltaTime;
        if (hunger < maxHunger)
            hunger += hungerIncreaseRate * Time.deltaTime;



        //Calculating the health decrease rate
        if(hunger >= maxHunger && thirst >= maxThirst) //Thirst & Hungry
        {
            healthDecreaseRate = 1.25f;
        } else if(hunger >= maxHunger && thirst < maxThirst) //Hungry 
        {
            healthDecreaseRate = .25f;
        } else if(hunger < maxHunger && thirst >= maxThirst) //Thirsty
        {
            healthDecreaseRate = .5f;
        } else if(hunger < maxHunger && thirst < maxHunger) //Neither hungry or thirsty
        {
            healthDecreaseRate = 0f;
        }

        //Decrease health
        if(healthDecreaseRate > 0)
        {
            health -= healthDecreaseRate * Time.deltaTime;
        }

        if(hunger < 0)
        {
            hunger = 0;
        }
        if(thirst < 0)
        {
            thirst = 0;
        }
    }
}
