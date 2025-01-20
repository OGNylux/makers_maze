using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScript : MonoBehaviour
{
    [Range(0.0f, 20.0f)]
    public int weight = 10;
    public float multiplier = 0.1f;

    float startHeight = 0.0f;

    public int currentWeight;

    public GameObject otherScale;


    // Start is called before the first frame update
    void Start()
    {
        startHeight = transform.localPosition.y- weight * multiplier;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(transform.localPosition.x, startHeight + weight * multiplier, transform.localPosition.z);
        Debug.Log("oboi"+ targetPos.y);
        if (targetPos.y < -0.5f) targetPos.y = -0.5f;
        if (targetPos.y > 0.5f) targetPos.y = 0.5f;
        Debug.Log("wsv"+targetPos.y);
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime * 5);
        Debug.Log(weight);

    }

    private void OnTriggerEnter(Collider other)
    {
        weight -= calculateWeight(other);
        otherScale.GetComponent<ScaleScript>().weight += calculateWeight(other);
        if (other.transform.parent == null) other.transform.parent = transform;
        else other.transform.parent.transform.parent = transform;
    }

        private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent == transform) other.transform.parent = null;
        else other.transform.parent.gameObject.transform.parent = null;
        weight += calculateWeight(other);
        otherScale.GetComponent<ScaleScript>().weight -= calculateWeight(other);

    }

    private void OnCollisionStay(Collision collision)
    {
        
    }

    private int calculateWeight(Collider other)
    {
        float weightOfScale = other.transform.localScale.x * other.transform.localScale.y * other.transform.localScale.z;
        if (other.GetComponent<Rigidbody>() != null)
        {
            weightOfScale = weightOfScale * other.GetComponent<Rigidbody>().mass;
        } 
        else
        {
            GameObject parent = other.transform.parent.gameObject;
            weightOfScale = weightOfScale * parent.GetComponent<Rigidbody>().mass;

        }
        return Mathf.RoundToInt(weightOfScale);
    }


}
