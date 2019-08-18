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
    public partial class QuanLiNhanVien : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString;
        // đổ dữ liệu lên GridView
        private void LayDuLieuVaoGridView()
        {
            nv NV = new nv();
            grVQuanLi.DataSource = NV.LayNV();
            grVQuanLi.DataSourceID = null;
            grVQuanLi.DataBind();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                LayDuLieuVaoGridView();
            }
            
            
        }


        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dangnhap.aspx");
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            //lấy các giá trị từ giao diện
            qlnv nv = LayDuLieuTuForm();

            nv NV = new nv();

            //Kiểm tra username này đã tồn tại trong CSDL chưa
            bool exist = NV.KiemtraNV(nv.MaNV);

            if (exist)
            {
                lblThongBao.Text = "Mã nhân viên đã tồn tại";
            }
            else
            {
                //thực hiện ghi dữ liệu xuống
                bool result = NV.ThemNV(nv);
                if (result)
                {
                    lblThongBao.Text = "Thêm thành công!";
                    //hiển thị dữ liệu lên GridView
                    LayDuLieuVaoGridView();
                }
                else
                {
                    lblThongBao.Text = "Có lỗi.Vui lòng thử lại sau";
                }
            }

        }
        private qlnv LayDuLieuTuForm()
        {
            string maNV = txtMaNV.Text;
            string tenNV = txtTenNV.Text;
            string email = txtEmail.Text;
            string diaChi = txtDiaChi.Text;
            bool gioiTinh = Boolean.Parse(rdGioiTinh.SelectedValue);
            string chucVu = ddlChucvu.SelectedValue;  
            string sdt = txtSDT.Text;

            string ngaySinh = txtNgaysinh.Text;
            
            qlnv nv = new qlnv
            {
                MaNV = maNV,
                TenNV = tenNV,
                Email = email,
                GioiTinh = gioiTinh,
                ChucVu = chucVu,
                SDT = sdt,
                DiaChi = diaChi,
                NgaySinh = ngaySinh,
                
            };
            return nv;
        }
        private void DoDuLeuVaoCacTruong(qlnv nv)
        {
            txtMaNV.Text = nv.MaNV;
            txtTenNV.Text = nv.TenNV;
            rdGioiTinh.SelectedIndex = nv.GioiTinh ? 0:1;
            txtDiaChi.Text = nv.DiaChi;
            txtEmail.Text = nv.Email;
            txtNgaysinh.Text = nv.NgaySinh;
            txtSDT.Text = nv.SDT;
            txtEmail.Text = nv.Email;
            //
            if (nv.GioiTinh== false)
                rdGioiTinh.SelectedIndex = 0;
            else
                rdGioiTinh.SelectedIndex = 1;
        }


        protected void grVQuanLi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maNV = grVQuanLi.SelectedRow.Cells[0].Text;

            nv NV = new nv();
            qlnv nv= NV.LayMaNV(maNV);
            if(nv !=null)
            {
                DoDuLeuVaoCacTruong( nv);
            }

                
            }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            nv NV = new nv();
            bool kq = NV.XoaNV(txtMaNV.Text);
            if (kq)
            {
                lblThongBao.Text = "Đã xóa thành công";
                LayDuLieuVaoGridView();
            }
            else
            {
                lblThongBao.Text = "Có lỗi";
            }
        }
     }
 }

        
     
