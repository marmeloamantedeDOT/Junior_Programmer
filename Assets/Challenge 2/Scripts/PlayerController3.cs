using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public GameObject dogPrefab;
    public float fireDelay = 20;
    void Update()
    {
        fireDelay -= 0.1f;
        if (Input.GetKeyDown(KeyCode.Space) && fireDelay <= 0.0f)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            fireDelay = 20;  
        }
    }
}