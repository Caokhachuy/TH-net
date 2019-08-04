using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyTaiKhoan
{
    public class UserDAO : ApiController
    {
        string connectionString= ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public bool CheckUser(string userName)
        {
            string sql = "select count(*) from UserInfo where UserName=@user";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@user", userName);
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return (count >= 1);
            }
        }
        public bool Insert(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "insert into UserInfo values(@username,@password,@firstname,@lastname,@email,@gender,@address,@avarta)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@username",user.UserName);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@firstname", user.FirstName);
                cmd.Parameters.AddWithValue("@lastname", user.LastName);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@gender", user.Gender);
                cmd.Parameters.AddWithValue("@address", user.Address);
                cmd.Parameters.AddWithValue("@avarta", user.Avarta);
                connection.Open();
                int result = (int)cmd.ExecuteNonQuery();
                return (result >= 1);

            }
        }
        public DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from UserInfo", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public User GetUserByUserName(string userName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql="select * from UserInfo where UserName=@user";
                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("@user", userName);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    User user = new User()
                    {
                        UserName=(string)dr["UserName"],
                        Password = (string)dr["Passwordd"],
                        FirstName = (string)dr["FirstName"],
                        LastName = (string)dr["LastName"],
                        Email = (string)dr["Email"],
                        Gender = (Boolean)dr["Gender"],
                        Address = (string)dr["Addresss"]
                    };
                    return user;
                }
            }
            return null;
        }
        public bool UpdateUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "update UserInfo set Passwordd=@password,FirstName=@firstName,LastName=@lastName,Email=@email,Gender=@gender,Addresss=@address,Avarta=@avarta where UserName=@user";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                cmd.Parameters.AddWithValue("@lastName", user.LastName);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@gender", user.Gender);
                cmd.Parameters.AddWithValue("@address", user.Address);
                cmd.Parameters.AddWithValue("@user", user.UserName);
                cmd.Parameters.AddWithValue("@avarta", user.Avarta);
                conn.Open();
                int result=(int)cmd.ExecuteNonQuery();
                return (result >= 1);
            }
        }
        public bool DeleteUser(string userName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "delete from UserInfo where UserName=@user";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", userName);
                conn.Open();
                int result=(int)cmd.ExecuteNonQuery();
                return (result >= 1);
            }
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}