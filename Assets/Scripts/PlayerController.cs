using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool goesStraight;
    private float rotationAngle = 90f;
    private int collisionCounter = 0;
    private bool isGruonded;
    public Collider2D[] colliders;
    private GameManager gm;
    [SerializeField] private float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        goesStraight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >= 0.1f) // without it, calls right after restart??!!??..
        {
            if (collisionCounter == 0 && !gm.ballisFalling && gm.gameIsActive && !gm.isReadyToRestart) //calls GO only once
            {
                gm.GameOver();
            }
        }

        if (gm.ballisFalling) Falling();
        // Input.GetMouseButtonDown(0) PC 
        if (isGruonded && Input.touchCount >= 1)
        {
            if (goesStraight)
            {
                transform.Rotate(Vector3.forward, -rotationAngle);
                goesStraight = false;
            }
            else
            {
                transform.Rotate(Vector3.forward, rotationAngle);
                goesStraight = true;
            }
        }
        if (gm.gameIsActive) transform.Translate(Vector2.up * speed * Time.deltaTime);
        // check if the center of the player is inside of other collider
            colliders = Physics2D.OverlapCircleAll(transform.position, 0.0f);
            if (colliders.Length == 1) //always detects player - so 1;
            {
                isGruonded = false;
            }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GroundTile")
        || collision.gameObject.CompareTag("StartPlatform")) collisionCounter--;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GroundTile") ||
            collision.gameObject.CompareTag("StartPlatform")
            )
        {
            collisionCounter++;
            isGruonded = true;
        }
    }
    void Falling()
    {
            if (gameObject.transform.localScale.x >= 0) // gradually decrease the size of the ball, till miniscule amount
            {
                gameObject.transform.localScale += new Vector3(-0.001f, -0.001f, -0.01f);
            }
    }
}

