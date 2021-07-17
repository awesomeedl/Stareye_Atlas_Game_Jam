using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool grounded = true;
    private Rigidbody2D rb2d;
    public float jumpPower;
    private BoxCollider2D boxCollider2D;

    public float speed;
    private float moveInput;
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private LayerMask childLayerMask;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            rb2d.velocity = Vector2.up * jumpPower;
        }
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.layer == 7)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, platformsLayerMask);
        return raycastHit2D.collider != null;
    }
}
