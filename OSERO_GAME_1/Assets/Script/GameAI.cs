using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAI : MonoBehaviour
{
    Turn T;
    GaidPoint GP;
    CoinClass[,] Coin;
    ChangeCoin CC;
    SpecialCoinB SCB;
    private bool[,] point;
    private int X, Y;//コインを打つマス
    private bool sw;

    void Start()
    {
        Coin = this.GetComponent<CcreateCoin>().Coin;
        T = this.GetComponent<Turn>();
        GP = this.GetComponent<GaidPoint>();
        CC = this.GetComponent<ChangeCoin>();
        point = this.GetComponent<GaidPoint>().point;
        SCB = GameObject.Find("Button").GetComponent<SpecialCoinB>();
        sw = false;
    }

    public void MainAI()//必ず最後に呼び出すこと　ガイドの処理が終わってからでないとバグる
    {
        X = -1;Y = -1;
        switch (PhaseJudgment())
        {
            case 1: EarlyStage(); break;//序盤用の処理呼び出し
            case 2: MidfieldStage(); break;//中盤用の処理呼び出し
            case 3: EndStage(); break;//終盤用の処理呼び出し
            default:Debug.LogError("序中終判断がおかしいです"); break;
        }
        ClickMousePos.Down = true;//疑似的にマウスを押したことにする
        ClickMousePos.posx = X;//Xに値を代入
        ClickMousePos.posy = Y;//Yに値を代入
    }

    int PhaseJudgment()//序盤、中盤、終盤なのかを判定
    {
        int C = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int l = 0; l < 8; l++)
            {
                if(Coin[i,l].GetSet() == true)//コインが設置されている
                {
                    C++;
                }
            }
        }
        if (C < 21)
        {
            return 1;
        }
        else if (C < 41)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }

    private void EarlyStage()//開放度理論...周りのマスが埋まっているほうが良い　終盤まで石はあまり返さない
    {
        int Evaluation = 100;
        int r;//評価値　低いほど良い
        for (int i = 0; i < 8; i++)
        {
            for (int l = 0; l < 8; l++)
            {
                if(Coin[i,l].GetGaid() == true)//設置可能マスである
                {
                    r = Coin[i, l].GetR() + Coin[i, l].GetSurrounding();//周囲の設置可能マスとそこに設置した際の返すコインの枚数　どちらも少ないとよい
                    if ((i < 2 && l < 2) || (i < 2 && l > 5) || (i > 5 && l < 2) || (i > 5 && l > 5)) r += 5;//四隅の周りの場合は評価を下げる
                    if ((i == 0 && l == 0) || (i == 0 && l == 7) || (i == 7 && l == 0) || (i == 7 && l == 7)) r -= 5;//4隅の場合は評価を上げる

                    if (Evaluation >= r)//既存の設定値より値が低い　＝　評価が高い場合
                    {
                        if (Evaluation == r)//評価値と設定値が同じ場合
                        {
                            if (RandomBool())
                            {
                                X = i; Y = l;//座標を設定
                                Evaluation = r;//設定値を評価が高い値にする
                            }
                        }
                        else
                        {
                            Evaluation = r;//設定値を評価が高い値にする
                            X = i; Y = l;//座標を設定
                        }
                    }


                }
            }
        }
    }//序盤の処理

    private void MidfieldStage()//開放度理論...周りのマスが埋まっているほうが良い　終盤まで石はあまり返さない
    {
        int Evaluation = 100;
        int r;//評価値　低いほど良い
        for (int i = 0; i < 8; i++)
        {
            for (int l = 0; l < 8; l++)
            {
                if (Coin[i, l].GetGaid() == true)//設置可能マスである
                {
                    r = Coin[i, l].GetR() + Coin[i, l].GetSurrounding();//周囲の設置可能マスとそこに設置した際の返すコインの枚数　どちらも少ないとよい
                    if ((i < 2 && l < 2) || (i < 2 && l > 5) || (i > 5 && l < 2) || (i > 5 && l > 5)) r += 5;//四隅の周りの場合は評価を下げる
                    if ((i == 0 && l == 0) || (i == 0 && l == 7) || (i == 7 && l == 0) || (i == 7 && l == 7)) r -= 5;//4隅の場合は評価を上げる
                    if ((i == 0) || (l == 7) || (i == 7) || (l == 0)) r += 2;//辺の場合は評価を少し下げる


                    if (Evaluation >= r)//既存の設定値より値が低い　＝　評価が高い場合
                    {
                        if (Evaluation == r)//評価値と設定値が同じ場合
                        {
                            if (RandomBool())
                            {
                                X = i; Y = l;//座標を設定
                                Evaluation = r;//設定値を評価が高い値にする
                            }
                        }
                        else
                        {
                            Evaluation = r;//設定値を評価が高い値にする
                            X = i; Y = l;//座標を設定
                        }
                    }
                }
            }
        }
        if ((X == 1 && Y == 1) || (X == 1 && Y == 6) || (X == 6 && Y == 1) || (X == 6 && Y == 6))//中編の場合
        {
            if (sw == false)
            {
                Coin[X, Y].ONSC();//特殊コインを設置
                sw = true;
            }
        }
    }//中盤の処理
    private void EndStage()
    {
        int Evaluation = 100;
        int r;//評価値　低いほど良い
        for (int i = 0; i < 8; i++)
        {
            for (int l = 0; l < 8; l++)
            {
                if (Coin[i, l].GetGaid() == true)//設置可能マスである
                {
                    r = Coin[i, l].GetR() - Coin[i, l].GetSurrounding();//周囲の設置可能マスとそこに設置した際の返すコインの枚数　どちらも少ないとよい
                    if ((i < 2 && l < 2) || (i < 2 && l > 5) || (i > 5 && l < 2) || (i > 5 && l > 5)) r += 5;//四隅の周りの場合は評価を下げる
                    if ((i == 0 && l == 0) || (i == 0 && l == 7) || (i == 7 && l == 0) || (i == 7 && l == 7)) r -= 5;//4隅の場合は評価を上げる
                    if ((i == 0) || (l == 7) || (i == 7) || (l == 0)) r += 2;//辺の場合は評価を少し下げる


                    if (Evaluation >= r)//既存の設定値より値が低い　＝　評価が高い場合
                    {
                        if (Evaluation == r)//評価値と設定値が同じ場合
                        {
                            if (RandomBool())
                            {
                                X = i; Y = l;//座標を設定
                                Evaluation = r;//設定値を評価が高い値にする
                            }
                        }
                        else
                        {
                            Evaluation = r;//設定値を評価が高い値にする
                            X = i; Y = l;//座標を設定
                        }
                    }
                }
            }
        }

    }

    public bool RandomBool()
    {
        return Random.Range(0, 2) == 0;
    }
}
