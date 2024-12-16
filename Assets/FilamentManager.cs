using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FilamentManager : MonoBehaviour
{
    public GameObject[] Filaments;

    public GameObject currentLockedObject = null;

    public void lockObjectOnSnapping()
    {
        foreach (GameObject filament in Filaments)
        {
            if (filament.transform.GetComponent<XRGrabInteractable>().singleGrabTransformersCount > 1)
            {
                filament.GetComponent<BoxCollider>().enabled = false;
                currentLockedObject = filament;
            }
        }
    }

    public void unlockObjectOnSnapping()
    {
        if (currentLockedObject)
        {
            currentLockedObject.GetComponent<BoxCollider>().enabled = true;
            currentLockedObject = null;
        }
    }



}
