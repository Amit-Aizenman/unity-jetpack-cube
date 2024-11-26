using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] int _point = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        MyEvents.OnPointCollected?.Invoke(_point);
        Destroy(this.gameObject);
    }
}
