using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Log 的摘要说明
/// </summary>
public class Log
{
    public Log()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public LogType Type { get; set; }

    public string Dt { get; set; }

    public string Content { get; set; }
}

public enum LogType
{
    Info = 1,
    Error = 0
}