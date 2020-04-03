using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private bool goesStraight = true;
    private bool isGrounded;
    private float rotationAngle = 90f;
    private int collisionCounter = 0;

    private Collider2D[] colliders;
    [Inject]
    private GameManager gm;

    [SerializeField] private float speed = 0;
    private bool isFirstFrame = true;
    private float scaleDecrement = 0.001f;

    // Update is called once per frame
    void Update()
    {
        if (!isFirstFrame)
        {
            if (collisionCounter == 0 && gm.state == GameManager.State.STATE_ISPLAYING) //calls GO only once
            {
                gm.GameOver();
            }
        }

        if (!isGrounded) Falling();

        if (isGrounded && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
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
            transform.Translate(Vector2.up * (speed * Time.deltaTime)); 
        }
        // check if the center of the player is inside of other collider
        colliders = Physics2D.OverlapCircleAll(transform.position, 0.0f);
        isGrounded = colliders.Length > 1;
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
            if (gameObject.transform.localScale.x >= 0.001f)
                gameObject.transform.localScale -= new Vector3(scaleDecrement, scaleDecrement, 0);
 
    }

    private void Start()
    {
        StartCoroutine(WaitForSecoundFrame());
    }

    IEnumerator WaitForSecoundFrame()
    {
        yield return null;
        isFirstFrame = false;
    }
}

