using UnityEngine;

public class playerMovment : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public Transform dirt;
    public float speed = 10;
    public bool canSpawn = true;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public int currentSpriteIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(animate), 0.15f, 0.15f);
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
        else
        {
            playerBody.linearVelocity = Vector2.zero;
            spawnDirt();
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

    private void animate()
    {
        currentSpriteIndex++;
        if (currentSpriteIndex >= 7)
            currentSpriteIndex = 0;

        spriteRenderer.sprite = sprites[currentSpriteIndex];
    }

    private void spawnDirt()
    {
        if (canSpawn)
        {
            Debug.Log("sapwnning");
            Instantiate(dirt, playerBody.position, dirt.rotation);
        }
    }
}
