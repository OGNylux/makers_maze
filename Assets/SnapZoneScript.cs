using UnityEngine;


public class SnapZoneScript : MonoBehaviour
{

    public GameObject USBStick;
    public GameObject Destination;
    public VideoPlayController vpc;
    private bool isUSBInserted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == USBStick && isUSBInserted == false)
        {
            Destroy(USBStick.gameObject.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>());
            Destroy(USBStick.GetComponent<Rigidbody>());
            Debug.Log("USB inserted");
            vpc.USBInserted();




            USBStick.transform.parent = Destination.transform;
            USBStick.transform.localPosition = Vector3.zero;
            USBStick.transform.localRotation = new Quaternion(0, 0, 0, 0);
            USBStick.transform.localScale = Vector3.one;
            isUSBInserted = true;
        }
    }


}
