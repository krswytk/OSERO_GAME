using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour //黒と白の順番を管理する
{
    public bool turn;
    public GameObject B_turn;
    public GameObject W_turn;
    // Start is called before the first frame update
    void Start()
    {
        turn = false; // true = 白 false = 黒　
        W_turn.SetActive(false);
        B_turn.SetActive(false);
        CS();
    }

    // Update is called once per frame
    public void CS()
    {
        if(turn == true)
        {
            Debug.Log("白ターンに切り替え");
            B_turn.SetActive(false);
            W_turn.SetActive(true);
            turn = false;
        }
        else if (turn == false)
        {
            Debug.Log("黒ターンに切り替え");
            B_turn.SetActive(true);
            W_turn.SetActive(false);
            turn = true;
        }
    }
}
