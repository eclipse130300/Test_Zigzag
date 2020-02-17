using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameIsActive;
    private bool gameIsOver;

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
            if (Input.anyKeyDown && !gameIsActive)
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
        gameIsActive = false;
        gameIsOver = true;
        //show Game is Over Tap here to restart
        Invoke("ShowRestartText", 1f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ShowRestartText()
    {
        restartText.gameObject.SetActive(true);
    }

}
