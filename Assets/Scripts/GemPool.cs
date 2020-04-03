using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GemPool : GameObjectPooler<GemScript>
{
    [Inject]
    GemScript.GemScriptFactory groundTileFactory;
    protected override void AddToPull(int count)
    {
        {
            for (int i = 0; i < count; i++)
            {
                var newObject = groundTileFactory.Create();
                newObject.gameObject.SetActive(false);
                objects.Enqueue(newObject);
            }
        }
    }
}
