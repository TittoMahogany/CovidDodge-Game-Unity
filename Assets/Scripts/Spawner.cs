using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    public float minTime, maxTime;
    public float minPos, maxPos;

    public float currentSpeed;
    public float maxSpeed;
    public float acceleration;
    
    void Start()
    {
        StartCoroutine(SpawnVirus());
    }

    IEnumerator SpawnVirus()
    {
        GameObject instance = Instantiate(obstacle, new Vector3(transform.position.x, Random.Range(minPos, maxPos), transform.position.z), Quaternion.identity);
        
        if(currentSpeed < maxSpeed) {
            currentSpeed += acceleration * Time.deltaTime;
        }

        instance.GetComponent<Obstacle>().speed = currentSpeed;

        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        StartCoroutine(SpawnVirus());
    }
}
