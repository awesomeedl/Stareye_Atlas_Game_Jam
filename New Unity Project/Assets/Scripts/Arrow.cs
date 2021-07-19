using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.layer == 9)
        {
            collider2D.gameObject.GetComponent<Health>().decreaseHealth(1);
        }
        Destroy(gameObject);
    }
}
