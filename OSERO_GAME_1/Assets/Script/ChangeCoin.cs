using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCoin : MonoBehaviour
{
    Turn T;
    CoinClass[,] Coin;
    private bool[,] poin;
    private bool G;
    // Start is called before the first frame update
    void Start()
    {
        Coin = this.GetComponent<CcreateCoin>().Coin;
        T = this.GetComponent<Turn>();
        poin = this.GetComponent<GaidPoint>().point;
        
    }

    public void Change(int x,int y)
    {
        G = false;//上
        for (int lp = 1; lp < 8; lp++)
        {
            try
            {
                if (Coin[x, y + lp].GetSet() == true && Coin[x, y + lp].GetFAB() != T.turn)//コインがある かつ　今とは反対の色である
                {
                    G = true;//他のコインがある
                }
                else if (Coin[x, y + lp].GetSet() == true && Coin[x, y + lp].GetFAB() == T.turn)//コインがある かつ　今と同じ色である
                {
                    if (G == true)//他のコインがあり、その先に自分のコインが先にあった
                    {
                        //先コインから設置コインまでをひっくり返す
                        for (int d = 1; d < lp; d++)
                        {
                            Coin[x, y + d].C();
                        }
                        break;
                    }
                    break;
                }
                else//コインがない
                {
                    break;//何もないならとっととブレイク
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                break;
            }
        }
        G = false;//右上
        for (int lp = 1; lp < 8; lp++)
        {
            try
            {
                if (Coin[x + lp, y + lp].GetSet() == true && Coin[x + lp, y + lp].GetFAB() != T.turn)//コインがある かつ　今とは反対の色である
                {
                    G = true;//他のコインがある
                }
                else if (Coin[x + lp, y + lp].GetSet() == true && Coin[x + lp, y + lp].GetFAB() == T.turn)//コインがある かつ　今と同じ色である
                {
                    if (G == true)//他のコインがあったら自分のコインが先にあった
                    {
                        //先コインから設置コインまでをひっくり返す
                        for (int d = 1; d < lp; d++)
                        {
                            Coin[x + d, y + d].C();
                        }
                        break;
                    }
                    break;
                }
                else//コインがない
                {
                    break;//何もないならとっととブレイク
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                break;
            }
        }
        G = false;//右
        for (int lp = 1; lp < 8; lp++)
        {
            try
            {
                if (Coin[x + lp, y].GetSet() == true && Coin[x + lp, y].GetFAB() != T.turn)//コインがある かつ　今とは反対の色である
                {
                    G = true;//他のコインがある
                }
                else if (Coin[x + lp, y].GetSet() == true && Coin[x + lp, y].GetFAB() == T.turn)//コインがある かつ　今と同じ色である
                {
                    if (G == true)//他のコインがあったら自分のコインが先にあった
                    {
                        //先コインから設置コインまでをひっくり返す
                        for (int d = 1; d < lp; d++)
                        {
                            Coin[x + d, y].C();
                        }
                        break;
                    }
                    break;
                }
                else//コインがない
                {
                    break;//何もないならとっととブレイク
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                break;
            }
        }
        G = false;//右下
        for (int lp = 1; lp < 8; lp++)
        {
            try
            {
                if (Coin[x + lp, y - lp].GetSet() == true && Coin[x + lp, y - lp].GetFAB() != T.turn)//コインがある かつ　今とは反対の色である
                {
                    G = true;//他のコインがある
                }
                else if (Coin[x + lp, y - lp].GetSet() == true && Coin[x + lp, y - lp].GetFAB() == T.turn)//コインがある かつ　今と同じ色である
                {
                    if (G == true)//他のコインがあったら自分のコインが先にあった
                    {
                        //先コインから設置コインまでをひっくり返す
                        for (int d = 1; d < lp; d++)
                        {
                            Coin[x + d, y - d].C();
                        }
                        break;
                    }
                    break;
                }
                else//コインがない
                {
                    break;//何もないならとっととブレイク
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                break;
            }
        }
        G = false;//下
        for (int lp = 1; lp < 8; lp++)
        {
            try
            {
                if (Coin[x, y - lp].GetSet() == true && Coin[x, y - lp].GetFAB() != T.turn)//コインがある かつ　今とは反対の色である
                {
                    G = true;//他のコインがある
                }
                else if (Coin[x, y - lp].GetSet() == true && Coin[x, y - lp].GetFAB() == T.turn)//コインがある かつ　今と同じ色である
                {
                    if (G == true)//他のコインがあったら自分のコインが先にあった
                    {
                        //先コインから設置コインまでをひっくり返す
                        for (int d = 1; d < lp; d++)
                        {
                            Coin[x, y - d].C();
                        }
                        break;
                    }
                    break;
                }
                else//コインがない
                {
                    break;//何もないならとっととブレイク
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                break;
            }
        }
        G = false;//左下
        for (int lp = 1; lp < 8; lp++)
        {
            try
            {
                if (Coin[x - lp, y - lp].GetSet() == true && Coin[x - lp, y - lp].GetFAB() != T.turn)//コインがある かつ　今とは反対の色である
                {
                    G = true;//他のコインがある
                }
                else if (Coin[x - lp, y - lp].GetSet() == true && Coin[x - lp, y - lp].GetFAB() == T.turn)//コインがある かつ　今と同じ色である
                {
                    if (G == true)//他のコインがあったら自分のコインが先にあった
                    {
                        //先コインから設置コインまでをひっくり返す
                        for (int d = 1; d < lp; d++)
                        {
                            Coin[x - d, y - d].C();
                        }
                        break;
                    }
                    break;
                }
                else//コインがない
                {
                    break;//何もないならとっととブレイク
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                break;
            }
        }
        G = false;//左
        for (int lp = 1; lp < 8; lp++)
        {
            try
            {
                if (Coin[x - lp, y].GetSet() == true && Coin[x - lp, y].GetFAB() != T.turn)//コインがある かつ　今とは反対の色である
                {
                    G = true;//他のコインがある
                }
                else if (Coin[x - lp, y].GetSet() == true && Coin[x - lp, y].GetFAB() == T.turn)//コインがある かつ　今と同じ色である
                {
                    if (G == true)//他のコインがあったら自分のコインが先にあった
                    {
                        //先コインから設置コインまでをひっくり返す
                        for (int d = 1; d < lp; d++)
                        {
                            Coin[x - d, y].C();
                        }
                        break;
                    }
                    break;
                }
                else//コインがない
                {
                    break;//何もないならとっととブレイク
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                break;
            }
        }
        G = false;//左上
        for (int lp = 1; lp < 8; lp++)
        {
            try
            {
                if (Coin[x - lp, y + lp].GetSet() == true && Coin[x - lp, y + lp].GetFAB() != T.turn)//コインがある かつ　今とは反対の色である
                {
                    G = true;//他のコインがある
                }
                else if (Coin[x - lp, y + lp].GetSet() == true && Coin[x - lp, y + lp].GetFAB() == T.turn)//コインがある かつ　今と同じ色である
                {
                    if (G == true)//他のコインがあったら自分のコインが先にあった
                    {
                        //先コインから設置コインまでをひっくり返す
                        for (int d = 1; d < lp; d++)
                        {
                            Coin[x - d, y + d].C();
                        }
                        break;
                    }
                    break;
                }
                else//コインがない
                {
                    break;//何もないならとっととブレイク
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                break;
            }
        }
    }
}
