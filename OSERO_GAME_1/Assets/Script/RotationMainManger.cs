using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMainManger : MonoBehaviour
{
    Turn T;
    GaidPoint GP;
    CoinClass[,] Coin;
    ChangeCoin CC;
    SpecialCoinB SCB;
    Risalter R;
    private bool[,] point;

    // Update is called once per frame    
    void Start()
    {
        Coin = this.GetComponent<CcreateCoin>().Coin;
        T = this.GetComponent<Turn>();
        GP = this.GetComponent<GaidPoint>();
        CC = this.GetComponent<ChangeCoin>();
        point = this.GetComponent<GaidPoint>().point;
        R = this.GetComponent<Risalter>();
        SCB = GameObject.Find("Button").GetComponent<SpecialCoinB>();
        GP.Gaid();//初手のガイドを呼び出す
    }

    void Update()
    {
        if(ClickMousePos.Down == true)//クリックしたら
        {
            try
            {
                //Debug.Log(ClickMousePos.posx + "  " + ClickMousePos.posy);
                if (Coin[ClickMousePos.posx, ClickMousePos.posy].GetSet() == false)//コインがまだ置かれていない
                {
                    if (point[ClickMousePos.posx, ClickMousePos.posy] == true)//コインが設置可能マスである。（ガイドが表示されている）
                    {
                        if (SCB.GetSCSW())
                        {
                            Coin[ClickMousePos.posx, ClickMousePos.posy].ONSC();//特殊コインを設置
                            SCB.ONSW();//特殊コインを封印
                        }
                        Coin[ClickMousePos.posx, ClickMousePos.posy].SetCoin(T.turn);//コインを生成
                        CC.Change(ClickMousePos.posx, ClickMousePos.posy);//コインをひっくり返す

                        R.SetSharc();//ゲーム終了かどうかを判定　

                        T.CS();//この時点でターンが切り替わる
                        GP.Gaid();//ここでターンを呼べば次のターンが取れる　falseで白
                        ClickMousePos.Down = false;
                    }
                    else
                    {
                        Debug.Log("そこは置けないよ");
                        ClickMousePos.Down = false;
                    }
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
            catch (System.IndexOutOfRangeException)
            {
                Debug.Log("そこは押す場所じゃないよ！！");
                ClickMousePos.Down = false;
            }
        }
    }
}
