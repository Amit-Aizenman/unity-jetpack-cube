using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _playerScore = 0;
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
    }

    public int GetPlayerScore()
    {
        return _playerScore;
    }
}
