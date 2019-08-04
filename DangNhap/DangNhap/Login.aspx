<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DangNhap.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lbDangNhap" runat="server" Font-Size="Larger" Text="Đăng Nhập"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lbUserName" runat="server" Text="User Name"></asp:Label>
        :<asp:TextBox ID="txtUsername" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbPassword" runat="server" Text="Password"></asp:Label>
        :<asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;
        <asp:Button ID="btnDangNhap" runat="server" OnClick="btnDangNhap_Click" Text="Đăng nhập" />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
