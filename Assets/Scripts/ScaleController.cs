using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleController : MonoBehaviour
{
    public GameObject firstScale;
    public GameObject secondScale;
    public bool active = false;
    public bool stayActive = false;
    private const float weightTolerance = 1.5f;

    void Start()
    {

    }

    void Update()
    {
        float firstWeight = firstScale.GetComponent<ScaleScript>().weight;
        float secondWeight = secondScale.GetComponent<ScaleScript>().weight;
        if (Mathf.Abs(firstWeight - secondWeight) <= weightTolerance)
        {
            active = true;
        }
        else
        {
            if (!stayActive) active = false;
        }
    }
}