using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrigger : MonoBehaviour
{
    [SerializeField] GameObject platform;
    bool finished = false;

    void OnTriggerEnter2D()
    {
        if(!finished)
        {
            StartCoroutine(MoveUpPlatform());
            finished = true;
        }
    }

    IEnumerator MoveUpPlatform()
    {
        float timeElapsed = 0f;
        float duration = 3f;
        Vector3 origPos = platform.transform.position;
        Vector3 newPos = origPos + new Vector3(0f, 10f, 0f);

        while(timeElapsed < duration)
        {
            platform.transform.position = Vector3.Lerp(origPos, newPos, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
