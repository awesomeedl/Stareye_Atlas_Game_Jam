using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    public Buff_Type buff;

    public enum Buff_Type
    {
        Arrow,
        Sword,
        Staff
    }
}
