using System;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;

namespace iKandi.Web.Internal.Merchandising
{
    public partial class Reallocation_History : System.Web.UI.Page
    {
        int StyleId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);
            
            if (!IsPostBack)
            {
                Get_Reallocation_History(StyleId);
            }
        }
        DataSet ds;
        DataTable dt;
        private void Get_Reallocation_History(int StyleId)
        {
            OrderProcessController obj_ProcessController = new OrderProcessController();
            ds = obj_ProcessController.Get_Reallocation_History(StyleId);
            dt = new DataTable();
            dt = ds.Tables[0];
            grdReallocationHistory.DataSource = dt;
            grdReallocationHistory.DataBind();

        }
        protected void grdReallocationHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblOperation = (Label)e.Row.FindControl("lblOperation");
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                Label lblUpdateRemarks = (Label)e.Row.FindControl("lblUpdateRemarks");
                int count = 0;
                count = int.Parse((e.Row.RowIndex ).ToString());
                if (lblOperation != null)
                {
                    DataTable dt1 = new DataTable();
                    dt1 = ds.Tables[1];
                    if (dt.Rows[count]["Status"].ToString().ToUpper() == "UPDATED" || dt.Rows[count]["Status"].ToString().ToUpper() == "DELETED")     //&& (dt.Rows[count]["UpdateRemark"].ToString() != "")
                    {
                        lblStatus.Text = "<span style='color:blue;'>" + dt.Rows[count]["Status"].ToString() + "</span>" + " by " + dt.Rows[count]["FirstName"].ToString() + " On " + Convert.ToDateTime(dt.Rows[count]["ModifyOn"]).ToString("dd MMM yyyy (ddd)");
                    }
                    else
                    {
                        lblStatus.Text = "<span style='color:blue;'>" + dt.Rows[count]["Status"].ToString() + "</span>" + " by " + dt.Rows[count]["FirstName"].ToString() + " On " + Convert.ToDateTime(dt.Rows[count]["CreatedOn"]).ToString("dd MMM yyyy (ddd)");//dt.Rows[count]["CreatedOn"].ToString();   
                    }

                    lblOperation.Text = "<span style='color:black;'>" + dt1.Rows[count]["SerialNumber"].ToString() + "<span style='color:blue;'>" + " (" + dt1.Rows[count]["Quantity"].ToString() + ") " + "</span>" + "</span>" + "<span style='color:grey;'>" + "(" + dt1.Rows[count]["LineNumber"].ToString() + "/" + dt1.Rows[count]["ContractNumber"].ToString() + ") " + "</span>";
                }
            }
        }
    }
}