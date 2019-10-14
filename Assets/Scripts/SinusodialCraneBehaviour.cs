﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CraneController))]
public class SinusodialCraneBehaviour : MonoBehaviour
{
    public float RotateSpeed = 1.0f;
    public float RotateRate = 1.0f;
    public float InvertSpeed = 1.0f;
    public float InvertPhase = 0;


    private CraneController craneController;

    private float elapsed;

    void Start()
    {
        this.craneController = this.GetComponent<CraneController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.elapsed += Time.deltaTime;

        this.craneController.RotateBy(this.RotateSpeed * Mathf.Sin(this.RotateRate * this.elapsed));
        this.craneController.TranslateBy(this.InvertSpeed * Mathf.Sin(this.elapsed + this.InvertPhase));
    }
}
