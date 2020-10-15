using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    /*
     *
     */
    SoldierType myType;
    void Start()
    {
        
    }

    public enum SoldierType
    {
        Soldier1,
        Soldier2
    }

    public void Init(SoldierType Type)
    {
        myType = Type;
    }

}
