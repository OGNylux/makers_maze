using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCanvasPC : MonoBehaviour
{
    

    public GameObject PCScreen;
    public GameObject LeftHand;
    public GameObject RightHand;



    void Start()
    {
        PCScreen.SetActive(false);
                
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject == LeftHand ||  collision.gameObject == RightHand)
        {
            Debug.Log("Collision2");
            PCScreen.SetActive(true);
            
        }
    }
    
}