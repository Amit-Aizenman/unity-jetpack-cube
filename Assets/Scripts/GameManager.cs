using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int _playerScore;
    [SerializeField] int pointToWin = 3;
    [SerializeField] private int hitsToLose = 3;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    private void OnEnable()
    {
        MyEvents.OnPointCollected += HandlePointCollected;
        MyEvents.OnEnemyHit += EnemyHit;
    }

    private void OnDisable()
    {
        MyEvents.OnPointCollected -= HandlePointCollected;
    }

    private void HandlePointCollected(int points)
    {
        _playerScore += points;
        print("Point Collected! Current score is " +_playerScore);
        if (_playerScore >= pointToWin)
        {
            print ("Congratulations! You won!");
            QuitGame();
        }
    }

    private void EnemyHit(int damage)
    {
        hitsToLose--;
        if (hitsToLose <= 0)
        {
            print ("game over! Your score is: " + _playerScore);
            QuitGame();
        }
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

    public int GetPlayerScore()
    {
        return _playerScore;
    }


}
