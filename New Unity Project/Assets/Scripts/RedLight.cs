using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLight : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public BoxCollider2D swordChild;
    public BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        swordChild = FindObjectOfType<SwordChild>().gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.clear;
        boxCollider2D = transform.parent.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(boxCollider2D.bounds.Contains(swordChild.bounds.center))
        {
            spriteRenderer.color = Color.white;
        }
        else
        {
            spriteRenderer.color = Color.clear;
        }
    }
}
