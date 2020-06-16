using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// LogHelper 的摘要说明
/// </summary>
public class LogHelper
{
    public static void WriteLog(Log log)
    {
        string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string _watherFilePath = Path.Combine(dir, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
        if (!File.Exists(_watherFilePath))
        {
            File.Create(_watherFilePath).Close();
        }
        FileSystemWatcherSingle wather = FileSystemWatcherSingle.CreateInstance();
        wather.MyQueue.Enqueue(log);
        File.AppendAllText(_watherFilePath, string.Format("{0} {1}\r\n{2}", log.Type.ToString(), log.Dt, log.Content));
    }
}