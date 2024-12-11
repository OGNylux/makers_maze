using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FakeScript : MonoBehaviour
{

    public UnityEvent onButtonPress;
    public UnityEvent Printing;
    public UnityEvent finishupprinting;
    public MeshRenderer Object;


    public void loud()
    {



        onButtonPress.Invoke();

        StartCoroutine(ExampleCoroutine());


    }



    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(10);
        Printing.Invoke();
        yield return new WaitForSeconds(1);
        Object.enabled = true;
        yield return new WaitForSeconds(10);

        finishupprinting.Invoke();
    }
}
