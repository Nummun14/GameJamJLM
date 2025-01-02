using UnityEngine;

public class playerMovment : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float speed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) {
            myRigidbody.velocity = Vector2.right * speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            myRigidbody.velocity = Vector2.left * speed;
        }
        else
        {
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
