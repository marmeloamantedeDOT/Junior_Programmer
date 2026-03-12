using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    public float speed = 20;
    public float colorR = 225;
    public float colorG = 1;
    public float colorB = 1;
    public float colorA = 43;
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(colorR, colorG, colorB, colorA);
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, speed, 0.0f);
    }
}
