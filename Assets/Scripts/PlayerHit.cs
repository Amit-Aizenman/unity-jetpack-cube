using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int _initialHealth = 100;
    private void OnEnable()
    {
        MyEvents.OnEnemyHit += EnemyHit;
    }

    private void OnDisable()
    {
        MyEvents.OnPointCollected -= EnemyHit;

    }
    
    private void EnemyHit(int damage)
    {
        _initialHealth -= damage;
        print ("Character got hit! Health is now " + _initialHealth);
    }
}
