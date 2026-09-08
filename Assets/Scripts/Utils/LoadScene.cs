using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void Load(int i)
    {
        // Make sure the game is running before changing scenes.
        Time.timeScale = 1f;

        // Load the scene using its build index.
        SceneFader.Instance.LoadSceneWithFade(i);
    }

    public void load(string s)
    {
        // Load the scene using its name.
        SceneFader.Instance.LoadSceneWithFade(s);
    }
}