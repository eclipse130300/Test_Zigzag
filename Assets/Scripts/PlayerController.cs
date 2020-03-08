using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool goesStraight = true;
    private bool isGrounded;
    private float rotationAngle = 90f;
    private int collisionCounter = 0;

    public Collider2D[] colliders;
    public GameManager gm;

    [SerializeField] private float speed = 0;
    private bool isFirstFrame;
    float scaleDecrement = 0.001f;

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad>= 0.01f) // calls GameOver 0.1 after reload, otherwise calls GO right after restart
        {
            if (collisionCounter == 0 && gm.state == GameManager.State.STATE_ISPLAYING) //calls GO only once
            {
                gm.GameOver();
            }
        }

        if (!isGrounded) Falling();

        if (isGrounded && (Input.touchCount > 0 || Input.GetMouseButtonDown(0)))
        {
            //Touch touch = Input.GetTouch(0);
            //if (touch.phase == TouchPhase.Began)
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
        }
        if (gm.state == GameManager.State.STATE_ISPLAYING || gm.state == GameManager.State.STATE_ISFALLING)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime); //push player forward
        }
        // check if the center of the player is inside of other collider
        colliders = Physics2D.OverlapCircleAll(transform.position, 0.0f);
        if (colliders.Length <= 1) isGrounded = false; //always detects player - so 1
        else
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GroundTile")) collisionCounter--;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GroundTile"))
        {
            collisionCounter++;
        }
    }
    void Falling()
    {
            if (gameObject.transform.localScale.x >= 0.001f) // gradually decrease the size of the ball, till miniscule amount
            {
            gameObject.transform.localScale -= new Vector3(scaleDecrement, scaleDecrement, 0);
            }
    }
}

