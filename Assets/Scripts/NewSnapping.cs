using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ObjectSnapper : MonoBehaviour
{
    public Transform snapPosition; // Die Position, an die das Objekt snappen soll
    public GameObject redQuad; // Rotes leuchtendes Quad
    public GameObject greenQuad; // Grünes leuchtendes Quad
    Vector3 minSize = new Vector3(0.111f, 0.111f, 0.111f);// Minimale Größe für die Platzierung                      
    Vector3 maxSize = new Vector3(0.297f, 0.297f, 0.297f);// Maximale Größe für die Platzierung
    public XRSocketInteractor socket;
    public GameObject spool;

    public bool active = false;

    private void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    public void CheckSize()
    {
        // Hol das älteste platzierte Objekt aus dem Socket
        GameObject interactable = socket.GetOldestInteractableSelected().transform.Find("Model").transform.gameObject;
        if (interactable == null)
        {
            return;
        }

        // Hole das GameObject des Interactables
        GameObject obj = interactable;

        // Prüfe die lokale Skalierung
        Vector3 objSize = obj.transform.localScale;

        // Überprüfe, ob die Größe im erlaubten Bereich liegt
        if (objSize.x > maxSize.x || objSize.y > maxSize.y || objSize.z > maxSize.z)
        {
            StartCoroutine(ResetSocket());
        }
        else if (objSize.x >= minSize.x && objSize.y >= minSize.y && objSize.z >= minSize.z)
        {
            //SnapObject(obj); // Falls korrekt, snappe das Objekt
            active = true;
            spool.SetActive(true);
            redQuad.SetActive(false);
            greenQuad.SetActive(true);
            obj.GetComponent<BoxCollider>().enabled = false;

        }
        else
        {
            StartCoroutine(ResetSocket());
        }
    }

    // Coroutine zum Zurücksetzen des Sockets
    private IEnumerator ResetSocket()
    {
        socket.enabled = false; // Socket deaktivieren
        yield return new WaitForSeconds(0.1f); // Kurze Pause
        socket.enabled = true; // Socket wieder aktivieren
    }


}
