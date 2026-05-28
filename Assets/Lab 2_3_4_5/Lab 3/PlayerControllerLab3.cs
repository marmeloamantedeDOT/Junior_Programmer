using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerControllerLab3 : MonoBehaviour
{

    private float speed = 10.0f;
    private Rigidbody playerRB;

    [SerializeField]
    private float zBound = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        ConstrainPlayerPosition();

    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRB.AddForce(Vector3.forward * speed * verticalInput);
        playerRB.AddForce(Vector3.right * speed * horizontalInput);
        
    }

    void ConstrainPlayerPosition()
    {
                if ( transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x , transform.position.y, -zBound);
        }

        if( transform.position.z > zBound)
        {
                        transform.position = new Vector3(transform.position.x , transform.position.y, zBound);

        }
    }

    private void onCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Inimigo"))
        {
            Debug.Log("Player has colided with the enemy.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
