using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Doozy.Engine;
using Doozy.Engine.Nody;
using Doozy.Engine.SceneManagement;
using Doozy.Engine.UI;
using Doozy.Engine.UI.Animation;
using Doozy.Engine.UI.Nodes;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [Header("Canvas")]
    public UICanvas gameCanvas;
    public UICanvas menuCanvas;
   
    public TextMeshProUGUI realNumText; // 顶部level等级   
    
    public GraphController MyController;

    public UIView lastView; // 当前展示view
    
    public UIView successView;
    
    public UIView[] gameViews;

    public void sendMessageeee(string name)
    {
        GameEventMessage.SendEvent(name);
    }



    /// <summary>
    ///  菜单栏点击事件
    /// </summary>

    public void tipsBtnClick()
    {
        // 展示一个tips
        GameEventMessage.SendEvent("GoTo Tips");
    }

    public void backBtnClick()
    {
        gameCanvas.gameObject.SetActive(false);
        int level = PlayerPrefs.GetInt(GameConstant.Level);
        for (int i = 0; i < level; i++)
        {
            gameViews[i].gameObject.SetActive(false);
        }
        menuCanvas.gameObject.SetActive(true);
    }

    
    public void closeSuccessScene()
    {
        successView.Hide();
    }

    /// <summary>
    /// 开始游戏
    /// </summary>
    ///
    public void startGame()
    {
        PlayerPrefs.SetInt(GameConstant.PlayLevel,0);
        PlayerPrefs.SetInt(GameConstant.Level,1);

        Invoke( "switchGameCanvas",0.5F);
    }
    public void goToGame()
    {
        Invoke( "switchGameCanvas",0.5F);
    }
    
  


/// <summary>
/// 选中需要显示的canvas
/// </summary>
    void switchGameCanvas()
    {
        switchCanvas(true);
    }

    void switchMenuCanvas()
    {
        switchCanvas(false);
    }

    
    void switchCanvas(bool openGame)
    {
        gameCanvas.gameObject.SetActive(openGame);
        if (openGame)
        { 
            SetGameLevel();
        }
        menuCanvas.gameObject.SetActive(!openGame);
        
    }

    void SetGameLevel()
    {
        // 显示游戏关卡
        int gameFrom = PlayerPrefs.GetInt(GameConstant.GameFrom);
        int levelNum = PlayerPrefs.GetInt(gameFrom == 2 ? GameConstant.PlayLevel : GameConstant.Level);
        Debug.Log("当前的游戏关卡是：+"+levelNum.ToString());
        if (levelNum - 1 > gameViews.Length)
        {
            return;
        }
        UIView displayView = gameViews[levelNum-1];
        Debug.Log(displayView);
        displayView.gameObject.SetActive(true);
        lastView = displayView;
        // 设置顶部关卡num
        realNumText.text = levelNum.ToString();

        if (gameFrom == 2)
        {
            PlayerPrefs.SetInt(GameConstant.GameFrom,0);
        }
    }
    /// 选中关卡
    ///
    ///
    /// 下一关
    public void NextGame()
    {
        // 获取当前关卡
        int currentLevel = PlayerPrefs.GetInt(GameConstant.Level);
        gameViews[currentLevel-1].gameObject.SetActive(false);

        int nextLevel = currentLevel + 1;
        realNumText.text = nextLevel.ToString();
        PlayerPrefs.SetInt(GameConstant.Level,nextLevel);
        gameViews[nextLevel-1].gameObject.SetActive(true);
    }
}

/// ==================================================================================================


//public void GoToTest1()
//{
////        MyController.GoToNodeByName("Test1");
//}

//    private void Awake()
//    {
//        print("GAMESCENE-AWAKE");
//    }
//
//    private void OnEnable()
//    {
//        print("GameScene-Enable");
//    }
//
//    private void OnDisable()
//    {
//        print("GameScene-Disable");
//    }
//
//
//    public void GoToMenu()
//    {
////        menuSceneLoader.ActivateLoadedScene();
//    }




/// start
///         
//        huiko.ShowBehavior = new UIViewBehavior(AnimationType.Show);

//        print("START");
//        UIView[] children =  gameObject.GetComponentsInChildren<UIView>(true);
//        foreach (var VARIABLE in children)
//        {
//            print(VARIABLE.name);
//            if (VARIABLE.name == "View - HuiKou")
//            {
//                VARIABLE.Show();
//            }
//
//        }
//        GameEventMessage.SendEvent("GoTo HuiKou");
//        GameEventMessage.SendEvent("GoTo HeTong");
//        String level = PlayerPrefs.GetString("Level");
//        String level11 = PlayerPrefs.GetString("Level11");
//        print(level);
//        print(level11);
//
//        if (level != null)
//        {
////            MyController.GoToNodeByName(level);
//
//        }



/// Awka
/// //        UIView[] children =  gameObject.GetComponentsInChildren<UIView>(true);
//        foreach (var VARIABLE in children)
//        {
//            print(VARIABLE.name);
//            if (VARIABLE.name == "View - HuiKou")
//            {
//                VARIABLE.Show();
//            }
//
//        }
//        print("AWAKE");
//        GameEventMessage.SendEvent("GoTo HuiKou");
