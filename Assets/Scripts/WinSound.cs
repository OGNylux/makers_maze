using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSound : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] activators;
    private bool playSound = false;
    private AudioSource audioSource;

    private bool active = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject activator in activators)
        {

            if (activator.GetComponent<SensorChangeMaterial>() != null)
                active = activator.GetComponent<SensorChangeMaterial>().active;
            else if (activator.GetComponent<ObjectSnapper>() != null)
                active = activator.GetComponent<SensorChangeMaterial>().active;
            else if (activator.GetComponent<PickUpFilament>() != null)
                active = activator.GetComponent<PickUpFilament>().active;
            else if (activator.GetComponent<ScaleController>() != null)
                active = activator.GetComponent<ScaleController>().active;
            else if (activator.GetComponent<PressurePlate>() != null)
                active = activator.GetComponent<PressurePlate>().isActive;
            if (active == false)
            {
                return;
            }
        }
        PlaySound();
    }

    private void PlaySound()
    {
        if (!playSound)
        {
            audioSource.Play();
            playSound = true;
        }
    }
}
