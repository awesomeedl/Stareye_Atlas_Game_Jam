using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionCheck : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;

    private Child[] allChild;
    // Start is called before the first frame update
    void Start()
    {
        allChild = FindObjectsOfType<Child>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckWin())
        {
            GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 0.3f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.3f);
        }
    }

    bool CheckWin()
    {
        foreach(var c in allChild)
        {
            if(!boxCollider2D.bounds.Contains(c.gameObject.transform.position))
            {
                return false;
            }
        }
        return true;
    }
}
