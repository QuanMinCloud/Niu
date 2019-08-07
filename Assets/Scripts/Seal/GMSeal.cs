using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Doozy.Engine.UI;
using UnityEngine;
using UnityEngine.UI;

public class GMSeal : MonoBehaviour
{

    [Header("游戏对象")] public GameObject deskObject;
    public GameObject niuObject;
    public GameObject sealObject;
    public GameObject bookObject;
    public GameObject peopleObject;


    private Vector3 deskOriginPos;
    private Vector3 niuOriginPos;
    private Vector3 sealOriginPos;
    private Vector3 bookOriginPos;
    private Vector3 peopleOriginPos;

    public Animator niuAnim;

    public Text niuDialogue;
    public Text peopleDialogue;
    
    // 章和人之间的距离
    public float disBetPeopleAndSeal;
    
    // 游戏是否过关判断
    bool gameFlag = false;

    private float firstMoveTime = 0.2F;
    
    // 里面的内容都可以进行拖动，首先要记录原来的位置

    private void Awake()
    {
        deskOriginPos = deskObject.transform.localPosition;
        niuOriginPos = niuObject.transform.localPosition;
        sealOriginPos = sealObject.transform.localPosition;
        bookOriginPos = bookObject.transform.localPosition;
        peopleOriginPos = peopleObject.transform.localPosition;
    }

    private void Start()
    {
        
    }


    public void StartGame()
    {


        StartCoroutine(GameStep());
        
        // 首先把所有对象，放到指定位置<使用DOTWeen动画吧>




        // 移动对象到原位置


        // 开始播放动画
    }

    
    IEnumerator GameStep()
    {
        FirstMoveObject();
        yield return new WaitForSeconds(firstMoveTime);
        // 你开始走向桌子
        float niuMoveTime = 0.2F;
        NiuMove(niuMoveTime);
        yield return new WaitForSeconds(niuMoveTime);
        
        // 此处判断 游戏状态
        if (gameFlag)
        {
            float dialogueTime = 0.2F;
            // 成功通关
            // 播放对话
            niuDialogue.DOText("请问我可以使用公章吗？",dialogueTime);
            yield return new WaitForSeconds(dialogueTime);
            peopleDialogue.DOText("可以~~~。", dialogueTime);
            yield return new WaitForSeconds(dialogueTime);
            
            // 播放盖章动画
            DoSeal();
            // 展示SuccessView
            
        }
        else
        {
            // 用章动画
            niuAnim.SetTrigger("seal");
            yield return new WaitForSeconds(niuMoveTime);
            // 下面一直执行敲章动画
            
        }


        void DoSeal()
        {
            
        }
    }

    void FirstMoveObject()
    {
        float dis = (peopleObject.transform.localPosition - sealObject.transform.localPosition).sqrMagnitude;
        DoMoveToOrigin(deskObject,deskOriginPos,firstMoveTime);
        DoMoveToOrigin(niuObject,niuOriginPos,firstMoveTime);
        DoMoveToOrigin(sealObject,sealOriginPos,firstMoveTime);
        DoMoveToOrigin(bookObject,bookOriginPos,firstMoveTime);
        // 判断people和章的距离是否小于xx
        if (dis < 10)
        {
            gameFlag = true;
            // 把人移动到桌子前面，
            DoMoveToOrigin(peopleObject,peopleOriginPos,firstMoveTime);
        }
        else
        {
            DoMoveToOrigin(peopleObject,peopleOriginPos,firstMoveTime);
        }
    }

    void NiuMove(float niuMoveTime)
    {
        // 播放牛走动动画 niuAnim
        
        // 牛开始往前移动，并且放大
        niuObject.transform.DOLocalMove(Vector3.zero, niuMoveTime);

    }


    public void ResetGame()
    {
        
    }


    void DoMoveToOrigin(GameObject go, Vector3 pos ,float duration)
    {
        go.transform.DOLocalMove(pos, duration);
    }

}
