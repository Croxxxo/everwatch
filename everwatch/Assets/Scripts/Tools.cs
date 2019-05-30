using UnityEngine;

public class Tools : MonoBehaviour
{
    public enum ToolType {axe, pickaxe};
    public ToolType toolType;
    [SerializeField] private int range;
    [SerializeField] private int damage;
    public Camera cam;
    private PickUp pickUp;


    public void Start()
    {
        pickUp = gameObject.GetComponent<PickUp>();
        damage = 10;
    }
    public void Update()
    {
        RaycastHit hit;

        if (Input.GetButtonDown("Fire1") && pickUp.equipped)
        {
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                if (hit.transform.gameObject.GetComponent<Tree>() && toolType == ToolType.axe)
                {
                    hit.transform.gameObject.GetComponent<Tree>().TakeDamage(damage);
                    print("that's a tree!");
                }
            }

        }
    }
}
