using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StartPlatform : MonoBehaviour
{
    private Tilemap tilemap;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(Fading());
        Destroy(gameObject, 1f);
    }
    IEnumerator Fading()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.01f)
        {
            Color c = tilemap.color;
            c.a = ft;
            tilemap.color = c;
            yield return null;
        }
    }
}
