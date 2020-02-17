using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject[] allTiles;
    public GameObject gemPref;
    // Start is called before the first frame update
    void Start()
    {
        allTiles = GameObject.FindGameObjectsWithTag("GroundTile");
        foreach (GameObject tile in allTiles)
        {
            int randomNum = Random.Range(0, 6);
            if(randomNum == 0)
            {
                Instantiate(gemPref, tile.transform.position, gemPref.transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
