using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR.Hubs;


[HubName("logHub")]
public class LogHub : Hub
{
    private FileSystemWatcherSingle fileWather;
    public void Send(string name, string message)
    {
        // Call the addNewMessageToPage method to update clients.
        Clients.All.addNewMessageToPage(name, message);
    }

    public LogHub()
    {
        fileWather = FileSystemWatcherSingle.CreateInstance();
        fileWather.wather.Changed += wather_Changed;
        fileWather.wather.Created += wather_Created;
    }

    void wather_Created(object sender, System.IO.FileSystemEventArgs e)
    {
        this.Send("system", "创建文件:" + e.Name);
    }

    void wather_Changed(object sender, System.IO.FileSystemEventArgs e)
    {
        while (fileWather.MyQueue != null && fileWather.MyQueue.Count > 0)
        {
            Log log = fileWather.MyQueue.Dequeue();
            if (log != null)
            {
                this.Send(log.Type.ToString(), JsonConvert.SerializeObject(log));
            }
        }
    }
}
