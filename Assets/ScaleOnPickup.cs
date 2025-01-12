using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnPickup : MonoBehaviour
{
    public Vector3 scale = new Vector3(0.5f, 0.5f, 0.5f);
    public void Scale()
    {
        Debug.Log(transform.gameObject.name);
        transform.localScale = scale;
    }

    public void SetXScale(float x)
    {
        scale.x = x;
    }

    public void SetYScale(float y)
    {
        scale.y = y;
    }

    public void SetZScale(float z)
    {
        scale.z = z;
    }

}
