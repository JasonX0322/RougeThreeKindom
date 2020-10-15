using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManage : MonoBehaviour
{
    /*
     * void pass 下一列卡牌
     * enum LoseCondition 失败情况
     * void Lose 显示失败
     */
    public GameObject cardList;
    public GameObject canvas;

    public List<GameObject> cards = new List<GameObject>();

    int LevelNow;
    public int PosNow;

    [Header("士兵列表")]
    public List<Soldier> mySoldier = new List<Soldier>();
    [Header("将军列表")]
    public List<General> myGeneral = new List<General>();

    public Soldier PrefabSolider;

    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        GenerateLists(5);
        LevelNow = 0;
    }

    void GenerateLists(int num)
    {
        for(int i=0;i!=num;i++)
        {
            GameObject temp = Instantiate(cardList);
            temp.GetComponent<CardList>().ListLevel = i;
            temp.GetComponent<CardList>().Init();
            temp.transform.SetParent(canvas.transform);
            temp.transform.localPosition = new Vector3(0, -250 + i * 100, 0);
            temp.transform.localScale = new Vector3(1, 1, 1);
            temp.name = "CardList" + i.ToString();
            cards.Add(temp);
        }
        for (int i = num - 1; i >= 0; i--)
        {
            canvas.transform.GetChild(i).transform.SetAsLastSibling();
        }
        cards[0].transform.GetChild(2).GetComponent<Toggle>().enabled = true;
    }

    void AddList()
    {
        GameObject temp = Instantiate(cardList);
        temp.GetComponent<CardList>().ListLevel = LevelNow + 4;
        temp.GetComponent<CardList>().Init();
        temp.transform.SetParent(canvas.transform);
        temp.transform.localPosition = new Vector3(0, 150, 0);
        temp.transform.localScale = new Vector3(1, 1, 1);
        temp.name = "CardList" + (LevelNow + 4).ToString();
        cards.Add(temp);
        temp.transform.SetAsFirstSibling();
    }

    void DeleteList()
    {
        foreach (Image temp in cards[0].GetComponentsInChildren<Image>())
        {
            temp.DOFade(0, 1).OnComplete(() => { DestoryPassedCard(temp.name); });
            temp.raycastTarget = false;
        }
    }
    public void Pass()
    {
        LevelNow++;
        foreach(CardList t in canvas.GetComponentsInChildren<CardList>())
        {
            t.gameObject.transform.DOLocalMoveY(t.gameObject.transform.localPosition.y - 100, 1);
        }
        cards[1].GetComponent<CardList>().ListEnable();
        AddList();
        DeleteList();
    }

    void DestoryPassedCard(string str)
    {
        if (str == "Card0")
        {
            Destroy(cards[0]);
            cards.RemoveAt(0);
        }
    }
    public enum LoseCondition
    {
        NoWayToGo
    }
    public void Lose(LoseCondition lc)
    {
        switch(lc)
        {
            case LoseCondition.NoWayToGo:
                Debug.Log("此处，就是落凤坡吗");
                break;
        }
    }

    public void AddSoldier(Soldier.SoldierType st)
    {
        Soldier s = GameObject.Instantiate(PrefabSolider);
        PrefabSolider.Init(st);
        mySoldier.Add(s);
    }
}
