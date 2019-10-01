using PENet;

public enum LogType
{
    Log=0,
    Warn=1,
    Error=2,
    Info=3,
}

public class PECommon
{
    public static void Log(string msg="",LogType logType = LogType.Log)
    {
        LogLevel level = (LogLevel)logType;
        PETool.LogMsg(msg, level);
    }
}

