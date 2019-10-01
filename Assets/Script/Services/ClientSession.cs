using PENet;
using PEProtocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClientSession : PESession<GameMessage>
{
    protected override void OnConnected()
    {
        PETool.LogMsg("Client Connect");
    }

    protected override void OnReciveMsg(GameMessage msg)
    {
        PETool.LogMsg("Client Req: " + msg.text);
    }

    protected override void OnDisConnected()
    {
        PETool.LogMsg("Client DisConnect");
        
    }
}
