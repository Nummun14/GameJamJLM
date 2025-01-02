using UnityEngine;

public class pzzaSpawner : MonoBehaviour
{
    public GameObject pzza;
    public float SpawnRate= 2;
    private float timer = 0;
    public float leftest = -4;
    public float rightest = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < SpawnRate) {
            timer += Time.deltaTime;
        }
        else {
            float leftestPoint = transform.position.x - leftest;
            float rightestPoint = transform.position.x - rightest;
            Instantiate(road, new Vector3(Random.Range(leftestPoint, rightestPoint), transform.position.y, transform.position.z), rotation);
            timer = 0;
        }
    }
}
