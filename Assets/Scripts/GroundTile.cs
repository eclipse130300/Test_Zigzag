using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            Color c = spriteRenderer.color;
            c.a = ft;
            spriteRenderer.color = c;
            yield return null;
        }     
    }
}
