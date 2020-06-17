using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtname.Text = "1";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Dictionary<string, object> dic = new Dictionary<string, object>();
        dic.Add("name", "1");
        dic.Add("name", "1");
        dic.Add("name", "1");
    }
}