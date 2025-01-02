using UnityEngine;

public class pzza : MonoBehaviour
{
    public float speed = 5;
    public float deadZone = -5;
    public logicScript logic;
    public playerMovment player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovment>();
    }

    void Update()
    {
    transform.position = transform.position + (Vector3.down * speed) * Time.deltaTime;

    if (transform.position.y < deadZone)
    {
        Destroy(gameObject);
    }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("lose");
        logic.GameOver();
        player.tryandtry();
        }
}
