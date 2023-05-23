using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool _gameEnded = false;
    void Update()
    {
        if (_gameEnded)
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
        _gameEnded = true;
        Debug.Log("End Game!!");
    }
}
