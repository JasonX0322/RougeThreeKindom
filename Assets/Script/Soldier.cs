using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    /*
     *
     */
    void Start()
    {
        
    }

    public enum SoldierType
    {
        Soldier1,
        Soldier2
    }

    public void Init(SoldierType myType)
    {
        switch(myType)
        {
            case SoldierType.Soldier1:
                break;
            case SoldierType.Soldier2:
                break;
        }
    }

}
