using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginSystem : MonoBehaviour
{

    /// <summary>
    /// 初始化 LoginSystem；
    /// </summary>
    public void InitLoginSys()
    {

    }

    /// <summary>
    /// 进入登陆场景
    /// </summary>
    public void EnterLogin()
    {
        GameRoot.Instance.LoadingPanle.gameObject.SetActive(true);
        ///异步加载登陆场景；
        ResSever.Instance.AsyncLoadScene(Constant.LoginSceneName);
        ///加载进度；
        ///打开注册登陆界面；
    }

    public void Reover() { }
}
