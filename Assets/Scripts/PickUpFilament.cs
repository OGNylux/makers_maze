using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFilament : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] filaments;
    public bool unlockHeavy = false;
    public bool unlockMirror = false;
    public bool active = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            active = true;
            foreach (GameObject filament in filaments)
            {
                if (unlockHeavy) filament.GetComponent<PrintLogic>().setCanHeavyPrint(true);
                if (unlockMirror) filament.GetComponent<PrintLogic>().setCanMirrorPrint(true);
            }
            transform.position = new Vector3(0, -100, 0);
        }
    }
}
