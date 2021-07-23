using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if(collider2d.gameObject.layer == 7 || collider2d.gameObject.layer == 8)
        {
            Debug.Log("Boundry triggerd gameover");
            SceneLoader.instance.LoadGameOver();
        }
    }
}
