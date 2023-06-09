using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameIsOver;
    [SerializeField] private GameObject _gameOverMenu;

    private void Start()
    {
        gameIsOver = false;
        _gameOverMenu.SetActive(false);
    }
    void Update()
    {
        if (gameIsOver)
        {
            return;
        }
        if (PlayerStats.curentLive == 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameIsOver = true;
        _gameOverMenu.SetActive(true);
    }
}
