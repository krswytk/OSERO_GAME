using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaidPoint : MonoBehaviour
{
    Turn T;
    CoinClass[,] Coin;
    private bool G;
    // Update is called o
    // Start is called before the first frame update
    void Start()
    {
        Coin = this.GetComponent<CcreateCoin>().Coin;
        T = this.GetComponent<Turn>();
    }

    public void Gaid()
    {
        Debug.Log(T.turn);
        for(int i = 0; i < 8; i++)
        {
            for (int l = 0; l < 8; l++)
            {
                if (Coin[i, l].GetSet() == false)//コインが設置されていなければ //共通使用可能？
                {
                    Coin[i, l].Clear();//コインが設置されていなければクリアを行う

                    //上下左右判定
                    //上から
                    G = false;
                    for (int lp = 1; lp < 8; lp++)
                    {
                        try
                        {
                            if (Coin[i, l + lp].GetSet() == true && Coin[i, l + lp].GetFAB() != T.turn){//コインがある かつ　今とは反対の色である
                                G = true;//ガイド設置条件を満たしている
                            }
                            else if (Coin[i, l + lp].GetSet() == true && Coin[i, l + lp].GetFAB() == T.turn){//コインがある かつ　今と同じ色である
                                if(G == true)//もしガイド設置条件を満たしているなら
                                {
                                    Coin[i, l].SetGaid();//ガイドを設置する
                                    break;
                                }
                            }
                            else break;//何もないならとっととブレイク
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            Debug.Log("そこはお外ですよ " + " i = " + i + "  l = " + l);
                            break;
                        }
                    }
                }
            }
        }
    }
}