<%@ WebHandler Language="C#" Class="getWebFileToBase64" %>

using System;
using System.Web;
using System.IO;
using System.Net;

public class getWebFileToBase64 : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string url = context.Request["url"] == null ? "" : context.Request["url"].ToString();
        string strBase64 = "";
        if (url != "")
        {
            strBase64 = GetBase64String(url);
        }
        context.Response.ContentType = "text/plain";
        context.Response.Write(strBase64);
    }

    public string GetBase64String(string Url)
    {
        Stream stream = WebRequest.Create(Url).GetResponse().GetResponseStream();
        MemoryStream ms = new MemoryStream();
        stream.CopyTo(ms);
        //System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
        //img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        byte[] buff = new byte[ms.Length];
        ms.Position = 0;
        ms.Read(buff, 0, (int)ms.Length);
        ms.Close();
        return Convert.ToBase64String(buff);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}