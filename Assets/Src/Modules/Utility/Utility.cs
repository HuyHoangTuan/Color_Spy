using System;

using UnityEngine;

public static class Utility
{
    public static void log(params object[] data)
    {
        DateTime currentDateTime = DateTime.Now;
        string dateTimeString = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        string logString = string.Format("[{0}]: ", dateTimeString);
        foreach (object item in data)
        {
            logString += string.Format(" [{0}]", item.ToString());
        }
        
        Debug.Log(logString);
    }
}