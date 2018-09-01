using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace HSMAPI.Controllers
{
    public class DBContextController : Controller
    {
        // GET: DBContext
        public static string GetConnection()
        {
             return ConfigurationManager.ConnectionStrings["HSMDataCon"].ConnectionString; 
        }
    
    }
}