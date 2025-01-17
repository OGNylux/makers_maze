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

    public bool active = false;
    public GameObject FilamentManager;
    public GameObject printer;
    public RectTransform infoPanel;

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

    public void setActive(bool active)
    {
        this.active = active;
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

    public void checkFilament()
    {
        Debug.Log("Filament ID: " + filamentID);
        Debug.Log(FilamentManager.gameObject.GetComponent<FilamentManager>().hasTag("Normal"));
        if (((filamentID == 0 || filamentID == 1) && FilamentManager.gameObject.GetComponent<FilamentManager>().hasTag("Normal")) ||
                (filamentID == 2 && FilamentManager.gameObject.GetComponent<FilamentManager>().hasTag("Reflective")))
        {
            printButton.interactable = true;
            infoPanel.gameObject.SetActive(false);
        }
        else
        {
            printButton.interactable = false;
            infoPanel.gameObject.SetActive(true);
            infoPanel.GetComponent<AudioSource>().Play();
        }
    }

    private IEnumerator DelayedCreateObject(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for delay
        GameObject newPrintObject = Instantiate(prints[(filamentID * shapesNum) + printID], new Vector3(-2.40700006f, 1.26400006f, -41.2000732f), Quaternion.identity); // Create new object

        GameObject child = newPrintObject.transform.Find("Model").transform.gameObject;

        child.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        child.transform.gameObject.GetComponent<ScaleOnPickup>().SetXScale(transform.localScale.x); // Set scale
        child.transform.gameObject.GetComponent<ScaleOnPickup>().SetYScale(transform.localScale.y); // Set scale
        child.transform.gameObject.GetComponent<ScaleOnPickup>().SetZScale(transform.localScale.z); // Set scale
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

    public void resetScale()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
