using PENet;
using PEProtocol;
using System;
using System.Collections;
using System.Collections.Generic;

public class NetworkService
{
    private static NetworkService instance;
    public static NetworkService Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new NetworkService();
            }

            return instance;
        }
    }
    

    private static readonly string obj = "Lock";
    private Queue<MessagePack> msgPackQue = new Queue<MessagePack>();

    public void Init()
    {
        PESocket<ServerSession, GameMessage> server = new PESocket<ServerSession, GameMessage>();
        server.StartAsServer(SrvCfg.srvIP, SrvCfg.srvPort);

       PECommon.Log("NetServer Init Done");
    }
   
    public void AddmsgQue(ServerSession serverSession,GameMessage gameMessage)
    {
        lock (obj)
        {
            msgPackQue.Enqueue(new MessagePack(serverSession,gameMessage));
        }
    }

    public void Update()
    {
        if (msgPackQue.Count > 0)
        {
            PECommon.Log($"PackCount: {msgPackQue.Count}");
            lock (obj)
            {
                MessagePack messagePack = msgPackQue.Dequeue();
                HandOutMsg(messagePack);
            }
        }
    }

    private void HandOutMsg(MessagePack messagePack)
    {
        switch ((CMD)messagePack.gameMessage.cmd)
        {
            case CMD.ReqLogin:
                LoginSys.Instance.ReqLogin(messagePack);
                break;
            default:
                break;
        }
    }
}

public class MessagePack
{
    public ServerSession serverSession;
    public GameMessage gameMessage;

    public MessagePack(ServerSession serverSession, GameMessage gameMessage)
    {
        this.serverSession = serverSession;
        this.gameMessage = gameMessage;
    }

}