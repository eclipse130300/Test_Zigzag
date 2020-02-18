﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    private GameObject player;
    private GameManager gm;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (player != null)
        {
            if (player.transform.position.y > gameObject.transform.position.y)
            {
                StartCoroutine(Fading());
                Destroy(gameObject, 1f);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gm.AddScore();
        Destroy(gameObject);
    }

    IEnumerator Fading()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.01f)
        {
            Color c = GetComponent<SpriteRenderer>().color;
            c.a = ft;
            GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
    }
}
