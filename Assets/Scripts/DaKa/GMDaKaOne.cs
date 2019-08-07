using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Doozy.Engine;
using Doozy.Engine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GMDaKaOne : MonoBehaviour
{




    [Header("GameObject")] public Image dakaji;
    public RectTransform niuRT;
    public Image niuCard;
    public Image ygCard;
    public UIButton startGameBtn;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI niuDiagueText;
    public RectTransform restartBtn;
    
    
    private Vector3 originPos;
    private Vector3 firstDestPos;
    private Vector3 secondDestPos;
    private Vector3 ygCardPos;
    private Vector3 dakajiPos;
    private float resetBtnPosX;
    private float niuScale = 0.6F;
    private float niuRunTime = 3.0F;

    public Animator niuAnim;

//    //物体拖动  https://blog.csdn.net/u013983442/article/details/79931870


    private void OnEnable()
    {
        print("Enable");
        Invoke(nameof(SetPos),1F);
    }

    void SetPos()
    {
        resetBtnPosX = restartBtn.localPosition.x;
        originPos = new Vector3(niuRT.localPosition.x, niuRT.localPosition.y, 0);
        firstDestPos = new Vector3(Screen.width / 2 + 200, originPos.y + 260, 0);
        ygCardPos = new Vector3(ygCard.rectTransform.position.x, ygCard.rectTransform.position.y, 0);
        dakajiPos = new Vector3(dakaji.transform.localPosition.x, dakaji.transform.localPosition.y, 0);
    }
    public void resetGame()
    {
        // 停止所有动作
        StopCoroutine("startFailedRun");
        StopCoroutine("SuccessDialogue");
        // 按钮状态
        startGameBtn.enabled = true;
        niuAnim.SetTrigger("default");
        // 所有数据复位
        niuCard.gameObject.SetActive(false);
        ygCard.gameObject.SetActive(true);
        niuRT.localPosition = originPos;
        ygCard.rectTransform.position = ygCardPos;
    }

    public void startGame()
    {
        
        
        
        startGameBtn.enabled = false;
        // 1.检测卡的位置，是否在下面
        Vector3 yg = Camera.main.WorldToScreenPoint(ygCard.rectTransform.position);
    
        if (yg.y < 300) //过关
        {
            dialogueText.text = "";

            StartCoroutine(SuccessDialogue());
        }
        else
        {

            StartCoroutine(startFailedRun(() =>
            {
                niuAnim.SetTrigger("Achieve");
            }));
//        niuAnim.Play("DaKaNiuAchieve", 0, 0.5F);


//        StartCoroutine(doRun());
//        niuRT.DOMoveX(0,2F);
//        StartCoroutine(doMoveTest(() =>
//        {
//            print("播放完成");
//        }));

        }
        // 2.进行对白
        // 3.牛获取卡
        // 4.牛去打卡
        // 5.


        // 对白



    }

    IEnumerator SuccessDialogue()
    {
        float dialogTime = 1F;
        dialogueText.DOText("我的卡丢了拉拉拉拉拉啊了....", dialogTime);
        yield return new WaitForSeconds(dialogTime);
        niuDiagueText.DOText("我帮你一起找，不用担心！", dialogTime);
        yield return new WaitForSeconds(dialogTime);
        GameEventMessage.SendEvent("GoTo Success");

    }

    IEnumerator startFailedRun(Action callBack)
    {
        // 按钮失效
        restartBtn.DOLocalMoveX(Screen.width / 2 + 500, 1);
        // 获取卡
        niuAnim.SetTrigger("Achieve");
        yield return new WaitForSeconds(0.55F);
        niuAnim.SetTrigger("default");
        // 显示牛卡，隐藏员工卡
        niuCard.gameObject.SetActive(true);
        ygCard.gameObject.SetActive(false);

        // 一秒后开始移动
        yield return new WaitForSeconds(1F);
        niuAnim.SetTrigger("Run");
        doFirstRun();
        yield return new WaitForSeconds(niuRunTime);
        doSecondRun();
        yield return new WaitForSeconds(niuRunTime);
        niuAnim.SetTrigger("default");
        restartBtn.DOLocalMoveX(resetBtnPosX, 1);
        if (callBack != null)
        {
            callBack();
        }
    }

    IEnumerator doRun()
    {
        niuAnim.SetTrigger("Run");
        doFirstRun();
        yield return new WaitForSeconds(niuRunTime);
        doSecondRun();
    }

    private void doFirstRun()
    {

        
        niuRT.DOLocalMove(new Vector3(firstDestPos.x, firstDestPos.y, 0), niuRunTime);
        niuRT.DOScale(niuScale, niuRunTime);
    }


    private void doSecondRun()
    {
        // 设置niu的pos
        niuRT.localPosition = new Vector3(-200 - Screen.width / 2, 0, 0);
        secondDestPos = new Vector3(dakajiPos.x - 102, dakajiPos.y + 130, 0);
        niuRT.DOLocalMove(secondDestPos, niuRunTime);
        niuRT.DOScale(1.2F, niuRunTime);

    }

}


// Update is called once per frame
//    void Update()
//    {
//        
//    }
//
//    public void OnBeginDrag()
//    {
//        
//    }
//
//
//  
//
//    IEnumerator doMoveTest(Action callback)
//    {
////        niuAnim.SetTrigger("Run");
//        Tweener tweener = niuRT.DOLocalMoveX(Screen.width / 2, 10F);
//        tweener.SetEase(Ease.Linear);
//        yield return new WaitForSeconds(10);
//        if (callback != null)
//        {
//            callback();
//        }
//    }
//}
