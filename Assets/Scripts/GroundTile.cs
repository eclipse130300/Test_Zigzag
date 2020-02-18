using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
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
            Color c = GetComponent<SpriteRenderer>().color;
            c.a = ft;
            GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }     
    }
}
