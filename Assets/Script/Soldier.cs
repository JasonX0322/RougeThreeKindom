using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soldier : MonoBehaviour
{
    /*
     *
     */
    SoldierType myType;
    public int attack;
    public int health;
    ConfigIni ini;
    void Start()
    {
        ini = new ConfigIni("Soldier");
    }

    public enum SoldierType
    {
        Soldier1,
        Soldier2
    }

    public void RandomInit()
    {
        CardType[] types = Enum.GetValues(typeof(CardType)) as CardType[];
        myType = types[UnityEngine.Random.Range(1, 5)];
    }

    public void Init(SoldierType Type)
    {
        this.transform.localScale = new Vector3(1, 1, 1);
        myType = Type;
        Debug.Log(Type);
        this.GetComponent<Image>().sprite = (Sprite)Resources.Load(Type.ToString() + ".png");
        attack = int.Parse(ini.ReadIniContent(Type.ToString(), "Attack"));
        health = int.Parse(ini.ReadIniContent(Type.ToString(), "Health"));
    }

}
