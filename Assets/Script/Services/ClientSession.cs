using PENet;
using PEProtocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClientSession : PESession<GameMessage>
{
    protected override void OnConnected()
    {
        GameRoot.AddTips("服务器链接成功");
        PETool.LogMsg("Client Connect");

    }

    protected override void OnReciveMsg(GameMessage msg)
    {
        PETool.LogMsg("Client Req: " + msg.text);
        PETool.LogMsg("Rcv Pack CMD: " + ((CMD)msg.cmd).ToString());
    }

    protected override void OnDisConnected()
    {
        GameRoot.AddTips("服务器链接断开");
        PETool.LogMsg("DisConnect To Server");        
    }
}
