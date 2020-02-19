using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform lastTilePos;
    public GameObject gemPref;
    public GameObject groundTile;
    public GameObject player;
    private const int startSpawnLimit = 30;
    const float spawnDistance = 30f;
    Vector3 nextTilePos;

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
        GameObject newTile = Instantiate(groundTile, nextTilePos, groundTile.transform.rotation);
        lastTilePos = newTile.transform;
        newTile.transform.SetParent(gameObject.transform);
        int randomGemNumber = Random.Range(0, 6);
        if (randomGemNumber == 0)
        {
            GameObject newGem = Instantiate(gemPref, newTile.transform.position, gemPref.transform.rotation);
            newGem.transform.SetParent(gameObject.transform);
        }
    }
    void PickRandomDirection()
    {
        int randomNum = Random.Range(0, 2);
        {
            if (randomNum == 0)
            {
                nextTilePos = lastTilePos.position + new Vector3(0.7071068f, 0.7071068f, 0f); //hardcode...found it out when I put empty GO instead of the last tile
            }
            else
            {
                nextTilePos = lastTilePos.position + new Vector3(-0.7071068f, 0.7071068f, 0f);
            }
        }
    }
}

