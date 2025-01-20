using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstScale;
    public GameObject secondScale;
    public bool active = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (firstScale.GetComponent<ScaleScript>().weight == secondScale.GetComponent<ScaleScript>().weight)
        {
            active = true;
        }
        else
        {
            active = false;
        }
    }
}
