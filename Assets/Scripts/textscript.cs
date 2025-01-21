using System.Collections;
using TMPro;
using UnityEngine;

public class textscript : MonoBehaviour
{
    public TextMeshPro Textrobotobject;
    public string Textrobot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Textrobotstart()
    {
        StartCoroutine(Textspeller());
    }

    IEnumerator Textspeller()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < Textrobot.Length; i++)
        {
            Textrobotobject.text += Textrobot[i];
            string text = "Play_" + char.ToUpper(Textrobot[i]);
            yield return new WaitForSeconds(0.05f);
        }



    }
}
