﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CcreateCoin : MonoBehaviour//初期の設定　すべてのマスに透明なコインを配置する
{
    [SerializeField] Sprite BlackImage;//●画像を格納
    [SerializeField] Sprite WhiteImage;//○画像を格納
    [SerializeField] GameObject CoinPrefab;//生成するコインのプレハブ

    public CoinClass[,] Coin;
    // Start is called before the first frame update
    void Awake()
    {
        Coin = new CoinClass[8, 8];

        for (int i = 0; i < 8; i++)
        {
            for (int l = 0; l < 8; l++)
            {
                GameObject c = Instantiate(CoinPrefab, transform.position, transform.rotation, this.transform);//コインを生成
                c.transform.localPosition = new Vector2(i * 110, l * 110);//コインの座標を変更
                c.name = "COIN[" + i + "][" + l + "]";//コインの名前変更
                Coin[i, l] = new CoinClass(c, BlackImage, WhiteImage);
            }
        }
    }

}

public class CoinClass
{
    //基本素材格納
    private Image CSP;//sprit変更用に格納
    private Sprite BI;//●画像を格納
    private Sprite WI;//○画像を格納

    //コインの状態格納
    private bool Set;//コインがあるかどうかの判定
    private bool FAB;//コインが黒か白の判定　黒ならtrue
    private bool SC;//特殊コインの判定　trueならコインが変わらなくなる

    public CoinClass(GameObject c,Sprite BI, Sprite WI)
    {
        CSP = c.GetComponent<Image>();
        this.BI = BI;
        this.WI = WI;
        this.Set = false;
        SC = false;
    }

    private void SB()
    {
        CSP.sprite = BI;
        FAB = true;
    }
    private void SW()
    {
        CSP.sprite = WI;
        FAB = false;
    }


    public void SetCoin(bool t)//何もまだ設置されていなければ、引数に応じたコインが表示される。
    {
        if(Set == false)
        {
            if( t == true)
            {
                SB();
            }
            else
            {
                SW();
            }

            Set = true;
        }
    }

    public void C()//何もまだ設置されていなければ、引数に応じたコインが表示される。
    {
        if (SC == false)//特殊コインでなければ
        {
            if (Set == true)
            {
                if (FAB == true)//黒なら白にする
                {
                    SW();
                }
                else
                {
                    SB();
                }
            }
        }
    }
    public void ONSC()//使用されたら特殊コインがオンになり、表裏が変化しなくなる
    {
        SC = true;
    }
    public bool GetFAB()//現在黒か白かのGetr 黒ならtrue
    {
        return FAB;
    }
}
