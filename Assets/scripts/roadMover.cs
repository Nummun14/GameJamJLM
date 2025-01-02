using UnityEngine;

public class roadMover : MonoBehaviour
{
    public GameObject road;
    public float SpawnRate = 1;
    private float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < SpawnRate) {
            timer += Time.deltaTime;
        }
        else {
        Quaternion rotation = transform.rotation * Quaternion.Euler(0, 0, 90);
        Instantiate(road, transform.position, rotation);
        timer = 0;
        }

    }
}
