using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    Vector3 spawnPosition;
    Quaternion spawnRotation;

    public float rotationSpeed;

    public float timerInSeconds;

    public bool isRotating = true;

    private void Start()
    {
        spawnPosition = transform.position;
        spawnRotation = transform.rotation;
    }

    private void Update()
    {
        if (isRotating) transform.Rotate(rotationSpeed, 0, rotationSpeed, Space.Self);
    }


    public void RespawnToStartPosition()
    {
        StartCoroutine(RespawnTheObject());
    }

    public IEnumerator RespawnTheObject()
    {
        isRotating = false;
        yield return new WaitForSeconds(timerInSeconds);
        transform.position = spawnPosition;
        transform.rotation = spawnRotation;
        GetComponent<Rigidbody>().isKinematic = true;
        isRotating = true;
    }
}
