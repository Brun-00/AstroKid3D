using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public static SceneFader Instance { get; private set; }

    [Header("Referências")]
    [SerializeField] private CanvasGroup canvasGroup;

    [Header("Configuração")]
    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        // Keep only one SceneFader instance across scenes.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Preserve the fader when loading a new scene.
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        // Clear the singleton reference when this instance is destroyed.
        if (Instance == this)
            Instance = null;
    }

    private void Start()
    {
        // Start with the screen visible and raycasts disabled.
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
    }

    public void LoadSceneWithFade(string sceneName)
    {
        // Start the fade process using the scene name.
        StartCoroutine(FadeAndLoad(sceneName, -1));
    }

    public void LoadSceneWithFade(int sceneIndex)
    {
        // Start the fade process using the scene build index.
        StartCoroutine(FadeAndLoad(null, sceneIndex));
    }

    private IEnumerator FadeAndLoad(string sceneName, int sceneIndex)
    {
        // Fade the screen to black before loading.
        yield return StartCoroutine(Fade(1f));

        AsyncOperation asyncLoad = !string.IsNullOrEmpty(sceneName)
            ? SceneManager.LoadSceneAsync(sceneName)
            : SceneManager.LoadSceneAsync(sceneIndex);

        // Wait until the new scene has finished loading.
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return null;

        // Fade back in after the scene has loaded.
        yield return StartCoroutine(Fade(0f));
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = canvasGroup.alpha;
        float elapsed = 0f;

        // Block input while the fade is active.
        canvasGroup.blocksRaycasts = true;

        while (elapsed < fadeDuration)
        {
            // Use unscaled time so the fade also works while paused.
            float delta = Mathf.Min(Time.unscaledDeltaTime, 0.05f);

            elapsed += delta;

            canvasGroup.alpha = Mathf.Lerp(
                startAlpha,
                targetAlpha,
                elapsed / fadeDuration
            );

            yield return null;
        }

        canvasGroup.alpha = targetAlpha;

        // Only block input while the screen is covered.
        canvasGroup.blocksRaycasts = targetAlpha > 0f;
    }
}