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
        if (collisionCounter == 0 && gm.gameIsActive)
        {
            gm.LosingSecuence();
            isGruonded = false;
        }

        if(isGruonded && Input.GetMouseButtonDown(0))
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
       if (gm.gameIsActive && !gm.gameIsOver) transform.Translate(Vector2.up * speed * Time.deltaTime);
       
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
}
