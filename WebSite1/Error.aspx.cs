using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {

            //__VIEWSTATE=/wEPDwUKMTA5MTg4MjI2MmQYAQUeX19Db250cm9sc1JlcXVpcmVQb3N0QmFja0tleV9fFgcFCGNoa0NhbiQwBQhjaGtDYW4kMQUIY2hrQ2FuJDIFCGNoa0NhbiQzBQhjaGtDYW4kNAUIY2hrQ2FuJDUFCGNoa0NhbiQ1crwIyn83mmzTszPfal8FdQdsb7/XsyYtqr1d/0jMOg0=&txtname=&chkCan$0=1&chkCan$3=4&btnSave=提交&__VIEWSTATEGENERATOR=CA0B0334&__EVENTVALIDATION=/wEdAAmUMlPvPW7at4EEQ7onYFA5VCDn2pfngd5PSl9R1fd0WPJFy63+9ZzQpNxcrxQlNvKM9QjXdjl6gZyK6HuD7nfujQpq8siiTKPTUhvZmGXF41fsNRiDvxOoS1Hd2L52NSXEzBYsF9/b11tiGE60bz6X1B3RAYV61vaeBL4T3YJMlJZYgDymPir0Zp4mFYzbkIg+yP5WkK8YalI9U+coVZduMqDF/7YrNaH1NuqZsN9RaQ==
            byte[] byts = new byte[Request.InputStream.Length];
            Request.InputStream.Read(byts, 0, byts.Length);
            string req = System.Text.Encoding.Default.GetString(byts);
            req = Server.UrlDecode(req);

            Response.Write("Request.Filter.ToString()" + " <br />" + Request.Filter.ToString() + "<hr />");
            Response.Write("Request.Form" + " <br />" + JsonConvert.SerializeObject(Request.Form) + "<hr />");//["__VIEWSTATE","txtname","chkCan$0","chkCan$3","btnSave","__VIEWSTATEGENERATOR","__EVENTVALIDATION"]

            Response.Write("Request.Form" + "<br />");
            foreach (string formItem in Request.Form)
            {
                if (formItem.IndexOf("__") == -1)
                {
                    Response.Write(formItem + "=" + Request.Form[formItem] + "<br />");
                }
            }
            Response.Write("<hr />");

            Response.Write("Request.InputStream" + " <br />" + req + "<hr />");
            Response.Write("Request.QueryString" + " <br />" + JsonConvert.SerializeObject(Request.QueryString) + "<hr />");
            Response.Write("Request.RequestContext.ToString()" + " <br />" + Request.RequestContext.ToString() + "<hr />");
            Request.SaveAs(Server.MapPath("~HtmlPage.html"), true);
            Response.Write("Request" + "<br />" + JsonConvert.SerializeObject(Request.ToString()) + "<hr />");
        }
    }
}