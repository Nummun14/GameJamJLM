using UnityEngine;

public class pzza : MonoBehaviour
{
    public float speed = 5;
    public float deadZone = -5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Move downward
    transform.position = transform.position + (Vector3.down * speed) * Time.deltaTime;

    // Debug log for position

    // Destroy when below deadZone
    if (transform.position.y < deadZone)
    {
        Destroy(gameObject);
    }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("lose");
    }
}
