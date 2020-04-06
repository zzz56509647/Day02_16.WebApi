using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using Model;
using DAL;

namespace Day02_16.WebApi.Controllers
{
    public class UserController : ApiController
    {
        DetpDAL dal = new DetpDAL();
        public List<UserInfo> Get(string name, string did)
        {
            var list = dal.Show();
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(s => s.Uname.Contains(name)).ToList();
            }
            if (!string.IsNullOrEmpty(did))
            {
                list = list.Where(s => s.DetpId == int.Parse(did)).ToList();
            }
            return list;
        }

        // GET: api/User/5
        public UserInfo Get(int id)
        {
            return dal.Find(id);
        }

        // POST: api/User
        public int Post([FromBody]UserInfo m)
        {
            return dal.Add(m);
        }

        // PUT: api/User/5
        public int Put([FromBody]UserInfo m)
        {
            return dal.Upt(m);
        }

        // DELETE: api/User/5
        public int Delete(string id)
        {
            return dal.Del(id);
        }
    }
}
