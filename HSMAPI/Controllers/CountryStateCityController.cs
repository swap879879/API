using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using HSMAPI.Models;
using Classes;
using HSMAPI.Classes;

namespace HSMAPI.Controllers
{
    public class CountryStateCityController : Controller
    {   
        [System.Web.Http.HttpPost]
        public JsonResult SaveCountry(string Country)
        {
            var Result = "Operation Fail";
            if (Country != null)
            {
                SqlConnection _con = new SqlConnection();
                SqlCommand _cmd = new SqlCommand();
                SqlTransaction _trans = null;                
                try
                {
                    _con.ConnectionString = DBContext.GetConnection;
                    _con.Open();
                    _trans = _con.BeginTransaction();
                    _cmd.Connection = _con;
                    _cmd.CommandText = "[dbo].[sp_CountryGIUD]";
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Transaction = _trans;

                    CountryStateCity _oCountryStateCity = new CountryStateCity();
                    _oCountryStateCity = JsonConvert.DeserializeObject<CountryStateCity>(Country);
                   
                    _cmd.Parameters.Add(new SqlParameter("@vCountry", _oCountryStateCity.Country));
                    _cmd.Parameters.Add(new SqlParameter("@vOperation", 2));
                    _cmd.ExecuteNonQuery();
                    Result = "Record Inserted Successfully.";
                    _trans.Commit();
                }
                catch (Exception ex)
                {
                    // Result = ex.ToString();
                    Result = "Insert Fail";
                    _trans.Rollback();                    
                }
                finally
                {
                    _con.Close();
                    _con = null;
                    _trans = null;
                }                
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public JsonResult GetCountry()
        {
            string Result = "";            
            DataSet _oDs = new DataSet();
            SqlConnection _con = new SqlConnection();
            SqlCommand _cmd = new SqlCommand();
            
            try
            {                
                _con.ConnectionString = DBContext.GetConnection;
                _con.Open();
                _cmd.Connection = _con;
                _cmd.CommandText = "[dbo].[sp_CountryGIUD]";
                _cmd.CommandType = CommandType.StoredProcedure;                           
                _cmd.Parameters.Add(new SqlParameter("@vOperation", 1));
                SqlDataAdapter _oDa = new SqlDataAdapter();
                 _oDa.SelectCommand = _cmd;
                _oDa.Fill(_oDs);

                Result = JsonConvert.SerializeObject(_oDs);
            }
            catch(Exception ex)
            {
                Result = ex.ToString();                
            }
            finally
            {
                _con.Close();
            }

            return Json( Result, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public JsonResult SaveState(string State)
        {
            var Result = "Operation Fail";
            if (State != null)
            {
                SqlConnection _con = new SqlConnection();
                SqlCommand _cmd = new SqlCommand();
                SqlTransaction _trans = null;
                try
                {
                    _con.ConnectionString = DBContext.GetConnection;
                    _con.Open();
                    _trans = _con.BeginTransaction();
                    _cmd.Connection = _con;
                    _cmd.CommandText = "[dbo].[sp_StateGIUD]";
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Transaction = _trans;

                    CountryStateCity _oCountryStateCity = new CountryStateCity();
                    _oCountryStateCity = JsonConvert.DeserializeObject<CountryStateCity>(State);

                    _cmd.Parameters.Add(new SqlParameter("@vCountryId", _oCountryStateCity.CountryId));
                    _cmd.Parameters.Add(new SqlParameter("@vState", _oCountryStateCity.State));
                    _cmd.Parameters.Add(new SqlParameter("@vOperation", 2));
                    _cmd.ExecuteNonQuery();
                    Result = "Record Inserted Successfully.";
                    _trans.Commit();
                }
                catch (Exception ex)
                {
                    // Result = ex.ToString();
                    Result = "Insert Fail";
                    _trans.Rollback();
                }
                finally
                {
                    _con.Close();
                    _con = null;
                    _trans = null;
                }
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public JsonResult GetState()
        {
            string Result = "";
            DataSet _oDs = new DataSet();
            SqlConnection _con = new SqlConnection();
            SqlCommand _cmd = new SqlCommand();

            try
            {
                _con.ConnectionString = DBContext.GetConnection;
                _con.Open();
                _cmd.Connection = _con;
                _cmd.CommandText = "[dbo].[sp_StateGIUD]";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Parameters.Add(new SqlParameter("@vOperation", 1));
                SqlDataAdapter _oDa = new SqlDataAdapter();
                _oDa.SelectCommand = _cmd;
                _oDa.Fill(_oDs);

                Result = JsonConvert.SerializeObject(_oDs);
            }
            catch (Exception ex)
            {
                Result = ex.ToString();
            }
            finally
            {
                _con.Close();
            }

            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public JsonResult SaveCity(string City)
        {
            var Result = "Operation Fail";
            if (City != null)
            {
                SqlConnection _con = new SqlConnection();
                SqlCommand _cmd = new SqlCommand();
                SqlTransaction _trans = null;
                try
                {
                    _con.ConnectionString = DBContext.GetConnection;
                    _con.Open();
                    _trans = _con.BeginTransaction();
                    _cmd.Connection = _con;
                    _cmd.CommandText = "[dbo].[sp_CityGIUD]";
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Transaction = _trans;

                    CountryStateCity _oCountryStateCity = new CountryStateCity();
                    _oCountryStateCity = JsonConvert.DeserializeObject<CountryStateCity>(City);

                    _cmd.Parameters.Add(new SqlParameter("@vStateId", _oCountryStateCity.StateId));
                    _cmd.Parameters.Add(new SqlParameter("@vCity", _oCountryStateCity.City));
                    _cmd.Parameters.Add(new SqlParameter("@vOperation", 2));
                    _cmd.ExecuteNonQuery();
                    Result = "Record Inserted Successfully.";
                    _trans.Commit();
                }
                catch (Exception ex)
                {
                    // Result = ex.ToString();
                    Result = "Insert Fail";
                    _trans.Rollback();
                }
                finally
                {
                    _con.Close();
                    _con = null;
                    _trans = null;
                }
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public JsonResult GetSummary()
        {
            string Result = "";
            DataSet _oDs = new DataSet();
            SqlConnection _con = new SqlConnection();
            SqlCommand _cmd = new SqlCommand();

            try
            {
                _con.ConnectionString = DBContext.GetConnection;
                _con.Open();
                _cmd.Connection = _con;
                _cmd.CommandText = @"SELECT Country,State,City FROM Master_Country mc left join Master_State ms on ms.CountryId = mc.CountryId
                left join Master_City mct on mct.StateId = ms.StateId";                
                SqlDataAdapter _oDa = new SqlDataAdapter();
                _oDa.SelectCommand = _cmd;
                _oDa.Fill(_oDs);

                Result = JsonConvert.SerializeObject(_oDs);
            }
            catch (Exception ex)
            {
                Result = ex.ToString();
            }
            finally
            {
                _con.Close();
            }

            return Json(Result, JsonRequestBehavior.AllowGet);
        }


    }
}