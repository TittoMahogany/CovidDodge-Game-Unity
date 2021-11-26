using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    public GameObject[] components;
    public float minTime, maxTime;
    public float minPos, maxPos;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnComponent());
    }

    IEnumerator SpawnComponent()
    {
        int randComp = Random.Range(0, components.Length);

        Instantiate(components[randComp], new Vector3(transform.position.x, Random.Range(minPos, maxPos), transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        StartCoroutine(SpawnComponent());
    }
}
