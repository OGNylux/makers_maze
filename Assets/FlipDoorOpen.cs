using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipDoorOpen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] activators;

    private bool active = false;
    private bool open = false;

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

            if (active == false)
            {
                return;
            }
        }
        if (transform.rotation.eulerAngles.y < 5) return;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,90,0), Time.deltaTime / 4);
    }
}
