using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightingController : MonoBehaviour
{
    private Light lightComponent;

    public float Intensity = 1;

    // Start is called before the first frame update
    void Start()
    {
        this.lightComponent = this.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (this.Intensity == 0) {
        //     this.lightComponent.color = 
        // } else {
            this.lightComponent.intensity = this.Intensity;
        // }
    }
}
