using System;
using UnityEngine;

public class MyEvents : MonoBehaviour
{
    public static Action<int> OnPointCollected;
    public static Action<int> OnEnemyHit;
}
