using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapping : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SnapGO()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y) - transform.localScale.y/2, Mathf.Round(transform.position.z));
        //RotationStuff here!!!
        //transform.eulerAngles = 
    }
}
