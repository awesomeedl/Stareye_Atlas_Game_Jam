using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player_Mode
{
    [Header("Arrow")]
    [SerializeField] Sprite bow_sprite;
    [SerializeField] GameObject arrowPrefab;
    float arrow_timeBtwAttack = 0;
    float arrow_startTimeBtwAttack = 1f;


    private void ServiceArrowMode()
    {
        if(arrow_timeBtwAttack <= 0)
        {
            if(Input.GetKey(KeyCode.Q))
            {
                //SoundManager.PlaySound("arrow");
                GameObject a = Instantiate(arrowPrefab, attackPos.position + new Vector3(0, 1, 0), Quaternion.identity);
                a.transform.up = transform.right;
                a.GetComponent<Rigidbody2D>().velocity = transform.right * 20;
                arrow_timeBtwAttack = arrow_startTimeBtwAttack;
            }
        }
        else
        {
            arrow_timeBtwAttack -= Time.deltaTime;
        }
    }
}
