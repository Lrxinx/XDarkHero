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
        GameMessage gameMessage = new GameMessage { cmd = (int)CMD.RspLogin, reqLogin = new ReqLogin { } };
        messagePack.serverSession.SendMsg(gameMessage);
    }

}
