using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMainManger : MonoBehaviour
{
    [SerializeField] GameObject Main;//キャンバスのメインを格納
    Turn T;
    CoinClass[,] Coin;
    // Update is called once per frame    
    void Start()
    {
        Coin = Main.GetComponent<CcreateCoin>().Coin;
        T = this.GetComponent<Turn>();

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
                    T.CS();
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
