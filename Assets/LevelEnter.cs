using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnter : MonoBehaviour
{
    // Start is called before the first frame update
    public bool entered = false;
    private bool showText = false;
    public string text;
    public string subtext;
    public GameObject UIOverlay;
    public TMP_Text TextMesh;
    public TMP_Text SubTextMesh;
    public float fadeDuration = 1.0f; // Dauer des Fadings in Sekunden
    public float displayDuration = 4.0f; // Dauer, wie lange der Text angezeigt wird

    void Start()
    {
        TextMesh.text = text;
        SubTextMesh.text = subtext;
        SetUIOverlayAlpha(0); // Setze die Opazität des UIOverlay auf 0
    }

    // Update is called once per frame
    void Update()
    {
        if (entered && !showText)
        {
            showText = true;
            StartCoroutine(FadeInAndOutUIOverlay());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !entered)
        {
            entered = true;
            UIOverlay.SetActive(true);
        }
    }

    IEnumerator FadeInAndOutUIOverlay()
    {
        yield return StartCoroutine(FadeInUIOverlay());
        yield return new WaitForSeconds(displayDuration);
        yield return StartCoroutine(FadeOutUIOverlay());
    }

    IEnumerator FadeInUIOverlay()
    {
        float elapsedTime = 0f;
        CanvasGroup canvasGroup = UIOverlay.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = UIOverlay.AddComponent<CanvasGroup>();
        }

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }
    }

    IEnumerator FadeOutUIOverlay()
    {
        float elapsedTime = 0f;
        CanvasGroup canvasGroup = UIOverlay.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = UIOverlay.AddComponent<CanvasGroup>();
        }

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(1 - (elapsedTime / fadeDuration));
            yield return null;
        }

        UIOverlay.SetActive(false); // Deaktiviere das UIOverlay nach dem Ausblenden
    }

    void SetUIOverlayAlpha(float alpha)
    {
        CanvasGroup canvasGroup = UIOverlay.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = UIOverlay.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = alpha;
    }
}