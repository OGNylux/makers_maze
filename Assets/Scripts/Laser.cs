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
    public GameObject startVFX;
    public GameObject endVFX;

    private List<ParticleSystem> particles = new List<ParticleSystem>();


    void Start()
    {
        FillLists();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = maxBounces + 1; // Stelle sicher, dass der LineRenderer genügend Positionen hat

        for (int i = 0; i < particles.Count; i++)
        {
            particles[i].Play();
        }
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
        startVFX.transform.position = startPoint.position;

        for (int i = 0; i < maxBounces; i++)
        {
            Ray ray = new(position, direction);

            if (count < maxBounces - 1)
            {
                count++;
            }

            if (Physics.Raycast(ray, out RaycastHit hit, 50))
            {
                position = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);
                lineRenderer.SetPosition(count, hit.point);
                endVFX.transform.position = hit.point;

                if (!hit.transform.CompareTag("Mirror") && reflectOnlyMirror)
                {
                    for (int j = (i + 1); j <= maxBounces; j++)
                    {
                        lineRenderer.SetPosition(j, hit.point);
                        endVFX.transform.position = hit.point;
                        if (previousSensor != null)
                        {
                            previousSensor.GetComponent<SensorChangeMaterial>().active = false;
                            previousSensor = null;
                        }

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
            }
            else
            {
                if (previousSensor != null)
                {
                    previousSensor.GetComponent<SensorChangeMaterial>().active = false;
                    previousSensor = null;
                }
                lineRenderer.SetPosition(count, ray.GetPoint(50));
                endVFX.transform.position = ray.GetPoint(50);
                break;
            }
        }
    }

    void FillLists()
    {
        var startPs = startVFX.transform.GetComponent<ParticleSystem>();
        if (startPs != null)
        {
            particles.Add(startPs);
        }

        var endPs = endVFX.transform.GetComponent<ParticleSystem>();
        if (endPs != null)
        {
            particles.Add(endPs);
        }
    }
}