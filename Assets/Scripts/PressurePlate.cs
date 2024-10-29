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
    bool stayActivated;

    int items;

    private void OnTriggerEnter(Collider other)
    {
        if (ShouldIncrement(other))
        {
            items++;
            Sensor.GetComponent<SensorChangeMaterial>().active = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!stayActivated && ShouldIncrement(other))
        {
            items--;
            if (items == 0)
            {
                Sensor.GetComponent<SensorChangeMaterial>().active = false;
            }
        }
    }

    private bool ShouldIncrement(Collider other)
    {
        if (allowAllGameObjects) return true;
        if (allowPlayers && other.CompareTag("Player")) return true;
        if (other.TryGetComponent<CustomTags>(out var customTags))
        {
            if (allowAllFilaments && customTags.HasTag("Filament")) return true;
            if (allowHeavyFilament && customTags.HasTag("Heavy")) return true;
        }

        return false;
    }
}
