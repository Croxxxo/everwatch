using System.Collections;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int growTime;
    private GameObject player;
    private Inventory inventory;
    [SerializeField] private GameObject stump;
    [SerializeField] private GameObject newStump;
    [SerializeField] private GameObject wood;

    private void Start()
    {
        maxHealth = 100;
        health = maxHealth;
        growTime = 5;

        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            DestroyTree();
        }
    }

    private void DestroyTree()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        newStump = Instantiate(stump, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        newStump.transform.SetParent(gameObject.transform);
    }
    public void StartTreePlant()
    {
        StartCoroutine(PlantTree());
    }
    public IEnumerator PlantTree()
    {
        yield return new WaitForSeconds(growTime);
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        health = maxHealth;
    }
}
