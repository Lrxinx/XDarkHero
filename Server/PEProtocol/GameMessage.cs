using System;
using PENet;

namespace PEProtocol
{
    [Serializable]
    public class GameMessage:PEMsg
    {
        public ReqLogin reqLogin;
        public RspLogin rspLogin;
        public string text;
    }

    [Serializable]
    public class ReqLogin
    {
        public string account;
        public string password;
    }

    [Serializable]
    public class RspLogin
    {

    }

    public enum CMD
    {
        None = 0,
        ReqLogin = 101,
        RspLogin = 102
    }

    public class SrvCfg
    {
        public const string srvIP = "127.0.0.1";
        public const int srvPort = 17666;
    }
}
