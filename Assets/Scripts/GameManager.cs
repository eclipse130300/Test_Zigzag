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

    public AudioClip fallingSound;
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
        { //Input.anyKeyDown PC
            if (Input.anyKeyDown && !gameIsActive && !ballisFalling && !isReadyToRestart) //To listen to player's input for the very first secouns
            {
                StartGame();
            }
        }
        // Input.anyKeyDown PC Input.touchCount >= 1 andr?
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
        AudioSource.PlayClipAtPoint(fallingSound, Camera.main.transform.position + new Vector3(0,0,1), 1f);
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
