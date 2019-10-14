using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : MonoBehaviour
{
    private Transform trackingTransform;
    private Vector3 previousFrame;
    private Vector3 trackingOffset;

    public float Speed = 1.0f;
    public float InputScale = 1.0f;

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

        // The lantern just floats upwards (with sideway sway)
        this.transform.position += (this.Speed * Vector3.up + this.InputScale * new Vector3(horz, 0, vert)) * Time.deltaTime;
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
