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

        Coin[3, 3].SetCoin(true);
        Coin[4, 4].SetCoin(true);
        Coin[3, 4].SetCoin(false);
        Coin[4, 3].SetCoin(false);
        
    }
}
