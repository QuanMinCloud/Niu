using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstant
{
    public static string PlayLevel = "PlayLevel"; // 点击即将打开的关卡
    public static string Level = "Level"; // 最高解锁关卡

    /// 游戏来源  Menu页面 == 1 ； Levle == 2
    public static string GameFrom = "GameFrom";


    /// 当前玩的游戏index
    public static string CurrentLevel = "CurrentLevel";
    /// Scene
    public static string GameScene = "GameScene";
    public static string MenuScene = "MenuScene";

    
    /// Tips Array
    public static string[] TipsContentArray = new string[]{"Book、Computer、Desk","代打卡是不诚信行为，请三思。途牛严厉禁止代打卡行为。","开发还在努力制作当中，有很多不好的地方还请见谅..."};
    public static string[] TipsArray = new string[]{"Book、Computer、Desk","试着拖动工牌，把工牌扔远远的。","开发还在努力制作当中..."};
}

/// 还在努力制作当中，有很多问题存在还请见谅。。。。。。
/// 提示 返回 开始游戏  关于 关卡 要旅游，找途牛。1234567890
/// 游戏说明 看了公司宣传卡通后，本想也做一款关于企业文化的小游戏，无奈理想很美好，现实很残酷，折磨两周后只完成了了两个关卡！
/// 找出规律，升序依次点击。
/// 今天早上帮我打下卡...Please!
/// 我的卡丢了拉拉拉拉拉啊了....
/// 我帮你一起找，不用担心！
/// 恭喜过关
/// 提示
/// 试着拖动工牌，把工牌扔远远的
/// 、
/// Book、Computer、Desk
/// 代打卡是不诚信行为，请三思。途牛严厉禁止代打卡行为
/// 重来
/// 开发还在努力制作当中，有很多不好的地方还请见谅..
