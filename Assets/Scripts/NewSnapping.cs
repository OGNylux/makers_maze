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

    private void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    public void CheckSize()
    {
        // Hol das älteste platzierte Objekt aus dem Socket
        IXRSelectInteractable interactable = socket.GetOldestInteractableSelected();
        if (interactable == null)
        {
            Debug.Log("Kein Objekt im Socket.");
            return;
        }

        // Hole das GameObject des Interactables
        GameObject obj = interactable.transform.gameObject;

        // Prüfe die lokale Skalierung
        Vector3 objSize = obj.transform.localScale;

        // Überprüfe, ob die Größe im erlaubten Bereich liegt
        if (objSize.x > maxSize.x || objSize.y > maxSize.y || objSize.z > maxSize.z)
        {
            // Objekt ist zu groß, Socket deaktivieren und neu aktivieren
            Debug.Log("Objektgröße ist zu groß. Socket wird zurückgesetzt.");
            StartCoroutine(ResetSocket());
        }
        else if (objSize.x >= minSize.x && objSize.y >= minSize.y && objSize.z >= minSize.z)
        {
            // Größe ist im erlaubten Bereich
            Debug.Log("Objektgröße ist korrekt.");
            //SnapObject(obj); // Falls korrekt, snappe das Objekt
            redQuad.SetActive(false);
            greenQuad.SetActive(true);
            obj.GetComponent<BoxCollider>().enabled = false;
            Debug.Log(obj.name);
        }
        else
        {
            // Objekt ist zu klein
            Debug.Log("Objektgröße ist zu klein. Socket wird zurückgesetzt.");
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
