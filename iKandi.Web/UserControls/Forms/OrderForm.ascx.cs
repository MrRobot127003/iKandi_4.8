using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Linq;


namespace iKandi.Web
{
    public partial class OrderForm : BaseUserControl
    {
        string Status = string.Empty;
        #region Properties

        public int OrderID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["orderid"]))
                {
                    return Convert.ToInt32(Request.QueryString["orderid"]);
                }

                return -1;
            }
        }

        #endregion

        #region Event Handlers

        protected bool bChechFirstPage;
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnuserid.Value = Convert.ToString(ApplicationHelper.LoggedInUser.UserData.UserID);
            string squerystring = Request.QueryString["orderid"];
            if (squerystring == null)
            {
                bChechFirstPage = true;
            }
            else
            {
                bChechFirstPage = false;
            }

            ddlDeliveryMode.DataSource = iKandi.BLL.CommonHelper.GetDeliveryModes(true);
            ddlDeliveryMode.DataBind();

            Page.Form.Enctype = "multipart/form-data";
            if (!IsPostBack)
            {
                BindControls();
                PopulateOrderData();
                //var vv = iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_ORDER_DATE) ? "date-picker date_style" : " date_style do-not-allow-typing";

            }

           // hypGetEXFactoryReport.Visible = PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.ORDER_FORM_LINK_EXFACTORYQUANTITYREPORT) ? true : false;
            if (Status == "0")
            {
                btnSubmit.Visible = false;
                btnsentProposal.Visible = false;
                if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Sales_Manager || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_Manager || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_AccountManager)
                {
                    btnAgree.Visible = true;
                    btnDisagree.Visible = true;
                    lblText.Visible = false;
                }
                else
                {
                    lblText.Visible = true;
                    btnAgree.Visible = false;
                    btnDisagree.Visible = false;
                }
            }

            if (Status != "0")
            {
                btnsentProposal.Visible = !(btnSubmit.Visible);
            }
            btnSave.Visible = !(btnSubmit.Visible);


            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_FitMerchant)
            {
                btnSave.Visible = true;
            }
            //changes to be done
            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_Manager || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Sales_Manager || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_SalesManager || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_Manager)
            {
                btnSave.Visible = false;
            }
        }

        public string[] RemoveDuplicates(string[] s)
        {
            HashSet<string> set = new HashSet<string>(s);
            string[] result = new string[set.Count];
            set.CopyTo(result);
            return result;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool bcheck = false;
            bool bCheckUpdate = false;
            //if (!Page.IsValid)
            //    return;
            SaveOrder(1, "O", ref bcheck, ref bCheckUpdate);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/internal/Sales/Order.aspx?orderid=" + OrderID);
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {//manisha on 28th march
            bool Bcheck = false;
            bool bCheckUpdate = false;
            if (!Page.IsValid)
                return;
            SaveOrder(1, "B", ref Bcheck, ref bCheckUpdate);
        }

        protected void btnDisagree_Click(object sender, EventArgs e)
        {//manisha on 28th march
            bool BcheckDis = false;
            bool bCheckUpdate = false;
            if (!Page.IsValid)
                return;
            SaveOrder(2, "B", ref BcheckDis, ref bCheckUpdate);
        }

        protected void btnsentProposal_Click(object sender, EventArgs e)
        {
            iKandi.Common.Order order = new iKandi.Common.Order();
            OrderDetail orderDetail = new OrderDetail();
            order.OrderID = this.OrderID;
            order.Style = new iKandi.Common.Style();
            order.Style.client = new Client();
            order.Style.cdept = new ClientDepartment();
            order.Costing = new Costing();
            order.IsApproved = 0;//manisha on 28th march
            order.OrderType = "I";//manisha on 28th march

            if (!string.IsNullOrEmpty(txtStyleNumber.Text))
            {
                if (hdnStyleID.Value == "")
                {
                    hdnStyleID.Value = Convert.ToString(this.OrderControllerInstance.GetStyleIdByStyleNumber(txtStyleNumber.Text));
                }
                order.Style.StyleID = Convert.ToInt32(hdnStyleID.Value);
                order.Style.StyleNumber = txtStyleNumber.Text;
            }
            if (txtTotalQty.Text.IndexOf(',') > -1)
            {
                order.TotalQuantity = Convert.ToInt32(txtTotalQty.Text.Replace(",", ""));
            }
            else
            {
                order.TotalQuantity = Convert.ToInt32(txtTotalQty.Text);
            }
            //order.CDQDA = Convert.ToInt32(acvb.SelectedValue);
            order.Style.client.CompanyName = "";
            order.Style.cdept.Name = "";

            if (!string.IsNullOrEmpty(ddlClient.SelectedValue))
            {
                order.Style.client.ClientID = Convert.ToInt32(Request.Params[ddlClient.UniqueID]);
                order.Style.client.CompanyName = hdnSelectedClient.Value;
            }

            if (!string.IsNullOrEmpty(Request.Params[ddlParentDept.UniqueID]))
            {
                order.Costing.ParentDepartmentID = Convert.ToInt32(Request.Params[ddlParentDept.UniqueID]);
                order.Costing.ParentDepartment = hdnSelectedParentDept.Value;
            }

            if (!string.IsNullOrEmpty(Request.Params[ddlDepartment.UniqueID]))
            {
                order.Style.cdept.DeptID = Convert.ToInt32(Request.Params[ddlDepartment.UniqueID]);
                order.Style.cdept.Name = hdnSelectedDept.Value;
            }
            else
            {
                order.Style.cdept.DeptID = Convert.ToInt32(hdnDeptID.Value);
            }
            if (!string.IsNullOrEmpty(txtOrderDate.Text))
                order.OrderDate = DateHelper.ParseDate(txtOrderDate.Text).Value;

            if (!string.IsNullOrEmpty(txtIkandiSerial.Text))
                order.SerialNumber = txtIkandiSerial.Text;

            if (!string.IsNullOrEmpty(txtDescription.Text))
                order.Description = txtDescription.Text;

            if (!string.IsNullOrEmpty(txtBIPLPrice.Text))
            {
                order.BiplPrice = Convert.ToDouble(txtBIPLPrice.Text);
                order.Costing.AgreedPrice = Convert.ToDouble(txtBIPLPrice.Text);
            }

            if (!string.IsNullOrEmpty(txtComments1.Value))
            {
                order.Comments = txtComments1.Value;
            }

            order.ApprovedByMerchandiserManager = Convert.ToInt32(Convert.ToBoolean(checkBoxMerchandisingMgr.Checked));
            order.ApprovedBySalesBIPL = Convert.ToInt32(Convert.ToBoolean(checkBoxSalesMgrBIPL.Checked));

            order.Costing.CostingID = Convert.ToInt32(hdnCostingId.Value);

            order.OrderBreakdown = new System.Collections.Generic.List<OrderDetail>();

            int i = 1;
            while (!string.IsNullOrEmpty(Request.Params["txtQty" + i.ToString()]))
            {

                //Added By Ashish on 28/10/2014
                // orderDetail.SizeOption =Convert.ToInt32(Request.Params["Option_" + i.ToString()]);
                if (!string.IsNullOrEmpty(Request.Params["Option_" + i.ToString()]))
                {
                    orderDetail.SizeOption = Convert.ToInt32(Request.Params["Option_" + i.ToString()]);
                }

                orderDetail.LineItemNumber = Request.Params["txtLineItemNumber" + i.ToString()];
                //END
                orderDetail.ContractNumber = Request.Params["txtContractNumber" + i.ToString()];

                if (!string.IsNullOrEmpty(Request.Params["txtUploadFilea" + i.ToString()]))
                {
                    orderDetail.File1 = Request.Params["txtUploadFilea" + i.ToString()];
                }

                if (!string.IsNullOrEmpty(Request.Params["txtUploadFileb" + i.ToString()]))
                {
                    orderDetail.File2 = Request.Params["txtUploadFileb" + i.ToString()];
                }

                if (!string.IsNullOrEmpty(Request.Params["txtUploadFilec" + i.ToString()]))
                {
                    orderDetail.File3 = Request.Params["txtUploadFilec" + i.ToString()];
                }

                if (!string.IsNullOrEmpty(Request.Params["txtUploadFiled" + i.ToString()]))
                {
                    orderDetail.File4 = Request.Params["txtUploadFiled" + i.ToString()];
                }

                orderDetail.Fabric1 = Request.Params["txtFabrica" + i.ToString()];       

                orderDetail.Fabric1Details = Request.Params["txtFabric12" + i.ToString()];
                if (orderDetail.Fabric1Details.IndexOf("PRD:") > -1 || orderDetail.Fabric1Details.IndexOf("prd") > -1)
                {
                    string[] fab1 = orderDetail.Fabric1Details.Split('(');
                    orderDetail.Fabric1Details = fab1[0].Replace("PRD:", "");
                    orderDetail.Fabric1Details = orderDetail.Fabric1Details.Replace("prd:", "");
                }        

                orderDetail.Fabric2 = Request.Params["txtFabricb" + i.ToString()];       

                orderDetail.Fabric2Details = Request.Params["txtFabric22" + i.ToString()];
                if (orderDetail.Fabric2Details.IndexOf("PRD:") > -1 || orderDetail.Fabric2Details.IndexOf("prd") > -1)
                {
                    string[] fab2 = orderDetail.Fabric2Details.Split('(');
                    orderDetail.Fabric2Details = fab2[0].Replace("PRD:", "");
                    orderDetail.Fabric2Details = orderDetail.Fabric2Details.Replace("prd:", "");
                }
  
                orderDetail.Fabric3 = Request.Params["txtFabricc" + i.ToString()];

                orderDetail.Fabric3Details = Request.Params["txtFabric32" + i.ToString()];
                if (orderDetail.Fabric3Details.IndexOf("PRD:") > -1 || orderDetail.Fabric3Details.IndexOf("prd") > -1)
                {
                    string[] fab3 = orderDetail.Fabric3Details.Split('(');
                    orderDetail.Fabric3Details = fab3[0].Replace("PRD:", "");
                    orderDetail.Fabric3Details = orderDetail.Fabric3Details.Replace("prd:", "");
                }

                orderDetail.Fabric4 = Request.Params["txtFabricd" + i.ToString()];
               
                orderDetail.Fabric4Details = Request.Params["txtFabric42" + i.ToString()];
                if (orderDetail.Fabric4Details.IndexOf("PRD:") > -1 || orderDetail.Fabric4Details.IndexOf("prd") > -1)
                {
                    string[] fab4 = orderDetail.Fabric4Details.Split('(');
                    orderDetail.Fabric4Details = fab4[0].Replace("PRD:", "");
                    orderDetail.Fabric4Details = orderDetail.Fabric4Details.Replace("prd:", "");
                }
               
                orderDetail.Quantity = Convert.ToInt32(Request.Params["txtQty" + i.ToString()]);
                orderDetail.Mode = Convert.ToInt32(Request.Params["ddlMode" + i.ToString()]);
                orderDetail.ModeName = Request.Params["hdnMode" + i.ToString()];

                orderDetail.iKandiPrice = Convert.ToDouble(Request.Params["txtIkandiPrice" + i.ToString()]);
                orderDetail.ExFactory = DateHelper.ParseDate(Request.Params["txtExFactory" + i.ToString()]).Value;
                orderDetail.WeekToEx = Convert.ToInt32(Request.Params["txtWeeksToEx" + i.ToString()]);
                orderDetail.DC = DateHelper.ParseDate(Request.Params["txtDC" + i.ToString()]).Value; ;
                orderDetail.WeeksToDC = Convert.ToInt32(Request.Params["txtWeeksToDC" + i.ToString()]);

                if (!string.IsNullOrEmpty(Request.Params["txtOrderDetailID" + i.ToString()]))
                {
                    orderDetail.OrderDetailID = Convert.ToInt32(Request.Params["txtOrderDetailID" + i.ToString()]);
                }
                else
                {
                    orderDetail.OrderDetailID = -1;
                }                

                if (Request.Files != null && Request.Files.Count > 0)
                {
                    for (int j = 0; j < Request.Files.Count; j++)
                    {
                        string filetype = Request.Files.Keys[j].Substring(13, 1);
                        if (Request.Files.Keys[j].Contains(i.ToString()))
                        {
                            if (Request.Files[j] != null && Request.Files[j].FileName != "")
                            {
                                string OriginalfileName = Request.Files[j].FileName;
                                string filePath = "";
                                if (OriginalfileName.LastIndexOf("\\") > -1)
                                {
                                    filePath = OriginalfileName.Substring(0, (OriginalfileName.LastIndexOf("\\") + 1));
                                    OriginalfileName = OriginalfileName.Replace(filePath, "");
                                }
                                string ext = OriginalfileName.Substring(OriginalfileName.LastIndexOf("."));
                                OriginalfileName = OriginalfileName.Replace(ext, "");
                                string fileName = FileHelper.SaveFile(Request.Files[j].InputStream, Request.Files[j].FileName, Constants.ORDER_FOLDER_PATH, true, OriginalfileName);

                                if (filetype == "a")
                                {
                                    orderDetail.File = fileName.Trim();
                                    orderDetail.File1 = fileName.Trim();
                                }
                                if (filetype == "b")
                                    orderDetail.File2 = fileName.Trim();
                                if (filetype == "c")
                                    orderDetail.File3 = fileName.Trim();
                                if (filetype == "d")
                                    orderDetail.File4 = fileName.Trim();
                            }
                            else
                            {
                                if (filetype == "a")
                                {
                                    orderDetail.File = Request.Params["hdnFilea" + i.ToString()];
                                    orderDetail.File1 = Request.Params["hdnFilea" + i.ToString()];
                                }
                                if (filetype == "b")
                                    orderDetail.File2 = Request.Params["hdnFileb" + i.ToString()];
                                if (filetype == "c")
                                    orderDetail.File3 = Request.Params["hdnFilec" + i.ToString()];
                                if (filetype == "d")
                                    orderDetail.File4 = Request.Params["hdnFiled" + i.ToString()];
                            }
                        }
                    }

                }
                else
                {
                    orderDetail.File = Request.Params["hdnFilea" + i.ToString()];
                    orderDetail.File1 = Request.Params["hdnFilea" + i.ToString()];
                    orderDetail.File2 = Request.Params["hdnFileb" + i.ToString()];
                    orderDetail.File3 = Request.Params["hdnFilec" + i.ToString()];
                    orderDetail.File4 = Request.Params["hdnFiled" + i.ToString()];
                }

                order.OrderBreakdown.Add(orderDetail);

                i++;
            }


            //bool sucess = this.OrderControllerInstance.AddOrder(order, ApplicationHelper.LoggedInUser.UserData.UserID);//manisha 28th March
            int a;
            string differences = this.ShowDifferences(order, "proposed", out a);
            bool boolenaDiff = false;
            bool bCheckUpdate = false;
            if (a > 0)
            {
                //order.History = differences;
                SaveOrder(0, "I", ref boolenaDiff, ref bCheckUpdate);
            }
            else
            {
                SaveOrder(1, "O", ref boolenaDiff, ref bCheckUpdate);
            }


            if (differences.IndexOf("$$") > -1)
            {
                differences = differences.Replace("$$", "<br/>");
                differences = differences.Replace("<br/><br/>", "<br/>");
                List<string> AttachmentsList = new List<string>();
                //Gajendra Email Notification
                NotificationEmailHistory NEH = new NotificationEmailHistory();
                NEH.Type = "5";
                NEH.EmailID = "7";
                NEH.OrderDetailsID = orderDetail.OrderDetailID.ToString();
                NEH.OrderID = order.OrderID.ToString();
                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                //this.NotificationControllerInstance.SendEmailForEditOrder(differences, order.SerialNumber, AttachmentsList, order.Style.client.ClientID, true, 2, "");
            }

            pnlForm.Visible = false;
            pnlMessage1.Visible = true;
        }

        #endregion

        #region Private Method

        private void BindControls()
        {
            txtOrderDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
            DropdownHelper.BindAllClients(ddlClient as ListControl);
            hdnExpectedDate.Value = DateHelper.GetNextMondayDate().ToString();
            txtOrderDate.DataBind();
            txtStyleNumber.DataBind();
            txtDescription.DataBind();
            ddlClient.DataBind();
            txtBIPLPrice.DataBind();
            btnsentProposal.DataBind();
            ddlordrType.DataBind();
            txtkusakprice.DataBind();
            DropdownHelper.BindAllOrderTypeOfPacking(ddlTypeOfPacking as ListControl);
        }

        private string GetMessage(int orderID)
        {
            string ErrorMessage = Convert.ToString(this.OrderControllerInstance.GetMessage(orderID));
            return ErrorMessage;
        }

        private void SaveOrder(int type, string owner, ref bool bCheckOrderSAM, ref bool bCheckUpdate)  //type--> Status of order in duplicate table(is approved), owner--> O=original, I=Ikandi, B=Boutique
        {
            bool IsIkandiCommentInserted = false;
            string differences = "";
            iKandi.Common.Order order = new iKandi.Common.Order();
            order.OrderID = this.OrderID;
            order.Style = new iKandi.Common.Style();
            order.Style.client = new Client();
            order.Style.cdept = new ClientDepartment();
            order.Costing = new Costing();
            order.OrderType = owner;
            order.IsApproved = type;

            if (!string.IsNullOrEmpty(txtStyleNumber.Text))
            {
                if ((hdnStyleID.Value == "") || (hdnStyleID.Value == "0"))
                {
                    hdnStyleID.Value = Convert.ToString(this.OrderControllerInstance.GetStyleIdByStyleNumber(txtStyleNumber.Text));
                }
                order.Style.StyleID = Convert.ToInt32(hdnStyleID.Value);
            }
            order.Style.StyleNumber = txtStyleNumber.Text;

            if (txtTotalQty.Text.IndexOf(',') > -1)
            {
                order.TotalQuantity = Convert.ToInt32(txtTotalQty.Text.Replace(",", ""));
            }
            else
            {
                order.TotalQuantity = Convert.ToInt32(txtTotalQty.Text);
            }
            //order.CDQDA = Convert.ToInt32(acvb.SelectedValue);
            order.Style.client.CompanyName = "";
            order.Style.cdept.Name = "";

            if (!string.IsNullOrEmpty(ddlClient.SelectedValue))
            {
                order.Style.client.ClientID = Convert.ToInt32(Request.Params[ddlClient.UniqueID]);
                order.Style.client.CompanyName = hdnSelectedClient.Value;
            }

            if (!string.IsNullOrEmpty(Request.Params[ddlParentDept.UniqueID]))
            {
                order.Costing.ParentDepartmentID = Convert.ToInt32(Request.Params[ddlParentDept.UniqueID]);
                order.Costing.ParentDepartment = hdnSelectedParentDept.Value;                
            }
            //else
            //{
            //    if (Convert.ToInt32(Request.Params[ddlParentDept.UniqueID]) == 0)
            //    {
            //        order.Style.cdept.DeptID = Convert.ToInt32(hdnDeptID.Value);
            //    }
            //}

            if (!string.IsNullOrEmpty(Request.Params[ddlDepartment.UniqueID]))
            {
                order.Style.cdept.DeptID = Convert.ToInt32(Request.Params[ddlDepartment.UniqueID]);
                order.Style.cdept.Name = hdnSelectedDept.Value;
            }
            else
            {
                if (Convert.ToInt32(Request.Params[ddlDepartment.UniqueID]) == 0)
                {
                    order.Style.cdept.DeptID = Convert.ToInt32(hdnDeptID.Value);
                }
            }

            order.TypeOfPacking = Convert.ToInt32(ddlTypeOfPacking.SelectedValue);

            if (!string.IsNullOrEmpty(txtOrderDate.Text))
                order.OrderDate = DateHelper.ParseDate(txtOrderDate.Text).Value;

            if (!string.IsNullOrEmpty(txtIkandiSerial.Text))
                order.SerialNumber = txtIkandiSerial.Text;

            if (!string.IsNullOrEmpty(txtDescription.Text))
                order.Description = txtDescription.Text;

            if (!string.IsNullOrEmpty(txtBIPLPrice.Text))
            {
                order.BiplPrice = Convert.ToDouble(txtBIPLPrice.Text);
                order.Costing.AgreedPrice = Convert.ToDouble(txtBIPLPrice.Text);
            }

            //abhishek 
            order.OrderTypes = Convert.ToInt32(ddlordrType.SelectedValue);
            if (!string.IsNullOrEmpty(txtkusakprice.Text))
                order.OutHousePrice = Convert.ToDouble(txtkusakprice.Text);
            //end
            if (!string.IsNullOrEmpty(txtComments1.Value))
            {
                order.Comments = ApplicationHelper.LoggedInUser.UserData.FirstName + " ( " + DateTime.Today.ToString("dd MMM") + ") :" + txtComments1.Value;
                IsIkandiCommentInserted = true;
            }

            order.Costing.CostingID = Convert.ToInt32(hdnCostingId.Value);

            order.ApprovedBySalesIkandi = 1;
            order.ApprovedByMerchandiserManager = Convert.ToInt32(Convert.ToBoolean(checkBoxMerchandisingMgr.Checked));
            order.ApprovedBySalesBIPL = Convert.ToInt32(Convert.ToBoolean(checkBoxSalesMgrBIPL.Checked));
            //Edit By Prabhaker 19-jun-18
            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_AccountManager)
            {
                if ((checkBoxMerchandisingMgr.Checked) == true)
                {
                    order.ApprovedByMerchandiserManagerOn = DateTime.Now;
                }
            }
            //end
            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Sales_Manager)
            {
                if ((checkBoxSalesMgrBIPL.Checked) == true)
                {
                    order.ApprovedBySalesBIPLOn = DateTime.Now;
                }
            }

            if (!string.IsNullOrEmpty(txtDeliverTo.Text))
                order.InvoiceLocation = txtDeliverTo.Text;

            order.OrderBreakdown = new System.Collections.Generic.List<OrderDetail>();

            int i = 1;

            string bulkEtaChangeHistory = string.Empty;

            while (!string.IsNullOrEmpty(Request.Params["txtQty" + i.ToString()]))
            {
                OrderDetail orderDetail = new OrderDetail();
                if (!string.IsNullOrEmpty(Request.Params["Option_" + i.ToString()]))
                {
                    orderDetail.SizeOption = Convert.ToInt32(Request.Params["Option_" + i.ToString()]);
                }
                orderDetail.LineItemNumber = Request.Params["txtLineItemNumber" + i.ToString()];

                orderDetail.ContractNumber = Request.Params["txtContractNumber" + i.ToString()];

                if (!string.IsNullOrEmpty(Request.Params["txtUploadFilea" + i.ToString()]))
                {
                    //orderDetail.File1 = txtIkandiSerial.Text.Replace(" ","_") + "-" + Request.Params["txtQty" + i.ToString()].ToString() + "-a-" + Request.Params["txtUploadFilea" + i.ToString()];
                    orderDetail.File1 = txtIkandiSerial.Text.Replace(" ", "_") + "-" + i.ToString() + "1-" + Request.Params["txtQty" + i.ToString()].ToString() + "-" + Request.Params["txtUploadFilea" + i.ToString()];
                }

                if (!string.IsNullOrEmpty(Request.Params["txtUploadFileb" + i.ToString()]))
                {
                    orderDetail.File2 = txtIkandiSerial.Text.Replace(" ", "_") + "-" + i.ToString() + "2-" + Request.Params["txtQty" + i.ToString()].ToString() + "-" + Request.Params["txtUploadFileb" + i.ToString()];
                }

                if (!string.IsNullOrEmpty(Request.Params["txtUploadFilec" + i.ToString()]))
                {
                    orderDetail.File3 = txtIkandiSerial.Text.Replace(" ", "_") + "-" + i.ToString() + "3-" + Request.Params["txtQty" + i.ToString()].ToString() + "-" + Request.Params["txtUploadFilec" + i.ToString()];
                }

                if (!string.IsNullOrEmpty(Request.Params["txtUploadFiled" + i.ToString()]))
                {
                    orderDetail.File4 = txtIkandiSerial.Text.Replace(" ", "_") + "-" + i.ToString() + "4-" + Request.Params["txtQty" + i.ToString()].ToString() + "-" + Request.Params["txtUploadFiled" + i.ToString()];
                }

                orderDetail.Fabric1 = Request.Params["txtFabrica" + i.ToString()].Trim();
                if (orderDetail.Fabric1.IndexOf("Fabric") > -1)
                {
                    orderDetail.Fabric1 = string.Empty;
                }

                orderDetail.Fabric1Details = Request.Params["txtFabric12" + i.ToString()];
                if (orderDetail.Fabric1Details.IndexOf("PRD:") > -1 || orderDetail.Fabric1Details.IndexOf("prd") > -1)
                {
                    string[] fab1 = orderDetail.Fabric1Details.Split('(');
                    orderDetail.Fabric1Details = fab1[0].Replace("PRD:", "").Trim();
                    orderDetail.Fabric1Details = orderDetail.Fabric1Details.Replace("prd:", "").Trim();
                }
                //if (orderDetail.Fabric1Details.IndexOf("prd") > -1)
                //{
                //    //orderDetail.Fabric1Details = orderDetail.Fabric1Details.Replace("prd", "");
                //    string[] fab1 = orderDetail.Fabric1Details.Split('(');
                //    orderDetail.Fabric1Details = fab1[0].Replace("prd:", "");
                //}
                //if (orderDetail.Fabric1Details.IndexOf("Color") > -1)
                //{
                //    orderDetail.Fabric1Details = string.Empty;
                //}

                orderDetail.Fabric2 = Request.Params["txtFabricb" + i.ToString()].Trim();
                if (orderDetail.Fabric2.IndexOf("Fabric") > -1)
                {
                    orderDetail.Fabric2 = string.Empty;
                }

                orderDetail.Fabric2Details = Request.Params["txtFabric22" + i.ToString()];
                if (orderDetail.Fabric2Details.IndexOf("PRD:") > -1 || orderDetail.Fabric2Details.IndexOf("prd") > -1)
                {
                    string[] fab2 = orderDetail.Fabric2Details.Split('(');                   
                    orderDetail.Fabric2Details = fab2[0].Replace("PRD:", "").Trim();                   
                    orderDetail.Fabric2Details = orderDetail.Fabric2Details.Replace("prd:", "").Trim();
                }
               
                orderDetail.Fabric3 = Request.Params["txtFabricc" + i.ToString()].Trim();

                if (orderDetail.Fabric3.IndexOf("Fabric") > -1)
                {
                    orderDetail.Fabric3 = string.Empty;

                }
                orderDetail.Fabric3Details = Request.Params["txtFabric32" + i.ToString()];
                if (orderDetail.Fabric3Details.IndexOf("PRD:") > -1 || orderDetail.Fabric3Details.IndexOf("prd") > -1)
                {
                    string[] fab3 = orderDetail.Fabric3Details.Split('(');
                    orderDetail.Fabric3Details = fab3[0].Replace("PRD:", "").Trim();
                    orderDetail.Fabric3Details = orderDetail.Fabric3Details.Replace("prd:", "").Trim();
                }                
                orderDetail.Fabric4 = Request.Params["txtFabricd" + i.ToString()].Trim();
                if (orderDetail.Fabric4.IndexOf("Fabric") > -1)
                {
                    orderDetail.Fabric4 = string.Empty;

                }
                orderDetail.Fabric4Details = Request.Params["txtFabric42" + i.ToString()];
                if (orderDetail.Fabric4Details.IndexOf("PRD:") > -1 || orderDetail.Fabric4Details.IndexOf("prd:") > -1)
                {
                    string[] fab4 = orderDetail.Fabric4Details.Split('(');
                    orderDetail.Fabric4Details = fab4[0].Replace("PRD:", "").Trim();
                    orderDetail.Fabric4Details = orderDetail.Fabric4Details.Replace("prd:", "").Trim();
                }               

                if (!string.IsNullOrEmpty(Request.Params["txtQty" + i.ToString()]))
                {
                    orderDetail.Quantity = Convert.ToInt32(Request.Params["txtQty" + i.ToString()]);
                }

                if (!string.IsNullOrEmpty(Request.Params["hdnSortType" + i.ToString()]))
                {
                    orderDetail.sortType = Convert.ToString(Request.Params["hdnSortType" + i.ToString()]);
                }

                if (!string.IsNullOrEmpty(Request.Params["ddlMode" + i.ToString()]))
                {
                    orderDetail.Mode = Convert.ToInt32(Request.Params["ddlMode" + i.ToString()]);
                }
                else
                {
                    orderDetail.Mode = Convert.ToInt32(Request.Params["ddlMode" + i.ToString()]);
                }

                if (!string.IsNullOrEmpty(Request.Params["hdnMode" + i.ToString()]))
                {
                    orderDetail.ModeName = Request.Params["hdnMode" + i.ToString()];
                }                
                if (!string.IsNullOrEmpty(Request.Params["txtIsSplit" + i.ToString()]))
                {
                    orderDetail.isSplit = Convert.ToInt32(Request.Params["txtIsSplit" + i.ToString()]);
                }

                if (!string.IsNullOrEmpty(Request.Params["txtIsSplitted" + i.ToString()]))
                {
                    orderDetail.isSplitted = Convert.ToInt32(Request.Params["txtIsSplitted" + i.ToString()]);
                }

                if (!string.IsNullOrEmpty(Request.Params["txtIsQuantityInc" + i.ToString()]))
                {
                    orderDetail.isQuantityInc = Convert.ToInt32(Request.Params["txtIsQuantityInc" + i.ToString()]);
                }

                if (!string.IsNullOrEmpty(Request.Params["hdnParentOrderDetailID" + i.ToString()]))
                {
                    orderDetail.parentOrderDetailID = Convert.ToInt32(Request.Params["hdnParentOrderDetailID" + i.ToString()]);
                }

                //Edit by ashish on 2/4/2013
                if (!string.IsNullOrEmpty(Request.Params["txtIkandiPrice" + i.ToString()]))
                {
                    orderDetail.iKandiPrice = Convert.ToDouble(Request.Params["txtIkandiPrice" + i.ToString()]);
                }

                //End
                //Added by Ravi kumar on 30-3-18 for BIPL price contract wise
                if ((!string.IsNullOrEmpty(Request.Params["txtodBIPLPrice" + i.ToString()])) && (!string.IsNullOrEmpty(Request.Params["hdnOdBIPLPrice" + i.ToString()])))
                {
                    if ((Convert.ToDouble(Request.Params["txtodBIPLPrice" + i.ToString()]) == Convert.ToDouble(Request.Params["hdnOdBIPLPrice" + i.ToString()])))
                        orderDetail.odBIPLPrice = Convert.ToDouble(Request.Params["txtodBIPLPrice" + i.ToString()]);
                }
                else
                {
                    if (!string.IsNullOrEmpty(Request.Params["txtodBIPLPrice" + i.ToString()]))
                    {
                        orderDetail.odBIPLPrice = Convert.ToDouble(Request.Params["txtodBIPLPrice" + i.ToString()]);
                    }
                }
                //End adding
                if (!string.IsNullOrEmpty(Request.Params["txtExFactory" + i.ToString()]))
                {
                    orderDetail.ExFactory = DateHelper.ParseDate(Request.Params["txtExFactory" + i.ToString()]).Value;
                }
                if (!string.IsNullOrEmpty(Request.Params["txtWeeksToEx" + i.ToString()]))
                {
                    orderDetail.WeekToEx = Convert.ToInt32(Request.Params["txtWeeksToEx" + i.ToString()]);
                }
                orderDetail.DC = DateHelper.ParseDate(Request.Params["txtDC" + i.ToString()]).Value; ;
                if (!string.IsNullOrEmpty(Request.Params["txtWeeksToDC" + i.ToString()]))
                {
                    orderDetail.WeeksToDC = Convert.ToInt32(Request.Params["txtWeeksToDC" + i.ToString()]);
                }
                if (!string.IsNullOrEmpty(Request.Params["txtIsDeleted" + i.ToString()]))
                {
                    orderDetail.isDeleted = Convert.ToInt32(Request.Params["txtIsDeleted" + i.ToString()]);
                }
                if (!string.IsNullOrEmpty(Request.Params["txtOrderDetailID" + i.ToString()]))
                {
                    orderDetail.OrderDetailID = Convert.ToInt32(Request.Params["txtOrderDetailID" + i.ToString()]);
                }
                else
                {
                    orderDetail.OrderDetailID = -1;
                }
                if (!string.IsNullOrEmpty(Request.Params["hdnMode" + i.ToString()]))
                {
                    orderDetail.hdnMode = Request.Params["hdnMode" + i.ToString()];
                }

                if (!string.IsNullOrEmpty(hdnCostingId.Value))
                {
                    orderDetail.hdnCostingId = Convert.ToInt32(hdnCostingId.Value);
                }

                //Date Calculations

                DateTime OrderDate = order.OrderDate;
                DateTime ExFactoryDate = orderDetail.ExFactory;

                int days = ((ExFactoryDate - OrderDate).Days) / 2;

                DateTime newDate1 = ExFactoryDate.AddDays(-35);
                DateTime newDate2 = ExFactoryDate.AddDays(-days);

                if (DateTime.Compare(newDate2, newDate1) > 0)
                {
                    orderDetail.STCUnallocated = newDate1;
                }
                else if (DateTime.Compare(newDate2, newDate1) < 0)
                {
                    orderDetail.STCUnallocated = newDate2;
                }
                else if (DateTime.Compare(newDate2, newDate1) == 0)
                {
                    orderDetail.STCUnallocated = newDate1;
                }

                orderDetail.STCAllocated = orderDetail.STCUnallocated.AddDays(3);
                //orderDetail.InlineCut = orderDetail.ExFactory.AddDays(-25);
                orderDetail.CuttingETA = orderDetail.ExFactory.AddDays(-20);
                orderDetail.StitchingETA = orderDetail.ExFactory.AddDays(-14);
                orderDetail.PackingETA = orderDetail.ExFactory.AddDays(-7);
                //orderDetail.ExFactoryPlanned = orderDetail.ExFactory.AddDays(-3);
                //orderDetail.ApprovedToExFactory = orderDetail.ExFactory.AddDays(-1);

                DateTime OldExfactory = DateHelper.ParseDate(Request.Params["hdnExFactory" + i.ToString()]).Value;
                DateTime ExistingBulkInHouse = DateHelper.ParseDate(Request.Params["hdnBulk" + i.ToString()]).Value;
                DateTime ExistingLabDipTarget = DateHelper.ParseDate(Request.Params["hdnLabDipTarget" + i.ToString()]).Value;
                DateTime NewBulkTarget = orderDetail.STCUnallocated;

                int IsPcDate = Convert.ToInt32(Request.Params["hdnPCdate" + i.ToString()]);
                orderDetail.IsPCdateChange = IsPcDate;

                if (orderDetail.ExFactory == OldExfactory)
                {
                    NewBulkTarget = ExistingBulkInHouse;
                }   

                if ((!string.IsNullOrEmpty(Request.Params["chkIA11" + i.ToString()]) && Request.Params["chkIA11" + i.ToString()] == "1")
                    || (!string.IsNullOrEmpty(Request.Params["hdnChkIA11" + i.ToString()]) && Request.Params["hdnChkIA11" + i.ToString()] == "1"))
                {
                    orderDetail.IAFabric1 = true;
                }

                if (!string.IsNullOrEmpty(Request.Params["chkIA21" + i.ToString()]) && Request.Params["chkIA21" + i.ToString()] == "1"
                    || (!string.IsNullOrEmpty(Request.Params["hdnChkIA21" + i.ToString()]) && Request.Params["hdnChkIA21" + i.ToString()] == "1"))
                {
                    orderDetail.IAFabric2 = true;
                }

                if (!string.IsNullOrEmpty(Request.Params["chkIA31" + i.ToString()]) && Request.Params["chkIA31" + i.ToString()] == "1"
                    || (!string.IsNullOrEmpty(Request.Params["hdnChkIA31" + i.ToString()]) && Request.Params["hdnChkIA31" + i.ToString()] == "1"))
                {
                    orderDetail.IAFabric3 = true;
                }

                if (!string.IsNullOrEmpty(Request.Params["chkIA41" + i.ToString()]) && Request.Params["chkIA41" + i.ToString()] == "1"
                    || (!string.IsNullOrEmpty(Request.Params["hdnChkIA41" + i.ToString()]) && Request.Params["hdnChkIA41" + i.ToString()] == "1"))
                {
                    orderDetail.IAFabric4 = true;
                }


                if (this.OrderID == -1)
                {
                    orderDetail.BulkTarget = orderDetail.STCUnallocated;

                    if ((orderDetail.IAFabric1 && orderDetail.Fabric1 != string.Empty && orderDetail.Fabric2 == string.Empty && orderDetail.Fabric3 == string.Empty && orderDetail.Fabric4 == string.Empty)
                        || (orderDetail.IAFabric1 && orderDetail.Fabric1 != string.Empty && orderDetail.IAFabric2 && orderDetail.Fabric2 != string.Empty && orderDetail.Fabric3 == string.Empty && orderDetail.Fabric4 == string.Empty)
                        || (orderDetail.IAFabric1 && orderDetail.Fabric1 != string.Empty && orderDetail.IAFabric2 && orderDetail.Fabric2 != string.Empty && orderDetail.IAFabric3 && orderDetail.Fabric3 != string.Empty && orderDetail.Fabric4 == string.Empty)
                        || (orderDetail.IAFabric1 && orderDetail.Fabric1 != string.Empty && orderDetail.IAFabric2 && orderDetail.Fabric2 != string.Empty && orderDetail.IAFabric3 && orderDetail.Fabric3 != string.Empty && orderDetail.IAFabric4 && orderDetail.Fabric4 != string.Empty))
                        orderDetail.LabDipTarget = OrderDate;
                    else
                        orderDetail.LabDipTarget = OrderDate.AddDays(15);
                }
                else
                {
                    if ((orderDetail.IAFabric1 && orderDetail.Fabric1 != string.Empty && orderDetail.Fabric2 == string.Empty && orderDetail.Fabric3 == string.Empty && orderDetail.Fabric4 == string.Empty)
                        || (orderDetail.IAFabric1 && orderDetail.Fabric1 != string.Empty && orderDetail.IAFabric2 && orderDetail.Fabric2 != string.Empty && orderDetail.Fabric3 == string.Empty && orderDetail.Fabric4 == string.Empty)
                        || (orderDetail.IAFabric1 && orderDetail.Fabric1 != string.Empty && orderDetail.IAFabric2 && orderDetail.Fabric2 != string.Empty && orderDetail.IAFabric3 && orderDetail.Fabric3 != string.Empty && orderDetail.Fabric4 == string.Empty)
                        || (orderDetail.IAFabric1 && orderDetail.Fabric1 != string.Empty && orderDetail.IAFabric2 && orderDetail.Fabric2 != string.Empty && orderDetail.IAFabric3 && orderDetail.Fabric3 != string.Empty && orderDetail.IAFabric4 && orderDetail.Fabric4 != string.Empty))
                        orderDetail.LabDipTarget = OrderDate;
                    else
                        orderDetail.LabDipTarget = ExistingLabDipTarget;

                    orderDetail.BulkTarget = ExistingBulkInHouse;
                }


                if (this.OrderID > 0 && DateTime.Compare(orderDetail.ExFactory, OldExfactory) > 0 && CommonHelper.IsFOB(orderDetail.Mode))
                {
                    int NoOfDaysExtended = (ExFactoryDate - OldExfactory).Days;
                    int NoOFDaysToBulkInHouse = (DateHelper.ParseDate(Request.Params["hdnBulk" + i.ToString()]).Value - DateTime.Today).Days;
                    int NoOFDaysToOldExfactory = (OldExfactory - DateTime.Today).Days;
                    int DaysToBeAdded = 0;

                    if (NoOFDaysToOldExfactory > 0)
                    {
                        DaysToBeAdded = (NoOFDaysToBulkInHouse / NoOFDaysToOldExfactory) * NoOfDaysExtended;
                    }

                    orderDetail.BulkTarget = ExistingBulkInHouse.AddDays(DaysToBeAdded);

                }

                orderDetail.BulkTarget = NewBulkTarget;

                if (orderDetail.BulkTarget != ExistingBulkInHouse)
                    bulkEtaChangeHistory += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + (!string.IsNullOrEmpty(orderDetail.LineItemNumber) ? orderDetail.LineItemNumber : orderDetail.ContractNumber) + ": Bulk Target changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + orderDetail.BulkTarget.ToString("dd MMM yy (ddd)") + " was " + ExistingBulkInHouse.ToString("dd MMM yy (ddd)") + " as Ex-Factory changed on ORDER FORM";

                orderDetail.BulkApprovalTarget = orderDetail.BulkTarget.AddDays(-10);

                if (Request.Files != null && Request.Files.Count > 0)
                {
                    for (int j = 0; j < Request.Files.Count; j++)
                    {
                        string filetype = Request.Files.Keys[j].Substring(13, 1);
                        if (Request.Files.Keys[j].Contains(i.ToString()))
                        {
                            if (Request.Files[j] != null && Request.Files[j].FileName != "")
                            {
                                string OriginalfileName = Request.Files[j].FileName;
                                string filePath = "";
                                if (OriginalfileName.LastIndexOf("\\") > -1)
                                {
                                    filePath = OriginalfileName.Substring(0, (OriginalfileName.LastIndexOf("\\") + 1));
                                    OriginalfileName = OriginalfileName.Replace(filePath, "");
                                }
                                string ext = OriginalfileName.Substring(OriginalfileName.LastIndexOf("."));
                                OriginalfileName = OriginalfileName.Replace(ext, "");
                                OriginalfileName = txtIkandiSerial.Text.Trim().Replace(" ", "_") + "-" + i.ToString().Trim() + j.ToString().Trim() + "-" + Request.Params["txtQty" + i.ToString()].ToString().Trim() + "-" + OriginalfileName.Trim();
                                OriginalfileName = OriginalfileName.Replace(" ", "");
                                string fileName = FileHelper.SaveFile(Request.Files[j].InputStream, Request.Files[j].FileName, Constants.ORDER_FOLDER_PATH, true, OriginalfileName);

                                if (filetype == "a")
                                {
                                    orderDetail.File = fileName.Trim();
                                    orderDetail.File1 = fileName.Trim();
                                }
                                if (filetype == "b")
                                    orderDetail.File2 = fileName.Trim();
                                if (filetype == "c")
                                    orderDetail.File3 = fileName.Trim();
                                if (filetype == "d")
                                    orderDetail.File4 = fileName.Trim();
                            }
                            else
                            {
                                if (filetype == "a")
                                {
                                    orderDetail.File = Request.Params["hdnFilea" + i.ToString()];
                                    orderDetail.File1 = Request.Params["hdnFilea" + i.ToString()];
                                }
                                if (filetype == "b")
                                    orderDetail.File2 = Request.Params["hdnFileb" + i.ToString()];
                                if (filetype == "c")
                                    orderDetail.File3 = Request.Params["hdnFilec" + i.ToString()];
                                if (filetype == "d")
                                    orderDetail.File4 = Request.Params["hdnFiled" + i.ToString()];
                            }
                        }
                    }
                }
                else
                {
                    orderDetail.File = Request.Params["hdnFilea" + i.ToString()];
                    orderDetail.File1 = Request.Params["hdnFilea" + i.ToString()];
                    orderDetail.File2 = Request.Params["hdnFileb" + i.ToString()];
                    orderDetail.File3 = Request.Params["hdnFilec" + i.ToString()];
                    orderDetail.File4 = Request.Params["hdnFiled" + i.ToString()];
                }
                //System.Diagnostics.Debugger.Break();
                if (Request.Params["radioMode1" + i.ToString()] == "1")
                    orderDetail.IsAirFabric1 = true;
                else
                    orderDetail.IsAirFabric1 = false;

                if (Request.Params["radioMode2" + i.ToString()] == "1")
                    orderDetail.IsAirFabric2 = true;
                else
                    orderDetail.IsAirFabric2 = false;

                if (Request.Params["radioMode3" + i.ToString()] == "1")
                    orderDetail.IsAirFabric3 = true;
                else
                    orderDetail.IsAirFabric3 = false;

                if (Request.Params["radioMode4" + i.ToString()] == "1")
                    orderDetail.IsAirFabric4 = true;
                else
                    orderDetail.IsAirFabric4 = false;

                //manisha added on 1 march for task reminder
                if (!string.IsNullOrEmpty(Request.Params["hdnManualNo" + i.ToString()]))
                {
                    orderDetail.HdnDetailType = Request.Params["hdnManualNo" + i.ToString()];
                }

                order.OrderBreakdown.Add(orderDetail);

                orderDetail.OrderSizes = new List<OrderDetailSizes>();

                for (int j = 1; j <= 15; j++)
                {
                    OrderDetailSizes orderdetailsizes = new OrderDetailSizes();
                    orderdetailsizes.isDeleted = 0;

                    //orderdetailsizes.SizeOption = Request.Params["Option_" + i.ToString()];

                    orderdetailsizes.Size = Request.Params["txtSize" + j.ToString() + "_" + i.ToString()];

                    if (!string.IsNullOrEmpty(Request.Params["txtRatioPack" + j.ToString() + "_" + i.ToString()]))
                    {
                      orderdetailsizes.RatioPack = Convert.ToInt32(Request.Params["txtRatioPack" + j.ToString() + "_" + i.ToString()]);
                    }
                    else
                    { orderdetailsizes.RatioPack = 0; }

                    if (!string.IsNullOrEmpty(Request.Params["txtRatio" + j.ToString() + "_" + i.ToString()]))
                    {
                        orderdetailsizes.Ratio = Convert.ToInt32(Request.Params["txtRatio" + j.ToString() + "_" + i.ToString()]);
                    }
                    else
                    { orderdetailsizes.Ratio = 0; }
                    if (!string.IsNullOrEmpty(Request.Params["txtSingles" + j.ToString() + "_" + i.ToString()]))
                    {
                      orderdetailsizes.Singles = Convert.ToInt32(Request.Params["txtSingles" + j.ToString() + "_" + i.ToString()]);
                    }

                    else
                    {
                      orderdetailsizes.Singles = 0;
                    }

                    if (!string.IsNullOrEmpty(Request.Params["txtOrderDetailSizeID" + j.ToString() + "_" + i.ToString()]))
                    {
                        orderdetailsizes.OrderDetailSizeID = Convert.ToInt32(Request.Params["txtOrderDetailSizeID" + j.ToString() + "_" + i.ToString()]);
                    }
                    else
                    {
                        orderdetailsizes.OrderDetailSizeID = -1;
                    }
                    //abhishek 
                    if (!string.IsNullOrEmpty(Request.Params["txtQuantity" + j.ToString() + "_" + i.ToString()]))
                    {
                        orderdetailsizes.Quantity = Convert.ToInt32(Request.Params["txtQuantity" + j.ToString() + "_" + i.ToString()]);
                    }
                    else
                    {
                         orderdetailsizes.isDeleted = 1;
                        //OrderController objcontroller = new OrderController();
                        //bool gg = objcontroller.DeleteOrderDetailSizes_new(orderdetailsizes.OrderDetailSizeID, orderDetail.OrderDetailID);

                    }
                    //end
                    if (orderdetailsizes.OrderDetailSizeID > -1)
                    {
                        if (!string.IsNullOrEmpty(Request.Params["txtSize" + j.ToString() + "_" + i.ToString()]))
                        {
                            orderdetailsizes.Size = Request.Params["txtSize" + j.ToString() + "_" + i.ToString()];
                        }
                        else
                        {
                            orderdetailsizes.isDeleted = 1;
                        }
                    }
                    else
                    { orderdetailsizes.OrderDetailSizeID = 0; }
                    // add by sushil for insert update only size wise quantity value > 0 on date 17/3/2015
                    //if (orderdetailsizes.Quantity > 0)
                    //{
                        orderDetail.OrderSizes.Add(orderdetailsizes);
                    //}
                }
                i++;
            }

            int a;
            if (owner == "I")
                differences = this.ShowDifferences(order, "proposed", out a);
            else
                differences = this.ShowDifferences(order, "changed", out a);

            string proposal = "";
            if (type == 1 && owner == "B")
            {
                proposal = "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "Proposal accepted by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper();
                differences = proposal + differences;
            }
            else if (type == 2 && owner == "B")
            {
                proposal = "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "Proposal rejected by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper();
                differences = proposal;//+ differences;  
            }
            order.History = differences + "$$" + bulkEtaChangeHistory;

            if (IsIkandiCommentInserted == false)
            {
                order.Comments = string.Empty;
            }

            order.UpdatedBy = ApplicationHelper.LoggedInUser.UserData.UserID.ToString();

            //Status of order in duplicate table(is approved), data type flag-->0=original,1=agree,2=Ikandi,3=disagree
            int iOrderId = order.OrderID;
            int iAfterUpdation = 0;
            int NewOrderID = 0;

            if (hdnRepeatWithChanges.Value == "1")
            {
                int ParentStyleID = -1;
                string ParentStyleNumber = "";
                if (hdnParentStyleID.Value != "")
                {
                    ParentStyleID = Convert.ToInt32(hdnParentStyleID.Value);
                }
                if (hdnParentStyleNumber.Value != "")
                {
                    ParentStyleNumber = hdnParentStyleNumber.Value;
                    order.BaseStyle = ParentStyleNumber;
                }

                order.Style.StyleID = StyleControllerInstance.CloneStyleNumberByOrder(ParentStyleID, ParentStyleNumber, order.Style.StyleNumber, order.Style.client.ClientID, order.Style.cdept.DeptID);
            }

            //Add By Surendra2 on 10-05-2018.
            if (hdnOldStyleId.Value != "" && hdnOldStyleNumber.Value != "")
            {
                if (hdnOldStyleId.Value != hdnStyleID.Value && hdnOldStyleNumber.Value != txtStyleNumber.Text.Trim())
                {
                    bool Sucessfully = this.OrderControllerInstance.Update_Old_Style(Convert.ToInt32(hdnOldStyleId.Value), order.OrderID, Convert.ToInt32(hdnStyleID.Value));
                    order.ApprovedByMerchandiserManager = 0;
                }
            }

            bool sucess = this.OrderControllerInstance.AddOrder(order, ApplicationHelper.LoggedInUser.UserData.UserID, ref bCheckOrderSAM, ref bCheckUpdate, ref iAfterUpdation, ref NewOrderID, Convert.ToInt32(hdnRepeatWithChanges.Value));

            if (sucess)
            {
                if (iOrderId == -1)
                {
                    // when new order
                    bool PcdUpdate = this.OrderControllerInstance.CalculatePCD_InsertOrder(NewOrderID);

                }
                // update By Ravi kumar on 04/11/2015 for calculate PCD, avail mins, days and line on update order
                else
                {
                    bool PcdUpdate = this.OrderControllerInstance.CalculatePCD_UpdateOrder(order.OrderID);
                }
                //if (iAfterUpdation == 1)
                //{
                //    bool PcdUpdate = this.OrderControllerInstance.CalculatePCD_UpdateOrder(order.OrderID);
                //}

                string Attachments = hdnAttachments.Value;
                List<string> AttachmentsList = new List<string>();
              
                if ((bCheckOrderSAM == true && bCheckUpdate == false) && ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_Manager)
                {
                   
                    pnlForm.Visible = false;
                    pnlMessage.Visible = true;
                }
                else
                {
                    if (bCheckOrderSAM == false && bCheckUpdate == true)
                    {
                        // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('Order Sam not input IN MO,Please input Correct order SAM');", true);
                        // pnlForm.Visible = true;
                        //  pnlMessage.Visible = false;
                        pnlForm.Visible = false;
                        pnlMessage.Visible = true;
                    }
                    else
                    {
                        pnlForm.Visible = false;
                        pnlMessage.Visible = true;
                    }
                }
            }
            else
            {
                pnlForm.Visible = false;
                pnlMessage.Visible = true;
            }
        }

        private void ApproveOrder(int type)
        {//manisha on 28th march
            //if (type == 0)
            //{
            //    bool sucess = this.OrderControllerInstance.RestoreOrder(OrderID);
            //}
            //else if (type == 1)
            //{
            //    bool sucess = this.OrderControllerInstance.RestoreOrder(OrderID);
            //}
        }

        private void SaveFabricLabDipApproval(string Fabric, int ClientID, int OrderID, int StyleID, string FabricDetails)
        {
            try
            {

                DataSet dsLabDip = FabricApprovalControllerInstance.GetLabDipHistory(ClientID, Fabric, OrderID, StyleID, FabricDetails);

                int c1 = dsLabDip.Tables[0].Rows.Count;


                if (c1 == 0 || (c1 > 0 && dsLabDip.Tables[0].Rows[c1 - 1]["Status"].ToString() != "2"))
                {

                    FabricApproval fabricApproval = new FabricApproval();

                    fabricApproval.Id = -1;

                    fabricApproval.FabricName = Fabric.ToLower().Trim();

                    fabricApproval.ClientID = ClientID;

                    fabricApproval.OrderID = OrderID;

                    fabricApproval.FabricDetails = FabricDetails;
                    fabricApproval.StyleID = StyleID;

                    fabricApproval.LabDipApproval = new List<FabricApprovalDetails>();


                    FabricApprovalDetails labDipApprovalDetails = new FabricApprovalDetails();

                    fabricApproval.LabDipApproval.Add(labDipApprovalDetails);

                    labDipApprovalDetails.Id = -1;

                    labDipApprovalDetails.DHLNumber = string.Empty;
                    labDipApprovalDetails.ActionDate = DateTime.Today;
                    labDipApprovalDetails.SentDate = DateTime.Today;
                    labDipApprovalDetails.Remarks = "Auto Approved from Order Form";
                    labDipApprovalDetails.Stage = Convert.ToInt32(FabricApprovalStage.LabDip);
                    labDipApprovalDetails.Status = ((int)FabricApprovalStatus.Approved).ToString();

                    this.FabricApprovalControllerInstance.InsertFabricApproval(fabricApproval);
                }

            }
            catch (Exception ex)
            {
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + "  " + ex.StackTrace);
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        private void PopulateOrderData()
        {

            //if ((iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_IKANDI_COMMENTS)))
            //{
            //    txtComments1.Attributes.Remove("readonly");
            //}
            //else
            //{
            //    txtComments1.Attributes.Add("readonly", "true");
            //}

            //if (!(iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_TYPE_OF_PACKING)))
            //{
            //    ddlTypeOfPacking.CssClass = "disable-dropdown";
            //}
            //Gajendra Permission
            //ShowUsers();
            //if (this.OrderControllerInstance.bCheckOB(OrderID) == false)
            //{
            //    checkBoxSalesMgrBIPL.Enabled = false;
            //}
            hdnOrderId.Value = this.OrderID.ToString();
            // edit By surendra
            hdnBuyingHouse.Value = this.OrderControllerInstance.CheckExistBuyingHouse(OrderID);
            //
            iKandi.Common.Order order;

            if (this.OrderID == -1)
            {
                //acvb.CssClass = "disable-dropdown";
                order = new iKandi.Common.Order();
                order.TypeOfPacking = Convert.ToInt32(ddlTypeOfPacking.SelectedValue);
                lblBiplPriceSign.Text = "£";
                order.OrderBreakdown = new List<OrderDetail>();
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderSizes = new List<OrderDetailSizes>();
                orderDetail.ParentOrder = new iKandi.Common.Order();
                orderDetail.ParentOrder.Costing = new iKandi.Common.Costing();

                orderDetail.LineItemNumber = string.Empty;
                orderDetail.ContractNumber = string.Empty;
                orderDetail.Fabric1 = "Fabric";
                orderDetail.Fabric1Details = "Color / PRD";
                orderDetail.Fabric2 = "Fabric";
                orderDetail.Fabric2Details = "Color / PRD";
                orderDetail.Fabric3 = "Fabric";
                orderDetail.Fabric3Details = "Color / PRD";
                orderDetail.Fabric4 = "Fabric";
                orderDetail.Fabric4Details = "Color / PRD";
                //orderDetail.ColorPrint = string.Empty;
                orderDetail.Quantity = 0;
                orderDetail.iKandiPrice = 0;
                orderDetail.ExFactory = DateTime.MinValue;
                orderDetail.WeekToEx = 1;
                orderDetail.DC = DateTime.Today;
                orderDetail.WeeksToDC = 1;
                orderDetail.OrderDetailID = -1;
                orderDetail.StatusModeID = -1;
                orderDetail.StatusModeSequence = -1;
                orderDetail.IsAirFabric1 = false;
                orderDetail.IsAirFabric2 = false;
                orderDetail.IsAirFabric3 = false;
                orderDetail.IsAirFabric4 = false;
                orderDetail.ParentOrder.Costing.CurrencySign = "£";

                order.OrderBreakdown.Add(orderDetail);

                if (order.OrderBreakdown != null && order.OrderBreakdown.Count > 0)
                {
                    System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
                    new System.Web.Script.Serialization.JavaScriptSerializer();

                    string sJSON = oSerializer.Serialize(order.OrderBreakdown);

                    PageHelper.AddJScriptVariable("orderDetail", "{" + string.Format("table: {0}", sJSON) + "}");
                }
            }
            if (this.OrderID > -1)
            {
                order = this.OrderControllerInstance.GetOrderOrderForm(OrderID);
                string CQDName = order.CQDName;
                if (CQDName != "")
                    lblCQD.Text = CQDName;
                ApplyPermissions(order);

                ddlordrType.SelectedValue = order.OrderTypes.ToString();
                if (order.OrderTypes == 2)
                {

                    txtkusakprice.Attributes.Add("style", "display:show;float:right;text-align: left;font-size: 10px; font-weight: bold;");
                    txtkusakprice.Attributes.Add("class", "numeric-field-with-two-decimal-places");
                    if (order.OutHousePrice.ToString() != "-1" && order.OutHousePrice.ToString() != "0")
                    {
                        txtkusakprice.Text = order.OutHousePrice.ToString("N2");
                        hdnkasukaprice.Value = order.OutHousePrice.ToString();
                    }
                }
                if (order.OrderTypes == 3)
                    lblbiplprice.Text = "Kasuka price";
                ////Added By Ashish on 29/10/2014
                for (int i = 0; i < order.OrderBreakdown.Count; i++)
                {
                    int OdId = order.OrderBreakdown[i].OrderDetailID;
                    int IsSizeContain = this.OrderControllerInstance.IsSizeByOrderDetailsId(OdId);
                    if (IsSizeContain == 1)
                    {
                        hdnIsNewOrderId.Value = "1";
                    }
                    else
                    {
                        hdnIsNewOrderId.Value = "-1";
                    }                   
                }
                ////END

                int IsQtySize = this.OrderControllerInstance.CheckSizeByOrderId(OrderID);
                if (IsQtySize == 1)
                {
                    ddlClient.CssClass = "disable-dropdown";
                    txtStyleNumber.Attributes.Add("readonly", "true");
                    ddlDepartment.Attributes.Add("disabled", "true");
                    hdnIsSize.Value = "1";                   
                } 

                // If Order is DIRECT order then display the iKandi Price in place of BIPL Price

                if (order != null && order.OrderBreakdown != null && order.OrderBreakdown.Count > 0 && CommonHelper.IsFOBDelivery(order.OrderBreakdown[0].Mode))
                {                   

                    if (order.OrderBreakdown[0].Mode == 7 || order.OrderBreakdown[0].Mode == 8 ||
                        order.OrderBreakdown[0].Mode == 9 || order.OrderBreakdown[0].Mode == 10 ||
                        order.OrderBreakdown[0].Mode == 14 || order.OrderBreakdown[0].Mode == 15 ||
                        order.OrderBreakdown[0].Mode == 16 || order.OrderBreakdown[0].Mode == 17 ||
                        order.OrderBreakdown[0].Mode == 18)
                    {
                        txtDirectOrderiKandiPrice.Text = Convert.ToString(order.BiplPrice);
                    }
                }
                hdnOrderSequence.Value = order.StatusModeSequence.ToString();
                ddlClient.SelectedValue = order.ClientID.ToString();
                hdnOriginalClientID.Value = order.ClientID.ToString();
                lbltxtStyleNumber.InnerHtml = order.StyleNumber_d;
                lbltxtDescription.InnerHtml = order.Description_d;
                lblddlClient.InnerHtml = order.CompanyName_d;
                lblddlDepartment.InnerHtml = order.Name_d;
                lblddlParentDept.InnerHtml = order.Costing.ParentDepartment_d;
                lblddlTypeOfPacking.InnerHtml = Convert.ToString(order.TypeOfPackingName);

                int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

                List<ClientDepartment> cd = this.ClientControllerInstance.GetClientDeptsByClientID_ForDesignForm(Convert.ToInt32(ddlClient.SelectedValue), UserId, -1, "Parent");

                foreach (ClientDepartment client in cd)
                {
                    ddlParentDept.Items.Add(new ListItem(client.Name, client.DeptID.ToString()));
                }

                List<ClientDepartment> cDepartment = this.ClientControllerInstance.GetClientDeptsByClientID_ForDesignForm(Convert.ToInt32(ddlClient.SelectedValue), UserId, order.Costing.ParentDepartmentID, "SubParent");

                foreach (ClientDepartment client in cDepartment)
                {
                    ddlDepartment.Items.Add(new ListItem(client.Name, client.DeptID.ToString()));
                }

                Status = Convert.ToString(order.IsApproved);
                hdnOrderType.Value = Status;
                ddlParentDept.SelectedValue = order.Costing.ParentDepartmentID.ToString();
                ddlDepartment.SelectedValue = order.Style.cdept.DeptID.ToString();
                txtOrderDate.Text = order.OrderDate.ToString("dd MMM yy (ddd)");

                int CheckCutting_Permission = this.OrderControllerInstance.GetAuthenticatCutting(OrderID);

                txtStyleNumber.Text = order.Style.StyleNumber;

                if (CheckCutting_Permission == 1)
                {
                    txtStyleNumber.Enabled = false;
                }
                else
                {
                    txtStyleNumber.Enabled = true;
                }

                hdnOldStyleId.Value = order.Style.StyleID.ToString();
                hdnOldStyleNumber.Value = order.Style.StyleNumber;
                txtIkandiSerial.Text = order.SerialNumber.ToString();
                txtDescription.Text = order.Description;
                txtTotalQty.Text = order.TotalQuantity.ToString();
                txtDeliverTo.Text = order.InvoiceLocation;
                ddlTypeOfPacking.SelectedValue = ((int)order.TypeOfPacking).ToString();
                lblikandiCommentsHistory.Text = order.Comments.ToString().Replace("~", "<br/>");
                //txtBIPLPrice.Text = order.BiplPrice.ToString("N2");
                //lbltxtBIPLPrice.InnerHtml = order.BiplPrice_d.ToString("N2");
                lbltxtTotalQty.InnerHtml = Convert.ToString(order.TotalQuantity_d);

                if (txtTotalQty.Text == lbltxtTotalQty.InnerHtml)
                {
                    lbltxtTotalQty.InnerHtml = "-1";
                }
                //if (txtBIPLPrice.Text == lbltxtBIPLPrice.InnerHtml)
                //{
                //    lbltxtBIPLPrice.InnerHtml = "0.0";
                //}
                //lblBiplPriceSign.Text = order.Costing.CurrencySign;
                lblAccntMgr.Text = order.AccountManagerName;
                checkBoxMerchandisingMgr.Checked = Convert.ToBoolean(order.ApprovedByMerchandiserManager);
                //Gajendra Permission
                //if (checkBoxMerchandisingMgr.Checked == true)
                //{
                //    checkBoxMerchandisingMgr.Enabled = false;
                //}

                checkBoxSalesMgrBIPL.Checked = Convert.ToBoolean(order.ApprovedBySalesBIPL);
                //Gajendra Permission
                //if (checkBoxSalesMgrBIPL.Checked == true)
                //{
                //    checkBoxSalesMgrBIPL.Enabled = false;
                //}

                if (order.Style.SampleImageURL1 != string.Empty)
                {
                    imgPrint.ImageUrl = ResolveUrl("~/Uploads/Style/thumb-" + order.Style.SampleImageURL1);
                    imgPrint.CssClass = "";
                }

                if (order.Style.SampleImageURL2 != string.Empty)
                {
                    imgStyle.ImageUrl = ResolveUrl("~/Uploads/Style/thumb-" + order.Style.SampleImageURL2);
                    imgStyle.CssClass = "";
                }
                hdnCostingId.Value = order.Costing.CostingID.ToString();

                if (order.OrderBreakdown != null && order.OrderBreakdown.Count > 0)
                {
                    if (order.OrderBreakdown[0].ModeName.IndexOf("/H") > -1)
                    {
                        txtDelInstruction.Text = "Hanging";
                    }
                    else
                    {
                        txtDelInstruction.Text = "Flat";
                    }
                    if (order.OrderBreakdown[0].ModeName.IndexOf("FOB") > -1)
                    {
                        txtDeliverTo.Text = order.InvoiceLocation;
                    }
                    else
                    {
                        txtDeliverTo.Text = "Ikandi";
                    }
                }
                else
                {
                    order.OrderBreakdown = new List<OrderDetail>();
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.ParentOrder = new iKandi.Common.Order();
                    orderDetail.ParentOrder.Costing = new iKandi.Common.Costing();
                    orderDetail.OrderSizes = new List<OrderDetailSizes>();
                    orderDetail.LineItemNumber = string.Empty;
                    orderDetail.ContractNumber = string.Empty;
                    orderDetail.Fabric1 = "Fabric";
                    orderDetail.Fabric1Details = "Color / PRD";
                    orderDetail.Fabric2 = "Fabric";
                    orderDetail.Fabric2Details = "Color / PRD";
                    orderDetail.Fabric3 = "Fabric";
                    orderDetail.Fabric3Details = "Color / PRD";
                    orderDetail.Fabric4 = "Fabric";
                    orderDetail.Fabric4Details = "Color / PRD";
                    // orderDetail.ColorPrint = string.Empty;
                    orderDetail.Quantity = 0;
                    orderDetail.iKandiPrice = 0;
                    orderDetail.ExFactory = DateTime.MinValue;
                    orderDetail.WeekToEx = 1;
                    orderDetail.DC = DateTime.Today;
                    orderDetail.WeeksToDC = 1;
                    orderDetail.OrderDetailID = -1;
                    orderDetail.StatusModeID = -1;
                    orderDetail.StatusModeSequence = -1;
                    orderDetail.IsAirFabric1 = false;
                    orderDetail.IsAirFabric2 = false;
                    orderDetail.IsAirFabric3 = false;
                    orderDetail.IsAirFabric4 = false;
                    orderDetail.IAFabric1 = false;
                    orderDetail.IAFabric2 = false;
                    orderDetail.IAFabric3 = false;
                    orderDetail.IAFabric4 = false;
                    orderDetail.ParentOrder.Costing.CurrencySign = "£";

                    order.OrderBreakdown.Add(orderDetail);

                    if (order.OrderBreakdown != null && order.OrderBreakdown.Count > 0)
                    {
                        System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
                        new System.Web.Script.Serialization.JavaScriptSerializer();

                        string sJSON = oSerializer.Serialize(order.OrderBreakdown);

                        PageHelper.AddJScriptVariable("orderDetail", "{" + string.Format("table: {0}", sJSON) + "}");
                    }

                }
                if (order.History != string.Empty)
                {
                    order.History = order.History.Replace("~", "<br/>");
                    lblHistory.Text = order.History.Replace("<br/><br/>", "<br/>");
                    lblHistory.Text = RemoveDuplicateHistory(lblHistory.Text);
                }
                else
                {
                    lblHistory.Text = order.History;
                    lblHistory.Text = RemoveDuplicateHistory(lblHistory.Text);
                }

                hypBiplPrice.NavigateUrl = "/Internal/Sales/CostingSheet.aspx?sn=" + order.Style.StyleNumber + "&SingleVersion=1";

                if (order.IsBiplAgreement == 1)
                {
                    lblBiplPriceComments.Text = " BIPL Agreement Pending.";
                }
                else if (order.IsBiplAgreement == 0)
                {
                    lblBiplPriceComments.Text = " Price Agreed.";
                }
                else if (order.IsBiplAgreement == 2)
                {
                    lblBiplPriceComments.Text = "";
                }

                if (order.OrderBreakdown != null && order.OrderBreakdown.Count > 0)
                {
                    PageHelper.RemoveJScriptVariable("orderDetail");

                    string[] temp = new string[order.OrderBreakdown.Count];
                    for (int i = 0; i < order.OrderBreakdown.Count; i++)
                    {
                        if (Convert.ToInt32(order.OrderBreakdown[i].OrderDetailID) > 0 && order.OrderBreakdown[i].ParentOrder.Print.ImageUrl != string.Empty)
                        {
                            temp[i] = ResolveUrl("~/Uploads/Print/thumb-" + order.OrderBreakdown[i].ParentOrder.Print.ImageUrl);
                        }
                    }
                    string[] print = RemoveDuplicates(temp);
                    for (int i = 0; i <= print.Length - 1; i++)
                    {
                        if (Convert.ToInt32(order.OrderBreakdown[i].OrderDetailID) > 0 && order.OrderBreakdown[i].ParentOrder.Print.ImageUrl != string.Empty)
                        {
                            Image img = new Image();
                            img.ImageUrl = print[i];
                            imagePrint.Visible = false;
                            img.Width = 80;
                            img.Height = 80;
                            divPrintImages.Controls.Add(img);
                        }
                    }

                    System.Web.Script.Serialization.JavaScriptSerializer oSerializer =  new System.Web.Script.Serialization.JavaScriptSerializer();

                    string sJSON = oSerializer.Serialize(order.OrderBreakdown);

                    PageHelper.AddJScriptVariable("orderDetail", "{" + string.Format("table: {0}", sJSON) + "}");
                }

                PageHelper.AddJScriptVariable("selectedDeptID", order.Style.cdept.DeptID);
                hdnDeptID.Value = order.Style.cdept.DeptID.ToString();
                hdnOriginalDeptID.Value = order.Style.cdept.DeptID.ToString();
                PageHelper.AddJScriptVariable("selectedAccManagerID", order.AccountManagerID);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "$(function(){onPageLoad()});", true);

                if (order.BaseStyle != string.Empty)
                {
                    lblBaseStyle.Text = "Base Style is : " + order.BaseStyle + "   ";
                }
            }
            //Gajendra Permission
            //checkBoxMerchandisingMgr.Enabled = iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_MERCHANDISING_MGR);
            //checkBoxSalesMgrBIPL.Enabled = iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SALES_MANAGER_BIPL);
            if (checkBoxMerchandisingMgr.Checked)
                checkBoxMerchandisingMgr.Enabled = false;
            if (checkBoxSalesMgrBIPL.Checked)
                checkBoxSalesMgrBIPL.Enabled = false;
        }

        private void ApplyPermissions(iKandi.Common.Order order)
        {
            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_Manager || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_SalesManager) && order.StatusModeSequence >= 11) //temp need to manage it with DB
            {
                btnSubmit.Visible = false;
            }
        }

        //Gajendra Permission
        //private void ShowUsers()
        //{
        //    if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_Manager)
        //    {
        //        checkBoxSalesMgrBIPL.Enabled = false;
        //        checkBoxMerchandisingMgr.Enabled = true;
        //    }
        //    else
        //        if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Sales_Manager)
        //        {
        //            checkBoxSalesMgrBIPL.Enabled = true;
        //            checkBoxMerchandisingMgr.Enabled = false;
        //        }
        //        else
        //        {
        //            checkBoxSalesMgrBIPL.Enabled = false;
        //            checkBoxMerchandisingMgr.Enabled = false;
        //        }
        //    // edit by surendra
        //    //
        //}

        private string ShowDifferences(iKandi.Common.Order Neworder, string type, out int a)
        {       

            string Differences = "";
            iKandi.Common.Order order = this.OrderControllerInstance.GetOrderOrderForm(OrderID);
            a = 0;

            if (OrderID > -1)
            {                
                NotificationEmailHistory NEH = new NotificationEmailHistory();
                NEH.Type = "5";
                NEH.EmailID = "6";
                NEH.OrderDetailsID = order.OrderDetailsID.ToString();
                NEH.OrderID = order.OrderID.ToString();
               
                int i = 0;
                if (DateTime.Compare(Neworder.OrderDate, order.OrderDate) != 0)
                {
                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> Order Date changed by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderDate.ToString("dd MMM yy (ddd)") + "</b> was <b>" + order.OrderDate.ToString("dd MMM yy (ddd)") + "</b>";
                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> Order Date changed by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderDate.ToString("dd MMM yy (ddd)") + " was " + order.OrderDate.ToString("dd MMM yy (ddd)") + "</b>";
                }

                if (Neworder.Style.StyleNumber != order.Style.StyleNumber)
                {
                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> StyleNumber changed by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.Style.StyleNumber.ToUpper() + " was " + order.Style.StyleNumber.ToUpper() + "</b>";
                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> StyleNumber changed by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.Style.StyleNumber.ToUpper() + " was " + order.Style.StyleNumber.ToUpper() + "</b>";
                }
                if (Neworder.Style.client.CompanyName != order.Style.client.CompanyName)
                {
                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> Buyer " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.Style.client.CompanyName.ToUpper() + " was " + order.Style.client.CompanyName.ToUpper() + "</b>";
                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> Buyer " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.Style.client.CompanyName.ToUpper() + " was " + order.Style.client.CompanyName.ToUpper() + "</b>";
                    a++;
                }
                if (hdnSelectedParentDept.Value != order.Costing.ParentDepartment)
                {
                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> Parent Department " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.Costing.ParentDepartment + " was " + order.Costing.ParentDepartment + "</b>";
                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> Parent Department " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.Costing.ParentDepartment.ToUpper() + " was " + order.Costing.ParentDepartment.ToUpper() + "</b>";
                    a++;
                }
                if (hdnSelectedDept.Value != order.Style.cdept.Name)
                {
                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> Department " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.Style.cdept.Name.ToUpper() + " was " + order.Style.cdept.Name.ToUpper() + "</b>";
                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> Department " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.Style.cdept.Name.ToUpper() + " was " + order.Style.cdept.Name.ToUpper() + "</b>";
                    a++;
                }
                if (Neworder.SerialNumber != order.SerialNumber)
                {
                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> SerialNumber changed by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.SerialNumber.ToUpper() + " was " + order.SerialNumber.ToUpper() + "</b>";
                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> SerialNumber changed by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.SerialNumber.ToUpper() + " was " + order.SerialNumber.ToUpper() + "</b>";
                }
                if (Neworder.Description != order.Description)
                {
                    if (Neworder.Description != null)
                    {
                        if (order.Description == "")
                        {
                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> Description " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.Description.ToUpper() + " was None";
                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                            Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> Description " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.Description.ToUpper() + " was None";
                        }
                        else
                        {
                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> Description " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.Description.ToUpper() + " was " + order.Description.ToUpper() + "</b>";
                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                            Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> Description " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.Description.ToUpper() + " was " + order.Description.ToUpper() + "</b>";
                        }
                        a++;
                    }
                }

                //if (Neworder.BiplPrice != order.BiplPrice)
                //{
                //    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> BiplPrice " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderDetail.odBIPLPrice.ToString("N2") + " was " + order.OrderDetail.odBIPLPrice.ToString("N2") + "</b>";
                //    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                //    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> BiplPrice " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderDetail.odBIPLPrice.ToString("N2") + " was " + order.OrderDetail.odBIPLPrice.ToString("N2") + "</b>";
                //    a++;
                //}

                if (Neworder.Comments != order.Comments)
                {
                    if (Neworder.Comments != null)
                    {
                        if (order.Comments == "")
                        {
                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> Ikandi Comments : <b>" + Neworder.Comments + "</b> : Inserted by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b>";
                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                            Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> Ikandi Comments : <b>" + Neworder.Comments + "</b> : Inserted by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b>";
                        }
                        else
                        {
                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> Ikandi Comments : <b>" + Neworder.Comments + "</b> : updated by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b>";
                            this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                            Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> Ikandi Comments : <b>" + Neworder.Comments + "</b> : updated by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b>";
                        }
                        a++;
                    }

                }
                if (Neworder.ApprovedByMerchandiserManager != order.ApprovedByMerchandiserManager)
                {
                    if (Neworder.ApprovedByMerchandiserManager == 1)
                    {
                        //NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "Approved By Merchandising Manager " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper();
                        //this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> " + "Approved By Account Manager <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b>";
                    }
                }

                if (Neworder.ApprovedBySalesBIPL != order.ApprovedBySalesBIPL)
                {
                    if (Neworder.ApprovedBySalesBIPL == 1)
                    {
                        //NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "Approved By SalesBIPL " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper();
                        //this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                        Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> " + "Approved By SalesBIPL <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b>";
                    }
                }

                if (order.OrderBreakdown != null && order.OrderBreakdown.Count > 0)
                {
                    int RowcountDiff = Neworder.OrderBreakdown.Count - order.OrderBreakdown.Count;
                    if (RowcountDiff < 0)
                    {

                    }
                    else
                    {
                        foreach (OrderDetail od in Neworder.OrderBreakdown)
                        {
                            if (order.OrderBreakdown.Count >= i + 1)
                            {

                                if (order.OrderBreakdown[i].Fabric1Details.IndexOf("PRD:") > -1)
                                {
                                    order.OrderBreakdown[i].Fabric1Details = order.OrderBreakdown[i].Fabric1Details.Replace("PRD:", "");
                                }

                                if (order.OrderBreakdown[i].Fabric2Details.IndexOf("PRD:") > -1)
                                {
                                    order.OrderBreakdown[i].Fabric2Details = order.OrderBreakdown[i].Fabric2Details.Replace("PRD:", "");
                                }
                                if (order.OrderBreakdown[i].Fabric3Details.IndexOf("PRD:") > -1)
                                {
                                    order.OrderBreakdown[i].Fabric3Details = order.OrderBreakdown[i].Fabric3Details.Replace("PRD:", "");
                                }
                                if (order.OrderBreakdown[i].Fabric4Details.IndexOf("PRD:") > -1)
                                {
                                    order.OrderBreakdown[i].Fabric4Details = order.OrderBreakdown[i].Fabric4Details.Replace("PRD:", "");
                                }

                                if (order.OrderBreakdown[i].LineItemNumber != Neworder.OrderBreakdown[i].LineItemNumber)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> " + "Line/Item Number " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].LineItemNumber.ToUpper() + " was " + order.OrderBreakdown[i].LineItemNumber.ToUpper() + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ":<b>" + order.SerialNumber + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> " + "LineItemNumber " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].LineItemNumber.ToUpper() + " was " + order.OrderBreakdown[i].LineItemNumber.ToUpper() + "</b>";
                                    a++;
                                }
                                if (order.OrderBreakdown[i].ContractNumber != Neworder.OrderBreakdown[i].ContractNumber)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> " + "Contract Number " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " was " + order.OrderBreakdown[i].ContractNumber.ToUpper() + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + " <b>" + order.SerialNumber + "</b> ContractNumber " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " was " + order.OrderBreakdown[i].ContractNumber.ToUpper() + "</b>";
                                    a++;
                                }
                              //abhishek 20/6/2018
                                for (int x = i; x < order.OrderBreakdown.Count; x++)
                                {
                                  for (int y = 0; y < 15; y++)
                                  {
                                      if ((Neworder.OrderBreakdown[x].OrderSizes != null) && (order.OrderBreakdown[x].OrderSizes != null) && (Convert.ToInt32(order.OrderBreakdown[x].OrderSizes.Count) > 0))
                                      {
                                          if (order.OrderBreakdown[x].OrderSizes[y].Singles != Neworder.OrderBreakdown[x].OrderSizes[y].Singles)
                                          {
                                              Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> " + "Size set single quantity changed " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[x].OrderSizes[y].Singles + " was " + order.OrderBreakdown[x].OrderSizes[y].Singles + " against " + order.OrderBreakdown[x].OrderSizes[y].Size + "</b>";

                                          }
                                          if (order.OrderBreakdown[x].OrderSizes[y].RatioPack != Neworder.OrderBreakdown[x].OrderSizes[y].RatioPack)
                                          {
                                              Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> " + "Size set ratioPack changed " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[x].OrderSizes[y].Singles + " was " + order.OrderBreakdown[x].OrderSizes[y].Singles + " against " + order.OrderBreakdown[x].OrderSizes[y].Size + "</b>";

                                          }
                                          if (order.OrderBreakdown[x].OrderSizes[y].Ratio != Neworder.OrderBreakdown[x].OrderSizes[y].Ratio)
                                          {
                                              Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> " + "Size set ratio changed " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[x].OrderSizes[y].Singles + " was " + order.OrderBreakdown[x].OrderSizes[y].Singles + " against " + order.OrderBreakdown[x].OrderSizes[y].Size + "</b>";
                                          }
                                      }
                                    
                                    //if (order.OrderBreakdown[x].OrderSizes[y].Quantity != Neworder.OrderBreakdown[x].OrderSizes[y].Quantity)
                                    //{
                                    //  Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber + "</b> " + "Size set quantity changed " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[x].OrderSizes[y].Singles + " was " + order.OrderBreakdown[x].OrderSizes[y].Singles + " against " + order.OrderBreakdown[x].OrderSizes[y].Size + "</b>";
                                    //}
                                  }
                                  a++;
                                }
                                
                              //end
                                //if (order.OrderBreakdown[i].File != Neworder.OrderBreakdown[i].File)
                                //{
                                //    if (order.OrderBreakdown[i].File != string.Empty && order.OrderBreakdown[i].File != "null")
                                //    {
                                //        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Buyer Contract " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b>";
                                //        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                //        Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Buyer Contract " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].File.ToUpper() + " was " + order.OrderBreakdown[i].File.ToUpper() + "</b>";
                                //    }
                                //    else
                                //    {
                                //        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> New Buyer Contract uploaded by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b>";
                                //        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                //        Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> New Buyer Contract uploaded by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "  " + Neworder.OrderBreakdown[i].File.ToUpper() + "</b>";
                                //    }
                                //    a++;
                                //}
                                //if (order.OrderBreakdown[i].File2 != Neworder.OrderBreakdown[i].File2)
                                //{
                                //    if (order.OrderBreakdown[i].File2 != string.Empty && order.OrderBreakdown[i].File2 != "null")
                                //    {
                                //        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Buyer Contract(2) " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b>";
                                //        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                //        Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Buyer Contract(2) " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].File2.ToUpper() + " was " + order.OrderBreakdown[i].File2.ToUpper() + "</b>";
                                //    }
                                //    else
                                //    {
                                //        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> New Buyer Contract(2) uploaded by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b>";
                                //        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                //        Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> New Buyer Contract(2) uploaded by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "  " + Neworder.OrderBreakdown[i].File2.ToUpper() + "</b>";
                                //    }
                                //    a++;
                                //}
                                //if (order.OrderBreakdown[i].File3 != Neworder.OrderBreakdown[i].File3)
                                //{
                                //    if (order.OrderBreakdown[i].File3 != string.Empty && order.OrderBreakdown[i].File3 != "null")
                                //    {
                                //        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Buyer Contract(3) " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b>";
                                //        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                //        Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": In Order Form: " + "Buyer Contract(3) " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].File3.ToUpper() + " was " + order.OrderBreakdown[i].File3.ToUpper() + "</b>";
                                //    }
                                //    else
                                //    {
                                //        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> New Buyer Contract(3) uploaded by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b>";
                                //        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                //        Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> New Buyer Contract(3) uploaded by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "  " + Neworder.OrderBreakdown[i].File3.ToUpper() + "</b>";
                                //    }
                                //    a++;
                                //}
                                //if (order.OrderBreakdown[i].File4 != Neworder.OrderBreakdown[i].File4)
                                //{
                                //    if (order.OrderBreakdown[i].File4 != string.Empty && order.OrderBreakdown[i].File4 != "null")
                                //    {
                                //        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Buyer Contract(4) " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b>";
                                //        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                //        Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Buyer Contract(4) " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].File4.ToUpper() + " was " + order.OrderBreakdown[i].File4.ToUpper() + "</b>";
                                //    }
                                //    else
                                //    {
                                //        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> New Buyer Contract(4) uploaded by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b>";
                                //        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                //        Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> New Buyer Contract(4) uploaded by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "  " + Neworder.OrderBreakdown[i].File4.ToUpper() + "</b>";
                                //    }
                                //    a++;
                                //}
                                if (order.OrderBreakdown[i].Fabric1 != Neworder.OrderBreakdown[i].Fabric1)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Fabric1 " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Fabric1.ToUpper() + " was " + order.OrderBreakdown[i].Fabric1.ToUpper() + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Fabric1 " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Fabric1.ToUpper() + " was " + order.OrderBreakdown[i].Fabric1.ToUpper() + "</b>";
                                    a++;
                                }
                                //Edit by Ashish  on 1/4/20183
                                //if (order.OrderBreakdown[i].Fabric1Details != Neworder.OrderBreakdown[i].Fabric1Details)
                                //{
                                //    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " : " + "Fabric1Details " + type + " by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Fabric1Details.ToUpper() + " was " + order.OrderBreakdown[i].Fabric1Details.ToUpper();
                                //    a++;
                                //}
                                if (order.OrderBreakdown[i].Fabric1Desc != Neworder.OrderBreakdown[i].Fabric1Details)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Fabric1Details " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].Fabric1Details.ToUpper() + "</b> was <b>" + order.OrderBreakdown[i].Fabric1Details.ToUpper() + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Fabric1Details " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Fabric1Details.ToUpper() + " was " + order.OrderBreakdown[i].Fabric1Details.ToUpper() + "</b>";
                                    a++;
                                }
                                //End

                                if (order.OrderBreakdown[i].IAFabric1 != Neworder.OrderBreakdown[i].IAFabric1)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> " + Neworder.OrderBreakdown[i].IAFabric1 + " : " + "Fabric1 IA " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].IAFabric1 + " was " + order.OrderBreakdown[i].IAFabric1 + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> " + Neworder.OrderBreakdown[i].IAFabric1 + " : " + "Fabric1 IA " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].IAFabric1 + " was " + order.OrderBreakdown[i].IAFabric1 + "</b>";
                                    //a++;
                                }

                                if (order.OrderBreakdown[i].Fabric2 != Neworder.OrderBreakdown[i].Fabric2)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Fabric2 " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Fabric2.ToUpper() + " was " + order.OrderBreakdown[i].Fabric2.ToUpper() + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Fabric2 " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Fabric2.ToUpper() + " was " + order.OrderBreakdown[i].Fabric2.ToUpper() + "</b>";
                                    a++;
                                }
                                if (order.OrderBreakdown[i].Fabric2Details != Neworder.OrderBreakdown[i].Fabric2Details)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Fabric2Details " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Fabric2Details.ToUpper() + " was " + order.OrderBreakdown[i].Fabric2Details.ToUpper() + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Fabric2Details " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Fabric2Details.ToUpper() + " was " + order.OrderBreakdown[i].Fabric2Details.ToUpper() + "</b>";
                                    a++;
                                }
                                if (order.OrderBreakdown[i].IAFabric2 != Neworder.OrderBreakdown[i].IAFabric2)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b>" + Neworder.OrderBreakdown[i].IAFabric2 + " : " + "Fabric2 IA " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].IAFabric2 + " was " + order.OrderBreakdown[i].IAFabric2 + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> " + Neworder.OrderBreakdown[i].IAFabric2 + " : " + "Fabric2 IA " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].IAFabric2 + " was " + order.OrderBreakdown[i].IAFabric2 + "</b>";
                                    //a++;
                                }

                                if (order.OrderBreakdown[i].Fabric3 != Neworder.OrderBreakdown[i].Fabric3)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Fabric3 " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Fabric3.ToUpper() + " was " + order.OrderBreakdown[i].Fabric3.ToUpper() + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Fabric3 " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Fabric3.ToUpper() + " was " + order.OrderBreakdown[i].Fabric3.ToUpper() + "</b>";
                                    a++;
                                }
                                if (order.OrderBreakdown[i].Fabric3Details != Neworder.OrderBreakdown[i].Fabric3Details)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Fabric3Details " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Fabric3Details.ToUpper() + " was " + order.OrderBreakdown[i].Fabric3Details.ToUpper() + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Fabric3Details " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Fabric3Details.ToUpper() + " was " + order.OrderBreakdown[i].Fabric3Details.ToUpper() + "</b>";
                                    a++;
                                }
                                if (order.OrderBreakdown[i].IAFabric3 != Neworder.OrderBreakdown[i].IAFabric3)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b>" + Neworder.OrderBreakdown[i].IAFabric3 + " : " + "Fabric3 IA " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].IAFabric3 + " was " + order.OrderBreakdown[i].IAFabric3 + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b>" + Neworder.OrderBreakdown[i].IAFabric3 + " : " + "Fabric3 IA " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].IAFabric3 + " was " + order.OrderBreakdown[i].IAFabric3 + "</b>";
                                    //a++;
                                }

                                if (order.OrderBreakdown[i].Fabric4 != Neworder.OrderBreakdown[i].Fabric4)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Fabric4 " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Fabric4.ToUpper() + " was " + order.OrderBreakdown[i].Fabric4.ToUpper() + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Fabric4 " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Fabric4.ToUpper() + " was " + order.OrderBreakdown[i].Fabric4.ToUpper() + "</b>";
                                    a++;
                                }
                                if (order.OrderBreakdown[i].Fabric4Details != Neworder.OrderBreakdown[i].Fabric4Details)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Fabric4Details " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Fabric4Details.ToUpper() + " was " + order.OrderBreakdown[i].Fabric4Details.ToUpper() + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Fabric4Details " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Fabric4Details.ToUpper() + " was " + order.OrderBreakdown[i].Fabric4Details.ToUpper() + "</b>";
                                    a++;
                                }
                                if (order.OrderBreakdown[i].IAFabric4 != Neworder.OrderBreakdown[i].IAFabric4)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> " + Neworder.OrderBreakdown[i].IAFabric4 + " : " + "Fabric4 IA " + type + " by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].IAFabric4 + " was " + order.OrderBreakdown[i].IAFabric4 + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b>" + Neworder.OrderBreakdown[i].IAFabric4 + " : " + "Fabric4 IA " + type + " by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].IAFabric4 + " was " + order.OrderBreakdown[i].IAFabric4 + "</b>";
                                    //a++;
                                }

                                if (order.OrderBreakdown[i].Mode != Neworder.OrderBreakdown[i].Mode)
                                {
                                    string oldMode = iKandi.BLL.CommonHelper.GetOrderDeliveryMode(order.OrderBreakdown[i].Mode);
                                    string NewMode = iKandi.BLL.CommonHelper.GetOrderDeliveryMode(Neworder.OrderBreakdown[i].Mode);

                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Mode " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b> <b>" + NewMode.ToUpper() + "</b> was <b>" + oldMode.ToUpper() + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Mode " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + NewMode.ToUpper() + "</b> was <b>" + oldMode.ToUpper() + "</b>";
                                    a++;
                                }
                                if (order.OrderBreakdown[i].Quantity != Neworder.OrderBreakdown[i].Quantity)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Quantity " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].Quantity.ToString("N0") + "</b> was <b>" + order.OrderBreakdown[i].Quantity.ToString("N0") + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> Quantity " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].Quantity.ToString("N0") + "</b> was <b>" + order.OrderBreakdown[i].Quantity.ToString("N0") + "</b>";
                                    a++;
                                }
                                if (order.OrderBreakdown[i].ExFactory != Neworder.OrderBreakdown[i].ExFactory)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> ExFactory " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].ExFactory.ToString("dd MMM yy (ddd)") + "</b> was <b>" + order.OrderBreakdown[i].ExFactory.ToString("dd MMM yy (ddd)") + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> ExFactory " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].ExFactory.ToString("dd MMM yy (ddd)") + "</b> was <b>" + order.OrderBreakdown[i].ExFactory.ToString("dd MMM yy (ddd)") + "</b>";
                                    a++;
                                }

                                if (order.OrderBreakdown[i].DC != Neworder.OrderBreakdown[i].DC)
                                {
                                    NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> DC " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].DC.ToString("dd MMM yy (ddd)") + "</b> was <b>" + order.OrderBreakdown[i].DC.ToString("dd MMM yy (ddd)") + "</b>";
                                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> DC " + type + " by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].DC.ToString("dd MMM yy (ddd)") + "</b> was <b>" + order.OrderBreakdown[i].DC.ToString("dd MMM yy (ddd)") + "</b>";
                                    a++;
                                }
                                //Edit By Ashish on 2/4/2013
                                //if (order.OrderBreakdown[i].iKandiPrice.ToString("N2") != Neworder.OrderBreakdown[i].iKandiPrice.ToString("N2"))
                                //{
                                //    Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " : " + "iKandi Price changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].iKandiPrice.ToString("N2") + " was " + order.OrderBreakdown[i].iKandiPrice.ToString("N2");
                                //}

                                double BiplPrice = Convert.ToDouble(Neworder.OrderBreakdown[i].odBIPLPrice.ToString("N2"));
                                if (BiplPrice != Convert.ToDouble("0.0"))
                                {
                                    if (order.OrderBreakdown[i].odBIPLPrice.ToString("N2") != Neworder.OrderBreakdown[i].odBIPLPrice.ToString("N2"))
                                    {
                                        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> BIPL Price changed by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].odBIPLPrice.ToString("N2") + "</b> was <b>" + order.OrderBreakdown[i].odBIPLPrice.ToString("N2") + "</b>";
                                        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                        Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> BIPL Price changed by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].odBIPLPrice.ToString("N2") + "</b> was <b>" + order.OrderBreakdown[i].odBIPLPrice.ToString("N2") + "</b>";
                                    }
                                }

                                double ikandiprice = Convert.ToDouble(Neworder.OrderBreakdown[i].iKandiPrice.ToString("N2"));
                                if (ikandiprice != Convert.ToDouble("0.0"))
                                {
                                    if (order.OrderBreakdown[i].iKandiPrice.ToString("N2") != Neworder.OrderBreakdown[i].iKandiPrice.ToString("N2"))
                                    {
                                        NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> iKandi Price changed by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].iKandiPrice.ToString("N2") + "</b> was <b>" + order.OrderBreakdown[i].iKandiPrice.ToString("N2") + "</b>";
                                        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                        Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> <b>" + Neworder.OrderBreakdown[i].ContractNumber.ToUpper() + " </b> iKandi Price changed by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Neworder.OrderBreakdown[i].iKandiPrice.ToString("N2") + "</b> was <b>" + order.OrderBreakdown[i].iKandiPrice.ToString("N2") + "</b>";
                                    }
                                }
                                //End

                            }
                            else
                            {
                                NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b>  New Contract has been added <b>" + Neworder.OrderBreakdown[i].ContractNumber + "</b>";
                                this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                                Differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + order.SerialNumber.ToUpper() + "</b> New Contract has been added <b>" + Neworder.OrderBreakdown[i].ContractNumber + "</b>";
                            }
                            i++;
                        }
                    }
                }
            }
            return Differences;

        }
      //adedd by abhishek 
        public string RemoveDuplicateHistory(string history)
        {
          string[] StrResult = null; string results="";
          if (!string.IsNullOrEmpty(history))
          {
            string[] h = history.Split(new string[] { "</li></ul>" }, StringSplitOptions.RemoveEmptyEntries);
            StrResult = h.Distinct().ToArray();
            results = string.Join("</li></ul>", StrResult);          
          }
          return results;
        }
        #endregion
    }
}

