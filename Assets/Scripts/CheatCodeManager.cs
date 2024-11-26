using UnityEngine;

public class CheatCodeManager : MonoBehaviour
{
    public CheatCodeManager Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            // 1 - reset player Score
        {
            print("Resetting player score");
            GameManager.Instance.ResetPlayerScore();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
            // 2 - Reset Player Health
        {
            print ("Resetting player Health");
            GameManager.Instance.ResetInitialHealth();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
            // 3 - Reset Player Position
        {
            print("Resetting player position");
            PlayerMovement._playerResetFlag = true;

        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            
            print("Resetting enemies position");
            MyEvents.EnemyReset?.Invoke(1);

        }
    }

}

