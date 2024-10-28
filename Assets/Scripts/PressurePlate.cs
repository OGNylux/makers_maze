using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject Sensor;
    [SerializeField]
    bool allowPlayers = true;
    [SerializeField]
    bool allowHeavyFilament;
    [SerializeField]
    bool allowAllFilaments;
    [SerializeField]
    bool allowAllGameObjects;
    [SerializeField]
    bool isOpen;

    private void OnTriggerEnter(Collider other)
    {
        Sensor.GetComponent<SensorChangeMaterial>().active = true;
        isOpen = true;
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
