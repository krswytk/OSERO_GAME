using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Size : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution(1000, 1000, false, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) Quit();
    }

    void Quit()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #elif UNITY_STANDALONE
          UnityEngine.Application.Quit();
    #endif
    }
}
