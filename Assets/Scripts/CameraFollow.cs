using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject pivot;
    Vector3 offset;

    // Update is called once per frame
    private void Awake()
    {
        offset.z = pivot.transform.position.z + 1f; //orthographic cam, so 1 is enough
    }

    private void LateUpdate()
    {
        transform.position = pivot.transform.position - offset;
    }
}
