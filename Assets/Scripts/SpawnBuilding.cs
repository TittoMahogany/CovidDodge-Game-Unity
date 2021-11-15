using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuilding : MonoBehaviour
{

    public GameObject[] building;
    public float minTime, maxTime;
    public float minPos, maxPos;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBuild());
    }

    IEnumerator SpawnBuild()
    {
        int randBuilding = Random.Range(0, building.Length);

        Instantiate(building[randBuilding], new Vector3(transform.position.x, Random.Range(minPos, maxPos), transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        StartCoroutine(SpawnBuild());
    }
}
