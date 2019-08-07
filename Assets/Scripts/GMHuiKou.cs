using System.Collections;
using System.Collections.Generic;
using Doozy.Engine.UI;
using UnityEngine;

public class GMHuiKou : MonoBehaviour
{
    // Start is called before the first frame update
    public int hitHeadTimes;
    public GameObject cuiZiObject;

    public UIButton headButton;
    public UIButton niuButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hitHeadTimes > 10)
        {
            // 关闭所有交互
            niuButton.enabled = false;
            headButton.enabled = false;
            // 通关成功
        }
    }
    
    // 点击次数
    public void HitHead()
    {
        hitHeadTimes++;
        print(hitHeadTimes);
    }
}
