using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCode.Business;
using AppCode.Entities;
namespace DoChoiOTo.UserControls
{
    public partial class LeftMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public List<ECategories> LoadData()
        {
            var result = BCategories.ListAll();
            return result;
        }
    }
}