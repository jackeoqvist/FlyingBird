using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int highScore;

    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public GameObject gameOverScreen;
    public AudioSource scoreSound;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        scoreSound.Play();
        score = score + scoreToAdd;
        scoreText.text = score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        loadHighscore();
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);

        var currentHigh = PlayerPrefs.GetInt("highscore");
        if (score > currentHigh)
        {
            PlayerPrefs.SetInt("highscore", score);
            loadHighscore();
        }
    }

    public void loadHighscore()
    {
        
        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore").ToString();
        
    }
}
