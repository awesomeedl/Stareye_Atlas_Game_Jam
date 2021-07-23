using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditionCheck : MonoBehaviour
{

    DialogueManager dialogueManager;
    DialogueTrigger dialogueTrigger;
    BoxCollider2D boxCollider2D;
    public Animator transionAnim;
    private Child[] allChild;
    private bool dialogue;
    // Start is called before the first frame update
    void Start()
    {
        allChild = FindObjectsOfType<Child>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckWin())
        {
            if(TryGetComponent<DialogueTrigger>(out dialogueTrigger) && !dialogue)
            {
                dialogueTrigger.TriggerDialogue();
                dialogue = true;
            }
            if(!dialogueManager.started && dialogue)
            {
                if(SceneManager.GetActiveScene().buildIndex == 3)
                {
                    FindObjectOfType<Ending>().End();
                    return;
                }
                StartCoroutine(DelayLoadNext());
            }
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
