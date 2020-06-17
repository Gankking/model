<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="/Scripts/jquery-1.6.4.js"></script>
    <script src="/Scripts/jquery.signalR-2.2.0.js"></script>
    <script src="/signalr/js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
<script>
    $(function () {
        // Reference the auto-generated proxy for the hub.
        var log = $.connection.logHub;
        console.log(log);
        // Create a function that the hub can call back to display messages.
        log.client.addNewMessageToPage = function (name, message) {
            console.log(name);
            console.log(message);
            // Add the message to the page.
            if (name === "Info") {
                $('#container').append('<p style="color:green;">' + message + '</p>');
            } else {
                $('#container').append('<p style="color:red;">' + message + '</p>');
            }
        };
        // Start the connection.
        $.connection.hub.start().done();
    });
</script>
