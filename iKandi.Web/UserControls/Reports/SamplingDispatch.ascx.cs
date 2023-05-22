using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.Web.Components;
using System.Collections.Generic;
using System.IO;
using iKandi.BLL;
using iKandi.Common;

namespace iKandi.Web.UserControls.Reports
{
    public partial class SamplingDispatch : BaseUserControl
    {
        ////StatusDetail statusdetail = new StatusDetail();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindControls();
            
        }

        private void BindControls()
        {
            if(!IsPostBack)
            txtCourierDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
            DateTime CourierDate = DateTime.MinValue;
            //DropdownHelper.BindClients(listClient);

            if (!string.IsNullOrEmpty(txtCourierDate.Text))
                //CourierDate = Convert.ToDateTime(txtCourierDate.Text);
                CourierDate = DateHelper.ParseDate(txtCourierDate.Text).Value;
            DataSet ds = this.ReportControllerInstance.GetSamplingDispatchReport(CourierDate, txtSearchText.Text);
            grdSamplingDispatch.DataSource = ds.Tables[0];
            grdSamplingDispatch.DataBind();

        
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();

        }

        //   protected void btnTest_click(object sender, EventArgs e)
        //{
           
        //    string Clientids = "";
        //    //List<String> ClientIdCollection = new List<string>();
        //    statusdetail.ParentOrder = new iKandi.Common.Order();
        //    statusdetail.ParentOrder.Style = new iKandi.Common.Style();
        //    foreach (ListItem item in listClient.Items)
        //    { 

                
        //        if (!item.Selected) continue;

                
        //        statusdetail.ParentOrder.Style.client = new Client();

        //        statusdetail.ParentOrder.Style.client.ClientID = Convert.ToInt32(item.Value);
        //        if (Clientids != "")
        //        {
        //           Clientids = Clientids + "," + statusdetail.ParentOrder.Style.client.ClientID.ToString();
                
        //        }
        //        else

        //            Clientids = Clientids  + statusdetail.ParentOrder.Style.client.ClientID.ToString();
            
        //    }

        //    //ClientIdCollection.Add(Clientids);

        //      ReportController controller = new ReportController();

        //    if (!Directory.Exists(Constants.TEMP_FOLDER_PATH))
        //        Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

        //    DateTime currentDate = DateTime.Today;
        //    string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, "Status List -" + currentDate.ToString("dd MMM yyy") + ".pdf");

        //    //controller.GenerateDailyCourierReport(pdfFilePath, CourrierDate);


        //    controller.GenerateDailyStatusReport(pdfFilePath, Clientids);





        //}
    
      
    }
}


      
   