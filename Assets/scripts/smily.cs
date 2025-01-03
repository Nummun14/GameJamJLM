using UnityEngine;

public class smily : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * 5) * Time.deltaTime;

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
