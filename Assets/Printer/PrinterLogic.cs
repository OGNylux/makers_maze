using UnityEngine;
using System.Collections;


public class PrinterController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Animator-Komponente holen
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        // Animationen durch Setzen der Parameter starten
        animator.SetBool("PlayAnimation1", true);

        // Optional: Parameter nach Start zurücksetzen
        StartCoroutine(ResetParameters());
    }

    private IEnumerator ResetParameters()
    {
        yield return new WaitForSeconds(0.1f); // Kurz warten, damit Animationen starten
        animator.SetBool("PlayAnimation1", false);
    }
}
