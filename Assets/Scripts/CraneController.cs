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
