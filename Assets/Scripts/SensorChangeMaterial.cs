using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorChangeMaterial : MonoBehaviour
{
    // Start is called before the first frame update
    public bool active;
    public Material oldmaterial;
    public Material newmaterial;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ToggleMaterial();
    }

    void ToggleMaterial()
    {
        if (active)
        {
            GetComponent<Renderer>().material = newmaterial;
        }
        else 
        { 
            GetComponent<Renderer>().material = oldmaterial;
        }
    }
}
