using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    // Start is called before the first frame update
    public UnityEvent OnCount;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void countersa()
    {
        StartCoroutine(Count());
    }
    IEnumerator Count()
    {


        for (int i = 0; i < 211; i++)
        {


            textMeshPro.text = i.ToString();
            yield return new WaitForSeconds((float)0.07);
        }
        OnCount.Invoke();
    }
}
