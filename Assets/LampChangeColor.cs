using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] activators;

    public Material oldMaterial;
    public Material newMaterial;

    private bool active = false;
    public bool stayActive = false;

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
            if (activator.GetComponent<PressurePlate>() != null) active = activator.GetComponent<PressurePlate>().isActive;
            else if (activator.GetComponent<SensorChangeMaterial>() != null) active = activator.GetComponent<SensorChangeMaterial>().active;
            if (active == false)
            {
                if (!stayActive) transform.GetComponent<Renderer>().material = oldMaterial;
                return;
            }
        }

        transform.GetComponent<Renderer>().material = newMaterial;
    }
}
