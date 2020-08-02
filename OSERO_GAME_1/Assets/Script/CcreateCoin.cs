using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CcreateCoin : MonoBehaviour//初期の設定　すべてのマスに透明なコインを配置する
{
    [SerializeField] Sprite WhiteImage;
    [SerializeField] Sprite BlackImage;
    
    [SerializeField] GameObject CoinPrefab;

    public GameObject[,] Coin;
    public Image[,] CoinSP;
    // Start is called before the first frame update
    void Start()
    {
        Coin = new GameObject[8, 8];
        for (int i = 0;i < 8; i++)
        {
            for (int l = 0; l < 8; l++)
            {
                Coin[i,l] = Instantiate(CoinPrefab, transform.position, transform.rotation,this.transform);//コインを生成
                Coin[i,l].transform.localPosition = new Vector2(i * 110, l * 110);//コインの座標を変更
                Coin[i,l].name = "COIN[" + i + "][" + l + "]";//コインの名前変更
                CoinSP[i, l] = Coin[i, l].GetComponent<Image>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
