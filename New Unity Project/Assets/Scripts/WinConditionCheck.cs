using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionCheck : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    public Animator transionAnim;
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
            StartCoroutine(DelayLoadNext());
        }
    }

    IEnumerator DelayLoadNext()
    {
        yield return new WaitForSeconds(2);
        transionAnim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(1);
        SceneLoader.instance.LoadNextLevel();
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
