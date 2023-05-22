using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using iKandi.BLL;
using iKandi.Web.Components;
using System.Collections.Generic;
using iKandi.Common;
using System.Net;
using System.IO;

using Pechkin;
using System.Net.Mail;

using System.Text.RegularExpressions;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace iKandi.Web
{
    public partial class iKandiService
    {
        [WebMethod(EnableSession = true)]
        public List<String> SuggestAccessoryName(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.AccessoryName.ToString(), limit);
        }
        [WebMethod(EnableSession = true)]
        public List<String> UnregisterdAcc(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.UnRegAccessoryName.ToString(), limit);
        }
        [WebMethod(EnableSession = true)]
        public string GetFabricAccessoryPhotosView(int ID, int Type)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("Id", ID);
            properties.Add("Type", Type);

            return PageHelper.GetControlHtml("~/UserControls/Lists/ShowFabricAccessoryPhotos.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public int GetAccIdByTradeName(string TradeName)
        {
            //System.Diagnostics.Debugger.Break();
            return this.AccessoryQualityControllerInstance.GetAccIdByTradeName(TradeName);
        }

        [WebMethod(EnableSession = true)]
        public bool ImageAccessoryDelete(int ImageId)
        {
            //System.Diagnostics.Debugger.Break();
            return this.AccessoryQualityControllerInstance.DeleteAccessoryQualityPicture(ImageId);
        }

        [WebMethod(EnableSession = true)]
        public List<String> SuggestAccessoryTradeName(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.RegisteredAccessoryTradeName.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public string GetAccessoryQualityView(int AccessoryQualityID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("AccessoryQualityID", AccessoryQualityID);

            return PageHelper.GetControlHtml("~/UserControls/Lists/AccessoryQualityPopup.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetAccessoryInfoView(int AccessoryWorkingDetailID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("AccessoryWorkingDetailID", AccessoryWorkingDetailID);
            return PageHelper.GetControlHtml("~/UserControls/Lists/AccessoryInfoPopup.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public int Stock_Qty_Update_ToRaise_DebitNote(int SupplierPO_Id, int InspectionID, int flag, int StockQty)
        {
            return this.AccessoryQualityControllerInstance.Stock_Qty_Update_ToRaise_DebitNote(SupplierPO_Id, InspectionID, flag, StockQty);
        }

        // Added by Shubehndu  on 28-01-2022
        [WebMethod(EnableSession = true)]
        public int UpdateAccessoryGMSignature(int isGmChecked, decimal FailedRaisedDebit, decimal FailedStock, decimal FailedGoodStock, decimal InspectRaisedDebit, decimal InspectUsableStock, int Srv_id)
        {
            return this.AccessoryQualityControllerInstance.UpdateAccessoryGMSignature(isGmChecked, FailedRaisedDebit, FailedStock, FailedGoodStock, InspectRaisedDebit, InspectUsableStock, Srv_id);
        }
        // Added By shubhendu 29/08/2022
        [WebMethod(EnableSession = true)]
        public List<string> SuggestAccessoryByName(string q, string limit,string flag,string TradeName="")
        {
            return this.AccessoryQualityControllerInstance.SuggestAccessoryByName(q,flag,TradeName);
        }

        [WebMethod(EnableSession = true)]
        public AccessoryPending Update_AccessoryPending_Orders(int OrderDetailID, int AccessoryworkingdetailId, int Stage1, int Stage2)
        {
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

            return this.AccessoryWorkingControllerInstance.Update_AccessoryPending_Orders(OrderDetailID, AccessoryworkingdetailId, Stage1, Stage2, UserId);
        }
        //Updated by girish on dated 18 jul 2022
        [WebMethod(EnableSession = true)]
        public int Save_Accessory_Supplier_Quotation(int SupplierID, int AccessoryMasterId, string Size, string ColorPrint, double QuotedLandedRate, int type)
        {
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            return this.AccessoryWorkingControllerInstance.Save_Accessory_Supplier_Quotation(SupplierID, AccessoryMasterId, Size, ColorPrint, QuotedLandedRate, UserId, type);
        }
        //End of code
        //added by shubhendu on 8/02/2022
        [WebMethod(EnableSession = true)]
        public int UpdateAccessoryRemarks(string Po_number, string CommentRemarks, int UserId)
        {

            return this.AccessoryWorkingControllerInstance.UpdateAccessoryRemarks(Po_number, CommentRemarks, UserId);
        }
        //Added by girish on dated 18 jul 2022
        [WebMethod(EnableSession = true)]
        public List<AccessoryPending> GetAccessory_SupplierCode( int AccessoryMasterId, string Size, string ColorPrint, int SupplierId, int AccessoryType)
        {
            return this.AccessoryWorkingControllerInstance.GetAccessory_SupplierCode( AccessoryMasterId, Size, ColorPrint, SupplierId, AccessoryType);
        }
        // End of Code
        //[WebMethod(EnableSession = true)]
        //public List<AccessoryPending> GetAccessory_SupplierCode(int AccessoryMasterId, string Size, string ColorPrint, int SupplierId, int AccessoryType)
        //{
        //    return this.AccessoryWorkingControllerInstance.GetAccessory_SupplierCode(AccessoryMasterId, Size, ColorPrint, SupplierId, AccessoryType);
        //}

        [WebMethod(EnableSession = true)]
        public int Delete_AccessoryPO(int SupplierPoId)
        {
            return this.AccessoryWorkingControllerInstance.Delete_AccessoryPO(SupplierPoId);
        }

        [WebMethod(EnableSession = true)]
        public bool AccessoryCancel_Close_PO(int SupplierPoId, string field)
        {
            return this.AccessoryWorkingControllerInstance.AccessoryCancel_Close_PO(SupplierPoId, field);
        }

        //added by raghvinder on 23-03-2021 start
        //added by raghvinder on 23-10-2020 start
        [WebMethod(EnableSession = true)]
        public decimal GetAccessory_ConversionValue(int CurrentUnitId, int PreviousUnitId)
        {
            decimal iSave = this.AccessoryWorkingControllerInstance.GetAccessory_ConversionValue(CurrentUnitId, PreviousUnitId);
            return iSave;
        }
        //added by raghvinder on 23-03-2021 end

        //added by raghvinder on 23-10-2020 start
        [WebMethod(EnableSession = true)]
        public int Save_Accessory_Average(string Type, float Avg, int Unit, int OrderID, int AccWorkingDetailId, bool CheckValue, int CreatedBy)
        {
            int iSave = this.AccessoryWorkingControllerInstance.Save_Accessory_Average(Type, Avg, Unit, OrderID, AccWorkingDetailId, CheckValue, CreatedBy);
            return iSave;
        }

        //added by raghvinder on 23-10-2020 start
        //[WebMethod(EnableSession = true)]
        //public int Save_Accessory_Description(string Type, string ComVal)
        //{
        //    int iSave = this.AccessoryWorkingControllerInstance.Save_Accessory_Description(Type, ComVal);
        //    return iSave;
        //}   

        [WebMethod(EnableSession = true)]
        public int Update_SupplierPo_PartySignature(int SupplierPoId, int IsPartySignature)
        {
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            return this.AccessoryWorkingControllerInstance.Update_SupplierPo_PartySignature(SupplierPoId, IsPartySignature, UserId);
        }

        //added by bharat on 17-09-2020 start
        [WebMethod(EnableSession = true)]
        public string Save_UnRagisterAccessories(string AccessoriesName, string AccessoryRateSize)
        {
            return this.AccessoryQualityControllerInstance.Save_UnRagisterAccessories(AccessoriesName, AccessoryRateSize);
        }
        //added by bharat on 17-09-2020 end

        [WebMethod(EnableSession = true)]
        public string Get_UnRagisterAccessories(string Tradename)
        {
            return this.AccessoryQualityControllerInstance.Get_UnRagisterAccessories(Tradename);
        }

        [WebMethod(EnableSession = true)]
        public string CheckChallanNumber(int SupplierPoId, int SRV_Id, string PartyChallanNumber)
        {
            return this.AccessoryWorkingControllerInstance.CheckChallanNumber(SupplierPoId, SRV_Id, PartyChallanNumber);
        }
        [WebMethod(EnableSession = true)]
        public string Save_Accessory_Description(int OrderDetailId, string ComVal)
        {
            return this.AccessoryWorkingControllerInstance.Save_Accessory_Description(OrderDetailId, ComVal);
        }
        // Added by shubhendu 4/02/2022
        [WebMethod(EnableSession = true)]
        public string Save_Accessory_AccessoryRemarks(int orderid, string ComVal)
        {
            return this.AccessoryWorkingControllerInstance.Save_Accessory_AccessoryRemarks(orderid, ComVal);
        }
        [WebMethod(EnableSession = true)]
        public List<AccessoryPending> GetPOAccesoryHistory(int SupplierPOId)
        {
            return this.AccessoryWorkingControllerInstance.GetPOAccesoryHistory(SupplierPOId);
        }

        [WebMethod(EnableSession = true)]
        public List<AccessoryQualityIssuing> GetChallanDetailsByOrderDetailId(int OrderDetailId, int AccessoryMasterId, string Size, string ColorPrint)
        {
            return this.AccessoryWorkingControllerInstance.GetChallanDetailsByOrderDetailId(OrderDetailId, AccessoryMasterId, Size, ColorPrint);
        }
        [WebMethod(EnableSession = true)]
        public List<GroupUnit> Get_AccessoryDDL_ForOrder(int OrderId, int AccessoryWorkingDetailId)
        {
            return this.AccessoryQualityControllerInstance.Get_AccessoryDDL_ForOrder(OrderId, AccessoryWorkingDetailId);
        }

        [WebMethod(EnableSession = true)]
        public List<AccessoryPending> UnitMastEdt(string ID)
        {
            return this.AccessoryQualityControllerInstance.UnitMastEdt(ID);
        }

        [WebMethod(EnableSession = true)]
        public string UpdateAccQuality(Boolean isDefalt, int CatGroupID, int AccessoryMasterId, string AccQuality, int ClientId, int ParentDeptId, int DeptId, string DefaultTradeName, int Wastage, int Shrinkage, int GarmentUnit)
        {
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            return this.AccessoryQualityControllerInstance.UpdateAccQuality(isDefalt, CatGroupID, AccessoryMasterId, AccQuality, ClientId, ParentDeptId, DeptId, DefaultTradeName, Wastage, Shrinkage, GarmentUnit, UserId);
        }

        #region Mail Function by sanjeev
        [WebMethod(EnableSession = true)]
        public void SendAccessoryPoMail(int SupplierPO_Id)
        {
            AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();
            DataTable Dt = objAccessoryWorking.Get_AccessoryPODetail(SupplierPO_Id);
            if (Dt.Rows.Count > 0)
            {
                string PO_Number = Dt.Rows[0]["PO_Number"].ToString();
                string AccessoryType = Dt.Rows[0]["AccessoryType"].ToString();
                string AccessoryStage = Dt.Rows[0]["AccessoryStage"].ToString();
                string AccessoryMasterId = Dt.Rows[0]["AccessoryMasterId"].ToString();
                string Size = Dt.Rows[0]["Size"].ToString();
                string Color_Print = Dt.Rows[0]["Color_Print"].ToString();
                string PoStatus = Dt.Rows[0]["PoStatus"].ToString();
                string SupplierEmail = Dt.Rows[0]["SupplierEmail"].ToString();
                string AccessoryQualityName = Dt.Rows[0]["AccessoryQualityName"].ToString();
                randorccessoryHtmlAndSendMail(PO_Number, AccessoryType, AccessoryStage, AccessoryMasterId, AccessoryQualityName, Size, Color_Print, SupplierPO_Id.ToString(), PoStatus, SupplierEmail);
            }

        }
        public void randorccessoryHtmlAndSendMail(string AccessoryPoNo, string AccessoryType, string AccessoryStage, string AccessoryMasterId, string AccessoryQualityName, string Size, string ColorPrint, string SupplierPoId, string PoStatus, string SupplierEmail)
        {
            LogFileWrite("Render Html Start");
            WebRequest Request;
            WebResponse Response;
            StreamReader reader;
            string strHTML;
            string RequestUrl = "http://" + HttpContext.Current.Request.Url.Authority + "/AccessoryPdfFile/AccessoryPurchaseOrderPdf.aspx?AccessoryType=" + AccessoryType + "&AccessoryMasterId=" + AccessoryMasterId + "&Size=" + Size + "&ColorPrint=" + ColorPrint + "&SupplierPoId=" + SupplierPoId;
            Request = WebRequest.Create(RequestUrl);
            LogFileWrite("Request Url:- " + RequestUrl);
            Request.Timeout = Convert.ToInt32(99999999);
            Response = Request.GetResponse();
            reader = new StreamReader(Response.GetResponseStream());
            strHTML = reader.ReadToEnd();
            LogFileWrite("Response Html:- " + strHTML);
            genertaeAccessoryPdf(strHTML, "ss", AccessoryPoNo);
            SendAccessoryPoEmail(AccessoryPoNo, SupplierEmail, AccessoryQualityName, AccessoryStage, PoStatus);
        }

        public void genertaeAccessoryPdf(string HTMLCode, string PolicyFile, string AccessoryPoNo)
        {
            string strFileName = Constants.ACCESSORY_FOLDER_PATH + "POAccessory_" + AccessoryPoNo + ".pdf";
            HTMLCode = getAccessoryImage(HTMLCode);
            getvartypeAccessoryHTML(HTMLCode, strFileName, AccessoryPoNo);
        }

        public void getvartypeAccessoryHTML(string HTMLCode, string PolicyFile, string AccessoryPoNo)
        {
            try
            {
                LogFileWrite("getvartypeAccessoryHTML Start:- ");
                string strFileName = Constants.ACCESSORY_FOLDER_PATH + "POAccessory_" + AccessoryPoNo + ".pdf";
                LogFileWrite("getvartypeAccessoryHTML FileName:- " + strFileName);
                using (IPechkin pechkin = Factory.Create(new GlobalConfig()))
                {
                    var pdf = pechkin.Convert(new ObjectConfig()
                                            .SetLoadImages(true)
                                            .SetZoomFactor(1.5)
                                            .SetPrintBackground(true)
                                            .SetScreenMediaType(true)
                                            .SetCreateExternalLinks(true), (HTMLCode));
                    LogFileWrite("pechkin Pdf Start:- ");
                    using (FileStream file = System.IO.File.Create(strFileName))
                    {
                        file.Write(pdf, 0, pdf.Length);
                    }
                }
                LogFileWrite("getvartypeAccessoryHTML End:- ");
            }
            catch (Exception ex)
            {
                LogFileWrite("Error occur in getvartypeAccessoryHTML on :- " + ex.Message);
            }
        }
        public string getAccessoryImage(string input)
        {
            if (input == null)
                return string.Empty;
            string tempInput = input;
            string pattern = @"<img(.|\n)+?>";
            string src = string.Empty;
            HttpContext context = HttpContext.Current;
            foreach (Match m in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.RightToLeft))
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
                                tempInput = tempInput.Remove(m.Index, m.Length);
                                tempInput = tempInput.Insert(m.Index, tempM);
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
            return tempInput;
        }


        public Boolean SendAccessoryPoEmail(string AccessoryPoNo, string SupplierEmail, string AccessoryQualityName, string AccessoryStage, string PoStatus)
        {
            try
            {
                LogFileWrite("SendAccessoryPoEmail Start:- ");
                string PoPath = string.Empty;
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                List<String> to = new List<String>();
                string email = SupplierEmail;
                to.Add(email);
                List<Attachment> atts = new List<Attachment>();
                if (File.Exists(Constants.ACCESSORY_FOLDER_PATH + "POAccessory_" + AccessoryPoNo + ".pdf"))
                {
                    PoPath = Path.Combine(Constants.ACCESSORY_FOLDER_PATH, "POAccessory_" + AccessoryPoNo + ".pdf");
                    atts.Add(new Attachment(PoPath));
                }
                this.SendAccessoryEmail(fromName, to, atts, false, false, AccessoryPoNo, AccessoryQualityName, AccessoryStage, PoStatus);
                LogFileWrite("SendAccessoryPoEmail End:- ");
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return false;
            }
        }

        public Boolean SendAccessoryEmail(String FromEmail, List<String> To, List<Attachment> Attachments, Boolean hasAppendAttachment, Boolean isAsync, string AccessoryPoNo, string AccessoryQualityName, string AccessoryStage, string PoStatus)
        {
            string MailType = "Accessory PO";
            AccessoryQualityName = AccessoryQualityName.Contains('(') ? AccessoryQualityName.Substring(0, AccessoryQualityName.IndexOf('(')) : AccessoryQualityName;
            //System.Diagnostics.Debugger.Break();
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = MailType + " (" + AccessoryPoNo + ")";
            if (PoStatus == "1")
            {
                mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a <span style='color:gray'>Purchase Order</span><span style='color:#2f5597'> " + AccessoryPoNo + "</span> is canceled for <span style='color:gray'>" + "Accessory Quality - </span><span style='color:#2f5597'>" + AccessoryQualityName + "</span><span style='color:gray'> for stage </span> <span style='color:#2f5597'> " + AccessoryStage + "</span>. Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> Disclaimer: This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
            }
            else
            {
                mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a <span style='color:gray'>Purchase Order</span><span style='color:#2f5597'> " + AccessoryPoNo + "</span> is raised for <span style='color:gray'>" + "Accessory Quality - </span><span style='color:#2f5597'>" + AccessoryQualityName + "</span><span style='color:gray'> for stage </span> <span style='color:#2f5597'> " + AccessoryStage + "</span>. Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> Disclaimer: This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
            }
            mailMessage.IsBodyHtml = true;

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
                        //htmlView.LinkedResources.Add(imageId);
                    }
                    i++;
                }
            }
            else
            {
                mailMessage.Body = mailMessage.Body;
            }
            Boolean isDebug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["isDebug"]);
            //Boolean isDebug = false;
            if (isDebug)
            {
                // TODO
                mailMessage.To.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.Bcc.Add(Constants.WEBMASTER_EMAIL);
                mailMessage.CC.Add("itsupport@boutique.in");
            }
            else
            {
                foreach (String to in To)
                    mailMessage.To.Add(to);
                mailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.CC.Add("bipl_accessories@boutique.in");
            }
            SmtpClient smtpClient = new SmtpClient(Constants.SMTP_HOST, Constants.SMTP_PORT);
            if (!hasAppendAttachment && Attachments != null)
            {
                foreach (Attachment att in Attachments) { mailMessage.Attachments.Add(att); }
            }
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Timeout = Constants.SMTP_TIMEOUT;

            if (Constants.SMTP_SECURE) { smtpClient.EnableSsl = true; }

            if (Constants.SMTP_IS_AUTH_REQUIRED)
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(Constants.SMTP_USERNAME, Constants.SMTP_PASSWORD);
            }
            try
            {
                smtpClient.Timeout = 300000;
                smtpClient.Send(mailMessage);
                System.Diagnostics.Trace.WriteLine("Email Having Subject of --" + MailType.ToString() + " is send successfully on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Some error has been occur in Email having subject of ---" + MailType.ToString() + " On" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                System.Diagnostics.Trace.WriteLine("Sorry !! Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                return false;
            }
            finally
            {
                try
                {
                    if (Attachments != null) { foreach (Attachment att in Attachments) { att.Dispose(); } Attachments = null; }
                    foreach (Attachment att in mailMessage.Attachments) { att.Dispose(); }
                    mailMessage = null;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
        }

        public static void LogFileWrite(string message)
        {
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            try
            {
                string logFilewithname = "POAccessory_SanjeevTest" + ".txt";
                string logFilePath = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "" + logFilewithname);

                if (logFilePath.Equals("")) return;
                #region Create the Log file directory if it does not exists
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                #endregion Create the Log file directory if it does not exists


                if (!logFileInfo.Exists) { fileStream = logFileInfo.Create(); }
                else { fileStream = new FileStream(logFilePath, FileMode.Append); }
                streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine("Datetime of Log : " + DateTime.Now.ToString() + Environment.NewLine + " Message:- " + message + Environment.NewLine + Environment.NewLine);

            }
            catch
            {
            }
            finally
            {
                if (streamWriter != null) streamWriter.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
       
        #endregion
    }
}
