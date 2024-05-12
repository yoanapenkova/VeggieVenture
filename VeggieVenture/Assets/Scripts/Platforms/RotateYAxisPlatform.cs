using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateYAxisPlatform : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation in degrees per second

    void Update()
    {
        // Rotate the platform along the Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
