using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    private readonly int maxBounces = 10;
    private int count;
    private LineRenderer lineRenderer;
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private bool reflectOnlyMirror;
    [SerializeField]
    private GameObject previousSensor;

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
            Ray ray = new(position, direction);

            if (count < maxBounces - 1)
            {
                count++;
            }

            if (Physics.Raycast(ray, out RaycastHit hit, 300))
            {
                position = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);
                lineRenderer.SetPosition(count, hit.point);

                if (!hit.transform.CompareTag("Mirror") && reflectOnlyMirror) 
                { 
                    for (int j = (i+1); j <= maxBounces; j++) 
                    {
                        lineRenderer.SetPosition(j, hit.point);
                        if (hit.transform.CompareTag("Sensor"))
                        {
                            if (previousSensor != null && hit.transform.gameObject != previousSensor)
                            {
                                previousSensor.GetComponent<SensorChangeMaterial>().active = false;
                            }
                            previousSensor = hit.transform.gameObject;
                            hit.transform.gameObject.GetComponent<SensorChangeMaterial>().active = true;
                        }
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
                if (previousSensor != null)
                {
                    previousSensor.GetComponent<SensorChangeMaterial>().active = false;
                    previousSensor = null;
                }
                lineRenderer.SetPosition(count, ray.GetPoint(300));
            }
        }
    }
}