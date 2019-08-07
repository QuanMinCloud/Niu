using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHelper : MonoBehaviour
{
    // 按钮里面的属性都放在这里
    
    
    
    virtual public void OnClicked(){}

    private void OnEnable()
    {
        GetComponent<UnityEngine.UI.Button> ().onClick.AddListener (OnClicked);
    }

    private void OnDisable()
    {
        RemoveListener();
    }

    public void RemoveListener()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.RemoveListener(OnClicked);
    }
}
