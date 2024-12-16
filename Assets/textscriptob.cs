using System.Collections;
using TMPro;
using UnityEngine;

public class textscriptob : MonoBehaviour
{


    // Start is called before the first frame update

    public void Textrobotstart(string Textrobot)
    {
        StartCoroutine(Textspeller(Textrobot));
    }

    IEnumerator Textspeller(string Textrobot)
    {
        gameObject.GetComponent<TextMeshPro>().text = "";
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < Textrobot.Length; i++)
        {
            gameObject.GetComponent<TextMeshPro>().text += Textrobot[i];

            string text = "Play_" +  char.ToUpper(Textrobot[i]);
            if (text != "Play_ ") AkSoundEngine.PostEvent(text, gameObject);
            yield return new WaitForSeconds(0.08f);
        }



    }
}
