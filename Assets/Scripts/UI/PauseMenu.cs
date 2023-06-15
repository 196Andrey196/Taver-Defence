using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private SceneFader _sceneFader;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        _menu.SetActive(!_menu.activeSelf);
        if (_menu.activeSelf)

            Time.timeScale = 0f;

        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Continiue()
    {
        Toggle();
    }

    public void Restart()
    {
        Toggle();
        _sceneFader.FadeTo(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        Toggle();
        _sceneFader.FadeTo(0);
    }
}
