using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongWaypoints : MonoBehaviour
{
    public List<GameObject> Waypoints;
    public float speed = 2;
    int index = 0;

    public void Start()
    {
        transform.position = Waypoints[index].transform.position;
    }

    void Update()
    {
        move();
    }

    private void move() 
    {
        if (index == Waypoints.Count) return;
        Vector3 destintion = Waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, Waypoints[index].transform.position, speed * Time.deltaTime);
        transform.position = newPos;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 144.676f, 0), Time.deltaTime * 50);
        if (transform.position == Waypoints[index].transform.position)
        {
            index += 1;
        }
    }
}
