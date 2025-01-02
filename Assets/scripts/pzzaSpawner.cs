using UnityEngine;

public class pzzaSpawner : MonoBehaviour
{
    public GameObject pzza;
    public float SpawnRate= 2;
    private float timer = 0;
    public float leftest = -5.5f;
    public float rightest = 6.7f;
    public float spawnHeight = 13 ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < SpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            // Calculate the random X position within bounds
            float randomX = Random.Range(leftest, rightest);

            // Set the spawn position above the visible area
            Vector2 spawnPosition = new Vector2(randomX, spawnHeight);

            // Instantiate the pzza
            Instantiate(pzza, spawnPosition, Quaternion.identity);

            // Reset the timer
            timer = 0;
        }
    }
}
