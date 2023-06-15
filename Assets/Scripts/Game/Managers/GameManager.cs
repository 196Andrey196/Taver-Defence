using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool gameIsOver;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _compliteLevel;


    private void Start()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        gameIsOver = false;
        _gameOverMenu.SetActive(false);
        _compliteLevel.SetActive(false);
    }
    void Update()
    {
        if (gameIsOver)
        {
            return;
        }
        if (PlayerStats.instance.curentLive == 0)
        {
            gameIsOver = true;
            EndGame();
        }
    }

    private void EndGame()
    {
        _gameOverMenu.SetActive(true);
    }
    public void WinLevel()
    {
        _compliteLevel.SetActive(true);
    }

}
