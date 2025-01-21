using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class FilamentManager : MonoBehaviour
{
    public GameObject[] Filaments;

    public GameObject currentLockedObject = null;

    XRSocketInteractor socket;

    private void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
        lockObjectOnSnapping();
    }
    public void lockObjectOnSnapping()
    {
        IXRSelectInteractable obj = socket.GetOldestInteractableSelected();
        if (obj != null)
        {
            obj.transform.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void unlockObjectOnSnapping()
    {
        IXRSelectInteractable obj = socket.GetOldestInteractableSelected();
        if (obj.transform.gameObject != null)
        {
            obj.transform.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public bool hasTag(string tag)
    {
        IXRSelectInteractable obj = socket.GetOldestInteractableSelected();

        return obj.transform.gameObject.CompareTag(tag);
    }

    public bool hasObject()
    {
        return socket.hasSelection;
    }
}
