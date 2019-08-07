using System.Collections;
using System.Collections.Generic;
using Doozy.Engine.UI;
using UnityEngine;

public class GameUtils
{
//    public  static UICanvas[] findCanvas()
//    {
//        UICanvas[] canvass = (UICanvas[])Resources.FindObjectsOfTypeAll(typeof(UICanvas));
//        foreach (var VARIABLE in canvass)
//        {
//            if (VARIABLE.name == "Canvas - GameCanvas")
//            {
//                gameGo = VARIABLE.gameObject;
//            }else if (VARIABLE.name == "Canvas - MenuCanvas")
//            {
//                menuGO = VARIABLE.gameObject;
//            }
//        }
//    }
//
    public static GameObject findGameCanvas()
    {
        GameObject gameGo;
        UICanvas[] canvass = (UICanvas[])Resources.FindObjectsOfTypeAll(typeof(UICanvas));
        
        foreach (var VARIABLE in canvass)
        {
            if (VARIABLE.name == "Canvas - GameCanvas")
            {
                gameGo = VARIABLE.gameObject;
                return gameGo;
            }
        }

        return null;
    }
    
    public static GameObject findMenuCanvas()
    {
        GameObject menuGo;
        UICanvas[] canvass = (UICanvas[])Resources.FindObjectsOfTypeAll(typeof(UICanvas));
        
        foreach (var VARIABLE in canvass)
        {
            if (VARIABLE.name == "Canvas - MenuCanvas")
            {
                menuGo = VARIABLE.gameObject;
                return menuGo;
            }
        }

        return null;
    }

}
