<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="/Scripts/jquery-1.6.4.js"></script>
    <script src="https://cdn.bootcss.com/html2canvas/0.5.0-beta4/html2canvas.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="page_content">
            <asp:Label ID="lblName" runat="server">名字：</asp:Label>
            <asp:TextBox runat="server" ID="txtname"></asp:TextBox>
            <hr />
            <br />
            <asp:Label ID="lblCalen" runat="server">日历：</asp:Label>
            <asp:CheckBoxList runat="server" ID="chkCan">
                <asp:ListItem Value="1">周一</asp:ListItem>
                <asp:ListItem Value="2">周二</asp:ListItem>
                <asp:ListItem Value="3">周三</asp:ListItem>
                <asp:ListItem Value="4">周四</asp:ListItem>
                <asp:ListItem Value="5">周五</asp:ListItem>
                <asp:ListItem Value="6">周六</asp:ListItem>
            </asp:CheckBoxList>

            <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="提交" OnClientClick="return check();" />
        </div>

        <div id="screen_shoot_box">
            <asp:Image runat="server" ID="hiddenShootImg" />
            <asp:HiddenField runat="server" ID="hfimg" />
            <input id="htmltxt" type="text" runat="server" />
            <img src="" alt="" id="screen_shoot_content" class="absh-centen" />
        </div>
    </form>
</body>
</html>
<script>
    function shoot() {
        $(document).ready(function () {
            html2canvas($('#page_content').get(0), {   //$('.page-haibao').get(0)相当于doucument.getEelementsByClassName
                // ("page-haibao")，该参数是以需要html2canvas以.page-haibao标签为
                //画布，该画图是.container下的设计图的宽高，
                useCORS: true
            }).then((canvas) => {
                var dataURL = canvas.toDataURL('image/png');     //保存 html2canvas生成图片的路径dataURL 。 image/jpg image/png
                //$('#screen_shoot_content').attr('src', dataURL);                              //将图片保存在#haibao标签图片里面。
                $('#hiddenShootImg').attr('src', dataURL);
            });

            //if($('#hiddenShootImg').attr('src')!=""){
            //    $("#hfimg").val = $('#hiddenShootImg').attr('src');
            //}
        })
    }
    function check() {
        shoot();
        return false;
    }
</script>
