using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;

namespace iKandi.Web.Internal.OrderProcessing
{
    public partial class DestinationMap : System.Web.UI.Page
    {
        OrderController objOrderController = new OrderController();
        int OrderId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.QueryString["OrderId"] != null)
            //{
            //    OrderId = Convert.ToInt32(Request.QueryString["OrderId"]);
            //}
            OrderId = 8;

            if (!IsPostBack)
            {
                BinddestnMapGridView();
            }
        }

        protected void BinddestnMapGridView()
        {
            DataSet dsDestMap = objOrderController.GetDestinationMap(OrderId, "GetDestinationMap");
            destnMap.DataSource = dsDestMap.Tables[0];
            destnMap.DataBind();
               
        }

        protected void destnMap_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlDestinationCode = (DropDownList)e.Row.FindControl("ddlDestinationCode");
                DropDownList ddlMode = (DropDownList)e.Row.FindControl("ddlMode");
                Label lblExFactory = (Label)e.Row.FindControl("lblExFactory");
                TextBox txtDc = (TextBox)e.Row.FindControl("txtDc");
                HiddenField hdnDesination_code = (HiddenField)e.Row.FindControl("hdnDesination_code");
                HiddenField hdnMode = (HiddenField)e.Row.FindControl("hdnMode");

                if (lblExFactory.Text != "")
                    lblExFactory.Text = Convert.ToDateTime(lblExFactory.Text).ToString("dd MMM yy");
                if (txtDc.Text != "")
                    txtDc.Text = Convert.ToDateTime(txtDc.Text).ToString("dd MMM yy");

                DataSet ds = objOrderController.GetDestinationMap(OrderId, "GetDestAndMode");
                ddlDestinationCode.DataSource = ds.Tables[0];
                ddlDestinationCode.DataTextField = "Country_Code";
                ddlDestinationCode.DataValueField = "Country_Code_Id";
                ddlDestinationCode.DataBind();

                ddlMode.DataSource = ds.Tables[1];
                ddlMode.DataTextField = "Code";
                ddlMode.DataValueField = "Mode";
                ddlMode.DataBind();

                if (hdnDesination_code.Value != string.Empty)
                    ddlDestinationCode.SelectedValue = hdnDesination_code.Value;
                if (hdnMode.Value != string.Empty)
                    ddlMode.SelectedValue = hdnMode.Value;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Save();
        }

        public void Save()
        {
            int result = 0;
            if (destnMap.Rows.Count > 0)
            {
                foreach (GridViewRow gvr in destnMap.Rows)
                {
                    HiddenField hdnOrderDetailId = (HiddenField)gvr.FindControl("hdnOrderDetailId");
                    DropDownList ddlDestinationCode = (DropDownList)gvr.FindControl("ddlDestinationCode");
                    DropDownList ddlMode = (DropDownList)gvr.FindControl("ddlMode");
                    TextBox txtDc = (TextBox)gvr.FindControl("txtDc");
                    Label lblExFactory = (Label)gvr.FindControl("lblExFactory");

                    result = objOrderController.UpdateDestinationMap(Convert.ToInt32(hdnOrderDetailId.Value), Convert.ToInt32(ddlDestinationCode.SelectedValue), Convert.ToInt32(ddlMode.SelectedValue), Convert.ToDateTime(txtDc.Text), Convert.ToDateTime(lblExFactory.Text));
                }
            }
            if (result > 0)
            {
                ShowAlert("Data has save successfully!");
            }
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

    }
}