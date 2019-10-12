using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    private float speed;
    private float startTime;
    private GameObject lerpTo;

    public GameObject Target;

    public float Phi;
    public float Theta;

    public float Distance = 4.0f;

    public Vector3 TargetPosition {
        get {
            if (this.lerpTo == null)
            {
                return this.Target.transform.position;
            }

            Vector3 start = this.Target.transform.position;
            Vector3 end = this.lerpTo.transform.position;

            // Shamelessly taken from Unity's lerp documentation
            float covered = (Time.time - this.startTime) * this.speed;
            float fullDistance = Vector3.Distance(start, end);
            float fraction = covered / fullDistance;

            if (fraction >= 1.0f)
            {
                // Note: lerp is fixed bounded [0, 1]
                // reaching 1 means we have successfully lerped to the other object
                // so we swap the original target object out!
                this.Target = this.lerpTo;
                this.lerpTo = null;
            }

            return Vector3.Lerp(start, end, fraction);
        }
    }

    void Update()
    {
        float x = Distance * Mathf.Sin(Mathf.Deg2Rad * Theta) * Mathf.Cos(Mathf.Deg2Rad * Phi);
        float z = Distance * Mathf.Sin(Mathf.Deg2Rad * Theta) * Mathf.Sin(Mathf.Deg2Rad * Phi);
        float y = Distance * Mathf.Cos(Mathf.Deg2Rad * Theta);

        Vector3 targetPosition = this.TargetPosition;
        this.transform.position = new Vector3(x, y, z) + targetPosition;
        this.transform.LookAt(targetPosition);
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

    public void LerpToNewTarget(GameObject newTarget, float speed)
    {
        this.lerpTo = newTarget;

        this.speed = speed;
        this.startTime = Time.time;
    }
}
