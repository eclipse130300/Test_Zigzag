using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
            Destroy(gameObject, 1f);
    }
}
