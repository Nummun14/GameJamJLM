using UnityEngine;

public class playerMovment : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public Transform dirt;
    public float speed = 10;
    public bool canSpawn = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) {
            playerBody.linearVelocity = Vector2.right * speed;
            spawnDirt();
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            playerBody.linearVelocity = Vector2.left * speed;

            spawnDirt();
        }
        else
        {
            playerBody.linearVelocity = Vector2.zero;
            spawnDirt();
        }

    }

    private void spawnDirt()
    {
        if (canSpawn)
        {
            Debug.Log("sapwnning");
            Instantiate(dirt, playerBody.position, dirt.rotation);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
            canSpawn = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            canSpawn = true;
        }
    }
}
