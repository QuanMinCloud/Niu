using System;
using System.Collections;
using System.Collections.Generic;
using Doozy.Engine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPrefab : MonoBehaviour
{
    GameObject gameGo;
    GameObject menuGO;
    private GameManager gameManager;
    
    public GameObject btnImg;
    public GameObject lockGo;
    // 当前是第一个level
    public int levelIndex;
    // Start is called before the first frame update
    public bool unlockStatus;

    public TextMeshProUGUI numText;
    public Image xx;
    
    void Start()
    {
        
    }

    private void OnEnable()
    {
        SetLockStatus();
        SetBtnImage();
        SetLevelNum();
        SetCanvas();
        gameManager = GameObject.FindWithTag("Manager").GetComponent<GameManager>();

    }

    void SetLockStatus()
    {
        int level = PlayerPrefs.GetInt("Level");
        unlockStatus = level >= levelIndex;
        print(unlockStatus);

        if (unlockStatus)
        {
            lockGo.SetActive(false);
        }
    }

    void SetBtnImage()
    {
        Sprite levelSprite = Resources.Load<Sprite>("LevelImg/LevelImg"+levelIndex.ToString());
        btnImg.GetComponent<Image>().sprite = levelSprite;
    }

    void SetLevelNum()
    {
        numText.text = levelIndex.ToString();
    }

    void SetCanvas()
    {
        UICanvas[] canvass = (UICanvas[])Resources.FindObjectsOfTypeAll(typeof(UICanvas));
        foreach (var VARIABLE in canvass)
        {
            if (VARIABLE.name == "Canvas - GameCanvas")
            {
                gameGo = VARIABLE.gameObject;
            }else if (VARIABLE.name == "Canvas - MenuCanvas")
            {
                menuGO = VARIABLE.gameObject;
            }
        }
        
    }

    public void openTuniuURL()
    {
        if (unlockStatus)
        {
            // 解锁状态跳转游戏关卡
            PlayerPrefs.SetInt(GameConstant.PlayLevel,levelIndex);
            PlayerPrefs.SetInt(GameConstant.GameFrom,2);
            gameManager.goToGame();
        }    
        else
        {
            Application.OpenURL("https://www.tuniu.com");
            // 打开 途牛页面
        }
        
    }

}
