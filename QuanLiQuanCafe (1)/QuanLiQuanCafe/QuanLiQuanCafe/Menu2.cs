using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace QuanLiQuanCafe
{
    public class Menu2
    {
        string connect = ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString;
        public DataTable LayMenu()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string sql = "select * from Menu";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool KiemTraHang(string maHang)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string sql = "select count(*) from Menu where Mahang=@ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maHang);
                conn.Open();
                int kq = (int)cmd.ExecuteScalar();
                return kq >= 1;
            }
        }
        public bool ThemHang(string maHang, string tenHang, int donGia)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string sql = "insert into Menu values(@ma,@ten,@dg)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maHang);
                cmd.Parameters.AddWithValue("@ten", tenHang);
                cmd.Parameters.AddWithValue("@dg", donGia);
                conn.Open();
                int kq = (int)cmd.ExecuteNonQuery();
                return kq >= 1;
            }
        }
        public bool XoaHang(string maHang)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string sql = "delete from Menu where Mahang=@ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maHang);
                conn.Open();
                int kq = (int)cmd.ExecuteNonQuery();
                return kq >= 1;
            }
        }
        public DataTable TimKiemMatHang(string maHang)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string sql = "select * from Menu where Mahang=@ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maHang);
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool DemTimKiemMatHang(string maHang)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string sql = "select * from Menu where Mahang=@ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maHang);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                return dr.Read();
            }
        }

    }
}