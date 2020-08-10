using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartCoin : MonoBehaviour
{
    CoinClass[,] Coin;
    // Start is called before the first frame update
    void Start()
    {
        CoinClass[,] Coin = this.GetComponent<CcreateCoin>().Coin;
        ///*
        Coin[3, 3].SetCoin(true);
        Coin[4, 4].SetCoin(true);
        Coin[3, 4].SetCoin(false);
        Coin[4, 3].SetCoin(false);
        //*/

        //リザルトデバック用
        /*
        for (int i = 0; i < 7; i++)
        {
            for (int l = 0; l < 7; l++)
            {
                if (i * l % 2 == 0) {
                    Coin[i, l].SetCoin(false);
                }else Coin[i, l].SetCoin(true);
            }
        }
        */
        
    }
}
