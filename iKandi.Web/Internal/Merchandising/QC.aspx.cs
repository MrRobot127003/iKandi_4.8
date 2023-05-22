using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using iKandi.Common;
using iKandi.Web.Components;
using System.Data;
using iKandi.BLL;

namespace iKandi.Web.Internal.Merchandising
{
    public partial class QC : BasePage
    {

        public string OrderDetailID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["OrderDetailID"]))
                {
                    return Request.QueryString["OrderDetailID"];
                }
                return "0";
            }
        }

        public string OrderId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["OrderId"]))
                {
                    return Request.QueryString["OrderId"];
                }
                return "0";
            }
        }

        public string InspectionQId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["InspectionQId"]))
                {
                    return Request.QueryString["InspectionQId"];
                }
                return "-10";
            }
        }

        public string InspectionIDMO
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["InspectionIDMO"]))
                {
                    return Request.QueryString["InspectionIDMO"];
                }
                return "0";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BINDDATA();
        }

        private void BINDDATA()
        { 
             QualityController qualityControl = new QualityController();
             DataSet DS = qualityControl.GetQualityControlBYContract(OrderId, OrderDetailID, InspectionQId, InspectionIDMO);

             if (DS.Tables[0].Rows.Count > 0)
             {
                 ltrlContractNo.Text = DS.Tables[0].Rows[0]["ContractNumber"].ToString();
                 ltrlSerialNo.Text = DS.Tables[0].Rows[0]["SerialNumber"].ToString();
                 ltrlStyleNo.Text = DS.Tables[0].Rows[0]["StyleNumber"].ToString();
                 hdnOrderID.Value = OrderId;
                 hdnISOpenPopUp.Value = DS.Tables[0].Rows[0]["ISOpenPopUp"].ToString();
                 hdnInspectionName.Value = DS.Tables[0].Rows[0]["Inspection"].ToString(); 

                 if ((DS.Tables[0].Rows.Count == 1) && (DS.Tables[0].Rows[0]["QualityId"].ToString()=="0"))
                 {
                     tabs_qc.Visible = false;
                 }
             }

             ddlInspection.DataSource = DS.Tables[1];
             ddlInspection.DataValueField = "InspectionID";
             ddlInspection.DataTextField = "Description";
             ddlInspection.DataBind();
             

             repeaterQCTabs.DataSource = repeaterQC.DataSource = DS.Tables[0];
             repeaterQCTabs.DataBind();
             repeaterQC.DataBind();

        }

        protected void repeaterQCTabs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string StatusName = "";//DataBinder.Eval(e.Item.DataItem, "FaultStatusNAME").ToString();
                int FaultStatus = DataBinder.Eval(e.Item.DataItem, "FaultStatus") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "FaultStatus"));
                int ApproveByCQD = DataBinder.Eval(e.Item.DataItem, "ApprovedByCQD_QAManager") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ApprovedByCQD_QAManager"));
                string Inspection = DataBinder.Eval(e.Item.DataItem, "Inspection").ToString();
                string FaultsDate = DataBinder.Eval(e.Item.DataItem, "FaultDateS").ToString();

                HtmlGenericControl dvTab = (HtmlGenericControl)e.Item.FindControl("dvTab");
                HtmlAnchor QCTab = (HtmlAnchor)e.Item.FindControl("QCTab");

                if ((FaultStatus == 1) && (ApproveByCQD == 1))
                    StatusName = "Pass";
                if ((FaultStatus == 1) && (ApproveByCQD == 0))
                    StatusName = "Pen.";
                if ((FaultStatus == 2) && (ApproveByCQD == 1))
                    StatusName = "Fail";
                if ((FaultStatus == 2) && (ApproveByCQD == 0))
                    StatusName = "Pen.";
                if(FaultStatus == 0)
                    StatusName = "Pen.";

                QCTab.InnerText = Inspection + " " + StatusName + " " + FaultsDate;

                if (StatusName == "Pass")
                    dvTab.Attributes.Add("class", "tabGreen");
                if (StatusName == "Fail")
                    dvTab.Attributes.Add("class", "tabRed");
                if (StatusName == "Pen.")
                    dvTab.Attributes.Add("class", "tabGray");
            }
        }
    }
}