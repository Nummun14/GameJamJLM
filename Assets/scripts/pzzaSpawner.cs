using UnityEngine;

public class pzzaSpawner : MonoBehaviour
{
    public GameObject pzza;
    public float SpawnRate = 2;
    public float minXPos = -5.5f;
    public float maxXpos = 6.7f;
    public float spawnHeight = 13 ;

    private float timer = 0;

    void Start(){}

    void Update()
    {
        if (timer < SpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            // Calculate the random X position within bounds
            float randomX = Random.Range(minXPos, maxXpos);

            // Set the spawn position above the visible area
            Vector2 spawnPosition = new Vector2(randomX, spawnHeight);

            // Instantiate the pzza
            Instantiate(pzza, spawnPosition, Quaternion.identity);

            // Reset the timer
            timer = 0;
        }
    }
}
