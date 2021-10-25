using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    public float minTime, maxTime;
    public float minPos, maxPos;
    
    void Start()
    {
        StartCoroutine(SpawnVirus());
    }

    IEnumerator SpawnVirus()
    {
        Instantiate(obstacle, new Vector3(transform.position.x, Random.Range(minPos, maxPos), transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        StartCoroutine(SpawnVirus());
    }
}
