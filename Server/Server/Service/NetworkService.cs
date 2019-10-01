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
   
    public void AddmsgQue(MessagePack messagePack)
    {
        lock (obj)
        {
            msgPackQue.Enqueue(messagePack);
        }
    }

    public void Update()
    {
        if (msgPackQue.Count > 0)
        {
            PECommon.Log($"PackCount: {msgPackQue.Count}");
            lock (obj)
            {
                MessagePack msg = msgPackQue.Dequeue();
                HandOutMsg(msg);
            }
        }
    }

    private void HandOutMsg(MessagePack messagePack)
    {
        switch ((CMD)messagePack.gameMessage.cmd)
        {
            case CMD.ReqLogin:
                LoginSys.Instance.RepLogin(messagePack);
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