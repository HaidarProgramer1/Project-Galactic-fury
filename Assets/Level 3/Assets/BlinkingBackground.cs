using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal; // Tambahkan ini untuk menggunakan Light2D

public class BlinkingBackgroundLight : MonoBehaviour
{
    public float blinkDuration = 0.2f; // Durasi dalam detik untuk satu siklus blink
    private Light2D light2D;
    private bool isBlinking = false;

    void Start()
    {
        light2D = GetComponent<Light2D>();
        if (light2D == null)
        {
            Debug.LogError("No Light2D found on the GameObject.");
        }
        else
        {
            StartCoroutine(Blink());
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            float elapsedTime = 0f;
            float originalIntensity = light2D.intensity;
            float targetIntensity = 0f; // Mengubah intensitas ke 0

            // Fade out
            while (elapsedTime < blinkDuration)
            {
                light2D.intensity = Mathf.Lerp(originalIntensity, targetIntensity, elapsedTime / blinkDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Fade in
            elapsedTime = 0f;
            while (elapsedTime < blinkDuration)
            {
                light2D.intensity = Mathf.Lerp(targetIntensity, originalIntensity, elapsedTime / blinkDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
