using UnityEngine;

public class background : MonoBehaviour
{
    public Transform building1;
    public float space;
    void Start()
    {
        for (int i = -4; i < 4; i++) {
            Instantiate(building1, new Vector2(-14, i * space), building1.rotation);
        }
        for (int i = -4; i < 4; i++)
        {
            Instantiate(building1, new Vector2(14, i * space), building1.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
