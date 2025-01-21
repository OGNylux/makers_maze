using UnityEngine;
using UnityEngine.Events;

public class CardReaderScript : MonoBehaviour
{
    public GameObject cardReaderLight;

    public Color activeColor;
    public bool active = false;

    void Start()
    {



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("card"))
        {
            active = true;
            cardReaderLight.GetComponent<MeshRenderer>().material.color = activeColor;
        }
    }
}
