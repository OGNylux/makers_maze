using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongWaypoints : MonoBehaviour
{

    public void Start()
    {

    }


    public void teleport()
    {
        transform.position = new Vector3(51.0299988f, 40.2700005f, -19.5799999f);
        transform.rotation = Quaternion.Euler(0, 134.4f, 0);
    }
}
