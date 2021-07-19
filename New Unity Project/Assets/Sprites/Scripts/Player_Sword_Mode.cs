using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player_Mode
{
    [Header("Sword")]
    public Sprite sword_sprite;
    float sword_timeBtwAttack = 0;
    float sword_startTimeBtwAttack = 0.3f;

    public float sword_attackRange;
    public Animator sword_animator;

    private void ServiceSwordMode()
    {
        if(sword_timeBtwAttack <= 0)
        {
            if(Input.GetKey(KeyCode.Q))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, sword_attackRange, whatIsEnemies);
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().Destruct();
                }

                sword_animator.SetTrigger("swing");
            
                sword_timeBtwAttack = sword_startTimeBtwAttack;
            }
        }
        else
        {
            sword_timeBtwAttack -= Time.deltaTime;
        }
    }
}
