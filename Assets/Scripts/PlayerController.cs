using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool goesStraight;
    private float rotationAngle = 90f;
    private int collisionCounter = 0;
    private bool isGruonded;
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
        if (Time.timeSinceLevelLoad >= 0.1f) // calls right after restart???!!??..though
        {
            if (collisionCounter == 0 && !gm.ballisFalling && gm.gameIsActive && !gm.isReadyToRestart)
            {
                gm.GameOver();
                isGruonded = false;
            }
        }

        if (gm.ballisFalling)  Fade();

        if (isGruonded && Input.GetMouseButtonDown(0))
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
            isGruonded = true;
        }
    }
    void Fade()
    {
            if (gameObject.transform.localScale.x >= 0)
            {
                gameObject.transform.localScale += new Vector3(-0.001f, -0.001f, -0.01f);
            }
    }
}

