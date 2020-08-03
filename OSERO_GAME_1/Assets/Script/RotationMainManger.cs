using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMainManger : MonoBehaviour
{
    Turn T;
    GaidPoint GP;
    CoinClass[,] Coin;
    // Update is called once per frame    
    void Start()
    {
        Coin = this.GetComponent<CcreateCoin>().Coin;
        T = this.GetComponent<Turn>();
        GP = this.GetComponent<GaidPoint>();
    }

    void Update()
    {
        if(ClickMousePos.Down == true)//クリックしたら
        {
            try
            {
                //Debug.Log(ClickMousePos.posx + "  " + ClickMousePos.posy);
                if (Coin[ClickMousePos.posx, ClickMousePos.posy].GetSet() == false)
                {
                    Coin[ClickMousePos.posx, ClickMousePos.posy].SetCoin(T.turn);
                    T.CS();//この時点でターンが切り替わる
                    GP.Gaid();//ここでターンを呼べば次のターンが取れる　falseで白
                    ClickMousePos.Down = false;
                }
                else
                {
                    Debug.Log("もう置いてあるよ！！");
                    ClickMousePos.Down = false;
                }
            }
            catch (System.NullReferenceException)
            {
                Debug.Log("そこは押せないよ！！");
                ClickMousePos.Down = false;
            }
        }
    }
}
