using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] activators;

    public Material oldMaterial;
    public Material newMaterial;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor();
    }

    public void ChangeColor()
    {
        foreach (GameObject activator in activators)
        {
            if (activator.GetComponent<SensorChangeMaterial>().active == false)
            {
                transform.GetComponent<Renderer>().material = oldMaterial;
                return;
            }
        }

        transform.GetComponent<Renderer>().material = newMaterial;
    }
}
