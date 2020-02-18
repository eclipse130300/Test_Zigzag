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

    public Text startText;
    public Text restartText;
    // Start is called before the first frame update
    void Start()
    {
        startText.gameObject.SetActive(true);
        if (SceneLoadCounter.SceneLoadCount == 0)
        {
            Debug.Log("Сработало");
            gameIsActive = false;
            ballisFalling = false;
        }
        else
        {
            gameIsActive = false;
            ballisFalling = false;
            StartGame();
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneLoadCounter.SceneLoadCount == 0)
        {
            if (Input.anyKeyDown && !gameIsActive && !ballisFalling && !isReadyToRestart)
            {
                StartGame();
            }
        }

        if (Input.anyKeyDown && isReadyToRestart && !gameIsActive) //-
        {
            RestartGame();
        }
    }
    void StartGame()
    {
        startText.gameObject.SetActive(false);
        gameIsActive = true;
        Debug.Log("START");
    }
    public void GameOver()
    {
        //show Game is Over Tap here to restart
        ballisFalling = true;
        Invoke("ShowRestartText", 1f);
        Debug.Log("GAME OVER");
    }

    public void RestartGame()
    {
        isReadyToRestart = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name , LoadSceneMode.Single);
        StartCoroutine(RestartCoroutine());
    }

    void ShowRestartText()
    {
        restartText.gameObject.SetActive(true);
        gameIsActive = false; //!!!
        ballisFalling = false;
        isReadyToRestart = true;
    }
    IEnumerator RestartCoroutine()
    {
        yield return null;
    }
}
