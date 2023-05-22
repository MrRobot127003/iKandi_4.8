using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace iKandi.Web.UserControls.Lists
{
    public partial class ClientCostingDefaultList : BaseUserControl
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        #region Private Method

        private void BindControls()
        {
            ds = this.AdminControllerInstance.GetClientCostingDefaults();
            ViewState["currency"] = ds.Tables[1];
            ViewState["Achievement"] = ds.Tables[2];

            gvClientCostingDefaults.DataSource = ds.Tables[0];
            gvClientCostingDefaults.DataBind();
        }

        private void BindCurrency(DropDownList ddlCurrency, int CurrencyId)
        {
            DataTable dtCurrency = (DataTable)ViewState["currency"];
            ddlCurrency.DataSource = dtCurrency;
            ddlCurrency.DataTextField = "CurrencySymbol";
            ddlCurrency.DataValueField = "Id";
            ddlCurrency.DataBind();
            if (CurrencyId != -1)
            {
                ddlCurrency.SelectedValue = CurrencyId.ToString();
            }
        }

        private void BindAchievement(DropDownList ddlAchievement, int AchievementId)
        {
            DataTable dtAchievement = (DataTable)ViewState["Achievement"];

            ddlAchievement.DataSource = dtAchievement;
            ddlAchievement.DataTextField = "Achivementlabels";
            ddlAchievement.DataValueField = "AchievementlabelsID";
            ddlAchievement.DataBind();
            if (AchievementId != -1)
            {
                ddlAchievement.SelectedValue = AchievementId.ToString();
            }
        }


        #endregion

        protected void gvClientCostingDefaults_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlConvertTo = (DropDownList)e.Row.FindControl("ddlConvertTo");
                    HiddenField hdnConvertTo = (HiddenField)e.Row.FindControl("hdnConvertTo");
                    BindCurrency(ddlConvertTo, Convert.ToInt32(hdnConvertTo.Value));

                    DropDownList ddlACHIEVEMENT = (DropDownList)e.Row.FindControl("ddlACHIEVEMENT");
                    HiddenField hdnACHIEVEMENT = (HiddenField)e.Row.FindControl("hdnACHIEVEMENT");
                    BindCurrency(ddlACHIEVEMENT, Convert.ToInt32(hdnACHIEVEMENT.Value));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //ShowAlert(ex.Message.ToString());
            }
        }
    }
}