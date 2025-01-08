using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChangeColor : MonoBehaviour
{
    public RectTransform panel1;
    public RectTransform panel2;
    public RectTransform panel3;
    public RectTransform panel4;
    public RectTransform panel5;
    public RectTransform panel6;
    public RectTransform actionPanel;
    public RectTransform mainPanel;
    public RectTransform spoolPanel;
    public GameObject FilamentHolder;

    // change the color of the panel with a 0.25 second delay each
    public void ChangeColorUnload()
    {
        if (FilamentHolder.GetComponent<FilamentManager>().hasObject())
        {
            mainPanel.transform.gameObject.SetActive(false);
            transform.gameObject.SetActive(true);
            StartCoroutine(ChangeColorUnloadWithDelay());
        }
    }

    private IEnumerator ChangeColorUnloadWithDelay()
    {
        panel1.GetComponent<Image>().color = new Color(0.0f, 0.9686275f, 0.5333334f, 1);
        yield return new WaitForSeconds(0.5f);

        panel2.GetComponent<Image>().color = new Color(0.0f, 0.9686275f, 0.5333334f, 1);
        yield return new WaitForSeconds(0.5f);

        panel3.GetComponent<Image>().color = new Color(0.0f, 0.9686275f, 0.5333334f, 1);
        yield return new WaitForSeconds(0.5f);

        panel4.GetComponent<Image>().color = new Color(0.0f, 0.9686275f, 0.5333334f, 1);
        yield return new WaitForSeconds(0.5f);

        actionPanel.transform.gameObject.SetActive(true);

        FilamentHolder.GetComponent<FilamentManager>().unlockObjectOnSnapping();

        panel1.GetComponent<Image>().color = new Color(0.2470588f, 0.4f, 0.4470589f, 1);
        panel2.GetComponent<Image>().color = new Color(0.2470588f, 0.4f, 0.4470589f, 1);
        panel3.GetComponent<Image>().color = new Color(0.2470588f, 0.4f, 0.4470589f, 1);
        panel4.GetComponent<Image>().color = new Color(0.2470588f, 0.4f, 0.4470589f, 1);

    }

    public void ChangeColorLoad()
    {
        if (FilamentHolder.GetComponent<FilamentManager>().hasObject())
        {
            mainPanel.transform.gameObject.SetActive(false);
            transform.gameObject.SetActive(true);
            spoolPanel.transform.gameObject.SetActive(false);
            StartCoroutine(ChangeColorLoadWithDelay());
        }
        else
        {
            spoolPanel.transform.gameObject.SetActive(true);
        }
    }

    private IEnumerator ChangeColorLoadWithDelay()
    {
        panel1.GetComponent<Image>().color = new Color(0.0f, 0.9686275f, 0.5333334f, 1);
        yield return new WaitForSeconds(0.5f);

        panel2.GetComponent<Image>().color = new Color(0.0f, 0.9686275f, 0.5333334f, 1);
        yield return new WaitForSeconds(0.5f);

        panel3.GetComponent<Image>().color = new Color(0.0f, 0.9686275f, 0.5333334f, 1);
        yield return new WaitForSeconds(0.5f);

        panel4.GetComponent<Image>().color = new Color(0.0f, 0.9686275f, 0.5333334f, 1);
        yield return new WaitForSeconds(0.5f);

        panel5.GetComponent<Image>().color = new Color(0.0f, 0.9686275f, 0.5333334f, 1);
        yield return new WaitForSeconds(0.5f);

        panel6.GetComponent<Image>().color = new Color(0.0f, 0.9686275f, 0.5333334f, 1);
        yield return new WaitForSeconds(0.5f);

        actionPanel.transform.gameObject.SetActive(true);

        panel1.GetComponent<Image>().color = new Color(0.2470588f, 0.4f, 0.4470589f, 1);
        panel2.GetComponent<Image>().color = new Color(0.2470588f, 0.4f, 0.4470589f, 1);
        panel3.GetComponent<Image>().color = new Color(0.2470588f, 0.4f, 0.4470589f, 1);
        panel4.GetComponent<Image>().color = new Color(0.2470588f, 0.4f, 0.4470589f, 1);
        panel5.GetComponent<Image>().color = new Color(0.2470588f, 0.4f, 0.4470589f, 1);
        panel6.GetComponent<Image>().color = new Color(0.2470588f, 0.4f, 0.4470589f, 1);

    }

}
