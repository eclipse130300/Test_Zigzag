using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpawnManager : MonoBehaviour
{
    public Transform lastTilePos;
    public GameObject gemPref;
    public GameObject groundTile;
    public GameObject player;

    [SerializeField] int startSpawnLimit = 20;
    [SerializeField] float spawnDistance = 20f;

    [Inject]
    GemScript.GemScriptFactory gemScriptFactory;
    [Inject]
    GroundTile.GroundTileFactory groundTileFactory;

    GameObject newTile;
    Vector3 upRightDir;
    Vector3 upLeftDir;
    Vector3 nextTilePos;
    private void Awake()
    {
        upRightDir = new Vector3(1, 1, 0f).normalized;
        upLeftDir = new Vector3(-1, 1, 0f).normalized;
    }
    void Start()
    {
        for (int i = 0; i < startSpawnLimit; i++)
        {
            InstantiateTileAndGem();
        }
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, lastTilePos.position) <= spawnDistance)
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
    void PickRandomDirection()
    {
        int randomNum = Random.Range(0, 2);
        {
            if (randomNum == 0)
            {
                nextTilePos = lastTilePos.position + upRightDir; //diagonally right
            }
            else
            {
                nextTilePos = lastTilePos.position + upLeftDir; //diagonally left
            }
        }
    }
    void InstantiateTile()
    {
        newTile = groundTileFactory.Create().gameObject;
        newTile.transform.position = nextTilePos;
        lastTilePos = newTile.transform;
    }
    void InstantiateGem()
    {
        int randomGemNumber = Random.Range(0, 6); //20 % chance
        if (randomGemNumber == 0)
        {
            GameObject newGem = gemScriptFactory.Create().gameObject;
            newGem.transform.position = newTile.transform.position;
        }
    }
}

