using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartCoin : MonoBehaviour
{
    [SerializeField] GameObject Main;//●画像を格納
    CoinClass[,] Coin;
    // Start is called before the first frame update
    void Start()
    {
        CoinClass[,] Coin = Main.GetComponent<CcreateCoin>().Coin;

        Coin[3, 3].SetCoin(true);
        Coin[4, 4].SetCoin(true);
        Coin[3, 4].SetCoin(false);
        Coin[4, 3].SetCoin(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
