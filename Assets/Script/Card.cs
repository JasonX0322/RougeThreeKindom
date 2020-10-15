using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class Card : MonoBehaviour
{
    /*
     *卡片
     */

    public Sprite CardBack;
    public Sprite CardFront;
    public int cardPos;
    public Sprite CardEmpty;
    GameObject gmgo;
    GameManage gm;

    Image myImg;

    public CardType myType = CardType.Soldier;

    public enum CardType
    {
        Empty,
        Soldier,
        Leader,
        Enemy,
        Boss,
        City
    }


    void Awake()
    {
        gmgo = GameObject.Find("GameManager");
        gm = gmgo.GetComponent<GameManage>();
        myImg = this.GetComponent<Image>();
        if (myType != CardType.Empty)
            myImg.sprite = CardBack;
    }

    public void Choose()
    {
        gm.PosNow = cardPos;
        this.GetComponentInParent<CardList>().ListDisable();
        this.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.5f).SetEase(Ease.Linear).OnComplete(() => 
        {
            myImg.sprite = CardFront;
            this.transform.DOLocalRotate(new Vector3(0, 180, 0), 0.5f).SetEase(Ease.Linear).OnComplete(() =>
                this.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1, 1).OnComplete(() =>
                SwitchCardType()));
        });
    }

    public void SetAsEmpty()
    {
        myType = CardType.Empty;
        this.GetComponent<Toggle>().enabled = false;
        this.GetComponent<Image>().sprite = CardEmpty;
    }

    void SwitchCardType()
    {
        switch(myType)
        {
            case CardType.Soldier:
                gm.AddSoldier(Soldier.SoldierType.Soldier1);
                gm.Pass();
                break;
            case CardType.Leader:
                gm.Pass();
                break;
            case CardType.Enemy:
                gm.Pass();
                break;
            case CardType.Boss:
                gm.Pass();
                break;
            case CardType.City:
                gm.Pass();
                break;
        }
    }

    void GenerateMyType()
    {
        CardType[] types = Enum.GetValues(typeof(CardType)) as CardType[];
        myType = types[UnityEngine.Random.Range(1, 5)];
    }
}
