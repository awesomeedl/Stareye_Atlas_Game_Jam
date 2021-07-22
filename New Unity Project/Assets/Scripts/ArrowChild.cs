using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowChild : MonoBehaviour
{
    static bool dialogue1 = false;
    [SerializeField] LayerMask whatIsPlayer;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(!dialogue1 && Physics2D.OverlapCircle(transform.position, 1.5f, whatIsPlayer) != null)
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
            dialogue1 = true;
        }
    }
}
