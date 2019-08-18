using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace QuanLiQuanCafe
{
    public partial class Menu : System.Web.UI.Page
    {
        string connect = ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString;
        Menu2 mn = new Menu2();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DoDuLieuVaoGridView();
            }

        }
        public void DoDuLieuVaoGridView()
        {
            grVMenu.DataSource = mn.LayMenu();
            grVMenu.DataSourceID = null;
            grVMenu.DataBind();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            bool kt = mn.KiemTraHang(txtMahang.Text);
            if (kt)
            {
                lblThongBao.Text = "Hàng đã tồn tại";
            }
            else
            {
                bool kq = mn.ThemHang(txtMahang.Text, txtTenhang.Text, Int32.Parse(txtDonGia.Text));
                if (kq)
                {
                    lblThongBao.Text = "Thêm thành công";
                    DoDuLieuVaoGridView();
                }
                else
                {
                    lblThongBao.Text = "Có lỗi";
                }
            }
        }
        protected void grMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(connect))
            {
                string sql = "select * from Menu where Mahang=@ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", grVMenu.SelectedRow.Cells[1].Text);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtMahang.Text = ((string)dr["Mã hàng"]).ToString();
                    txtTenhang.Text = ((string)dr["Tên hàng"]).ToString();
                    txtDonGia.Text = ((int)dr["Đơn giá"]).ToString();
                }
            }
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            bool kq = mn.XoaHang(txtMahang.Text);
            if (kq)
            {
                lblThongBao.Text = "Đã xóa thành công";
                DoDuLieuVaoGridView();
            }
            else
            {
                lblThongBao.Text = "Có lỗi";
            }
        }
     
        protected void btnTimkiem_Click1(object sender, EventArgs e)
        {
             bool kq = mn.DemTimKiemMatHang(txtMahang.Text);
            if (kq)
            {
                lblThongBao.Text = "";
                grVMenu.DataSource = mn.TimKiemMatHang(txtMahang.Text);
                grVMenu.DataSourceID = null;
                grVMenu.DataBind();
            }
            else
            {
                lblThongBao.Text = "Không có kết quả tìm thấy";
                grVMenu.DataSource = mn.TimKiemMatHang(txtMahang.Text);
                grVMenu.DataSourceID = null;
                grVMenu.DataBind();
            }
        }

        protected void btnDangxuat_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dangnhap.aspx");
        }
    }
}