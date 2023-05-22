using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using iKandi.BLL;
using iKandi.Web.Components;


using System.Collections.Generic;
using iKandi.Common;

namespace iKandi.Web
{
    public partial class iKandiService
    {
        [WebMethod(EnableSession = true)]
        public List<string> SuggestStyles(string q, int limit)
        {
            List<string> allStyles = SuggestForAutoComplete(q, AutoComplete.Style.ToString(), limit);

            //if (ApplicationHelper.LoggedInUser.UserData.Designation != Designation.BIPL_Sales_Manager)
            //{
                List<string> styles = new List<string>();

                foreach (string style in allStyles)
                { 
                    if(!style.Contains("$"))
                        styles.Add(style);
                }

                return styles;
            //}
            //else
            //{
            //    return allStyles;
            //}
        }
        //added by abhishek on 8/2/2017 SyleNumber search for cluster
        [WebMethod(EnableSession = true)]
       
        public List<string> SuggestStylesCluster(string q)
        {
            List<string> allStyles = SuggestForAutoComplete(q, AutoComplete.SerialNumber.ToString(), 10);
            
           
                List<string> styles = new List<string>();

                foreach (string style in allStyles)
                {
                  if (!style.Contains("$"))
                        styles.Add(style);
                }

                return styles;
           
        }
        [WebMethod(EnableSession = true)]
        public List<string> SuggestStylesClusterForUnit(string q)
        {
            List<string> allStyles = SuggestForAutoCompleteUnit(q, AutoComplete.SerialNumber.ToString(), 10,Convert.ToInt32(HttpContext.Current.Session["UnitID"].ToString()));
            var str = HttpContext.Current.Session["UnitID"].ToString();

            List<string> styles = new List<string>();

            foreach (string style in allStyles)
            {
                if (!style.Contains("$"))
                    styles.Add(style);
            }

            return styles;

        }
        //[WebMethod(EnableSession = true)]
        //public  List<string> SerialNumber(string q, int limit) 
        //{
        //    return SuggestForAutoComplete1(q, limit, AutoComplete.SerialNumber.ToString(), 100);           
        //}
        [WebMethod(EnableSession = true)] 
        public List<string> SerialNumberOnly(string q, string limit)
        {
          return SuggestForAutoComplete1(q, limit, AutoComplete.SerialNumberOnly.ToString(), 100);
        }
        [WebMethod(EnableSession = true)]
        public List<string> SerialNumber(string q, string limit)
        {
            return SuggestForAutoComplete1(q, limit, AutoComplete.SerialNumber.ToString(), 100);
        }
        [WebMethod(EnableSession = true)]
        public List<string> SuggestStylesWithCosting(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.StyleWithCosting.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestStylesWithoutCosting(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.StyleWithoutCosting.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestStyleFabric(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.StyleFabric.ToString(), limit);
        }
        /// <summary>
        /// For Insert Owner Detail 4 Oct
        /// <param name="ClientId"></param>
        [WebMethod(EnableSession = true)]
        public void InsertOwnerSampling(string OwnerDetail)
        {
            this.StyleControllerInstance.InsertOwnerSamplingBAL(OwnerDetail);                    
        }

        [WebMethod(EnableSession = true)]
        public void InsertMeterageValue(int intStyleId, string stringMeterage, string stringFabric )
        {
            this.StyleControllerInstance.InsertMeterageValueBAL(intStyleId, stringMeterage, stringFabric);
        }


        [WebMethod(EnableSession = true)]

        public string GetOwnerSampling(int StyleId)
        {
            return this.StyleControllerInstance.GetOwnerSamplingBAL(StyleId);


        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestSamplingFactory(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.SamplingFactory.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public iKandi.Common.Style GetStyleByNumber(string StyleNumber)
        {
            iKandi.Common.Style style = this.StyleControllerInstance.GetStyleByStyleNumber(StyleNumber.Trim());

            return (style.StyleID > 0) ? style : null;
        }
        [WebMethod(EnableSession = true)]
        public iKandi.Common.Style GetStyleByNumber_Courier(string StyleNumber)
        {
            iKandi.Common.Style style = this.StyleControllerInstance.GetStyleByNumber_Courier(StyleNumber.Trim());

            return (style.StyleID > 0) ? style : null;
        }

        [WebMethod(EnableSession = true)]
        public iKandi.Common.Style GetStyleByNumberUserSpacific(string StyleNumber,int userid)
        {
            iKandi.Common.Style style = this.StyleControllerInstance.GetStyleByStyleNumberUserSpacific(StyleNumber.Trim(), userid);

            return (style.StyleID > 0) ? style : null;
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateStylesCourierReceivedOnById(int StyleID)
        {
            //System.Diagnostics.Debugger.Break();

            return this.StyleControllerInstance.UpdateStylesCourierReceivedOnById(StyleID);
        }

        [WebMethod(EnableSession = true)]
        public List<iKandi.Common.SamplingStatus> GetAllStyleSamplingStatus(int ClientID, int SortBy, String Search)
        {
            int UserId;
            //if (ApplicationHelper.LoggedInUser.UserData.DesignationID == (int)Designation.BIPL_Merchandising_SamplingMerchant)
                UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            //else
            //    UserId = -1;
                List<iKandi.Common.SamplingStatus> styles = this.StyleControllerInstance.GetAllStyleSamplingStatus(UserId, ClientID, SortBy, Search);
            return styles;
        }

        [WebMethod(EnableSession = true)]
        public List<iKandi.Common.Style> GetClientStyles(int ClientID)
        {
            List<iKandi.Common.Style> styles = this.StyleControllerInstance.GetClientStyles(ClientID);

            return styles;
        }

        [WebMethod(EnableSession = true)]
        public string GetStylePhotosView(int StyleID, int OrderID, int OrderDetailID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StyleID", StyleID);
            properties.Add("OrderID", OrderID);
            properties.Add("OrderDetailID", OrderDetailID);

            return PageHelper.GetControlHtml("~/UserControls/Lists/StylePhotos.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public bool CloneStyleNumber(string parentStyleNumber, string styleNumber, int clientId, int departmentId, int costingId, string orderIDs, string selectedItemSample,int avg,int Cad,int obsheet,int sam,int ob,int cmt)
        {
            bool success = this.StyleControllerInstance.CloneStyleNumber(parentStyleNumber, styleNumber, clientId, departmentId, costingId, orderIDs, selectedItemSample, avg, Cad, obsheet, sam, ob, cmt);

            if (success)
                GetCostingByStyleNumber(parentStyleNumber, 1, 0);

            return success;
        }
        [WebMethod(EnableSession = true)]
        public bool CloneStyleNumber_New(string parentStyleNumber, string styleNumber, int clientId, int departmentId, int costingId, string orderIDs, string selectedItemSample, int avg, int Cad, int obsheet, int sam, int ob, int cmt, int userID)
        {
            bool success = this.StyleControllerInstance.CloneStyleNumber_New(parentStyleNumber, styleNumber, clientId, departmentId, costingId, orderIDs, selectedItemSample, avg, Cad, obsheet, sam, ob, cmt, userID);

            if (success)
                GetCostingByStyleNumber_New(parentStyleNumber, 1,0);

            return success;
        }

        [WebMethod(EnableSession = true)]
        public List<StyleFabric> GetStyleFabricsByStyleId(int styleId)
        {
            return this.StyleControllerInstance.GetStyleFabricsByStyleId(styleId);
        }

        [WebMethod(EnableSession = true)]
        public string GetPendingStylesView()
        {
            return PageHelper.GetControlHtml("~/UserControls/Lists/CourierStylesPending.ascx", null);
        }

        [WebMethod(EnableSession = true)]
        public List<iKandi.Common.Style> GetStylesByIDs(string StyleIDs)
        {         
            List<iKandi.Common.Style> styles = this.StyleControllerInstance.GetStylesByIDs(StyleIDs);

            return styles;
        }


        [WebMethod(EnableSession = true)]
        public List<iKandi.Common.Style> GetClientTest(string ClientID)
        {
            List<iKandi.Common.Style> styles = this.StyleControllerInstance.GetClient(ClientID);

            return styles;
        }



        [WebMethod(EnableSession = true)]
        public string GetMaxStyleNumber(string Code)
        {
            return this.StyleControllerInstance.GetMaxStyleNumber(Code);
        }

        [WebMethod(EnableSession = true)]
        public bool CostingEnquiryUpdateStyle(string styleNumber, int StyleId, int type)
        {
            return this.StyleControllerInstance.CostingEnquiryUpdateStyle(styleNumber,StyleId, type);
        }

        [WebMethod(EnableSession = true)]
        public string PrintSamplingStatusPDF(string SearchText, int Client, int SortedBy)
        {
            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            return this.PDFControllerInstance.GenerateSamplingStatusFilePDF(SearchText, Client, SortedBy, UserId);
        }

        [WebMethod(EnableSession = true)]
        public string PrintSamplingStatusPDF1(string SearchText, int Client, int SortedBy, string SeasonName, string IsOwnerLoggedIn)
        {
            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            string result = this.PDFControllerInstance.GenerateSamplingStatusFilePDF1(SearchText, Client, SortedBy, UserId,
                                                                             SeasonName,
                                                                             IsOwnerLoggedIn);
            //if(!string.IsNullOrEmpty(result.Trim()))
            //{
            //    WebClient client = new WebClient();
            //    client.DownloadFile(Path.Combine(Constants.TEMP_FOLDER_PATH,result), result);
            //}
            return result;
        }

        [WebMethod(EnableSession = true)]
        public bool DeleteStyleReferenceBlockById(int BlockId)
        {
            //System.Diagnostics.Debugger.Break();
            return this.StyleControllerInstance.DeleteStyleReferenceBlockById(BlockId);
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateUrl(int StyleId, int Type)
        {
            //System.Diagnostics.Debugger.Break();
            return this.StyleControllerInstance.UpdateUrl(StyleId, Type);
        }

        //[WebMethod(EnableSession = true)]
        //public iKandi.Common.Fits GetFitsByStyleNumber(int StyleNumber)
        //{
        //   // System.Diagnostics.Debugger.Break();
        //    iKandi.Common.Fits fits = this.FITsControllerInstance.GetFitsByStyleNumber(StyleNumber);
        //    return (fits.Id > 0) ? fits : null;
        //}

        [WebMethod(EnableSession = true)]
        public bool GetIsValidateStyleCodeByStyleNumber(string StyleNumber)
        {
           // System.Diagnostics.Debugger.Break();
            bool status = false;
            status = this.FITsControllerInstance.GetIsValidateStyleCodeByStyleNumber(StyleNumber);
            return status;
        }

        [WebMethod(EnableSession = true)]
        public List<Fits> GetFitsDropdownRelatedInformation(string StyleCodeVersion, int departmentID)
        {
            return this.FITsControllerInstance.GetFitsDropdownRelatedInformation(StyleCodeVersion, departmentID);
        }

        [WebMethod(EnableSession = true)]
        public List<StyleFabric> GetStyleByStyleId_Multiple(string StyleID)
        {
            return this.StyleControllerInstance.GetStyleByStyleId_Multiple(StyleID);
        }

        // Update By Ravi kumar on 11/8/15 For add style from order
        [WebMethod(EnableSession = true)]
        public string IsRepeatedStyle(int StyleId)
        {
            return this.StyleControllerInstance.IsRepeatedStyle(StyleId);
        }
        //added by abhishek 14/9/2016
        [WebMethod(EnableSession = true)]
        public List<string> SuggestCategories(string q, string limit)
        {
            return SuggestForAutoComplete1(q, limit, AutoComplete.ManageCategory.ToString(), 100);
        }
        [WebMethod(EnableSession = true)]
        public List<string> SuggestGroupCode(string q, int limit)
        {
            List<string> allStyles = SuggestForAutoComplete(q, AutoComplete.ManageCategory.ToString(), limit);           
            return allStyles;           
        }
        //added by abhishek for Supplier admin autocomp
        [WebMethod(EnableSession = true)]
        public List<string> SuggestGroupCode_fabric(string q, int limit)
        {
            List<string> allStyles = SuggestForAutoCompletesupplier(q, AutoComplete.suggestGroupCode_fabric.ToString(), limit);
            return allStyles;
        }
        [WebMethod(EnableSession = true)]
        public List<string> SuggestGroupCode_accsessory(string q, int limit)
        {
            List<string> allStyles = SuggestForAutoCompletesupplier(q, AutoComplete.suggestGroupCode_Accessoires.ToString(), limit);
            return allStyles;
        }


        [WebMethod(EnableSession = true)]
        public List<string> SuggestAccsessoryTradeName(string q, int limit)
        {
            List<string> allStyles = SuggestForAutoComplete(q, AutoComplete.StyleAccsessory.ToString(), limit);
            return allStyles;
        }
        //end by abhishek 
        // Add By Ravi kumar for PatternAllocation
        [WebMethod(EnableSession = true)]
        public List<string> SuggestStylesForPattern(string q, int limit)
        {
            List<string> allStyles = SuggestForAutoComplete(q, AutoComplete.StyleForPattern.ToString(), limit);

            if (ApplicationHelper.LoggedInUser.UserData.Designation != Designation.BIPL_Sales_Manager)
            {
                List<string> styles = new List<string>();

                foreach (string style in allStyles)
                {
                    if (!style.Contains("$"))
                        styles.Add(style);
                }

                return styles;
            }
            else
            {
                return allStyles;
            }
        }
        //abhishek 
        [WebMethod(EnableSession = true)]
        public string GetMaxStyleCode()
        {
            return this.StyleControllerInstance.GetMaxStyleCode(ApplicationHelper.LoggedInUser.UserData.DesignerCode.ToString());
        }

        [WebMethod(EnableSession = true)]
        public List<LinePlanningStyle> GetStyleCodeDetails(int UnitId, int LineNo, string Status, string StylePrefix)
        {
            return this.AdminControllerInstance.GetStyleCodeDetails(UnitId, LineNo, Status, StylePrefix);
        }
      //abhishek 26/12/2017 Autopopulate Multiple Param
        [WebMethod(EnableSession = true)]
        public List<string> SuggestStylesCode(string q, int limit)
        {          
          int UnitID=Convert.ToInt32(HttpContext.Current.Session["UnitID"].ToString());
          int LineNumber = Convert.ToInt32(HttpContext.Current.Session["LineNumber"].ToString());
          string status = HttpContext.Current.Session["status"].ToString();
          string StylePrefix = HttpContext.Current.Session["StylePrefix"].ToString();
          List<string> allStyles = SuggestForAutoCompleteUnitLine(q, UnitID, LineNumber, status);
          return allStyles;

        }
        [WebMethod(EnableSession = true)]
        public bool UpdateStylesFabricDetails(int ID,string dates,int status,string flag)
        {       
          return this.StyleControllerInstance.UpdateStylesFabricDetails(ID, dates, status, flag);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateBuyerStyleNumber(string cValue, string StyleId)
        {
            return this.StyleControllerInstance.UpdateBuyerStyleNumber(cValue, StyleId);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateSelectExports(string IsCheked, string StyleId, string AllSelect)
        {
            return this.StyleControllerInstance.UpdateSelectExports(IsCheked, StyleId, AllSelect);
        }
        [WebMethod(EnableSession = true)]
        public string UpdateStylesFabricStatus(int ID, string Etadate)
        {
          return this.StyleControllerInstance.UpdateStylesFabricStatus(ID, Etadate);
        }
        [WebMethod(EnableSession = true)]
        public string UpdateStylesFabricStatusActual(int ID, string Etadate, string UserId)
        {
            return this.StyleControllerInstance.UpdateStylesFabricStatusActual(ID, Etadate, UserId);
        }
        [WebMethod(EnableSession = true)]
        public List<StyleFabric> GetStyleFabricsByStyleId_New(int styleId)
        {
            return this.StyleControllerInstance.GetStyleFabricsByStyleId_New(styleId);
        }
        [WebMethod(EnableSession = true)]
        public List<StyleFabric> Get_RegisterAcc(string RegisterAccName)
        {
            return this.StyleControllerInstance.Get_RegisterAcc(RegisterAccName);
        }
        [WebMethod(EnableSession = true)]
        public List<StyleFabric> Get_RegisterProcess_Name(string RegisterProcessName)
        {
            return this.StyleControllerInstance.Get_RegisterProcess_Name(RegisterProcessName);
        }
        [WebMethod(EnableSession = true)]
        public List<StyleFabric> Get_RegisterFabric(string RegisterFabricName)
        {
            return this.StyleControllerInstance.Get_RegisterFabric(RegisterFabricName);
        }
        //Added by RSB on 1 jul 2022 for design form fabric
        [WebMethod(EnableSession = true)]
        public List<StyleFabric> Get_RegisterFabric_Design(string RegisterFabricName)
        {
            return this.StyleControllerInstance.Get_RegisterFabric_Design(RegisterFabricName);
        }
        // end of code
        [WebMethod(EnableSession = true)]
        public List<StyleFabric> Get_Register_Print(string RegisterPrint)
        {
            return this.StyleControllerInstance.Get_Register_Print(RegisterPrint);
        }
        //add code by bhrata on 6-2-20
        [WebMethod(EnableSession = true)]
        public string Get_Register_MarketingTag(string RegisterTags)
        {
            return this.StyleControllerInstance.Get_Register_MarketingTag(RegisterTags);
        }

        [WebMethod(EnableSession = true)]
        public string GetStylePhotosView_New(int StyleID, int OrderID, int OrderDetailID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StyleID", StyleID);
            properties.Add("OrderID", OrderID);
            properties.Add("OrderDetailID", OrderDetailID);

            return PageHelper.GetControlHtml("~/UserControls/Lists/StylePhotos.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public List<StyleFabric> Get_Final_Rate_From_PO(string fabricname, string fabtype, string RegisterPrint)
        {
            return this.StyleControllerInstance.Get_Final_Rate_From_PO(fabricname, fabtype, RegisterPrint);
        }
        
    }
    

}
