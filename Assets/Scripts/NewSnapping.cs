using UnityEngine;

public class ObjectSnapper : MonoBehaviour
{
    public Transform snapPosition; // Die Position, an die das Objekt snappen soll
    public GameObject redQuad; // Rotes leuchtendes Quad
    public GameObject greenQuad; // Grünes leuchtendes Quad
    public Vector3 minSize; // Minimale Größe für die Platzierung
    public Vector3 maxSize; // Maximale Größe für die Platzierung

    private void OnTriggerEnter(Collider other)
    {
        // Prüfen, ob das Objekt das richtige Tag hat (z.B. "Placeable")
        if (other.CompareTag("Placeable"))
        {
            GameObject obj = other.gameObject;

            // Größe überprüfen
            Vector3 objSize = obj.GetComponent<Renderer>().bounds.size;
            if (objSize.x > maxSize.x || objSize.y > maxSize.y || objSize.z > maxSize.z)
            {
                Debug.Log("Objekt ist zu groß.");
                return;
            }
            if (objSize.x < minSize.x || objSize.y < minSize.y || objSize.z < minSize.z)
            {
                Debug.Log("Objekt ist zu klein.");
                return;
            }

            // Snappen
            obj.transform.position = snapPosition.position;
            obj.transform.rotation = snapPosition.rotation;

            // Farbe ändern
            redQuad.SetActive(false);
            greenQuad.SetActive(true);

            Debug.Log("Objekt korrekt platziert!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Wenn das Objekt entfernt wird, zurücksetzen
        if (other.CompareTag("Placeable"))
        {
            redQuad.SetActive(true);
            greenQuad.SetActive(false);
            Debug.Log("Objekt entfernt.");
        }
    }
}
