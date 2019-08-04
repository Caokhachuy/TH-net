<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DangNhap.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:LinkButton ID="lbtnPageLoad" runat="server" OnClick="lbtnPageLoad_Click">Page_Load</asp:LinkButton>
    <div>
    
        <asp:LinkButton ID="lbtnLogout" runat="server" OnClick="LinkButton2_Click" PostBackUrl="~/Default.aspx">LogOut</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
