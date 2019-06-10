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
        while (passiveCount < 10)
        {
            xPos = Random.Range(-20, 320);
            zPos = Random.Range(-20, 20);
            Instantiate(thePassive, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            passiveCount += 1;
        }
    }
}
