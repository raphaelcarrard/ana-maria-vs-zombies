using System;
using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    
    void FixedUpdate()
    {
        var multiplerForRotation = -1;
        if (transform.localScale.x == -1)
        {
            multiplerForRotation = 1;
        }
        rb.linearVelocity = new Vector2(multiplerForRotation * 30, 0);
    }
}
