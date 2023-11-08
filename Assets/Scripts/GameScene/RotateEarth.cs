using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    // Update is called once per frame
    public float rotation_speed = 10.0f;
    void Update()
    {
        Earth_Rotation();
    }

    void Earth_Rotation()
    {
        transform.Rotate(Vector3.down * rotation_speed * Time.deltaTime);
    }
}
