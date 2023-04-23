using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameSheep : MonoBehaviour
{
    private float sheepSpeed = 3f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
}
