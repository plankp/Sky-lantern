using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : MonoBehaviour
{
    private Transform trackingTransform;
    private Vector3 previousFrame;
    private Vector3 trackingOffset;

    private Vector3 velocity = Vector3.zero;

    public float Speed = 1.0f;

    public bool GuidedByTransform {
        get {
            return this.trackingTransform != null;
        }
    }

    void Update()
    {
        if (this.GuidedByTransform)
        {
            if (this.trackingTransform.position == this.previousFrame)
            {
                // Ending condition for transform-tracking
                this.trackingTransform = null;
            }
            else
            {
                this.previousFrame = this.trackingTransform.position;
                this.transform.position = this.previousFrame + this.trackingOffset;
                return;
            }
        }

        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        this.velocity += new Vector3(horz, 0, vert);

        // The lantern just floats upwards
        this.transform.position = this.transform.position + (Vector3.up + this.velocity.normalized) * (this.Speed * Time.deltaTime);
    }

    public void setTrackingTransform(Transform transform, Vector3 trackingOffset)
    {
        this.trackingTransform = transform;
        this.trackingOffset = trackingOffset;

        // This is just need to be some value that
        // trackingTransform cannot return next
        this.previousFrame = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        // Immediately compute next position
        this.transform.position = this.trackingTransform.position + this.trackingOffset;
    }
}
