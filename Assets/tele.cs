using UnityEngine;

public class tele : MonoBehaviour
{
    public GameObject card;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void teleport()
    {
        card.transform.position = new Vector3(8, 0, 0);
    }
}
