using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject[] activators;

    private void Update()
    {
        Open();
    }

    public void Open()
    {
        foreach (GameObject activator in activators)
        {
            if (activator.GetComponent<PressurePlate>().isActive == false)
            {
                return;
            }
        }

        transform.position += new Vector3(0, 5, 0);
    }

}
