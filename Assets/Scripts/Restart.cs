using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public static bool isScoreStopped = false;
    public Text scoreUI;

    void Start()
    {
        isScoreStopped = true;
        scoreUI.text = "Your Score: " + Mathf.Round(ScoreManagement.score).ToString();
        
        if (ScoreManagement.score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", ScoreManagement.score);
        }
    }

    public void PlayAgain()
    {
        isScoreStopped = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        isScoreStopped = false;
        SceneManager.LoadScene("MainMenu");
    }
}
