using UnityEngine;

public class pzza : MonoBehaviour
{
    public float speed = 5;
    public float deadZone = -5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.down * speed) * Time.deltaTime;

        if (transform.position.y < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
