<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dangki.aspx.cs" Inherits="KiemTraGK.dangki" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 311px;
        }
        .auto-style2 {
            width: 311px;
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%;">
            <tr>
                <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label6" runat="server" Text="ĐĂNG KÝ TÀI KHOẢN"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Tài Khoản"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTaiKhoan" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Mật Khẩu"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMatKhau" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Text="Nhập Lại Mật Khẩu"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtNhapLaimk" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label5" runat="server" Text="Họ Tên"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtHoTen" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="btnDangKy" runat="server" OnClick="btnDangKy_Click" Text="Đăng Ký" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Label ID="lblThongBao" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
