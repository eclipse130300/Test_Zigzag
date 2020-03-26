using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;

    public Text startText;
    public Text restartText;
    public Text scoreText;

    public AudioClip fallingSound;

    public enum State
    {
        STATE_STARTGAME,
        STATE_ISPLAYING,
        STATE_ISFALLING,
        STATE_ENDGAME,
    };
    public State state;
    // Start is called before the first frame update

    void Start()
    {
        startText.gameObject.SetActive(true);
        state = State.STATE_STARTGAME;
    }
    // Update is called once per frame
    void Update()
    {

        if (/*Input.touchCount > 0*/ Input.GetMouseButtonDown(0) && state == State.STATE_STARTGAME) //To listen to player's input for the very first secounds
        {
            StartGame();
        }

        else if (/*Input.touchCount > 0*/Input.GetMouseButtonDown(0) && state == State.STATE_ENDGAME) //To listen to player's input  after the game ends
        {
            RestartGame();
        }
        scoreText.text = "Score: " + score;
    }
    void StartGame()
    {
        state = State.STATE_ISPLAYING;
        startText.gameObject.SetActive(false);
    }
    public void GameOver()
    {
        state = State.STATE_ISFALLING;
        AudioSource.PlayClipAtPoint(fallingSound, Camera.main.transform.position + Vector3.forward, 1f);
        Invoke("ShowRestartText", 1f); //small delay for sound?
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name , LoadSceneMode.Single);
    }

    void ShowRestartText() //show restart text, and wait for player's input
    {
        state = State.STATE_ENDGAME;
        restartText.gameObject.SetActive(true);
    }
    public void AddScore()
    {
        score++;
    }
}
