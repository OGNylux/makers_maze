using UnityEngine;

public class DeactivateObject : MonoBehaviour
{
    // Referenz auf das zu deaktivierende GameObject
    public GameObject targetObject;

    // Methode zum Deaktivieren
    public void DeactivateTarget()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Kein Zielobjekt zugewiesen!");
        }
    }
}
