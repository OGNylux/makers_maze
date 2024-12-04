using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScript : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public int weight = 5;
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
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime * 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        weight -= calculateWeight(other);
        otherScale.GetComponent<ScaleScript>().weight += calculateWeight(other);
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
        weight += calculateWeight(other);
        otherScale.GetComponent<ScaleScript>().weight -= calculateWeight(other);

    }

    private void OnCollisionStay(Collision collision)
    {
        
    }

    private int calculateWeight(Collider other)
    {
        float weightOfScale = other.transform.localScale.x * other.transform.localScale.y * other.transform.localScale.z;
        weightOfScale = weightOfScale * other.GetComponent<Rigidbody>().mass;
        return Mathf.RoundToInt(weightOfScale);
    }


}
