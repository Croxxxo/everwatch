using System.Collections;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int respawnTime;
    private GameObject player;
    private Inventory inventory;
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject newStone;

    private void Start()
    {
        health = maxHealth;

        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyRock();
        }
    }

    private void DestroyRock()
    {
        gameObject.GetComponent<MeshCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        newStone = Instantiate(stone, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        newStone.transform.SetParent(gameObject.transform);
    }
    public void StartRockRespawn()
    {
        StartCoroutine(RespawnRock());
    }
    public IEnumerator RespawnRock()
    {
        yield return new WaitForSeconds(respawnTime);
        gameObject.GetComponent<MeshCollider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        health = maxHealth;
    }
}
