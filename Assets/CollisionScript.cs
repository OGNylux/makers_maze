using UnityEngine;
using UnityEngine.Events;

public class CollisionScriptrobot : MonoBehaviour
{
    public UnityEvent onCollisionEvent;

    private void OnCollisionEnter(Collision collision)
    {

        onCollisionEvent.Invoke();
    }
}
