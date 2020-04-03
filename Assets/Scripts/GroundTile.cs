using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GroundTile : MonoBehaviour
{
     SpriteRenderer _spriteRenderer;
     public bool isActive;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(Fading());
        Invoke(nameof(BackToPull), 2f);
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

    private void OnEnable()
    {
        isActive = true;
        Color spriteRendererColor = _spriteRenderer.color;
        spriteRendererColor.a = 1;
        _spriteRenderer.color = spriteRendererColor;
    }

    private void OnDisable()
    {
        isActive = false;
    }

    void BackToPull()
    {
        TilePool.Instance.ReturnToPull(this);
    }
    
    public class GroundTileFactory : PlaceholderFactory<GroundTile>
    {

    }
}
