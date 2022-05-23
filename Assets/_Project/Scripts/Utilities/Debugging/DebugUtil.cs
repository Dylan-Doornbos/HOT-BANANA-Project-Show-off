using UnityEngine;

public static class DebugUtil
{
#if UNITY_EDITOR
    public static void Log(string pMessage, LogType pLogType)
    {
        switch (pLogType)
        {
            case LogType.NORMAL:
                Debug.Log(pMessage);
                break;
            case LogType.WARNING:
                Debug.LogWarning(pMessage);
                break;
            case LogType.ERROR:
                Debug.LogWarning(pMessage);
                break;
        }
    }
#else
    public static void Log(string pMessage, LogType pLogType)
    {

    }
#endif
}

public enum LogType
{
    NORMAL,
    WARNING,
    ERROR
}
