using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class step : MonoBehaviour
{
    // Start is called before the first frame update
    private String[] steps = { "01:44", "01:19", "00:54", "00:28", "00:00" };
    private String[] percents = { "20%", "40%", "60%", "80%", "100%" };
    public TextMeshPro steper;
    public TextMeshPro percent;
    public TextMeshPro height;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void StartStep()
    {
        StartCoroutine(Step());
    }

    IEnumerator Step()
    {
        yield return new WaitForSeconds(5);
        for (int i = 0; i < steps.Length; i++)
        {

            steper.text = steps[i];
            percent.text = percents[i];
            height.text = percents[i];
            yield return new WaitForSeconds(4.4f);


        }
    }
}
