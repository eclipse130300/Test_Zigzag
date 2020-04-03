using UnityEngine;
using System;
using Zenject;

public class ZigZagInstaller : MonoInstaller
{
    public GameObject _gemPref;
    public GameObject _tilePref;

    public override void InstallBindings()
    {
        Container.BindFactory<GemScript, GemScript.GemScriptFactory>().
            FromComponentInNewPrefab(_gemPref).
            WithGameObjectName("Gem").
            UnderTransformGroup("Gems");

        Container.BindFactory<GroundTile, GroundTile.GroundTileFactory>().
            FromComponentInNewPrefab(_tilePref).
            WithGameObjectName("GroundTile").
            UnderTransformGroup("Tiles");
        
    }
}