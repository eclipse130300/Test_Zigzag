using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameIsActive;
    public bool gameIsOver;

    public Text startText;
    public Text restartText;
    // Start is called before the first frame update
    void Start()
    {
        gameIsActive = false;
        gameIsOver = false;
        startText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsActive && Input.anyKeyDown && !gameIsOver)
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
        gameIsOver = true;
        //show Game is Over Tap here to restart
        restartText.gameObject.SetActive(true);
    }
    public void LosingSecuence()
    {
        gameIsActive = false;
        Invoke("GameOver", 1f); //string ref
        Debug.Log("LosingSecuence Called");
        //playerisFading
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
