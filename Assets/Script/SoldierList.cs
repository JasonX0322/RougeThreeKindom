using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierList : MonoBehaviour
{
    // Start is called before the first frame update
    GameManage gm;

    List<Soldier> mySoldierList;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSoldierList()
    {
        SoldierList = gm.mySoldier;
    }

    public void LastSoldierList()
    {

    }

    public void NextSoldierList()
    {

    }
}
