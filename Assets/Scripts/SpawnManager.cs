using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpawnManager : MonoBehaviour
{
    public Transform lastTilePos;
    [Inject]
    private Transform player;

    [SerializeField] int gemSpawnСhance = 20;
    [SerializeField] int startSpawnLimit = 20;
    [SerializeField] float spawnDistance = 20f;
    
    Vector3 upRightDir;
    Vector3 upLeftDir;
    Vector3 nextTilePos;

    private GroundTile lastSpawnedTile;
    
    void Start()
    {
        upRightDir = new Vector3(1, 1, 0f).normalized;
        upLeftDir = new Vector3(-1, 1, 0f).normalized;
        
        for (int i = 0; i < startSpawnLimit; i++)
        {
            InstantiateTileAndGem();
        }
    }

    void Update()
    {
        if (Vector3.Distance(player.position, lastTilePos.position) <= spawnDistance)
        {
            InstantiateTileAndGem();
        }
    }
    void InstantiateTileAndGem()
    {
        PickRandomDirection();
        InstantiateTile();
        InstantiateGem();
    }

    private void PickRandomDirection()
    {
        var randomNum = Random.Range(0, 2);
        nextTilePos = randomNum == 0
            ? lastTilePos.position + upRightDir
            : lastTilePos.position + upLeftDir;
    }
    void InstantiateTile()
    {
        lastSpawnedTile = TilePool.Instance.GetFromPull();
        lastSpawnedTile.transform.position = nextTilePos;
        
        lastTilePos = lastSpawnedTile.transform;
    }

    void InstantiateGem()
    {
        if (!lastSpawnedTile.isActive) return;
        var randomGemNumber = Random.Range(0,  101); 
        if (randomGemNumber >= gemSpawnСhance) return; //20 % chance
        var newGem = GemPool.Instance.GetFromPull();
        newGem.gameObject.transform.position = lastSpawnedTile.transform.position;
    }
}

