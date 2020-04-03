using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GemScript : MonoBehaviour
{
    [Inject]
    private Transform player;
    [Inject]
    private GameManager gm;
    private SpriteRenderer spriteRenderer;

    public AudioClip gemPickUp;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (player.position.y > transform.position.y)
        {
            StartCoroutine(Fading());
            Invoke(nameof(BackToPull), 2f);
        }
        
    }
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

    private void OnEnable()
    {
        Color spriteRendererColor = spriteRenderer.color;
        spriteRendererColor.a = 1f;
        spriteRenderer.color = spriteRendererColor;
    }

    void BackToPull()
    {
        GemPool.Instance.ReturnToPull(this);
    }
    public class GemScriptFactory : PlaceholderFactory<GemScript>
    {

    }
}
