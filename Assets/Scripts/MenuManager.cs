using System;
using System.Collections;
using System.Collections.Generic;
using Doozy.Engine.SceneManagement;
using Doozy.Engine.UI.Nodes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public SceneLoader MySceneLoader;


    private void Start()
    {
//        MySceneLoader.ActivateLoadedScene();
//        MySceneLoader.LoadSceneAsync();

        InitGameLevel();
    
    }

    void InitGameLevel()
    {
        if (PlayerPrefs.GetInt(GameConstant.Level) == 0)
        {
            PlayerPrefs.SetInt(GameConstant.Level, 1);
        }
    }

//    private void OnEnable()
//    {
//        print("menu-enable");
//    }
//
//    private void OnDisable()
//    {
//        print("menu-disable");
//    }
//    
//
    public void GoTOGame()
    {
        print("12123");
        SceneManager.LoadScene(GameConstant.GameScene);

    }
//
//    
//     public void onActiviteSceneChanged()
//    {
//            print("onActiviteSceneChanged");
//    }
//     
//     public void onSceneLoaded()
//     {
//         print("onSceneLoaded");
//     }
//     
//     public void onSceneUnloaded()
//     {
//         print("onSceneUnloaded");
//     }
//
//     public void destoryMenuScene()
//     {
//         print("Destory");
//         SceneDirector.UnloadSceneAsync(0);
//     }
//
//     ///
//     ///
//
//     public void SetLevel()
//     {
//         print(PlayerPrefs.GetString("Level"));
//         PlayerPrefs.SetString("Level","Test1");
//         PlayerPrefs.Save();
//     }
}
