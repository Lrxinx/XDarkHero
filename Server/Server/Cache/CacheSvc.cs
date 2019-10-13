using System.Collections.Generic;

public class CacheSvc
{
    private static CacheSvc instance;
    public static CacheSvc Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CacheSvc();
            }

            return instance;
        }
    }

    Dictionary<string, ServerSession> onLineAccountDic = new Dictionary<string, ServerSession>();
    public void Init()
    {
        PECommon.Log("CacheSvc System Init Done");
    }

    public bool IsAccountOnline(string account)
    {
        return onLineAccountDic.ContainsKey(account);
    }

}