using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DangNhap
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ta sẽ tạo mot tep de nhap session
            string ten = Session["Username"].ToString();
            //viết lệnh xuất ra màn hình thông báo
            Response.Write("Chào bạn: " + ten + "đang đăng nhập!");

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Application.Remove("Username");
            Application.Remove("Password");
            Response.Redirect("Default.aspx");
        }

        protected void lbtnPageLoad_Click(object sender, EventArgs e)
        {

        }
    }
}