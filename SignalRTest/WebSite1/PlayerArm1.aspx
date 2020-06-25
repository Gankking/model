﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlayerArm1.aspx.cs" Inherits="PlayerArm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="/Scripts/jquery-1.6.4.js"></script>
    <script src="/Scripts/voice-2.0.js"></script>
    <script src="/Scripts/audio.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="file" name="" id="upload" value="" onchange="selectFile(this)" />

        <%--第二--%>
        <input type="button" value="play" id="playId"/>
        <input type="button" value="stop" id="stopId"/>

        <%--第三种在线播放--%>
        <input type="button" value="播放在线文件" id="playWebSound" onclick="playWebFile();"/>
    </form>
</body>
</html>
<script>
    // 初始化两个插件
    audiojs.events.ready(function () {
        var as = audiojs.createAll();
    });
    RongIMLib.RongIMVoice.init();

    function selectFile(file) {
        var reader = new FileReader() // 接收选择的amr文件
        reader.readAsDataURL(file.files[0]) // 对amr文件进行转码
        reader.onload = function (f) {
            var base64Str = f.target.result.split(',')[1]  // base64字符串，有兴趣的可以输出来看一看
            RongIMLib.RongIMVoice.play(base64Str); // 直接播放该base64字符串
        }
    }

    function playWebFile() {
        $.ajax({
            url: "/Audio/20131002235427264.amr", // 请求后台，后台把amr文件进行base64编码后直接返回
            dataType: 'text', // 注意：因为是返回base64字符串，所以要用‘text’类型
            success: function (res) {
                res = decodeURIComponent(res);
                console.log(res);
                RongIMLib.RongIMVoice.play(res) // 同样道理，直接播放该base64字符串
            },
            error: function (res) {
                console.log(res)
            }
        })
    }

    //播放
    document.getElementById("playId").onclick = function ()
    {
        // base64Str ： amr 格式的 base64 码，可以用 HTML5 FileReader 或者canvas 进行转换 。 
        var base64Str = "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";
        RongIMLib.RongIMVoice.play(base64Str);
    };
    //暂停
    document.getElementById("stopId").onclick = function () { RongIMLib.RongIMVoice.stop(); };
</script>
