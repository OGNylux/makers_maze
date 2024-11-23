using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintLogic : MonoBehaviour
{
    public int printID = 0;
    public GameObject[] prints;
    public bool test = false;

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
        GetComponentsInChildren<GameObject>(false);
        transform.GetChild(index).gameObject.SetActive(true);
        test = true;
        Console.WriteLine("test");

    }

    public void testfunc()
    {
        test = true;
        Console.WriteLine("test");
    }
}
