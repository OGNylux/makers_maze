using UnityEngine;


public class detachusb : MonoBehaviour
{
    public GameObject USBStick;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void detach()
    {
        transform.parent = null;
        USBStick.AddComponent<Rigidbody>();
        USBStick.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

    }
}
