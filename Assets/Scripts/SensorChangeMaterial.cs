using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorChangeMaterial : MonoBehaviour
{
    // Start is called before the first frame update
    public bool active;
    public Material oldmaterial;
    public Material newmaterial;

    // Update is called once per frame
    void Update()
    {
        ToggleMaterial();
    }

    void ToggleMaterial()
    {
        Transform child = transform.Find("Indicators");
        if (active)
        {
            child.GetComponent<Renderer>().material = newmaterial;
        }
        else
        {
            child.GetComponent<Renderer>().material = oldmaterial;
        }
    }
}
