using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResSever : MonoBehaviour
{
    public static ResSever Instance;

    /// <summary>
    /// 初始化 ResSever；
    /// </summary>
    public void IniResSever()
    {
        Instance = this;
    }

    /// <summary>
    /// 异步加载 场景；
    /// </summary>
    public void AsyncLoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }


}
