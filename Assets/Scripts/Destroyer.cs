using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{
    public float score;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Building"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Cloud"))
        {
            Destroy(other.gameObject);
        }
    }
}
