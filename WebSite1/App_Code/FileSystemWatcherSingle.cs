using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// FileSystemWatcherSingle 的摘要说明
/// </summary>
public class FileSystemWatcherSingle
{
    public FileSystemWatcher wather;
    private static FileSystemWatcherSingle _instance;
    private static readonly object _objLock = new object();
    public Queue<Log> MyQueue;
    private string _watherFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
    private FileSystemWatcherSingle()
    {
        if (MyQueue == null)
        {
            MyQueue = new Queue<Log>();
        }
        if (wather == null)
        {
            wather = new FileSystemWatcher();
            if (!Directory.Exists(_watherFolderPath))
            {
                Directory.CreateDirectory(_watherFolderPath);
            }
            wather.Path = _watherFolderPath;
            wather.EnableRaisingEvents = true;
        }
    }

    public static FileSystemWatcherSingle CreateInstance()
    {
        if (_instance == null)
        {
            lock (_objLock)
            {
                if (_instance == null)
                {
                    _instance = new FileSystemWatcherSingle();
                }
            }
        }
        return _instance;
    }
}