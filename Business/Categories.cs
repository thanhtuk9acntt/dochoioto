using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using AppCode.Entities;
using AppCode.DataAccess;
namespace AppCode.Business
{
    public class BCategories
    {
        //---------------------------------------------------------------------------------------------------------//
        public static DataTable SelectAll()
        {
            var all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Categories_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(string Top, string Where, string Order)
        {
            var pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"Top", Top);
            pr[1] = new SqlParameter(@"Where", Where);
            pr[2] = new SqlParameter(@"Order", Order);
            var all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Categories_SelectTop", pr);
            return all;
        }
        public static ECategories SelectByID(int Id)
        {
            var OCategories = new ECategories();
            var pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Id", Id);
            var idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Categories_SelectByID", pr);
            if (idr.Read())
                OCategories = GetOneCategories(idr);
            idr.Close();
            idr.Dispose();
            return OCategories;
        }
        public static bool TestByID(int Id)
        {
            var pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Id", Id);
            pr[0].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Categories_TestByID", pr);
            return Convert.ToBoolean(pr[0].Value);
        }
        public static DataTable SelectPage(int CurrentPage, int PageSize, out int RowCount)
        {
            var pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"CurrentPage", CurrentPage);
            pr[1] = new SqlParameter(@"PageSize", PageSize);
            pr[2] = new SqlParameter(@"RowCount", SqlDbType.Int);
            pr[2].Direction = ParameterDirection.Output;
            var all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Categories_SelectPage", pr);
            RowCount = Convert.ToInt32(pr[2].Value);
            return all;
        }
        //---------------------------------------------------------------------------------------------------------//
        public static void Insert(ECategories OCategories)
        {
            var pr = new SqlParameter[2];
            pr[1] = new SqlParameter(@"CategoryName", OCategories.CategoryName);
            pr[0] = new SqlParameter(@"Description", OCategories.Description);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Categories_Insert", pr);
        }
        public static void Update(ECategories OCategories)
        {
            var pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"Id", OCategories.Id);
            pr[1] = new SqlParameter(@"CategoryName", OCategories.CategoryName);
            pr[2] = new SqlParameter(@"Description", OCategories.Description);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Categories_Update", pr);
        }
        public static void Delete(int Id)
        {
            var pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Id", Id);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Categories_Delete", pr);
        }
        //---------------------------------------------------------------------------------------------------------//
        private static ECategories GetOneCategories(IDataReader idr)
        {
            var OCategories = new ECategories();
            if (idr["Id"] != DBNull.Value)
                OCategories.Id = (int)idr["Id"];
            if (idr["CategoryName"] != DBNull.Value)
                OCategories.CategoryName = (string)idr["CategoryName"];
            if (idr["Description"] != DBNull.Value)
                OCategories.Description = (string)idr["Description"];
            return OCategories;
        }
        //---------------------------------------------------------------------------------------------------------//
        public static List<ECategories> ListAll()
        {
            var list = new List<ECategories>();
            var idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Categories_SelectAll", null);
            while (idr.Read())
                list.Add(GetOneCategories(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }
        public static List<ECategories> ListTop(string Top, string Where, string Order)
        {
            var pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"Top", Top);
            pr[1] = new SqlParameter(@"Where", Where);
            pr[2] = new SqlParameter(@"Order", Order);
            var list = new List<ECategories>();
            var idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Categories_SelectTop", pr);
            while (idr.Read())
                list.Add(GetOneCategories(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }
        public static List<ECategories> ListPage(int CurrentPage, int PageSize, out int RowCount)
        {
            var pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"CurrentPage", CurrentPage);
            pr[1] = new SqlParameter(@"PageSize", PageSize);
            pr[2] = new SqlParameter(@"RowCount", SqlDbType.Int);
            pr[2].Direction = ParameterDirection.Output;
            var list = new List<ECategories>();
            var idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Categories_SelectPage", pr);
            while (idr.Read())
                list.Add(GetOneCategories(idr));
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