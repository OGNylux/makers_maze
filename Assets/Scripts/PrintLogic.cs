using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintLogic : MonoBehaviour
{
    public int printID = 0;
    public GameObject[] prints;

    public void setPrintID(int printID)
    {
        this.printID = printID;
    }

    public void Scale(float scaleX)
    {
        transform.localScale = new Vector3(scaleX, scaleX, scaleX);
    }

    // Print Objects with a delay
    public void createObjectWithDelay(float delay)
    {
        StartCoroutine(DelayedCreateObject(delay));
    }

    private IEnumerator DelayedCreateObject(float delay)
    {
        yield return new WaitForSeconds(delay); // Warte für die angegebene Zeit
        GameObject newPrintObject = Instantiate(prints[printID]); // Objekt erstellen
        newPrintObject.transform.localScale = transform.localScale; // Skalierung übernehmen
    }

    public void allObjectsInactive()
    {
        GetComponentsInChildren<GameObject>(false);
    }
}
