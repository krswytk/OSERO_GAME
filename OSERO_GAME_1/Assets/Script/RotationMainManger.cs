//名前 PR利用了解しました。日付.2020/08/20 桐澤悠空

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
    GameAI GA;
    private bool[,] point;
    AudioSource audioSource;

    // Update is called once per frame    
    void Start()
    {
        Coin = this.GetComponent<CcreateCoin>().Coin;
        T = this.GetComponent<Turn>();
        GP = this.GetComponent<GaidPoint>();
        CC = this.GetComponent<ChangeCoin>();
        point = this.GetComponent<GaidPoint>().point;
        SCB = GameObject.Find("Button").GetComponent<SpecialCoinB>();
        GA = this.GetComponent<GameAI>();
        GP.Gaid(false);//初手のガイドを呼び出す
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Debug.Log("log0");
        if (ClickMousePos.Down == true)//クリックしたら
        {
            //Debug.Log("log1");
            try
            {
                //Debug.Log("log2");
                //Debug.Log(ClickMousePos.posx + "  " + ClickMousePos.posy);
                if (Coin[ClickMousePos.posx, ClickMousePos.posy].GetSet() == false)//コインがまだ置かれていない
                {
                    //Debug.Log("log3");
                    if (point[ClickMousePos.posx, ClickMousePos.posy] == true)//コインが設置可能マスである。（ガイドが表示されている）
                    {
                        //Debug.Log("log4");
                        Debug.Log("r = " + Coin[ClickMousePos.posx, ClickMousePos.posy].GetR());
                        Debug.Log("Surrounding = " + Coin[ClickMousePos.posx, ClickMousePos.posy].GetSurrounding());
                        if (SCB.GetSCSW())
                        {
                            Coin[ClickMousePos.posx, ClickMousePos.posy].ONSC();//特殊コインを設置
                            SCB.ONSW();//特殊コインを封印
                        }
                        //Debug.Log("log5");
                        Coin[ClickMousePos.posx, ClickMousePos.posy].SetCoin(T.turn);//コインを生成
                        audioSource.Play();
                        CC.Change(ClickMousePos.posx, ClickMousePos.posy);//コインをひっくり返す

                        T.CS();//この時点でターンが切り替わる
                        //Debug.Log("log6");
                        GP.Gaid(false);//ここでターンを呼べば次のターンが取れる　falseで白  //ついでに勝敗の判定も行っている
                        ClickMousePos.Down = false;
                        //Debug.Log("log7");
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

        ///*
        if(T.turn == false)//もし白のターンだったら
        {
            Debug.Log("\n----AI呼び出し----\n");
            GA.MainAI();//ゲームAIを呼び出す
        }
        //*/
    }
}
