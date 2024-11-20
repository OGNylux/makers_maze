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
        transform.localScale = new Vector3(scaleX,scaleX, scaleX);
    }

    //Print Objects
    public void createObject()
    {
        GameObject newPrintObject = Instantiate(prints[printID]);
        newPrintObject.transform.localScale = transform.localScale;
    }

    public void allObjectsInactive()
    {
        GetComponentsInChildren<GameObject>(false);
    }
}
