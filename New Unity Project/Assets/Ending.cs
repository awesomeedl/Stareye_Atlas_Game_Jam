using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    DialogueManager dialogueManager;
    DialogueTrigger dialogueTrigger;
    public Image image;
    // Start is called before the first frame update
    public void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    public void End()
    {
        StartCoroutine(cEnd());
    }

    IEnumerator cEnd()
    {
        float time = 0f;
        float endTime = 5f;
        float transparency;
        
        while(time <= endTime)
        {
            transparency = Mathf.Lerp(0, 1, time / endTime);
            image.color = new Color(1, 1, 1, transparency);
            time += 0.1f;
            yield return null;
        }

        dialogueTrigger.TriggerDialogue();
        while(dialogueManager.started)
        {
            yield return null;
        }
        SceneLoader.instance.LoadMenu();
    }
}
