using PEProtocol;
using PENet;
public class ServerSession : PESession<GameMessage>
{
    protected override void OnConnected()
    {
        PECommon.Log("Client Connect");
        SendMsg(new GameMessage { text = "Welcome To Connect." });
    }

    protected override void OnReciveMsg(GameMessage msg)
    {
        PECommon.Log("RcvPack: " + ((CMD)msg.cmd).ToString());
        SendMsg(new GameMessage { text = "SrvRsp:" + msg.text });

        NetworkService.Instance.AddmsgQue(msg);
    }

    protected override void OnDisConnected()
    {
        PECommon.Log("Client DisConnect");

    }
}

