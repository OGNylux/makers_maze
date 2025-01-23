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
    public RectTransform infoPanel2;
    public bool canHeavyPrint = false;
    public bool canMirrorPrint = false;
    public int printerID = 0;

    private Vector3 pos0 = new Vector3(40.5169983f, 40.8129997f, -23.4892082f);
    private Vector3 pos1 = new Vector3(39.8785629f, 40.8110008f, -12.7832661f);
    private Vector3 pos2 = new Vector3(47.2845917f, 40.8160019f, -33.3429985f);
    private Vector3 pos3 = new Vector3(66.1060028f, 35.7799988f, -5.10437822f);

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
    public void setCanHeavyPrint(bool canHeavyPrint)
    {
        this.canHeavyPrint = canHeavyPrint;
    }
    public void setCanMirrorPrint(bool canMirrorPrint)
    {
        this.canMirrorPrint = canMirrorPrint;
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
        if ((filamentID == 1 && !canHeavyPrint) || (filamentID == 2 && !canMirrorPrint)) return;
        if (!FilamentManager.gameObject.GetComponent<FilamentManager>().hasObject())
        {
            printButton.interactable = false;
            infoPanel.gameObject.SetActive(true);
            infoPanel.GetComponent<AudioSource>().Play();
            return;
        }

        if (((filamentID == 0 || filamentID == 1) && FilamentManager.gameObject.GetComponent<FilamentManager>().hasTag("Normal")) ||
                (filamentID == 2 && FilamentManager.gameObject.GetComponent<FilamentManager>().hasTag("Reflective")))
        {
            printButton.interactable = true;
            infoPanel.gameObject.SetActive(false);
        }
        else
        {
            printButton.interactable = false;
            infoPanel2.gameObject.SetActive(false);
            infoPanel.gameObject.SetActive(true);
            infoPanel.GetComponent<AudioSource>().Play();
        }
    }

    public void checkPrintability()
    {
        if (!FilamentManager.gameObject.GetComponent<FilamentManager>().hasObject())
        {
            return;
        }

        if ((filamentID == 1 && canHeavyPrint) || (filamentID == 2 && canMirrorPrint) || filamentID == 0)
        {
            printButton.interactable = true;
            infoPanel2.gameObject.SetActive(false);
        }
        else
        {
            printButton.interactable = false;
            infoPanel.gameObject.SetActive(false);
            infoPanel2.gameObject.SetActive(true);
            infoPanel2.GetComponent<AudioSource>().Play();
        }
    }

    private IEnumerator DelayedCreateObject(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for delay
        Vector3 location = new Vector3(0, 0, 0); // Set location
        if (printerID == 0) location = pos0;
        else if (printerID == 1) location = pos1;
        else if (printerID == 2) location = pos2;
        else if (printerID == 3) location = pos3;
        GameObject newPrintObject = Instantiate(prints[(filamentID * shapesNum) + printID], location, Quaternion.identity); // Create new object

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
