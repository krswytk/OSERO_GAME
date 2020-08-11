using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaidPoint : MonoBehaviour
{
    Turn T;
    CoinClass[,] Coin;
    public bool[,] point;
    private bool G;
    private bool pass;
    Risalter R;
    int r;
    int Surrounding;
    // Update is called o
    // Start is called before the first frame update
    void Start()
    {
        Coin = this.GetComponent<CcreateCoin>().Coin;
        T = this.GetComponent<Turn>();
        point = new bool[8, 8];
        R = this.GetComponent<Risalter>();
        //RisetPoint();
        //Debug.Log(Coin[1, 1].GetSet());
    }

    public void Gaid(bool p)//この中でのみ配列参照が出来ていない
    {
        RisetPoint();
        pass = true;
        //Debug.Log(T.turn);
        for (int i = 0; i < 8; i++)
        {
            for (int l = 0; l < 8; l++)
            {
                r = 0;//めくれるコインの枚数
                Surrounding = 0;//周囲にあるコインの枚数
                if (Coin[i, l].GetSet() == false)//コインが設置されていなければ
                {
                    Coin[i, l].Clear();//コインが設置されていなければクリアを行う
                    
                    //12時方向から時計回りに
                    G = false;//上
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
                                    point[i, l] = true;//ガイド座標をtrueに
                                    pass = false;
                                    r += (lp- 1);
                                    break;
                                }
                                break;
                            }
                            else break;//何もないならとっととブレイク
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            //Debug.Log("そこはお外ですよ");
                            break;
                        }
                    }
                    G = false;//右上
                    for (int lp = 1; lp < 8; lp++)
                    {
                        try
                        {
                            if (Coin[i + lp, l + lp].GetSet() == true && Coin[i + lp, l + lp].GetFAB() != T.turn)
                            {//コインがある かつ　今とは反対の色である
                                G = true;//ガイド設置条件を満たしている
                            }
                            else if (Coin[i + lp, l + lp].GetSet() == true && Coin[i + lp, l + lp].GetFAB() == T.turn)
                            {//コインがある かつ　今と同じ色である
                                if (G == true)//もしガイド設置条件を満たしているなら
                                {
                                    Coin[i, l].SetGaid();//ガイドを設置する
                                    point[i, l] = true;//ガイド座標をtrueに
                                    pass = false;
                                    r += (lp - 1);
                                    break;
                                }
                                break;
                            }
                            else break;//何もないならとっととブレイク
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            //Debug.Log("そこはお外ですよ");
                            break;
                        }
                    }
                    G = false;//右
                    for (int lp = 1; lp < 8; lp++)
                    {
                        try
                        {
                            if (Coin[i + lp, l].GetSet() == true && Coin[i + lp, l].GetFAB() != T.turn)
                            {//コインがある かつ　今とは反対の色である
                                G = true;//ガイド設置条件を満たしている
                            }
                            else if (Coin[i + lp, l].GetSet() == true && Coin[i + lp, l].GetFAB() == T.turn)
                            {//コインがある かつ　今と同じ色である
                                if (G == true)//もしガイド設置条件を満たしているなら
                                {
                                    Coin[i, l].SetGaid();//ガイドを設置する
                                    point[i, l] = true;//ガイド座標をtrueに
                                    pass = false;
                                    r += (lp - 1);
                                    break;
                                }
                                break;
                            }
                            else break;//何もないならとっととブレイク
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            //Debug.Log("そこはお外ですよ");
                            break;
                        }
                    }
                    G = false;//右下
                    for (int lp = 1; lp < 8; lp++)
                    {
                        try
                        {
                            if (Coin[i + lp, l - lp].GetSet() == true && Coin[i + lp, l - lp].GetFAB() != T.turn)
                            {//コインがある かつ　今とは反対の色である
                                G = true;//ガイド設置条件を満たしている
                            }
                            else if (Coin[i + lp, l - lp].GetSet() == true && Coin[i + lp, l - lp].GetFAB() == T.turn)
                            {//コインがある かつ　今と同じ色である
                                if (G == true)//もしガイド設置条件を満たしているなら
                                {
                                    Coin[i, l].SetGaid();//ガイドを設置する
                                    point[i, l] = true;//ガイド座標をtrueに
                                    pass = false;
                                    r += (lp - 1);
                                    break;
                                }
                                break;
                            }
                            else break;//何もないならとっととブレイク
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            //Debug.Log("そこはお外ですよ");
                            break;
                        }
                    }
                    G = false;//下
                    for (int lp = 1; lp < 8; lp++)
                    {
                        try
                        {
                            if (Coin[i, l - lp].GetSet() == true && Coin[i, l - lp].GetFAB() != T.turn)
                            {//コインがある かつ　今とは反対の色である
                                G = true;//ガイド設置条件を満たしている
                            }
                            else if (Coin[i, l - lp].GetSet() == true && Coin[i, l - lp].GetFAB() == T.turn)
                            {//コインがある かつ　今と同じ色である
                                if (G == true)//もしガイド設置条件を満たしているなら
                                {
                                    Coin[i, l].SetGaid();//ガイドを設置する
                                    point[i, l] = true;//ガイド座標をtrueに
                                    pass = false;
                                    r += (lp - 1);
                                    break;
                                }
                                break;
                            }
                            else break;//何もないならとっととブレイク
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            //Debug.Log("そこはお外ですよ");
                            break;
                        }
                    }
                    G = false;//左下
                    for (int lp = 1; lp < 8; lp++)
                    {
                        try
                        {
                            if (Coin[i - lp, l - lp].GetSet() == true && Coin[i - lp, l - lp].GetFAB() != T.turn)
                            {//コインがある かつ　今とは反対の色である
                                G = true;//ガイド設置条件を満たしている
                            }
                            else if (Coin[i - lp, l - lp].GetSet() == true && Coin[i - lp, l - lp].GetFAB() == T.turn)
                            {//コインがある かつ　今と同じ色である
                                if (G == true)//もしガイド設置条件を満たしているなら
                                {
                                    Coin[i, l].SetGaid();//ガイドを設置する
                                    point[i, l] = true;//ガイド座標をtrueに
                                    pass = false;
                                    r += (lp - 1);
                                    break;
                                }
                                break;
                            }
                            else break;//何もないならとっととブレイク
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            //Debug.Log("そこはお外ですよ");
                            break;
                        }
                    }
                    G = false;//左
                    for (int lp = 1; lp < 8; lp++)
                    {
                        try
                        {
                            if (Coin[i - lp, l].GetSet() == true && Coin[i - lp, l].GetFAB() != T.turn)
                            {//コインがある かつ　今とは反対の色である
                                G = true;//ガイド設置条件を満たしている
                            }
                            else if (Coin[i - lp, l].GetSet() == true && Coin[i - lp, l].GetFAB() == T.turn)
                            {//コインがある かつ　今と同じ色である
                                if (G == true)//もしガイド設置条件を満たしているなら
                                {
                                    Coin[i, l].SetGaid();//ガイドを設置する
                                    point[i, l] = true;//ガイド座標をtrueに
                                    pass = false;
                                    r += (lp - 1);
                                    break;
                                }
                                break;
                            }
                            else break;//何もないならとっととブレイク
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            //Debug.Log("そこはお外ですよ");
                            break;
                        }
                    }
                    G = false;//左上
                    for (int lp = 1; lp < 8; lp++)
                    {
                        try
                        {
                            if (Coin[i - lp, l + lp].GetSet() == true && Coin[i - lp, l + lp].GetFAB() != T.turn)
                            {//コインがある かつ　今とは反対の色である
                                G = true;//ガイド設置条件を満たしている
                            }
                            else if (Coin[i - lp, l + lp].GetSet() == true && Coin[i - lp, l + lp].GetFAB() == T.turn)
                            {//コインがある かつ　今と同じ色である
                                if (G == true)//もしガイド設置条件を満たしているなら
                                {
                                    Coin[i, l].SetGaid();//ガイドを設置する
                                    point[i, l] = true;//ガイド座標をtrueに
                                    pass = false;
                                    r += (lp - 1);
                                    break;
                                }
                                break;
                            }
                            else break;//何もないならとっととブレイク
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            //Debug.Log("そこはお外ですよ");
                            break;
                        }
                    }
                }
                try
                {
                    if (Coin[i, l + 1].GetSet()) Surrounding++;
                    if (Coin[i + 1, l].GetSet()) Surrounding++;
                    if (Coin[i, l - 1].GetSet()) Surrounding++;
                    if (Coin[i - 1, l].GetSet()) Surrounding++;
                    if (Coin[i + 1, l + 1].GetSet()) Surrounding++;
                    if (Coin[i - 1, l - 1].GetSet()) Surrounding++;
                    if (Coin[i + 1, l - 1].GetSet()) Surrounding++;
                    if (Coin[i - 1, l + 1].GetSet()) Surrounding++;
                }
                catch (System.IndexOutOfRangeException)
                {
                }
                Coin[i, l].SetSurrounding(Surrounding);
                Coin[i, l].SetR(r);
            }
        }

        if(pass == true)//恐らく無限ループの元凶
        {
            if(p == true)//一回パスしてまたパスしていた場合　つまり置けるところが双方ない場合
            {
                R.GameSet();//リザルト処理を行う
                Debug.Log("どちらも設置できません");
                return;
            }
            Debug.Log("Passが発生しました");
            T.CS();
            Gaid(true);
        }
    }



    private void RisetPoint()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int l = 0; l < 8; l++)
            {
                try
                {
                    point[i, l] = false;
                }
                catch(System.NullReferenceException)
                {
                    //Debug.Log("Riseterror["+ i +","+ l+"]");
                }
            }
        }
    }
}