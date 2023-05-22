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
using iKandi.Web.Components;
using iKandi.Common;
using System.Collections.Generic;



namespace iKandi.Web
{
    public partial class TopNavigation : BaseUserControl
    {
        WorkFlowPhaseCollection objWorkFlowPhaseCollection;
        Int32 repeaterPhase_RowIndex = 0;
        public static int usercount = 0;
        int iUserId = 0;

        static string IsPostBackCheck = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 13 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 4)
            {
                rblradbutton.SelectedIndex = 1;
                hdnRadioButton.Value = "1";
            }
            else
            {
                rblradbutton.SelectedIndex = 0;
                hdnRadioButton.Value = "0";
            }
            if (!IsPostBack)
            {
                //if ( ViewState["IsPostBackCheck"]==null)
                //{
                objWorkFlowPhaseCollection = ApplicationHelper.Phases;

                repeaterPhase.DataSource = objWorkFlowPhaseCollection;
                repeaterPhase.DataBind();


                ListUserTask usertasks = this.UserTaskControllerInstance.GetUserTasksCount();
                usercount = usertasks.Count;

                if (ApplicationHelper.LoggedInUser.UserData != null)

                    iUserId = ApplicationHelper.LoggedInUser.UserData.UserID;

                UserDetails usd = new UserDetails();


                SessionInfo sessionInfo = new SessionInfo();

                iKandi.Common.User user = null;

                user = this.MembershipControllerInstance.GetUser(Convert.ToInt32(iUserId));
                rptMyTask.DataSource = usertasks;
                rptMyTask.DataBind();
                DataSet ds = new DataSet();
                ApplicationHelper objApplicationHelper = new ApplicationHelper();


                //if (Session["Name"]!=null)
                //{

                //}

                //else
                //{

                ds = objApplicationHelper.GetlandingpageandDesgination(user.PrimaryGroupID, user.DesignationID, user.UserID, 1);

                HiddenField hid = new HiddenField();
                //HttpContext.Current.Session["Name"] = ds.Tables[1].Rows.Count.ToString();

                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    if (ds.Tables[1].Rows[i]["ApplicationModule"].ToString() == "Notification")
                    {
                        ntfication.Visible = true;
                    }
                    //else
                    //{
                    //    ntfication.Visible = false;
                    //}

                    if (ds.Tables[1].Rows[i]["ApplicationModule"].ToString() == "Latest Updated Style")
                    {
                        imglatestStyle.Visible = true;
                    }
                    //else
                    //{
                    //    imglatestStyle.Visible = false;
                    //}


                    if (ds.Tables[1].Rows[i]["ApplicationModule"].ToString() == "Booking Calculator")
                    {
                        imgCalCulator.Visible = true;
                    }
                    //else
                    //{
                    //    imgCalCulator.Visible = false;
                    //}

                    if (ds.Tables[1].Rows[i]["ApplicationModule"].ToString() == "Budget")
                    {
                        imgMoBudget.Visible = true;
                    }
                    else
                        //{
                        //    imgMoBudget.Visible = false;
                        //}


                        if (ds.Tables[1].Rows[i]["ApplicationModule"].ToString() == "OrderForm")
                        {
                            imgorder.Visible = true;
                        }
                        else
                            //{
                            //    imgorder.Visible = false;
                            //}

                            if (ds.Tables[1].Rows[i]["ApplicationModule"].ToString() == "Manage Order")
                            {
                                ImgMo.Visible = true;
                            }
                    //else
                    //{
                    //    ImgMo.Visible = false;
                    //}

                    if (ds.Tables[1].Rows[i]["ApplicationModule"].ToString() == "Costing")
                    {
                        imgcost.Visible = true;
                    }
                    //else
                    //{
                    //    imgcost.Visible = false;
                    //}

                    if (ds.Tables[1].Rows[i]["ApplicationModule"].ToString() == "Delay")
                    {
                        delay.Visible = true;
                    }

                    if (ds.Tables[1].Rows[i]["ApplicationModule"].ToString() == "Task Notificaton")
                    {
                        Divtasknotifaction.Visible = true;
                    }
                    if (ds.Tables[1].Rows[i]["ApplicationModule"].ToString() == "Sop")
                    {
                        soap.Visible = true;
                    }
                    //else
                    //{
                    //    delay.Visible = false;
                    //}
                }

                //repGlobal.DataSource = ds.Tables[1];
                //repGlobal.DataBind();
                //if (ds.Tables[2].Rows.Count > 0)
                //{
                //    Lblnotificationcount.Text = ds.Tables[2].Rows.Count.ToString();
                //    grdNotiFication.DataSource = ds.Tables[2];
                //    grdNotiFication.DataBind();

                //}


                if (ds.Tables[5].Rows.Count > 0)
                {
                    DataTable table;
                    table = ds.Tables[5];

                    object sumObject;
                    sumObject = table.Compute("Sum(cnt)", "");


                    repnotifaciton.DataSource = ds.Tables[5];
                    repnotifaciton.DataBind();
                    lblnotificatonctiontask.Text = sumObject.ToString();
                    if (ds.Tables[5].Rows[0]["sumTask"].ToString() == "")
                    {
                        Lblnotificationcount.Visible = false;
                        notification_count1.Attributes.Add("Style", "display:none");
                    }
                    else
                        Lblnotificationcount.Text = ds.Tables[5].Rows[0]["sumTask"].ToString();
                    grdNotiFication.DataSource = ds.Tables[2];
                    grdNotiFication.DataBind();

                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    DataTable table;
                    table = ds.Tables[3];

                    object sumObject;
                    sumObject = table.Compute("Sum(Count)", "");


                    Label2.Text = sumObject.ToString();
                    GrdDelay.DataSource = ds.Tables[3];
                    GrdDelay.DataBind();

                }

                if (ds.Tables[4].Rows.Count > 0)
                {
                    DataTable table;
                    table = ds.Tables[4];

                    object sumObject;
                    sumObject = table.Compute("Sum(cnt)", "");


                    Label3.Text = sumObject.ToString();
                    //   Grdnotificatontask.DataSource = ds.Tables[4];
                    //  Grdnotificatontask.DataBind();
                    RepTaskCompeltion.DataSource = ds.Tables[4];
                    RepTaskCompeltion.DataBind();

                }

                // end comment



                if (usertasks != null)
                {

                    long mytaskcount = (from r in usertasks select r.Task_Count).ToList().Sum();


                    //ListTeamTask listTeamTask = this.UserTaskControllerInstance.GetTeamTasksCount();
                    //rptTeamTask.DataSource = listTeamTask;
                    //rptTeamTask.DataBind();
                    ////long teamtaskcount = (from r in listTeamTask select r.Task_Count).ToList().Sum();
                    //ltTeamTask.Text = teamtaskcount.ToString();

                    // ltTotalTaskCount.Text = (mytaskcount + teamtaskcount).ToString();
                    lblcount.Text = (mytaskcount).ToString();
                    ltMyTask.Text = (mytaskcount).ToString();
                }
            }


            // }


            //    ViewState["isPostBack"] ="true";
            //}
            IsPostBackCheck = "true";

        }

        protected void repeaterPhaseItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ((Repeater)e.Item.FindControl("repeaterSubPhase")).DataSource = objWorkFlowPhaseCollection[e.Item.ItemIndex].SubPhase;
                ((Repeater)e.Item.FindControl("repeaterSubPhase")).DataBind();


                repeaterPhase_RowIndex = repeaterPhase_RowIndex + 1;
            }
        }


        protected void repGlobalItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Image img = e.Item.FindControl("img") as Image;
                String ProductionFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"];
                if (img.AlternateText == "costings.jpg")
                {
                    img.Attributes.Add("style", "display:none");
                    imgcost.ImageUrl = ProductionFolderPath + img.AlternateText;
                }
                else
                {
                    img.ImageUrl = ProductionFolderPath + img.AlternateText;
                }
                if (img.AlternateText == "calculator.jpg")
                {
                    img.Attributes.Add("style", "display:none");
                    imgCalCulator.ImageUrl = ProductionFolderPath + img.AlternateText;
                }
                else
                {
                    img.ImageUrl = ProductionFolderPath + img.AlternateText;
                }


                if (img.AlternateText == "updated-style.jpg")
                {
                    img.Attributes.Add("style", "display:none");
                    imglatestStyle.ImageUrl = ProductionFolderPath + img.AlternateText;
                }
                else
                {
                    img.ImageUrl = ProductionFolderPath + img.AlternateText;
                }

            }
        }

        protected void rptTeamTask_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            TeamTaskCount ttc = e.Item.DataItem as TeamTaskCount;
            Repeater rpt = e.Item.FindControl("rptTeamSubTask") as Repeater;
            rpt.DataSource = ttc.ListUtc;
            rpt.DataBind();
        }


        protected void repeaterSubPhaseItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                List<ApplicationModule> appList = objWorkFlowPhaseCollection[repeaterPhase_RowIndex].SubPhase[e.Item.ItemIndex].Forms.FindAll(delegate(ApplicationModule appModule) { return appModule.IncludeInNavigation; });


                ((Repeater)e.Item.FindControl("repeaterTypeForms")).DataSource = appList;
                ((Repeater)e.Item.FindControl("repeaterTypeForms")).DataBind();

                appList = objWorkFlowPhaseCollection[repeaterPhase_RowIndex].SubPhase[e.Item.ItemIndex].Files.FindAll(delegate(ApplicationModule appModule) { return appModule.IncludeInNavigation; });

                ((Repeater)e.Item.FindControl("repeaterTypeFiles")).DataSource = appList;
                ((Repeater)e.Item.FindControl("repeaterTypeFiles")).DataBind();
                //added by abhishek on 2/6/2016 if count =0 then hide admin link
                appList = objWorkFlowPhaseCollection[repeaterPhase_RowIndex].SubPhase[e.Item.ItemIndex].Admins.FindAll(delegate(ApplicationModule appModule) { return appModule.IncludeInNavigation; });
                if (appList.Count > 0)
                {
                    ((Repeater)e.Item.FindControl("repeateradmin")).DataSource = appList;
                    ((Repeater)e.Item.FindControl("repeateradmin")).DataBind();
                }
                else
                {
                    ((HtmlGenericControl)(e.Item.FindControl("DivAdmin"))).Visible = false;
                }


                appList = objWorkFlowPhaseCollection[repeaterPhase_RowIndex].SubPhase[e.Item.ItemIndex].Reports.FindAll(delegate(ApplicationModule appModule) { return appModule.IncludeInNavigation; });

                //((Repeater)e.Item.FindControl("repeaterTypeReports")).DataSource = appList;
                //((Repeater)e.Item.FindControl("repeaterTypeReports")).DataBind();

            }

        }

        protected void repeaterLinkItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ApplicationModule appModule = (e.Item.DataItem as ApplicationModule);

            HyperLink link = e.Item.FindControl("lnkMenuItem") as HyperLink;

            if (link.Text == "Bipl Export Revenue")
            {

            }

            //link.Visible = PermissionHelper.IsReadPermitted(appModule.ApplicationModuleID);

            appModule.Path = ResolveUrl("~" + appModule.Path);

            HyperLink lnkMenuItem = (HyperLink)e.Item.FindControl("lnkMenuItem");
            //Added By Abhishek on 15/6/2015
            if (lnkMenuItem.Text == "Basic" || lnkMenuItem.Text == "Fabric" || lnkMenuItem.Text == "Accessories" || lnkMenuItem.Text == "Technical")
            {
                //lnkMenuItem.Text = "Updated Word";
                lnkMenuItem.Attributes.CssStyle[HtmlTextWriterStyle.Cursor] = "default";
                // lnkMenuItem.ForeColor = System.Drawing.Color.Red;
                lnkMenuItem.Attributes["href"] = "#";
                lnkMenuItem.Style.Add("font-weight", "bold !important ");
                lnkMenuItem.Style.Add("font-size", "11px !important");
                lnkMenuItem.Style.Add("color", "#E91677 !important");

            }



        }
        // add code by bharat on 22-Sep-20
        protected void repeateradminLinkItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            HyperLink lnkMenu = (HyperLink)e.Item.FindControl("lnkMenuItem");

            if (lnkMenu.Text == "Po_Srv_Reports" || lnkMenu.Text == "Cut Issue Reports" || lnkMenu.Text == "Bipl Export Revenue " || lnkMenu.Text == "Supplier Quotation")
            {
                lnkMenu.Attributes.Add("target", "_blank");
            }

        }
        //end
        protected void grdNotiFication_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblhour = (Label)e.Row.FindControl("lblhour");


            }
        }

        protected void GrdDelay_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delay")
            {
                int StatusId = Convert.ToInt32(e.CommandArgument.ToString());



                string SessionId = Session.SessionID;

                if (ApplicationHelper.LoggedInUser.UserData != null)

                    iUserId = ApplicationHelper.LoggedInUser.UserData.UserID;

                UserDetails usd = new UserDetails();


                SessionInfo sessionInfo = new SessionInfo();
                WorkflowController objWorkflowController = new WorkflowController();
                iKandi.Common.User user = null;
                user = this.MembershipControllerInstance.GetUser(Convert.ToInt32(iUserId));
                bool flag = objWorkflowController.InsertDelayForMO(SessionId, StatusId, iUserId);
                Control ctrl = e.CommandSource as Control;



                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                HtmlAnchor anch = (HtmlAnchor)row.FindControl("anch");


                HyperLink hyp = (HyperLink)row.FindControl("hyp");

                hyp.NavigateUrl = String.Format("~/internal/OrderProcessing/frmMO.aspx?DelayStatusId={0}", StatusId);
                //    hyp.NavigateUrl = "/internal/OrderProcessing/ManageOrders.aspx?DelayStatusId=" + StatusId;
                // anch.HRef = "/internal/OrderProcessing/ManageOrders.aspx?DelayStatusId=" + StatusId;
                //anch.Target=


                //string pageurl = "/internal/OrderProcessing/ManageOrders.aspx?DelayStatusId=" + StatusId;
                //Response.Write("<script>");
                //Response.Write("window.open('" + pageurl + "','_blank')");
                //Response.Write("</script>");
                //if (ctrl != null)
                //{
                //    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                //    //LinkButton fullname = (LinkButton)row.FindControl("lbName");
                //    LinkButton ltdelay = (LinkButton)row.FindControl("ltdelay");
                //    //ltdelay.PostBackUrl = "~/Internal/OrderProcessing/ManageOrders.aspx";
                //}


            }
        }

        protected void LegacyUrl_Click(object sender, EventArgs e)
        {
            string LegacyUrl = HttpContext.Current.Request.Url.Authority;
        }

        //protected void Grdnotificatontask_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //  if (e.Row.RowType == DataControlRowType.DataRow)
        //  {
        //    HiddenField Stusname = (HiddenField)e.Row.FindControl("status_modename");
        //    HiddenField StatusModeID = (HiddenField)e.Row.FindControl("StatusModeID");
        //    HiddenField StyleNumber = (HiddenField)e.Row.FindControl("StyleNumber");
        //    HiddenField SerialNumber = (HiddenField)e.Row.FindControl("SerialNumber");

        //    HiddenField CompanyName = (HiddenField)e.Row.FindControl("CompanyName");

        //    HiddenField DepartmentName = (HiddenField)e.Row.FindControl("DepartmentName");
        //    HiddenField ContractNumber = (HiddenField)e.Row.FindControl("ContractNumber");
        //    HiddenField LineItemNumber = (HiddenField)e.Row.FindControl("LineItemNumber");
        //    Label lblhour = (Label)e.Row.FindControl("lblhour");


        //    HiddenField Quantity = (HiddenField)e.Row.FindControl("Quantity");
        //    HiddenField BIPLPrice = (HiddenField)e.Row.FindControl("BIPLPrice");
        //    HiddenField Url = (HiddenField)e.Row.FindControl("Url");
        //    HiddenField hdninr = (HiddenField)e.Row.FindControl("hdninr");



        //    Url = (HiddenField)e.Row.FindControl("Url");
        //    Label lblmsg = (Label)e.Row.FindControl("lblmsg");
        //    Image img = (Image)e.Row.FindControl("img");
        //    String ProductionFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["style.folder"];
        //    img.ImageUrl = ProductionFolderPath + Url.Value;
        //    switch ((TaskMode)Convert.ToInt32(StatusModeID.Value))
        //    {
        //      case TaskMode.COSTING_BIPL:


        //      case TaskMode.PRICE_QUOTED_BIPL:
        //      case TaskMode.COSTED_IKANDI:
        //      case TaskMode.BIPL_AGREEMENT_BIPL:
        //      case TaskMode.BIPL_AGREEMENT_Ikandi:
        //      case TaskMode.SAMPLE_SENT:
        //      case TaskMode.DIGITAL_UPLOADED:

        //        lblmsg.Text = "<b>" + Stusname.Value + "</b>" + " for " + "<b>" + StyleNumber.Value + "</b>" + " For " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>";
        //        break;

        //      case TaskMode.STYLE_CREATED:
        //        lblmsg.Text = "<b>" + Stusname.Value + "</b>" + " for " + "<b>" + StyleNumber.Value + "</b>" + " For " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>";
        //        break;

        //      case TaskMode.NEW_ORDER:
        //      case TaskMode.ORDER_CONFIRMED_SALES:
        //        lblmsg.Text = "<b>" + Stusname.Value + "</b>" + " for " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>" + " on " + "<b>" + StyleNumber.Value + "</b>" + " For" + " " + "<b>" + Quantity.Value + "</b>" + " Pcs @" + " " + "<b>" + BIPLPrice.Value + "</b>" + "for" + "<b>" + hdninr.Value + "</b>";
        //        break;

        //      case TaskMode.Create_OB:
        //      case TaskMode.Final_OB:
        //      case TaskMode.Risk:
        //      case TaskMode.Create_Fabric:
        //      case TaskMode.Fabric_Approved:
        //      case TaskMode.Create_Accessories:
        //      case TaskMode.Accessory_Approved:
        //      case TaskMode.Fill_Fabric:
        //      case TaskMode.Fill_Accessories:
        //      case TaskMode.Limitation_Fabric:


        //      case TaskMode.Limitation_Accessories:
        //      case TaskMode.STC_UNALLOCATED_Fit_Merchant:
        //      case TaskMode.STC_UNALLOCATED_Technol:
        //        // case TaskMode.ALLOCATED:
        //        lblmsg.Text = "<b>" + Stusname.Value + "</b>" + " for " + "<b>" + SerialNumber.Value + "</b>" + " " + "<b>" + StyleNumber.Value + "</b>" + " For " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>" + " " + "<b>" + Quantity.Value + "</b>" + " " + "pcs";
        //        break;

        //      case TaskMode.INLINE_CUT:
        //      case TaskMode.HO_PPM:
        //      case TaskMode.Cutting:
        //      case TaskMode.Stitching:
        //      case TaskMode.Finishing:
        //        lblmsg.Text = "<b>" + Stusname.Value + "</b>" + " for " + "<b>" + SerialNumber.Value + "</b>" + " " + "<b>" + StyleNumber.Value + "</b>" + " For " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>" + " " + "<b>" + Quantity.Value + "</b>" + " " + "pcs";
        //        break;

        //      case TaskMode.EXFACTORY_PLANNED:
        //      case TaskMode.Approved_To_EX_Approval_QA:
        //      case TaskMode.Approved_To_EX_CLT_QA_Pending:
        //      case TaskMode.Approved_To_EX_Fact_QA_Pending:
        //      case TaskMode.Approved_To_EX_Shipping:
        //      case TaskMode.PART_EX_FACTORIED:
        //      case TaskMode.UNDER_CLEARENCE_HANGING:
        //      case TaskMode.UNDER_CLEARANCE_FLAT:
        //      case TaskMode.PROCESSING:
        //      case TaskMode.DELIVERED:
        //      case TaskMode.BIPL_INVOICED:
        //      case TaskMode.iKandi_Invoiced:
        //        //case TaskMode.CANCELLED:
        //        //case TaskMode.ONHOLD:

        //        lblmsg.Text = "<b>" + Stusname.Value + "</b>" + " for " + "<b>" + SerialNumber.Value + "</b>" + " " + "<b>" + StyleNumber.Value + "</b>" + " For " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>" + "  On " + "<b>" + ContractNumber.Value + "/ " + LineItemNumber.Value + " " + Quantity.Value + " " + "</b>" + "pcs";
        //        break;
        //      //Case.TaskMode.STYLE_CREATED:
        //      //{


        //      //break;
        //      //}
        //      default:
        //        lblmsg.Text = "<b>" + Stusname.Value + "</b>" + " for " + "<b>" + SerialNumber.Value + "</b>" + " " + "<b>" + StyleNumber.Value + "</b>" + " For " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>" + "  On " + "<b>" + ContractNumber.Value + "/ " + LineItemNumber.Value + " " + Quantity.Value + " " + "</b>" + "pcs";
        //        lblhour.Visible = true;
        //        img.Visible = true;
        //        break;


        //    }


        //  }




        //}
    }





}
