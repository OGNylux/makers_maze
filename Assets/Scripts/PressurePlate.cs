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

    public bool isActive = false;
    int items;

    private void OnTriggerEnter(Collider other)
    {
        if (ShouldIncrement(other))
        {
            items++;
            isActive = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (!stayActivated && ShouldIncrement(other))
        {
            items--;
            if (items == 0)
            {
                isActive = false;
            }
        }
    }

    private bool ShouldIncrement(Collider other)
    {
        if (allowAllGameObjects) return true;
        if (allowPlayers && other.CompareTag("Player")) return true;
        if (other.transform.parent.TryGetComponent<CustomTags>(out var customTags))
        {
            Debug.Log(other.name);

            if (allowAllFilaments && customTags.HasTag("Filament")) return true;
            if (allowHeavyFilament && customTags.HasTag("Heavy")) return true;
        }

        return false;
    }
}
