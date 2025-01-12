using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSound : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] activators;
    private bool playSound = false;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject activator in activators)
        {
            if (activator.GetComponent<SensorChangeMaterial>().active == false)
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
