using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float rotateSpeed = 0.5F;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
