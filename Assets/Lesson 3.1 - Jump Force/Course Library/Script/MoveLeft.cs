using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController4 playerController4Script;
   private float leftBound = -15;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController4Script =
            GameObject.Find("Player").GetComponent<PlayerController4>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController4Script.gameOver == false) { 
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")){
            Destroy(gameObject);
        }
    }
}
