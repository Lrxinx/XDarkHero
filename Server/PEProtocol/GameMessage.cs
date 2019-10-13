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
        public PlayerData playerData;
    }

    [Serializable]
    public class PlayerData
    {
        public int id;
        public string name;
        public int lv;
        public int exp;
        public int power;
        public int diamond;
        public int coin;
    }

    public enum CMD
    {
        None = 0,
        ReqLogin = 101,
        RspLogin = 102
    }

    public enum ErrorCode
    {
        None = 0,
        AccountIsOnline,
    }

    public class SrvCfg
    {
        public const string srvIP = "127.0.0.1";
        public const int srvPort = 17666;
    }
}
