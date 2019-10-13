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

    private CacheSvc cacheSvc;
    public void Init()
    {
        cacheSvc = CacheSvc.Instance;
        PECommon.Log("Login System Init Done");
    }

    public void ReqLogin(MessagePack messagePack)
    {
        ReqLogin data = messagePack.gameMessage.reqLogin;
        ///账号是否上线；
          GameMessage gameMessage = new GameMessage
          {
              cmd = (int)CMD.RspLogin, reqLogin = new ReqLogin { }
          };
        ///已经上线：返回错误消息；
        if (cacheSvc.IsAccountOnline(data.account))
        {
            gameMessage.err = (int)ErrorCode.AccountIsOnline;
        }
        else
        {
        ///未上线：账号存在，检测密码，不存在，创建账户；
        ///回应客户端；
        ///

        }
        
       


        messagePack.serverSession.SendMsg(gameMessage);
    }

}
