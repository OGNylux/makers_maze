using UnityEngine;
using UnityEngine.Events;

public class CardReaderScript : MonoBehaviour
{
    public GameObject cardReaderLight;
    public GameObject door;
    public GameObject robot;

    public Color activeColor;
    public bool active = false;
    private bool robotMoved = false;

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

    private void Update()
    {
        if (active) 
        { 
            door.transform.rotation = Quaternion.RotateTowards(door.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 50);
        }
    }
}
