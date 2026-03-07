using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropeller : MonoBehaviour
{
    public float spinSpeed = 1000f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

// Update is called once per frame
void Update()
    {
        transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
    }
}
