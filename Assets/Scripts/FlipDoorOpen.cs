using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipDoorOpen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] activators;

    private bool active = false;
    private bool open = false;
    public int angle = 90;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Open();
    }

    public void Open()
    {
        foreach (GameObject activator in activators)
        {
            if (activator.GetComponent<PressurePlate>() != null)
                active = activator.GetComponent<PressurePlate>().isActive;
            else if (activator.GetComponent<SensorChangeMaterial>() != null)
                active = activator.GetComponent<SensorChangeMaterial>().active;
            else if (activator.GetComponent<PickUpFilament>() != null) active = activator.GetComponent<PickUpFilament>().active;

            if (active == false)
            {
                return;
            }
        }
        Debug.Log("FlipDoorOpen");
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, angle, 0), Time.deltaTime * 50);
    }
}
