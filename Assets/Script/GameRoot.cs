using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance;
    public LoadingPanle LoadingPanle;
    public DynamicWind dynamicWind;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        ClearnUIRoot();
        Init();
    }

    /// <summary>
    /// 初始化游戏
    /// </summary>
    private void Init()
    {
        ///服务模块 初始化；
        ResSever resSever = GetComponent<ResSever>();
        resSever.IniResSever();

        NetSvc net = GetComponent<NetSvc>();
        net.InitSvc();

        AudioSer audioSer = GetComponent<AudioSer>();
        audioSer.IniAudioSer();

        ///业务系统 初始化；
        LoginSystem loginSystem = GetComponent<LoginSystem>();
        loginSystem.IniSys();

        ///载入登陆场景：
        loginSystem.EnterLogin();
        
    }

    private void ClearnUIRoot()
    {
        Transform canvas = transform.Find("Canvas");
        for (int i = 0; i < canvas.childCount; i++)
        {
            canvas.GetChild(i).gameObject.SetActive(false);
        }

        dynamicWind.SetWindState();
    }

    public static void AddTips(string tips)
    {
        Instance.dynamicWind.AddTip(tips);
    }
}
