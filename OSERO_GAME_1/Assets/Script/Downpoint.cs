using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Downpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ClickMousePos.Down == true)
        {
            if (Turn.turn == true)
            {
                IventManeger.COIN[ClickMousePos.posx, ClickMousePos.posy] = Instantiate(IventManeger.B_COIN, Vector2.zero, Quaternion.identity, IventManeger.main);

            }
            if (Turn.turn == false)
            {
                IventManeger.COIN[ClickMousePos.posx, ClickMousePos.posy] = Instantiate(IventManeger.W_COIN, Vector2.zero, Quaternion.identity, IventManeger.main);

            }
            ClickMousePos.Down = false;
        }
            
    }
}
