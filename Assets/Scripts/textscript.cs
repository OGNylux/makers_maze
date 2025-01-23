using System.Collections;
using TMPro;
using UnityEngine;

public class textscript : MonoBehaviour
{
    public string Textrobot;
    public TMP_Text TextMesh;
    // Start is called before the first frame update
    void Start()
    {
        TextMesh = GetComponent<TextMeshProUGUI>();
        Textrobotstart();
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
            TextMesh.text += Textrobot[i];
            string text = "Play_" + char.ToUpper(Textrobot[i]);
            yield return new WaitForSeconds(0.075f);
        }



    }
}
