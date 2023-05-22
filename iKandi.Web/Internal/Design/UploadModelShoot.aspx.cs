using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Web.UI.HtmlControls;
using System.Text;

namespace iKandi.Web.Internal.Design
{
    public partial class UploadModelShoot : System.Web.UI.Page
    {
        public static string StyleId
        {
            get;
            set;
        }
        StyleController objStyleController = new StyleController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["StyleId"] != null && Request.QueryString["StyleId"].ToString() != "")
            {
                StyleId = Request.QueryString["StyleId"].ToString();

            }
            else StyleId = "0";

            if (!Page.IsPostBack)
            {
                BindComMarketingDropDown();
                BindDropDown();
                BindFault();
                BindTags();
            }
        }

        private void BindFault()
        {
            try
            {
                DataSet ds = objStyleController.GetFileDetailsByStyleId(Convert.ToInt32(StyleId));
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtTitle.Text = ds.Tables[1].Rows[0]["MarketingTitle"].ToString();
                    txtPrice.Text = ds.Tables[1].Rows[0]["MarketingPrice"].ToString();
                    lblFabricComposition.Text = ds.Tables[1].Rows[0]["Composition"].ToString();
                    lblFabricQuality.Text = ds.Tables[1].Rows[0]["Fabric"].ToString();
                    ddlGarmentType.SelectedValue = ds.Tables[1].Rows[0]["GarmentTypeID"].ToString();
                    //ddlTags.SelectedValue = ds.Tables[1].Rows[0]["MarketingTagId"].ToString();
                    ddlCollection.SelectedValue = ds.Tables[1].Rows[0]["MarketingCollectionId"].ToString();
                    //ddlCompositon.SelectedValue = ds.Tables[1].Rows[0]["MarketingCompositionId"].ToString();
                    ddlMOQ.SelectedValue = ds.Tables[1].Rows[0]["MarketingMOQId"].ToString();
                    txtShortDesc.Text = ds.Tables[1].Rows[0]["MarketingShortDescription"].ToString();
                    txtLongDesc.Text = ds.Tables[1].Rows[0]["MarketingLongDescription"].ToString();
                    // DataTable dt = new DataTable();
                    rptFile.DataSource = ds.Tables[0];
                    rptFile.DataBind();
                }
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    showUPFile.Visible = true;
                //}
               
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message.ToString());
            }
        }
        protected void BindTags() {
           
          //  DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dt = objStyleController.GetTagsByStyleId(Convert.ToInt32(StyleId));
          
            StringBuilder TagsListSB = new StringBuilder();
            for (int i = 0; i <= dt.Rows.Count-1; i++)
            {
                
                TagsListSB.Append("<div id='idchec'>" + dt.Rows[i]["TagName"] +  "<span class='DelBotton' onclick='DelTagsFun(this)'> <img src='../../images/Del-new.png' class='Delimg'/></div>");
                hdnTags.Value = hdnTags.Value + dt.Rows[i]["TagName"] + ",";
            }
             AddTagsVal.InnerHtml = TagsListSB.ToString();
            // hdnTags.Value = TagsListSB.ToString();
        }
        protected void ReBindTags()
        {
            string[] screenShotUrlCollection = hdnTags.Value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder TagsListSB = new StringBuilder();
            for (int i = 0; i <= screenShotUrlCollection.Length - 1; i++)
            {

                TagsListSB.Append("<div id='idchec'>" + screenShotUrlCollection[i] + "<span class='DelBotton' onclick='DelTagsFun(this)'> <img src='../../images/Del-new.png' class='Delimg'/></div>");
            }
            AddTagsVal.InnerHtml = TagsListSB.ToString();
          
        }
        protected void BindComMarketingDropDown()
        {

           // DataSet ds = new DataSet();
           // DataTable dt = new DataTable();
            DataSet  ds = objStyleController.BindMarketingTypeDropDown();
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    ddlTags.DataSource = ds.Tables[0];
            //    ddlTags.DataTextField = "TagName";
            //    ddlTags.DataValueField = "MarketingTagId";
            //    ddlTags.DataBind();
            //}
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCollection.DataSource = ds.Tables[0];
                ddlCollection.DataTextField = "CollectionName";
                ddlCollection.DataValueField = "MarketingCollectionId";
                ddlCollection.DataBind();
            }
            //if (ds.Tables[2].Rows.Count > 0)
            //{
            //    ddlCompositon.DataSource = ds.Tables[2];
            //    ddlCompositon.DataTextField = "CompositionName";
            //    ddlCompositon.DataValueField = "MarketingCompositionId";
            //    ddlCompositon.DataBind();
            //}
                 if (ds.Tables[1].Rows.Count > 0)
            {
                ddlMOQ.DataSource = ds.Tables[1];
                ddlMOQ.DataTextField = "MOQRangeStart";
                ddlMOQ.DataValueField = "MarketingMOQId";
                ddlMOQ.DataBind();
            }
        }

        protected void BindDropDown()
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = objStyleController.BindGarmentTypeDropDown();
            if (dt.Rows.Count > 0)
            {
                ddlGarmentType.DataSource = dt;
                ddlGarmentType.DataTextField = "GarmentType";
                ddlGarmentType.DataValueField = "GarmentTypeID";
                ddlGarmentType.DataBind();
            }
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
           
            //string AddTagName = hdnTags.Value;
            ReBindTags();
            var filename = "";
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ImageURL", typeof(string)));
            foreach (RepeaterItem rptItem in rptFile.Items)
            {
                HiddenField hdnFilePath = (HiddenField)rptItem.FindControl("hdnFilePath");
                DataRow dr = dt.NewRow();
                dr[0] = hdnFilePath.Value;
                dt.Rows.Add(dr);
            }
            if (Fldresolution.HasFile)
            {
                filename = iKandi.Web.Components.FileHelper.SaveFile(Fldresolution.PostedFile.InputStream, Fldresolution.FileName, Constants.STYLE_FOLDER_PATH, false, string.Empty);
                DataRow dr1 = dt.NewRow();
                dr1[0] = filename;
                dt.Rows.Add(dr1);
            }
            rptFile.DataSource = dt;
            rptFile.DataBind();
          
        }

        protected void btnSvaeFile_Click(object sender, EventArgs e)
        {
            // HtmlControl AddTagName=(HtmlInputControl) as fin
           // HtmlControl AddTagName = FindControl("AddTagsVal") as HtmlControl;

            //string AddTagName = hdnTags.Value;
            if (hdnTags.Value != "")
            {
                int resul = objStyleController.SaveTagNameByStyleId(Convert.ToInt32(StyleId), hdnTags.Value);
            }
          
            int result = objStyleController.DeleteFilesByStyleId(Convert.ToInt32(StyleId));
            int iCount = 1;
 
            foreach (RepeaterItem rptItem in rptFile.Items)
            {
               
                HiddenField hdnFilePath = (HiddenField)rptItem.FindControl("hdnFilePath");
                int re = objStyleController.SaveFileDetailByStyleId(Convert.ToInt32(StyleId), hdnFilePath.Value, ApplicationHelper.LoggedInUser.UserData.UserID, iCount);
                iCount = iCount + 1;
            }
            if (ddlGarmentType.SelectedValue == "-1")
            {
                ShowAlert("Please select garment type!");
                return;
            }
            //if (ddlTags.SelectedValue == "-1")
            //{
            //    ShowAlert("Please select Tags!");
            //    return;
            //}
            //if (ddlCompositon.SelectedValue == "-1")
            //{
            //    ShowAlert("Please select Composition!");
            //    return;
            //}
            //if (ddlCollection.SelectedValue == "-1")
            //{
            //    ShowAlert("Please select Collection!");
            //    return;
            //}
            //if (ddlMOQ.SelectedValue == "-1")
            //{
            //    ShowAlert("Please select MOQ!");
            //    return;
            //}
           // string dropval = ddlGarmentType.SelectedValue;
            int re1 = objStyleController.SaveMarketingDescription(Convert.ToInt32(StyleId), txtTitle.Text, ddlGarmentType.SelectedValue, Convert.ToInt32(ddlCollection.SelectedValue), ddlMOQ.SelectedValue,Convert.ToDecimal(txtPrice.Text), txtShortDesc.Text, txtLongDesc.Text, ApplicationHelper.LoggedInUser.UserData.UserID);
            Page.ClientScript.RegisterStartupScript(typeof(Page), "ShowMsg", "CallBackParentPage();", true);
        }

        protected void imgRow_Click(object sender, EventArgs e)
        {
            RepeaterItem rptItem = (RepeaterItem)(((Control)sender).NamingContainer);
            DataTable dt=new DataTable();
            dt.Columns.Add(new DataColumn("ImageURL", typeof(string)));
            foreach (RepeaterItem rptItem1 in rptFile.Items)
            {
                HiddenField hdnFilePath = (HiddenField)rptItem1.FindControl("hdnFilePath");
                DataRow dr = dt.NewRow();
                dr[0] = hdnFilePath.Value;
                dt.Rows.Add(dr);
            }
            dt.Rows[rptItem.ItemIndex].Delete();
            rptFile.DataSource = dt;
            rptFile.DataBind();
        }
    }
}