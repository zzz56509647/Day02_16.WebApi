using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DetpDAL
    {
        string Conn = "Data Source =.; Initial Catalog = yuekao0216;Integrated Security = True";
        //显示
        public List<UserInfo> Show()
        {
            using (SqlConnection conn = new SqlConnection(Conn))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from DetpInfo join UserInfo on DetpInfo.Did=UserInfo.DetpId";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                var users = new List<UserInfo>();
                foreach (DataRow i in dt.Rows)
                {
                    var u = new UserInfo();
                    u.Uid = Convert.ToInt32(i["Uid"].ToString());
                    u.Uname = i["Uname"].ToString();
                    u.LoginName = i["LoginName"].ToString();
                    u.RegistrationTime = Convert.ToDateTime(i["RegistrationTime"].ToString());
                    u.DetpId = Convert.ToInt32(i["DetpId"].ToString());
                    u.Dname = i["Dname"].ToString();
                    users.Add(u);
                }
                return users;
            }
        }
        //绑定下拉
        public DataTable BandSel()
        {
            using (SqlConnection conn = new SqlConnection(Conn))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from DetpInfo";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        //添加
        public int Add(UserInfo m)
        {
            using (SqlConnection conn = new SqlConnection(Conn))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("insert into UserInfo values('{0}','{1}','{2}',{3})", m.Uname, m.LoginName, m.RegistrationTime, m.DetpId);
                return cmd.ExecuteNonQuery();
            }
        }
        //删除
        public int Del(string id)
        {
            using (SqlConnection conn = new SqlConnection(Conn))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "delete from UserInfo where Uid in (" + id + ")";
                return cmd.ExecuteNonQuery();
            }
        }
        //修改
        public int Upt(UserInfo m)
        {
            using (SqlConnection conn = new SqlConnection(Conn))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("update UserInfo set Uname='{0}',LoginName='{1}',RegistrationTime='{2}',DetpId={3} where Uid={4}", m.Uname, m.LoginName, m.RegistrationTime, m.DetpId, m.Uid);
                return cmd.ExecuteNonQuery();
            }
        }
        //获取数据
        public UserInfo Find(int id)
        {
            using (SqlConnection conn = new SqlConnection(Conn))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from UserInfo where Uid=" + id;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<UserInfo> users = new List<UserInfo>();
                foreach (DataRow i in dt.Rows)
                {
                    var u = new UserInfo();
                    u.Uid = Convert.ToInt32(i["Uid"].ToString());
                    u.Uname = i["Uname"].ToString();
                    u.LoginName = i["LoginName"].ToString();
                    u.RegistrationTime = Convert.ToDateTime(i["RegistrationTime"].ToString());
                    u.DetpId = Convert.ToInt32(i["DetpId"].ToString());

                    users.Add(u);
                }
                return users[0];
            }
        }
    }
}
