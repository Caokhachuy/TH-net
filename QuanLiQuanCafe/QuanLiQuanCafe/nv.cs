using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace QuanLiQuanCafe
{
    public class nv
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString;
        public DataTable LayNV()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT*FROM ThemNV", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }
        public bool KiemtraNV(string maNV)
        {
            string sql = @"SELECT COUNT(*) FROM ThemNV WHERE MaNV = @manv";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@manv", maNV);

                connection.Open();

                int count = (int)command.ExecuteScalar();

                return (count >= 1);
                //if (count >= 1) return true;
                //else return false;

            }
        }
        public bool ThemNV(qlnv nv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO ThemNV(MaNV,TenNV,NgaySinh,GioiTinh,ChucVu,DiaChi,SDT,Email) 
                                 VALUES(@manv,@tennv,@ngaysinh,@gioitinh,@chucvu,@diachi,@sdt, @email)";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@manv", nv.MaNV);
                cmd.Parameters.AddWithValue("@tennv", nv.TenNV);
                cmd.Parameters.AddWithValue("@ngaysinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@gioitinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@chucvu", nv.ChucVu);
                cmd.Parameters.AddWithValue("@diachi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@sdt", nv.SDT);
                cmd.Parameters.AddWithValue("@email", nv.Email);

                connection.Open();
                int result = (int) cmd.ExecuteNonQuery();
                return (result >= 1);
            }
        }
        public qlnv LayMaNV(string maNV)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM ThemNV WHERE MaNV=@manv";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@manv", maNV);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    qlnv nv = new qlnv
                    {
                        //lấy giá trị theo tên cột trong CSDL
                        MaNV = (string)reader["MaNV"],
                        TenNV = (string)reader["TenNV"],
                        NgaySinh = (string)reader["NgaySinh"],
                        GioiTinh = (Boolean)reader["GioiTinh"],
                        ChucVu = (string)reader["ChucVu"],
                        DiaChi = (string)reader["ĐiaChi"],
                        SDT = (string)reader["SDT"],
                        Email= (string)reader["Email"]
                    };
                    return nv;
                }
            }
            return null;
        }
        public bool XoaNV(string maNV)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "delete from ThemNV where MaNV=@manv";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@manv", maNV);
                connection.Open();
                int kq = (int)cmd.ExecuteNonQuery();
                return kq >= 1;
            }

        }
        }
}



        
