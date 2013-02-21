<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WCFTest._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnSVRef" runat="server" Text="服务引用" OnClick="btnSVRef_Click" />
        <asp:Button ID="btnWebRef" runat="server" Text="Web引用" OnClick="btnWebRef_Click" />
        <asp:Button ID="btnASMXWebRef" runat="server" Text="asmx WebRef" OnClick="btnASMXWebRef_Click" />
        <asp:Button ID="btnAsmxSVRef" runat="server" Text="AsmxSVRef" OnClick="btnAsmxSVRef_Click" /><input
            id="Button1" type="button" value="button" onclick="getsv();" />
        <div id="result">
        </div>

        <script type="text/javascript">
            function getsv() {
                $.ajax({
    contentType:"html",
    data:"",
    url: "http://localhost:8003/webservice1.asmx/HelloWorld",
    success:function(msg){
        alert(msg);
}
})
                    $.ajax(
                    {
                        type: "POST",
                        contentType: "application/json;utf-8",
                        data:"",
                        url: "http://localhost:8003/webservice1.asmx/HelloWorld",
                        success: function(msg) {
                        //var json = eval('(' + msg + ')');
                            alert(msg);

                        }
                    }
                    )
                    $.ajax(
                    {
                        type: "POST",
                        contentType: "application/json;utf-8",
                        data:"",
                        url: "http://localhost:8003/service1.svc/GetData",
                        success: function(msg) {
                        //var json = eval('(' + msg + ')');
                            alert(msg);

                        }
                    }
                    )
                }
        </script>

    </div>
    </form>
</body>
</html>
