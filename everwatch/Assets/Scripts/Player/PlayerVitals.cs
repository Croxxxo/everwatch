using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerVitals : MonoBehaviour
{

    //Variables

    public float maxHealth, maxThirst, maxHunger;
    public float health, thirst, hunger;
    public float hungerIncreaseRate, thirstIncreaseRate;
    public float healthDecreaseRate;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider staminaSlider;
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private Slider thirstSlider;
    private PlayerMove pm;



    public void Start()
    {
        health = maxHealth;
        pm = GetComponent<PlayerMove>();
    }

    public void Update()
    {
        if (health <= 0)
            SceneManager.LoadScene("DeadScene");
        //Decrease thirst & hunger
        if (thirst < maxThirst)
            thirst += thirstIncreaseRate * Time.deltaTime;
        if (hunger < maxHunger)
            hunger += hungerIncreaseRate * Time.deltaTime;


        healthSlider.value = health / maxHealth;
        staminaSlider.value = pm.stamina / 100;
        hungerSlider.value = hunger / maxHunger;
        thirstSlider.value = thirst / maxThirst;


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
