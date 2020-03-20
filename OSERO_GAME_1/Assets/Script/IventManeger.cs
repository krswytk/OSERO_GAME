using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IventManeger : MonoBehaviour
{
    public GameObject B_COIN;//publicで黒いコインを保存
    public GameObject W_COIN;//publicで白いコインを保存
    public Transform main;

    public static GameObject[,] COIN;//コインの位置を管理する2次元配列

    private Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        COIN = new GameObject[8,8];//2次元配列を定義


        for (int lp = 0; lp < 8; lp++)
        {
            for (int kp = 0; kp < 8; kp++)
            {
                COIN[lp, kp] = null;//すべてのポジション管理配列にnullを代入
            }
        }

        COIN[4, 3] = Instantiate(B_COIN, Vector2.zero, Quaternion.identity, main);//初期のコインを生成
        COIN[3, 4] = Instantiate(B_COIN, Vector2.zero, Quaternion.identity, main);
        COIN[3, 3] = Instantiate(W_COIN, Vector2.zero, Quaternion.identity, main);
        COIN[4, 4] = Instantiate(W_COIN, Vector2.zero, Quaternion.identity, main);

        for (int lp = 0; lp < 8; lp++)
        {
            for (int kp = 0; kp < 8; kp++)
            {
                if (COIN[lp, kp] != null)
                {
                    COIN[lp, kp].gameObject.transform.localPosition = new Vector2(110 * lp, 110 * kp);//初期生成した4つのコインを特定の場所に移動
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
