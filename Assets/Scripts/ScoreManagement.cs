using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    public Text scoreUI;
    public static float score;
    public float pointPerSec;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
         if (!Restart.isScoreStopped){
            score += pointPerSec * Time.deltaTime;
        }

        scoreUI.text = Mathf.Round(score).ToString();
    
    }
}
