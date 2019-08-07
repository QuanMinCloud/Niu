using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Doozy.Engine;
using UnityEngine;
using UnityEngine.UI;

public class GMPaiXu : MonoBehaviour
{
    [Header("NumImage")] 
    public Image bookImg;
    public Image deskImg;
    public Image computerImg;


    private int currentNum = 0;

    [Header("numSprite")] 
    private Sprite oneSprite;
    private Sprite twoSprite;
    private Sprite threeSprite;

    [Header("GameFlag")] 
    public Image failedFlagImg;
    public Image successFlagImg;

//    [Header("GO")] public GameObject bookGO;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    private void OnEnable()
    {
        Array ss = Resources.LoadAll("Num123");
        foreach (var VARIABLE in ss)
        {
            if (VARIABLE.GetType() == typeof(Sprite))
            {
                Sprite imgSprite = VARIABLE as Sprite;
                if (imgSprite.name == "123num_0")
                {
                    oneSprite = imgSprite;
                }
                else if (imgSprite.name == "123num_1")
                {
                    twoSprite = imgSprite;
                }
                else if (imgSprite.name == "123num_2")
                {
                    threeSprite = imgSprite;
                }
            }
        }
        bookImg.sprite = null;
        computerImg.sprite = null;
        deskImg.sprite = null;

        currentNum = 0;
        bookImg.gameObject.SetActive(false);
        computerImg.gameObject.SetActive(false);
        deskImg.gameObject.SetActive(false);
        failedFlagImg.transform.localScale = Vector3.zero;
        successFlagImg.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
    }


    // 点击按钮
    public void ImgBtnClick(int index)
    {
        switch (index)
        {
            case 1:
                addNumToImage(bookImg);
                break;
            case 2:
                addNumToImage(computerImg);
                break;
            case 3:
                addNumToImage(deskImg);
                break;
            default:
                Debug.Log("错误消息");
                break;
        }
    }

    // 重置
    void resetData()
    {
        currentNum = 0;
        bookImg.gameObject.SetActive(false);
        computerImg.gameObject.SetActive(false);
        deskImg.gameObject.SetActive(false);
    }

    // 点击选项，添加数字
    public void addNumToImage(Image numImg)
    {
        // 判断图片是否存在
        if (numImg.gameObject.activeSelf)
        {
            return;
        }
        
        currentNum++;

        Sprite numSprite;
        if (currentNum == 1)
        {
            numSprite = oneSprite;
        }
        else if (currentNum == 2)
        {
            numSprite = twoSprite;
        }
        else
        {
            numSprite = threeSprite;
        }

        // 设置数字图片
        numImg.gameObject.SetActive(true);
        numImg.sprite = numSprite;
        if (currentNum == 3)
        {
            // 判断成功还是失败
            judgeResult();
        }
    }


    void judgeResult()
    {
        // 成功
        if (bookImg.sprite.name == oneSprite.name 
            && computerImg.sprite.name == twoSprite.name
            && deskImg.sprite.name == threeSprite.name)
        {
            //展示 ✅
            setGameFlagImgActive(successFlagImg, true);
        }
        else
        {
            // 重置所有数据
            resetData();
            // 展示  ❎
            setGameFlagImgActive(failedFlagImg,false);
            // 0.5庙后小时
        }
    }
    
    // 展示游戏状态 ✅❎
    void setGameFlagImgActive(Image flagImg, bool successFlag)
    {
        flagImg.transform.localScale = Vector3.zero;
        flagImg.gameObject.SetActive(true);
        flagImg.transform.DOScale(2.5F, 0.3F);
        if (successFlag)
        {
            Invoke(nameof(displaySuccess), 1);
            // 调用成功
        }
        else
        {
            Invoke(nameof(displayFailed), 1);
        }
    }

    // 游戏成功
    void displaySuccess()
    {
        successFlagImg.gameObject.SetActive(false);
        // 展示 SuccessView
        GameEventMessage.SendEvent("GoTo Success");
    }
    void displayFailed()
    {
        failedFlagImg.gameObject.SetActive(false);
    }
}

// 修改 精灵图片资源
//    void changeSpriteByImage(){
//        Texture2D Tex = Resources.Load ("enter") as Texture2D;
//        SpriteRenderer spr = xx.GetComponent<SpriteRenderer> (); 
//        Sprite spriteA = Sprite.Create (Tex, spr.sprite.textureRect, new Vector2 (0.5f, 0.5f));
//        xx.GetComponent<SpriteRenderer> ().sprite = spriteA;
//    }
// 
//    void changeSpriteByAnotherSprite(){
//        Sprite spriteB = Resources.Load<Sprite> ("test");
//        xx.GetComponent<SpriteRenderer> ().sprite = spriteB;
//    }