using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL.Production;
using iKandi.BLL;

namespace iKandi.Web.Admin.ProductionAdmin
{
    public partial class FrmValueAdditionInput : System.Web.UI.Page
    {
        ProductionController objProductionController = new ProductionController();
        public int OrderId
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["OrderId"])
            {
                OrderId = Convert.ToInt32(Request.QueryString["OrderId"].ToString());
            }
      
            if (!IsPostBack)
            {
                BindValueaddtionid(OrderId);
            }
        }

        private void BindValueaddtionid(int OrderId)
        {

            DataTable dtGetVlaue = new DataTable();
            dtGetVlaue = objProductionController.GetAllVaAddtion(OrderId);
            grdValaddtion.DataSource = dtGetVlaue;
            grdValaddtion.DataBind();
        }

        protected void btnsumbit_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow gvr in grdValaddtion.Rows)
                {
                    int Qty = 0,vaddid = 0;
                    

                    HiddenField Valid = (HiddenField)gvr.FindControl("hidriskid");

                    TextBox txtQty = (TextBox)gvr.FindControl("txtcapcity");


                    vaddid = Convert.ToInt32(Valid.Value);
                    Qty = Convert.ToInt32(txtQty.Text);
                    //HiddenField hdnOrderId = (HiddenField)gvr.FindControl("hdnorderid");
                    //HiddenField hdnOrderDetailId = (HiddenField)gvr.FindControl("hdnorderdetail");



                    int iSaveComment = objProductionController.InsertUpdateValueEdttion(vaddid, Qty);
                    if (iSaveComment > 0)
                    {
                    }
                }
                       
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }

        }
    }
}