using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        child.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.layer == 10)
        {
            child.GetComponent<Rigidbody2D>().isKinematic = false;
            Destroy(gameObject);
        }
    }
}
