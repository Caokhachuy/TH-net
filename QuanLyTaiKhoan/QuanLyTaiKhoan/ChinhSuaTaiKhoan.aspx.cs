using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyTaiKhoan
{
    public partial class ChinhSuaTaiKhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userName = Request.QueryString["uname"];
                UserDAO userDao = new UserDAO();
                User user = userDao.GetUserByUserName(userName);
                if (user != null)
                {
                    DoDuLieuVaoForm(user);
                }
            }
        }

        public void DoDuLieuVaoForm(User user)
        {
            txtTenDangNhap.Text = user.UserName;
            txtMatKhau.Text = user.Password;
            txtTen.Text = user.FirstName;
            txtTenDem.Text = user.LastName;
            txtEmail.Text = user.Email;
            txtDiaChi.Text = user.Address;
            RadioButtonList1.SelectedIndex = user.Gender ? 0 : 1;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            User user = LayDuLieuTuForm();
            bool exist = userDAO.UpdateUser(user);
            UploadAvatar(user.Avarta);
            if (exist)
            {
                lblThongBao.Text = "Cập nhập thông tin thành công";
            }
            else
                lblThongBao.Text = "Đã xảy ra lỗi";
            
        }
        private void UploadAvatar(string fileName)
        {
            string filePath = "~/images/" + fileName;
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath(filePath));
            }
        }
        public User LayDuLieuTuForm()
        {
            User user = new User()
            {
                UserName=txtTenDangNhap.Text,
                Password=txtMatKhau.Text,
                FirstName=txtTen.Text,
                LastName=txtTenDem.Text,
                Email=txtEmail.Text,
                Gender=Boolean.Parse(RadioButtonList1.SelectedValue),
                Address=txtDiaChi.Text,
                Avarta=FileUpload1.FileName.ToString()
            };
            return user;
        }
    }
}