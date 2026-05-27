using UnityEngine;

public class Target : MonoBehaviour
{
    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10;
    private float xRange = 4f;
    private float ySpawnPos = -6f;
    private Rigidbody targetRb;
    private GameManager5 gameManager5;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position =RandomSpawnPos();
        gameManager5 = GameObject.Find("Game Manager").GetComponent<GameManager5>();
       
    }
     Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public int pointValue;
    public ParticleSystem explosionParticle;
    private void OnMouseDown() {
        if (gameManager5.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager5.UpdateScore(pointValue);
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager5.GameOver();
        }
    }

}
