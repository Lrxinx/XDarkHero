using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PENet;
using PEProtocol;

public class NetSvc : MonoBehaviour
{
    public static NetSvc Instance;
    PESocket<ClientSession, GameMessage> client;

    public void InitSvc()
    {        
        Instance = this;

        client = new PESocket<ClientSession, GameMessage>();
        client.SetLog(true, (string msg, int lv) =>
         {
             switch (lv)
             {
                 case 0:
                     msg = "Log:" + msg;
                     Debug.Log(msg);
                     break;
                 case 1:
                     msg = "Warning:" + msg;
                     Debug.LogWarning(msg);
                     break;
                 case 2:
                     msg = "Error:" + msg;
                     Debug.LogError(msg);
                     break;
                 case 3:
                     msg = "Info:" + msg;
                     Debug.Log(msg);
                     break;
                 default:
                     break;
             }
         });
        client.StartAsClient(SrvCfg.srvIP, SrvCfg.srvPort);


        Debug.Log("Init NetSvc...");
    }

    public void SendMessage(GameMessage msg)
    {
        if (client.session != null)
            client.session.SendMsg(msg);
        else
        {
            GameRoot.AddTips("Server not connected!");
            InitSvc();
        }
    }

    public void Update()
    {
        
    }
}
