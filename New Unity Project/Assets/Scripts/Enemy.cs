using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb2d;
    GameObject player;


    public Collider2D capCollider;
    bool groundDetected;
    bool wallDetected;
    int facingDirection = 1;
    public float movementSpeed = 5f;

    public Transform groundCheck;
    public float groundCheckDistance;
    public Transform wallCheck;
    public float wallCheckDistance;
    public LayerMask whatIsGround;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();   
    }

    void Move()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);

        if(IsGrounded())
        {
            if(!groundDetected || wallDetected)
            {
                Flip();
            }
            else
            {
                rb2d.velocity = new Vector2(movementSpeed * facingDirection, rb2d.velocity.y);
                rb2d.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
            }
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(capCollider.bounds.center, capCollider.bounds.size, 0, Vector2.down, 0.1f, whatIsGround);
        return (hit.collider != null);
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);

    }

    public void Destruct()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }
    
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.layer == 10)
        {
            GetComponent<Health>().decreaseHealth(1);
            if(GetComponent<Health>().isDead())
            {
                Destruct();
            }
        }
    }
}
