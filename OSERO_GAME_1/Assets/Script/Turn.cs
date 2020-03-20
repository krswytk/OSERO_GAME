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
    }

    // Update is called once per frame
    void Update()
    {
        if(turn == true)
        {
            W_turn.SetActive(false);
            B_turn.SetActive(true);
        }
        if (turn == false)
        {
            B_turn.SetActive(false);
            W_turn.SetActive(true);
        }
    }
}
