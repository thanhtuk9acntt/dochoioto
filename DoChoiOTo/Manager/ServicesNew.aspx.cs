using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCode.Business;
using AppCode.Entities;
namespace DoChoiOTo.Manager
{
    public partial class ServicesNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var servicesName = txtServicesName.Text.Trim();
                if (string.IsNullOrEmpty(servicesName))
                {
                    Response.Write(string.Format(Utilities.AlertJs, "Trường tên không được rỗng!"));
                    return;
                }

                var description = txtDesciption.Value;
                if (string.IsNullOrEmpty(servicesName))
                {
                    Response.Write(string.Format(Utilities.AlertJs, "Trường mô tả không được rỗng!"));
                    return;
                }

                string fileName = string.Empty;
                if (fileImages.HasFile)
                {
                    fileName = fileImages.FileName;
                    var fileInformation = new FileInfo(fileName);
                    var ext = fileInformation.Extension;
                    if (!Utilities.ImageFileExtension.Contains(ext))
                    {
                        Response.Write(string.Format(Utilities.AlertJs, "Phải chọn file có định dạng ảnh !"));
                        return;
                    }
                }
                else
                {
                    Response.Write(string.Format(Utilities.AlertJs, "Chưa chọn file  ảnh !"));
                    return;
                }

                var filePath = Utilities.CreateFileURL(fileName);
                fileImages.SaveAs(filePath);
                var service = new EServices();
                service.ServiceName = servicesName;
                service.Description = description;
                service.ImageList = string.Format("imagesUpload\\{0}", fileName);
                BServices.Insert(service);
                Response.Write(string.Format(Utilities.AlertJs, "Thêm thành công !"));
                //var fileNames = fileImages.FileName;
            }
            catch (Exception ex)
            {
                WriteLog.WriteLogEntry("ServicesNew - btnSave_Click()", ex);
            }
        }
    }
}