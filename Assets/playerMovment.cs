using UnityEngine;

public class playerMovment : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float speed = 10;
    //public GameObject logic;
    public logicScript logic;
    public bool playerAlive = true;    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(playerAlive);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerAlive);
        if (Input.GetKey(KeyCode.RightArrow) && playerAlive) {
            myRigidbody.velocity = Vector2.right * speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && playerAlive) {
            myRigidbody.velocity = Vector2.left * speed;
        }
        else
        {
            myRigidbody.velocity = Vector2.zero;
        }
    }

    public void tryandtry() {
        playerAlive = false;
    }
}
