using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCode.Entities;
using AppCode.Business;
using System.IO;

namespace DoChoiOTo.Manager
{
    public partial class ProductNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllCategory();
        }

        void GetAllCategory()
        {
            var result = BCategories.ListAll();
            ddlCategory.DataSource = result;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var productName = txtProductName.Text.Trim();
                if (string.IsNullOrEmpty(productName))
                {
                    AlertJs("Không thể để rống trường tên!");
                    return;
                }
                var categoryId = Convert.ToInt16(ddlCategory.SelectedValue);
                var description = txtDescription.Value;
                var oldPrice = Convert.ToDecimal(txtOldPrice.Text);
                var newPrice = Convert.ToDecimal(txtOldPrice.Text);
                var fileNames = string.Empty;
                if (fileImages.HasFiles)
                {
                    foreach (var fileImage in fileImages.PostedFiles)
                    {
                        var fileName = fileImage.FileName;
                        var filePath = Utilities.CreateFileURL(fileName);
                        fileImages.SaveAs(filePath);
                        fileNames = string.Format("{0}{1};", fileNames, fileName);
                    }
                }
                var product = new EProducts();
                product.ProductName = productName;
                product.Description = description;
                product.CategoryId = categoryId;
                product.OldPrice = oldPrice;
                product.NewPrice = newPrice;
                product.ImageList = fileNames;
                BProducts.Insert(product);
            }
            catch (Exception ex)
            {
                WriteLog.WriteLogEntry("ProductNew - btnSave_Click()", ex);
            }
        }

        protected void AlertJs(string message)
        {
            Response.Write(string.Format(Utilities.AlertJs, message));
        }
    }
}