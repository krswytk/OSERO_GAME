using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour //黒と白の順番を管理する
{
    public static bool turn;
    public GameObject B_turn;
    public GameObject W_turn;
    // Start is called before the first frame update
    void Start()
    {
        turn = true; // true = 黒　false = 白
        W_turn.SetActive(false);
        B_turn.SetActive(false);
        CS();
    }

    // Update is called once per frame
    void CS()
    {
        if(turn == true)
        {
            B_turn.SetActive(true);
            W_turn.SetActive(false);
        }
        if (turn == false)
        {
            B_turn.SetActive(false);
            W_turn.SetActive(true);
        }
    }
}
