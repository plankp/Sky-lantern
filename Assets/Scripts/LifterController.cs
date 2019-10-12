using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LifterController : MonoBehaviour
{
    private bool firedAlready = false;

    private Animator animator;
    private Transform hand;

    public GameObject LanternPrefab;
    public Vector3 PlacementOffset;

    void Start()
    {
        this.animator = this.GetComponent<Animator>();
        this.hand = this.transform.Find("Armature/Hand.right");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (this.firedAlready)
            {
                // We are done... (animation is still playing)
                return;
            }

            this.firedAlready = true;

            animator.Play("Lift lantern off");
            GameObject obj = GameObject.Instantiate(LanternPrefab, this.transform.position, Quaternion.Euler(-90, 0, 0));

            LanternController lanternHack = obj.GetComponent<LanternController>();
            lanternHack.setTrackingTransform(this.hand, this.PlacementOffset);
        }
    }
}
