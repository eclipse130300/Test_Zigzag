using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameIsActive;
    public bool gameIsOver;
    public bool ballIsDying;

    public Text startText;
    public Text restartText;
    // Start is called before the first frame update
    void Start()
    {
        startText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneLoadCounter.SceneLoadCount < 1)
        {
            if (!gameIsActive && Input.anyKeyDown)
            {
                StartGame();
            }
        }
        else
        {
                StartGame();
        }
        if (Input.anyKeyDown && gameIsOver)
        {
            gameIsOver = false;
            RestartGame();
        }
    }
    void StartGame()
    {
        gameIsActive = true;
        startText.gameObject.SetActive(false);
    }
    public void GameOver()
    {
        ballIsDying = false;
        gameIsOver = true;
        //show Game is Over Tap here to restart
        restartText.gameObject.SetActive(true);
    }
    public void LosingSecuence()
    {
        ballIsDying = true;
        Invoke("GameOver", 1f); //string ref
        //playerisFading
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
