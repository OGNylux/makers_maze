using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintLogic : MonoBehaviour
{
    public int printID = 0;
    public GameObject[] prints;
    public int debug = 0;

    public void setPrintID(int printID)
    {
        this.printID = printID;
    }

    public void ScaleX(float scaleX)
    {
        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
    }

    public void ScaleY(float scaleY)
    {
        transform.localScale = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);
    }

    public void ScaleZ(float scaleZ) 
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, scaleZ);
    }

    // Print Objects with a delay
    public void createObjectWithDelay(float delay)
    {
        StartCoroutine(DelayedCreateObject(delay));
    }

    private IEnumerator DelayedCreateObject(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for delay
        GameObject newPrintObject = Instantiate(prints[printID]); // Create new object
        newPrintObject.transform.localScale = transform.localScale; // Set scale
        newPrintObject.transform.position = new Vector3(newPrintObject.transform.position.x, 0.92f, newPrintObject.transform.position.z); // Set position
    }

    public void allObjectsInactive()
    {
        GetComponentsInChildren<GameObject>(false);
    }

    public void specificObjectActive(int index)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        transform.GetChild(index).gameObject.GetComponent<MeshRenderer>().enabled = true;
        Console.WriteLine("test");

    }
}
