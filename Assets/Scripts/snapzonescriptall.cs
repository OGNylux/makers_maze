using UnityEngine;


public class snapzonescriptall : MonoBehaviour
{
    public GameObject USBStick;
    public GameObject Destination;

    public bool isUSBInserted = false;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == USBStick && isUSBInserted == false)
        {
            Debug.Log("USB inserted");

            Destroy(USBStick.gameObject.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>());
            Destroy(USBStick.GetComponent<Rigidbody>());


            USBStick.transform.parent = Destination.transform;
            USBStick.transform.localPosition = Vector3.zero;
            USBStick.transform.localRotation = new Quaternion(0, 0, 0, 0);
            USBStick.transform.localScale = Vector3.one;
            isUSBInserted = true;
        }
    }


}
