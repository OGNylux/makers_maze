using UnityEngine;
using UnityEngine.Events;

public class CardReaderScript : MonoBehaviour
{
    public GameObject studentCardCollider;
    public GameObject cardReaderLight;

    public Color activeColor;
    public UnityEvent onCardAccepted;





    void Start()
    {



    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == studentCardCollider)
        {
            studentCardCollider.GetComponent<textscript>().Textrobotstart();
            onCardAccepted.Invoke();


            cardReaderLight.GetComponent<MeshRenderer>().material.color = activeColor;

















        }
    }



}
