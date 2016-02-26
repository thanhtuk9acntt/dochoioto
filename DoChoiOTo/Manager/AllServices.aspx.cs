using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCode.Entities;
using AppCode.Business;
namespace DoChoiOTo.Manager
{
    public partial class AllServices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            var data = BServices.SelectAll();
            grvServices.DataSource = data;
            grvServices.DataBind();

        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {

        }

        protected void grvServices_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdDelete"))
            {
                var gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                var rowIndex = gvr.RowIndex;
                var idbook = grvServices.Rows[rowIndex].Cells[0].Text;
                BServices.Delete(int.Parse(idbook));
                Response.Redirect("AllServices.aspx");
                //  grvServices.DataBind();
               // Response.Write(string.Format(Utilities.AlertJs, "Xóa thành công!"));

            }
        }
    }
}