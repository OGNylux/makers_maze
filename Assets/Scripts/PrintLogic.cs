using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintLogic : MonoBehaviour
{
    public int printID = 0;
    public int filamentID = 0;
    public GameObject[] prints;
    private int shapesNum = 3;

    [SerializeField] 
    private Button printButton;

    public void setUIColorOn()
    {
        var color = new Color(0.0f, 0.5882353f, 0.5333334f, 1);
        transform.GetComponent<Image>().color = color;
    }
    public void setUIColorOff()
    {
        var color = new Color(0.227451f, 0.2666667f, 0.2745098f, 1);
        transform.GetComponent<Image>().color = color;
    }

    public void setPrintID(int printID)
    {
        this.printID = printID;
    }

    public void setFilamentID(int filamentID)
    {
        this.filamentID = filamentID;
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
        GameObject newPrintObject = Instantiate(prints[(filamentID * shapesNum) + printID]); // Create new object
        newPrintObject.transform.localScale = transform.localScale; // Set scale
        newPrintObject.transform.position = new Vector3(newPrintObject.transform.position.x, 0.92f, newPrintObject.transform.position.z); // Set position
        printButton.interactable = true; // Enable print button
    }

    public void specificObjectActive(int index)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        transform.GetChild(index).gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
