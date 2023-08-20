using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource musicSrc;
    public Text highestScoreText;
    public GameObject newHighestScoreObj;
    public BirdScript bird;


    [ContextMenu("Increase Score")] // para poder ejecutar la función desde el menu de unity, sirve mucho para testear
    public void addScore()
    {
        if (bird.isAlive)
        {
            score++;
            updateScore();
        }
    }

    public void restartGame()
    {
        score = 0;
        updateScore();
        newHighestScoreObj.SetActive(false);
        highestScoreText.text = PlayerPrefs.GetInt("highestScore").ToString();
        musicSrc.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // recarga el nivel actual
        Debug.Log("highest score:" + PlayerPrefs.GetInt("highestScore").ToString());
    }

    private void updateScore()
    {
        scoreText.text = score.ToString();
    }
    [ContextMenu("Game Over")]
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        musicSrc.Stop();
        if (score > PlayerPrefs.GetInt("highestScore"))
        {
            PlayerPrefs.SetInt("highestScore", score);
            newHighestScoreObj.GetComponent<Text>().text = "New HIghest score! : " + PlayerPrefs.GetInt("highestScore").ToString();
            newHighestScoreObj.SetActive(true);
        }
        Debug.Log("Game over. HIghest score: " + PlayerPrefs.GetInt("highestScore").ToString());
    }
    public void Start()
    {
        highestScoreText.text = PlayerPrefs.GetInt("highestScore").ToString();
    }
}
