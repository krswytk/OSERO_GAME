﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Risalter : MonoBehaviour
{
    [SerializeField] GameObject Gameset;
    [SerializeField] GameObject BSTR;
    [SerializeField] GameObject WSTR;
    [SerializeField] GameObject BC;
    [SerializeField] GameObject WC;
    CoinClass[,] Coin;

    Text B,W;
    int b, w;

    private void Start()
    {
        Coin = this.GetComponent<CcreateCoin>().Coin;
        Gameset.SetActive(false);
        BSTR.SetActive(false);
        WSTR.SetActive(false);
        B = BC.GetComponent<Text>();
        W = WC.GetComponent<Text>();

    }




    public void SetSharc()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int l = 0; l < 8; l++)
            {
                if (Coin[i,l].GetSet() == true) {//コインが設置されている


                }
                else
                {
                    return;//関数から抜ける
                }
            }
        }
        //ここまでくる＝すべて設置されている
        GameSet();//リザルト処理を行う
    }

    public void GameSet()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int l = 0; l < 8; l++)
            {
                if (Coin[i, l].GetFAB() == true)
                {
                    b++;//黒の枚数
                }
                else
                {
                    w++;//白の枚数
                }
            }
        }


        while (true)//処理を繰り返す　ロードシーンで強制的に抜け出す
        {

        }
    }
        
}
