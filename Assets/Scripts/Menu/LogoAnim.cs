using UnityEngine;

public class LogoAnim : MonoBehaviour
{
    [Header("Configurações de Órbita")]
    [Tooltip("Velocidade única para manter a forma da elipse")]
    public float orbitSpeed = 2f;

    private float horizontalAmplitude;
    private float verticalAmplitude;

    private RectTransform rectTransform;
    private Vector2 startAnchoredPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startAnchoredPosition = rectTransform.anchoredPosition;

        // Definimos amplitudes diferentes para ser uma elipse e não um círculo perfeito
        horizontalAmplitude = Random.Range(40f, 60f) * (Random.value > 0.5f ? 1 : -1);
        verticalAmplitude = Random.Range(20f, 40f) * (Random.value > 0.5f ? 1 : -1);
    }

    void Update()
    {
        // Usamos o mesmo Time.time * orbitSpeed para ambos
        float timeIndex = Time.time * orbitSpeed;

        // A mágica: Cosseno no X e Seno no Y
        float newX = startAnchoredPosition.x + Mathf.Cos(timeIndex) * horizontalAmplitude;
        float newY = startAnchoredPosition.y + Mathf.Sin(timeIndex) * verticalAmplitude;

        rectTransform.anchoredPosition = new Vector2(newX, newY);

        // BÔNUS: Leve inclinação para parecer que está flutuando no espaço
        float tilt = Mathf.Sin(Time.time * (orbitSpeed * 0.5f)) * 5f;
        rectTransform.localRotation = Quaternion.Euler(0, 0, tilt);
    }
}