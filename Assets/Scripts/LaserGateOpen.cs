using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGateOpen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] activators;

    private bool active = false;
    public bool stayActive = false;
    void Start()
    {
        
    }

    private void Update()
    {
        ChangeColor();
    }
    // Update is called once per frame
    public void ChangeColor()
    {
        foreach (GameObject activator in activators)
        {
            if (activator.GetComponent<PressurePlate>() != null) active = activator.GetComponent<PressurePlate>().isActive;
            else if (activator.GetComponent<SensorChangeMaterial>() != null) active = activator.GetComponent<SensorChangeMaterial>().active;
            else if (activator.GetComponent<ScaleController>() != null) active = activator.GetComponent<ScaleController>().active;
            if (active == false)
            {
                if (!stayActive) transform.gameObject.SetActive(true);
                return;
            }
        }
        Debug.Log("LaserGateOpen");
        transform.gameObject.SetActive(false);
    }
}
