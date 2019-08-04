using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyTaiKhoan
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LayDuLieuVaoGridView();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            User user = LayDuLieuTuForm();
            UserDAO userDAO = new UserDAO();
            bool exist = userDAO.CheckUser(user.UserName);
            if (exist)
            {
                lblMessage.Text = "Tài khoản đã tồn tại";
            }
            else
            {
                bool result = userDAO.Insert(user);
                UploadAvatar(user.Avarta);
                if (result)
                {
                    lblMessage.Text = "Thêm Thành công";
                    LayDuLieuVaoGridView();
                }
                else
                {
                    lblMessage.Text = "Có lỗi xảy ra";
                }
            }
        }
        private void UploadAvatar(string fileName)
        {
            string filePath = "~/images/" + fileName;
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath(filePath));
            }
        }
        private User LayDuLieuTuForm()
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            bool gender = Boolean.Parse(rblGender.SelectedValue);
            string address = txtAddress.Text;
            string avarta = FileUpload1.FileName.ToString();
            User user = new User
            {
                UserName = userName,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Gender = gender,
                Address = address,
                Avarta=avarta
            };
            return user;
        }
        private void LayDuLieuVaoGridView()
        {
            UserDAO userDAO = new UserDAO();
            GridView1.DataSourceID = null;
            GridView1.DataSource = userDAO.GetAllUsers();
            GridView1.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            /*txtUserName.Text = "";
            txtPassword.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";*/
            XoaNoiDung(Page);
            
        }
        private void XoaNoiDung(Control ctrl)
        {
            if (ctrl is TextBox)
            {
                (ctrl as TextBox).Text = string.Empty;
            }
            foreach (Control i in ctrl.Controls)
            {
                XoaNoiDung(i);
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userName = GridView1.SelectedRow.Cells[0].Text;
            UserDAO userDAO = new UserDAO();
            User user = userDAO.GetUserByUserName(userName);
            if (user != null)
            {
                DoDuLieuVaoForm(user);
            }
        }
        public void DoDuLieuVaoForm(User user)
        {
            txtUserName.Text = user.UserName;
            txtPassword.Text = user.Password;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            rblGender.SelectedIndex = user.Gender ? 0 : 1;
            /*int kq = 1;
            if (user.Gender == true)
            {
                kq = 0;
            }
            rblGender.SelectedIndex = kq;*/
            txtEmail.Text = user.Email;
            txtAddress.Text = user.Address;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            User user = LayDuLieuTuForm();
            UserDAO userDAO = new UserDAO();
            bool exist = userDAO.UpdateUser(user);
            if (exist)
            {
                lblMessage.Text = "Update dữ liệu thành công";
                LayDuLieuVaoGridView();
            }
            else
            {
                lblMessage.Text = "Có lỗi xảy ra";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            UserDAO userDAO = new UserDAO();
            bool exist = userDAO.DeleteUser(userName);
            if (exist)
            {
                lblMessage.Text = string.Format("Đã xóa khách hàng có tài khoản {0}", userName);
                LayDuLieuVaoGridView();
            }
            else
            {
                lblMessage.Text = "Có lỗi xảy ra";
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string username = GridView1.Rows[e.RowIndex].Cells[0].Text;
            UserDAO userDAO = new UserDAO();
            bool exist = userDAO.DeleteUser(username);
            if (exist)
            {
                lblMessage.Text = "Xóa thành công";
                LayDuLieuVaoGridView();
            }
            else
                lblMessage.Text = "Có lỗi xảy ra";
        }

        protected void btnDelete2_Click(object sender, EventArgs e)
        {
            //lấy user name cần xóa
            string username = (sender as Button).CommandArgument;
            UserDAO userDAO = new UserDAO();
            bool exist = userDAO.DeleteUser(username);
            if (exist)
            {
                lblMessage.Text = "Xóa thành công";
                LayDuLieuVaoGridView();
            }
            else
                lblMessage.Text = "Có lỗi xảy ra";
        }
    }
}