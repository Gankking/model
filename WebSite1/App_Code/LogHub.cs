using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

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
        //fileWather = FileSystemWatcherSingle.CreateInstance();
        //fileWather.wather.Changed += wather_Changed;
        //fileWather.wather.Created += wather_Created;
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

    /// <summary>
    /// 发送给指定组
    /// </summary>
    public void CallGroup(string fromname, string content)
    {
        string groupname = Context.QueryString["groupname"]; //获取客户端发送过来的用户名
                                                             //根据username获取对应的ConnectionId
        Clients.Group(groupname).show(fromname + ":" + content);
    }

    //连接成功
    public override Task OnConnected()
    {
        string groupname = Context.QueryString["groupname"]; //获取客户端发送过来的用户名
        JoinGroup(groupname);//加入群组
        return base.OnConnected();
    }
    public Task JoinGroup(string groupName)
    {
        return Groups.Add(Context.ConnectionId, groupName);
    }

    //断开连接
    public override Task OnDisconnected(bool stopCalled)
    {
        string groupname = Context.QueryString["groupname"]; //获取客户端发送过来的用户名
        LeaveGroup(groupname);//移除组
        return base.OnDisconnected(true);
    }
    public Task LeaveGroup(string groupName)
    {
        return Groups.Remove(Context.ConnectionId, groupName);
    }

    /// <summary>
    /// 示例
    /// </summary>
    /// <param name="content">广播的内容</param>
    public void Hello(string content)
    {
        Clients.All.show(content); //调用了前端js上定义的hello方法
    }

    /// <summary>
    /// 推送给自己
    /// </summary>
    /// <param name="content"></param>
    public void CallSelf(string content)
    {
        Clients.Caller.show(content);
    }
    /// <summary>
    /// 发送给指定连接
    /// </summary>
    /// <param name="toName"></param>
    /// <param name="content"></param>
    public void CallOne(string toName, string content)
    {
        //根据username获取对应的ConnectionId
        var connectionId = HttpContext.Current.Application[toName].ToString();
        Clients.Client(connectionId).show(content);
    }

    /// <summary>
    /// 初次连接
    /// </summary>
    /// <returns></returns>
    //public override Task OnConnected()
    //{
    //    string username = Context.QueryString["userName"]; //获取客户端发送过来的用户名
    //    string connectionId = Context.ConnectionId;
    //    HttpContext.Current.Application.Add(username, connectionId); //存储关系
    //    return base.OnConnected();
    //}

    //所有连接的客户端
    //Clients.All.show(content);

    //仅调用的客户端
    //Clients.Caller.show(content);

    //除调用客户端之外的所有客户端
    //Clients.Others.show(content);

    //特定的客户端标识的连接 id
    //Clients.Client(Context.ConnectionId).show(content);

    //所有连接的客户端除外指定客户端，由连接 ID 标识
    //Clients.AllExcept(connectionId1, connectionId2).show(content);

    //指定组中的所有连接的客户端
    //Clients.Group(groupName).show(content);
    //Clients.Group(groupName, connectionId1, connectionId2).show(content);

    //所有连接的客户端指定组中除调用客户端
    //Clients.OthersInGroup(groupName).show(content);

    //所有客户端和组列表中的连接 Id
    //Clients.Clients(ConnectionIds).show(content);

    //组的列表。
    //Clients.Groups(GroupIds).show(content);

    //按名称的用户
    //Clients.Client(username).show(content); //这里的username我还没理解是怎么创建的

    //（在 SignalR 2.1 中引入） 的用户名称的列表。
    //Clients.Users(new string[] { "myUser", "myUser2" }).show(content)
}
