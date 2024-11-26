using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _playerScore = 0;
    [SerializeField] int _pointToWin = 3;
    private void OnEnable()
    {
        MyEvents.OnPointCollected += HandlePointCollected;
    }

    private void OnDisable()
    {
        MyEvents.OnPointCollected -= HandlePointCollected;
    }

    private void HandlePointCollected(int points)
    {
        _playerScore += points;
        print("Point Collected! Current score is " + _playerScore);
        if (points >= _pointToWin)
        {
            print ("Congratulations! You won!");
            QuitGame();
        }
    }

    public int GetPlayerScore()
    {
        return _playerScore;
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        // Application.Quit() does not work in the editor
        // so we use this instead
                UnityEditor.EditorApplication.isPlaying = false;
        #else
        // Close the game!
        Application.Quit();
        #endif
    }

}
