using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite[] heartsSprite;
    public const int maxHearts = 3;

    public void UpdateHeartCount(int count)
    {
        foreach(var heart in hearts)
        {
            heart.GetComponent<Image>().sprite = heartsSprite[0];
        }

        if(count == 1)
        {
            hearts[0].GetComponent<Image>().sprite = heartsSprite[1];
        }
        else if(count == 2)
        {
            hearts[0].GetComponent<Image>().sprite = heartsSprite[1];
            hearts[1].GetComponent<Image>().sprite = heartsSprite[1];
        }
        else if(count == 3)
        {
            hearts[0].GetComponent<Image>().sprite = heartsSprite[1];
            hearts[1].GetComponent<Image>().sprite = heartsSprite[1];
            hearts[3].GetComponent<Image>().sprite = heartsSprite[1];
        }
    }

}
