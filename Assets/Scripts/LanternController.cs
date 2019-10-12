using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : MonoBehaviour
{
    private Transform trackingTransform;
    private Vector3 previousFrame;
    private Vector3 trackingOffset;

    public float Speed = 1.0f;

    void Update()
    {
        if (this.trackingTransform == null)
        {
            // The lantern just floats upwards
            this.transform.position = this.transform.position + Vector3.up * this.Speed * Time.deltaTime;
            return;
        }

        if (this.trackingTransform.position == this.previousFrame)
        {
            // Ending condition for transform-tracking
            this.trackingTransform = null;
            return;
        }

        this.previousFrame = this.trackingTransform.position;
        this.transform.position = this.previousFrame + this.trackingOffset;
    }

    public void setTrackingTransform(Transform transform, Vector3 trackingOffset) {
        this.trackingTransform = transform;
        this.trackingOffset = trackingOffset;

        // This is just need to be some value that
        // trackingTransform cannot return next
        this.previousFrame = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        // Immediately compute next position
        this.transform.position = this.trackingTransform.position + this.trackingOffset;
    }
}
