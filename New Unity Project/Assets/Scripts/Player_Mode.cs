using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player_Mode : MonoBehaviour
{
    [Header("Shared Variables")]
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
            //Debug.Log("E pressed");
            DropCurrentBuff();
            PickUpBuff();
        }
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

    private void PickUpBuff()
    {
        
        Collider2D buff = Physics2D.OverlapCircle(transform.position, 1, whatIsChild);
        if(buff != null)
        {
            switch(buff.GetComponent<Child>().buff)
            {
                case Child.Buff_Type.Arrow:
                    attackMode = AttackMode.Arrow;
                    weaponSprite.sprite = bow_sprite;
                    GetComponent<SpriteRenderer>().color = Color.green;
                    break;
                case Child.Buff_Type.Sword:
                    attackMode = AttackMode.Sword;
                    weaponSprite.sprite = sword_sprite;
                    GetComponent<SpriteRenderer>().color = Color.red;
                    break;
                case Child.Buff_Type.Staff:
                    attackMode = AttackMode.Staff;
                    //weaponSprite.sprite = staff_sprite;
                    break;
            }
            buff.gameObject.transform.parent = gameObject.transform;
            buff.gameObject.transform.localPosition = new Vector3(0, 1, 0);
            buff.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            DropCurrentBuff();
            currentBuff = buff.gameObject;
        }
        else
        {
            DropCurrentBuff();
        }
    }

    private void DropCurrentBuff()
    {
        if(currentBuff != null)
        {
            currentBuff.transform.parent = null;
            currentBuff.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

}
