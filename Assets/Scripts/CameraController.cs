using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public GameObject Target;

    public float Phi;
    public float Theta;

    public float Distance = 4.0f;

    void Update()
    {
        float x = Distance * Mathf.Sin(Mathf.Deg2Rad * Theta) * Mathf.Cos(Mathf.Deg2Rad * Phi);
        float z = Distance * Mathf.Sin(Mathf.Deg2Rad * Theta) * Mathf.Sin(Mathf.Deg2Rad * Phi);
        float y = Distance * Mathf.Cos(Mathf.Deg2Rad * Theta);

        this.transform.position = new Vector3(x, y, z) + Target.transform.position;
        this.transform.LookAt(Target.transform);
    }

    public void RotateBy(float theta, float phi)
    {
        this.Phi += phi;
        this.Theta += theta;
    }

    public void ZoomBy(float dist)
    {
        this.Distance += dist;
    }
}
