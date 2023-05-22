using System;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;

namespace iKandi.Web.Internal.OrderProcessing
{
    public partial class OB_Operations_HistoryPopUp : BasePage
    {
        int StyleId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);
            if (!IsPostBack)
            {
                Get_OBOperations_History(StyleId);
            }
        }

        private void Get_OBOperations_History(int StyleId)
        {
            OrderProcessController obj_ProcessController = new OrderProcessController();
            DataTable dt = obj_ProcessController.Get_OBOperations_History(StyleId);       
        
                gvStitchingManpowerDetail.DataSource = dt;
                gvStitchingManpowerDetail.DataBind();              
        }
    }
}