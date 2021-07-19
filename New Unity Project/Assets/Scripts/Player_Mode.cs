using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player_Mode : MonoBehaviour
{
    [Header("Shared Variables")]

    public Sprite[] sprites;
    public Transform attackPos;
    public SpriteRenderer weaponSprite;
    public LayerMask whatIsEnemies;
    public LayerMask whatIsChild;

    [SerializeField] GameObject currentBuff;
    
    // State machine
    [SerializeField] private AttackMode attackMode = AttackMode.Empty;
    private enum AttackMode
    {
        Empty,
        Arrow,
        Sword,
        Staff
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Collider2D[] buffAvailable = Physics2D.OverlapCircleAll(transform.position, 1, whatIsChild);

            if(buffAvailable.Length > 0 && currentBuff == null)
            {
                PickUpBuff(buffAvailable[0].gameObject);
            }
            else
            {
                if(buffAvailable.Length <= 1)
                {
                    DropCurrentBuff();
                }
                else
                {
                    foreach(var buff in buffAvailable)
                    {
                        if(buff.gameObject != currentBuff)
                        {
                            DropCurrentBuff();
                            PickUpBuff(buff.gameObject);
                            break;
                        }
                    }
                }
            }
        }
            //Debug.Log("E pressed");
        ServiceFSM();
    }

    void ServiceFSM()
    {
        switch(attackMode)
        {
            case AttackMode.Arrow:
                ServiceArrowMode();
                break;
            case AttackMode.Sword:
                ServiceSwordMode();
                break;
            case AttackMode.Staff:
                ServiceStaffMode();
                break;
            case AttackMode.Empty:
                break;
            default:
                break;
        }
    }

    private void ServiceStaffMode()
    {
        //throw new NotImplementedException();
    }

    private void PickUpBuff(GameObject buff)
    {
        switch(buff.GetComponent<Child>().buff)
        {
            case Child.Buff_Type.Arrow:
                attackMode = AttackMode.Arrow;
                weaponSprite.sprite = bow_sprite;
                GetComponent<SpriteRenderer>().sprite = sprites[1];
                break;
            case Child.Buff_Type.Sword:
                attackMode = AttackMode.Sword;
                weaponSprite.sprite = sword_sprite;
                GetComponent<SpriteRenderer>().sprite = sprites[2];
                break;
            case Child.Buff_Type.Staff:
                attackMode = AttackMode.Staff;
                //weaponSprite.sprite = staff_sprite;
                break;
        }
        buff.gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        buff.gameObject.transform.parent = gameObject.transform;
        buff.gameObject.transform.localPosition = new Vector3(0, 1, 0);
        buff.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        DropCurrentBuff();
        currentBuff = buff.gameObject;
    }

    private void DropCurrentBuff()
    {
        if(currentBuff != null)
        {
            currentBuff.GetComponent<SpriteRenderer>().color = Color.white;
            currentBuff.transform.parent = null;
            currentBuff.GetComponent<Rigidbody2D>().isKinematic = false;
            currentBuff = null;

            attackMode = AttackMode.Empty;
            weaponSprite.sprite = null;
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1);
    }

}
