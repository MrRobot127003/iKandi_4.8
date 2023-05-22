using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;

namespace iKandi.Web.Internal.Sales
{
    public partial class Costing_GetLP_New : System.Web.UI.Page
    {
        CostingContollerNew CostingControllerInstanceNew = new CostingContollerNew();
        public int Styleid
        {
            get
            {
                if (Request.QueryString["Styleid"] == null || Request.QueryString["Styleid"].Trim() == string.Empty)
                    return -1;

                return Convert.ToInt32(Request.QueryString["Styleid"]);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        public void BindGrid()
        {
            DataSet ds = this.CostingControllerInstanceNew.Get_LP_Details_New(this.Styleid);
            grdGetLp.DataSource = ds.Tables[0];
            grdGetLp.DataBind();

            mergegrdGetLp(grdGetLp);

            grdGetVersionOrders.DataSource = ds.Tables[1];
            grdGetVersionOrders.DataBind();

            if (ds.Tables[1].Rows.Count > 1) {
                header.InnerHtml = "<b style='Color:gray'>Style Version With Latest Order(Shipped/Unshipped)</b><br><br>";
            }
        }

        void mergegrdGetLp(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                string A = "", B = "";

                A = A + ((Label)row.FindControl("lblstylenumber")).Text;
                B = B + ((Label)previousRow.FindControl("lblstylenumber")).Text;

                if (A.ToLower() == B.ToLower())
                {
                    row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 : previousRow.Cells[0].RowSpan + 1;
                    previousRow.Cells[0].Visible = false;
                }

            
            }
        }
       
    }
}