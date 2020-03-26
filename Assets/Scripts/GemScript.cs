using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GemScript : MonoBehaviour
{
    private GameObject player;
    private GameManager gm;
    private SpriteRenderer spriteRenderer;

    public AudioClip gemPickUp;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (player.transform.position.y > gameObject.transform.position.y) //checks distance
        {
            StartCoroutine(Fading()); //for fading
            Destroy(gameObject, 1f);
        }
    }// collects item -- addsScore, plays sound, destroyGO
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        gm.AddScore();
        AudioSource.PlayClipAtPoint(gemPickUp, Camera.main.transform.position + Vector3.forward , 1f);
        Destroy(gameObject);
    }

    IEnumerator Fading()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.01f)
        {
            Color c = spriteRenderer.color;
            c.a = ft;
            spriteRenderer.color = c;
            yield return null;
        }
    }
    public class GemScriptFactory : PlaceholderFactory<GemScript>
    {

    }
}
