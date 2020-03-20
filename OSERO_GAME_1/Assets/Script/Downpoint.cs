using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Downpoint : MonoBehaviour//クリックした場所にコインを生成
{
    public GameObject EventSystem;
    private GameObject B_COIN;
    private GameObject W_COIN;
    private Transform main;

    private GameObject copy;
    // Start is called before the first frame update
    void Start()
    {
        B_COIN = EventSystem.GetComponent<IventManeger>().B_COIN;
        W_COIN = EventSystem.GetComponent<IventManeger>().W_COIN;
        main = EventSystem.GetComponent<IventManeger>().main;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (ClickMousePos.Down == true)
        {

            //Debug.Log("DOWNTRUE");
            //Debug.Log(ClickMousePos.posx + " " + ClickMousePos.posy);


            if (Turn.turn == true)//黒のターン
            {
                copy = IventManeger.COIN[ClickMousePos.posx, ClickMousePos.posy] = 
                    Instantiate(B_COIN, Vector2.zero, Quaternion.identity, main);//オブジェクトを生成

                copy.gameObject.transform.localPosition = 
                    new Vector2(110 * ClickMousePos.posx, 110 * ClickMousePos.posy);//クリックした場所におぶっジェクトを移動

                Turn.turn = false;

                Debug.Log("黒配置");
            }
            else if (Turn.turn == false)//白のターン
            {
                copy = IventManeger.COIN[ClickMousePos.posx, ClickMousePos.posy] = 
                    Instantiate(W_COIN, Vector2.zero, Quaternion.identity, main);//オブジェクトを生成

                copy.gameObject.transform.localPosition = 
                    new Vector2(110 * ClickMousePos.posx, 110 * ClickMousePos.posy);//クリックした場所におぶっジェクトを移動

                Turn.turn = true;

                Debug.Log("白配置");
            }
            ClickMousePos.Down = false;
        }
            
    }
}
