using PEProtocol;

public class LoginSys
{
    private static LoginSys instance;
    public static LoginSys Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LoginSys();
            }

            return instance;
        }
    }


    public void Init()
    {
        PECommon.Log("Login System Init Done");
    }

    public void RepLogin(MessagePack messagePack)
    {
        ///账号是否上线；
        ///已经上线：返回错误消息；
        ///未上线：账号存在，检测密码，不存在，创建账户；
        ///回应客户端；
        GameMessage gameMessage = new GameMessage { cmd = (int)CMD.RspLogin, reqLogin = new ReqLogin { } };      

        messagePack.serverSession.SendMsg(gameMessage);
    }

}
