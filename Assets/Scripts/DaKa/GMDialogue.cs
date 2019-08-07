using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Doozy.Engine.UI;
using UnityEngine;

public class GMDialogue : MonoBehaviour
{
    Vector3 screenSpace;
    Vector3 offset;

    void OnMouseDown()
    {
        // 原位置
        screenSpace = Camera.main.WorldToScreenPoint(transform.position);
        // 相对便宜
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,screenSpace.z));
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenSapce = new Vector3(Input.mousePosition.x,Input.mousePosition.y,screenSpace.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSapce) + offset;
        // transform.position = curPosition;
        transform.DOMoveX(curPosition.x, 1);
    }
}
