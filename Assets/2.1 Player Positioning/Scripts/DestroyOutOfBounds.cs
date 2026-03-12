using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topLimit = 30;
    private float lowerLimit = -10;
    private float leftLimit = -20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topLimit)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < lowerLimit)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
    }
}
