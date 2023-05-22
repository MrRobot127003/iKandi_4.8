using System;
using System.Web.UI;

namespace iKandi.Web.Internal
{
    public partial class TestForPanel : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            String ProductionFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"];
            if (fileUploadImage.HasFile)
            {

                var fileName = fileUploadImage.FileName;
                fileUploadImage.SaveAs(ProductionFolderPath + fileName);
                img.ImageUrl = ProductionFolderPath + fileName;
            }
        }

        protected void btnProcessData_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            lblMessage.Visible = true;
        }
    }
    
}