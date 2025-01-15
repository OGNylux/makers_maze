using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorOpen : MonoBehaviour
{
    public GameObject[] activators;
    public int offset = 0;
    private Vector3 targetPos;
    private Vector3 savedPos;

    private void Start()
    {
        savedPos = transform.localPosition;
        targetPos = new Vector3(transform.localPosition.x, transform.localPosition.y + offset, transform.localPosition.z);
    }

    private void Update()
    {
        Open();
    }

    public void Open()
    {
        foreach (GameObject activator in activators)
        {
            if (activator.GetComponent<SensorChangeMaterial>().active == false)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, savedPos, Time.deltaTime * 2);
                return;
            }
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime * 2);
    }

}
