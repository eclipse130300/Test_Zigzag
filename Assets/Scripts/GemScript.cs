﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    private GameObject player;
    private GameManager gmScript;
    private SpriteRenderer spriteRenderer;

    public AudioClip gemPickUp;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gmScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (player.transform.position.y > gameObject.transform.position.y)
        {
            StartCoroutine(Fading());
            Destroy(gameObject, 1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gmScript.AddScore();
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
}
