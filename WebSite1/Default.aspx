<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>s
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

        <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="提交" />
    </div>
    </form>
</body>
</html>
