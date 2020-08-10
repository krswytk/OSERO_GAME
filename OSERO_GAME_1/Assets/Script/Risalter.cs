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

    Text B,W;
    int b, w;

    private void Start()
    {
        Coin = this.GetComponent<CcreateCoin>().Coin;
        Gameset.SetActive(false);
        BSTR.SetActive(false);
        WSTR.SetActive(false);
        B = BC.GetComponent<Text>();
        W = WC.GetComponent<Text>();

    }




    public void SetSharc()
    {
        int num = 0;
        Debug.Log("SetSharcが呼ばれた");
        for (int i = 0; i < 8; i++)
        {
            for (int l = 0; l < 8; l++)
            {
                if (Coin[i,l].GetSet() == true) {//コインが設置されている

                    num++;
                }
                else
                {
                    //Debug.Log("現在コイン(ただしチョー不確定) "+num);
                    return;//関数から抜ける
                }
            }
        }
        //ここまでくる＝すべて設置されている
        Debug.Log("GameSetを確認");
        //GameSet();//リザルト処理を行う
    }

    public void GameSet()
    {
        Debug.Log("GameSetが呼び出されました。ゲームを終了します");
        for (int i = 0; i < 8; i++)
        {
            for (int l = 0; l < 8; l++)
            {
                if (Coin[i, l].GetFAB() == true)
                {
                    b++;//黒の枚数
                }
                else
                {
                    w++;//白の枚数
                }
            }
        }

        Gameset.SetActive(true);
        B.text = b.ToString();
        W.text = w.ToString();
        if(b>w) BSTR.SetActive(true);
        else WSTR.SetActive(true);

        while (true)//処理を繰り返す　ロードシーンで強制的に抜け出す
        {
            if (Input.anyKeyDown)//何かキーが押された
            {
                SceneManager.LoadScene(0);
            }
        }
    }
        
}
