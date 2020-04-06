using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using Model;
using DAL;

namespace Day02_16.WebApi.Controllers
{
    public class DetpController : ApiController
    {
        DetpDAL dal = new DetpDAL();
        public DataTable Get()
        {
            return dal.BandSel();
        }


    }
}
