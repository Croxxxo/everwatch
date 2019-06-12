using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    public GameObject thePassive;
    public int xPos;
    public int zPos;
    public int passiveCount;

    private void Start()
    {
        StartCoroutine(PassiveDrop());
    }

    IEnumerator PassiveDrop()
    {
        while (passiveCount < 76)
        {
            xPos = Random.Range(-800, 1600);
            zPos = Random.Range(-800, 1600);
            Instantiate(thePassive, new Vector3(xPos, 200, zPos), Quaternion.identity);
            yield return new WaitForSeconds(2f);
            passiveCount += 1;
        }
    }
}
