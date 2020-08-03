using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCoin : MonoBehaviour
{
    Turn T;
    CoinClass[,] Coin;
    // Start is called before the first frame update
    void Start()
    {
        Coin = this.GetComponent<CcreateCoin>().Coin;
        T = this.GetComponent<Turn>();
    }

    public void Change(int x,int y)
    {

    }
}
