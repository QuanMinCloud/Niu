using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DragMove :  MonoBehaviour,IDragHandler
{
    private void Update()
    {
        
    }

    private void SetDraggedPosition(PointerEventData eventData)
    {
        var rt = gameObject.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position,eventData.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
        }
    }

    public void OnDrag(PointerEventData eventData)
    { 
        //拖拽移动图片
        SetDraggedPosition(eventData);
        print("111111111111111111111111");
        print(GetComponent<RectTransform>().position);
        print(GetComponent<RectTransform>().localPosition);
        print("22222222222222222222222");
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
      
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    
        
    }
}
