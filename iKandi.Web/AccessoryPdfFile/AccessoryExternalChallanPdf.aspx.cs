using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;
using System.Data;

namespace iKandi.Web.AccessoryPdfFile
{
    public partial class AccessoryExternalChallanPdf : System.Web.UI.Page
    {
        public int SupplierPoId
        {
            get;
            set;
        }
        public int ChallanId
        {
            get;
            set;
        }
        public int UserId
        {
            get;
            set;
        }
        string host = "";
        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();
        AccessoryQualityController ObjAccessoryQlty = new AccessoryQualityController();

        protected void Page_Load(object sender, EventArgs e)
        {
            host = "http://" + Request.Url.Authority;
            GetQueryString();
            if (!IsPostBack)
            {
                BindChallanProcess();
                BindData();
                DataTable dt = objAccessoryWorking.Getbipladdress("BIPLAddress3");
                divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();
            }

        }
        private void GetQueryString()
        {
            if (Request.QueryString["SupplierPoId"] != null)
            {
                SupplierPoId = Convert.ToInt32(Request.QueryString["SupplierPoId"]);
            }
            else
            {
               SupplierPoId = 0;
               //SupplierPoId = 154;
            }
            if (Request.QueryString["ChallanId"] != null)
            {
                ChallanId = Convert.ToInt32(Request.QueryString["ChallanId"]);
            }
            else
            {
                ChallanId = 0;
                //ChallanId = 124;
            }
            if (Request.QueryString["UserId"] != null)
            {
                UserId = Convert.ToInt32(Request.QueryString["UserId"]);
            }
            else
            {
                UserId = 0;
                //UserId = 96;
            }

        }

        private void BindChallanProcess()
        {
            //List<ChallanProcess> ChallanProcessList = objAccessoryWorking.GetChallanProcessList(ChallanId);
            DataTable dt = objAccessoryWorking.GetChallanProcessListForPdf(ChallanId);
            
            //chkProcess.DataSource = ChallanProcessList;
            //chkProcess.DataTextField = "ProcessName";
            //chkProcess.DataValueField = "ChallanProcessId";
            //chkProcess.DataBind();

            //for (int i = 0; i < chkProcess.Items.Count; i++)
            //{
            //    chkProcess.Items[i].Selected = ChallanProcessList[i].IsChecked;
            //}
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool ischecked = dt.Rows[i]["IsChecked"]==DBNull.Value ? false : Convert.ToBoolean(dt.Rows[i]["IsChecked"]);
                if(ischecked)
                {
                    if (lblCheckedList.Text == "")
                    {
                        lblCheckedList.Text = dt.Rows[i]["ProcessName"] == DBNull.Value ? "" : dt.Rows[i]["ProcessName"].ToString();
                    }
                    else
                    {
                        //if (i == dt.Rows.Count - 1)
                        //{
                        //    lblCheckedList.Text = lblCheckedList.Text + " ," + (dt.Rows[i]["ProcessName"] == DBNull.Value ? "" : dt.Rows[i]["ProcessName"].ToString());
                        //}
                        //else
                        //{
                            lblCheckedList.Text = lblCheckedList.Text + ", " + (dt.Rows[i]["ProcessName"] == DBNull.Value ? "" : dt.Rows[i]["ProcessName"].ToString());
                        //}
                    }
                    
                }
            }            
        }

        private void BindData()
        {
            //boutiqueImg.ImageUrl = host + "/images/boutique-logo.png";
            boutiqueImg.ImageUrl = host + "/images/200x50 bipllog.png";

            AccessoryChallanCls objAccessoryChallan = new AccessoryChallanCls();
            //int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;            

            objAccessoryChallan = objAccessoryWorking.Get_AccessorySendChallan(SupplierPoId, ChallanId, UserId);


            hdnChallan.Value = objAccessoryChallan.ChallanId.ToString();
            lblPoNo.Text = objAccessoryChallan.PoNumber.ToString();
            lblSupplierName.Text = objAccessoryChallan.SupplierName;
            //txtDescription.Text = objAccessoryChallan.ChallanDesc;            
            lblDescription.Text = objAccessoryChallan.ChallanDesc.Replace("\r\n","<br>");
            //rajeevS
            string HSNCode = objAccessoryChallan.HSNCode;
            if (HSNCode == "")
            {
                spn_HSNCode.InnerHtml = "";
                lblHSNcode.Visible = false;
            }
            else
            {
                lblHSNcode.Visible = true;
                spn_HSNCode.InnerHtml = "HSNCode";
                lblHSNcode.Text = HSNCode;
            }
            //rajeevS
            lblChallan.Text = objAccessoryChallan.ChallanNumber;
            lblAccessoryQuality.Text = objAccessoryChallan.AccessoryName;

            if (objAccessoryChallan.Size != "")
                lblSize.Text = objAccessoryChallan.Size == "Default" ? "" : "(" + objAccessoryChallan.Size + ")";

            lblcolorprint.Text = objAccessoryChallan.Color_Print;

            if (ChallanId > 0)
            {
                lblChallanDate.Text = objAccessoryChallan.ChallanDate.ToString("dd MMM yy (ddd)");
            }
            else
            {
                lblChallanDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");

                //for (int i = 0; i < chkProcess.Items.Count; i++)
                //{
                //    if (chkProcess.Items[i].Text == "Process")
                //    {
                //        chkProcess.Items[i].Selected = true;
                //    }
                //}
            }
            ddlType.SelectedValue = "1";
            ddlType.Attributes.Add("disabled", "disabled");

            //txtSendQty.Text = objAccessoryChallan.SendChallanQty == 0 ? "" : objAccessoryChallan.SendChallanQty.ToString("N0");
            lblSendQty.Text = objAccessoryChallan.SendChallanQty == 0 ? "" : objAccessoryChallan.SendChallanQty.ToString("N0");            
            hdnSendQty.Value = objAccessoryChallan.SendChallanQty.ToString();
            if (lblSendQty.Text != "")
            {
                lblSendQtyUnitName.Text = objAccessoryChallan.GarmentUnitName;
            }
            else
            {
                lblSendQtyUnitName.Text = "";
            }

            hdnIsUnitChange.Value = objAccessoryChallan.UnitChange == true ? "1" : "0";
            hdnConversionValue.Value = objAccessoryChallan.ConversionValue.ToString();

            hdnRemainingQty.Value = objAccessoryChallan.Remaining_SendQty.ToString();

            if (objAccessoryChallan.Remaining_SendQty == 0)
            {
                tdRemainingQuantity.Attributes.Add("style", "display:none");                
            }
            lblRemainingQty.Text = objAccessoryChallan.Remaining_SendQty == 0 ? "" : objAccessoryChallan.Remaining_SendQty.ToString("N0");


            lblRemainingQtyUnitName.Text = objAccessoryChallan.Remaining_SendQty == 0 ? "" : objAccessoryChallan.GarmentUnitName;

            if (objAccessoryChallan.UnitChange == true)
            {
                hdnDefaultSendQty.Value = objAccessoryChallan.Default_SendChallanQty.ToString();
                lblDefaultSendQty.Text = objAccessoryChallan.Default_SendChallanQty == 0 ? "" : objAccessoryChallan.Default_SendChallanQty.ToString("N0");
                hdnDefault_SendQtyUnitName.Value = objAccessoryChallan.DefaultGarmentUnitName;
                lblDefault_SendQtyUnitName.Text = objAccessoryChallan.SendChallanQty > 0 ? objAccessoryChallan.DefaultGarmentUnitName : "";


                hdnDefaultRemainingQty.Value = objAccessoryChallan.Default_Remaining_SendQty.ToString();
                lblDefaultRemainingQty.Text = objAccessoryChallan.Default_Remaining_SendQty == 0 ? "" : objAccessoryChallan.Default_Remaining_SendQty.ToString("N0");
                lblDefault_RemainingQtyUnitName.Text = objAccessoryChallan.Default_Remaining_SendQty == 0 ? "" : objAccessoryChallan.DefaultGarmentUnitName;
            }


            //String imgPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"];

            if (objAccessoryChallan.IsPartySignature == true)
            {
                chkReciever.Visible = false;
                lblRecierverDate.Text = objAccessoryChallan.ReceivedDate == DateTime.MinValue ? "" : objAccessoryChallan.ReceivedDate.ToString("dd MMM yy (ddd)");
                //imgpartysingature.ImageUrl = imgPath + objAccessoryChallan.RecievedSignature;
                imgpartysingature.ImageUrl = objAccessoryChallan.AuthSignature != string.Empty ? host + "/Uploads/Photo/" + objAccessoryChallan.AuthSignature : host + "/Uploads/Photo/NotSign.jpg";
                lblRecieverSign.Text = objAccessoryChallan.RecievedBy;
            }

            if (objAccessoryChallan.IsAuthorizedSignatory == true)
            {
                chkAuthorise.Visible = false;
                lblAuthoriseDate.Text = objAccessoryChallan.AuthorizedDate == DateTime.MinValue ? "" : objAccessoryChallan.AuthorizedDate.ToString("dd MMM yy (ddd)");
                //imgAuthorizedSignatory.ImageUrl = imgPath + objAccessoryChallan.AuthSignature;
                imgAuthorizedSignatory.ImageUrl = objAccessoryChallan.AuthSignature != string.Empty ? host + "/Uploads/Photo/" + objAccessoryChallan.AuthSignature : host + "/Uploads/Photo/NotSign.jpg";
                lblAuthoRiseSign.Text = objAccessoryChallan.AuthoriseBy;
            }
            if ((objAccessoryChallan.IsPartySignature == true) && (objAccessoryChallan.IsAuthorizedSignatory == true))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "disablePage();", true);                
            }
        }       
    }
}