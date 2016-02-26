
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using AppCode.Entities;
using AppCode.DataAccess;
namespace AppCode.Business
{
    public class BServices
    {
        //---------------------------------------------------------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Services_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(string Top, string Where, string Order)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"Top", Top);
            pr[1] = new SqlParameter(@"Where", Where);
            pr[2] = new SqlParameter(@"Order", Order);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Services_SelectTop", pr);
            return all;
        }
        public static EServices SelectByID(int id)
        {
            EServices OServices = new EServices();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"id", id);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Services_SelectByID", pr);
            if (idr.Read())
                OServices = GetOneServices(idr);
            idr.Close();
            idr.Dispose();
            return OServices;
        }
        public static bool TestByID(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"id", id);
            pr[0].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Services_TestByID", pr);
            return Convert.ToBoolean(pr[0].Value);
        }
        public static DataTable SelectPage(int CurrentPage, int PageSize, out int RowCount)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"CurrentPage", CurrentPage);
            pr[1] = new SqlParameter(@"PageSize", PageSize);
            pr[2] = new SqlParameter(@"RowCount", SqlDbType.Int);
            pr[2].Direction = ParameterDirection.Output;
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Services_SelectPage", pr);
            RowCount = Convert.ToInt32(pr[2].Value);
            return all;
        }
        //---------------------------------------------------------------------------------------------------------//
        public static void Insert(EServices OServices)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[1] = new SqlParameter(@"ServiceName", OServices.ServiceName);
            pr[2] = new SqlParameter(@"Description", OServices.Description);
            pr[0] = new SqlParameter(@"ImageList", OServices.ImageList);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Services_Insert", pr);
        }
        public static void Update(EServices OServices)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter(@"id", OServices.id);
            pr[1] = new SqlParameter(@"ServiceName", OServices.ServiceName);
            pr[2] = new SqlParameter(@"Description", OServices.Description);
            pr[3] = new SqlParameter(@"ImageList", OServices.ImageList);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Services_Update", pr);
        }
        public static void Delete(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"id", id);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Services_Delete", pr);
        }
        //---------------------------------------------------------------------------------------------------------//
        private static EServices GetOneServices(IDataReader idr)
        {
            EServices OServices = new EServices();
            if (idr["id"] != DBNull.Value)
                OServices.id = (int)idr["id"];
            if (idr["ServiceName"] != DBNull.Value)
                OServices.ServiceName = (string)idr["ServiceName"];
            if (idr["Description"] != DBNull.Value)
                OServices.Description = (string)idr["Description"];
            if (idr["ImageList"] != DBNull.Value)
                OServices.ImageList = (string)idr["ImageList"];
            return OServices;
        }
        //---------------------------------------------------------------------------------------------------------//
        public static List<EServices> ListAll()
        {
            List<EServices> list = new List<EServices>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Services_SelectAll", null);
            while (idr.Read())
                list.Add(GetOneServices(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }
        public static List<EServices> ListTop(string Top, string Where, string Order)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"Top", Top);
            pr[1] = new SqlParameter(@"Where", Where);
            pr[2] = new SqlParameter(@"Order", Order);
            List<EServices> list = new List<EServices>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Services_SelectTop", pr);
            while (idr.Read())
                list.Add(GetOneServices(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }
        public static List<EServices> ListPage(int CurrentPage, int PageSize, out int RowCount)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"CurrentPage", CurrentPage);
            pr[1] = new SqlParameter(@"PageSize", PageSize);
            pr[2] = new SqlParameter(@"RowCount", SqlDbType.Int);
            pr[2].Direction = ParameterDirection.Output;
            List<EServices> list = new List<EServices>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Services_SelectPage", pr);
            while (idr.Read())
                list.Add(GetOneServices(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            RowCount = Convert.ToInt32(pr[2].Value);
            return list;
        }
    }
}