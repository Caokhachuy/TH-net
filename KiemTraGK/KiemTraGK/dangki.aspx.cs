using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KiemTraGK
{
    public partial class dangki : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text.Length > 0 && txtMatKhau.Text.Length > 0 && txtNhapLaimk.Text.Length > 0 && txtHoTen.Text.Length>0 && txtEmail.Text.Length>0)
            {
                if (txtMatKhau.Text == txtNhapLaimk.Text)
                {
                    Session["taikhoan"] = txtTaiKhoan.Text;
                    Session["hoten"] = txtHoTen.Text;
                    Session["email"] = txtEmail.Text;
                    Response.Redirect("HienThi.aspx");
                }
                else
                {
                    lblThongBao.Text = "Mật khẩu nhập lại không khớp";
                }
                
            }
            else
            {
                lblThongBao.Text = "Vui lòng nhập đủ thông tin";

            }
            
        }
    }
}