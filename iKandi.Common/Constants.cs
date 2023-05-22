using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text.RegularExpressions;
using System.Web;
using System.Data;

namespace iKandi.Common
{

    public class Constants
    {
        #region Properties

        public static string BaseSiteUrl
        {
            get
            {
                HttpContext context = HttpContext.Current;
                string baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/');
                return baseUrl;
            }
        }

        #endregion

        #region Fields

        public static string CONTENT_TYPE_PDF = "Application/pdf";

        public static string CONTENT_TYPE_EXCEL = "application/ms-excel";

        public static string CONFIGURATION_STRING = System.Configuration.ConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString;

        public static int CONFIGURATION_TimeOut = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Timeout"]);

        public static string PHOTO_FOLDER_PATH = HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"]);

        public static string STYLE_FOLDER_PATH = HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["style.folder"]);

        public static string PRINT_FOLDER_PATH = HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["print.folder"]);

        public static string ORDER_FOLDER_PATH = HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["order.folder"]);

        public static string QUALITY_FOLDER_PATH = HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["quality.folder"]);

        public static string INLINEPPM_DOCS_FOLDER_PATH = HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["inlineppm.docs.folder"]);

        public static string FITS_FOLDER_PATH = HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["fits.docs.folder"]);

        public static string GARMENT_TESTING_FOLDER_PATH = HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["garment.testing.docs.folder"]);

        public static string DELIVERY_FOLDER_PATH = HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["delivery.docs.folder"]);

        public static string ACCESSORY_FOLDER_PATH = HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["accessory.folder"]);

        public static string TEMP_FOLDER_PATH = HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["temp.folder"]);

        public static string SCREEN_SHOT_FOLDER_PATH = HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["screenshot.folder"]);
      
        public static string MATERIAL_FOLDER_PATH = HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["material.folder"]);

        public static string VERSION_INFO = System.Configuration.ConfigurationManager.AppSettings["VersionInfo"];

        public static string IKANDI_EMAIL = "@ikandi.org.uk";

        public static string BOUTIQUE_EMAIL = "@boutique.in";

        public static string XNY_EMAIL = "@xny.in";

        public static string JSCRIPT_VARIABLE_NAMES = "JScriptVariableNames";

        public static string WEBMASTER_EMAIL = System.Configuration.ConfigurationManager.AppSettings["smtpClient.webmaster"];

        public static string SMTP_HOST = System.Configuration.ConfigurationManager.AppSettings["smtpClient.host"];

        public static int SMTP_PORT = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["smtpClient.port"]);

        public static int SMTP_TIMEOUT = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["smtpClient.timeout"]);

        public static int WorkSheetCount_ForExcel = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["WorkSheetCount_ForExcel"]);

        public static bool SMTP_SECURE = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["smtpClient.secure"]);

        public static bool SMTP_IS_AUTH_REQUIRED = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["smtpClient.isAuthRequired"]);

        public static string SMTP_USERNAME = System.Configuration.ConfigurationManager.AppSettings["smtpClient.user"];

        public static string SMTP_PASSWORD = System.Configuration.ConfigurationManager.AppSettings["smtpClient.password"];

        public static string ISNEWEMAILSCHEDULERACTIVE = System.Configuration.ConfigurationManager.AppSettings["IsNewSchedulerActive"];

        public static string BIPL_ADDRESS = "BIPLAddress";

        public static string IKANDI_ADDRESS = "iKandiAddress";

        public static string VAT_NO = "iKandiVATNo";

        public static string IKANDI_VAT = "iKandiVAT";

        public static string IE_CODE = "IECode";

        public static string EMAIL_FOOTER_LINE1 = "EmailFooterLine1";

        public static string EMAIL_FOOTER_LINE2 = "EmailFooterLine2";

        public static string EMAIL_FOOTER_LINE3 = "EmailFooterLine3";

        public static string NOTIFICATION_DAYS = "NotificationDays";

        public static string FINAL_DESTINATION = "FinalDestination";

        public static string IND_BLOCK_FOLDER_PATH = HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["indBlock.folder"]);

        public static string SITE_BASE_URL = System.Configuration.ConfigurationManager.AppSettings["site.baseUrl"];

        public static string INTERNAL_SITE_BASE_URL = System.Configuration.ConfigurationManager.AppSettings["site.baseUrl.internal"];

        public static string SCREENSHOT_EXE_PATH = System.Configuration.ConfigurationManager.AppSettings["screenshot.exePath"];

        public static string FABRIC_AWB_PATH = System.Configuration.ConfigurationManager.AppSettings["fabric.awbUrl"];

        public static int ADMIN_USER_ID = 2;

        public static string ADMIN_USER_NAME = "bipladmin@boutique.in";

        public static string LAURA_TARGET_PERCENT = "LauraTargetPercent";

        public static string VIKRANT_TARGET_PERCENT = "VikrantTargetPercent";

        public static string INR_VALUE = "CONVERSION_RATE";

        public static Boolean IS_DEBUG = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["isDebug"]);

        public static string LAB_TEST_FOLDER_PATH = HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["labtest.folder"]);

        public static string IsDebugMode = System.Configuration.ConfigurationManager.AppSettings["IsDebugMode"];

        public static bool IsMarginSumRequired = true;
        public static bool IsDesignHitRateSumRequired = true;

        public static string StyleID { get; set; }
        public static string SectionName { get; set; }

        public static string MainUrlMail = System.Configuration.ConfigurationManager.AppSettings["MainUrlMail"];
        public static string MainIpMail = System.Configuration.ConfigurationManager.AppSettings["MainIpMail"];
    
        #endregion



        #region Public Method

        /// <summary>
        /// Serializes the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="dataObj">The data obj.</param>
        /// <param name="nms">The NMS.</param>
        /// <returns></returns>
        public static string Serialize(Type type, object dataObj)
        {
            XmlSerializerNamespaces nms = new XmlSerializerNamespaces();

            nms.Add("", "http://www.phoenix.com/hyperSpace/1.0");

            MemoryStream ms = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(ms, Encoding.UTF8);
            try
            {
                XmlSerializer s = new XmlSerializer(type);

                s.Serialize(xmlWriter, dataObj, nms);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Encoding.UTF8.GetString(ms.ToArray());

        }

        /// <summary>
        /// Deserializes the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xs = new XmlSerializer(type);
            return xs.Deserialize(stream);
        }

        public static void WriteXMLResponse(string data)
        {
            //HttpContext.Current.Response.ClearContent();
            //HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.ContentType = "text/xml";
            //HttpContext.Current.Response.Write(data);
            //HttpContext.Current.Response.Flush();
            //HttpContext.Current.Response.End();
        }



        //public static string GetOrderDeliveryMode(int Mode)
        //{
        //    switch (Mode)
        //    {
        //        case 1:
        //            return "A/F";
        //        case 2:
        //            return "A/H";
        //        case 3:
        //            return "S/F";
        //        case 4:
        //            return "S/H";
        //        case 5:
        //            return "S-B/H";
        //        case 6:
        //            return "A-B/H";
        //        case 7:
        //            return "FOB-A/F";
        //        case 8:
        //            return "FOB-A/H";
        //        case 9:
        //            return "FOB-S/F";
        //        case 10:
        //            return "FOB-S/H";
        //        case 11:
        //            return "CIF-A/F";
        //        case 12:
        //            return "CIF-A/H";
        //    }

        //    return string.Empty;
        //}

        //public static string GetOrderDeliveryModeColor(int Mode)
        //{
        //    switch (Mode)
        //    {
        //        case 1:
        //            return "#92d14f";
        //        case 2:
        //            return "#a7ffa8";
        //        case 3:
        //            return "#32ccfe";
        //        case 4:
        //            return "#c1e6ff";
        //        case 5:
        //            return "#c1e6ff";
        //        case 6:
        //            return "#a7ffa8";
        //        case 7:
        //            return "#ffc82d";
        //        case 8:
        //            return "#eddcca";
        //        case 9:
        //            return "#ffdebd";
        //        case 10:
        //            return "#fe9900";
        //        case 11:
        //            return "#ff3300";
        //        case 12:
        //            return "#ff5757";
        //    }

        //    return "#ffffff";
        //}

        public static string GetQuoteToolMode(int ModeId)
        {
            switch (ModeId)
            {
                case 1:
                    return "AF";
                case 2:
                    return "AH";
                case 3:
                    return "SF";
                case 4:
                    return "SH";
                case 5:
                    return "FOB";

            }
            return string.Empty;

        }


        public static string GetSerialNumberColor(DateTime ExFactory)
        {
            if (DateTime.Compare(DateTime.Today, ExFactory) > 0)
                return "#ff3300";

            if (Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Weekday, DateTime.Today, ExFactory, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.Jan1) == 0)
                return "#00FF70";

            return "#ffffff";
        }

        //public static string GetExFactoryColor(DateTime ExFactory, DateTime DCDate, int Mode)
        //{


        //    long days = Math.Abs(Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Day, ExFactory, DCDate, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.Jan1));

        //    switch (Mode)
        //    {
        //        case 1:
        //        case 7:
        //        case 8:
        //        case 9:
        //        case 10:
        //        case 11:
        //            if (days <= 3)
        //                return "#ff3300";
        //            else if (days <= 10 && days >= 4)
        //                return "#fd9903";
        //            else if (days <= 17 && days > 10)
        //                return "#00FF70";
        //            break;
        //        case 2:
        //        case 6:
        //        case 12:
        //            if (days <= 10)
        //                return "#ff3300";
        //            else if (days <= 14 && days > 10)
        //                return "#fd9903";
        //            else if (days <= 21 && days > 14)
        //                return "#00FF70";
        //            break;
        //        case 3:
        //            if (days <= 38)
        //                return "#ff3300";
        //            else if (days <= 45 && days > 38)
        //                return "#00FF70";
        //            break;
        //        case 4:
        //        case 5:
        //            if (days <= 45)
        //                return "#ff3300";
        //            else if (days <= 52 && days > 45)
        //                return "#00FF70";
        //            break;
        //    }


        //    return "#ffffff";
        //}

        public static string GetPercentageColor(double Percentage)
        {
            if (Percentage <= 49 && Percentage >= 1)
                return "#fd9903";

            if (Percentage > 49 && Percentage < 100)
                return "#32ccfe";

            if (Percentage >= 100)
                return "#00FF70";

            return "#fde2c5";
        }

        public static string GetIdealAfterColor(int Days)
        {
            if (Days < 5)
                return "#ff3300";

            if (Days >= 5 && Days <= 10)
                return "#ffff00"; //yellow

            if (Days > 10)
                return "#00FF70";

            return "#ffffff";
        }

        public static string GetMarginColor(double Margin)
        {
            if (Margin >= 20)
                return "#00FF70";

            if (Margin >= 18 && Margin <= 19.99)
                return "#fd9903";

            if (Margin < 17.99 && Margin > 1)
                return "#ff3300";

            return "#ffffff";
        }

        public static string GetActualDateColor(DateTime ETA, DateTime Actual)
        {
            long days = Math.Abs(Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Day, ETA, Actual, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.Jan1));


            if (Actual == DateTime.MinValue || ETA == DateTime.MinValue)
                return "#ffffff";

            else if (days == 0)
                return "#00FF70";

            else if (DateTime.Compare(ETA, Actual) < 0)
                return "#ff3300";

            else if (DateTime.Compare(ETA, Actual) > 0)
                return "#00FF70";


            return "#ffffff";
        }

        public static string GetMimeType(string fileExt)
        {
            switch (fileExt.ToLower())
            {
                case "pdf":
                    return "application/pdf";
                case "ppt":
                    return "application/vnd.ms-powerpoint";
                case "xls":
                    return "application/vnd.ms-excel";
                case "doc":
                    return "application/msword";
                case "jpg":
                case "jpeg":
                    return "application/jpeg";
                case "gif":
                    return "application/gif";
                case "mpeg":
                case "mpg":
                    return "application/mpeg";
                case "txt":
                    return "application/text";
                default:
                    return "application/unknown";

            }
        }

        public static Boolean IsGuid(String value)
        {
            if (value == null)
            {
                return false;
            }
            return Regex.IsMatch(value, @"^?[\da-f]{8}-([\da-f]{4}-){3}[\da-f]{12}?$", RegexOptions.IgnoreCase);

        }

        //public static string GetShipmentInitial(string Mode)
        //{
        //    switch (Mode)
        //    {
        //        case "A/F":
        //        case "A/H":
        //        case "A-B/H":
        //        case "CIF-A/F":
        //        case "CIF-A/H":
        //            return "AIR-L-";

        //        case "S/F":
        //        case "S/H":
        //        case "S-B/H":
        //            return "SEA-L-";

        //        case "FOB-A/F":
        //        case "FOB-A/H":
        //            return "AIR-D-";

        //        case "FOB-S/F":
        //        case "FOB-S/H":
        //            return "SEA-D-";
        //    }

        //    return string.Empty;
        //}

        public static string GetFabricStatusModeColor(string StatusModeName)
        {
            switch (StatusModeName)
            {
                case "ON SCHEDULE":
                    return "#00B0F0";
                case "SENT DELAYED":
                    return "#FFFF00";
                case "SENT WITHIN TOLERANCE":
                    return "#FFC000";
                case "SENT ON TIME":
                    return "#92d050";
                case "DELAYED":
                    return "#FF0000";
            }
            return "#FFFFFF";

        }

        public static string GetStyleSamplingPriorityColor(string Priority)
        {
            switch (Priority)
            {
                case "Urgent":
                    return "#ff3300";

                case "High":
                    return "#fd9903";

                case "Medium":
                    return "#ffff00";

                case "Low":
                    return "#00FF70";
            }

            return "#FFFFFF";
        }

        public static string GetSamplingStatusPriority(DateTime ETA)
        {
            long days = Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Day, DateTime.Today, ETA, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.Jan1);

            if (days <= 7)
                return "Urgent";
            else if (days >= 8 && days < 15)
                return "High";
            else if (days >= 15 && days < 22)
                return "Medium";
            else if (days >= 22)
                return "Low";
            else
                return string.Empty;
        }




        // Update By Ravi kumar on 6/1/2015
        public static string GetFitsStatus(DateTime TopSendActual, DateTime TopActualApproval, bool IsStcApproved, DateTime SealDate, String CommentSendFor, String PlanningFor, DateTime FitsRequestedOn, DateTime AckDate, iKandi.Common.TopStatusType topStatusType, DateTime SepcsTargetDate, DateTime SpecsActualDate)
        {
            string fitsStatus = string.Empty;

            if (TopActualApproval != DateTime.MinValue)
            {
                if (topStatusType == TopStatusType.REJECTED && TopSendActual != DateTime.MinValue)
                {
                    fitsStatus = "Top Rejected On " + TopActualApproval.ToString("dd MMM (ddd)");
                }
                else if (topStatusType == TopStatusType.UNKNOWN && TopSendActual != DateTime.MinValue)
                {
                    fitsStatus = "Top Resent On " + TopSendActual.ToString("dd MMM (ddd)");
                }
                else
                {
                    fitsStatus = "Top Approved On " + TopActualApproval.ToString("dd MMM (ddd)");
                }
            }

            else if (TopSendActual != DateTime.MinValue)
            {
                fitsStatus = "Top Sent On " + TopSendActual.ToString("dd MMM (ddd)");
            }

            else if (CommentSendFor != null && CommentSendFor != string.Empty)
            {
                if (IsStcApproved)
                {
                    fitsStatus = "STC Approved On " + SealDate.ToString("dd MMM (ddd)");
                }
                else
                {
                    if (PlanningFor.IndexOf("STC") > -1)
                    {
                        fitsStatus = PlanningFor + " Requested on " + FitsRequestedOn.ToString("dd MMM (ddd)");
                    }

                    else if (AckDate == DateTime.MinValue)
                    {
                        if (CommentSendFor.ToString().Trim() == string.Empty)
                        {
                            fitsStatus = string.Empty;
                        }
                        if (CommentSendFor.ToString().Trim() == "Buying Sample")
                        {
                            fitsStatus = "Fit 1 Comment Received on " + FitsRequestedOn.ToString("dd MMM (ddd)");
                        }
                        else
                        {
                            fitsStatus = CommentSendFor + " Comment Received on " + FitsRequestedOn.ToString("dd MMM (ddd)");
                        }
                    }

                    else
                    {
                        fitsStatus = PlanningFor + " Sent on " + AckDate.ToString("dd MMM (ddd)");
                    }
                }
            }
            else if (SpecsActualDate != DateTime.MinValue)
            {
                fitsStatus = "Fit 1 Sent On " + SpecsActualDate.ToString("dd MMM (ddd)");
            }

            else
            {
                fitsStatus = string.Empty;
            }

            return fitsStatus;
        }

        public static string GetFitsStatusManageOrder(DateTime TopSendActual, DateTime TopActualApproval, iKandi.Common.TopStatusType topStatusType, string Fitstatus_ManageOrder)
        {
            string fitsStatus = string.Empty;

            if (TopActualApproval != DateTime.MinValue)
            {
                if (topStatusType == TopStatusType.REJECTED && TopSendActual != DateTime.MinValue)
                {
                    fitsStatus = "Top Rejected On " + TopActualApproval.ToString("dd MMM (ddd)");
                }
                else if (topStatusType == TopStatusType.UNKNOWN && TopSendActual != DateTime.MinValue)
                {
                    fitsStatus = "Top Resent On " + TopSendActual.ToString("dd MMM (ddd)");
                }
                else
                {
                    fitsStatus = "Top Approved On " + TopActualApproval.ToString("dd MMM (ddd)");
                }
            }

            else if (TopSendActual != DateTime.MinValue)
            {
                fitsStatus = "Top Sent On " + TopSendActual.ToString("dd MMM (ddd)");
            }

            else if (Fitstatus_ManageOrder != null && Fitstatus_ManageOrder != string.Empty)
            {
                fitsStatus = Fitstatus_ManageOrder;
            }            

            else
            {
                fitsStatus = string.Empty;
            }

            return fitsStatus;
        }

       
        public static string GetFitsStatusColor(DateTime ExFactoryDate, DateTime StcUnallocated, DateTime OrderDate, DateTime TopSendTarget, DateTime TopSendActual, DateTime TopActualApproval, DateTime SealDate, DateTime FitsRequestedOn, DateTime NextPlannedDate, DateTime AckDate, bool IsStcApproved, string CommentSendFor, string PlanningFor, iKandi.Common.TopStatusType topStatusType, DateTime SepcsTargetDate, DateTime SpecsActualDate)
        {
            string fitsStatus = "#ffffff";
            DateTime nextPlandDt = (NextPlannedDate == DateTime.MinValue) ? DateTime.MinValue : NextPlannedDate.AddDays(-2);
            DateTime exDate = (ExFactoryDate == DateTime.MinValue) ? DateTime.MinValue : ExFactoryDate.AddDays(-7);
            DateTime orderDt = (OrderDate == DateTime.MinValue) ? DateTime.MinValue : OrderDate.AddDays(10);

            if (TopActualApproval != DateTime.MinValue)
            {
                if (topStatusType == TopStatusType.REJECTED && TopSendActual == DateTime.MinValue)
                {
                    fitsStatus = GetActualDateColor(exDate, TopActualApproval);
                }
                else if (topStatusType == TopStatusType.REJECTED && TopSendActual != DateTime.MinValue)
                {
                    fitsStatus = GetActualDateColor(TopSendTarget, TopSendActual);
                }
                else
                {
                    fitsStatus = GetActualDateColor(exDate, TopActualApproval);
                }
            }

            else if (TopSendActual != DateTime.MinValue)
            {
                fitsStatus = GetActualDateColor(TopSendTarget, TopSendActual);
            }

            else if (CommentSendFor != null && CommentSendFor != string.Empty)
            {
                if (IsStcApproved)
                {
                    fitsStatus = GetActualDateColor(StcUnallocated, SealDate);
                }
                else
                {
                    if (PlanningFor.IndexOf("STC") > -1)
                    {
                        fitsStatus = GetActualDateColor(StcUnallocated, SealDate);
                    }

                    else if (AckDate == DateTime.MinValue)
                    {
                        if (CommentSendFor.ToString().ToUpper().Contains("FIT 1"))
                        {
                            fitsStatus = GetActualDateColor(orderDt, FitsRequestedOn);
                        }
                        else
                        {
                            fitsStatus = GetActualDateColor(NextPlannedDate, FitsRequestedOn);
                        }
                    }

                    else
                    {

                        fitsStatus = GetActualDateColor(nextPlandDt, AckDate);
                    }
                }
            }
            else if (SpecsActualDate != DateTime.MinValue)
            {
                fitsStatus = GetActualDateColor(SepcsTargetDate, SpecsActualDate);
            }

            else
            {
                fitsStatus = "#FFFFFF";
            }
            return fitsStatus;

        }

       
        // Add By Ravi kumar on 29/07/2015 create task for OB and Risk

        //public static string GetStatusModeColor(int StatusMode)
        //{

        //    switch (StatusMode)
        //    {
        //        case 1:
        //            return "#d4d4f0";
        //        case 2:
        //            return "#bbfcbc";
        //        case 3:
        //            return "#83d883";
        //        case 4:
        //            return "#7ecfed";
        //        case 5:
        //            return "#e9d5f0";
        //        case 6:
        //            return "#cac8b3";
        //        case 7:
        //            return "#ffff00";
        //        case 8:
        //            return "#cdbeab";
        //        case 9:
        //            return "#00FF70";
        //        case 10:
        //            return "#C5F893";
        //        case 11:
        //            return "#e3d5e6";
        //        case 12:
        //            return "#ead8c4";
        //        case 13:
        //            return "#f3c8f3";
        //        case 14:
        //            return "#a5fbfc";
        //        case 15:
        //            return "#f3bbc8";
        //        case 16:
        //            return "#fbf9ae";
        //        case 17:
        //            return "#edebee";
        //        case 18:
        //            return "#fde2c5";
        //        case 19:
        //            return "#92d14f";
        //        case 20:
        //            return "#bcc5e6";
        //        case 21:
        //            return "#4caaea";
        //        case 22:
        //            return "#65aba3";
        //        case 23:
        //            return "#99b568";
        //        case 24:
        //            return "#fe0000";
        //        case 25:
        //            return "#ffc000";
        //        case 26:
        //            return "#8fb3e3";
        //        case 28:
        //            return "#f8c15d";
        //        case 29:
        //            return "#05bef0";
        //        case 30:
        //            return "#7ecfed";
        //        case 31:
        //            return "#7ecfed";
        //        case 32:
        //            return "#7ecfed";
        //        case 33:
        //            return "#7ecfed";

        //    }

        //    return "#ffffff";
        //}
        // Add By Ravi kumar on 29/07/2015 create task for OB and Risk
        //New 
        
        //New Status Colour Added by Gajendra 17-03-2016
        public static string GetStatusModeColor(int StatusMode)
        {

            switch (StatusMode)
            {
                case 1:
                    return "#d4d4f0";
                case 3:
                    return "#bbfcbc";
                case 4:
                    return "#83d883";
                case 5:
                    return "#7ecfed";
                case 8:
                    return "#e9d5f0";
                case 9:
                    return "#e9d5f0";
                case 7:
                    return "#cac8b3";
                case 10:
                    return "#ffff00";
                case 11:
                    return "#cdbeab";
                case 77:
                    return "#cdbeab";
                case 25:
                    return "#00FF70";
                case 79:
                    return "#C5F893";
                case 28:
                    return "#e3d5e6";
                case 29:
                    return "#ead8c4";
                case 37:
                    return "#f3c8f3";
                case 39:
                    return "#a5fbfc";
                case 40:
                    return "#f3bbc8";
                case 41:
                    return "#fbf9ae";
                case 43:
                    return "#edebee";
                case 44:
                    return "#edebee";
                case 45:
                    return "#edebee";
                case 46:
                    return "#edebee";
                case 47:
                    return "#fde2c5";
                case 48:
                    return "#92d14f";
                case 49:
                    return "#bcc5e6";
                case 50:
                    return "#bcc5e6";
                case 51:
                    return "#4caaea";
                case 52:
                    return "#65aba3";
                case 83:
                    return "#99b568";
                case 56:
                    return "#fe0000";
                case 57:
                    return "#ffc000";
                case 20:
                    return "#8fb3e3";
                case 34:
                    return "#f8c15d";
                case 36:
                    return "#05bef0";
                case 6:
                    return "#7ecfed";            
            }

            return "#ffffff";
        }
        // Add By Ravi kumar on 29/07/2015 create task for OB and Risk
        public static string GetStatusModeName(int StatusMode)
        {

            switch (StatusMode)
            {
                case 1:
                    return "Style Created";
                case 2:
                    return "Verify Costing";
                case 3:
                    return "Courier Sent";
                case 4:
                    return "Digital Uploaded";
                case 5:
                    return "Costing Bipl";
                case 6:
                    return "Price Quoted Bipl";
                case 7:
                    return "Open Costing";
                case 8:
                    return "Costing Close";
                case 9:
                    return "Bipl Agreement Ikandi";
                case 10:
                    return "New Order";
                case 11:
                    return "Order Confirmed Sales";
                case 12:
                    return "Create OB";
                case 13:
                    return "Reminder";
                case 14:
                    return "Order Agreement";
                case 15:
                    return "Risk";
                case 16:
                    return "Create Fabric";
                case 17:
                    return "Create Accessories";
                case 18:
                    return "Fabric Approved";
                case 19:
                    return "Accessory Approved";
                case 20:
                    return "Workings Created";
                case 21:
                    return "Fill Fabric";
                case 22:
                    return "Fill Accessories";
                case 23:
                    return "Limitation Fabric";
                case 24:
                    return "Limitation Accessories";
                case 25:
                    return "Live";
                case 26:
                    return "Stc Unallocated Technol.";
                case 27:
                    return "Stc Unallocated Fit Merchant";
                case 29:
                    return "Inline Cut";
                case 30:
                    return "Final OB";
                case 34:
                    return "Factory Ppm";
                case 36:
                    return "HO PPM";
                case 37:
                    return "Cutting";
                case 38:
                    return "Line Plan";
                case 39:
                    return "Stitching";
                case 40:
                    return "Finishing";
                case 41:
                    return "Ex-factory Planned";
                case 43:
                    return "Final QA Inspection";
                case 44:
                    return "Approved To Ex (Clt- QA Pending)";
                case 45:
                    return "Approved To Ex (Approval) QA";
                case 46:
                    return "Approved To Ex (Shipping)";
                case 47:
                    return "Part Ex Factoried";
                case 48:
                    return "Ex-Factoried";
                case 49:
                    return "Under Clearance - (Flat)";
                case 50:
                    return "Under Clearence- (Hanging)";
                case 51:
                    return "Processing";
                case 52:
                    return "Delivered";
                case 53:
                    return "Bipl Invoiced";
                case 54:
                    return "Ikandi Invoiced";
                case 56:
                    return "Cancelled";
                case 57:
                    return "Onhold";
                case 58:
                    return "Pattern Sample Received";
                case 59:
                    return "Top Planned";
                case 60:
                    return "Top Sent";
                case 61:
                    return "Acknowledgement Fabric";
                case 62:
                    return "Acknowledgement Costing";
                case 63:
                    return "Initial Approval";
                case 64:
                    return "Bulk Approval";
                case 65:
                    return "PO Upload";
                case 67:
                    return "Production File";
                case 70:
                    return "Colour/ Print Ref Received";
                case 71:
                    return "Fabric Qualtiy Approved";
                case 72:
                    return "Buying Sample";
                case 73:
                    return "Photo Shoots";
                case 74:
                    return "Test Report";
                case 75:
                    return "Fabric BIH";
                case 76:
                    return "Accessories BIH";
                case 77:
                    return "Order Confirmed Merchant";
                case 78:
                    return "Cutting Sheet";
                case 79:
                    return "Sealed To Cut";
                case 80:
                    return "CD Chart";
                case 81:
                    return "Approved To Ex";
                case 82:
                    return "Under Clearence";
                case 83:
                    return "Invoiced";
                case 89:
                    return "HandOver";
                case 90:
                    return "Pattern Ready";
                case 91:
                    return "Sample Sent";
              

            }

            return "";
        }

        public static string GetStatusModeNameNew(int StatusMode)
        {

            switch (StatusMode)
            {
                case 1:
                    return "Style Created";
                case 2:
                    return "Sample Sent";
                case 3:
                    return "Digital Uploaded";
                case 4:
                    return "Costing Bipl";
                case 5:
                    return "Bipl Agreement";
                case 6:
                    return "Costed Ikandi";
                case 7:
                    return "New Order";
                case 8:
                    return "Order Confirmed";
                case 9:
                    return "Live";
                case 10:
                    return "Stc Unallocated";
                case 11:
                    return "Allocated";
                case 12:
                    return "Inline Cut";
                case 13:
                    return "Cutting";
                case 14:
                    return "Stitch. & Pkg.";
                case 15:
                    return "Packing";
                case 16:
                    return "Ex-factory Planned";
                case 17:
                    return "Approved To Ex";
                case 18:
                    return "Part Ex-factoried";
                case 19:
                    return "Ex-factoried";
                case 20:
                    return "Under Clearance";
                case 21:
                    return "Processing";
                case 22:
                    return "Delivered";
                case 23:
                    return "Invoiced";
                case 24:
                    return "Cancelled";
                case 25:
                    return "Onhold";
                case 26:
                    return "Workings Created";
                case 27:
                    return "Order Agreement";
                case 28:
                    return "Factory PPM";
                case 29:
                    return "HO PPM";
                case 30:
                    return "Price Quoted Bipl";
                case 31:
                    return "Create OB w/s";
                case 32:
                    return "Final OB w/s";
                case 33:
                    return "Risk Analysis";
            }

            return "";
        }

        public static string GetDesignationName(int Designation)
        {

            switch (Designation)
            {
                case 1:
                    return "iKandi Top Management";
                case 2:
                    return "BIPL Top Management";
                case 3:
                    return "iKandi Sales Director";
                case 4:
                    return "iKandi Sales Executive";
                case 5:
                    return "iKandi Design Director";
                case 6:
                    return "iKandi Designer";
                case 7:
                    return "iKandi Technical Manager";
                case 8:
                    return "iKandi Logistics Manager";
                case 9:
                    return "BIPL Factory Manager";
                case 10:
                    return "iKandi Technologist";
                case 11:
                    return "iKandi Finance Accountant";
                case 12:
                    return "iKandi Designer Assistant";
                case 13:
                    return "BIPL Sales Director";
                case 14:
                    return "BIPL Merchandising Manager";
                case 15:
                    return "BIPL Fabrics Manager";
                case 16:
                    return "BIPL Accessory Manager";
                case 17:
                    return "BIPL QA Manager";
                case 18:
                    return "BIPL Production Manager";
                case 19:
                    return "BIPL Logistics Manager";
                case 20:
                    return "BIPL Sales Advisor";
                case 21:
                    return "BIPL Account Manager";
                case 22:
                    return "BIPL Fabric Assistant (Entry)";
                case 23:
                    return "BIPL Fabric Manager-Store";
                case 24:
                    return "BIPL Fabric Manager-Processing";
                case 25:
                    return "BIPL Accessory Assistant";
                case 26:
                    return "BIPL QA";
                case 27:
                    return "BIPL Production Technologist";
                case 28:
                    return "BIPL Shipping Manager";
                case 29:
                    return "BIPL Delivery Manager";
                case 30:
                    return "BIPL Sales Assistant";
                case 31:
                    return "BIPL Fit Merchant";
                case 32:
                    return "BIPL Sampling Merchant";
                case 33:
                    return "BIPL Fabric Assistant (Processing)";
                case 34:
                    return "BIPL Production Assistant";
                case 35:
                    return "BIPL Production Assistant (Factory)";
                case 36:
                    return "Partner";
                case 37:
                    return "BIPL Accountant";
                case 38:
                    return "BIPL QA Factory Head";
                case 39:
                    return "BIPL FITs Manager";
                case 40:
                    return "BIPL LAB Supervisor";
                case 41:
                    return "BIPL LAB Assistant";
                case 42:
                    return "BIPL Client Head";
                case 43:
                    return "BIPL Production Merchandiser";
                case 44:
                    return "BIPL Manager";
                case 45:
                    return "BIPL IE";
                case 46:
                    return "BIPL Production Planning Executive";
                case 52:
                    return "BIPL Pre Production QA";
                case 53:
                    return "BIPL Factory IE";
                case 54:
                    return "BIPL Manger HR";
                case 55:
                    return "BIPL Assistance HR";


            }

            return "";
        }

        public static string GetGroupName(int Designation)
        {
            switch (Designation)
            {
                case 1:
                    return "iKandi Design";
                case 2:
                    return "ikandi Sales";
                case 3:
                    return "iKandi Technical";
                case 4:
                    return "iKandi Finance/Logistics";
                case 5:
                    return "BIPL Sales";
                case 6:
                    return "BIPL Merchandising";
                case 7:
                    return "BIPL Fabrics";
                case 8:
                    return "BIPL Accessory";
                case 9:
                    return "BIPL QA";
                case 10:
                    return "BIPL Production";
                case 11:
                    return "BIPL Logistics";
                case 12:
                    return "iKandi Top Management";
                case 13:
                    return "BIPL TopManagement";
                case 15:
                    return "Technical BIPL";
            }
            return "";
        }

        public static string GetCurrencySign(string Currency)
        {
            switch (Currency)
            {
                case "USD":
                    return "$";

                case "GBP":
                    return "£";
                case "INR":
                    return "Rs.";
                case "EURO":
                    return "€";
                case "KRO":
                    return "KR";
                case "AUD":
                    return "AUD";

            }
            return "";

        }
        /*Kuldeep Comment Start
         * 
         *
        //public static int GetNextETADays(int StatusMode)
        //{
        //    switch (StatusMode)
        //    {
        //        case 1:
        //            return 21;
        //        case 2:
        //            return 3;
        //        case 3:
        //            return 3;
        //        case 4:
        //            return 2;
        //        case 5:
        //            return 2;
        //        case 6:
        //            return 2;
        //        case 7:
        //            return 3;
        //        case 8:
        //            return 0;
        //        case 9:
        //            return 21;
        //        case 10:
        //            return 3;
        //        case 11:
        //            return 7;
        //        case 12:
        //            return 7;
        //        case 13:
        //            return 7;
        //        case 14:
        //            return 14;
        //        case 15:
        //            return 3;
        //        case 16:
        //            return 3;
        //        case 17:
        //            return 3;
        //        case 18:
        //            return 3;
        //        case 19:
        //            return 3;
        //        case 20:
        //            return 3;
        //        case 21:
        //            return 3;
        //        case 22:
        //            return 3;
        //        case 23:
        //            return 3;
        //        case 24:
        //            return 3;
        //        case 25:
        //            return 3;
        //        case 26:
        //            return 0;
        //    }

        //    return 3;
        //}
           
        public static DateTime GetNextETA(int StatusMode, OrderDetail OrderBreakdown)
        {
            switch (StatusMode)
            {
                case 8:
                    return OrderBreakdown.ParentOrder.OrderDate.AddDays(3);
                case 9:
                    return OrderBreakdown.ParentOrder.OrderDate.AddDays(3);
                case 10:
                    return OrderBreakdown.STCUnallocated;
                case 11:
                    return OrderBreakdown.STCUnallocated.AddDays(3);
                case 12:
                    return OrderBreakdown.ExFactory.AddDays(-25);
                case 13:
                    return OrderBreakdown.ExFactory.AddDays(-20);
                case 14:
                    return OrderBreakdown.ExFactory.AddDays(-14);
                case 15:
                    return OrderBreakdown.ExFactory.AddDays(-7);
                case 16:
                    return OrderBreakdown.ExFactory.AddDays(-3);
                case 17:
                    return OrderBreakdown.ExFactory.AddDays(-1);
                case 18:
                    return OrderBreakdown.ExFactory;
                case 19:
                    return OrderBreakdown.ExFactory;
                case 20:

                    if ((OrderBreakdown.ModeName).IndexOf("/F") > -1)
                        return OrderBreakdown.DC.AddDays(-4);
                    else
                        return OrderBreakdown.DC.AddDays(-8);
                case 21:
                    return OrderBreakdown.DC;
                case 22:
                    return OrderBreakdown.DC;
                case 23:
                    return OrderBreakdown.DC.AddDays(3);
                case 24:
                    return DateTime.MinValue;
                case 25:
                    return DateTime.MinValue;
                case 26:
                    return OrderBreakdown.ParentOrder.OrderDate.AddDays(3);
            }

            return DateTime.MinValue;
        }
          * *Kuldeep Comment End*/


        //public static int GetDefaultLeadTime(string mode)
        //{
        //    int leadTime = 0;
        //    mode = mode.ToLower();

        //    switch (mode)
        //    {
        //        case "a/f":
        //            leadTime = 12;
        //            break;

        //        case "a/h":
        //            leadTime = 13;
        //            break;

        //        case "s/f":
        //            leadTime = 17;
        //            break;

        //        case "s/h":
        //            leadTime = 18;
        //            break;

        //        case "fob":
        //            leadTime = 12;
        //            break;
        //    }

        //    return leadTime;
        //}

        public static double GetDefaultModeCost(string mode)
        {
            if (mode.ToLower().StartsWith("a/"))
                return 0.50;
            else if (mode.ToLower().StartsWith("s/"))
                return 0.15;

            return 0;
        }

        public static string GetProcessingInstructionName(int ProcessingInstruction)
        {
            switch (ProcessingInstruction)
            {
                case 1:
                    return "Unpacked and Hang".ToUpper();
                case 2:
                    return "Steam Tunnel".ToUpper();
                case 3:
                    return "Hand Press".ToUpper();
                case 4:
                    return "Other".ToUpper();

            }

            return string.Empty;
        }

        public static string GetFabricStatus(int Stage, int Status, DateTime ActionDate)
        {
            string FabricStatus = "";
            if (Stage == 1)
            {
                FabricStatus = "i-" + Enum.GetName(typeof(FabricApprovalStatus), Status) + " " + ActionDate.ToString("dd MMM");
            }
            else if (Stage == 2)
            {
                FabricStatus = "B-" + Enum.GetName(typeof(FabricApprovalStatus), Status) + " " + ActionDate.ToString("dd MMM");
            }
            if (FabricStatus.IndexOf("SentForApproval") > -1)
            {
                FabricStatus = FabricStatus.Replace("SentForApproval", "S");
            }
            else if (FabricStatus.IndexOf("Approved") > -1)
            {
                FabricStatus = FabricStatus.Replace("Approved", "A");
            }
            else if (FabricStatus.IndexOf("Rejected") > -1)
            {
                FabricStatus = FabricStatus.Replace("Rejected", "R");
            }

            return FabricStatus;
        }

        public static string GetExFactoryPecentageColor(int Percentage)
        {
            if (Percentage > 0 && Percentage <= 50)
                return "#FFFF00";
            else if (Percentage > 50 && Percentage <= 75)
                return "#FFCC00";
            else if (Percentage > 75 && Percentage <= 100)
                return "#00FF70";
            else if (Percentage > 100)
                return "#FE0000";
            else
                return "#ffffff";
        }


        public static string GetQuantitySizeFilledColor(bool IsQuantityFilledUp, bool IsCuttingFormSubbmitted)
        {

            if (IsQuantityFilledUp == false)
                return "#FD9903";
            else if (IsCuttingFormSubbmitted == true)
                return "#00FF70";
            else
                return "#FFFFFF";

        }


        public static string GetGarmentTypeName(GarmentType Type)
        {
            switch (Type)
            {
                case GarmentType.DR:
                    return "Dress";
                    
                case GarmentType.JK:
                    return "Jacket";
                    
                case GarmentType.JS:
                    return "Jumpsuit";
                    
                case GarmentType.PS:
                    return "Playsuit";
                    
                case GarmentType.SH:
                    return "Shorts";
                    
                case GarmentType.SK:
                    return "Skirt";
                    
                case GarmentType.TP:
                    return "Top";
                    
            }

            return string.Empty;
        }

        public static string GetLastComments(string Remarks, string Saparater, string AppendReplacedString, int Length)
        {
            string lastComment = string.Empty;

            if (Saparater == string.Empty)
            {
                lastComment = Remarks;
            }
            else
            {
                if (Remarks.LastIndexOf(Saparater) > -1)
                {
                    lastComment = Remarks.Substring(Remarks.LastIndexOf(Saparater));

                    if (lastComment.IndexOf(Saparater) > -1)
                    {
                        lastComment = lastComment.Replace(Saparater, string.Empty);
                    }
                }
                else
                {
                    lastComment = Remarks;
                }
            }

            if (Length > 0)
            {
                if (lastComment.Length > Length)
                {
                    lastComment = lastComment.Substring(0, (Length - 1));

                    if (AppendReplacedString != string.Empty)
                    {
                        lastComment = lastComment + " " + AppendReplacedString;
                    }
                }
            }
            return lastComment;
        }
        //Added By Ashish for shippingRemark when shipping Remark is Blank or with $$ in Last String on 26/9/2014
        public static string GetComment(string Remarks, string Saparater, string AppendReplacedString, int Length)
        {
            string lastComment = string.Empty;

            if (Saparater == string.Empty)
            {
                lastComment = Remarks;
            }
            else
            {
                if (Remarks.LastIndexOf(Saparater) > -1)
                {
                    lastComment = Remarks.Substring(Remarks.LastIndexOf(Saparater));

                    if (lastComment.IndexOf(Saparater) > -1)
                    {
                        //lastComment = lastComment.Replace(Saparater, string.Empty);
                        string Comment = Remarks.TrimEnd('$');
                        string lastRemarks = Comment.TrimEnd('$');
                        //lastComment = lastRemarks.Substring(lastRemarks.LastIndexOf(Saparater));
                    }

                }
                else
                {
                    lastComment = Remarks;
                }
            }

            if (Length > 0)
            {
                if (lastComment.Length > Length)
                {
                    lastComment = lastComment.Substring(0, (Length - 1));

                    if (AppendReplacedString != string.Empty)
                    {
                        lastComment = lastComment + " " + AppendReplacedString;
                    }
                }
            }
            return lastComment;
        }
        //End
        public static string GetFormatInvoiceAddress(string Address)
        {
            string finalAddress = string.Empty;
            string[] delim = { "," };

            if (Address.IndexOf(",") > -1)
            {
                string[] stringArray = Address.Trim().Split(delim, StringSplitOptions.None);

                if (stringArray.Length > -1)
                {
                    for (int i = 0; i < stringArray.Length; i++)
                    {
                        if (stringArray[i].Trim().IndexOf("\n ") > -1)
                        {
                            finalAddress += stringArray[i].Substring(0, stringArray[i].Trim().IndexOf("\n ")).Trim() + ",\n" + stringArray[i].Substring(stringArray[i].Trim().IndexOf("\n ") + 1).Trim() + ",\n";
                        }
                        else
                        {
                            finalAddress += stringArray[i].Trim() + ",\n";
                        }
                    }

                }
                else
                {
                    finalAddress = Address.Trim();
                }
            }
            else
            {
                finalAddress = Address.Trim();
            }


            if (finalAddress.Length > 2 && finalAddress.Substring(finalAddress.Length - 2).Contains(",\n"))
            {
                finalAddress = finalAddress.Substring(0, finalAddress.Length - 2);
            }

            finalAddress.Replace("\n\n", "\n");

            return finalAddress;
        }

        public static string GetFiveDigitStyleCodeByStyleCode(string StyleCode)
        {
            string styleCode = StyleCode.ToString().PadLeft(5, '0');
            //string tempCode = StyleCode.ToString();
            //int length = tempCode.Length;

            //switch (length)
            //{
            //    case 1:
            //        styleCode = "0000" + tempCode;
            //        break;
            //    case 2 :
            //        styleCode = "000" + tempCode;
            //        break;
            //    case 3:
            //        styleCode = "00" + tempCode;
            //        break;
            //    case 4:
            //        styleCode = "0" + tempCode;
            //        break;
            //    case 5:
            //        styleCode = tempCode;
            //        break;
            //}
            return styleCode;
        }


        public static string ExtractStyleCode(string StyleNumber)
        {
            string StyleCode = string.Empty;
            string[] word = StyleNumber.Trim().Split(' ');
            switch (word.Length)
            {
                case 1:
                    StyleCode = word[0];
                    break;
                case 2:
                    if (word[0].Length == 2)
                        StyleCode = word[1];
                    else
                        StyleCode = word[0];
                    break;
                case 3:
                    StyleCode = word[1];
                    break;
            }
            return StyleCode;



        }
        public static string GetCurrencySymbalByCurrencyType(int CurrencyValue)
        {
            switch (CurrencyValue)
            {
                case 1:
                    return "$";
                case 2:
                    return "£";
                case 3:
                    return "Rs.";
                case 4:
                    return "€";
                case 5:
                    return "KR";
                case 6:
                    return "AUD";
                case 8:
                    return "CHF";
                case 9:
                    return "AED";
            }
            return "£";
        }

        public static string GetHCurrencySymbalInHTMLByCurrencyType(int CurrencyValue)
        {
            switch (CurrencyValue)
            {
                    // $ 
                case 1:
                    return "&#36;";
                    // £
                case 2:
                    return "&#163";
                case 3:
                    return "Rs.";
                    // €
                case 4:
                    return "&#8364;";
                case 5:
                    return "KR";
                case 6:
                    return "AUD";
                case 8:
                    return "CHF";
                case 9:
                    return "AED";
            }
                 // £
            return "&#163";
        }


        public static string GetCurrencySymbalByCurrency(int CurrencyValue)
        {
            switch (CurrencyValue)
            {
                case 1:
                    return "$";
                case 2:
                    return "£";
                case 3:
                    return "Rs.";
                case 4:
                    return "€";
                case 5:
                    return "KR";
                case 6:
                    return "AUD $";
                case 8:
                    return "CHF";
                case 9:
                    return "AED";
            }
            return "£";
        }
        //Added by abhishek 20/7/2020
        public static string FabricPOStatus(string Statusid)
        {
            switch (Statusid)
            {
                case "1":
                    return "Cancel";

                case "2":
                    return "Close";
                

            }
            return "";

        }

        #endregion

       
    }

}




