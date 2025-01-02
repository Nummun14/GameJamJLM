using UnityEngine;

public class playerMovment : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public Transform dirt;
    public float speed = 10;
    public bool canSpawn = true;
    public logicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 6.7) {
            playerBody.linearVelocity = Vector2.right * speed;
            spawnDirt();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -5.5) {
            playerBody.linearVelocity = Vector2.left * speed;

            spawnDirt();
        }
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.x > -9.5)
        {
            playerBody.linearVelocity = Vector2.down * speed;
            spawnDirt();
        }
        else if (Input.GetKey(KeyCode.UpArrow) && transform.position.x < 9.5)
        {
            playerBody.linearVelocity = Vector2.up * speed;
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
            Instantiate(dirt, playerBody.position, dirt.rotation);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
            canSpawn = false;
        if (collision.gameObject.layer == 6) {
            Debug.Log(collision.gameObject.name);
            Debug.Log("lose");
            logic.GameOver();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            canSpawn = true;
        }
    }
}
