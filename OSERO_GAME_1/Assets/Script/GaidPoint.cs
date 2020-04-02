using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaidPoint : MonoBehaviour
{
    public static GameObject[,] COIN = IventManeger.COIN;//[横0-7,縦0-7]右下[0,0]左上[7,7]それ以外[-1,-1]
    private bool turn = Turn.turn;


    private int[,] cp = new int[8, 8];//各マスの状態を管理するint型2次元配列
    
    // Start is called before the first frame update
    void Start()
    {
        for (int lp = 0; lp < 8; lp++)
        {
            for (int kp = 0; kp < 8; kp++)
            {
                cp[lp, kp] = 0;//初期値0を代入
            }
        }
    }

    void Update()
    {
        if(ClickMousePos.Down == true){
            Gaid();
        }    
    }


    void Gaid()
    {
        if(turn == true)//黒の時の処理
        {
            for (int lp = 0; lp < 8; lp++)
            {
                for (int kp = 0; kp < 8; kp++)
                {
                    if(COIN[lp, kp] = null)
                    {

                        if (lp - 1 >= 0 && kp + 1 < 8)
                        {
                            if (COIN[lp - 1, kp + 1] != null) cp[lp, kp] += 1;   //左上                   +1
                        }

                        if ( kp + 1 < 8)
                        {
                            if (COIN[lp, kp + 1] != null) cp[lp, kp] += 10;       //上                   +10
                        }

                        if (lp + 1 < 8 && kp + 1 < 8)
                        {
                            if (COIN[lp + 1, kp + 1] != null) cp[lp, kp] =+ 100;   //右上                    +100
                        }

                        if (lp - 1 >= 0 )
                        {
                            if (COIN[lp - 1, kp] != null) cp[lp, kp] =+ 1000;       //左                         +1000
                        }

                        if (lp + 1 < 8 )
                        {
                            if (COIN[lp + 1, kp] != null) cp[lp, kp] =+ 10000;       //右                         +10000
                        }

                        if (lp - 1 >= 0 && kp - 1 >= 0)
                        {
                            if (COIN[lp - 1, kp - 1] != null) cp[lp, kp] =+ 100000;   //左下                      +100000
                        }

                        if (kp - 1 >= 0)
                        {
                            if (COIN[lp - 1, kp - 1] != null) cp[lp, kp] =+ 1000000;   //下                           +1000000
                        }

                        if (lp + 1 < 8 && kp - 1 >= 0)
                        {
                            if (COIN[lp + 1, kp - 1] != null) cp[lp, kp] =+ 10000000;   //右下                        +10000000
                        }


                        Debug.Log("COIN[" + lp + "," + kp + "] = " + cp[lp,kp] );








                    }
                }
            }
        }

        if (turn == false)//白の時の処理
        {

        }
    }
}
