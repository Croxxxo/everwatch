using UnityEngine;

public class Tools : MonoBehaviour
{
    public enum ToolType { axe, pickaxe, hammer };
    public ToolType toolType;
    [SerializeField] private int range;
    [SerializeField] private int damage;
    public Camera cam;
    private PickUp pickUp;
    [SerializeField] private float useCooldown;
    [SerializeField] private float cooldownAmount;



    public void Start()
    {
        pickUp = gameObject.GetComponent<PickUp>();
    }
    public void Update()
    {
        RaycastHit hit;
        if(useCooldown > 0)
        {
            useCooldown -= Time.deltaTime;
        } else if(useCooldown < 0)
        {
            useCooldown = 0;
        }

        if (Input.GetButtonDown("Fire1") && pickUp.equipped && useCooldown <= 0)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                if (hit.transform.gameObject.GetComponent<Tree>() && toolType == ToolType.axe)
                {
                    hit.transform.gameObject.GetComponent<Tree>().TakeDamage(damage);
                    print("that's a tree!");
                }
                else if (hit.transform.gameObject.GetComponent<Rock>() && toolType == ToolType.pickaxe)
                {
                    hit.transform.gameObject.GetComponent<Rock>().TakeDamage(damage);
                }

                useCooldown = cooldownAmount;
            }
        }
    }
}
