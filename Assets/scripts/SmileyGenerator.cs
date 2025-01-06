using UnityEngine;

public class SmileyGenerator : MonoBehaviour
{
    public Transform smileyPrefab;
    private Transform lastSmiley;
     playerMovment player;

    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovment>();    }

    public void SpawnSmiley()
    {

        if (lastSmiley != null)
        {
            Destroy(lastSmiley.gameObject);
        }

        float x = Random.Range(-5.5f, 6.0f);
        float y = 13;
        if (x == player.playerBody.position.x || y == player.playerBody.position.y){
            x = Random.Range(-5.5f, 6.0f);
        }
        lastSmiley = Instantiate(smileyPrefab, new Vector2(x, y), Quaternion.identity);

    }
}

