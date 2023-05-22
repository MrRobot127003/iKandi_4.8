using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL.Production;
using System.Data;
using iKandi.Web.Components;
using System.Net;
using System.IO;
using iKandi.BLL;
using System.Net.Mail;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Globalization;
using System.Threading;
using System.Drawing;
using iTextSharp;
using Pechkin;
using iTextSharp.text.html;
using System.Xml;
using System.Runtime.CompilerServices;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace iKandi.Web.Internal.Production
{
    public partial class POStitch : System.Web.UI.Page
    {
        ProductionController objProductionController = new ProductionController();
        string MailType = "Stitch Out House PO";
        string FitsPath = string.Empty;
        public int OrderDetailId
        {
            get;
            set;
        }
        public int LocationType
        {
            get;
            set;
        }
        public string StyleNumber
        {
            get;
            set;
        }
        public string PONumber
        {
            get;
            set;
        }
        iKandi.BLL.PermissionController PermissionControllerInstance = new BLL.PermissionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["OrderDetailId"] != null)
            {

                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);

            }
            else
                OrderDetailId = 33171;

            if (Request.QueryString["LocationType"] != null)
            {
                LocationType = Convert.ToInt32(Request.QueryString["LocationType"]);
            }
            else
                LocationType = 1;

            if (Request.QueryString["PONumber"] != null)
            {
                PONumber = Request.QueryString["PONumber"];
            }
            else
                PONumber = "";

            if (Request.QueryString["StyleNumber"] != null)
            {

                StyleNumber = Request.QueryString["StyleNumber"];

            }
            else
                StyleNumber = "DR 17135737 A";

            if (!IsPostBack)
            {

                BindDropDown();
                Bind();
            }
        }
        protected void BindDropDown()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = objProductionController.BindSAMDropDown(OrderDetailId);

            if (dt.Rows.Count > 0)
            {
                ddlSAMName.DataSource = dt;
                ddlSAMName.DataTextField = "SAMVALUE";
                ddlSAMName.DataValueField = "SAMVALUE";
                ddlSAMName.DataBind();
            }

            DataTable dt1 = new DataTable();
            dt1 = objProductionController.BindFinishSAMDropDown(OrderDetailId);

            if (dt1.Rows.Count > 0)
            {
                ddlfinishsam.DataSource = dt1;
                ddlfinishsam.DataTextField = "SAM";
                ddlfinishsam.DataValueField = "SAM";
                ddlfinishsam.DataBind();
            }
        }
        protected void Bind()
        {

            PO_StitchCutHouse objPO_StitchCutHouse = objProductionController.GetStitchHousePo(OrderDetailId, LocationType, PONumber);

            lblPoNumber.Text = objPO_StitchCutHouse.StitchPoNumber;
            txtDateofIssue.Text = objPO_StitchCutHouse.StitchDateofIssue == DateTime.MinValue ? "" : objPO_StitchCutHouse.StitchDateofIssue.ToString("dd MMM yy");
            txtAgreedQty.Text = objPO_StitchCutHouse.StitchAgreedQty == 0 ? "" : objPO_StitchCutHouse.StitchAgreedQty.ToString("N0");
            txtAgreedRate.Text = objPO_StitchCutHouse.StitchAgreedRate == 0 ? "" : objPO_StitchCutHouse.StitchAgreedRate.ToString();
            txtfinishrate.Text = objPO_StitchCutHouse.FinishAgreedRate == 0 ? "" : objPO_StitchCutHouse.FinishAgreedRate.ToString();
            txtDeliveryStartDate.Text = objPO_StitchCutHouse.StitchDeliveryStartDate == DateTime.MinValue ? "" : objPO_StitchCutHouse.StitchDeliveryStartDate.ToString("dd MMM yy");
            txtDeliveryEndDate.Text = objPO_StitchCutHouse.StitchDeliveryEndDate == DateTime.MinValue ? "" : objPO_StitchCutHouse.StitchDeliveryEndDate.ToString("dd MMM yy");
            txtDebitforLateDelivery.Text = objPO_StitchCutHouse.StitchDebitforLateDelivery == 0 ? "" : objPO_StitchCutHouse.StitchDebitforLateDelivery.ToString("N0");
            txtActualEndDate.Text = objPO_StitchCutHouse.StitchActualEndDate.Date == DateTime.MinValue ? "" : objPO_StitchCutHouse.StitchActualEndDate.ToString("dd MMM yy");
            txtDebitforAlteration.Text = objPO_StitchCutHouse.StitchDebitforAltration == 0 ? "" : objPO_StitchCutHouse.StitchDebitforAltration.ToString("N0");
            lblSupplierName.Text = objPO_StitchCutHouse.StitchSupplierName;
            chkVendorSig.Checked = objPO_StitchCutHouse.StitchSignature == true ? true : false;
            chkBIPLMngtSig.Checked = objPO_StitchCutHouse.StitchBIPLMngtSignature == true ? true : false;
            chkGMPlanningSig.Checked = objPO_StitchCutHouse.StitchGMPlanningSignature == true ? true : false;
            ddlSAMName.SelectedValue = objPO_StitchCutHouse.StitchSAM;
            txtStyleNumber.Text = objPO_StitchCutHouse.StitchStyleNo;
            txtSerialNumber.Text = objPO_StitchCutHouse.StitchSerialNo;
            ddlUnit.SelectedValue = objPO_StitchCutHouse.StitchUnit == "" ? "pcs" : objPO_StitchCutHouse.StitchUnit;
            //txtJob.Text = objPO_StitchCutHouse.Stitchjob;
            ddlStitchJob.SelectedValue = objPO_StitchCutHouse.Stitchjob == "" ? "Stich Out House" : objPO_StitchCutHouse.Stitchjob;
            if (objPO_StitchCutHouse.FinishSAM != "")
                ddlfinishsam.SelectedValue = objPO_StitchCutHouse.FinishSAM;

            txtArea.Text = objPO_StitchCutHouse.StitchRemarks;
            if (objPO_StitchCutHouse.StitchDateofIssue == DateTime.MinValue)
                txtDateofIssue.Text = DateTime.Now.ToString("dd MMM yy");

            chkGMPlanningSig.Enabled = ApplicationHelper.LoggedInUser.UserData.DesignationID == 19 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 111 ? true : false;
            chkBIPLMngtSig.Enabled = ApplicationHelper.LoggedInUser.UserData.DesignationID == 13 ? true : false;
            chkVendorSig.Enabled = ApplicationHelper.LoggedInUser.UserData.DesignationID == 46 || ApplicationHelper.LoggedInUser.UserData.DesignationID==158 ? true : false;


            lblVendorSigDate.Text = objPO_StitchCutHouse.StitchSignatureDate == DateTime.MinValue ? "" : objPO_StitchCutHouse.StitchSignatureDate.ToString("dd MMM yy (ddd)");
            lblBIPLMgntSigDate.Text = objPO_StitchCutHouse.StitchBIPLMngtSignatureDate == DateTime.MinValue ? "" : objPO_StitchCutHouse.StitchBIPLMngtSignatureDate.ToString("dd MMM yy (ddd)");
            lblGMPlanningSigDate.Text = objPO_StitchCutHouse.StitchGMPlanningSignatureDate == DateTime.MinValue ? "" : objPO_StitchCutHouse.StitchGMPlanningSignatureDate.ToString("dd MMM yy (ddd)");

            if (chkGMPlanningSig.Checked == false)
            {
                //chkVendorSig.Enabled = false;
                chkBIPLMngtSig.Enabled = false;
            }
            if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 19 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 111)
            {
                chkVendorSig.Enabled = true;
            }
            if (chkGMPlanningSig.Checked == true)
            {
                chkGMPlanningSig.Enabled = false;
                // chkVendorSig.Enabled = true;
                lblGMName.Visible = true;
                if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 46)
                {
                    if (chkVendorSig.Checked == true)
                    {
                        chkVendorSig.Enabled = false;
                        chkGMPlanningSig.Enabled = false;
                    }
                    else
                    {
                        chkVendorSig.Enabled = true;
                    }
                }
                if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 13)
                {
                    chkVendorSig.Enabled = false;
                    chkBIPLMngtSig.Enabled = true;
                }
            }
            if (chkVendorSig.Checked == true && chkGMPlanningSig.Enabled == true)
            {
                chkBIPLMngtSig.Enabled = false;
                chkVendorSig.Enabled = false;

            }
            if (chkVendorSig.Checked == true)
            {
                lblVendorName.Text = objPO_StitchCutHouse.StitchSupplierName;

            }
            if (chkBIPLMngtSig.Checked == true)
            {
                lblManagmentName.Visible = true;

            }



            DataTable dt = objProductionController.GetStitchHousePOHistory(OrderDetailId, LocationType, PONumber);
            string str = "";
            str = "<ul>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str += "<li>" + dt.Rows[i]["DetailsDescription"] + "</li>";
            }
            str += "</ul>";
            divHistory.InnerHtml = str;
            if (objPO_StitchCutHouse.StitchGMPlanningSignature == true)
            {
                chkGMPlanningSig.Enabled = false;
                //txtSerialNumber.Enabled = true;
                //txtStyleNumber.Enabled = true;
            }

            if (objPO_StitchCutHouse.StitchGMPlanningSignature == true)
                chkGMPlanningSig.Enabled = false;

            if (objPO_StitchCutHouse.StitchSignature == true)
                chkVendorSig.Enabled = false;

            if (objPO_StitchCutHouse.StitchBIPLMngtSignature == true)
                chkBIPLMngtSig.Enabled = false;

            //added by raghvinder on 28-08-2020 start
            //if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.REALLOCATION_FORM_SUBMIT_BUTTON))
            //{
            //    btnSubmit.Enabled = false;
            //}
            //added by raghvinder on 28-08-2020 starts

            DataTable dt_Permission = PermissionControllerInstance.GetUserPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, (int)iKandi.Common.AppModuleColumn.REALLOCATION_FORM_SUBMIT_BUTTON).Tables[0];
            bool readPermission = false;
            bool writePermission = false;

            for (int i = 0; i < dt_Permission.Rows.Count; i++)
            {
                readPermission = Convert.ToBoolean(dt_Permission.Rows[i]["PermisionRead"]);
                writePermission = Convert.ToBoolean(dt_Permission.Rows[i]["PermisionWrite"]);
            }

            if (writePermission == true)
            {
                btnSubmit.Enabled = true;
                
            }
            else
            {
                btnSubmit.Enabled = false;               
            }            
            //added by raghvinder on 28-08-2020 end
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;
            if (txtDateofIssue.Text == string.Empty)
            {
                ShowAlert("Date of Issue cannot blank!");
                txtDateofIssue.Focus();
                return;
            }
            if (txtAgreedQty.Text == string.Empty)
            {
                ShowAlert("Agreed Qty. cannot blank!");
                txtAgreedQty.Focus();
                return;
            }
            if (ddlSAMName.SelectedValue == "Select")
            {
                ShowAlert("Please select sam value!");
                ddlSAMName.Focus();
                return;
            }

            PO_StitchCutHouse ObjPoStitchHouse = new PO_StitchCutHouse();
            ObjPoStitchHouse.StitchDateofIssue = Convert.ToDateTime(txtDateofIssue.Text.Replace(",", ""));
            ObjPoStitchHouse.StitchAgreedQty = Convert.ToInt32(txtAgreedQty.Text.Replace(",", ""));
            ObjPoStitchHouse.StitchAgreedRate = txtAgreedRate.Text == "" ? 0 : Convert.ToDecimal(txtAgreedRate.Text);
            ObjPoStitchHouse.FinishAgreedRate = txtfinishrate.Text == "" ? 0 : Convert.ToDecimal(txtfinishrate.Text);
            ObjPoStitchHouse.StitchDeliveryStartDate = txtDeliveryStartDate.Text == "" ? DateTime.MinValue : Convert.ToDateTime(txtDeliveryStartDate.Text);
            ObjPoStitchHouse.StitchDeliveryEndDate = txtDeliveryEndDate.Text == "" ? DateTime.MinValue : Convert.ToDateTime(txtDeliveryEndDate.Text);
            ObjPoStitchHouse.StitchActualEndDate = txtActualEndDate.Text == "" ? DateTime.MinValue : Convert.ToDateTime(txtActualEndDate.Text);
            ObjPoStitchHouse.StitchDebitforLateDelivery = txtDebitforLateDelivery.Text == "" ? 0 : Convert.ToDecimal(txtDebitforLateDelivery.Text.Replace(",", ""));
            ObjPoStitchHouse.StitchDebitforAltration = txtDebitforAlteration.Text == "" ? 0 : Convert.ToDecimal(txtDebitforAlteration.Text.Replace(",", ""));
            ObjPoStitchHouse.StitchOrderDetailId = Convert.ToInt32(OrderDetailId);
            ObjPoStitchHouse.StitchLocationType = Convert.ToInt32(LocationType);
            ObjPoStitchHouse.StitchSupplierName = lblSupplierName.Text;
            ObjPoStitchHouse.StitchSignature = chkVendorSig.Checked == true ? true : false;
            ObjPoStitchHouse.StitchBIPLMngtSignature = chkBIPLMngtSig.Checked == true ? true : false;
            ObjPoStitchHouse.StitchGMPlanningSignature = chkGMPlanningSig.Checked == true ? true : false;
            ObjPoStitchHouse.StitchUnit = ddlUnit.SelectedValue;
            ObjPoStitchHouse.StitchUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            ObjPoStitchHouse.Stitchjob = ddlStitchJob.SelectedValue; ;
            ObjPoStitchHouse.StitchRemarks = txtArea.Text;
            ObjPoStitchHouse.StitchSerialNo = txtSerialNumber.Text;
            ObjPoStitchHouse.StitchStyleNo = txtStyleNumber.Text;
            ObjPoStitchHouse.StitchPoNumber = lblPoNumber.Text;
            ObjPoStitchHouse.StitchSAM = ddlSAMName.SelectedValue;
            ObjPoStitchHouse.FinishSAM = (ddlStitchJob.SelectedValue == "Stitch/Finish" ? (ddlfinishsam.Items.Count > 0 ? ddlfinishsam.SelectedValue : "") : "");
            string SupplierName = lblSupplierName.Text; ;

            int SaveValueadd = objProductionController.AddStitchHousePo(ObjPoStitchHouse);
            if (chkGMPlanningSig.Checked == true)
            {

                // Page.ClientScript.RegisterStartupScript(this.GetType(), "ConfirmAlert", "ShowConfirmAlert();", true);
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "confirm", "Confirm();", true);
                //string confirmValue = Request.Form["confirm_value"];
                var checkRadio = rdbYes.Checked;
                if (checkRadio == true)
                {
                    // randorPOValueadditionHtml();
                    randorHtml();
                    //string url = "http://localhost:5033/POStitchReplica.aspx?OrderDetailId=" + OrderDetailId + "&LocationType=" + LocationType + "&SupplierName=" + SupplierName + "&StyleNumber=" + StyleNumber;
                    // string url = "http://boutique.in/POStitchReplica.aspx?OrderDetailId=" + OrderDetailId + "&LocationType=" + LocationType + "&SupplierName=" + SupplierName + "&StyleNumber=" + StyleNumber;

                    string Attandence_url = "POStitchOutHouse_" + OrderDetailId + "_" + LocationType + ".pdf";
                    string url = "http://boutique.in:82/Uploads/Fits/" + Attandence_url;
                    
                    string EmailContent = HttpContent(url);
                    SendClientRegistrationEmail("test", "kumar", EmailContent, MailType, lblSupplierName.Text);
                }

            }

            ShowAlert("Saved Successfully!");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ClosePO", "funcReloadClosePO()", true);

            return;
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        public void ShowConfirmed(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "confirm('" + myStringVariable + "');", true);
        }

        //public void randorPOValueadditionHtml()
        //{
        //    WebResponse response;
        //    WebRequest quest;
        //    StreamReader reader;
        //    string strHTML;

        //    quest = WebRequest.Create("http://boutique.in:82/POStitchMail.aspx?OrderDetailId=" + OrderDetailId + "&LocationType=" + LocationType);
        //    quest.Timeout = Convert.ToInt32(99999999);
        //    response = quest.GetResponse();
        //    reader = new StreamReader(response.GetResponseStream());
        //    strHTML = reader.ReadToEnd();
        //    string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Fits/" + "POStitchOutHouse_" + OrderDetailId + "_"+ LocationType +".pdf");
        //    iTextSharp.text.Document document = new iTextSharp.text.Document();
        //    PdfWriter.GetInstance(document, new FileStream(strFileName, FileMode.Create));
        //    StringReader se = new StringReader(strHTML);
        //    HTMLWorker obj = new HTMLWorker(document);
        //    document.Open();
        //    obj.Parse(se);
        //    document.Close();

        //}
        public void randorHtml()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            
            string strHTML;
            //quest = WebRequest.Create("http://localhost:3240/POStitchMail.aspx?OrderDetailId=" + OrderDetailId + "&LocationType=" + LocationType + "&StyleNumber=" + StyleNumber);
            quest = WebRequest.Create("http://boutique.in/POStitchMail.aspx?OrderDetailId=" + OrderDetailId + "&LocationType=" + LocationType + "&StyleNumber=" + StyleNumber);
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());
            strHTML = reader.ReadToEnd();
            genertaePdf(strHTML, "ss");
        }
        public void genertaePdf(string HTMLCode, string PolicyFile)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "POStitchOutHouse_" + OrderDetailId + "_" + LocationType + ".pdf");
            HTMLCode = getImage(HTMLCode);
            getvartypeHTML(HTMLCode, strFileName);
        }
        public void getvartypeHTML(string HTMLCode, string PolicyFile)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "POStitchOutHouse_" + OrderDetailId + "_" + LocationType + ".pdf");

            using (IPechkin pechkin = Factory.Create(new GlobalConfig()))
            {
                var pdf = pechkin.Convert(new ObjectConfig()
                                        .SetLoadImages(true).SetZoomFactor(1.5)
                                        .SetPrintBackground(true)
                                        .SetScreenMediaType(true)
                                        .SetCreateExternalLinks(true), (HTMLCode));
                using (FileStream file = System.IO.File.Create(strFileName))
                {
                    file.Write(pdf, 0, pdf.Length);
                }
            }
        }
        public string getTitle(string input)
        {
            if (input == null)
                return string.Empty;
            string tempInput = input;
            string pattern = @"(?<=<title.*>)([\s\S]*)(?=</title>)";
            string title = string.Empty;

            //get and remove Title in HTML..
            foreach (Match m1 in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline))
            {
                if (m1.Success)
                {
                    string tempM = m1.Value;
                    try
                    {
                        //tempM = tempM.Remove(m1.Index, m1.Length);
                        tempM = tempM.Replace(m1.Value, title);

                        //insert new url img tag in whole html code
                        //tempInput = tempInput.Remove(m1.Index, m1.Length);
                        tempInput = tempInput.Replace(m1.Value, tempM);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                        System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    }
                }
                else
                {
                    return "";
                }
            }
            return tempInput;
        }
        public string getImage(string input)
        {
            if (input == null)
                return string.Empty;
            string tempInput = input;
            string pattern = @"<img(.|\n)+?>";
            string src = string.Empty;
            HttpContext context = HttpContext.Current;

            //Change the relative URL's to absolute URL's for an image, if any in the HTML code.
            foreach (Match m in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline |

            RegexOptions.RightToLeft))
            {
                if (m.Success)
                {
                    string tempM = m.Value;
                    string pattern1 = "src=[\'|\"](.+?)[\'|\"]";
                    Regex reImg = new Regex(pattern1, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    Match mImg = reImg.Match(m.Value);

                    if (mImg.Success)
                    {
                        src = mImg.Value.ToLower().Replace("src=", "").Replace("\"", "");
                        if (src == "../../signatured.jpg" || src == "../signatured.jpg")
                        {
                            string imgsrc = @Server.MapPath("~/Signature/SignatureD.jpg");
                            src = "src=\"" + imgsrc + "\"";
                        }
                        if (src == "../../signdt.jpg" || src == "../signdt.jpg")
                        {
                            string imgsrc = @Server.MapPath("~/Signature/signdt.jpg");
                            src = "src=\"" + imgsrc + "\"";
                        }
                        if (src.ToLower().Contains("http://") == false)
                        {

                            try
                            {
                                tempM = tempM.Remove(mImg.Index, mImg.Length);
                                tempM = tempM.Insert(mImg.Index, src);

                                //insert new url img tag in whole html code
                                tempInput = tempInput.Remove(m.Index, m.Length);
                                tempInput = tempInput.Insert(m.Index, tempM);
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                                //string imgsrc = @Server.MapPath("~/imgSignature/" + dt + ".jpg");
                                //string html = "<html><div><img src='" + imgsrc + "'</div></html>";
                                //generatepdf(html);
                                //File.Delete(imgsrc);
                            }
                        }
                    }
                }
            }
            return tempInput;
        }
        public void CreatePDFDocument(string strHtml)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "POStitchOutHouse_" + OrderDetailId + "_" + LocationType + ".pdf");
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter.GetInstance(document, new FileStream(strFileName, FileMode.Create));
            StringReader se = new StringReader(strHtml);
            HTMLWorker obj = new HTMLWorker(document);
            document.Open();
            obj.Parse(se);
            document.Close();
        }


        public static string HttpContent(string url)
        {
            string result = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Timeout = 80000000;
                req.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E)";

                using (var resp = req.GetResponse())
                {
                    result = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message.ToString();
            }

            return result;
        }


        public Boolean SendClientRegistrationEmail(String ClientName, String UsernamePasswordList, String ToEmail, string MailType, string SupplierName)
        {

            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL"); //Constants.KEY_FROM_EMAIL

                //Abhishek
                List<String> to = new List<String>();

                NotificationController objcontroller = new NotificationController();
                DataSet ds = objcontroller.GetSupplierNameMail(SupplierName);
                DataTable dt = ds.Tables[0];

                string email = ds.Tables[0].Rows[0]["EmailName"].ToString();
                string[] email2 = email.Split(',');
                foreach (string em in email2)
                {
                    to.Add(em);
                }
                // Forcefully adding the email id on the request of Vijay
                to.Add("Bipl_fabric@boutique.in");
                //End
                List<Attachment> atts = new List<Attachment>();

                if (File.Exists(Constants.FITS_FOLDER_PATH + "POStitchOutHouse_" + OrderDetailId + "_" + LocationType + ".pdf"))
                {

                    FitsPath = Path.Combine(Constants.FITS_FOLDER_PATH, "POStitchOutHouse_" + OrderDetailId + "_" + LocationType + ".pdf");
                    atts.Add(new Attachment(FitsPath));
                }

                this.SendEmail(fromName, to, null, null, ToEmail, MailType, atts, false, false);



                return true;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return false;
            }
        }


        public Boolean SendEmail(String FromEmail, List<String> To, List<String> CC, List<String> BCC, String Subject, String Content, List<Attachment> Attachments, Boolean hasAppendAttachment, Boolean isAsync)
        {
            //System.Diagnostics.Debugger.Break();


            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = MailType;
            mailMessage.IsBodyHtml = true;


            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Subject, null, "text/html");
            mailMessage.AlternateViews.Add(htmlView);

            if (hasAppendAttachment && Attachments != null)
            {
                int i = 1;

                foreach (Attachment attachment in Attachments)
                {
                    if (attachment.ContentStream.Length > 0)
                    {
                        LinkedResource imageId = new LinkedResource(attachment.ContentStream, "image/jpeg");
                        imageId.ContentId = "imageId" + i.ToString();
                        imageId.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                        htmlView.LinkedResources.Add(imageId);
                    }

                    i++;
                }
            }
            else
            {
                mailMessage.Body = Subject;
            }

            Boolean isDebug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["isDebug"]);
            //Boolean isDebug = false;

            if (isDebug)
            {
                // TODO
                mailMessage.To.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.Bcc.Add(Constants.WEBMASTER_EMAIL);
            }
            else
            {
                foreach (String to in To)
                    mailMessage.To.Add(to);
                mailMessage.Bcc.Add("samrat@boutique.in");
                mailMessage.CC.Add("karan@boutique.in");
                mailMessage.CC.Add("vinaygupta@boutique.in");
                mailMessage.CC.Add("baldev@boutique.in");
                //mailMessage.CC.Add("shivraj@boutique.in");
                //mailMessage.CC.Add("atish@boutique.in");
                mailMessage.CC.Add("itsupport@boutique.in");
                //if (CC != null)
                //    foreach (String to in CC)
                //        mailMessage.CC.Add(to);

                //if (BCC != null)
                //    foreach (String to in BCC)
                //        mailMessage.Bcc.Add(to);


                mailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);


            }

            SmtpClient smtpClient = new SmtpClient(Constants.SMTP_HOST, Constants.SMTP_PORT);

            if (!hasAppendAttachment && Attachments != null)
            {
                foreach (Attachment att in Attachments)
                {
                    mailMessage.Attachments.Add(att);
                }
            }

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Timeout = Constants.SMTP_TIMEOUT;

            if (Constants.SMTP_SECURE)
            {
                smtpClient.EnableSsl = true;
            }

            if (Constants.SMTP_IS_AUTH_REQUIRED)
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(Constants.SMTP_USERNAME, Constants.SMTP_PASSWORD);
            }
            try
            {
                smtpClient.Timeout = 300000;
                smtpClient.Send(mailMessage);
                System.Diagnostics.Trace.WriteLine("Email Having Subject of --" + Subject.ToString() + " is send successfully on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                ShowAlert("Mail Sent successfully");
                return true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Some error has been occur in Email having subject of ---" + Subject.ToString() + " On" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                System.Diagnostics.Trace.WriteLine("Sorry !! Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                return false;
            }

            finally
            {
                try
                {
                    if (Attachments != null)
                    {
                        foreach (Attachment att in Attachments)
                        {
                            att.Dispose();
                        }

                        Attachments = null;
                    }

                    foreach (Attachment att in mailMessage.Attachments)
                    {
                        att.Dispose();
                    }

                    mailMessage = null;

                }
                catch (Exception ex) 
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
        }
    }
}