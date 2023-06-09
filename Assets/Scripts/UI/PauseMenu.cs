using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
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

    public void Restart()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
       Debug.Log("Menu");
    }
}
