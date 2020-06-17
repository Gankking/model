using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class createLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void start_Click(object sender, EventArgs e)
    {
        var dempHubContext = GlobalHost.ConnectionManager.GetHubContext<LogHub>();
        for (int i = 1; i< 10; i++) {
            //LogType[] logtypes = { LogType.Info, LogType.Error };
            //Random r = new Random();
            //int index = r.Next(0, 2);
            //LogHelper.WriteLog(new Log { Content = "这是"+i+"次日志", Dt = DateTime.Now.ToString(), Type = logtypes[index] });
            
            dempHubContext.Clients.All.addNewMessageToPage("测试日志", "测试日志,第" + i+"次");

            Thread.Sleep(2000);
        }
    }
}