using System;
using System.Collections;
using System.Collections.Generic;
using Doozy.Engine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SuccessView : MonoBehaviour
{
   // 展示成功过关文字
   
   // 点击按钮进行下一关
   public TextMeshProUGUI tipText;
   public UIView testView;
   
   
   
   private void OnEnable()
   {
      int level = PlayerPrefs.GetInt("Level");
      Debug.Log("SuccessView"+level.ToString());
      tipText.text = GameConstant.TipsContentArray[level-1];
   }

}
