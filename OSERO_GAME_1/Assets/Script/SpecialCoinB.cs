using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialCoinB : MonoBehaviour
{
    private bool SCSW;
    private bool sw;//特殊コインを設置したがどうか　初期false
    private Button B;
    // Start is called before the first frame update
    //Color colors;
    void Start()
    {
        SCSW = false;
        sw = false;
        B = GetComponent<Button>();
        //colors = B.colors;
    }
    

    public void SpecialBotton()
    {
        if (sw == false)
        {
            if (SCSW)
            {
                SCSW = false;
                //ここに推してない状態
                B.GetComponentInChildren<Image>().color = new Color(1,1,1,1);
            }
            else
            {
                SCSW = true;
                B.GetComponentInChildren<Image>().color = new Color(1,1/2,1/2,1);
            }
        }
    }

    public bool GetSCSW()
    {
        return SCSW;
    }

    public void ONSW()
    {
        sw = true;
        SCSW = false;
        //灰色にして押せなくなる処理
        B.interactable = false;
    }
}
