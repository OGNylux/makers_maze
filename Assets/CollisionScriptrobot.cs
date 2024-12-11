using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CollisionScript : MonoBehaviour
{


    public GameObject Robot;
    public GameObject Arm;
    private bool hasExecuted = false;
    public GameObject ReplacmentArm;
    private bool hasExecuted2 = false;
    public bool hasExecuted3 = false;
    public TextMeshPro Textrobotobject;
    public string[] Textrobot;
    public string[] Textrobot2;
    public UnityEvent finish;

    private void OnTriggerEnter(Collider collision)
    {
        if (Arm.activeSelf == true && hasExecuted2 == false)
        {



            if (collision.gameObject.name == "XR Origin")
            {
                Textrobotobject.text = "";

                Robot.GetComponent<Animator>().SetTrigger("Close");
                Arm.SetActive(false);
                Robot.GetComponent<Animator>().SetBool("Default", true);
                StartCoroutine(Textspeller());


            }
        }
        if (Arm.activeSelf == false && hasExecuted == true && hasExecuted2 == false)
        {

            if (collision.gameObject.name == ReplacmentArm.name)
            {

                Arm.SetActive(true);
                ReplacmentArm.SetActive(false);
                Robot.GetComponent<Animator>().SetTrigger("Happy");
                hasExecuted2 = true;
                finish.Invoke();

            }
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (Arm.activeSelf == false && hasExecuted == false && hasExecuted3 == true)
        {


            if (collision.gameObject.name == "XR Origin")
            {
                //turn slowly the robot 90 degrees and walk forward
                Robot.transform.Rotate(0f, 90f, 0f, Space.Self);
                //move the robot forward
                Robot.transform.Translate(Vector3.forward * 5f, Space.Self);

                hasExecuted = true;
                StartCoroutine(Textspel());


            }
        }
    }

    IEnumerator Textspeller()
    {
        yield return new WaitForSeconds(4f);
        for (int i = 0; i < Textrobot.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            for (int t = 0; t < Textrobot[i].Length; t++)
            {
                Textrobotobject.text += Textrobot[i][t];
                string text = "Play_" + char.ToUpper(Textrobot[i][t]);
                if (text != "Play_ ") AkSoundEngine.PostEvent(text, gameObject);
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(2.5f);
            Textrobotobject.text = "";
        }
        hasExecuted3 = true;


    }


    IEnumerator Textspel()
    {
        yield return new WaitForSeconds(0.6f);
        for (int i = 0; i < Textrobot2.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            for (int t = 0; t < Textrobot2[i].Length; t++)
            {
                Textrobotobject.text += Textrobot2[i][t];
                string text = "Play_" + char.ToUpper(Textrobot[i][t]);
                if (text != "Play_ ") AkSoundEngine.PostEvent(text, gameObject);
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(2.5f);
            Textrobotobject.text = "";
        }




    }
}
