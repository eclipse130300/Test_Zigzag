using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameIsActive;
    public bool ballisFalling;
    public bool isReadyToRestart;
    public int score;

    public Text startText;
    public Text restartText;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
         startText.gameObject.SetActive(true);

        if (SceneLoadCounter.SceneLoadCount >= 1)
        {
            StartGame();
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneLoadCounter.SceneLoadCount == 0)
        {
            if (Input.anyKeyDown && !gameIsActive && !ballisFalling && !isReadyToRestart) //To listen to player's input for the very first secouns
            {
                StartGame();
            }
        }

        if (Input.anyKeyDown && isReadyToRestart && !gameIsActive) //To listen to player's input  after the game ends
        {
            RestartGame();
        }

        scoreText.text = "Score: " + score;
    }
    void StartGame()
    {
        startText.gameObject.SetActive(false);
        gameIsActive = true;
    }
    public void GameOver()
    {
        ballisFalling = true;
        Invoke("ShowRestartText", 1f); //small delay for sound?
    }

    public void RestartGame()
    {
        isReadyToRestart = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name , LoadSceneMode.Single);
    }

    void ShowRestartText() //show restart text, and wait for player's input
    {
        restartText.gameObject.SetActive(true);
        gameIsActive = false; //!!!
        ballisFalling = false;
        isReadyToRestart = true;
    }
    public void AddScore()
    {
        score++;
    }
}
