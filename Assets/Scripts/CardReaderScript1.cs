using UnityEngine;
using UnityEngine.Events;

public class CardReaderScript1 : MonoBehaviour
{
    public GameObject studentCardCollider;

    public GameObject usb;

    public UnityEvent onCardAccepted;





    void Start()
    {



    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == studentCardCollider && usb.GetComponent<snapzonescriptall>().isUSBInserted == true)
        {

            onCardAccepted.Invoke();







        }
    }



}
