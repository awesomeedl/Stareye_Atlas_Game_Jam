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
        Vector3 movement = player.transform.position;

        Vector3 newPosition = new Vector3(movement.x, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.fixedDeltaTime * 2);
    }

    public void Destruct()
    {
        Destroy(gameObject);
    }
}
