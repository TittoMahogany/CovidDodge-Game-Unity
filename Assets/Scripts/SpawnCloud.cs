using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloud : MonoBehaviour
{
    public GameObject[] cloud;
    public float minTime, maxTime;
    public float minPos, maxPos;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCloudy());
    }

    IEnumerator SpawnCloudy()
    {
        int randCloud = Random.Range(0, cloud.Length);

        Instantiate(cloud[randCloud], new Vector3(transform.position.x, Random.Range(minPos, maxPos), transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        StartCoroutine(SpawnCloudy());
    }
}
