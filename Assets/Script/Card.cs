using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Card : MonoBehaviour
{
    /*
     *卡片
     */

    public Sprite CardBack;
    public Sprite CardFront;
    public int cardPos;
    GameObject gmgo;
    GameManage gm;

    Image myImg;
    void Start()
    {
        gmgo = GameObject.Find("GameManager");
        gm = gmgo.GetComponent<GameManage>();
        myImg = this.GetComponent<Image>();
        myImg.sprite = CardBack;
    }

    public void Choose()
    {
        gm.PosNow = cardPos;
        this.GetComponentInParent<CardList>().ListDisable();
        this.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.5f).SetEase(Ease.Linear).OnComplete(() => 
        {
            myImg.sprite = CardFront;
            this.transform.DOLocalRotate(new Vector3(0, 180, 0), 0.5f).SetEase(Ease.Linear).OnComplete
                (() =>this.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1, 1).OnComplete
                (() => gm.Pass()));
        });
    }
}
