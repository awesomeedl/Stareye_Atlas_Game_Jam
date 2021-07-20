using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    public const int maxHearts = 3;

    public void UpdateHeartCount(int count)
    {
        foreach(var heart in hearts)
        {
            heart.color = Color.clear;
        }

        if(count == 1)
        {
            hearts[0].color = Color.white;
        }
        else if(count == 2)
        {
            hearts[0].color = Color.white;
            hearts[1].color = Color.white;
        }
        else if(count == 3)
        {
            hearts[0].color = Color.white;
            hearts[1].color = Color.white;
            hearts[3].color = Color.white;
        }
    }

}
