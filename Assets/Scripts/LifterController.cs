using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LifterController : MonoBehaviour
{
    private bool firedAlready = false;

    private Animator animator;

    public GameObject LanternPrefab;
    public Vector3 PlacementOffset;
    public Transform ReferencePoint;

    public CameraController Camera;

    void Start()
    {
        this.animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetAxis("Jump") != 0)
        {
            if (this.firedAlready)
            {
                // We are done... (animation is still playing)
                return;
            }

            this.firedAlready = true;

            // For some reason, using triggers in Animator (state-machine)
            // causes the next part to break... (disappoint)
            animator.Play("Standstill to Lift");

            // Create a new lantern to lift-off
            GameObject lantern = GameObject.Instantiate(LanternPrefab, this.transform.position, Quaternion.Euler(-90, 0, 0));
            LanternController lanternController = lantern.GetComponent<LanternController>();
            lanternController.setTrackingTransform(this.ReferencePoint, this.PlacementOffset);

            // Lantern says "Notice me senpai~~"
            // (joke, camera needs to look at lantern)
            // speed factor >= 0.5 (because that is the speed the lantern is moving at...)
            this.Camera.LerpToNewTarget(lantern, 0.78f);
        }
    }
}
