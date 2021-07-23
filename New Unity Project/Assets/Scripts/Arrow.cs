using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb2d;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        Destroy(gameObject);
    }

    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.up = rb2d.velocity.normalized;
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
}
