using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;
using System.IO;
using System.Text;


namespace iKandi.Web
{
    public partial class DesignerForm : BaseUserControl
    {
        public static String Flag
        {
            get;
            set;
        }
        #region Properties

        int _styleID = -1;
       

       


        public int styleid_New
        {
            get;
            set;
        }

        public int StyleID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["styleid"]))
                {
                    _styleID = Convert.ToInt32(Request.QueryString["styleid"]);
                }

                return _styleID;
            }

            set
            {
                this._styleID = value;
            }


        }



        #endregion

        #region Event Handlers
        public int ParentStyleid;
        protected void Page_Load(object sender, EventArgs e)
        {
            // iKandi.BLL.BackgroundProcessingController g = new iKandi.BLL.BackgroundProcessingController();
            //     g.ExecuteProcess();

            if (Request.QueryString["styleid"] != null)
            {
                ParentStyleid = Convert.ToInt32(Request.QueryString["styleid"]);
            }
            if (!IsPostBack)
            {
                ListItem li = new ListItem();
                li.Text = "Select";
                li.Value = "-1";
                ddlSeason.Items.Insert(0, li);
                ddlSeason.DataBind();
                BindControls();
                hdnuserid.Value = Convert.ToString(ApplicationHelper.LoggedInUser.UserData.UserID);
            }
            if (CbVisibleInMarketing.Checked == true) {
                LinkUploadModelShoot.Visible = true;
            }


        }

        protected void BindClientDepartments(int clientId, string value, bool textvalue)
        {
            List<ClientDepartment> cds = ClientControllerInstance.GetClientDeptsByClientID(clientId);
            ddlDept.DataSource = cds;
            ddlDept.DataValueField = "DeptID";
            ddlDept.DataTextField = "Name";
            ddlDept.DataBind();
            if (textvalue)
            {
                if (ddlDept.Items.FindByText(value) != null)
                    ddlDept.Items.FindByText(value).Selected = true;
            }
            else
            {
                if (ddlDept.Items.FindByValue(value) != null)
                    ddlDept.Items.FindByValue(value).Selected = true;
            }
        }

        protected void BindClientSeason(int clientId, string value, bool textvalue)
        {
            DataTable dt = ClientControllerInstance.GetSeasonByClient(clientId, this.StyleID.ToString());
            ddlSeason.DataSource = dt;
            ddlSeason.DataValueField = "ID";
            ddlSeason.DataTextField = "SeasonName";
            ddlSeason.DataBind();
            if (textvalue)
            {
                if (ddlSeason.Items.FindByText(value) != null)
                    ddlSeason.Items.FindByText(value).Selected = true;
            }
            else
            {
                if (ddlSeason.Items.FindByValue(value) != null)
                    ddlSeason.Items.FindByValue(value).Selected = true;
            }
        }


        protected void Submit_Click(object sender, EventArgs e)
        {
         

            // string styleNumber=string.Empty;
            //if (!Page.IsValid)
            //{
            //    if(ddlBuyer.SelectedItem.Text.Trim().ToUpper()!="SELECT")
            //    {
            //        //PageHelper.AddJScriptVariable("deptSeason",
            //        //                              "{" +
            //        //                              string.Format("{0}|{1}{2}", ddlDept.SelectedItem.Value, hdnDeptName,
            //        //                                            hdnSeason.Value) + "}");
            //        BindClientDepartments(Convert.ToInt32(ddlBuyer.SelectedItem.Value), hdnDeptName.Value, true);
            //        BindClientSeason(Convert.ToInt32(ddlBuyer.SelectedItem.Value), hdnSeason.Value, false);
            //    }

            //   // ddlDept.Text = hdnDeptName.Value;
            //    //ddlSeason.Text = hdnSeason.Value;
            //    return;
            //}

            int IsIkandiClient = 0;
            int isRepeatStyleno = 0;
            var selectradio = Convert.ToInt32(rdobtn.SelectedValue);

            IsIkandiClient = this.ClientControllerInstance.GetClientsInfo_BuyingHouse(Convert.ToInt32(ddlBuyer.SelectedItem.Value));
            //Edit by surendra on 10 jan 2013
            if (txtDesignerCode.Text == "")
            {
                isRepeatStyleno = this.ClientControllerInstance.GetDuplicateStyleNo(ddlDesignerCode.SelectedValue + txtStyle1.Text);

            }
            else
            {
                isRepeatStyleno = this.ClientControllerInstance.GetDuplicateStyleNo(txtDesignerCode.Text + txtStyle1.Text);

            }
            //if (IsIkandiClient == 1 && (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_SamplingMerchant))
            //{
            //    //sp_BuyingHouse_get_clients_info_clientID
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "$(function(){alert('Sorry you can not create a style for this client');});", true);
            //    return;
            //}
            //else if (IsIkandiClient == 0 && (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Design_Assistant || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Design_Designers))
            //{
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "$(function(){alert('Sorry you can not create a style for this client');});", true);
            //    return;
            //}

            if (isRepeatStyleno != 0)
            {
                if (this.StyleID == -1)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "$(function(){alert('Sorry you can not create a duplicate style no');});", true);
                    return;
                }
                else
                {
                    CreateStyle(this.StyleID, false, ParentStyleid);
                }
            }
            // end
            else { CreateStyle(this.StyleID, false, ParentStyleid); }



        }

        protected void SaveAs_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            CreateStyle(-1, true, ParentStyleid);
        }

        protected void rptTab_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                iKandi.Common.Style style = e.Item.DataItem as iKandi.Common.Style;

                if (style.StyleID == this.StyleID)
                {
                    ((HyperLink)e.Item.FindControl("hlkDesign")).CssClass = "selectedTabs";
                    // ((HyperLink)e.Item.FindControl("hlkDesign")).CssClass = string.Empty;
                }
                else
                {
                    ((HyperLink)e.Item.FindControl("hlkDesign")).CssClass = string.Empty;
                }
            }
        }

        #endregion

        public void BindDDLBuyingHouse(string DivisionID)
        {
            DataTable dt = this.PrintControllerInstance.GetBuyingHouseByDivision(DivisionID);
            ddlBuyingHouse.DataSource = dt;
            ddlBuyingHouse.DataTextField = "CompanyName";
            ddlBuyingHouse.DataValueField = "ID";
            ListItem li = new ListItem();
            li.Text = "Select";
            li.Value = "-1";
            ddlBuyingHouse.Items.Insert(0, li);
            ddlBuyingHouse.DataBind();
        }

        private void BindControls()
        {
            //DropdownHelper.BindClients(ddlBuyer as ListControl);
            bindDivisionName();
            //DropdownHelper.BindBuyingHouse(ddlBuyingHouse as ListControl);
            //DropdownHelper.BindClientsDesign(ddlBuyer as ListControl, Convert.ToInt32(ddlBuyingHouse.SelectedValue));
            //DropdownHelper.BindFabric(ddlFabricType as ListControl);
            //DropdownHelper.BindPrints(ddlPrint as ListControl);
            //BindDDLBuyingHouse();
            DropdownHelper.BindCurrency(ddlCurrency as ListControl);

            rptTab.DataSource = this.StyleControllerInstance.GetAllStyleVariations(this.StyleID);
            rptTab.DataBind();

            lblDesignerName.Text = ApplicationHelper.LoggedInUser.UserData.FullName;

            var emaildomain = ApplicationHelper.LoggedInUser.UserData.Email.Split('@');
            if (emaildomain[1].Trim().ToUpper() == "IKANDI.ORG.UK")
                this.PopulateDesignerCode(ApplicationHelper.LoggedInUser.UserData.DesignerCode.ToString());
            else
                this.PopulateDesignerCode("");

            if (StyleID == -1)
            {
                trUpdatedBy.Visible = false;

                lblDateTime.Text = DateTime.Now.ToString("dd MMM yy (ddd) ");

                this.chkDefaultETA.Checked = true;
                // Make it constant on configuration
                this.txtETA.Text = DateTime.Now.AddDays(21).ToString("dd MMM yy (ddd)");
                this.ddlCurrency.SelectedValue = ((int)Currency.GBP).ToString();

            }
            if (StyleID != -1)
            {
                rfvupSketch1.Enabled = false;
                PopulateStyleData();
            }
            DataSet ds = this.StyleControllerInstance.GetAccsessoryDetails(StyleID);

            DataTable dt = ds.Tables[0];
            ViewState["Accsessoryname"] = dt;
            if (ViewState["datatable"] != null)
            {
                //Updated code by bharat 5-feb-19
                DataTable dtAccess = (DataTable)ViewState["datatable"];
                if (dtAccess.Rows.Count == 0)
                {
                    dtAccess.Rows.Add(dtAccess.NewRow());

                    grdAccsessory.DataSource = dtAccess;
                    grdAccsessory.DataBind();
                    grdAccsessory.Rows[0].Visible = false;
                    LinkButton abtnAdd = grdAccsessory.FooterRow.FindControl("abtnAdd") as LinkButton;
                    abtnAdd.CommandName = "addnew";
                }
                else
                {
                    grdAccsessory.DataSource = dtAccess;
                    grdAccsessory.DataBind();
                }

            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    grdAccsessory.DataSource = dt;
                    grdAccsessory.DataBind();
                    ViewState["datatable"] = dt;
                    grdAccsessory.Visible = true;
                    LinkButton abtnAdd = grdAccsessory.FooterRow.FindControl("abtnAdd") as LinkButton;
                    abtnAdd.CommandName = "Insert";
                }
                else
                {
                    ViewState["datatable"] = dt;
                    dt.Rows.Add(dt.NewRow());
                    grdAccsessory.DataSource = dt;
                    grdAccsessory.DataBind();

                    grdAccsessory.Rows[0].Visible = false;
                    LinkButton abtnAdd = grdAccsessory.FooterRow.FindControl("abtnAdd") as LinkButton;
                    abtnAdd.CommandName = "addnew";
                }
            }

        }
        //Changed by surendra2 on 24-10-2018.
        private void GetDepartmentDropdownInformationAtPrint(string BuyerSelectedValue)
        {
            List<ClientDepartment> objClientDepartment = this.ClientControllerInstance.GetClientDeptsByClientID_ForDesignForm(Convert.ToInt32(BuyerSelectedValue), -1, Convert.ToInt32(ddlParentDept.SelectedValue), "SubParent");

            foreach (ClientDepartment cdept in objClientDepartment)
            {
                ddlDept.Items.Add(new ListItem(cdept.Name, cdept.DeptID.ToString()));

            }
        }
        private void GetParentDepartmentDropdownInformationAtPrint(string BuyerSelectedValue)
        {
            List<ClientDepartment> objClientDepartment = this.ClientControllerInstance.GetClientDeptsByClientID_ForDesignForm(Convert.ToInt32(BuyerSelectedValue), -1, -1, "Parent");

            foreach (ClientDepartment cdept in objClientDepartment)
            {
                ddlParentDept.Items.Add(new ListItem(cdept.Name, cdept.DeptID.ToString()));

            }
        }
        private void PopulateStyleData()
        {
            iKandi.Common.Style style = this.StyleControllerInstance.GetStyleByStyleId(StyleID);

            // Added by Yadvendra on 06/01/2020
            CbVisibleInMarketing.Checked = style.IsMarketingVisible == true ? true : false;
            // worked by prabhaker 17-apr-17
            if (style.IcheckAutoAllocationDone == 1)
            {
                rdobtn.Enabled = false;
            }
            else
            {
                rdobtn.Enabled = true;
            }
            // end worked by prabhaker 17-apr-17
            if ((style.fitstype == 3) && (style.Sample_Sent_Action != ""))
                txtETA.Enabled = false;
            else
                txtETA.Enabled = true;

            rfvupSketch.Enabled = false;
            rfvupDoc.Enabled = false;
            txtStory.Text = style.Story;
            ddlDivisionName.SelectedValue = style.DivisionID;
            BindDDLBuyingHouse(style.DivisionID);
            ddlBuyingHouse.SelectedValue = Convert.ToString(style.BuyingHouseID);
            DropdownHelper.BindClientsDesign(ddlBuyer as ListControl, Convert.ToInt32(ddlBuyingHouse.SelectedValue));

            //DropdownHelper.BindUsersByDesignation(ddlSampling as ListControl, style.AccountManagerID, Convert.ToInt32(Designation.BIPL_Merchandising_SamplingMerchant));
            DropdownHelper.GetSamplingMerchandiserByDeptID(ddlSampling as ListControl, style.DepartmentID, 32);
            DropdownHelper.GetClientAccMgrByClientID(ddlAccMgr as ListControl, style.DepartmentID);
            hdnStyleID.Value = (style.StyleID).ToString();

            string story = string.Empty;
            if (!string.IsNullOrEmpty(style.Story))
            {
                story = style.Story.Replace("$$", "<br/>").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;");
            }
            else story = "";
            //            ImgRemarks.Attributes.Add("onclick", "showRemarks2('" + style.StyleID + "',0,'" + story + "','StoryPoints','DESIGN_FORM',0)");
            ImgRemarks.Attributes.Add("onclick", "showRemarks2('" + story + "')");
            //onclick=

            if (style.StyleNumberDesc.IndexOf("!") > -1)
            {
                string styleSeries = string.Empty;
                if (style.StyleNumberDesc.IndexOf("$") > -1)
                {
                    string[] styleCode1 = style.StyleNumberDesc.Split((new char[] { '$' }));
                    if (styleCode1.Length > 1)
                    {
                        txtStyle.Text = styleCode1[0];/// for SK, TP etc
                        styleSeries = styleCode1[1];
                    }
                    else styleSeries = styleCode1[0];
                }
                else styleSeries = style.StyleNumberDesc;

                if (styleSeries.IndexOf("!") > -1)
                {
                    string[] styleCode2 = styleSeries.Split((new char[] { '!' }));
                    if (styleCode2.Length > 1)
                    {
                        //Edit by surendra on 10 jan 2013
                        //if (ApplicationHelper.LoggedInUser.UserData.UserID == 417)
                        //{

                        //    txtDesignerCode.Text ="102";/// for Designer Series
                        //    txtDesignerCode.ReadOnly = true;                         /// 
                        //    this.SetDesignerCode(txtDesignerCode.Text);
                        //    styleSeries = styleCode2[1];

                        //}
                        //else  if (ApplicationHelper.LoggedInUser.UserData.UserID == 420)
                        //{

                        //    txtDesignerCode.Text = "103";/// for Designer Series
                        //    txtDesignerCode.ReadOnly = true;                         /// 
                        //    this.SetDesignerCode(txtDesignerCode.Text);
                        //    styleSeries = styleCode2[1];

                        //}
                        //else
                        //{
                        txtDesignerCode.Text = styleCode2[0];/// for Designer Series
                        this.SetDesignerCode(txtDesignerCode.Text);
                        styleSeries = styleCode2[1];
                        //}
                        //end

                    }
                    else
                    {
                        styleSeries = styleCode2[0];
                    }
                }

                string[] styleParts = styleSeries.Split(new char[] { ' ' });
                //int len = styleParts[1].Length;
                for (int i = 0; i < styleParts.Length; i++)
                {
                    if (i == 0)
                    {
                        txtStyle1.Text = styleParts[0];
                    }
                    if (i == 1)
                    {
                        txtStyle2.Text = styleParts[1];
                    }
                }
            }
            else
            {
                if (style.StyleNumber.IndexOf(" ") > -1)
                {
                    string[] styleParts = style.StyleNumber.Split(new char[] { ' ' });
                    int len = styleParts[1].Length;
                    for (int i = 0; i < styleParts.Length; i++)
                    {
                        if (i == 0)
                        {
                            txtStyle.Text = styleParts[0];
                        }
                        if (i == 1)
                        {
                            //this.SetDesignerCode(styleParts[1].Substring(0, 1));

                            txtStyle1.Text = styleParts[1].Substring(1, len - 1);
                        }
                        if (i == 2)
                        {
                            txtStyle2.Text = styleParts[2];
                        }
                    }
                }
            }
            txtStyle1.Text = txtStyle1.Text.Replace("!", "").Replace("$", "");
            hdnstylecodeNew.Value = txtStyle1.Text;

            if (!string.IsNullOrEmpty(style.SketchURL))
            {
                //imgSketch.Visible = true;
                HyperLinkimgSketch.Visible = true;
                //chkSketch.Visible = true;
                imgSketch.ImageUrl = ResolveUrl("~/Uploads/Style/" + style.SketchURL);
                HyperLinkimgSketch.NavigateUrl = ResolveUrl("~/Uploads/Style/" + style.SketchURL);
                HyperLinkimgSketch.Target = "_blank";
            }

            if (!string.IsNullOrEmpty(style.DocURL))
            {
                hlkViewMe.NavigateUrl = ResolveUrl("~/Uploads/Style/" + style.DocURL);
                hlkViewMe.Visible = true;
                //lnkDoc.Visible = true;
                lnkDoc.PostBackUrl = ResolveUrl("~/Uploads/Style/" + style.DocURL);
            }
            if (!string.IsNullOrEmpty(style.TackpackFile))
            {
                hlkviewtackpack.NavigateUrl = ResolveUrl("~/Uploads/Style/" + style.TackpackFile);
                hlkviewtackpack.Visible = true;
                lnktackpack.PostBackUrl = ResolveUrl("~/Uploads/Style/" + style.TackpackFile);
            }

            //add by prabhaker
            if (!string.IsNullOrEmpty(style.TackpackFile1))
            {
                hlkviewtackpack1.NavigateUrl = ResolveUrl("~/Uploads/Style/" + style.TackpackFile1);
                hlkviewtackpack1.Visible = true;
                //Imgtechfile1.ImageUrl = ResolveUrl("~/Uploads/Style/" + style.TackpackFile1);
                lnktackpack1.PostBackUrl = ResolveUrl("~/Uploads/Style/" + style.TackpackFile1);
            }

            if (!string.IsNullOrEmpty(style.TackpackFile2))
            {
                hlkviewtackpack2.NavigateUrl = ResolveUrl("~/Uploads/Style/" + style.TackpackFile2);
                hlkviewtackpack2.Visible = true;
                //Imgtechfile2.ImageUrl = ResolveUrl("~/Uploads/Style/" + style.TackpackFile2);
                lnktackpack2.PostBackUrl = ResolveUrl("~/Uploads/Style/" + style.TackpackFile2);
            }

            //end of code



            if (!string.IsNullOrEmpty(style.SampleImageURL1))
            {
                hypSample1.Visible = true;
                hypSample1.NavigateUrl = ResolveUrl("~/Uploads/Style/" + style.SampleImageURL1);
            }
            if (!string.IsNullOrEmpty(style.SampleImageURL2))
            {
                hypSample2.Visible = true;
                hypSample2.NavigateUrl = ResolveUrl("~/Uploads/Style/" + style.SampleImageURL2);
            }
            if (!string.IsNullOrEmpty(style.SampleImageURL3))
            {
                hypSample3.Visible = true;
                hypSample3.NavigateUrl = ResolveUrl("~/Uploads/Style/" + style.SampleImageURL3);
            }

            List<StyleReferenceBlock> refBlocksembellishment = style.ReferenceBlocks.FindAll(delegate(StyleReferenceBlock s)
            {
                return s.Type == 3;
            });

            for (int i = 0; i <= refBlocksembellishment.Count - 1; i++)
            {
                if (!string.IsNullOrEmpty(refBlocksembellishment[i].ImagePath))
                {
                    hypEmbleshment.Visible = true;
                    imgEmblessment.Visible = true;
                    hypEmbleshment.NavigateUrl = ResolveUrl("~/Uploads/Style/" + refBlocksembellishment[i].ImagePath);
                }

            }

            List<StyleReferenceBlock> refMocks = style.ReferenceBlocks.FindAll(delegate(StyleReferenceBlock s)
            {
                return s.Type == 4;
            });


            for (int i = 0; i <= refMocks.Count - 1; i++)
            {
                if (!string.IsNullOrEmpty(refMocks[i].ImagePath))
                {
                    hypMocks.Visible = true;
                    hypMocks.NavigateUrl = ResolveUrl("~/Uploads/Style/" + refMocks[i].ImagePath);
                }
            }

            List<StyleReferenceBlock> refCad = style.ReferenceBlocks.FindAll(delegate(StyleReferenceBlock s)
            {
                return s.Type == 5;
            });

            for (int i = 0; i <= refCad.Count - 1; i++)
            {
                if (!string.IsNullOrEmpty(refCad[i].ImagePath))
                {

                    hypCad.Visible = true;
                    hypCad.NavigateUrl = ResolveUrl("~/Uploads/Style/" + refCad[i].ImagePath);

                }

            }
            if (Request.QueryString["styleid"] != null)
            {
                bool count = true;
                ListItem li = new ListItem(style.ClientName.ToString(), style.ClientID.ToString());
                for (int i = 0; i <= ddlBuyer.Items.Count - 1; i++)
                {
                    if (li.Value == ddlBuyer.Items[i].Value)
                    {
                        count = false;
                    }
                }
                if (count == true)
                {
                    ddlBuyer.Items.Add(li);
                    hdndddlexistancecheck.Value = "1";
                }
            }
            ddlBuyer.SelectedValue = style.ClientID.ToString();
            txtETA.Text = style.ETA.ToString("dd MMM yy (ddd)");

            //Changed by surendra2 on 24-10-2018.
            GetParentDepartmentDropdownInformationAtPrint(ddlBuyer.SelectedValue.ToString());
            ddlParentDept.SelectedValue = style.ParentDepartmentID.ToString();
            GetDepartmentDropdownInformationAtPrint(ddlBuyer.SelectedValue);
            ddlDept.SelectedValue = style.DepartmentID.ToString();

            lblDateTime.Text = style.CreatedOn.ToString("dd MMM yy (ddd)");
            if (style.UpdatedOn.Year.ToString() == "1")
            {
                lblDateUpdated.Text = style.CreatedOn.ToString("dd MMM yy (ddd)");
            }
            else
            {
                lblDateUpdated.Text = style.UpdatedOn.ToString("dd MMM yy (ddd)");
            }
            lblUpdatedBy.Text = style.UpdatedBy;

            //if (!string.IsNullOrEmpty(style.Story))
            //{
            //    txtStory.Text = style.Story;
            //}
            //BindDDLSeason(style.ClientID);
            BindClientSeason(style.ClientID, style.SeasonID.ToString(), false);
            hdnSeason.Value = Convert.ToString(style.SeasonID);
            srvrHdnSeasonName.Value = style.StyleID.ToString();
            //  ddlSeason.SelectedItem.Text = Convert.ToString(style.SeasonName);
            //  ddlSeason.SelectedValue = Convert.ToString(style.SeasonID);
            if (style.StyleMeeting != DateTime.MinValue)
            {
                txtMeeting.Text = style.StyleMeeting.ToString("dd MMM yy (ddd)");
            }
            txtComments.Text = style.Comments;
            txtTarget.Text = style.TargetPrice.ToString();
            ddlCurrency.SelectedValue = style.TargetPriceCurrency.ToString();
            BindClientDepartments(style.ClientID, style.DepartmentID.ToString(), false);
            ddlSampling.SelectedValue = style.SamplingMerchandisingManagerID.ToString();
            //ddlDept.SelectedValue = style.DepartmentID.ToString();
            ddlAccMgr.SelectedValue = style.AccountManagerID.ToString();
            rdobtn.SelectedValue = style.fitstype.ToString();
            rdobuttonStyleSequence.SelectedValue = style.IsDefaultStyle.ToString();
            if (style.IsDefaultStyle.ToString() == "1")
            {
                rdobuttonStyleSequence.Enabled = false;
            }
            if (!string.IsNullOrEmpty(style.DesignerName))
            {
                lblDesignerName.Text = style.DesignerName;
            }

            if (style.Fabrics != null && style.Fabrics.Count > 0)
            {
                System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
         new System.Web.Script.Serialization.JavaScriptSerializer();

                string sJSON = oSerializer.Serialize(style.Fabrics);

                PageHelper.AddJScriptVariable("styleFabrics", "{" + string.Format("table: {0}", sJSON) + "}");
            }


            List<StyleReferenceBlock> refBlocks = style.ReferenceBlocks.FindAll(delegate(StyleReferenceBlock s)
            {
                return s.Type == 1;
            });

            for (int i = 0; i <= refBlocks.Count - 1; i++)
            {
                if (i == 0)
                {
                    HiddenRefId1.Value = refBlocks[i].Id.ToString();
                    if (refBlocks[i].Type == 1)
                        txtRefBlock1.Text = refBlocks[i].Name;

                    if (!string.IsNullOrEmpty(refBlocks[i].ImagePath))
                    {
                        RefUrl1.Visible = false;
                        chkRefBlock1.Visible = true;
                        RefUrl1.ImageUrl = refBlocks[i].ImagePath;
                        ImgRef1.Visible = true;
                        hyp1.NavigateUrl = ResolveUrl("~/Uploads/Style/" + RefUrl1.ImageUrl);
                    }
                }

                if (i == 1)
                {
                    HiddenRefId2.Value = refBlocks[i].Id.ToString();
                    if (refBlocks[i].Type == 1)
                        txtRefBlock2.Text = refBlocks[i].Name;

                    if (!string.IsNullOrEmpty(refBlocks[i].ImagePath))
                    {
                        RefUrl2.Visible = false;
                        chkRefBlock2.Visible = true;
                        RefUrl2.ImageUrl = refBlocks[i].ImagePath;
                        ImgRef2.Visible = true;
                        hyp2.NavigateUrl = ResolveUrl("~/Uploads/Style/" + RefUrl2.ImageUrl);
                    }
                }
                if (i == 2)
                {
                    HiddenRefId3.Value = refBlocks[i].Id.ToString();
                    if (refBlocks[i].Type == 1)
                        txtRefBlock3.Text = refBlocks[i].Name;

                    if (!string.IsNullOrEmpty(refBlocks[i].ImagePath))
                    {
                        RefUrl3.Visible = false;
                        chkRefBlock3.Visible = true;
                        RefUrl3.ImageUrl = refBlocks[i].ImagePath;
                        ImgRef3.Visible = true;
                        hyp3.NavigateUrl = ResolveUrl("~/Uploads/Style/" + RefUrl3.ImageUrl);
                    }
                }
            }

            //  For Ind Block
            List<StyleReferenceBlock> indBlocks = style.ReferenceBlocks.FindAll(delegate(StyleReferenceBlock s)
            {
                return s.Type == 2;
            });

            for (int i = 0; i < indBlocks.Count; i++)
            {

                if (i == 0)
                {
                    hiddenInd1Id.Value = indBlocks[i].Id.ToString();
                    txtIndBlock1.Text = indBlocks[i].Name;

                    if (!string.IsNullOrEmpty(indBlocks[i].ImagePath))
                    {
                        imgInd1.Visible = true;
                        hypInd1.NavigateUrl = ResolveUrl("~/Uploads/Style/" + indBlocks[i].ImagePath);
                    }
                }

                if (i == 1)
                {
                    hiddenInd2Id.Value = indBlocks[i].Id.ToString();
                    txtIndBlock2.Text = indBlocks[i].Name;

                    if (!string.IsNullOrEmpty(indBlocks[i].ImagePath))
                    {
                        imgInd2.Visible = true;
                        hypInd2.NavigateUrl = ResolveUrl("~/Uploads/Style/" + indBlocks[i].ImagePath);
                    }
                }

                if (i == 2)
                {
                    hiddenInd3Id.Value = indBlocks[i].Id.ToString();
                    txtIndBlock3.Text = indBlocks[i].Name;

                    if (!string.IsNullOrEmpty(indBlocks[i].ImagePath))
                    {
                        imgInd3.Visible = true;
                        hypInd3.NavigateUrl = ResolveUrl("~/Uploads/Style/" + indBlocks[i].ImagePath);
                    }
                }

            }

            PageHelper.AddJScriptVariable("selectedDeptID", style.DepartmentID);
            PageHelper.AddJScriptVariable("selectedAccManagerID", style.AccountManagerID);
            PageHelper.AddJScriptVariable("selectedSeasonID", style.SeasonID);

            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "$(function(){onCompanyChange()});", true);
        }

        //Create by Surendra 2 on 21-03-2018...
        bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                case ".png":
                    return true;
                default:
                    return false;
            }
        }

        private void CreateStyle(int StyleID, bool SaveStyleNew, int ParentStyleid)
        {
            if (string.IsNullOrEmpty(Request.Params["txtFabricName1"]))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "$(function(){alert('Sorry atleast one fabric is required');});", true);
                return;
            }

            int designerId = ApplicationHelper.LoggedInUser.UserData.UserID;

            iKandi.Common.Style style;
            if (StyleID == -1)
            {
                style = new iKandi.Common.Style();
            }
            else
            {
                style = this.StyleControllerInstance.GetStyleByStyleId(StyleID);
            }

            style.StyleID = StyleID;
            //string strmaxStyleCode = hdnstylecodeNew.Value;
            if (Convert.ToInt32(rdobuttonStyleSequence.SelectedValue) == 2)
            {
                style.StyleNumber = ((txtStyle.Text) + " " + txtStyle1.Text + " " + txtStyle2.Text).ToString().Trim();
                //style.StyleNumber = ((txtStyle.Text) + " " + strmaxStyleCode + " " + txtStyle2.Text).ToString().Trim();

                style.StyleNumberDesc = ((txtStyle.Text) + "$" + "" + "!" + txtStyle1.Text + " " + txtStyle2.Text).ToString().Trim();
                //style.StyleNumberDesc = ((txtStyle.Text) + "$" + txtDesignerCode.Text + "!" + strmaxStyleCode + " " + txtStyle2.Text).ToString().Trim();
            }
            else
            {
                string strmaxStyleCode = hdnstylecodeNew.Value;
                style.StyleNumber = ((txtStyle.Text) + " " + txtDesignerCode.Text + strmaxStyleCode + " " + txtStyle2.Text).ToString().Trim();
                //style.StyleNumberDesc = ((txtStyle.Text) + "$" + this.GetDesignerCode() + "!" + txtStyle1.Text + " " + txtStyle2.Text).ToString().Trim();
                style.StyleNumberDesc = ((txtStyle.Text) + "$" + txtDesignerCode.Text + "!" + strmaxStyleCode + " " + txtStyle2.Text).ToString().Trim();
            }
            //style.StyleNumberDesc = ((txtStyle.Text) + "$" + "" + "!" + strmaxStyleCode + " " + txtStyle2.Text).ToString().Trim();
            style.DivisionID = ddlDivisionName.SelectedValue;
            style.IsMarketingVisible = CbVisibleInMarketing.Checked == true ? true : false;
            style.IsDefaultStyle = Convert.ToInt32(rdobuttonStyleSequence.SelectedValue);
            style.fitstype = Convert.ToInt32(rdobtn.SelectedValue);
            if (Convert.ToInt32(ddlBuyer.SelectedValue) > 0)
            {
                style.ClientID = Convert.ToInt32(ddlBuyer.SelectedValue);
            }
            else
            {
                style.ClientID = Convert.ToInt32(hdnBuyer.Value);
            }
            if (Convert.ToInt32(style.ClientID) < 1)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "$(function(){alert('Please select Client for this style');});", true);
                return;
            }

            style.ClientName = ddlBuyer.SelectedItem.Text;

            if (!string.IsNullOrEmpty(Request.Params[ddlDept.UniqueID]))
            {
                style.DepartmentID = Convert.ToInt32(Request.Params[ddlDept.UniqueID]);
                style.DepartmentName = hdnDeptName.Value;
            }
            if (!string.IsNullOrEmpty(Request.Params[ddlParentDept.UniqueID]))
            {
                style.ParentDepartmentID = Convert.ToInt32(Request.Params[ddlParentDept.UniqueID]);
                style.ParentDepartmentName = hdnParentDeptName.Value;
            }
            if (!string.IsNullOrEmpty(Request.Params[ddlSeason.UniqueID]))
            {
                style.SeasonID = Convert.ToInt32(Request.Params[ddlSeason.UniqueID]);
            }
            else style.SeasonID = Convert.ToInt32(ddlSeason.SelectedValue);
            //style.SeasonID = Convert.ToInt32(ddlSeason.SelectedValue);
            if (!string.IsNullOrEmpty(txtStory.Text))
            {
                style.Story = "$$" + Convert.ToString(ApplicationHelper.LoggedInUser.UserData.FirstName + ' ' + ApplicationHelper.LoggedInUser.UserData.LastName) + "(" + DateTime.Now.ToString("dd MMM yy (ddd)") + "): " + txtStory.Text + "$$";
            }
            style.StyleMeeting = DateHelper.ParseDate(txtMeeting.Text).Value;

            if (upSketch.HasFile)
            {
                if (CheckFileType(upSketch.FileName))
                {
                    style.SketchURL = FileHelper.SaveFile(upSketch.PostedFile.InputStream, upSketch.FileName, Constants.STYLE_FOLDER_PATH, true, style.StyleNumber);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "$(function(){alert('Only Jpeg and Png File Upload in Style Sketch!');});", true);
                    return;
                }

            }
            else if (!string.IsNullOrEmpty(style.SketchURL))
            {
                style.SketchURL = style.SketchURL;
            }
            else if (!string.IsNullOrEmpty(imgSketch.ImageUrl))
            {
                int slashIndex = imgSketch.ImageUrl.LastIndexOf("/");
                string imagePath = imgSketch.ImageUrl.Substring(slashIndex + 1);
                style.SketchURL = imagePath;
            }

            if (upDoc.HasFile)
            {
                style.DocURL = FileHelper.SaveFile(upDoc.PostedFile.InputStream, upDoc.FileName, Constants.STYLE_FOLDER_PATH, true, "upDoc" + style.StyleNumber);
            }
            else if (!string.IsNullOrEmpty(style.DocURL))
            {
                style.DocURL = style.DocURL;
            }
            else if (!string.IsNullOrEmpty(lnkDoc.PostBackUrl))
            {
                int slashIndex = lnkDoc.PostBackUrl.LastIndexOf("/");
                string docPath = lnkDoc.PostBackUrl.Substring(slashIndex + 1);
                style.DocURL = docPath;
            }
            //added by abhishek 22/5/2017

            if (filetackpack.HasFile)
            {
                style.TackpackFile = FileHelper.SaveFile(filetackpack.PostedFile.InputStream, filetackpack.FileName, Constants.STYLE_FOLDER_PATH, true, "TechPacks_" + style.StyleNumber);
            }
            else if (!string.IsNullOrEmpty(style.TackpackFile))
            {
                style.TackpackFile = style.TackpackFile;
            }
            else if (!string.IsNullOrEmpty(lnktackpack.PostBackUrl))
            {
                int slashIndex = lnktackpack.PostBackUrl.LastIndexOf("/");
                string docTeckPackPath = lnktackpack.PostBackUrl.Substring(slashIndex + 1);
                style.TackpackFile = docTeckPackPath;
            }




            //added By Prabhaker
            if (filetackpack1.HasFile)
            {
                style.TackpackFile1 = FileHelper.SaveFile(filetackpack1.PostedFile.InputStream, filetackpack1.FileName, Constants.STYLE_FOLDER_PATH, true, "TechPacksone_" + style.StyleNumber);
            }
            else if (!string.IsNullOrEmpty(style.TackpackFile1))
            {
                style.TackpackFile1 = style.TackpackFile1;
            }
            else if (!string.IsNullOrEmpty(lnktackpack1.PostBackUrl))
            {
                int slashIndex1 = lnktackpack1.PostBackUrl.LastIndexOf("/");
                string docTeckPackPath1 = lnktackpack1.PostBackUrl.Substring(slashIndex1 + 1);
                style.TackpackFile1 = docTeckPackPath1;
            }



            if (filetackpack2.HasFile)
            {
                style.TackpackFile2 = FileHelper.SaveFile(filetackpack2.PostedFile.InputStream, filetackpack2.FileName, Constants.STYLE_FOLDER_PATH, true, "TechPackstwo_" + style.StyleNumber);
            }
            else if (!string.IsNullOrEmpty(style.TackpackFile2))
            {
                style.TackpackFile2 = style.TackpackFile2;
            }
            else if (!string.IsNullOrEmpty(lnktackpack2.PostBackUrl))
            {
                int slashIndex2 = lnktackpack2.PostBackUrl.LastIndexOf("/");
                string docTeckPackPath2 = lnktackpack.PostBackUrl.Substring(slashIndex2 + 1);
                style.TackpackFile2 = docTeckPackPath2;
            }
            //end of Code


            style.ETA = DateHelper.ParseDate(txtETA.Text).Value;

            if (!string.IsNullOrEmpty(txtTarget.Text))
                style.TargetPrice = Convert.ToDecimal(txtTarget.Text);
            style.TargetPriceCurrency = ddlCurrency.SelectedValue;

            if (!string.IsNullOrEmpty(Request.Params[ddlAccMgr.UniqueID]))
            {
                style.AccountManagerID = Convert.ToInt32(Request.Params[ddlAccMgr.UniqueID]);
            }

            style.SamplingMerchandisingManagerID = Convert.ToInt32(Request.Params[ddlSampling.UniqueID]);
            style.IssuedOn = DateTime.Now;
            style.DesignerID = designerId;
            style.FactoryName = "BIPL"; // TODO: Remove hardcoding
            style.Comments = txtComments.Text;

            // int i = 1;
            style.Fabrics = new List<StyleFabric>();
            StringBuilder strFabric = new StringBuilder();
            //string strFabric = string.Empty;
            //while (!string.IsNullOrEmpty(Request.Params["txtFabricName" + i.ToString()]))
            for (int i = 1; i <= 6; i++)
            {
                if (string.IsNullOrEmpty(Request.Params["txtFabricName" + i.ToString()]))
                {
                    continue;
                }
                int j = 1;
                int total = 0;
                if (i == 1)
                    strFabric.Append("<table>");
                //txtRemarks1_1
                total = Convert.ToInt32(Request.Params["hdntotal" + i.ToString()]);
                while ((!string.IsNullOrEmpty(Request.Params["ddlFabricType" + i.ToString() + "_" + j.ToString()])) || total > 0)
                {
                    StyleFabric stylefab = new StyleFabric();
                    string s = Request.Params["txtFabricName" + i.ToString()];
                    string[] ss = s.Split('[');
                    stylefab.FabricName = ss[0];
                    stylefab.Remarks = Request.Params["txtRemarks" + i.ToString() + "_" + j.ToString()];

                    if (string.IsNullOrEmpty(Request.Params["ddlFabricType" + i.ToString() + "_" + j.ToString()]))
                    {
                        j++;
                        total--;
                        continue;
                    }

                    if (Convert.ToInt32(Request.Params["ddlFabricType" + i.ToString() + "_" + j.ToString()]) == -1)
                        continue;

                    stylefab.FabricType = (FabricType)Convert.ToInt32(Request.Params["ddlFabricType" + i.ToString() + "_" + j.ToString()]);

                    if (!string.IsNullOrEmpty(Request.Params["txtIsDeleted" + i.ToString()]))
                    {
                        stylefab.IsDeleted = Convert.ToInt32(Request.Params["txtIsDeleted" + i.ToString()]);
                    }

                    if (Convert.ToInt32(Request.Params["ddlFabricType" + i.ToString() + "_" + j.ToString()]) == 1)
                    {

                        if (!string.IsNullOrEmpty(Request.Params["txtPrint" + i.ToString() + "_" + j.ToString()]))
                        {
                            stylefab.PrintNumber = (Request.Params["txtPrint" + i.ToString() + "_" + j.ToString()]).ToString();
                        }
                        else
                        {
                            stylefab.PrintNumber = string.Empty;
                        }

                        if (!string.IsNullOrEmpty(stylefab.PrintNumber))
                        {
                            //string printNew = stylefab.PrintNumber.Substring(8);
                            string PrintNo = string.Empty;
                            string[] printNumber = stylefab.PrintNumber.Split('-');
                            if (printNumber.Length > 1)
                            {
                                string[] printNew = printNumber[1].Split('(');


                                if (printNumber.Length > 0)
                                {
                                    PrintNo = printNew[0].Trim();
                                }
                            }
                            else { PrintNo = stylefab.PrintNumber; }
                            stylefab.PrintID = this.StyleControllerInstance.GetPrintIdByPrintNumber(PrintNo);
                        }
                        stylefab.SpecialFabricDetails = string.Empty;
                    }
                    else if (Convert.ToInt32(Request.Params["ddlFabricType" + i.ToString() + "_" + j.ToString()]) == 2)
                    {

                        if (!string.IsNullOrEmpty(Request.Params["txtDgtlPrint" + i.ToString() + "_" + j.ToString()]))
                        {
                            stylefab.PrintNumber = (Request.Params["txtDgtlPrint" + i.ToString() + "_" + j.ToString()]).ToString();
                        }
                        else
                        {
                            stylefab.PrintNumber = string.Empty;
                        }

                        if (!string.IsNullOrEmpty(stylefab.PrintNumber))
                        {
                            //string printNew = stylefab.PrintNumber.Substring(8);
                            string PrintNo = string.Empty;
                            string[] printNumber = stylefab.PrintNumber.Split('-');
                            if (printNumber.Length > 1)
                            {
                                string[] printNew = printNumber[1].Split('(');


                                if (printNumber.Length > 0)
                                {
                                    PrintNo = printNew[0].Trim();
                                }
                            }
                            else { PrintNo = stylefab.PrintNumber; }
                            stylefab.PrintID = this.StyleControllerInstance.GetPrintIdByPrintNumber(PrintNo);
                        }
                        stylefab.SpecialFabricDetails = string.Empty;
                    }
                    else
                    {
                        stylefab.SpecialFabricDetails = Request.Params["txtSpecialFabricDetails" + i.ToString() + "_" + j.ToString()];

                    }

                    //Add By Surendra2 on 10-09-2018.
                    if (!string.IsNullOrEmpty(Request.Params["hdnDyedRate" + i.ToString()]))
                    {
                        stylefab.DyedRate = Convert.ToDouble(Request.Params["hdnDyedRate" + i.ToString()]);
                    }
                    else
                    {
                        stylefab.DyedRate = 0;
                    }
                    stylefab.PrintRate = 0;
                    stylefab.DigitalPrintRate = 0;

                    //if (!string.IsNullOrEmpty(Request.Params["hdnPrintRate" + i.ToString()]))
                    //{
                    //    stylefab.PrintRate = Convert.ToDouble(Request.Params["hdnPrintRate" + i.ToString()]);
                    //}
                    //else
                    //{
                    //    stylefab.PrintRate = 0;
                    //}
                    //if (!string.IsNullOrEmpty(Request.Params["hdnDigitalPrintRate" + i.ToString()]))
                    //{
                    //    stylefab.DigitalPrintRate = Convert.ToDouble(Request.Params["hdnDigitalPrintRate" + i.ToString()]);
                    //}
                    //else
                    //{
                    //    stylefab.DigitalPrintRate = 0;
                    //}
                    if (!string.IsNullOrEmpty(Request.Params["hdnGSM" + i.ToString()]))
                    {
                        //stylefab.GSM =  (Request.Params["hdnGSM" + i.ToString()]).ToString().Replace(",","");
                        if ((Request.Params["hdnGSM" + i.ToString()]).ToString().Contains(','))
                        {
                            stylefab.GSM = (Request.Params["hdnGSM" + i.ToString()]).ToString().Split(',')[0];
                        }
                        else
                        {
                            stylefab.GSM = (Request.Params["hdnGSM" + i.ToString()]).ToString();
                        }
                    }
                    else
                    {
                        stylefab.GSM = "0";
                    }
                    if (!string.IsNullOrEmpty(Request.Params["hdnCC" + i.ToString()]))
                    {
                        stylefab.CountConstruct = (Request.Params["hdnCC" + i.ToString()]).ToString().Replace(",", "");
                    }
                    else
                    {
                        stylefab.CountConstruct = string.Empty;
                    }
                    if (!string.IsNullOrEmpty(Request.Params["hdnCostWidth" + i.ToString()]))
                    {
                        stylefab.CostWidth = Convert.ToDouble(Request.Params["hdnCostWidth" + i.ToString()]);
                    }
                    else
                    {
                        stylefab.CostWidth = 0;
                    }
                    if (!string.IsNullOrEmpty(Request.Params["hdnFabricQualityId" + i.ToString()]))
                    {
                        if (Request.Params["hdnFabricQualityId" + i.ToString()] != "undefined")
                        {
                            stylefab.FabricQualityId = Convert.ToInt32(Request.Params["hdnFabricQualityId" + i.ToString()]);
                        }
                        else
                        {
                            stylefab.FabricQualityId = 0;
                        }
                       
                    }
                    else
                    {
                        stylefab.FabricQualityId = 0;
                    }

                    if (stylefab.FabricQualityId == 0)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "$(function(){alert('Sorry You have not selected registered or unregistered fabric quality.');});", true);
                        return;
                    }


                    if (StyleID > 0 && !string.IsNullOrEmpty(Request.Params["txtStyleFabID" + i.ToString() + "_" + j.ToString()]))
                    {
                        stylefab.Id = Convert.ToInt32(Request.Params["txtStyleFabID" + i.ToString() + "_" + j.ToString()]);
                    }
                    else
                    {
                        stylefab.Id = -1;
                    }


                    if (j == 1)
                    {
                        style.Fabrics.Add(stylefab);
                    }

                    strFabric.Append("<styleNumber>" + style.StyleNumber + "</styleNumber><fabric>" + stylefab.FabricName + "</fabric>");
                    strFabric.Append("<ccgsm>" + stylefab.CCGSM + "</ccgsm><type>" + Convert.ToInt32(Request.Params["ddlFabricType" + i.ToString() + "_" + j.ToString()]) + "</type>");

                    if (!string.IsNullOrEmpty(stylefab.PrintNumber))
                    {
                        if (Convert.ToInt32(Request.Params["ddlFabricType" + i.ToString() + "_" + j.ToString()]) == 1)
                        {
                            strFabric.Append("<fabtype>Print</fabtype><des>" + stylefab.PrintNumber + "</des>");
                        }
                        if (Convert.ToInt32(Request.Params["ddlFabricType" + i.ToString() + "_" + j.ToString()]) == 2)
                        {
                            strFabric.Append("<fabtype>Digital Print</fabtype><des>" + stylefab.PrintNumber + "</des>");
                        }
                    }
                    else
                    {
                        strFabric.Append(" <fabtype>Dyed</fabtype><des>" + stylefab.SpecialFabricDetails + "</des>");
                    }
                    strFabric.Append("<rem>" + stylefab.Remarks + "</rem>");
                    if (stylefab.PrintID != null)
                        strFabric.Append("<printid>" + stylefab.PrintID + "</printid>");
                    else strFabric.Append("<printid>0</printid>");
                    j++;
                    total--;
                }
                //i++;

            }
            strFabric.Append("</table>");
            strFabric.Replace("&", "&amp;");

            style.ReferenceBlocks = new List<StyleReferenceBlock>();
            StyleReferenceBlock StyleRef1 = new StyleReferenceBlock();
            int HiddenId1 = Convert.ToInt32(HiddenRefId1.Value);

            if (HiddenId1 == -1 && RefUrl1.ImageUrl == string.Empty)
            {
                if (UploadRef1.HasFile)
                {
                    StyleRef1.ImagePath = FileHelper.SaveFile(UploadRef1.PostedFile.InputStream, UploadRef1.FileName, Constants.STYLE_FOLDER_PATH, true, style.StyleNumber.Trim() + "-REF1");
                    StyleRef1.StyleID = style.StyleID;
                    StyleRef1.Name = txtRefBlock1.Text;
                    StyleRef1.Type = Convert.ToInt32(ReferenceBlockType.Block);
                    style.ReferenceBlocks.Add(StyleRef1);
                    if (StyleID > -1)
                    {
                        this.StyleControllerInstance.CreateStyleRefBlock(StyleRef1);
                    }
                }
            }
            else if (HiddenId1 > -1 && RefUrl1.ImageUrl != string.Empty && chkRefBlock1.Checked == true)
            {
                StyleRef1.Id = Convert.ToInt32(HiddenRefId1.Value);
                StyleRef1.StyleID = style.StyleID;
                StyleRef1.Type = Convert.ToInt32(ReferenceBlockType.Block);
                this.StyleControllerInstance.DeleteStyleRefBlock(StyleRef1);
            }
            else if (HiddenId1 > -1 && RefUrl1.ImageUrl != string.Empty && chkRefBlock1.Checked == false)
            {
                if (UploadRef1.HasFile)
                {
                    StyleRef1.ImagePath = FileHelper.SaveFile(UploadRef1.PostedFile.InputStream, UploadRef1.FileName, Constants.STYLE_FOLDER_PATH, true, style.StyleNumber.Trim() + "-REF1");
                }
                else
                {
                    StyleRef1.ImagePath = RefUrl1.ImageUrl;
                }
                StyleRef1.Id = Convert.ToInt32(HiddenRefId1.Value);
                StyleRef1.StyleID = style.StyleID;
                StyleRef1.Name = txtRefBlock1.Text;
                StyleRef1.Type = Convert.ToInt32(ReferenceBlockType.Block);
                this.StyleControllerInstance.UpdateStyleRefBlock(StyleRef1);
            }


            StyleReferenceBlock StyleRef2 = new StyleReferenceBlock();
            int HiddenId2 = Convert.ToInt32(HiddenRefId2.Value);
            if (HiddenId2 == -1 && RefUrl1.ImageUrl == string.Empty)
            {
                if (UploadRef2.HasFile)
                {
                    StyleRef2.ImagePath = FileHelper.SaveFile(UploadRef2.PostedFile.InputStream, UploadRef2.FileName, Constants.STYLE_FOLDER_PATH, true, style.StyleNumber.Trim() + "-REF2");
                    StyleRef2.StyleID = style.StyleID;
                    StyleRef2.Name = txtRefBlock2.Text;
                    StyleRef2.Type = Convert.ToInt32(ReferenceBlockType.Block);
                    style.ReferenceBlocks.Add(StyleRef2);
                    if (StyleID > -1)
                    {
                        this.StyleControllerInstance.CreateStyleRefBlock(StyleRef2);
                    }
                }
            }
            else if (HiddenId2 > -1 && RefUrl1.ImageUrl != string.Empty && chkRefBlock2.Checked == true)
            {
                StyleRef2.Id = Convert.ToInt32(HiddenRefId2.Value);
                StyleRef2.StyleID = style.StyleID;
                StyleRef2.Type = Convert.ToInt32(ReferenceBlockType.Block);
                this.StyleControllerInstance.DeleteStyleRefBlock(StyleRef2);
            }
            else if (HiddenId2 > -1 && RefUrl2.ImageUrl != string.Empty && chkRefBlock2.Checked == false)
            {
                if (UploadRef2.HasFile)
                {
                    StyleRef2.ImagePath = FileHelper.SaveFile(UploadRef2.PostedFile.InputStream, UploadRef2.FileName, Constants.STYLE_FOLDER_PATH, true, style.StyleNumber.Trim() + "-REF2");
                }
                else
                {
                    StyleRef2.ImagePath = RefUrl2.ImageUrl;
                }
                StyleRef2.Id = Convert.ToInt32(HiddenRefId2.Value);
                StyleRef2.StyleID = style.StyleID;
                StyleRef2.Name = txtRefBlock2.Text;
                StyleRef2.Type = Convert.ToInt32(ReferenceBlockType.Block);
                this.StyleControllerInstance.UpdateStyleRefBlock(StyleRef2);
            }

            StyleReferenceBlock StyleRef3 = new StyleReferenceBlock();
            int HiddenId3 = Convert.ToInt32(HiddenRefId3.Value);
            if (HiddenId3 == -1 && RefUrl3.ImageUrl == string.Empty)
            {
                if (UploadRef3.HasFile)
                {
                    StyleRef3.ImagePath = FileHelper.SaveFile(UploadRef3.PostedFile.InputStream, UploadRef3.FileName, Constants.STYLE_FOLDER_PATH, true, style.StyleNumber.Trim() + "-REF3");
                    StyleRef3.StyleID = style.StyleID;
                    StyleRef3.Name = txtRefBlock3.Text;
                    StyleRef3.Type = Convert.ToInt32(ReferenceBlockType.Block);
                    style.ReferenceBlocks.Add(StyleRef3);
                    if (StyleID > -1)
                    {
                        this.StyleControllerInstance.CreateStyleRefBlock(StyleRef3);
                    }
                }
            }
            else if (HiddenId3 > -1 && RefUrl3.ImageUrl != string.Empty && chkRefBlock3.Checked == true)
            {
                StyleRef3.Id = Convert.ToInt32(HiddenRefId3.Value);
                StyleRef3.StyleID = style.StyleID;
                StyleRef3.Type = Convert.ToInt32(ReferenceBlockType.Block);
                this.StyleControllerInstance.DeleteStyleRefBlock(StyleRef3);
            }
            else if (HiddenId3 > -1 && RefUrl3.ImageUrl != string.Empty && chkRefBlock3.Checked == false)
            {
                if (UploadRef3.HasFile)
                {
                    StyleRef3.ImagePath = FileHelper.SaveFile(UploadRef3.PostedFile.InputStream, UploadRef3.FileName, Constants.STYLE_FOLDER_PATH, true, style.StyleNumber.Trim() + "-REF3");
                }
                else
                {
                    StyleRef3.ImagePath = RefUrl3.ImageUrl;
                }
                StyleRef3.Id = Convert.ToInt32(HiddenRefId3.Value);
                StyleRef3.StyleID = style.StyleID;
                StyleRef3.Name = txtRefBlock3.Text;
                StyleRef3.Type = Convert.ToInt32(ReferenceBlockType.Block);
                this.StyleControllerInstance.UpdateStyleRefBlock(StyleRef3);
            }

            // Ind Blocks
            StyleReferenceBlock StyleRefInd1 = new StyleReferenceBlock();
            int HiddenIndId1 = Convert.ToInt32(hiddenInd1Id.Value);

            StyleRefInd1.Id = HiddenIndId1;
            StyleRefInd1.StyleID = style.StyleID;
            StyleRefInd1.Type = Convert.ToInt32(ReferenceBlockType.INDBlock);
            StyleRefInd1.Name = txtIndBlock1.Text;


            if (HiddenIndId1 == -1 && !string.IsNullOrEmpty(txtIndBlock1.Text.Trim()) && StyleID > -1)
            {
                this.StyleControllerInstance.CreateStyleRefBlock(StyleRefInd1);
            }
            else if (HiddenIndId1 == -1 && !string.IsNullOrEmpty(txtIndBlock1.Text.Trim()) && StyleID == -1)
            {
                style.ReferenceBlocks.Add(StyleRefInd1);
            }
            else if (HiddenIndId1 > -1 && string.IsNullOrEmpty(txtIndBlock1.Text))
            {
                this.StyleControllerInstance.DeleteStyleRefBlock(StyleRefInd1);
            }
            else
            {
                this.StyleControllerInstance.UpdateStyleRefBlock(StyleRefInd1);
            }

            StyleReferenceBlock StyleRefInd2 = new StyleReferenceBlock();
            int HiddenIndId2 = Convert.ToInt32(hiddenInd2Id.Value);
            StyleRefInd2.Id = HiddenIndId2;
            StyleRefInd2.StyleID = style.StyleID;
            StyleRefInd2.Type = Convert.ToInt32(ReferenceBlockType.INDBlock);
            StyleRefInd2.Name = txtIndBlock2.Text;

            if (HiddenIndId2 == -1 && !string.IsNullOrEmpty(txtIndBlock2.Text.Trim()) && StyleID > -1)
            {
                this.StyleControllerInstance.CreateStyleRefBlock(StyleRefInd2);
            }
            else if (HiddenIndId2 == -1 && !string.IsNullOrEmpty(txtIndBlock2.Text.Trim()) && StyleID == -1)
            {
                style.ReferenceBlocks.Add(StyleRefInd2);
            }
            else if (HiddenIndId2 > -1 && string.IsNullOrEmpty(txtIndBlock2.Text))
            {
                this.StyleControllerInstance.DeleteStyleRefBlock(StyleRefInd2);
            }
            else
            {
                this.StyleControllerInstance.UpdateStyleRefBlock(StyleRefInd2);
            }

            StyleReferenceBlock StyleRefInd3 = new StyleReferenceBlock();
            int HiddenIndId3 = Convert.ToInt32(hiddenInd3Id.Value);
            StyleRefInd3.Id = HiddenIndId3;
            StyleRefInd3.StyleID = style.StyleID;
            StyleRefInd3.Type = Convert.ToInt32(ReferenceBlockType.INDBlock);
            StyleRefInd3.Name = txtIndBlock3.Text;

            if (HiddenIndId3 == -1 && !string.IsNullOrEmpty(txtIndBlock3.Text.Trim()) && StyleID > -1)
            {
                this.StyleControllerInstance.CreateStyleRefBlock(StyleRefInd3);
            }
            else if (HiddenIndId3 == -1 && !string.IsNullOrEmpty(txtIndBlock3.Text.Trim()) && StyleID == -1)
            {
                style.ReferenceBlocks.Add(StyleRefInd3);
            }
            else if (HiddenIndId3 > -1 && string.IsNullOrEmpty(txtIndBlock3.Text))
            {
                this.StyleControllerInstance.DeleteStyleRefBlock(StyleRefInd3);
            }
            else
            {
                this.StyleControllerInstance.UpdateStyleRefBlock(StyleRefInd3);

            }


            //  style.SeasonID = Convert.ToInt32(Request.Params[ddlSeason.UniqueID]);

            style.SeasonName = Convert.ToString(Request.Params["hdnSeasonName"]).Trim();

            style.CourierSentOn = DateHelper.ParseDate("").Value;
            if (style.StyleID == -1)
            {
                int isCheckRepeatStylecode = this.ClientControllerInstance.checkStylecode(style.StyleNumberDesc);
                if (isCheckRepeatStylecode == 1)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "$(function(){alert('Sorry You Can Not Create a Duplicate Style No.');});", true);
                    return;
                }
            }

            string DesignerCode = ApplicationHelper.LoggedInUser.UserData.DesignerCode.ToString();
            // Added by Yadvendra on 06/01/2020
            int bit = this.StyleControllerInstance.SaveStyleNew(style, DesignerCode, SaveStyleNew, ParentStyleid, CbVisibleInMarketing.Checked == true ? true : false);


            if (strFabric.ToString() != "</table>")
            {
                this.StyleControllerInstance.InsertFabricPrints(strFabric.ToString());
            }

            int results = 0;
            if (bit != 0)
            {
                this.pnlForm.Visible = false;
                this.pnlMessage.Visible = true;
                styleid_New = StyleID > 0 ? StyleID : bit;
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "alert('A style with same style number is already there!!!');", true);
            }

            int IsDeletedOld = this.StyleControllerInstance.DeleteAddACCDetails(styleid_New, "", "", 0, "", 0, "DELETE");


            string Remarks = string.Empty;
            string ACCName = string.Empty;
            string FlagIsDelete = "INSERT";

            foreach (GridViewRow row in grdAccsessory.Rows)
            {
                TextBox txtAccname = (TextBox)row.FindControl("txtAccname");
                TextBox txtRemarks = (TextBox)row.FindControl("txtRemarks");

                HiddenField hdnAutoincretment = (HiddenField)row.FindControl("hdnAutoincretment");
                HiddenField hdnAccQualityId = (HiddenField)row.FindControl("hdnAccQualityId");
                HiddenField hdnSize = (HiddenField)row.FindControl("hdnSize");
                HiddenField hdnRate = (HiddenField)row.FindControl("hdnRate");
                if (string.IsNullOrEmpty(hdnAccQualityId.Value))
                    hdnAccQualityId.Value = "0";
                if (string.IsNullOrEmpty(hdnSize.Value))
                    hdnSize.Value = "0";
                if (string.IsNullOrEmpty(hdnRate.Value))
                    hdnRate.Value = "0";
                ACCName = txtAccname.Text.Trim();
                Remarks = txtRemarks.Text.Trim();
                if (ACCName != "")
                {
                    results = this.StyleControllerInstance.DeleteAddACCDetails(styleid_New, ACCName, Remarks, Convert.ToInt32(hdnAccQualityId.Value), hdnSize.Value.ToString().Trim(), Convert.ToDouble(hdnRate.Value), FlagIsDelete);
                }
            }
            var footerRow = grdAccsessory.FooterRow;
            if (footerRow != null)
            {
                TextBox txtfoterAccname = (TextBox)footerRow.FindControl("txtfoterAccname");
                HiddenField hdnAutoincretmentfoter = (HiddenField)footerRow.FindControl("hdnAutoincretmentfoter");
                HiddenField hdnFooterAccQualityId = (HiddenField)footerRow.FindControl("hdnFooterAccQualityId");
                HiddenField hdnFooterSize = (HiddenField)footerRow.FindControl("hdnFooterSize");
                HiddenField hdnFooterRate = (HiddenField)footerRow.FindControl("hdnFooterRate");

                TextBox txtfoterRemarks = (TextBox)footerRow.FindControl("txtfoterRemarks");
                if (string.IsNullOrEmpty(hdnFooterAccQualityId.Value))
                    hdnFooterAccQualityId.Value = "0";

                if (string.IsNullOrEmpty(hdnFooterSize.Value))
                  hdnFooterSize.Value = "0";
                if(string.IsNullOrEmpty(hdnFooterRate.Value))
                    hdnFooterRate.Value="0";
                string Acc = txtfoterAccname.Text.Trim();
                string Acc_Remarks = txtfoterRemarks.Text.Trim();
                if (Acc != "")
                {
                    results = this.StyleControllerInstance.DeleteAddACCDetails(styleid_New, Acc, Acc_Remarks, Convert.ToInt32(hdnFooterAccQualityId.Value), hdnFooterSize.Value.ToString().Trim(), Convert.ToDouble(hdnFooterRate.Value), "Acc_Footer");
                }


            }
            //if (results > 0)
            //{
            //    ShowAlert("Record updated successfully");
            //    ViewState["datatable"] = null;
            //    BindControls();
            //}
        }

        //protected void btnPrint_Click(object sender, EventArgs e)
        //{
        //    ////System.Diagnostics.Debugger.Break();

        //    Dictionary<string, object> properties = new Dictionary<string, object>();
        //    properties.Add("StyleID", this.StyleID);

        //    string html = PageHelper.GetControlPrintableHtml("~/UserControls/Forms/DesignerForm.ascx", properties);

        //    Session["PRINT_HTML"] = html;
        //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('" + ResolveUrl("~/internal/Print.aspx") + "','PrintMe','height=300px,width=300px,scrollbars=1');</script>");

        //}

        private void PopulateDesignerCode(string DesignerCode)
        {
            if (DesignerCode.IndexOf(",") > -1)
            {
                string[] codes = DesignerCode.Split(new char[] { ',' });

                ddlDesignerCode.Items.Clear();

                foreach (string code in codes)
                {
                    ListItem item = new ListItem(code, code);
                    ddlDesignerCode.Items.Add(item);
                }

                txtDesignerCode.Visible = false;
                ddlDesignerCode.Visible = true;
            }
            else
            {
                //Edit by surendra on 10 jan 2013
                //if (ApplicationHelper.LoggedInUser.UserData.UserID == 417)
                //{

                //    txtDesignerCode.Text ="102";
                //    txtDesignerCode.ReadOnly = true;

                //}
                //else if (ApplicationHelper.LoggedInUser.UserData.UserID == 420)
                //{

                //    txtDesignerCode.Text = "103";
                //    txtDesignerCode.ReadOnly = true;

                //}
                //else
                //{
                txtDesignerCode.Text = DesignerCode;
                //}
                //end

                txtDesignerCode.Visible = true;
                ddlDesignerCode.Visible = false;
            }
        }

        private void SetDesignerCode(string DesignerCode)
        {
            if (txtDesignerCode.Visible == true)
                txtDesignerCode.Text = DesignerCode;
            else
            {

                if (ddlDesignerCode.Items.FindByValue(DesignerCode) != null)
                    ddlDesignerCode.SelectedValue = DesignerCode;
            }
        }

        private string GetDesignerCode()
        {
            if (txtDesignerCode.Visible == true)
                return txtDesignerCode.Text;
            else
            {
                return ddlDesignerCode.SelectedValue;
            }
        }

        private void bindDivisionName()
        {
            string designationID = ApplicationHelper.LoggedInUser.UserData.DesignationID.ToString();
            DataTable dt = this.PrintControllerInstance.GetDivisionBy_Designation(designationID);
            ddlDivisionName.DataSource = dt;
            ddlDivisionName.DataTextField = "DivisionName";
            ddlDivisionName.DataValueField = "ManageDivisionID";
            ddlDivisionName.DataBind();
            ddlDivisionName.Items.RemoveAt(0);
            ListItem li = new ListItem();
            li.Text = "Select";
            li.Value = "0";
            ddlDivisionName.Items.Insert(0, li);
        }

        protected void ddlBuyingHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlBuyer.Items.Clear();
            //ListItem li = new ListItem();
            //li.Text = "Select";
            //li.Value = "-1";
            DropdownHelper.BindClientsDesign(ddlBuyer as ListControl, Convert.ToInt32(ddlBuyingHouse.SelectedValue));
            // ddlBuyer.Items.Insert(0, li);
            // ddlBuyer.SelectedValue = hdnBuyer.Value;
            //Request.QueryString["PageIndex"].Remove(0);
        }

        //protected void ddlBuyer_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindDDLSeason(Convert.ToInt32(ddlBuyer.SelectedValue));
        //}

        public void BindDDLSeason(int ClientID)
        {
            DataTable dt = this.ClientControllerInstance.GetSeasonByClient(ClientID, "0");
            ddlSeason.DataSource = dt;
            ddlSeason.DataTextField = "SeasonName";
            ddlSeason.DataValueField = "ID";
            ListItem li = new ListItem();
            li.Text = "Select";
            li.Value = "-1";
            ddlSeason.Items.Insert(0, li);
            ddlSeason.DataBind();
        }

        protected void grdAccsessory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdAccsessory.Rows[e.RowIndex];

            HiddenField hdnAutoincretment = (HiddenField)row.FindControl("hdnAutoincretment");

            HiddenField hdnAccessoryid = (HiddenField)row.FindControl("hdnAccessoryid");
            DataTable dtnew = new DataTable();
            int rowIdnex = e.RowIndex;
            if (ViewState["datatable"] != null)
            {
                dtnew = (DataTable)(ViewState["datatable"]);
                if (hdnAutoincretment.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("ID=" + hdnAccessoryid.Value)[0]);
                    //int IsDelete = obj_ProcessController.DeleteHoppmRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdnAccessoryid.Value)[0]);
                }
                ViewState["datatable"] = dtnew;
            }


            grdAccsessory.EditIndex = -1;
            BindControls();

        }

        protected void grdAccsessory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            ////string[] name = Username.Split('@');
            //string date = DateTime.Now.ToString("dd MMM yyyy");

            //added by raghvinder on 14-10-2020 start
            if (grdAccsessory.Rows.Count == 24)
            {
                ShowAlert("Can not add more than 20 Accessory!");                
                return;
            }
            //added by raghvinder on 14-10-2020 end

            DataTable dtnewvalidate = new DataTable();
            dtnewvalidate = (DataTable)(ViewState["Accsessoryname"]);
            string Result = string.Empty;
            if (e.CommandName == "Insert")
            {
                TextBox txtfoterAccname = grdAccsessory.FooterRow.FindControl("txtfoterAccname") as TextBox;
                TextBox txtfoterRemarks = grdAccsessory.FooterRow.FindControl("txtfoterRemarks") as TextBox;




                HiddenField hdnIDfoter = grdAccsessory.FooterRow.FindControl("hdnAutoincretmentfoter") as HiddenField;
                HiddenField hdnFooterSize = grdAccsessory.FooterRow.FindControl("hdnFooterSize") as HiddenField;
                HiddenField hdnFooterAccQualityId = grdAccsessory.FooterRow.FindControl("hdnFooterAccQualityId") as HiddenField;
                HiddenField hdnFooterRate = grdAccsessory.FooterRow.FindControl("hdnFooterRate") as HiddenField;

                LinkButton abtnAdd = grdAccsessory.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();
                
                string AccsessoryName = string.Empty;
                string AccsessryRemarks = string.Empty;

                if (txtfoterAccname != null && txtfoterAccname.Text == string.Empty)
                {
                    ShowAlert("Enter Accessory name");
                    txtfoterAccname.Focus();
                    return;
                }
                else
                {
                    AccsessoryName = txtfoterAccname.Text;
                }
                string[] result = AccsessoryName.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                var AccsName = result[0].Trim();


                AccsessryRemarks = txtfoterRemarks.Text;
                if (AccsName == "TBD")
                {
                    if (AccsessryRemarks == "")
                    {
                        ShowAlert("Accessory TBD  Remark Mandatory");
                        return;
                    }
                }

                if (ViewState["datatable"] != null)
                {
                    dtnew = (DataTable)(ViewState["datatable"]);
                    int i = 0;
                    for (; i < grdAccsessory.Rows.Count; i++)
                    {

                        if (((TextBox)grdAccsessory.Rows[i].FindControl("txtAccname")).Text.Trim() == string.Empty)
                        {
                            ShowAlert("Enter Accessory name");
                            ((TextBox)grdAccsessory.Rows[i].FindControl("txtAccname")).Focus();
                            return;
                        }
                        if (AccsName != "TBD")
                        {

                            if (((TextBox)grdAccsessory.Rows[i].FindControl("txtAccname")).Text.Trim() == txtfoterAccname.Text.Trim())
                            {
                                ShowAlert("Entered accsessory name already in list.!");
                                ((TextBox)grdAccsessory.Rows[i].FindControl("txtAccname")).Focus();
                                return;

                            }
                        }

                        dtnew.Rows[i]["StyleID"] = StyleID;
                        dtnew.Rows[i]["AccesoriesName"] = ((TextBox)grdAccsessory.Rows[i].FindControl("txtAccname")).Text;
                        dtnew.Rows[i]["Remarks"] = ((TextBox)grdAccsessory.Rows[i].FindControl("txtRemarks")).Text;

                        dtnew.Rows[i]["Id"] = i + 1;

                        dtnew.Rows[i]["AccesoriesQualityID"] = ((HiddenField)grdAccsessory.Rows[i].FindControl("hdnAccQualityId")).Value == "" ? 0 : Convert.ToInt32(((HiddenField)grdAccsessory.Rows[i].FindControl("hdnAccQualityId")).Value);
                        dtnew.Rows[i]["SIZE"] = ((HiddenField)grdAccsessory.Rows[i].FindControl("hdnSize")).Value;
                        dtnew.Rows[i]["Rate"] = ((HiddenField)grdAccsessory.Rows[i].FindControl("hdnRate")).Value == "" ? 0 : Convert.ToDouble(((HiddenField)grdAccsessory.Rows[i].FindControl("hdnRate")).Value);




                        //foreach (DataRow dr in dtnewvalidate.Rows)
                        //{
                        //    if (dr["TextFields"].ToString() == ((TextBox)grdAccsessory.Rows[i].FindControl("txtFaultname")).Text)
                        //    {
                        //        Flag = "HAS";
                        //    }
                        //}
                        //if (Flag == "HAS")
                        //{
                        //    dtnew.Rows[i]["fault"] = ((TextBox)grdAccsessory.Rows[i].FindControl("txtFaultname")).Text;
                        //}
                        //else
                        //{
                        //    //((TextBox)grdAccsessory.Rows[i].FindControl("txtQnty")).Text = "";
                        //    //((TextBox)grdAccsessory.Rows[i].FindControl("txtFaultname")).Text="";
                        //    ShowAlert("You can select either fault or unaccounted only" + " (" + ((TextBox)grdAccsessory.Rows[i].FindControl("txtFaultname")).Text + ") " + "not a valid");
                        //    return;
                        //}
                        //Flag = "";




                    }

                    DataRow row = dtnew.NewRow();
                    row["StyleID"] = StyleID;
                    row["AccesoriesName"] = txtfoterAccname.Text.Trim();
                    row["Remarks"] = txtfoterRemarks.Text.Trim();
                    row["Id"] = i + 1;
                    row["AccesoriesQualityID"] = hdnFooterAccQualityId.Value == "" ? 0 : Convert.ToInt32(hdnFooterAccQualityId.Value);
                    row["SIZE"] = hdnFooterSize.Value;
                    row["Rate"] = hdnFooterRate.Value == "" ? 0 : Convert.ToDouble(hdnFooterRate.Value);






                    //foreach (DataRow dr in dtnewvalidate.Rows)
                    //{
                    //    if (dr["TextFields"].ToString() == txtfoterfaultname.Text)
                    //    {
                    //        Flag = "HAS";
                    //    }
                    //}
                    //if (Flag == "HAS")
                    //{
                    //    row["fault"] = txtfoterfaultname.Text;
                    //}
                    //else
                    //{
                    //    txtfoterfaultname.Text = "";
                    //    txtfoterqnty.Text = "";
                    //    ShowAlert("You can select either fault or unaccounted only" + " (" + txtfoterfaultname.Text + ") " + "not a valid");
                    //    return;
                    //}
                    //Flag = "";

                    dtnew.Rows.Add(row);

                    dtnew.AcceptChanges();



                    ViewState["datatable"] = dtnew;

                }

                //ViewState["ShipedValue"] = txtStitchQty.Text.Trim();
                //ViewState["ShipedDate"] = txtISShippedDate.Text.Trim();

                BindControls();





            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdAccsessory.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];

                TextBox txtfoterAccname = grdAccsessory.FooterRow.FindControl("txtfoterAccname") as TextBox;
                TextBox txtfoterRemarks = grdAccsessory.FooterRow.FindControl("txtfoterRemarks") as TextBox;
                HiddenField hdnIDfoter = grdAccsessory.FooterRow.FindControl("hdnAutoincretmentfoter") as HiddenField;
                HiddenField hdnFooterSize = grdAccsessory.FooterRow.FindControl("hdnFooterSize") as HiddenField;
                HiddenField hdnFooterAccQualityId = grdAccsessory.FooterRow.FindControl("hdnFooterAccQualityId") as HiddenField;
                HiddenField hdnFooterRate = grdAccsessory.FooterRow.FindControl("hdnFooterRate") as HiddenField;
                //TextBox txtemptyAccname = (TextBox)rows.FindControl("txtemptyAccname");
                //TextBox txtemptyRemarks = (TextBox)rows.FindControl("txtemptyRemarks");

                //HiddenField hdnIDfoter = grdAccsessory.FooterRow.FindControl("hdnAutoincretmentfoter") as HiddenField;




                DataTable dtnew = new DataTable();

                string accname = string.Empty;
                string accremarks = string.Empty;


                if (txtfoterAccname != null && txtfoterAccname.Text == string.Empty)
                {
                    ShowAlert("Enter Accessory name");
                    return;
                }
                else
                {
                    accname = txtfoterAccname.Text;
                }
                string[] result = accname.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                var AccsName = result[0].Trim();
                if (AccsName == "TBD")
                {
                    if (Convert.ToString(txtfoterRemarks.Text) == "")
                    {
                        ShowAlert("Accessory TBD Remark Mandatory");
                        return;
                    }
                }

                if (ViewState["datatable"] != null)
                {
                    dtnew = (DataTable)(ViewState["datatable"]);



                    DataRow row = dtnew.NewRow();
                    row["StyleID"] = StyleID;
                    row["AccesoriesName"] = txtfoterAccname.Text;
                    row["Remarks"] = txtfoterRemarks.Text;
                    row["Id"] = 0;
                    row["AccesoriesQualityID"] = hdnFooterAccQualityId.Value == "" ? 0 : Convert.ToInt32(hdnFooterAccQualityId.Value);
                    row["SIZE"] = hdnFooterSize.Value;
                    row["Rate"] = hdnFooterRate.Value == "" ? 0 : Convert.ToDouble(hdnFooterRate.Value);

                    dtnew.Rows.Remove(dtnew.Rows[0]);
                    dtnew.Rows.Add(row);
                    dtnew.AcceptChanges();

                    ViewState["datatable"] = dtnew;
                }



                BindControls();
            }
        }

        protected void grdAccsessory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
            //    ltIndex.Text = ((grdHoppmFabricRemark.PageIndex * grdHoppmFabricRemark.PageSize) + e.Row.RowIndex + 1).ToString();
            //}
            //bool EnableHOPPM = grdHoppmFabricRemark.Enabled;
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
            //    //ltIndex.Text = ((grdHoppmFabricRemark.PageIndex * grdHoppmFabricRemark.PageSize) + e.Row.RowIndex + 1).ToString();
            //    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");


            //    if (!EnableHOPPM)
            //    {
            //        lnkDelete.Visible = false;
            //    }



            //    TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
            //    NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
            //    if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
            //    {
            //        if (NewRefrence == 1)
            //        {
            //            txtRemarkEdit.Enabled = true;
            //            lnkDelete.Visible = true;
            //            lnkDelete.Attributes.Add("style", "display:block;");
            //        }
            //        else
            //        {
            //            txtRemarkEdit.Enabled = false;
            //            lnkDelete.Visible = false;
            //            lnkDelete.Attributes.Add("style", "display:none;");
            //        }
            //    }

            //}
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
            //    if (!EnableHOPPM)
            //    {
            //        abtnAdd.Visible = false;
            //    }
            //    NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
            //    TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");
            //    if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
            //    {
            //        if (NewRefrence == 1)
            //        {
            //            txtRemarkFooter.Enabled = true;
            //            abtnAdd.Visible = true;
            //        }
            //        else
            //        {
            //            txtRemarkFooter.Enabled = false;
            //            abtnAdd.Visible = false;
            //        }

            //    }
            //}
            //if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            //{
            //    LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
            //    if (!EnableHOPPM)
            //    {
            //        addbutton.Visible = false;
            //    }
            //}
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        protected void txtIndBlock1_TextChanged(object sender, EventArgs e)
        {
            List<StyleReferenceBlock> refBlocks = this.StyleControllerInstance.GetStyleReferenceByINDnumber(0, txtIndBlock1.Text.Trim());
            if (refBlocks.Count > 0)
            {
                HiddenRefId1.Value = refBlocks[0].Id.ToString();

                txtRefBlock1.Text = refBlocks[0].Name;

                if (!string.IsNullOrEmpty(refBlocks[0].ImagePath))
                {
                    RefUrl1.Visible = false;
                    chkRefBlock1.Visible = true;
                    RefUrl1.ImageUrl = refBlocks[0].ImagePath;
                    ImgRef1.Visible = true;
                    hyp1.NavigateUrl = ResolveUrl("~/Uploads/Style/" + RefUrl1.ImageUrl);

                }
            }
            else
            {
                HiddenRefId1.Value = "";

                txtRefBlock1.Text = "";
                txtIndBlock3.Text = "";

                RefUrl1.Visible = false;
                chkRefBlock1.Visible = false;
                RefUrl1.ImageUrl = "";
                ImgRef1.Visible = false;
                hyp1.NavigateUrl = "";

            }

        }
        protected void txtIndBlock2_TextChanged(object sender, EventArgs e)
        {
            List<StyleReferenceBlock> refBlocks = this.StyleControllerInstance.GetStyleReferenceByINDnumber(0, txtIndBlock2.Text.Trim());
            if (refBlocks.Count > 0)
            {
                HiddenRefId2.Value = refBlocks[0].Id.ToString();

                txtRefBlock2.Text = refBlocks[0].Name;

                if (!string.IsNullOrEmpty(refBlocks[0].ImagePath))
                {
                    RefUrl2.Visible = false;
                    chkRefBlock2.Visible = true;
                    RefUrl2.ImageUrl = refBlocks[0].ImagePath;
                    ImgRef2.Visible = true;
                    hyp2.NavigateUrl = ResolveUrl("~/Uploads/Style/" + RefUrl1.ImageUrl);
                }
            }
            else
            {
                HiddenRefId2.Value = "";

                txtRefBlock2.Text = "";
                txtIndBlock2.Text = "";

                RefUrl2.Visible = false;
                chkRefBlock2.Visible = false;
                RefUrl2.ImageUrl = "";
                ImgRef2.Visible = false;
                hyp2.NavigateUrl = "";

            }

        }
        protected void txtIndBlock3_TextChanged(object sender, EventArgs e)
        {
            List<StyleReferenceBlock> refBlocks = this.StyleControllerInstance.GetStyleReferenceByINDnumber(0, txtIndBlock3.Text.Trim());
            if (refBlocks.Count > 0)
            {
                HiddenRefId3.Value = refBlocks[0].Id.ToString();

                txtRefBlock3.Text = refBlocks[0].Name;

                if (!string.IsNullOrEmpty(refBlocks[0].ImagePath))
                {
                    RefUrl3.Visible = false;
                    chkRefBlock3.Visible = true;
                    RefUrl3.ImageUrl = refBlocks[0].ImagePath;
                    ImgRef3.Visible = true;
                    hyp3.NavigateUrl = ResolveUrl("~/Uploads/Style/" + RefUrl1.ImageUrl);
                }
            }
            else
            {
                HiddenRefId3.Value = "";

                txtRefBlock3.Text = "";


                RefUrl3.Visible = false;
                chkRefBlock3.Visible = false;
                RefUrl3.ImageUrl = "";
                ImgRef3.Visible = false;
                hyp3.NavigateUrl = "";
                txtIndBlock3.Text = "";

            }

        }


        public void CustomValidator_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (txtDesignerCode.Text + txtStyle1.Text == "" || (txtDesignerCode.Text + txtStyle1.Text).ToString().Length < 5)
            {
                CustomValidator1.ErrorMessage = "Min 5 characters are required !!";
                args.IsValid = false;

            }
        }



    }


}