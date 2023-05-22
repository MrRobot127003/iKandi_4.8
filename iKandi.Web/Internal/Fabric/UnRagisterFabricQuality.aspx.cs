using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;
using System.Data;
using iKandi.Common.Entities;

namespace iKandi.Web.Internal.Fabric
{
    public partial class UnRagisterFabricQuality : System.Web.UI.Page
    {
        FabricController FabriCon = new FabricController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDatagrd();
            }
        }

        protected void bindDatagrd() {
            List<Un_RagisterFabric> UnRagisterFab = FabriCon.GetUnRagisterFabQual();
            if (UnRagisterFab.Count > 0)
            {
                GrdUnRagisterFabQuality.DataSource = UnRagisterFab;
                GrdUnRagisterFabQuality.DataBind();
            }
            
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        protected void DataSave_Click(object sender, EventArgs e)
        {
            string EmptyTradeName = txtEmptyFabQuality.Text;
            string EmptyGsm = txtEmptyGsm.Text;
            string EmptyCountCounstruction = txtEmptyCountCounstruction.Text;
            decimal EmptyCostWidth = txtEmptyCostWidth.Text == "" ? 0 : Convert.ToDecimal(txtEmptyCostWidth.Text);
            decimal EmptyFinishRate = txtEmptyFinishRate.Text == "" ? 0 : Convert.ToDecimal(txtEmptyFinishRate.Text);
            if (EmptyTradeName != "")
            {
                Un_RagisterFabric objUnRagFab = new Un_RagisterFabric();
                objUnRagFab.TradeName = EmptyTradeName;
                objUnRagFab.Gsm = EmptyGsm;
                objUnRagFab.CountConstruction = EmptyCountCounstruction;
                objUnRagFab.CostWidth = EmptyCostWidth;
                objUnRagFab.FinishRate = EmptyFinishRate;

                int iSave = FabriCon.SaveUnRagisterFabQualityData(objUnRagFab);
                bindDatagrd();
                if (iSave > 0)
                {
                    txtEmptyFabQuality.Text = "";
                    txtEmptyGsm.Text = "";
                    txtEmptyCostWidth.Text = "";
                    txtEmptyCountCounstruction.Text = "";
                    txtEmptyFinishRate.Text = "";
                    ShowAlert("Data Save successfully!");
                    return;
                    
                }
                else
                {
                    ShowAlert("Fabric Quality Duplicate!");
                    return;
                }
               
            }
            bindDatagrd();
        }
        protected void GrdUnRagisterFabQuality_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblFinishRate = (Label)e.Row.FindControl("lblFinishRate");
                if (lblFinishRate.Text != "")
                {
                    lblFinishRate.Text = "₹ " + lblFinishRate.Text;
                }
            }
        }
       
    }
}