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
        CardNum = Random.Range(2, 3);
        for(int i=0;i!=3-CardNum;i++)
        {
            int rint;
            rint = Random.Range(0, 2);
            if (this.transform.GetChild(rint).gameObject.activeSelf)
                this.transform.GetChild(rint).gameObject.SetActive(false);
            else
                i--;
        }
        int t = 0;
        for(int i=0;i!=3;i++)
        {
            if (this.transform.GetChild(i).gameObject.activeSelf)
            {
                this.transform.GetChild(i).name = "Card" + t.ToString();
                t++;
            }
        }
    }

    void BossLevel()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(2).gameObject.SetActive(false);
        this.transform.GetChild(1).name = "Card0";
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
        switch(myPos)
        {
            case 0:
                this.transform.GetChild(0).GetComponent<Toggle>().enabled = true;
                this.transform.GetChild(1).GetComponent<Toggle>().enabled = true;
                break;
            case 1:
                this.transform.GetChild(0).GetComponent<Toggle>().enabled = true;
                this.transform.GetChild(1).GetComponent<Toggle>().enabled = true;
                this.transform.GetChild(2).GetComponent<Toggle>().enabled = true;
                break;
            case 2:
                this.transform.GetChild(1).GetComponent<Toggle>().enabled = true;
                this.transform.GetChild(2).GetComponent<Toggle>().enabled = true;
                this.transform.GetChild(3).GetComponent<Toggle>().enabled = true;
                break;
            case 3:
                this.transform.GetChild(2).GetComponent<Toggle>().enabled = true;
                this.transform.GetChild(3).GetComponent<Toggle>().enabled = true;
                this.transform.GetChild(4).GetComponent<Toggle>().enabled = true;
                break;
            case 4:
                this.transform.GetChild(3).GetComponent<Toggle>().enabled = true;
                this.transform.GetChild(4).GetComponent<Toggle>().enabled = true;
                break;
        }
    }
}
