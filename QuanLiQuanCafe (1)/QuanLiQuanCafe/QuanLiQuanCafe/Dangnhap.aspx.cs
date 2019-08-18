using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLiQuanCafe
{
    public partial class Dangnhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDangnhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cao Khac Huy\Downloads\QuanLiQuanCafe (1)\QuanLiQuanCafe\QuanLiQuanCafe\App_Data\Cafe.mdf;Integrated Security=True");
            try
            {
                conn.Open();
                string tendangnhap = txtTendangnhap.Text;
                string matkhau = txtMatkhau.Text;
                string sql = "SELECT*FROM DangNhap WHERE Tendangnhap='" + tendangnhap + "' and Matkhau='" + matkhau + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader da = cmd.ExecuteReader();
                if(da.Read()== true)
                {
                    Response.Redirect("QuanLiNhanVien.aspx");
                }
                else
                {
                    Response.Write("Nhập tên đăng nhập hoặc mật khẩu sai?");
                }
                
            }
            catch(Exception)
            {
                Response.Write("Lỗi kết nối");
            }
        }
    }
   }
    
