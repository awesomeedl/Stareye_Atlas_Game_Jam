using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb2d;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(transform.position + (player.transform.position - transform.position).normalized * Time.fixedDeltaTime);
    }

    public void Destruct()
    {
        Destroy(gameObject);
    }
}
