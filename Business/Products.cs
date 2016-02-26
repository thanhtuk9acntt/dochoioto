//==============================================
// Author: AutoNetCoder @ 2016
// Create date: 19/02/2016 1:57:30 PM
// Project: WebDoChoiOTo
// Description: Auto code by AutoNetCoder
// Website: http://.www.softviet.net
//==============================================
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using AppCode.Entities;
using AppCode.DataAccess;
namespace AppCode.Business
{
    public class BProducts
    {
        //---------------------------------------------------------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Products_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(string Top, string Where, string Order)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"Top", Top);
            pr[1] = new SqlParameter(@"Where", Where);
            pr[2] = new SqlParameter(@"Order", Order);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Products_SelectTop", pr);
            return all;
        }
        public static EProducts SelectByID(int id)
        {
            EProducts OProducts = new EProducts();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"id", id);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Products_SelectByID", pr);
            if (idr.Read())
                OProducts = GetOneProducts(idr);
            idr.Close();
            idr.Dispose();
            return OProducts;
        }
        public static bool TestByID(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"id", id);
            pr[0].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Products_TestByID", pr);
            return Convert.ToBoolean(pr[0].Value);
        }
        public static DataTable SelectPage(int CurrentPage, int PageSize, out int RowCount)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"CurrentPage", CurrentPage);
            pr[1] = new SqlParameter(@"PageSize", PageSize);
            pr[2] = new SqlParameter(@"RowCount", SqlDbType.Int);
            pr[2].Direction = ParameterDirection.Output;
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Products_SelectPage", pr);
            RowCount = Convert.ToInt32(pr[2].Value);
            return all;
        }
        //---------------------------------------------------------------------------------------------------------//
        public static void Insert(EProducts OProducts)
        {
            SqlParameter[] pr = new SqlParameter[6];

            pr[1] = new SqlParameter(@"ProductName", OProducts.ProductName);
            pr[2] = new SqlParameter(@"CategoryId", OProducts.CategoryId);
            pr[3] = new SqlParameter(@"Description", OProducts.Description);
            pr[4] = new SqlParameter(@"OldPrice", OProducts.OldPrice);
            pr[5] = new SqlParameter(@"NewPrice", OProducts.NewPrice);
            pr[0] = new SqlParameter(@"ImageList", OProducts.ImageList);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Products_Insert", pr);
        }
        public static void Update(EProducts OProducts)
        {
            SqlParameter[] pr = new SqlParameter[7];
            pr[0] = new SqlParameter(@"id", OProducts.id);
            pr[1] = new SqlParameter(@"ProductName", OProducts.ProductName);
            pr[2] = new SqlParameter(@"CategoryId", OProducts.CategoryId);
            pr[3] = new SqlParameter(@"Description", OProducts.Description);
            pr[4] = new SqlParameter(@"OldPrice", OProducts.OldPrice);
            pr[5] = new SqlParameter(@"NewPrice", OProducts.NewPrice);
            pr[6] = new SqlParameter(@"ImageList", OProducts.ImageList);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Products_Update", pr);
        }
        public static void Delete(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"id", id);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Products_Delete", pr);
        }
        //---------------------------------------------------------------------------------------------------------//
        private static EProducts GetOneProducts(IDataReader idr)
        {
            EProducts OProducts = new EProducts();
            if (idr["id"] != DBNull.Value)
                OProducts.id = (int)idr["id"];
            if (idr["ProductName"] != DBNull.Value)
                OProducts.ProductName = (string)idr["ProductName"];
            if (idr["CategoryId"] != DBNull.Value)
                OProducts.CategoryId = (int)idr["CategoryId"];
            if (idr["Description"] != DBNull.Value)
                OProducts.Description = (string)idr["Description"];
            if (idr["OldPrice"] != DBNull.Value)
                OProducts.OldPrice = (Decimal)idr["OldPrice"];
            if (idr["NewPrice"] != DBNull.Value)
                OProducts.NewPrice = (Decimal)idr["NewPrice"];
            if (idr["ImageList"] != DBNull.Value)
                OProducts.ImageList = (string)idr["ImageList"];
            return OProducts;
        }
        //---------------------------------------------------------------------------------------------------------//
        public static List<EProducts> ListAll()
        {
            List<EProducts> list = new List<EProducts>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Products_SelectAll", null);
            while (idr.Read())
                list.Add(GetOneProducts(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }
        public static List<EProducts> ListTop(string Top, string Where, string Order)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"Top", Top);
            pr[1] = new SqlParameter(@"Where", Where);
            pr[2] = new SqlParameter(@"Order", Order);
            List<EProducts> list = new List<EProducts>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Products_SelectTop", pr);
            while (idr.Read())
                list.Add(GetOneProducts(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }
        public static List<EProducts> ListPage(int CurrentPage, int PageSize, out int RowCount)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"CurrentPage", CurrentPage);
            pr[1] = new SqlParameter(@"PageSize", PageSize);
            pr[2] = new SqlParameter(@"RowCount", SqlDbType.Int);
            pr[2].Direction = ParameterDirection.Output;
            List<EProducts> list = new List<EProducts>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Products_SelectPage", pr);
            while (idr.Read())
                list.Add(GetOneProducts(idr));
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