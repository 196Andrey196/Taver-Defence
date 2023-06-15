using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private int _levelToLoad;
    public void Play()
    {
      _sceneFader.FadeTo(_levelToLoad);
    }
    public void Quit()
    {
        Debug.Log("Exciting...");
        Application.Quit();
    }
}
