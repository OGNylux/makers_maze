using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    private int maxBounces = 10;
    private int count;
    private LineRenderer lineRenderer;
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private bool reflectOnlyMirror;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        count = 0;
        CastLaser(transform.position, transform.forward);
    }

    void CastLaser(Vector3 position, Vector3 direction)
    {
        lineRenderer.SetPosition(0, startPoint.position);

        for (int i = 0; i < maxBounces; i++)
        {
            Ray ray = new Ray(position, direction);
            RaycastHit hit;

            if (count < maxBounces-1)
            {
                count++;
            }

            if (Physics.Raycast(ray, out hit, 300))
            {
                position = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);
                lineRenderer.SetPosition(count, hit.point);

                if (hit.transform.tag != "Mirror" && reflectOnlyMirror) 
                { 
                    for (int j = (i+1); j <= maxBounces; j++) 
                    {
                        lineRenderer.SetPosition(j, hit.point);
                    }
                    break;
                }
                else
                {
                    lineRenderer.SetPosition(count, hit.point);
                }
            }
            else
            {
                lineRenderer.SetPosition(count, ray.GetPoint(300));
            }
        }
    }
}
