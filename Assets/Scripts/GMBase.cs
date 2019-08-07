using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMBase : MonoBehaviour
{
    // Start is called before the first frame update
    
    PopupManager _popupManager;
    public PopupManager PopupManager
    {
        get 
        {
            if (_popupManager == null)
                _popupManager = FindObjectOfType<PopupManager> ();

            return _popupManager;
        }
    }
}
