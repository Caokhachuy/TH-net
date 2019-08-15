using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KiemTraGK
{
    public partial class HienThi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTaiKhoan.Text = "Tên tài khoản: " + Session["taikhoan"];
            lblHoTen.Text = "Họ Tên: " + Session["hoten"];
            lblEmail.Text = "Email: " + Session["email"];
        }
    }
}