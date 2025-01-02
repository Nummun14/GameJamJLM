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

        float x = Random.Range(-5.5f, 6.0f);
        float y = Random.Range(-9.5f, 9.5f);
        if (x == player.playerBody.position.x || y == player.playerBody.position.y){
            x = Random.Range(-5.5f, 6.0f);
            y = Random.Range(-9.5f, 9.5f);
        }

        lastSmiley = Instantiate(smileyPrefab, new Vector2(x, y), Quaternion.identity);
    }
}

