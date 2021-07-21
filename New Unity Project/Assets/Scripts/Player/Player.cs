using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool grounded = true;
    private Rigidbody2D rb2d;
    public float jumpPower;
    private BoxCollider2D boxCollider2D;
    private Health health;
    private SpriteRenderer spriteRenderer;
    private HeartDisplay heartDisplay;
    public float speed;
    private float moveInput;
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private LayerMask childLayerMask;

    void Start()
    {
        heartDisplay = FindObjectOfType<HeartDisplay>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
        rb2d = GetComponent<Rigidbody2D>(); 
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            //SoundManager.PlaySound("jump");
            rb2d.velocity = Vector2.up * jumpPower;
        }
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
        if(moveInput != 0)
        {
            transform.rotation = Quaternion.Euler(0, moveInput > 0 ? 0 : 180, 0);
        }
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, platformsLayerMask);
        return raycastHit2D.collider != null;
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {   
        if(collider2D.gameObject.layer == 9)
        {
            health.decreaseHealth(1);
            heartDisplay.UpdateHeartCount(health.health);
            StartCoroutine(flashRed());
            if(health.isDead())
            {
                SceneLoader.instance.LoadGameOver();
            }
        }
    }

    IEnumerator flashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}
