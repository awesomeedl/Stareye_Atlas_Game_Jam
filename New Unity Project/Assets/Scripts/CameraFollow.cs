using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    [Header("Camera Follow")]
    [SerializeField] GameObject followObject;
    [SerializeField] bool followY;
    [SerializeField] float yOffset;
    public GameObject cam;
    // [Header("Camera Shake")]
    // public float duration = 0.1f;
    // public float magnitude = 0.1f;

    // [Header("Boundary")]
    // public GameObject boundary;




    // [Header("Boss Level")]
    // private bool bossLevel = false;
    // public float transitionTime = 2f;
    // public GameObject boss;
    // private bool following = true;
    // private Vector3 originalPos;

    // Start is called before the first frame update
    void Start(){
        // Rect aspect = Camera.main.pixelRect;
        // camOrthoWidth = Camera.main.orthographicSize * aspect.width / aspect.height;
        // threshold = camOrthoWidth - followOffset;

        // camPosLimit = CalculateCamPosLimit();


        // if(boss != null)
        // {
        //     bossLevel = true;
        //     //boss.gameObject.SetActive(false);
        //     originalPos = boss.transform.position;
        //     boss.transform.position = (boss.transform.position + new Vector3(5.0f, 0f, 0f));
        // }
    }

    // Update is called once per frame
    void FixedUpdate(){
        Vector3 follow = followObject.transform.position;

        Vector3 newPosition = transform.position;
        newPosition.x = follow.x;
        if(followY)
        {
            newPosition.y = follow.y + yOffset;
        }

        cam.transform.position = newPosition;
    }


    // public void CallShake()
    // {
    //     StartCoroutine(Shake());
    // }

    // public IEnumerator Shake()
    // {
    //     Vector3 originalPos = cam.transform.localPosition;

    //     float elapsed = 0.0f;

    //     while (elapsed < duration)
    //     {
    //         float x = Random.Range(-1f, 1f) * magnitude;
    //         float y = Random.Range(-1f, 1f) * magnitude;

    //         cam.transform.localPosition = new Vector3(
    //             cam.transform.localPosition.x + x, 
    //             cam.transform.localPosition.y + y, originalPos.z);

    //         elapsed += Time.deltaTime;

    //         yield return null;
    //     }

    //     cam.transform.localPosition = originalPos;
    // }

    // IEnumerator FocusBoss()
    // {
    //     HeroBehavior.instance.canMove = false;
    //     float timeElapsed = 0f;
    //     Vector3 camOrigPos = cam.transform.position;
    //     Vector3 finalPos = new Vector3(camPosLimit.y, 0, cam.transform.position.z);
    //     while(timeElapsed < transitionTime)
    //     {
    //         timeElapsed += Time.deltaTime;
    //         cam.transform.position = Vector3.Lerp(camOrigPos, finalPos, timeElapsed / transitionTime);
    //         yield return null;
    //     }
    //     cam.transform.position = finalPos;
        
    //     timeElapsed = 0;
    //     while(timeElapsed < transitionTime)
    //     {
    //         timeElapsed += Time.deltaTime;
    //         boss.transform.position = Vector3.Lerp(originalPos + Vector3.right * 5, originalPos, timeElapsed / transitionTime);
    //         yield return null;
    //     }
    //     Final_Boss temp;
    //     MidBoss_Enemy temp1;
    //     boss.TryGetComponent<Final_Boss>(out temp);
    //     boss.TryGetComponent<MidBoss_Enemy>(out temp1);
    //     if(temp != null) temp.temp();
    //     if(temp1 != null) temp1.temp();
    //     boss.transform.position = originalPos;


    //     HeroBehavior.instance.canMove = true;
    // }
}