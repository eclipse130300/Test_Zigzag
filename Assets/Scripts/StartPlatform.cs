﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StartPlatform : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(Fading());
        Destroy(gameObject, 1f);
    }
    IEnumerator Fading()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.01f)
        {
            Debug.Log("Works!");
            Color c = GetComponent<Tilemap>().color;
            c.a = ft;
            GetComponent<Tilemap>().color = c;
            yield return null;
        }
    }
}