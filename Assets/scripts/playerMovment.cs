using UnityEngine;

public class playerMovment : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public SoundManger soundManger;
    public Transform dirt;
    public float speed = 6;
    public logicScript logic;
    public Sprite[] sprites;
    public int currentSpriteIndex = 0;
    // area of movement variables
    [Header("area of movement variables")]
    public float maxYPos;
    public float minYPos;
    public float maxXPos;
    public float minXPos;

    private bool canSpawn = true;
    private bool isAlive = true;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        soundManger = GameObject.FindGameObjectWithTag("audio").GetComponent<SoundManger>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(animate), 0.15f, 0.15f);
    }
    void Update()
    {
        if (isAlive)
            movement();
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
            soundManger.playSFX(soundManger.crushSound);
            logic.GameOver();
            isAlive = false;
        }
        if (collision.gameObject.layer == 7)
        {
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
    private void movement()
    {
        Vector2 direction = Vector2.zero;

        // Check for key presses and adjust the direction vector accordingly
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x < maxXPos) 
        {
            direction += Vector2.right;
        }
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x > minXPos) 
        {
            direction += Vector2.left;
        }
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && transform.position.y < maxYPos) 
        {
            direction += Vector2.up;
        }
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && transform.position.y > minYPos)
        {
            direction += Vector2.down;
        }

        // Normalize the direction to ensure consistent speed in diagonal movement
        if (direction != Vector2.zero)
        {
            direction.Normalize();
            playerBody.linearVelocity = direction * speed;
            spawnDirt();
        }
        else
        {
            playerBody.linearVelocity = Vector2.zero;
            spawnDirt();
        }
    }
    public void setSpeed(float speed)
    {
        this.speed = speed;     
    }
}
