using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerControlprop4 : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5;
    private GameObject focalPoint;
    public bool hasPowerup;
    private float powerupStrength = 15;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    public GameObject PowerupIndicator;
    // Update is called once per frame
    void Update()
    {
        float fowardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * fowardInput * speed);
        PowerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(powerupCountdownRoutine());
            PowerupIndicator.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
       if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigibody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.transform.position - transform.position);

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            enemyRigibody.AddForce( awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator powerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        PowerupIndicator.gameObject.SetActive(false);
    }
}
