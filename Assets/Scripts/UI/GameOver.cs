using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;

    public void Restart()
    {
        _sceneFader.FadeTo(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        _sceneFader.FadeTo(0);
    }
}
