using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    public GameObject[] Rotating;
    public Transform PivotPoint;
    public Vector3 PivotOffset;
    public GameObject[] Translating;

    public Vector3 RotationPointWorld
    {
        get
        {
            return this.PivotPoint.position + this.PivotPoint.TransformDirection(this.PivotOffset);
        }
    }

    private float elapsed;

    // Update is called once per frame
    void Update()
    {
        this.elapsed += Time.deltaTime;

        RotateBy(5 * Time.deltaTime);
        TranslateBy(0.06f * Mathf.Sin(this.elapsed + Mathf.PI / 4));
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(this.RotationPointWorld, Vector3.up * 10);
    }

    public void RotateBy(float angle)
    {
        foreach (GameObject gobj in this.Rotating)
        {
            gobj.transform.RotateAround(this.RotationPointWorld, Vector3.up, angle);
        }
    }

    public void TranslateBy(float units)
    {
        foreach (GameObject gobj in this.Translating)
        {
            gobj.transform.Translate(units, 0, 0);
        }
    }
}
