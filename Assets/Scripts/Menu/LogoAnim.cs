using UnityEngine;

public class LogoAnim : MonoBehaviour
{
    [Header("Orbit Settings")]
    public float orbitSpeed = 2f;

    private float horizontalAmplitude;
    private float verticalAmplitude;

    private RectTransform rectTransform;
    private Vector2 startAnchoredPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startAnchoredPosition = rectTransform.anchoredPosition;

        // Set different amplitudes to create an elliptical motion.
        horizontalAmplitude = Random.Range(40f, 60f) * (Random.value > 0.5f ? 1 : -1);
        verticalAmplitude = Random.Range(20f, 40f) * (Random.value > 0.5f ? 1 : -1);
    }

    void Update()
    {
        // Use the same time value for both axes.
        float timeIndex = Time.time * orbitSpeed;

        // Use cosine for X and sine for Y to create the orbit.
        float newX = startAnchoredPosition.x + Mathf.Cos(timeIndex) * horizontalAmplitude;
        float newY = startAnchoredPosition.y + Mathf.Sin(timeIndex) * verticalAmplitude;

        rectTransform.anchoredPosition = new Vector2(newX, newY);

        // Add a slight tilt to make the logo feel like it is floating.
        float tilt = Mathf.Sin(Time.time * (orbitSpeed * 0.5f)) * 5f;
        rectTransform.localRotation = Quaternion.Euler(0, 0, tilt);
    }
}