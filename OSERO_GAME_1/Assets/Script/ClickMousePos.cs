using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMousePos : MonoBehaviour
{
    public static int posx,posy;
    public static bool Down;
    // Start is called before the first frame update
    void Start()
    {
        Down = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            posx = (int)mousePosition.x;
            posy = (int)mousePosition.y;
            
            posx -= 60;
            posy -= 60; //110
            
            if (posx < 0 || posy < 0)
            {
                posx += 1000;
                posy += 1000;
            }

            posx = posx / 110;
            posy = posy / 110;

            if (posx > 7 || posx < 0 || posy > 7 || posy < 0)
            {
                posx = -1;
                posy = -1;
            }
            Down = true;
        }
    }
}
