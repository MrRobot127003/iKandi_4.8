using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using iKandi.Common;
using iKandi.BLL.Production;
using System.Data;
using System.Collections;
using iKandi.BLL;

namespace iKandi.Web.Internal.Accessory
{
    public partial class RoamingQcEntry : System.Web.UI.Page
    {

        AdminController objadmin = new AdminController();

        int QCId;
        int UnitId;
        int LineNo;
        int ClusterVal;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                QCNameDrop(ddlQcName);
                QCUnitDrop(ddlUnitName);
                //QCUnitLineNo();
                //QCUnitCluster();
                GriviewBind();
            }


        }

        protected void QCNameDrop(DropDownList ddlQC)
        {
           // DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = objadmin.GetInhouseQCName();
            //dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                ddlQC.DataSource = dt;
                ddlQC.DataTextField = "QCName";
                ddlQC.DataValueField = "QCId";
                ddlQC.DataBind();
            }
        }


        protected void QCUnitDrop(DropDownList ddlUnit)
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = objadmin.GetInhouseQCUnit();
            //dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                ddlUnit.DataSource = dt;
                ddlUnit.DataTextField = "UnitName";
                ddlUnit.DataValueField = "UnitId";
                ddlUnit.DataBind();
            }
        }
        protected void QCUnitLineNo(DropDownList ddlLine, int UnitId)
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = objadmin.GetInhouseQCLineNo(UnitId);
           // dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                ddlLine.DataSource = dt;
                ddlLine.DataTextField = "LineNumberText";
                ddlLine.DataValueField = "LineNo";
                ddlLine.DataBind();
            }

        }
        protected void QCUnitCluster(DropDownList ddlCluster, int UnitId)
        {
           // DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = objadmin.GetInhouseQCCluster(UnitId);
           // dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                ddlCluster.DataSource = dt;
                ddlCluster.DataTextField = "Cluster_Name";
                ddlCluster.DataValueField = "ClusterId";
                ddlCluster.DataBind();
            }

        }

        protected void SelectedUnitName(object sender, EventArgs e)
        {
            int UnitVal = Convert.ToInt32(ddlUnitName.SelectedValue);

            QCUnitLineNo(ddlLineNo, UnitVal);
            QCUnitCluster(ddlCluster, UnitVal);
        }

        protected void btn_Submitval(object sender, EventArgs e)
        {
            if (ddlQcName.SelectedValue != "-1")
            {
                QCId = Convert.ToInt32(ddlQcName.SelectedValue);
            }
            if (ddlUnitName.SelectedValue != "-1")
            {
                UnitId = Convert.ToInt32(ddlUnitName.SelectedValue);
            }
            if (ddlLineNo.SelectedValue != "-1")
            {
                LineNo = Convert.ToInt32(ddlLineNo.SelectedValue);
            }
            if (ddlCluster.SelectedValue != "-1")
            {
                ClusterVal = Convert.ToInt32(ddlCluster.SelectedValue);
            }


            int RoamingQcEntryData = objadmin.RoamingQcEntryFunt(QCId, UnitId, LineNo, ClusterVal);
        }

        protected void SlectedLineNo(object sender, EventArgs e)
        {
            if (ddlLineNo.SelectedValue != "-1")
            {

                ddlCluster.Attributes.Add("disabled", "disabled");
            }
            else
            {
                ddlCluster.Attributes.Remove("disabled");
            }

        }

        protected void SelectedCluster(object sender, EventArgs e)
        {
            if (ddlCluster.SelectedValue != "-1")
            {

                ddlLineNo.Attributes.Add("disabled", "disabled");
            }
            else
            {
                ddlLineNo.Attributes.Remove("disabled");
            }

        }
        protected void GriviewBind() {
            DataTable dt = new DataTable();
            dt = objadmin.GetGridViewData();
            grdroamingQcEntry.DataSource = dt;
            grdroamingQcEntry.DataBind();
        }
        protected void grdroamingQcEntry_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnQCId = (HiddenField)e.Row.FindControl("hdnQCId");
                DropDownList ddlgrdQCName = (DropDownList)e.Row.FindControl("ddlgrdQCName");
                QCNameDrop(ddlgrdQCName);

                HiddenField hdnUnit = (HiddenField)e.Row.FindControl("hdnUnit");
                DropDownList ddlgrdUnit = (DropDownList)e.Row.FindControl("ddlgrdUnit");
                QCUnitDrop(ddlgrdUnit);

                HiddenField hdnLineNo = (HiddenField)e.Row.FindControl("hdnLineNo");
                DropDownList ddlgrdLineNo = (DropDownList)e.Row.FindControl("ddlgrdLineNo");
                QCUnitLineNo(ddlgrdLineNo, Convert.ToInt32(hdnUnit.Value));

                HiddenField hdnCluster = (HiddenField)e.Row.FindControl("hdnCluster");
                DropDownList ddlgrdCluster = (DropDownList)e.Row.FindControl("ddlgrdCluster");
                QCUnitCluster(ddlgrdCluster, Convert.ToInt32(hdnUnit.Value));

                if ((Convert.ToInt32(hdnQCId.Value) > 0) && (ddlgrdQCName.Items.Count > 0))
                {
                    ddlgrdQCName.SelectedValue = hdnQCId.Value;
                    ddlgrdQCName.Attributes.Add("disabled", "disabled");
                   
                }
                if ((Convert.ToInt32(hdnUnit.Value) > 0) && (ddlgrdUnit.Items.Count > 0))
                {
                  
                    ddlgrdUnit.SelectedValue = hdnUnit.Value;
                    ddlgrdUnit.Attributes.Add("disabled", "disabled");
                }
                if (hdnLineNo.Value != "")
                {
                    if ((Convert.ToInt32(hdnLineNo.Value) > 0) && (ddlgrdLineNo.Items.Count > 0))
                    {

                        ddlgrdLineNo.SelectedValue = hdnLineNo.Value;
                        ddlgrdLineNo.Attributes.Add("disabled", "disabled");
                    }
                    else
                    {
                        ddlgrdLineNo.Attributes.Add("disabled", "disabled");
                    }
                }
                
               
                if (hdnCluster.Value != "")
                {
                    if ((Convert.ToInt32(hdnCluster.Value) > 0) && (ddlgrdCluster.Items.Count > 0))
                    {
                        
                        ddlgrdCluster.SelectedValue = hdnCluster.Value;
                        ddlgrdCluster.Attributes.Add("disabled", "disabled");
                    }
                    else
                    {
                        ddlgrdCluster.Attributes.Add("disabled", "disabled");
                    }
                }
                else 
                {
                    ddlgrdCluster.Attributes.Add("disabled", "disabled");
                }
                

            }
        }
        protected void grdroamingQcEntry_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
           
        }
    }
}