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

    void Start()
    {
        this.animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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

            GameObject obj = GameObject.Instantiate(LanternPrefab, this.transform.position, Quaternion.Euler(-90, 0, 0));
            LanternController lanternController = obj.GetComponent<LanternController>();
            lanternController.setTrackingTransform(this.ReferencePoint, this.PlacementOffset);
        }
    }
}
