using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    private void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 76)
        {
            xPos = Random.Range(-800, 1600);
            zPos = Random.Range(-800, 1600);
            Instantiate(theEnemy, new Vector3(xPos, 200, zPos), Quaternion.identity);
            yield return new WaitForSeconds(2f);
            enemyCount += 1;
        }
    }
}
