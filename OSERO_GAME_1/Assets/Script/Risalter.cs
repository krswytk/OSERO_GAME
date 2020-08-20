using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Risalter : MonoBehaviour
{
    [SerializeField] GameObject Gameset;
    [SerializeField] GameObject BSTR;
    [SerializeField] GameObject WSTR;
    [SerializeField] GameObject BC;
    [SerializeField] GameObject WC;
    CoinClass[,] Coin;
    RotationMainManger RMM;

    Text B,W;
    int b, w;

    bool i;

    private void Start()
    {
        Coin = this.GetComponent<CcreateCoin>().Coin;
        Gameset.SetActive(false);
        BSTR.SetActive(false);
        WSTR.SetActive(false);
        B = BC.GetComponent<Text>();
        W = WC.GetComponent<Text>();
        i = false;
        RMM = this.GetComponent<RotationMainManger>();
    }

    private void Update()
    {
        if (i == true)
        {
            if (Input.anyKeyDown)//何かキーが押された
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    public void GameSet()
    {
        Debug.Log("GameSetが呼び出されました。ゲームを終了します");
        b = 0;w = 0;
        Debug.Log(Coin[0, 7].GetFAB());
        Debug.Log(Coin[1, 7].GetFAB());
        Debug.Log(Coin[2, 7].GetFAB());
        for (int i = 0; i < 8; i++)
        {
            for (int l = 0; l < 8; l++)
            {
                if (Coin[i, l].GetFAB() == true && Coin[i, l].GetSet())
                {
                    b++;//黒の枚数
                }
                else if(Coin[i, l].GetFAB() == false && Coin[i, l].GetSet())
                {
                    w++;//白の枚数
                }
                else
                {
                    Debug.LogError("コインが設置されていないマスがあります。問題ないでしょうか？");
                }
            }
        }

        Gameset.SetActive(true);
        B.text = b.ToString();
        W.text = w.ToString();
        if(b>w) BSTR.SetActive(true);
        else WSTR.SetActive(true);
        i = true;
        RMM.enabled = false;

    }
        
}
