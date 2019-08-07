using System;
using System.Collections;
using System.Collections.Generic;
using Doozy.Engine;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GMTips : MonoBehaviour
{


    public TextMeshProUGUI tipsTextMesh;
    
    // Start is called before the first frame update
    void Start()
    {
        print("------Start------");
    }

    private void OnEnable()    
    {
        // 获取文字
        int index = PlayerPrefs.GetInt(GameConstant.Level);
        tipsTextMesh.text = GameConstant.TipsArray[index - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// Event
    
}


