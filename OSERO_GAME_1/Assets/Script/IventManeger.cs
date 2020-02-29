using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IventManeger : MonoBehaviour
{
    public static GameObject B_COIN;
    public static GameObject W_COIN;
    public static Transform main;

    public static GameObject[,] COIN;

    private Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        COIN = new GameObject[8,8];
        for (int lp = 0; lp < 8; lp++)
        {
            for (int kp = 0; kp < 8; kp++)
            {
                COIN[lp, kp] = null;
            }
        }

        COIN[4, 3] = Instantiate(B_COIN, Vector2.zero, Quaternion.identity, main);
        COIN[3, 4] = Instantiate(B_COIN, Vector2.zero, Quaternion.identity, main);
        COIN[3, 3] = Instantiate(W_COIN, Vector2.zero, Quaternion.identity, main);
        COIN[4, 4] = Instantiate(W_COIN, Vector2.zero, Quaternion.identity, main);

        for (int lp = 0; lp < 8; lp++)
        {
            for (int kp = 0; kp < 8; kp++)
            {
                if (COIN[lp, kp] != null)
                {
                    COIN[lp, kp].gameObject.transform.localPosition = new Vector2(110 * lp, 110 * kp);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
