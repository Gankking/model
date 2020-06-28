<%@ Page Language="C#" AutoEventWireup="true" CodeFile="amrjsTest.aspx.cs" Inherits="amrjsTest" %>

<!DOCTYPE html>
<html>
<head>
    <title>arm play</title>
    <script src="/Scripts/amrnb.js"></script>
    <script src="/Scripts/amrplayer.js"></script>
    <script type="text/javascript">
        //var player = new AmrPlayer('./amr-player-master/1562307681788.amr');
        //var player = new AmrPlayer('./amr-player-master/13703524514_20190628184029.amr');
        var player = new AmrPlayer('http://www.signalr.test/Audio/mario.amr');

        // chrome 禁止自动播放 改用手动播放
        //player.play();        
    </script>
</head>
<body>
    <h1>amr play</h1>

    <button id="unmuteButton">start play</button>
    <script>
        unmuteButton.addEventListener('click', function () {
            player.play();
        });
    </script>
</body>
</html>
