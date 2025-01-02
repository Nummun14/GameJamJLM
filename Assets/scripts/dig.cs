using UnityEngine;

public class dig : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public Transform dirt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
           Instantiate(dirt,playerBody.position, dirt.rotation);
        }
    }
}
