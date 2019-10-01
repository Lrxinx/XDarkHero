using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResSever : MonoBehaviour
{
    public static ResSever Instance;
    private Dictionary<string, AudioClip> audioDic = new Dictionary<string, AudioClip>();

    private List<string> firstName = new List<string>();
    private List<string> boyName = new List<string>();
    private List<string> girlName = new List<string>();


    /// <summary>
    /// Initialize ResSever；
    /// </summary>
    public void IniResSever()
    {
        IniRandomNameCfgs();
        Instance = this;
    }

    /// <summary>
    /// Async loading Scene:
    /// </summary>

    private Action LoadProgram;
    public void AsyncLoadScene(string sceneName,Action LoadFunc)
    {
        GameRoot.Instance.LoadingPanle.SetWindState();       

        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(sceneName);
        LoadProgram = () =>
        {
            float loadPro = sceneLoad.progress;
            GameRoot.Instance.LoadingPanle.SetPrograss(loadPro);
            if (loadPro == 1)
            {
                if (LoadFunc != null)
                    LoadFunc();
                LoadProgram = null;
                sceneLoad = null;
                GameRoot.Instance.LoadingPanle.SetWindState(false);
                GameRoot.AddTips("Scene Load Succeed!");
            }
        };
    }

    private void Update()
    {
        if (LoadProgram != null)
            LoadProgram();
    }



    /// <summary>
    /// 加载声音资源
    /// </summary>
    /// <param name="path">路径</param>
    /// <param name="cache">是否缓存</param>
    /// <returns></returns>
    public AudioClip LoadAudoClip(string path,bool cache)
    {
        AudioClip audioClip = null;
        if(!audioDic.TryGetValue(path,out audioClip))
        {
            audioClip = Resources.Load<AudioClip>(path);
            if (cache)
                audioDic.Add(path, audioClip);
        }
        return audioClip;
    }

    #region Initialize Configuration File

    private void IniRandomNameCfgs()
    {
        TextAsset XMLAsset = Resources.Load<TextAsset>(PathDefine.RandomNameCfg);

        if (XMLAsset)//File Exist
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(XMLAsset.text);

            /// 获得根节点 root 下面的所有子节点
            XmlNodeList nodeList = doc.SelectSingleNode("root").ChildNodes;
            
            ///遍历所有子节点；
            foreach (XmlElement element in nodeList)
            {
                if (element.GetAttributeNode("ID") == null)
                    continue;
                int ID = Convert.ToInt32(element.GetAttributeNode("ID").InnerText);///每个节点的ID；

                foreach (XmlElement item in element.ChildNodes)
                {
                    switch (item.Name)
                    {
                        case "surname":
                            firstName.Add(item.InnerText);
                            break;
                        case "man":
                            boyName.Add(item.InnerText);
                            break;
                        case "woman":
                            girlName.Add(item.InnerText);
                            break;                            
                    }
                }

            }
        }
    }

    #endregion

    public string GetRandomName(bool boy = true)
    {
        string surname = firstName[Tools.RandomInt(0, firstName.Count)];
        string lastName;
        if (boy)
            lastName = boyName[Tools.RandomInt(0, boyName.Count)];
        else
            lastName = girlName[Tools.RandomInt(0, girlName.Count)];
        return surname + lastName;
    }
}
