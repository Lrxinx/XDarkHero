using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginSystem : SystemRoot
{
    public static LoginSystem Instance;
    public LoginPanle loginPanle;
    public CreatPlayerPanle creatPlayerPanle;

    /// <summary>
    /// 初始化 LoginSystem；
    /// </summary>
    public override void IniSys()
    {
        base.IniSys();
        Instance = this;
    }

    /// <summary>
    /// 进入登陆场景
    /// </summary>
    public void EnterLogin()
    {
       
        ///异步加载登陆场景；
        resSever.AsyncLoadScene(Constant.LoginSceneName,OpenLoginPanle);
        ///加载进度；
        ///
        ///打开注册登陆界面；
    }

    public void OpenLoginPanle()
    {
        loginPanle.SetWindState();
        audioSer.PlayBgAudio(Constant.BgLoginName);
    }

    public void RspLogin()
    {
        //Open CreatPlayerPanle;
        creatPlayerPanle.SetWindState();
        //Close LoginPanle
        loginPanle.SetWindState(false);
    }
}
