using UnityEngine;

public class playerMovment : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public Transform dirt;
    public float speed = 6;
    public bool canSpawn = true;
    public logicScript logic;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public int currentSpriteIndex = 0;
    public bool isAlive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(animate), 0.15f, 0.15f);

    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
            movment();
        else
            playerBody.linearVelocity = Vector2.zero;
    }

    private void spawnDirt() 
    {
        if (canSpawn)
        {
            Instantiate(dirt, playerBody.position, dirt.rotation);
            if (isAlive)
                logic.AddScore(1);
        }
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
            canSpawn = false;
        if (collision.gameObject.layer == 6)
        {
            Debug.Log(collision.gameObject.name);
            Debug.Log("lose");
            logic.GameOver();
            isAlive = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            canSpawn = true;
        }
    }

    private void animate()
    {
        currentSpriteIndex++;
        if (currentSpriteIndex >= sprites.Length)
            currentSpriteIndex = 0;

        spriteRenderer.sprite = sprites[currentSpriteIndex];
    }
    private void movment()
    {
        bool isKeyPressed = false;
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) )&& transform.position.x < 6.7)
        {
            playerBody.linearVelocity = new Vector2(1 * speed, playerBody.linearVelocity.y);
            spawnDirt();
            isKeyPressed = true;
        }
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x > -7.5)
        {
            playerBody.linearVelocity = new Vector2(-1 * speed, playerBody.linearVelocity.y);
            spawnDirt();
            isKeyPressed = true;
        }
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && transform.position.y > -9.5)
        {
            playerBody.linearVelocity = new Vector2(playerBody.linearVelocity.x, -1 * speed);
            spawnDirt();
            isKeyPressed = true;
        }
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && transform.position.y < 9.5)
        {
            playerBody.linearVelocity = new Vector2(playerBody.linearVelocity.x, 1 * speed);
            spawnDirt();
            isKeyPressed = true;
        }
        if (!isKeyPressed)
        {
            playerBody.linearVelocity = Vector2.zero;
            spawnDirt();
        }
    }
}
