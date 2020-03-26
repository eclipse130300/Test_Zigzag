using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GroundTile : MonoBehaviour
{
     SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
            Color c = _spriteRenderer.color;
            c.a = ft;
            _spriteRenderer.color = c;
            yield return null;
        }     
    }
    public class GroundTileFactory : PlaceholderFactory<GroundTile>
    {

    }
}
