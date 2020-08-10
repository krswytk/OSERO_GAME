using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCoinB : MonoBehaviour
{
    CcreateCoin CC;
    GameObject EV;
    private bool SCSW;
    private bool sw;//特殊コインを設置したがどうか　初期false
    // Start is called before the first frame update
    void Start()
    {
        EV = GameObject.Find("EventSystem");
        CC = EV.GetComponent<CcreateCoin>();
        SCSW = false;
        sw = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpecialBotton()
    {
        if (sw == false)
        {
            if (SCSW)
            {
                SCSW = false;
                //ここに推してない状態
            }
            else
            {
                SCSW = true;
                //押している状態
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
        this.gameObject.SetActive(false);
    }
}
