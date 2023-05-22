using System;
using System.Collections;
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
using iKandi.Common;
using System.Collections.Generic;
using iKandi.Web.Components;
using System.IO;

namespace iKandi.Web.UserControls.Forms
{
    public partial class QCForm : BaseUserControl
    {

        #region Properties
        public string QualityControlID { get; set; }
        public string InspectionID { get; set; }
        public int OrderDetailID
        {
            get
            {
                if (null != Request.QueryString["orderDetailID"])
                {
                    int orderDetailID;

                    if (int.TryParse(Request.QueryString["orderDetailID"].ToString(), out orderDetailID))
                        return orderDetailID;
                }

                return -1;
            }
        }

        //public int StyleID
        //{
        //    get;
        //    set;
        //}

        //public string stylenumber
        //{
        //    get;
        //    set;
        //}
        //public string FitsStyle
        //{
        //    get;
        //    set;
        //}
        //public int ClientID
        //{
        //    get;
        //    set;
        //}
        //public int DeptId
        //{
        //    get;
        //    set;
        //}
        //public string showHOPPMFORM
        //{
        //    get;
        //    set;
        //}
        #endregion

        #region Fields

        public Int32 EmptyCell = 0;
        public Int32 EmptyCell2 = 0;
        public Int32 EmptyCell3 = 0;
     
        iKandi.Common.QualityControl qualityControl;
        private int catgoryIndex = 0;
        private int catgoryID = 0;
        List<QualityFaultsSubCategory> SubCategoryList = new List<QualityFaultsSubCategory>();
        private int catgoryIndex2 = 0;
        private int catgoryID2 = 0;
        List<QualityFaultsSubCategory> SubCategoryList2 = new List<QualityFaultsSubCategory>();
        List<User> users2;
        //List<User> users3;
        //List<User> users4;


        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            GEtQueryString();
            if (!IsPostBack)
            {
                BindControls();
            }
            HtmlButton btn = (HtmlButton)this.FindControl("btn");
            btn.Attributes.Add("onclick", "ShowFitsPopup(" + Convert.ToString(Request.QueryString["orderDetailID"]) + ")");
        }

        public void GEtQueryString()
        {
            if (null != Request.QueryString["styleid"])
            {
                hdnStyleId.Value = Request.QueryString["styleid"].ToString();
            }
            if (null != Request.QueryString["stylenumber"])
            {
                hdnstylenumber.Value = Request.QueryString["stylenumber"].ToString();
            }
            if (null != Request.QueryString["ClientID"])
            {
                hdnClientID.Value = Request.QueryString["ClientID"].ToString();
            }
            if (null != Request.QueryString["DeptId"])
            {
                hdnDeptId.Value = Request.QueryString["DeptId"].ToString();
            }
            if (null != Request.QueryString["showHOPPMFORM"])
            {
                hdnshowHOPPM.Value = Request.QueryString["showHOPPMFORM"].ToString() == "Yes" ? "ShowHOPPMForm" : "0";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            SaveQuality();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            PopulateQualityData();
        }

        protected void repeaterSizesItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                EmptyCell = EmptyCell + 1;

            if (e.Item.ItemType == ListItemType.Footer)
            {
                for (int i = 0; i < 10 - EmptyCell; i++)
                {
                    ((Label)e.Item.FindControl("lblEmptyCell")).Text = ((Label)e.Item.FindControl("lblEmptyCell")).Text + "<td></td>";
                }
            }
        }

        protected void repeaterQtyItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                EmptyCell2 = EmptyCell2 + 1;
            }
            if (e.Item.ItemType == ListItemType.Footer)
            {
                for (int i = 0; i < 10 - EmptyCell2; i++)
                {
                    ((Label)e.Item.FindControl("lblEmptyCell")).Text = ((Label)e.Item.FindControl("lblEmptyCell")).Text + "<td></td>";
                }
            }
        }

        protected void repeaterQtyCheckedItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //QuantityCheckedPerSize = 0;// qualityControl.OrderDetail.OrderSizes[e.Item.ItemIndex].Quantity * Convert.ToInt32((txtActualSamplesChecked.Text == String.Empty) ? "0" : txtActualSamplesChecked.Text) / Convert.ToInt32(lblTotalQty.Text);
                //((Label)e.Item.FindControl("lblQtyChecked")).Text = QuantityCheckedPerSize.ToString();
                EmptyCell3 = EmptyCell3 + 1;
            }
            if (e.Item.ItemType == ListItemType.Footer)
            {
                for (int i = 0; i < 10 - EmptyCell3; i++)
                {
                    ((Label)e.Item.FindControl("lblEmptyCell")).Text = ((Label)e.Item.FindControl("lblEmptyCell")).Text + "<td></td>";
                }
            }
        }

        protected void repeaterCategoryItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                catgoryIndex = e.Item.ItemIndex;

                List<QualityFaults> FaultsList = qualityControl.Faults.FindAll(
                               delegate(QualityFaults faults)
                               {
                                   return faults.QualityFaultsCategoryId == qualityControl.Category[e.Item.ItemIndex].Id;
                               });

                catgoryID = qualityControl.Category[e.Item.ItemIndex].Id;

                SubCategoryList.Clear();
                List<QualityFaultsSubCategory> NewSubCategoryList = qualityControl.SubCategory;

                foreach (QualityFaults objQualityFaults in FaultsList)
                {
                    QualityFaultsSubCategory objTemp = NewSubCategoryList.Find(
                                   delegate(QualityFaultsSubCategory subCategory)
                                   {
                                       return subCategory.Id == objQualityFaults.QualityFaultsSubCategoryId;
                                   });

                    if (objTemp != null)
                    {
                        QualityFaultsSubCategory objTemp1 = SubCategoryList.Find(
                                   delegate(QualityFaultsSubCategory subCategory)
                                   {
                                       return subCategory.Id == objTemp.Id;
                                   });

                        if (objTemp1 == null)
                        {
                            SubCategoryList.Add(objTemp);
                        }

                    }


                }
                ((Repeater)e.Item.FindControl("repeaterSubCategory")).DataSource = SubCategoryList;
                ((Repeater)e.Item.FindControl("repeaterSubCategory")).DataBind();
            }
        }

        protected void repeaterSubCategoryItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                List<QualityFaults> qualityFaultsList = qualityControl.Faults.FindAll(delegate(QualityFaults qualityFaults) { return qualityFaults.QualityFaultsCategoryId == catgoryID && qualityFaults.QualityFaultsSubCategoryId == SubCategoryList[e.Item.ItemIndex].Id; });
                ((Repeater)e.Item.FindControl("ddlFaults2")).DataSource = qualityFaultsList;
                ((Repeater)e.Item.FindControl("ddlFaults2")).DataBind();

            }
        }

        protected void repeaterCategory2ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                catgoryIndex2 = e.Item.ItemIndex;

                List<QualityFaults> FaultsList = qualityControl.Faults.FindAll(
                               delegate(QualityFaults faults)
                               {
                                   return faults.QualityFaultsCategoryId == qualityControl.Category[e.Item.ItemIndex].Id;
                               });

                catgoryID2 = qualityControl.Category[e.Item.ItemIndex].Id;

                SubCategoryList2.Clear();
                List<QualityFaultsSubCategory> NewSubCategoryList = qualityControl.SubCategory;

                foreach (QualityFaults objQualityFaults in FaultsList)
                {
                    QualityFaultsSubCategory objTemp = NewSubCategoryList.Find(
                                   delegate(QualityFaultsSubCategory subCategory)
                                   {
                                       return subCategory.Id == objQualityFaults.QualityFaultsSubCategoryId;
                                   });

                    if (objTemp != null)
                    {
                        QualityFaultsSubCategory objTemp1 = SubCategoryList2.Find(
                                   delegate(QualityFaultsSubCategory subCategory)
                                   {
                                       return subCategory.Id == objTemp.Id;
                                   });

                        if (objTemp1 == null)
                        {
                            SubCategoryList2.Add(objTemp);
                        }

                    }


                }
                ((Repeater)e.Item.FindControl("repeaterSubCategory2")).DataSource = SubCategoryList2;
                ((Repeater)e.Item.FindControl("repeaterSubCategory2")).DataBind();
            }
        }

        protected void repeaterSubCategory2ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                List<QualityFaults> qualityFaultsList = qualityControl.Faults.FindAll(delegate(QualityFaults qualityFaults) { return qualityFaults.QualityFaultsCategoryId == catgoryID2 && qualityFaults.QualityFaultsSubCategoryId == SubCategoryList2[e.Item.ItemIndex].Id; });
                ((Repeater)e.Item.FindControl("ddlFaults")).DataSource = qualityFaultsList;
                ((Repeater)e.Item.FindControl("ddlFaults")).DataBind();

            }
        }

        protected void repeaterFaultsReporting_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                QualityFaults FaultsPP = qualityControl.FaultsPP[e.Item.ItemIndex];

                ((Repeater)e.Item.FindControl("repeaterSizes")).DataSource = FaultsPP.SizesList;
                ((Repeater)e.Item.FindControl("repeaterSizes")).DataBind();

                ((Repeater)e.Item.FindControl("repeaterQtyStock")).DataSource = FaultsPP.SizesList;
                ((Repeater)e.Item.FindControl("repeaterQtyStock")).DataBind();

                ((Repeater)e.Item.FindControl("repeaterQtyChecked")).DataSource = FaultsPP.SizesList;
                ((Repeater)e.Item.FindControl("repeaterQtyChecked")).DataBind();

                ((HtmlInputText)e.Item.FindControl("txtDateConducted")).Value = (FaultsPP.DateConducted != null && FaultsPP.DateConducted != DateTime.MinValue) ? FaultsPP.DateConducted.ToString("dd MMM yy (ddd)") : DateTime.Now.ToString("dd MMM yy (ddd)");

                if (!String.IsNullOrEmpty(FaultsPP.QA.ToString()) && FaultsPP.QA > 0)
                {
                    User user = this.UserControllerInstance.GetUserByID(FaultsPP.QA);
                    ((Label)e.Item.FindControl("lblQA")).Text = user.FullName.ToString();
                }
                else
                {
                    ((Label)e.Item.FindControl("lblQA")).Text = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FullName.ToString();
                }

                string stringLastAQLTemp = QualityControllerInstance.GetPriviousAQLBAL(OrderDetailID);
                string stringLastAQL = this.QualityControllerInstance.GetPriviousAQLBAL(OrderDetailID);
                if (stringLastAQL != "")
                {
                    ((Label)e.Item.FindControl("lblLastAQL")).Text = stringLastAQL;
                    ((Label)e.Item.FindControl("lblFinalAudit")).Text = "Re-Audit is Pending";
                }
                else
                {
                    ((Label)e.Item.FindControl("lblFinalAudit")).Text = "Final Audit";
                }
                if (FaultsPP.CheckingItems != null && FaultsPP.CheckingItems.Count > 0)
                {
                    ((CheckBox)e.Item.FindControl("chkMainLabel1")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[0].Missing);
                    ((CheckBox)e.Item.FindControl("chkMainLabel2")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[0].NotRequired);
                    ((CheckBox)e.Item.FindControl("chkMainLabel3")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[0].Present);
                    ((HiddenField)e.Item.FindControl("HiddenField1")).Value = FaultsPP.CheckingItems[0].Id.ToString();
                    if (!string.IsNullOrEmpty(FaultsPP.Status))
                    {
                        if (FaultsPP.Status == "PASS")
                        {
                            ((HtmlInputText)e.Item.FindControl("hdnRadioStatus")).Value = "1";

                        }

                        else
                        {
                            ((HtmlInputText)e.Item.FindControl("hdnRadioStatus")).Value = "2";
                        }
                        //   ((Label)e.Item.FindControl("lblFinalAudit")).Text = "Re-Audit is Pending";

                        //   string stringLastAQL = this.QualityControllerInstance.GetPriviousAQLBAL(OrderDetailID);
                        //   ((Label)e.Item.FindControl("lblLastAQL")).Text = stringLastAQL;


                        //   }


                    }
                    else
                        ((Label)e.Item.FindControl("lblFinalAudit")).Text = "FINAL AUDIT";

                    ((CheckBox)e.Item.FindControl("chkSizeLabel1")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[1].Missing);
                    ((CheckBox)e.Item.FindControl("chkSizeLabel2")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[1].NotRequired);
                    ((CheckBox)e.Item.FindControl("chkSizeLabel3")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[1].Present);
                    ((HiddenField)e.Item.FindControl("HiddenField2")).Value = FaultsPP.CheckingItems[1].Id.ToString();

                    ((CheckBox)e.Item.FindControl("chkWashCare1")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[2].Missing);
                    ((CheckBox)e.Item.FindControl("chkWashCare2")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[2].NotRequired);
                    ((CheckBox)e.Item.FindControl("chkWashCare3")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[2].Present);
                    ((HiddenField)e.Item.FindControl("HiddenField3")).Value = FaultsPP.CheckingItems[2].Id.ToString();

                    ((CheckBox)e.Item.FindControl("chkPriceTicket1")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[3].Missing);
                    ((CheckBox)e.Item.FindControl("chkPriceTicket2")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[3].NotRequired);
                    ((CheckBox)e.Item.FindControl("chkPriceTicket3")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[3].Present);
                    ((HiddenField)e.Item.FindControl("HiddenField4")).Value = FaultsPP.CheckingItems[3].Id.ToString();

                    ((CheckBox)e.Item.FindControl("chkPolybagSticker1")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[4].Missing);
                    ((CheckBox)e.Item.FindControl("chkPolybagSticker2")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[4].NotRequired);
                    ((CheckBox)e.Item.FindControl("chkPolybagSticker3")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[4].Present);
                    ((HiddenField)e.Item.FindControl("HiddenField5")).Value = FaultsPP.CheckingItems[4].Id.ToString();

                    ((CheckBox)e.Item.FindControl("chkCartonQuality1")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[5].Missing);
                    ((CheckBox)e.Item.FindControl("chkCartonQuality2")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[5].NotRequired);
                    ((CheckBox)e.Item.FindControl("chkCartonQuality3")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[5].Present);
                    ((HiddenField)e.Item.FindControl("HiddenField6")).Value = FaultsPP.CheckingItems[5].Id.ToString();

                    ((CheckBox)e.Item.FindControl("chkCartonStickers1")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[6].Missing);
                    ((CheckBox)e.Item.FindControl("chkCartonStickers2")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[6].NotRequired);
                    ((CheckBox)e.Item.FindControl("chkCartonStickers3")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[6].Present);
                    ((HiddenField)e.Item.FindControl("HiddenField7")).Value = FaultsPP.CheckingItems[6].Id.ToString();

                    ((CheckBox)e.Item.FindControl("chkPolybagQuality1")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[7].Missing);
                    ((CheckBox)e.Item.FindControl("chkPolybagQuality2")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[7].NotRequired);
                    ((CheckBox)e.Item.FindControl("chkPolybagQuality3")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[7].Present);
                    ((HiddenField)e.Item.FindControl("HiddenField8")).Value = FaultsPP.CheckingItems[7].Id.ToString();

                    ((CheckBox)e.Item.FindControl("chkHangers1")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[8].Missing);
                    ((CheckBox)e.Item.FindControl("chkHangers2")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[8].NotRequired);
                    ((CheckBox)e.Item.FindControl("chkHangers3")).Checked = Convert.ToBoolean(FaultsPP.CheckingItems[8].Present);
                    ((HiddenField)e.Item.FindControl("HiddenField9")).Value = FaultsPP.CheckingItems[8].Id.ToString();
                }
            }
        }

        #endregion

        #region Private Method

        private void BindControls()
        {
            if (OrderDetailID != -1)
            {
                PageHelper.RemoveJScriptVariable("faults"); //New
                PageHelper.RemoveJScriptVariable("faults1");

                qualityControl = this.QualityControllerInstance.GetQualityControl(OrderDetailID,"0",-1);
                lblClient.Text = qualityControl.OrderDetail.ParentOrder.Client.CompanyName.ToString();
                lblIkandiSerial.Text = qualityControl.OrderDetail.ParentOrder.SerialNumber.ToString();
                lblStyleNumber.Text = qualityControl.OrderDetail.ParentOrder.Style.StyleNumber.ToString();
                lblDescription.Text = qualityControl.OrderDetail.ParentOrder.Description.ToString();
                lblTotalQty.Text = qualityControl.OrderDetail.Quantity.ToString();
                lblColour.Text = qualityControl.OrderDetail.Fabric1.ToString() + "/ " + qualityControl.OrderDetail.Fabric1Details;
                lblccgsm.Text = qualityControl.OrderDetail.OrderDetailccgsm;
                lblLineItemNumber.Text = qualityControl.OrderDetail.LineItemNumber.ToString();
                lblContractNumber.Text = qualityControl.OrderDetail.ContractNumber.ToString();
                lblExFactory.Text = qualityControl.OrderDetail.ExFactory.ToString("dd MMM yy (ddd)");
                lblUnit.Text = qualityControl.OrderDetail.Unit.FactoryCode.ToString();
                lblPack.Text = qualityControl.OrderDetail.ParentOrder.StitchingDetail.PercentageOverallPcsPacked.ToString();
                lblStitch.Text = qualityControl.OrderDetail.ParentOrder.StitchingDetail.PercentageOverallPcsStitched.ToString();
                string ccgsm = qualityControl.OrderDetail.OrderDetailccgsm;
                //try
                //{                    
                //    string ccgsmvalue=string.Empty;
                //    string[] ccgsmpart = ccgsm.Split(' ');
                //    if (ccgsmpart[2] == ""&&ccgsmpart[1]=="CC:")
                //    {
                //         ccgsm = ccgsmpart[2] + ccgsmpart[3];
                //    }
                //    if (ccgsmpart[4] == ""&&ccgsmpart[3]=="GSM:")
                //    {
                //        ccgsm += ccgsmpart[0] + ccgsmpart[1];
                //    }
                //}
                //catch (Exception)
                //{ 
                //}
                lblccgsm.Text = ccgsm;
                if (Convert.ToDateTime(qualityControl.OrderDetail.InlinePPM.DateHeldOn) != DateTime.MinValue)
                    lblDateHeld.Text = qualityControl.OrderDetail.InlinePPM.DateHeldOn.ToString("dd MMM yy (ddd)");
                else
                    lblDateHeld.Text = string.Empty;
                lblPpmRemarks.Text = Convert.ToString(qualityControl.OrderDetail.InlinePPM.PPMRemarks).Replace("$$", " ");
                lblFactoryMgr.Text = qualityControl.OrderDetail.InlinePPM.FactoryManager.FirstName.ToString();
                lblDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                lblClientHeadDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                lblFactoryHeadDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                lblStatus.Text = qualityControl.OrderDetail.ParentOrder.WorkflowInstanceDetail.StatusMode.ToString();
                hiddenStyleId.Value = qualityControl.OrderDetail.ParentOrder.Style.StyleID.ToString();
                hiddenStyleNumber.Value = qualityControl.OrderDetail.ParentOrder.Style.StyleCode.ToString();
                txtOtherProcessingInstruction.Enabled = false;

                imgPrint.ImageUrl = ResolveUrl("~/Uploads/Style/thumb-" + qualityControl.OrderDetail.ParentOrder.Style.SampleImageURL1);

                UserController controller = new UserController(ApplicationHelper.LoggedInUser);

                users2 = this.UserControllerInstance.GetFactoryManagerByClient(OrderDetailID);
                //users3 = new List<User>();
                //User a = new User();
                //a.FirstName = "a";
                //a.LastName = "B";
                //a.UserID = 10000;
                //users3.Add(a);
                // users3 = controller.GetUsersByDesignation((int)iKandi.Common.Designation.BIPL_QA_FACTORY_HEAD);
                //users4 = controller.GetUsersByDesignation((int)iKandi.Common.Designation.BIPL_QA_QA);

                //users2.AddRange(users3);
                //users2.AddRange(users4);

                ddlOwner.DataSource = users2;
                ddlOwner.DataBind();

                repeaterOwner.DataSource = users2;
                repeaterOwner.DataBind();

                repeaterAuditChart1.DataSource = this.QualityControllerInstance.GetAuditChart("1.5");
                repeaterAuditChart1.DataBind();

                repeaterAuditChart2.DataSource = this.QualityControllerInstance.GetAuditChart("2.5");
                repeaterAuditChart2.DataBind();

                repeaterCategory2.DataSource = qualityControl.Category;
                repeaterCategory2.DataBind();

                repeaterCategory.DataSource = qualityControl.Category;
                repeaterCategory.DataBind();

                //if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_QA_Manager))
                if ((ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)37))//Shipping Officer
                    chkQAManager.Enabled = true;
                else
                    chkQAManager.Enabled = false;

                if ((ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)42))//Client Head
                    chkClientHead.Enabled = true;
                else
                    chkClientHead.Enabled = false;

                if ((ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)26))//CQD
                    chkFactoryHead.Enabled = true;
                else
                    chkFactoryHead.Enabled = false;


                iKandi.Common.QualityControl qualityControl1 = new iKandi.Common.QualityControl();

                qualityControl1.Faults = new List<QualityFaults>();
                QualityFaults faults = new QualityFaults();
                faults.FaultDescription = "";
                faults.Id = -1;
                faults.FaultId = 0;
                faults.FaultType = 3;
                faults.Resolution = "";
                faults.Permission = 0;
                faults.LastResolution = "";

                qualityControl1.Faults.Add(faults);

                if (qualityControl1.Faults != null && qualityControl1.Faults.Count > 0)
                {
                    System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
                    new System.Web.Script.Serialization.JavaScriptSerializer();

                    string sJSON = oSerializer.Serialize(qualityControl1.Faults);

                    PageHelper.AddJScriptVariable("faults", "{" + string.Format("table: {0}", sJSON) + "}");
                }

                qualityControl1.Faults1 = new List<QualityFaults>();
                QualityFaults faults1 = new QualityFaults();
                faults1.Id = -1;
                faults1.FaultDescription = "";
                faults1.FaultId = 0;
                faults1.Occurrence = 0;
                faults1.FaultType = 3;
                faults1.Resolution = "";
                faults1.Permission = 0;
                faults1.LastResolution = "";

                qualityControl1.Faults1.Add(faults1);

                if (qualityControl1.Faults1 != null && qualityControl1.Faults1.Count > 0)
                {
                    System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
                    new System.Web.Script.Serialization.JavaScriptSerializer();

                    string sJSON = oSerializer.Serialize(qualityControl1.Faults1);

                    PageHelper.AddJScriptVariable("faults1", "{" + string.Format("table: {0}", sJSON) + "}");
                }

                PopulateQualityData();
            }
        }

        private void SaveQuality()
        {

            iKandi.Common.QualityControl qualityControl = new iKandi.Common.QualityControl();

            iKandi.Common.QualityControl qualityControlOld = this.QualityControllerInstance.GetQualityControlByID(OrderDetailID);

            if (qualityControlOld.FaultsPP.Count > 0)
                ViewState["AQLType"] = qualityControlOld.FaultsPP[0].AqlValue;
            qualityControl.OrderDetail = new OrderDetail();

            qualityControl.OrderDetail.OrderDetailID = OrderDetailID;

            string userName = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            string dateToday = DateTime.Today.ToString("dd MMM");
            string Comments = txtComments.Text;

            if (!string.IsNullOrEmpty(txtComments.Text))
                qualityControl.Comments = userName + " " + "(" + dateToday + ")" + " " + " : " + Comments + " ";
            else
                qualityControl.Comments = string.Empty;

            qualityControl.ApprovedByQAManager = Convert.ToInt32(chkQAManager.Checked);
            qualityControl.ApprovedByClientHead = Convert.ToInt32(chkClientHead.Checked);
            qualityControl.ApprovedByFactoryHead = Convert.ToInt32(chkFactoryHead.Checked);
            //if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_QA_Manager))
            //{                
            if ((chkQAManager.Checked) == true)
                if (qualityControlOld.ApprovedByQAManager == 0)
                    qualityControl.ApprovedByQAManagerOn = DateHelper.ParseDate(lblDate.Text).Value;
                else
                    qualityControl.ApprovedByQAManagerOn = qualityControlOld.ApprovedByQAManagerOn;
            //}

            //if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Client_Head))
            //{               
            if ((chkClientHead.Checked) == true)
                if (qualityControlOld.ApprovedByClientHead == 0)
                    qualityControl.ApprovedByClientHeadOn = DateHelper.ParseDate(lblClientHeadDate.Text).Value;
                else
                    qualityControl.ApprovedByClientHeadOn = qualityControlOld.ApprovedByClientHeadOn;
            //}

            //if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_QA_FACTORY_HEAD))
            //{
            if ((chkFactoryHead.Checked) == true)
                if (qualityControlOld.ApprovedByFactoryHead == 0)
                    qualityControl.ApprovedByFactoryHeadOn = DateHelper.ParseDate(lblFactoryHeadDate.Text).Value;
                else
                    qualityControl.ApprovedByFactoryHeadOn = qualityControlOld.ApprovedByFactoryHeadOn;
            //}


            if (ddlProcessingInstructions.SelectedValue == "4")
            {
                qualityControl.ProcessingInstruction = Convert.ToInt32(ddlProcessingInstructions.SelectedValue);
                if (!string.IsNullOrEmpty(txtOtherProcessingInstruction.Text))
                {
                    qualityControl.OtherInstruction = txtOtherProcessingInstruction.Text;
                }
            }
            else
            {
                qualityControl.ProcessingInstruction = Convert.ToInt32(ddlProcessingInstructions.SelectedValue);
                qualityControl.OtherInstruction = null;
            }

            qualityControl.Faults = new List<QualityFaults>();

            List<string> owner = new List<string>();
            int i = 1;

            while (!string.IsNullOrEmpty(Request.Params["faultDesc" + i.ToString()]))
            {
                QualityFaults qualityFaults = new QualityFaults();
                qualityFaults.ParentQualityControl = new iKandi.Common.QualityControl();
                qualityFaults.ParentQualityControl.OrderDetail = new OrderDetail();

                String fId = Request.Params["faultDesc" + i.ToString()];
                if (fId == "-1")
                {
                    i++;
                    continue;
                }
                var fID = fId.Split('-');
                if (!String.IsNullOrEmpty(fID[0]))
                    qualityFaults.FaultId = Convert.ToInt32(fID[0]);
                if (!String.IsNullOrEmpty(fID[1]))
                    qualityFaults.FaultType = Convert.ToInt32(fID[1]);
                if (!String.IsNullOrEmpty(Request.Params["txtIsDeleted" + i.ToString()]))
                    qualityFaults.IsDeleted = Convert.ToInt32(Request.Params["txtIsDeleted" + i.ToString()]);
                qualityFaults.ParentQualityControl.OrderDetail.OrderDetailID = OrderDetailID;
                //qualityFaults.Resolution = Request.Params["txtResolution" + i.ToString()];
                if (!String.IsNullOrEmpty(Request.Params["owner" + i.ToString()]))
                    qualityFaults.Owner = Convert.ToInt32(Request.Params["owner" + i.ToString()]);
                owner.Add((Request.Params["owner" + i.ToString()]));
                qualityFaults.Occurrence = 0;
                qualityFaults.IsOnline = 1;
                if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
                {
                    if (!string.IsNullOrEmpty(Request.Params["hiddenID" + i.ToString()]))
                        qualityFaults.Id = Convert.ToInt32(Request.Params["hiddenID" + i.ToString()]);
                    else
                        qualityFaults.Id = -1;
                    qualityFaults.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
                }
                else
                    qualityFaults.Id = -1;

                if (Request.Params["hdnRowStatus" + i.ToString()] == "1" || Request.Params["hdnRowStatus" + i.ToString()] == "")
                    qualityControl.Faults.Add(qualityFaults);
                i++;
            }




            qualityControl.FaultsPP = new List<QualityFaults>();
            qualityControl.Faults1 = new List<QualityFaults>();
            int index = 1;
            foreach (RepeaterItem repFaults in repeaterFaultsReporting.Items)
            {
                HiddenField hdnQCPartStatusId = ((HiddenField)repFaults.FindControl("hdnQCPartStatusId"));
                HtmlInputText txtActualSamplesChecked = ((HtmlInputText)repFaults.FindControl("txtActualSamplesChecked"));//
                HtmlInputText hdnRadioStatus = ((HtmlInputText)repFaults.FindControl("hdnRadioStatus"));
                HtmlInputText txtDateConducted = ((HtmlInputText)repFaults.FindControl("txtDateConducted"));//


                //
                HtmlInputText txtActuaQTY = ((HtmlInputText)repFaults.FindControl("lblQtyFinal"));//
                HtmlInputText txtSampleQTY = ((HtmlInputText)repFaults.FindControl("lblSampleQty"));//
                //                string stringQaName = .Text;
                Label lbl = ((Label)repFaults.FindControl("lblQA"));//

                string[] str = new string[5];


                str[0] = txtDateConducted.Value;
                str[1] = txtActuaQTY.Value;
                str[2] = txtSampleQTY.Value;
                str[3] = txtActualSamplesChecked.Value;
                str[4] = lbl.Text;
                ViewState["OnLineDate"] = str;
                //HtmlInputText txtSampleQTY = ((HtmlInputText)repFaults.FindControl("txtActualSamplesChecked"));//

                //

                CheckBox chkMainLabel1 = ((CheckBox)repFaults.FindControl("chkMainLabel1"));
                CheckBox chkMainLabel2 = ((CheckBox)repFaults.FindControl("chkMainLabel2"));
                CheckBox chkMainLabel3 = ((CheckBox)repFaults.FindControl("chkMainLabel3"));
                HiddenField HiddenField1 = ((HiddenField)repFaults.FindControl("HiddenField1"));
                CheckBox chkSizeLabel1 = ((CheckBox)repFaults.FindControl("chkSizeLabel1"));
                CheckBox chkSizeLabel2 = ((CheckBox)repFaults.FindControl("chkSizeLabel2"));
                CheckBox chkSizeLabel3 = ((CheckBox)repFaults.FindControl("chkSizeLabel3"));
                HiddenField HiddenField2 = ((HiddenField)repFaults.FindControl("HiddenField2"));
                CheckBox chkWashCare1 = ((CheckBox)repFaults.FindControl("chkWashCare1"));
                CheckBox chkWashCare2 = ((CheckBox)repFaults.FindControl("chkWashCare2"));
                CheckBox chkWashCare3 = ((CheckBox)repFaults.FindControl("chkWashCare3"));
                HiddenField HiddenField3 = ((HiddenField)repFaults.FindControl("HiddenField3"));
                CheckBox chkPriceTicket1 = ((CheckBox)repFaults.FindControl("chkPriceTicket1"));
                CheckBox chkPriceTicket2 = ((CheckBox)repFaults.FindControl("chkPriceTicket2"));
                CheckBox chkPriceTicket3 = ((CheckBox)repFaults.FindControl("chkPriceTicket3"));
                HiddenField HiddenField4 = ((HiddenField)repFaults.FindControl("HiddenField4"));
                CheckBox chkPolybagSticker1 = ((CheckBox)repFaults.FindControl("chkPolybagSticker1"));
                CheckBox chkPolybagSticker2 = ((CheckBox)repFaults.FindControl("chkPolybagSticker2"));
                CheckBox chkPolybagSticker3 = ((CheckBox)repFaults.FindControl("chkPolybagSticker3"));
                HiddenField HiddenField5 = ((HiddenField)repFaults.FindControl("HiddenField5"));
                CheckBox chkCartonQuality1 = ((CheckBox)repFaults.FindControl("chkCartonQuality1"));
                CheckBox chkCartonQuality2 = ((CheckBox)repFaults.FindControl("chkCartonQuality2"));
                CheckBox chkCartonQuality3 = ((CheckBox)repFaults.FindControl("chkCartonQuality3"));
                HiddenField HiddenField6 = ((HiddenField)repFaults.FindControl("HiddenField6"));
                CheckBox chkCartonStickers1 = ((CheckBox)repFaults.FindControl("chkCartonStickers1"));
                CheckBox chkCartonStickers2 = ((CheckBox)repFaults.FindControl("chkCartonStickers2"));
                CheckBox chkCartonStickers3 = ((CheckBox)repFaults.FindControl("chkCartonStickers3"));
                HiddenField HiddenField7 = ((HiddenField)repFaults.FindControl("HiddenField7"));
                CheckBox chkPolybagQuality1 = ((CheckBox)repFaults.FindControl("chkPolybagQuality1"));
                CheckBox chkPolybagQuality2 = ((CheckBox)repFaults.FindControl("chkPolybagQuality2"));
                CheckBox chkPolybagQuality3 = ((CheckBox)repFaults.FindControl("chkPolybagQuality3"));
                HiddenField HiddenField8 = ((HiddenField)repFaults.FindControl("HiddenField8"));
                CheckBox chkHangers1 = ((CheckBox)repFaults.FindControl("chkHangers1"));
                CheckBox chkHangers2 = ((CheckBox)repFaults.FindControl("chkHangers2"));
                CheckBox chkHangers3 = ((CheckBox)repFaults.FindControl("chkHangers3"));
                HiddenField HiddenField9 = ((HiddenField)repFaults.FindControl("HiddenField9"));
                HiddenField hdnProdPlanID = ((HiddenField)repFaults.FindControl("hdnProdPlanID"));
                HiddenField hdnIsPartShipment = ((HiddenField)repFaults.FindControl("hdnIsPartShipment"));

                ViewState["productionplanID"] = hdnProdPlanID.Value;
                QualityFaults faultsPp = new QualityFaults();

                if (!string.IsNullOrEmpty(hdnQCPartStatusId.Value))
                    faultsPp.Id = Convert.ToInt32(hdnQCPartStatusId.Value);
                else
                    faultsPp.Id = -1;

                if (!string.IsNullOrEmpty(txtActualSamplesChecked.Value))
                    faultsPp.ActualSamplesChecked = Convert.ToInt32(txtActualSamplesChecked.Value);

                faultsPp.QA = ApplicationHelper.LoggedInUser.UserData.UserID;
                //edited by abhishek on 8/2/2016
                if (!string.IsNullOrEmpty(hdnRadioStatus.Value))
                {
                    faultsPp.Status = hdnRadioStatus.Value;
                    if (Convert.ToInt32(hdnRadioStatus.Value) == 2)
                        ViewState["FaultStatus"] = 2;
                    ViewState["FaultStatus_new"] = 2;
                }
                else
                {
                    faultsPp.Status = "0";
                    ViewState["FaultStatus"] = 1;
                    ViewState["FaultStatus_new"] = 2;
                }
                //end by abhishek on 8/2/2016
                if (!string.IsNullOrEmpty(txtDateConducted.Value))
                    faultsPp.DateConducted = DateHelper.ParseDate(txtDateConducted.Value).Value;

                if (!string.IsNullOrEmpty(hdnIsPartShipment.Value))
                    faultsPp.IsPartShipment = Convert.ToBoolean(hdnIsPartShipment.Value);

                if (!string.IsNullOrEmpty(hdnProdPlanID.Value))
                    faultsPp.ProductionPlanningID = Convert.ToInt32(hdnProdPlanID.Value);

                #region CheckingItems
                faultsPp.CheckingItems = new List<ItemsToCheck>();
                iKandi.Common.ItemsToCheck itemChk1 = new iKandi.Common.ItemsToCheck();
                itemChk1.ParentQualityControl = new iKandi.Common.QualityControl();
                itemChk1.CheckingItem = 1;
                itemChk1.Missing = Convert.ToInt32(chkMainLabel1.Checked);
                itemChk1.NotRequired = Convert.ToInt32(chkMainLabel2.Checked);
                itemChk1.Present = Convert.ToInt32(chkMainLabel3.Checked);
                itemChk1.ProductionPlanningID = Convert.ToInt32(hdnProdPlanID.Value);
                if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
                {
                    if (!String.IsNullOrEmpty(HiddenField1.Value))
                        itemChk1.Id = Convert.ToInt32(HiddenField1.Value);
                    else
                        itemChk1.Id = -1;

                    itemChk1.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
                }
                else
                    itemChk1.Id = -1;
                faultsPp.CheckingItems.Add(itemChk1);

                iKandi.Common.ItemsToCheck itemChk2 = new iKandi.Common.ItemsToCheck();
                itemChk2.ParentQualityControl = new iKandi.Common.QualityControl();
                itemChk2.CheckingItem = 2;
                itemChk2.Missing = Convert.ToInt32(chkSizeLabel1.Checked);
                itemChk2.NotRequired = Convert.ToInt32(chkSizeLabel2.Checked);
                itemChk2.Present = Convert.ToInt32(chkSizeLabel3.Checked);
                itemChk2.ProductionPlanningID = Convert.ToInt32(hdnProdPlanID.Value);
                if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
                {
                    if (HiddenField2.Value != "" || HiddenField2.Value != string.Empty)
                        itemChk2.Id = Convert.ToInt32(HiddenField2.Value);
                    else
                        itemChk2.Id = -1;

                    itemChk2.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
                }
                else
                    itemChk2.Id = -1;
                faultsPp.CheckingItems.Add(itemChk2);

                iKandi.Common.ItemsToCheck itemChk3 = new iKandi.Common.ItemsToCheck();
                itemChk3.ParentQualityControl = new iKandi.Common.QualityControl();
                itemChk3.CheckingItem = 3;
                itemChk3.Missing = Convert.ToInt32(chkWashCare1.Checked);
                itemChk3.NotRequired = Convert.ToInt32(chkWashCare2.Checked);
                itemChk3.Present = Convert.ToInt32(chkWashCare3.Checked);
                itemChk3.ProductionPlanningID = Convert.ToInt32(hdnProdPlanID.Value);
                if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
                {
                    if (HiddenField3.Value != "" || HiddenField3.Value != string.Empty) // done as expection was thrown
                        itemChk3.Id = Convert.ToInt32(HiddenField3.Value);
                    else
                        itemChk3.Id = -1;

                    itemChk3.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
                }
                else
                    itemChk3.Id = -1;
                faultsPp.CheckingItems.Add(itemChk3);

                iKandi.Common.ItemsToCheck itemChk4 = new iKandi.Common.ItemsToCheck();
                itemChk4.ParentQualityControl = new iKandi.Common.QualityControl();
                itemChk4.CheckingItem = 4;
                itemChk4.Missing = Convert.ToInt32(chkPriceTicket1.Checked);
                itemChk4.NotRequired = Convert.ToInt32(chkPriceTicket2.Checked);
                itemChk4.Present = Convert.ToInt32(chkPriceTicket3.Checked);
                itemChk4.ProductionPlanningID = Convert.ToInt32(hdnProdPlanID.Value);
                if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
                {
                    if (HiddenField4.Value != "" || HiddenField4.Value != string.Empty) // done as expection was thrown
                        itemChk4.Id = Convert.ToInt32(HiddenField4.Value);
                    else
                        itemChk4.Id = -1;

                    itemChk4.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
                }
                else
                    itemChk4.Id = -1;
                faultsPp.CheckingItems.Add(itemChk4);

                iKandi.Common.ItemsToCheck itemChk5 = new iKandi.Common.ItemsToCheck();
                itemChk5.ParentQualityControl = new iKandi.Common.QualityControl();
                itemChk5.CheckingItem = 5;
                itemChk5.Missing = Convert.ToInt32(chkPolybagSticker1.Checked);
                itemChk5.NotRequired = Convert.ToInt32(chkPolybagSticker2.Checked);
                itemChk5.Present = Convert.ToInt32(chkPolybagSticker3.Checked);
                itemChk5.ProductionPlanningID = Convert.ToInt32(hdnProdPlanID.Value);
                if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
                {
                    if (HiddenField5.Value != "" || HiddenField5.Value != string.Empty) // done as expection was thrown
                        itemChk5.Id = Convert.ToInt32(HiddenField5.Value);
                    else
                        itemChk5.Id = -1;

                    itemChk5.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
                }
                else
                    itemChk5.Id = -1;
                faultsPp.CheckingItems.Add(itemChk5);

                iKandi.Common.ItemsToCheck itemChk6 = new iKandi.Common.ItemsToCheck();
                itemChk6.ParentQualityControl = new iKandi.Common.QualityControl();
                itemChk6.CheckingItem = 6;
                itemChk6.Missing = Convert.ToInt32(chkCartonQuality1.Checked);
                itemChk6.NotRequired = Convert.ToInt32(chkCartonQuality2.Checked);
                itemChk6.Present = Convert.ToInt32(chkCartonQuality3.Checked);
                itemChk6.ProductionPlanningID = Convert.ToInt32(hdnProdPlanID.Value);
                if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
                {
                    if (HiddenField6.Value != "" || HiddenField6.Value != string.Empty) // done as expection was thrown
                        itemChk6.Id = Convert.ToInt32(HiddenField6.Value);
                    else
                        itemChk6.Id = -1;

                    itemChk6.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
                }
                else
                    itemChk6.Id = -1;
                faultsPp.CheckingItems.Add(itemChk6);

                iKandi.Common.ItemsToCheck itemChk7 = new iKandi.Common.ItemsToCheck();
                itemChk7.ParentQualityControl = new iKandi.Common.QualityControl();
                itemChk7.CheckingItem = 7;
                itemChk7.Missing = Convert.ToInt32(chkCartonStickers1.Checked);
                itemChk7.NotRequired = Convert.ToInt32(chkCartonStickers2.Checked);
                itemChk7.Present = Convert.ToInt32(chkCartonStickers3.Checked);
                itemChk7.ProductionPlanningID = Convert.ToInt32(hdnProdPlanID.Value);
                if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
                {
                    if (HiddenField7.Value != "" || HiddenField7.Value != string.Empty) // done as expection was thrown
                        itemChk7.Id = Convert.ToInt32(HiddenField7.Value);
                    else
                        itemChk7.Id = -1;

                    itemChk7.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
                }
                else
                    itemChk7.Id = -1;
                faultsPp.CheckingItems.Add(itemChk7);

                iKandi.Common.ItemsToCheck itemChk8 = new iKandi.Common.ItemsToCheck();
                itemChk8.ParentQualityControl = new iKandi.Common.QualityControl();
                itemChk8.CheckingItem = 8;
                itemChk8.Missing = Convert.ToInt32(chkPolybagQuality1.Checked);
                itemChk8.NotRequired = Convert.ToInt32(chkPolybagQuality2.Checked);
                itemChk8.Present = Convert.ToInt32(chkPolybagQuality3.Checked);
                itemChk8.ProductionPlanningID = Convert.ToInt32(hdnProdPlanID.Value);
                if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
                {
                    if (HiddenField8.Value != "" || HiddenField8.Value != string.Empty) // done as expection was thrown
                        itemChk8.Id = Convert.ToInt32(HiddenField8.Value);
                    else
                        itemChk8.Id = -1;

                    itemChk8.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
                }
                else
                    itemChk8.Id = -1;
                faultsPp.CheckingItems.Add(itemChk8);

                iKandi.Common.ItemsToCheck itemChk9 = new iKandi.Common.ItemsToCheck();
                itemChk9.ParentQualityControl = new iKandi.Common.QualityControl();
                itemChk9.CheckingItem = 9;
                itemChk9.Missing = Convert.ToInt32(chkHangers1.Checked);
                itemChk9.NotRequired = Convert.ToInt32(chkHangers2.Checked);
                itemChk9.Present = Convert.ToInt32(chkHangers3.Checked);
                itemChk9.ProductionPlanningID = Convert.ToInt32(hdnProdPlanID.Value);
                if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
                {
                    if (HiddenField9.Value != "" || HiddenField9.Value != string.Empty) // done as expection was thrown
                        itemChk9.Id = Convert.ToInt32(HiddenField9.Value);
                    else
                        itemChk9.Id = -1;

                    itemChk9.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
                }
                else
                    itemChk9.Id = -1;
                faultsPp.CheckingItems.Add(itemChk9);
                #endregion

                int j = 1;
                while (!string.IsNullOrEmpty(Request.Params["faultDescReport" + j.ToString() + "_" + index.ToString()]))
                {
                    QualityFaults qualityFaults = new QualityFaults();
                    qualityFaults.ParentQualityControl = new iKandi.Common.QualityControl();
                    qualityFaults.ParentQualityControl.OrderDetail = new OrderDetail();

                    String fId = Request.Params["faultDescReport" + j.ToString() + "_" + index.ToString()];
                    if (fId == "-1")
                    {
                        j++;
                        continue;
                    }
                    var fID = fId.Split('-');

                    if (!String.IsNullOrEmpty(fID[0]))
                        qualityFaults.FaultId = Convert.ToInt32(fID[0]);
                    if (!String.IsNullOrEmpty(fID[1]))
                        qualityFaults.FaultType = Convert.ToInt32(fID[1]);
                    if (!String.IsNullOrEmpty(Request.Params["txtIsDeletedR" + j.ToString() + "_" + index.ToString()]))
                        qualityFaults.IsDeleted = Convert.ToInt32(Request.Params["txtIsDeletedR" + j.ToString() + "_" + index.ToString()]);
                    qualityFaults.ParentQualityControl.OrderDetail.OrderDetailID = OrderDetailID;
                    if (!String.IsNullOrEmpty(Request.Params["ownerR" + j.ToString() + "_" + index.ToString()]))
                        qualityFaults.Owner = Convert.ToInt32(Request.Params["ownerR" + j.ToString() + "_" + index.ToString()]);
                    if (!String.IsNullOrEmpty(Request.Params["txtOccurrence" + j.ToString() + "_" + index.ToString()]))
                        qualityFaults.Occurrence = Convert.ToInt32(Request.Params["txtOccurrence" + j.ToString() + "_" + index.ToString()]);
                    qualityFaults.IsOnline = 0;
                    if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
                    {
                        if (!string.IsNullOrEmpty(Request.Params["hiddenIDReport" + j.ToString() + "_" + index.ToString()]))
                            qualityFaults.Id = Convert.ToInt32(Request.Params["hiddenIDReport" + j.ToString() + "_" + index.ToString()]);
                        else
                            qualityFaults.Id = -1;
                        qualityFaults.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
                    }
                    else
                        qualityFaults.Id = -1;

                    qualityFaults.ProductionPlanningID = Convert.ToInt32(hdnProdPlanID.Value);
                    if (Request.Params["hdnRowStatusOcc" + j.ToString() + "_" + index.ToString()] == "1" || Request.Params["hdnRowStatusOcc" + j.ToString() + "_" + index.ToString()] == "")
                        qualityControl.Faults1.Add(qualityFaults);
                    ViewState["ProductionID"] = Convert.ToInt32(hdnProdPlanID.Value);
                    j++;

                }

                qualityControl.FaultsPP.Add(faultsPp);
                index++;
            }

            //for (int temp = 0; temp < qualityControl.FaultsPP.Count; temp++)
            //{
            //    qualityControl.Faults[temp].ProductionPlanningID = qualityControl.FaultsPP[0].ProductionPlanningID;
            //}

            if (Convert.ToInt32(ViewState["FaultStatus"]) == 2)
            {
                string stringFault = "<Table>";
                int iTotalFaultR = qualityControl.Faults1.Count;

                for (int inti = 0; inti <= iTotalFaultR - 1; inti++)
                {
                    stringFault += "<FaultId>" + qualityControl.Faults1[inti].FaultId + "</FaultId>";
                    stringFault += "<FaultType>" + qualityControl.Faults1[inti].FaultType + "</FaultType>";
                    stringFault += "<Occurrence>" + qualityControl.Faults1[inti].Occurrence + "</Occurrence>";
                    stringFault += "<FaultOwner>" + qualityControl.Faults1[inti].Owner + "</FaultOwner>";
                    string strtemp = qualityControl.Faults1[inti].LastResolution ?? "";
                    stringFault += "<FaultResolution>" + strtemp + "</FaultResolution>";
                }
                stringFault += "</Table>";


                string[] str1 = new string[5];
                str1 = (string[])ViewState["OnLineDate"];
                int intID = Convert.ToInt32(ViewState["productionplanID"]);
                int iTotalFault = qualityControl.Faults.Count;
                int intQualitycontrolID = 0;
                if (ViewState["QualityControlID"] != null)
                {
                    intID = Convert.ToInt32(ViewState["ProductionID"]);
                    intQualitycontrolID = Convert.ToInt32(ViewState["QualityControlID"]);
                }

                string stringXML = "<Table>";
                for (int inti = 0; inti <= iTotalFault - 1; inti++)
                {
                    stringXML += "<FaultId>" + qualityControl.Faults[inti].FaultId + "</FaultId>";
                    stringXML += "<FaultType>" + qualityControl.Faults[inti].FaultType + "</FaultType>";
                    stringXML += "<FaultOwner>" + qualityControl.Faults[inti].Owner + "</FaultOwner>";
                    string strtemp = qualityControl.Faults[inti].Resolution ?? "";
                    stringXML += "<FaultResolution>" + strtemp + "</FaultResolution>";
                }
                stringXML += "</Table>";
                //Save QualityAssurance
                QualityControllerInstance.InsertFinalAuditAndQualityAssuranceBAL(str1, intID, stringXML, intQualitycontrolID, Convert.ToDouble(ViewState["AQLType"]), stringFault);// Uncomment
                ViewState["FaultStatus"] = 1;
            }
            //Save QualityControl
            if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
            {
                qualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
                this.QualityControllerInstance.UpdateQualityControl(qualityControl);
            }
            else
                this.QualityControllerInstance.InsertQualityControl(qualityControl);

            {
                //Edited by abhishek on 8/2/2016
                if (ViewState["FaultStatus_new"] != null)
                { //if (faultsPp.Status.ToString().ToUpper() == "FAIL")


                    if (ViewState["FaultStatus_new"].ToString() == "2")
                    {
                        //    this.NotificationControllerInstance.SendQAStausFailEmail(OrderDetailID);
                        //Gajendra Email Notification
                        NotificationEmailHistory NEH = new NotificationEmailHistory();
                        NEH.Type = "5";
                        NEH.EmailID = "12";
                        NEH.OrderID = "0";
                        NEH.OrderDetailsID = OrderDetailID.ToString();
                        //this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                    }
                }

                //end by abhishek 8/2/2016
            }


            pnlForm.Visible = false;
            pnlMessage.Visible = true;
            //int intProductionId=qualityControl.
            //HiddenField hdnQCPartStatusId1 = ((HiddenField)repFaults.FindControl("hdnQCPartStatusId"));
            //HtmlInputText txtActualSamplesChecked1 = ((HtmlInputText)repFaults.FindControl("txtActualSamplesChecked"));//
            //HtmlInputText hdnRadioStatus1 = ((HtmlInputText)repFaults.FindControl("hdnRadioStatus"));
            //HtmlInputText txtDateConducted1 = ((HtmlInputText)repFaults.FindControl("txtDateConducted"));//


            ////
            //HtmlInputText txtActuaQTY1 = ((HtmlInputText)repFaults.FindControl("lblQtyFinal"));//
            //HtmlInputText txtSampleQTY1 = ((HtmlInputText)repFaults.FindControl("lblSampleQty"));//
            ////                string stringQaName = .Text;
            //Label lbl1 = ((Label)repFaults.FindControl("lblQA"));

        }

        private void PopulateQualityData()
        {
            hdnOrderDetailID.Value = (OrderDetailID).ToString();
            if (OrderDetailID != -1)
            {
                //System.Diagnostics.Debugger.Break();
                qualityControl = this.QualityControllerInstance.GetQualityControlBYQuality(OrderDetailID, QualityControlID, InspectionID);
                if (qualityControl.FaultsPP != null)
                {
                    if (qualityControl.FaultsPP.Count > 1)
                    {
                        ViewState["QualityControlID"] = qualityControl.Id;
                        ViewState["ProductionID"] = qualityControl.FaultsPP[0].ProductionPlanningID;
                    }
                }
                if (qualityControl.FaultsPP != null && qualityControl.FaultsPP.Count > 0)
                {
                    //foreach (QualityFaults qf in qualityControl.FaultsPP)
                    //{
                    //    if (qf.ProductionPlanningID > 0)
                    //        IsBind++;
                    //}
                    //if (IsBind > 0)
                    //{
                        repeaterFaultsReporting.DataSource = qualityControl.FaultsPP;
                        repeaterFaultsReporting.DataBind();
                    //}
                    //else
                        //repeaterFaultsReporting.Visible = false;
                }


                List<List<QualityFaults>> qualityFaults = new List<List<QualityFaults>>();

                if (qualityControl.OrderDetail.OrderDetailID == OrderDetailID)
                {
                    PageHelper.RemoveJScriptVariable("faults");
                    PageHelper.RemoveJScriptVariable("faults1");

                    lblLastComment.Visible = true;
                    hiddenQualityControlID.Value = qualityControl.Id.ToString();
                    txtComments.Text = string.Empty;



                    if (qualityControl.Comments.IndexOf("$$") > -1)
                    {
                        lblLastComment.Text = qualityControl.Comments.ToString().Substring(qualityControl.Comments.LastIndexOf("$$") + 2);
                        hdnComment.Value = qualityControl.Comments.ToString().Replace("$$", "<br/>");
                    }
                    else
                    {
                        lblLastComment.Text = qualityControl.Comments.ToString();
                        hdnComment.Value = qualityControl.Comments.ToString();
                    }
                    //lblLastComment.Text = qualityControl.Comments.ToString();
                    hdnComment.Value = qualityControl.Comments.ToString();


                    chkQAManager.Checked = Convert.ToBoolean(qualityControl.ApprovedByQAManager);
                    chkClientHead.Checked = Convert.ToBoolean(qualityControl.ApprovedByClientHead);
                    chkFactoryHead.Checked = Convert.ToBoolean(qualityControl.ApprovedByFactoryHead);

                    if (qualityControl.ApprovedByQAManager == 1)
                    {
                        chkQAManager.Enabled = false;
                        lblDate.Text = qualityControl.ApprovedByQAManagerOn.ToString("dd MMM yy (ddd)");
                    }

                    if (qualityControl.ApprovedByClientHead == 1)
                    {
                        chkClientHead.Enabled = false;
                        lblClientHeadDate.Text = qualityControl.ApprovedByClientHeadOn.ToString("dd MMM yy (ddd)");
                    }

                    if (qualityControl.ApprovedByFactoryHead == 1)
                    {
                        chkFactoryHead.Enabled = false;
                        lblFactoryHeadDate.Text = qualityControl.ApprovedByFactoryHeadOn.ToString("dd MMM yy (ddd)");
                    }

                    if (qualityControl.ProcessingInstruction == 4)
                    {
                        txtOtherProcessingInstruction.Enabled = true;
                        txtOtherProcessingInstruction.Text = qualityControl.OtherInstruction.ToString();
                        ddlProcessingInstructions.SelectedValue = "4";
                    }
                    else
                    {
                        ddlProcessingInstructions.SelectedValue = qualityControl.ProcessingInstruction.ToString();
                        txtOtherProcessingInstruction.Enabled = false;
                    }

                    if (qualityControl.Faults == null || qualityControl.Faults.Count == 0)
                    {
                        qualityControl.Faults = new List<QualityFaults>();

                        QualityFaults faults = new QualityFaults();
                        faults.FaultDescription = "";
                        faults.FaultId = 0;
                        faults.Id = -1;
                        faults.FaultType = 3;
                        faults.Resolution = "";
                        faults.Permission = 0;
                        faults.LastResolution = "";
                        qualityControl.Faults.Add(faults);
                    }

                    if (qualityControl.Faults != null && qualityControl.Faults.Count > 0)
                    {
                        System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
                        new System.Web.Script.Serialization.JavaScriptSerializer();

                        foreach (QualityFaults qf in qualityControl.Faults)
                        {
                            if (ApplicationHelper.LoggedInUser.UserData.UserID == qf.Owner)
                                qf.Permission = 1;
                            if (!String.IsNullOrEmpty(qf.Resolution))
                            {
                                if (qf.Resolution.ToString().IndexOf("$$") > -1)
                                {
                                    qf.LastResolution = qf.Resolution.ToString().Substring(qf.Resolution.LastIndexOf("$$") + 2);
                                    qf.Resolution = qf.Resolution.ToString().Replace("$$", "<br/>").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;");
                                }
                                else
                                {
                                    qf.LastResolution = qf.Resolution.ToString();
                                    qf.Resolution = qf.Resolution.ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;");
                                }
                            }
                            else if (String.IsNullOrEmpty(qf.Resolution))
                            {
                                qf.LastResolution = String.Empty;
                                qf.Resolution = String.Empty;

                            }

                        }

                        string sJSON = oSerializer.Serialize(qualityControl.Faults);

                        PageHelper.AddJScriptVariable("faults", "{" + string.Format("table: {0}", sJSON) + "}");
                    }

                    if (qualityControl.FaultsPP != null && qualityControl.FaultsPP.Count > 0)
                    {
                        foreach (QualityFaults qfpp in qualityControl.FaultsPP)
                        {
                            if (qualityControl.Faults1 == null || qualityControl.Faults1.Count == 0)
                            {
                                qualityControl.Faults1 = new List<QualityFaults>();

                                QualityFaults faults1 = new QualityFaults();
                                faults1.FaultDescription = "";
                                faults1.FaultId = 0;
                                faults1.Id = -1;
                                faults1.Occurrence = 0;
                                faults1.FaultType = 3;
                                faults1.Resolution = "";
                                faults1.Permission = 0;
                                faults1.LastResolution = "";

                                qualityControl.Faults1.Add(faults1);
                            }
                        }
                    }

                    //System.Diagnostics.Debugger.Break();
                    if (qualityControl.FaultsPP != null && qualityControl.FaultsPP.Count > 0)
                    {
                        System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                        foreach (QualityFaults qfpp in qualityControl.FaultsPP)
                        {
                            int count = 0;
                            List<QualityFaults> newQF = new List<QualityFaults>();
                            if (qualityControl.Faults1 != null && qualityControl.Faults1.Count > 0)
                            {
                                foreach (QualityFaults qf1 in qualityControl.Faults1)
                                {
                                    if (qf1.Id > 0)
                                    {
                                        if (ApplicationHelper.LoggedInUser.UserData.UserID == qf1.Owner)
                                            qf1.Permission = 1;
                                        if (!String.IsNullOrEmpty(qf1.Resolution))
                                        {
                                            if (qf1.Resolution.ToString().IndexOf("$$") > -1)
                                            {
                                                qf1.LastResolution = qf1.Resolution.ToString().Substring(qf1.Resolution.LastIndexOf("$$") + 2);
                                                qf1.Resolution = qf1.Resolution.ToString().Replace("$$", "<br/>").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;");
                                            }
                                            else
                                            {
                                                qf1.LastResolution = qf1.Resolution.ToString();
                                                qf1.Resolution = qf1.Resolution.ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;");
                                            }
                                        }
                                        else if (String.IsNullOrEmpty(qf1.Resolution))
                                        {
                                            qf1.LastResolution = String.Empty;
                                            qf1.Resolution = String.Empty;
                                        }
                                        if (qfpp.ProductionPlanningID == qf1.ProductionPlanningID)
                                        {
                                            newQF.Add(qf1);
                                        }
                                    }
                                }
                                if (newQF.Count <= 0)
                                {
                                    QualityFaults faults1 = new QualityFaults();
                                    faults1.FaultDescription = "";
                                    faults1.FaultId = 0;
                                    faults1.Id = -1;
                                    faults1.Occurrence = 0;
                                    faults1.FaultType = 3;
                                    faults1.Resolution = "";
                                    faults1.Permission = 0;
                                    faults1.LastResolution = "";

                                    newQF.Add(faults1);
                                    count++;
                                }
                                qualityFaults.Add(newQF);
                            }
                        }

                        string sJSON = oSerializer.Serialize(qualityFaults);

                        PageHelper.RemoveJScriptVariable("qualityFault");
                        PageHelper.AddJScriptVariable("qualityFault", "{" + string.Format("table: {0}", sJSON) + "}");
                    }
                }
                else
                {
                    //PageHelper.RemoveJScriptVariable("qualityFaults");
                    if (qualityControl.FaultsPP != null && qualityControl.FaultsPP.Count > 0)
                    {
                        System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
                                      new System.Web.Script.Serialization.JavaScriptSerializer();
                        foreach (QualityFaults qfpp in qualityControl.FaultsPP)
                        {
                            qualityControl.FaultsPP = new List<QualityFaults>();

                            QualityFaults faults1 = new QualityFaults();
                            faults1.FaultDescription = "";
                            faults1.FaultId = 0;
                            faults1.Id = -1;
                            faults1.Occurrence = 0;
                            faults1.FaultType = 3;
                            faults1.Resolution = "";
                            faults1.Permission = 0;
                            faults1.LastResolution = "";

                            qualityControl.FaultsPP.Add(faults1);

                            qualityFaults.Add(qualityControl.FaultsPP);
                        }

                        string sJSON = oSerializer.Serialize(qualityFaults);
                        PageHelper.RemoveJScriptVariable("qualityFault");
                        PageHelper.AddJScriptVariable("qualityFault", "{" + string.Format("table: {0}", sJSON) + "}");
                    }
                }
            }

            else
            {
                hdnComment.Visible = false;
            }
            //lblQAManager.Text = (qualityControl.UserName == string.Empty) ? "" : "( " + qualityControl.UserName + " )";

        }

        #endregion


        protected void repeaterFaultsReporting_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}