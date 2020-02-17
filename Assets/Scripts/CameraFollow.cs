using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject pivot;
    [SerializeField] private float cameraOffset = -10f;
    Vector3 offset;
    // Update is called once per frame
    private void Awake()
    {
        offset.z = pivot.transform.position.z - cameraOffset;
    }

    private void LateUpdate()
    {
        transform.position = pivot.transform.position - offset;
    }
}
