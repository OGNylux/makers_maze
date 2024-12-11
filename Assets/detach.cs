using UnityEngine;


public class detach : MonoBehaviour
{
    public GameObject spatula;
    public GameObject arm;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == spatula.name)
        {
            Debug.Log("Detached");
            arm.transform.parent = null;
            arm.AddComponent<Rigidbody>();
            arm.GetComponent<Rigidbody>().useGravity = true;
            arm.GetComponent<Rigidbody>().isKinematic = false;
            arm.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        }
    }
}
