using UnityEngine;

public class BasicMovent : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody objectRb;
    private float zDestroy = -10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.forward * -speed);

        if(transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }
}
