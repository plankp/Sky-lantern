using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : MonoBehaviour
{
    public float Speed = 1.0f;

    void Update()
    {
        // The lantern just floats upwards
        this.transform.position = this.transform.position + Vector3.up * this.Speed * Time.deltaTime;
    }
}
