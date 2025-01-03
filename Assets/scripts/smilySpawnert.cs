using UnityEngine;

public class SmileyGenerator : MonoBehaviour
{
    public Transform smileyPrefab;
    public float spawnRate;
    private Transform lastSmiley;
    playerMovment player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovment>();
        InvokeRepeating("SpawnSmiley", 0f, spawnRate);
    }

    void SpawnSmiley()
    {
        if (lastSmiley != null)
        {
            Destroy(lastSmiley.gameObject);
        }

        const float minDistance = 1.0f; // Minimum distance from player
        const float spawnAreaXMin = -5.5f, spawnAreaXMax = 6.0f;
        const float spawnAreaYMin = -9.5f, spawnAreaYMax = 9.5f;

        Vector2 playerPosition = player.playerBody.position;
        Vector2 spawnPosition = Vector2.zero;

        int maxAttempts = 10;
        bool validPositionFound = false;

        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            float x = Random.Range(spawnAreaXMin, spawnAreaXMax);
            float y = Random.Range(spawnAreaYMin, spawnAreaYMax);
            spawnPosition = new Vector2(x, y);

            // Check if the spawn position is far enough from the player
            if (Vector2.Distance(spawnPosition, playerPosition) >= minDistance)
            {
                validPositionFound = true;
                break;
            }
        }

        if (!validPositionFound)
        {
            Debug.LogWarning("Could not find a valid position to spawn the smiley.");
        }

        // Spawn the smiley at the chosen position
        lastSmiley = Instantiate(smileyPrefab, spawnPosition, Quaternion.identity);
    }
}