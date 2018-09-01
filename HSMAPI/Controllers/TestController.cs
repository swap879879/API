using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;


namespace HSMAPI.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
       [HttpGet]
       public JsonResult GetTest()
        {
            string Test;
            using (SqlConnection _oCon = new SqlConnection())
            {
                _oCon.ConnectionString = DBContext.GetConnection;
                _oCon.Open();

                using (SqlCommand _oCmd = new SqlCommand())
                {
                    _oCmd.Connection = _oCon;
                    _oCmd.CommandText = "select * from TestTable";
                    Test = Convert.ToString( _oCmd.ExecuteScalar());
                    _oCon.Close();                    
                }
            }
            return Json(Test,JsonRequestBehavior.AllowGet);
        }
    }
}