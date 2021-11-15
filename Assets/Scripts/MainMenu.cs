using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text HighScoreUI;

    void Start()
    {
        float PlayerHighScore = PlayerPrefs.GetFloat("HighScore", 0);
        HighScoreUI.text = "High Score : " + Mathf.Round(PlayerHighScore).ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
