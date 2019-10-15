using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    public GameObject[] Rotating;
    public Transform PivotPoint;
    public Vector3 PivotOffset;
    public GameObject[] Translating;

    private float planarAngle;

    public Vector3 RotationPointWorld
    {
        get
        {
            return this.PivotPoint.position + this.PivotPoint.TransformDirection(this.PivotOffset);
        }
    }

    public Vector3 RaiseAxis
    {
        get
        {
            return Quaternion.AngleAxis(this.planarAngle, Vector3.up) * Vector3.forward;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(this.RotationPointWorld, Vector3.up * 10);

        Vector3 vec = this.RaiseAxis;
        Gizmos.DrawRay(this.RotationPointWorld, vec * 2.5f);
        Gizmos.DrawRay(this.RotationPointWorld, vec * -2.5f);
    }

    public void RaiseBy(float angle)
    {
        foreach (GameObject gobj in this.Rotating)
        {
            gobj.transform.RotateAround(this.RotationPointWorld, this.RaiseAxis, angle);
        }
    }

    public void RotateBy(float angle)
    {
        this.planarAngle += angle;

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
