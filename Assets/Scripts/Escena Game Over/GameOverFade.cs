using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverFade : MonoBehaviour
{
    // CanvasGroup para controlar el fade
    [SerializeField] private CanvasGroup fadeCanvas;

    // Duración del fade-in
    [SerializeField] private float fadeDuration = 2f; 

    void Start()
    {
        // Inicia el fade-in
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        fadeCanvas.alpha = 1f;
        fadeCanvas.interactable = false;
        fadeCanvas.blocksRaycasts = false;

        // Incrementa gradualmente el alpha del CanvasGroup
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeCanvas.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        // Habilita la interacción al finalizar el fade-in
        fadeCanvas.interactable = true;
        fadeCanvas.blocksRaycasts = true;
    }
}
