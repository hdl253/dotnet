<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GridView._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="gvTemp" runat="server" onrowediting="gvTemp_RowEditing">
        <Columns>
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:TextBox ID="txta" runat="server" Text='<%# Eval("a") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderTemplate>
                    a
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbla" runat="server" Text='<%# Eval("a") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="b" HeaderText="b" SortExpression="b" />
            <asp:CommandField HeaderText="修改" ShowEditButton="True" ShowHeader="True" />
        </Columns>
    </asp:GridView>
    
    </div>
    </form>
</body>
</html>
