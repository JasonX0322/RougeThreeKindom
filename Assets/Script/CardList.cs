using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardList : MonoBehaviour
{
    /*
     *
     */
    [Header("卡牌数")]
    public int CardNum;
    [Header("第几关")]
    public int ListLevel;

    GameManage gm;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManage>();
    }

    public void Init()
    {
        if (ListLevel % 10 != 0)
            RandomCardNum();
        else
            BossLevel();

    }

    void RandomCardNum()
    {
        CardNum = Random.Range(4, 5);
        for(int i=0;i!=5-CardNum;i++)
        {
            int rint;
            rint = Random.Range(0, 4);
            this.transform.GetChild(rint).GetComponent<Card>().SetAsEmpty();
        }
    }

    void BossLevel()
    {
        this.transform.GetChild(0).GetComponent<Card>().SetAsEmpty();
        this.transform.GetChild(1).GetComponent<Card>().SetAsEmpty();
        this.transform.GetChild(3).GetComponent<Card>().SetAsEmpty();
        this.transform.GetChild(4).GetComponent<Card>().SetAsEmpty();
    }


    public void ListDisable()
    {
        foreach(Toggle t in this.GetComponentsInChildren<Toggle>())
        {
            t.enabled = false;
        }
    }
    public void ListEnable()
    {
        int myPos = gm.PosNow;
        bool LoseA = false;
        bool LoseB = false;
        bool LoseC = false;
        switch(myPos)
        {
            case 0:
                LoseA = true;
                LoseB = CardEnable(0);
                LoseC = CardEnable(1);
                break;
            case 1:
                LoseA = CardEnable(0);
                LoseB = CardEnable(1);
                LoseC = CardEnable(2);
                break;
            case 2:
                LoseA = CardEnable(1);
                LoseB = CardEnable(2);
                LoseC = CardEnable(3);
                break;
            case 3:
                LoseA = CardEnable(2);
                LoseB = CardEnable(3);
                LoseC = CardEnable(4);
                break;
            case 4:
                LoseA = CardEnable(3);
                LoseB = CardEnable(4);
                LoseC = true;
                break;
        }
        if(LoseA&&LoseB&&LoseC)
        {
            gm.Lose(GameManage.LoseCondition.NoWayToGo);
        }
    }

    bool CardEnable(int i)
    {
        if (this.transform.GetChild(i).GetComponent<Card>().myType != Card.CardType.Empty)
        {
            this.transform.GetChild(i).GetComponent<Toggle>().enabled = true;
            return false;
        }
        else
        {
            return true;
        }
    }
}
