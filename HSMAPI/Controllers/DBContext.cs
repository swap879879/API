using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace HSMAPI.Controllers
{
    public class DBContext
    {
        public static string GetConnection
        {
           get { return ConfigurationManager.ConnectionStrings["HSMDataCon"].ConnectionString; }
        }
    }
}