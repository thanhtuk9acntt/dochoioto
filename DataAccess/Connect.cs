//==============================================
// Author: AutoNetCoder @ 2016
// Create date: 17/02/2016 2:42:00 PM
// Project: WebDoChoiOTo
// Description: Auto code by AutoNetCoder
// Website: http://.www.softviet.net
//==============================================
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace AppCode.Connection
{
	public static class ConnectionString
	{
   		// Connect string for application
		//private static string strconnection = @"Data Source=.\SQLEXPRESS;Database=WebDoChoiOTo;integrated Security=SSPI";
		// Connect string for website
        private static string strconnection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
		public static string Text
		{
			get { return strconnection; }
			set { strconnection = value; }
		}
	}
}