using UnityEngine;

public class road : MonoBehaviour
{
    public float speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = transform.position + (Vector3.down * speed) * Time.deltaTime; 
    }
}
