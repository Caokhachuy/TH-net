using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DangNhap
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            //tạo 2 biến lưu username và password
            string tendn, mk;
            //lấy dữ liệu nhập vào textbox để đưa vào 2 biến  trên
            tendn = Request.Form["txtUsername"];
            mk = Request.Form["txtPassword"];
            //tên đăng nhập là admin, mật khẩu là 1234
            if (tendn == "admin" && mk == "1234")
            {
                //tạo sesion kết nối dữ liệu lên
                Session["Username"] = txtUsername.Text;
                //chuyển hướng đến trang default
                Response.Redirect("default.aspx");
            }
            else
            {
                //nếu sai tên đăng nhập hoặc mật khẩu thì sẽ hiển thị thông báo
                Response.Write("Nhập mật khẩu hoặc tên đăng nhập sai!");
            }
        }
    }
}