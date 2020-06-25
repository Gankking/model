<%@ Page Language="C#" AutoEventWireup="true" CodeFile="can.aspx.cs" Inherits="can" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="http://code.jquery.com/jquery-2.1.4.min.js"></script>
    <script src="https://cdn.bootcss.com/html2canvas/0.5.0-beta4/html2canvas.min.js"></script>
</head>
<body>
    <div class="container">
        <%--NOTE:海报生成页面--%>
        <div class="page-haibao page-hide" style="width: 750px; height: 1206px;">
            <div class="abs haibao haibao-bg">sdfdf</div>
            <div class="abs haibao-text haibao-nickname">sdfsdf</div>
            <div class="abs haibao-texthaibao-time">fsdf</div>
            <div class=" abs haibao-text haibao-address">sdfsdf</div>
            <div class=" abshaibao-text haibao-vs">sdfsdf</div>
            <div class=" abshaibao-text haibao-team">fdsfsdf</div>
            <div id=" code" style="width: 150px; height: 150px; position: absolute; bottom: 35px; right: 50px;"></div>
        </div>

        <%--海报结束页面--%>
        <div class="page page-haibao-over">
            <div class="bg mask"></div>
            <div class="content">
                <img src="" alt="" style="width: 595px; height: 948px; top: 36px;" id="haibao" class="absh-centen" />
            </div>
        </div>
    </div>
</body>
</html>
<script>
    html2canvas($('.page-haibao').get(0), {   //$('.page-haibao').get(0)相当于doucument.getEelementsByClassName
        // ("page-haibao")，该参数是以需要html2canvas以.page-haibao标签为
        //画布，该画图是.container下的设计图的宽高，
        useCORS: true
    }).then((canvas) => {
        var dataURL = canvas.toDataURL('image/png');     //保存 html2canvas生成图片的路径dataURL 。
        $('#haibao').attr('src', dataURL);                              //将图片保存在#haibao标签图片里面。
    })
</script>
