using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip hurtSound;
    AudioSource audioSource;
    protected Rigidbody2D rb2d;
    protected GameObject player;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>().gameObject;
        audioSource = player.GetComponent<AudioSource>();
    }
    
    public void Destruct()
    {
        Destroy(gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.layer == 10)
        {
            audioSource.PlayOneShot(hurtSound);
            Health enemyHealth;
            if(TryGetComponent<Health>(out enemyHealth))
            {
                enemyHealth.decreaseHealth(1);
                if(enemyHealth.isDead())
                {
                    Destruct();
                }
            }
        }
    }
}
