using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool grounded = true;
    private Rigidbody2D rb2d;
    public float jumpPower;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private LayerMask childLayerMask;

    void Start()
    {
        rb2d = rb2d = GetComponent<Rigidbody2D> ();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * Time.deltaTime * 5);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            rb2d.velocity = Vector2.up * jumpPower;
        }
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
