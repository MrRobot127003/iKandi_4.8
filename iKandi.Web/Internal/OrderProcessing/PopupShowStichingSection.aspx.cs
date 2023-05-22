using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;
using iKandi.Common.Entities;

namespace iKandi.Web.Internal.OrderProcessing
{
    public partial class PopupShowStichingSection : System.Web.UI.Page
    {
        OrderController obj_OrderController = new OrderController();
        AdminController obj_AdminController = new AdminController();
        OBForm obj_OBForm = new OBForm();
        public int StyleId
        {
            get;
            set;
        }

        public int IsReuse
        {
            get;
            set;  
        }


        protected void Page_Load(object sender, EventArgs e) 
        {
            GetQueryString();
            if (!IsPostBack)
            {
                BindSection();
            }
        }


        protected void GetQueryString()
        {
            if (null != Request.QueryString["GarmentId"])
            {
                obj_OBForm.GarmentId = Request.QueryString["GarmentId"].ToString();
            }
            if (null != Request.QueryString["StyleCode"])
            {
                obj_OBForm.StyleCode = Request.QueryString["StyleCode"].ToString();
            }
            //
            if (null != Request.QueryString["StyleId"])
            {
                StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);
            }
            //
            if (null != Request.QueryString["ClientID"])
            {
                obj_OBForm.ClientID = Convert.ToInt32(Request.QueryString["ClientID"].ToString());
            }
            if (null != Request.QueryString["DeptId"])
            {
                obj_OBForm.DeptId = Convert.ToInt32(Request.QueryString["DeptId"].ToString());
            }
            if (null != Request.QueryString["IsReuse"])
            {
                IsReuse = Convert.ToInt32(Request.QueryString["IsReuse"].ToString());
            }
            
        }
        protected void BindSection()
        {
            DataTable dtBindSection = new DataTable();
            dtBindSection = obj_AdminController.GetStichedSection();
            lstSection.DataSource = dtBindSection;
            lstSection.DataValueField = "OBSectionID";
            lstSection.DataTextField = "Section";
            lstSection.DataBind();
            int CreateNew = 0;
            int NewRefrence = 0;
            int ReUseStyleId = -1;
            DataTable dtSection = new DataTable();

            dtSection = obj_OrderController.GetSectionById(obj_OBForm,StyleId, IsReuse, CreateNew, NewRefrence, ReUseStyleId);

            if (dtSection.Rows.Count > 0)
            {
                for (int idtSection=0; idtSection <= dtSection.Rows.Count-1; idtSection++)
                {
                    string opration = dtSection.Rows[idtSection]["OBSectionID"].ToString();

                    //foreach (var oprval in opration)
                    //{
                        if (lstSection.Items.FindByValue(opration.ToString()) != null)
                            lstSection.Items.FindByValue(opration.ToString()).Selected = true;
                    //}
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = obj_OrderController.DeleteStichedOperation(obj_OBForm.ClientID, obj_OBForm.DeptId, StyleId);
            for(int iSection=0; iSection<=lstSection.Items.Count-1;iSection++)
            {
                if(lstSection.Items[iSection].Selected)
                {
                    int SectionId=Convert.ToInt32(lstSection.Items[iSection].Value);
                    obj_OBForm.SectionId=SectionId;
                   
                    obj_OBForm.GarmentTypeID=Convert.ToInt32(obj_OBForm.GarmentId);
                    int IsSave = obj_OrderController.InsertSection(obj_OBForm, StyleId, -1, -1);

                    if (IsSave > 0)
                    {
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "sCancel", "window.opener.location.href = window.opener.location.href;self.close()", true);
                        var IsCreated = 1;
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "NewPage(" + IsCreated + ")", true);
                        
                    }
                }
            }

            
        }

        #region "METHOD FOR SHOW ALERT"
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        #endregion
    }
}