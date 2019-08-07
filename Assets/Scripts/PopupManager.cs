using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public GameObject POPUP;
    public Array gameArr;

    private void Awake()
    {
        POPUP.SetActive(false);
    }
    
    public void GoToGame(int i)
    {
//        float time = 0.2f;
//        GoOut (POPUP,time,0);
//        GoIn (gameArr[i], time, time);
    }

    public void GoToPOPUP()
    {
        float time = 0.2f;
        GoIn (POPUP, time, time);
    }
    
    void Update()
    {
//        BACKGROUND_BACK.color = Color.Lerp(BACKGROUND_BACK.color, NORMAL_COLOR,Time.time);
    }
    
    public void GoOut(GameObject obj, float time, float delay)
    {
        obj.transform.localScale = Vector3.one;
        StartCoroutine (GoInOrOutCorout (obj, 0, time, delay, () => {
            obj.transform.localScale = Vector3.zero;
            obj.SetActive(false);
        }));

    }

    //animation scale from 0 to 1
    public void GoIn(GameObject obj, float time, float delay){
        obj.transform.localScale = Vector3.zero;
        StartCoroutine (GoInOrOutCorout (obj, 1, time, delay, () => {
            obj.transform.localScale = Vector3.one;
            obj.SetActive(true);
        }));

    }
    
    IEnumerator GoInOrOutCorout(GameObject obj, float scale, float time, float delay, Action callback)
    {
        obj.SetActive(true);

        yield return new WaitForSeconds (delay);

        var originalScale = obj.transform.localScale;
        var targetScale = Vector3.one * scale;
        var originalTime = time;

        while (time > 0.0f)
        {
            time -= Time.deltaTime;
            obj.transform.localScale = Vector3.Lerp(targetScale, originalScale, time / originalTime);
            yield return 0;
        }

        if (callback != null)
            callback ();
    }
}
