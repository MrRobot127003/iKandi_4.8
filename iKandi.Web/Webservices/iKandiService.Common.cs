using System;
using System.Data;
using System.Web.Security;
using System.Web.Services;
using iKandi.BLL;
using System.IO;
using System.Collections.Generic;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class iKandiService
    {
        [WebMethod(EnableSession = true)]
        public string GetDesignationPopup(string TaskName, string MainTaskId)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("TaskName", TaskName);
            properties.Add("MainTaskId", Convert.ToInt32(MainTaskId));
            return PageHelper.GetControlHtml("~/UserControls/Forms/TaskDesignationMappingPopup.ascx", properties);
        }

       

        [WebMethod(EnableSession = true)]
        public List<string> SuggestForAutoCompleteUnit(string searchValue, string searchContext, int limit, int UnitID)
        {
            List<string> searchResults = this.CommonControllerInstance.SuggestForAutoCompleteByunitid(searchValue, searchContext, UnitID);

            List<string> filteredSearchResults = new List<string>();

            // Looping through the datasource to select the items that match
            foreach (string result in searchResults)
            {
                if (result.ToLower().Contains(searchValue.ToLower()))
                {
                    filteredSearchResults.Add(result.ToUpper());
                }
            }

            // Sort the list
            filteredSearchResults.Sort();

            // Return the items that contained the text in alphabetical order
            return filteredSearchResults;
        }
        [WebMethod(EnableSession = true)]
        public List<string> SuggestForAutoComplete(string seatchText, string searchArea, int limit)
        {
            List<string> searchResults = this.CommonControllerInstance.SuggestForAutoComplete(seatchText, searchArea);

            List<string> filteredSearchResults = new List<string>();

            // Looping through the datasource to select the items that match
            foreach (string result in searchResults)
            {
                //updated by bharat 4-jan-19
                //if (result.ToLower().Contains(searchValue.ToLower()))
                //{
                // filteredSearchResults.Add(result.ToUpper());
                filteredSearchResults.Add(result);
                // }
            }

            // Sort the list
            //filteredSearchResults.Sort();

            // Return the items that contained the text in alphabetical order
            return filteredSearchResults;
        }
        //27042023 RajeevS
        [WebMethod(EnableSession = true)]
        public List<string> SuggestForAccAutoComplete(string SearchText, string SearchArea, int limit)
        {
            List<string> searchResults = this.CommonControllerInstance.SuggestForAccAutoComplete(SearchText,SearchArea );

            List<string> filteredSearchResults = new List<string>();         
            foreach (string result in searchResults)
            {            
                filteredSearchResults.Add(result);           
            }
            return filteredSearchResults;
        }
        //27042023
        // Added By Ravi kumar for autosuggestion fro faults

        [WebMethod(EnableSession = true)]
        public List<string> SuggestForAutoCompleteFault(string searchValue, string searchContext, int limit)
        {
            List<string> searchResults = this.CommonControllerInstance.SuggestForAutoComplete(searchValue, searchContext);

            List<string> filteredSearchResults = new List<string>();

            // Looping through the datasource to select the items that match
            foreach (string result in searchResults)
            {
                filteredSearchResults.Add(result);
                //if (result.ToLower().Contains(searchValue.ToLower()))
                //{
                //    filteredSearchResults.Add(result.ToUpper());
                //}
            }

            // Sort the list
            filteredSearchResults.Sort();

            // Return the items that contained the text in alphabetical order
            return filteredSearchResults;
        }
        [WebMethod(EnableSession = true)]
        public List<string> SuggestForAutoComplete1(string searchValue, string str, string searchContext, int limit)
        {
            List<string> searchResults = this.CommonControllerInstance.SuggestForAutoComplete1(searchValue, str, searchContext);

            List<string> filteredSearchResults = new List<string>();

            // Looping through the datasource to select the items that match
            foreach (string result in searchResults)
            {
                if (result.ToLower().Contains(searchValue.ToLower()))
                {
                    filteredSearchResults.Add(result.ToUpper());
                }
            }

            // Sort the list
            filteredSearchResults.Sort();

            // Return the items that contained the text in alphabetical order
            return filteredSearchResults;
        }

        //[WebMethod(EnableSession = true)]
        //public List<string> SuggestForFourPoint( string datakey,string type)
        //{
        //    return this.FourPointControllerInstance.GetFourPoint(type,datakey);
        //}

        /// <summary>
        /// For Autocomplete Story : Yaten 31 Aug
        /// </summary>
        /// <param name="searchValue"></param>
        /// <param name="searchContext"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public List<string> SuggestStoryBAL(string searchValue)
        {
            List<string> searchResults = this.CommonControllerInstance.SuggestStoryBAL(searchValue);

            List<string> filteredSearchResults = new List<string>();

            // Looping through the datasource to select the items that match
            foreach (string result in searchResults)
            {
                if (result.ToLower().Contains(searchValue.ToLower()))
                {
                    filteredSearchResults.Add(result.ToUpper());
                }
            }

            // Sort the list
            filteredSearchResults.Sort();

            // Return the items that contained the text in alphabetical order
            return filteredSearchResults;
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestSupplierNameCommon(string searchValue)
        {
            List<string> searchResults = this.CommonControllerInstance.SuggestSupplierNameBAL(searchValue);

            List<string> filteredSearchResults = new List<string>();

            // Looping through the datasource to select the items that match
            foreach (string result in searchResults)
            {
                if (result.ToLower().Contains(searchValue.ToLower()))
                {
                    filteredSearchResults.Add(result.ToUpper());
                }
            }

            // Sort the list
            filteredSearchResults.Sort();

            // Return the items that contained the text in alphabetical order
            return filteredSearchResults;
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestProcessOrderBAL(string searchValue)
        {
            List<string> searchResults = this.CommonControllerInstance.SuggestProcessOrderBAL(searchValue);

            List<string> filteredSearchResults = new List<string>();

            // Looping through the datasource to select the items that match
            foreach (string result in searchResults)
            {
                if (result.ToLower().Contains(searchValue.ToLower()))
                {
                    filteredSearchResults.Add(result.ToUpper());
                }
            }

            // Sort the list
            filteredSearchResults.Sort();

            // Return the items that contained the text in alphabetical order
            return filteredSearchResults;
        }


        [WebMethod(EnableSession = true)]
        public int GetModeDays(int modeValue)
        {
            return iKandi.BLL.CommonHelper.GetModeDays(modeValue);
        }

        [WebMethod(EnableSession = true)]
        public int GetOrderPackingType(int modeValue)
        {
            return iKandi.BLL.CommonHelper.GetOrderPackingType(modeValue);
        }


        [WebMethod(EnableSession = true)]
        public double GetZipRate(string zipDetail, int zipType, string zipSize)
        {
            return this.CommonControllerInstance.GetZipRate(zipDetail, (ZipRateType)zipType, zipSize);
        }



        [WebMethod(EnableSession = true)]
        public double GetZipRateStyle(string zipDetail, int zipType, string zipSize, int StyleId)
        {
            return this.CommonControllerInstance.GetZipRateStyle(zipDetail, (ZipRateType)zipType, zipSize, StyleId);
        }


        [WebMethod(EnableSession = true)]
        public bool SavePacking(Packing objPacking)
        {
            return this.DeliveryControllerInstance.SavePacking(objPacking);
        }

        [WebMethod(EnableSession = true)]
        public string GetPercentageColor(int percentageValue)
        {
            return iKandi.Common.Constants.GetPercentageColor(percentageValue);
        }

        [WebMethod(EnableSession = true)]
        public string GetSerialNumberColor(string strExFactoryDate)
        {
            DateTime exFactoryDate = DateHelper.ParseDate(strExFactoryDate).Value;
            return iKandi.Common.Constants.GetSerialNumberColor(exFactoryDate);
        }

        [WebMethod(EnableSession = true)]
        public string GetOrderDeliveryModeColor(int mode)
        {
            return iKandi.BLL.CommonHelper.GetDeliveryModeColor(mode);
        }

        [WebMethod(EnableSession = true)]
        public string GetExFactoryColor(string strExFactoryDate, string strDCDate, int mode)
        {
            DateTime exFactoryDate = DateHelper.ParseDate(strExFactoryDate).Value;
            DateTime dcDate = DateHelper.ParseDate(strDCDate).Value;

            return iKandi.BLL.CommonHelper.GetExFactoryColor(exFactoryDate, dcDate, mode);
        }

        [WebMethod(EnableSession = true)]
        public string GetStatusModeColor(int statusModeId)
        {
            return iKandi.Common.Constants.GetStatusModeColor(statusModeId);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestBrandCompany(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.INDBlockBrand.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestBrandCompanyRef(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.INDBlockReference.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestINDBlockNumber(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.INDBlock.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestRefBlock(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.ReferenceBlock.ToString(), limit);
        }


        [WebMethod(EnableSession = true)]
        public List<string> SuggestForPrintNumberAutoComplete2(string searchValue, string searchContext, int limit, int clientId, int PrintCategory)
        {
            List<string> searchResults = this.CommonControllerInstance.SuggestForPrintNumberAutoComplete2(searchValue, searchContext, clientId, PrintCategory);

            List<string> filteredSearchResults = new List<string>();

            // Looping through the datasource to select the items that match
            foreach (string result in searchResults)
            {
                //if (result.ToLower().Contains(searchValue.ToLower()))
                //{
                filteredSearchResults.Add(result);
                //}
            }

            // Sort the list
            //filteredSearchResults.Sort();

            // Return the items that contained the text in alphabetical order
            return filteredSearchResults;
        }

        // Adding new service for the color suggestion in design form by Bharat veer dated on 22 may 2019
        [WebMethod(EnableSession = true)]
        public List<string> SuggestForColorAutoComplete2(string searchValue, int clientId, int PrintCategory)
        {
            List<string> searchResults = this.CommonControllerInstance.SuggestForColorAutoComplete2(searchValue, clientId, PrintCategory);

            List<string> filteredSearchResults = new List<string>();

            // Looping through the datasource to select the items that match
            foreach (string result in searchResults)
            {
                if (result.ToLower().Contains(searchValue.ToLower()))
                {
                    filteredSearchResults.Add(result);
                }
            }

            // Sort the list
            filteredSearchResults.Sort();

            // Return the items that contained the text in alphabetical order
            return filteredSearchResults;
        }

        /// <summary>
        ///Yaten : Fetch Multiple prints by Style id
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public List<string> SuggestPrintNumbers_ForMultiplePrints2(string searchValue, string searchContext, int limit, int clientId, string stno, int PrintCategory)
        {
            int s = 0;
            List<string> searchResults = this.CommonControllerInstance.SuggestPrintNumbers_ForMultiplePrints2(searchValue, searchContext, clientId, stno, PrintCategory);
            List<string> filteredSearchResults = new List<string>();
            List<string> filterwithOther = new List<string>();
            List<string> LinkedtoStyle = new List<string>();
            List<string> tempList = new List<string>();
            foreach (string r in searchResults)
            {
                filterwithOther.Add(r);
                if (r.ToLower() == "--others--")
                {
                    filterwithOther.Remove("--Others--");
                    break;
                }
            }
            foreach (string r2 in searchResults)
            {
                if (s == 1)
                {
                    filteredSearchResults.Add(r2);
                }
                if (r2.ToLower() == "--others--")
                {
                    s = 1;
                }
            }
            //filteredSearchResults.Sort();
            int intCount = filterwithOther.Count;

            int intfilteredSearchResultsCount = filteredSearchResults.Count;
            if (intfilteredSearchResultsCount == 0)
            {
                filterwithOther.Remove("--others--");
            }

            if (intCount > 0)
            {
                tempList.Add("--Others--");
                tempList.AddRange(filteredSearchResults);
                filterwithOther.AddRange(tempList);
            }
            else
            {
                filterwithOther.AddRange(filteredSearchResults);
            }
            if (filterwithOther.Contains("--Others--"))
            {
                LinkedtoStyle.Add("--Linked to Style--");
                LinkedtoStyle.AddRange(filterwithOther);
                return LinkedtoStyle;
            }
            return filterwithOther;
        }

        //added on 07 Jan 2021 start
        [WebMethod(EnableSession = true)]
        public List<string> AutoComplete_Fabric_Pending_OrderSummary1(string searchValue, string searchContext, int limit, int clientId, string stno, int PrintCategory)
        {
            int s = 0;
            List<string> searchResults = this.CommonControllerInstance.AutoComplete_Fabric_Pending_OrderSummary1(searchValue, searchContext, clientId, stno, PrintCategory);
            List<string> filteredSearchResults = new List<string>();
            List<string> filterwithOther = new List<string>();
            List<string> LinkedtoStyle = new List<string>();
            List<string> tempList = new List<string>();
            foreach (string r in searchResults)
            {
                filterwithOther.Add(r);
                //if (r.ToLower() == "--others--")
                //{
                //    filterwithOther.Remove("--Others--");
                //    break;
                //}
            }
            foreach (string r2 in searchResults)
            {
                if (s == 1)
                {
                    filteredSearchResults.Add(r2);
                }
                //if (r2.ToLower() == "--others--")
                //{
                //    s = 1;
                //}
            }
            //filteredSearchResults.Sort();
            int intCount = filterwithOther.Count;

            int intfilteredSearchResultsCount = filteredSearchResults.Count;
            //if (intfilteredSearchResultsCount == 0)
            //{
            //    filterwithOther.Remove("--others--");
            //}

            if (intCount > 0)
            {
                //tempList.Add("--Others--");
                tempList.AddRange(filteredSearchResults);
                filterwithOther.AddRange(tempList);
            }
            else
            {
                filterwithOther.AddRange(filteredSearchResults);
            }
            //if (filterwithOther.Contains("--Others--"))
            //{
            //LinkedtoStyle.Add("--Linked to Style--");
            LinkedtoStyle.AddRange(filterwithOther);
            return LinkedtoStyle;
            //}
            return filterwithOther;
        }
        //added on 07 Jan 2021 end

        //added on 27 Jan 2021 start
        [WebMethod(EnableSession = true)]
        public List<string> AutoComplete_Accessory_Pending_OrderSummary1(string searchValue, string searchContext, int limit, int clientId, string stno, int PrintCategory)
        {
            int s = 0;
            List<string> searchResults = this.CommonControllerInstance.AutoComplete_Accessory_Pending_OrderSummary1(searchValue, searchContext, clientId, stno, PrintCategory);
            List<string> filteredSearchResults = new List<string>();
            List<string> filterwithOther = new List<string>();
            List<string> LinkedtoStyle = new List<string>();
            List<string> tempList = new List<string>();
            foreach (string r in searchResults)
            {
                filterwithOther.Add(r);
            }
            foreach (string r2 in searchResults)
            {
                if (s == 1)
                {
                    filteredSearchResults.Add(r2);
                }
            }
            int intCount = filterwithOther.Count;

            int intfilteredSearchResultsCount = filteredSearchResults.Count;


            if (intCount > 0)
            {
                tempList.AddRange(filteredSearchResults);
                filterwithOther.AddRange(tempList);
            }
            else
            {
                filterwithOther.AddRange(filteredSearchResults);
            }

            LinkedtoStyle.AddRange(filterwithOther);
            return LinkedtoStyle;
            //}
            return filterwithOther;
        }
        //added on 27 Jan 2021 end

        /// <summary>
        /// Yaten : Fetch Multiple prints by Style No.
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public List<string> SuggestPrintNumbers_ForMultiplePrintsStyleNumber2(string searchValue, string searchContext, int limit, int clientId, string stno)
        {
            int s = 0;
            List<string> searchResults = this.CommonControllerInstance.SuggestPrintNumbers_ForMultiplePrintsStyleNumber2(searchValue, searchContext, clientId, stno);

            List<string> filteredSearchResults = new List<string>();
            List<string> filterwithOther = new List<string>();
            List<string> LinkedtoStyle = new List<string>();
            List<string> tempList = new List<string>();
            foreach (string r in searchResults)
            {
                filterwithOther.Add(r);
                if (r.ToLower() == "----others----")
                {
                    filterwithOther.Remove("----Others----");
                    break;
                }
            }
            foreach (string r2 in searchResults)
            {
                if (s == 1)
                {
                    filteredSearchResults.Add(r2);
                }
                if (r2.ToLower() == "----others----")
                {
                    s = 1;
                }
            }
            // Sort the list
            filteredSearchResults.Sort();
            int intCount = filterwithOther.Count;
            int intfilteredSearchResultsCount = filteredSearchResults.Count;
            if (intfilteredSearchResultsCount == 0)
            {
                filterwithOther.Remove("----others----");
            }
            if (intCount > 0)
            {
                tempList.Add("----Others----");
                tempList.AddRange(filteredSearchResults);
                filterwithOther.AddRange(tempList);
            }
            else
            {
                filterwithOther.AddRange(filteredSearchResults);
            }
            if (filterwithOther.Contains("----Others----"))
            {
                LinkedtoStyle.Add("Linked to Style");
                LinkedtoStyle.AddRange(filterwithOther);
                return LinkedtoStyle;
            }
            else
            {
                return filterwithOther;
            }
        }

        [WebMethod(EnableSession = true)]
        public string GeneratePDF(string Url, int Width, int Height)
        {
            String userName = ApplicationHelper.LoggedInUser.UserData.Username;

            MembershipUser mUser = Membership.GetUser(userName);

            String password = "(CapTi17603&12%99#P$}";// mUser.GetPassword();"(B!*&IKB@2016@ErP)"


            String fileName = "fileName";

            String filePath = "";

            if (Url.ToUpper().IndexOf("PACKINGLIST") > -1 || Url.ToUpper().IndexOf("INLINEPPMEDIT") > -1 || Url.ToUpper().IndexOf("FABRICACCESSORIESWORKSHEET123") > -1 || Url.ToUpper().IndexOf("CLIENTLISTING") > -1)
            {
                if (Url.ToUpper().IndexOf("CLIENTLISTING") > -1)
                {
                    Height -= 100;
                }
                filePath = this.PDFControllerInstance.GeneratePDFForMultiPagePrint(Url, fileName, userName, password, Width, Height);
            }
            else
            {
                if (Url.ToUpper().IndexOf("CLIENTEDIT") > -1)
                {
                    Width += 30;
                }
                filePath = this.PDFControllerInstance.GeneratePDFForPrint(Url, fileName, userName, password, Width, Height);

            }

            int index = filePath.LastIndexOf("\\");


            Session["PathForPDF"] = Constants.BaseSiteUrl + "/uploads/temp/" + filePath.Substring(index + 1);
            return Constants.BaseSiteUrl + "/uploads/temp/" + filePath.Substring(index + 1);
        }

        [WebMethod(EnableSession = true)]
        public string GenerateMergePDF(string Url, int Width, int Height)
        {
            String userName = ApplicationHelper.LoggedInUser.UserData.Username;
            PdfMerge MergeFile = new PdfMerge();
            MembershipUser mUser = Membership.GetUser(userName);

            String password = "(C@pT!176O3&12%:9#P$}";// mUser.GetPassword(); "(B!*&IKB@2016@ErP)"

            String fileName = "fileName";

            String filePath1 = "";
            String filePath2 = "";
            String filePath3 = "";

            filePath1 = this.PDFControllerInstance.GeneratePDFForPrint(Url, fileName, userName, password, Width, Height);
            Url = Url.Replace("btn=1", "btn=2");
            filePath2 = this.PDFControllerInstance.GeneratePDFForPrint(Url, fileName, userName, password, Width, Height);
            Url = Url.Replace("btn=2", "btn=3");
            filePath3 = this.PDFControllerInstance.GeneratePDFForPrint(Url, fileName, userName, password, Width, Height);

            int index = filePath1.LastIndexOf("\\");
            filePath1 = Constants.BaseSiteUrl + "/uploads/temp/" + filePath1.Substring(index + 1);
            filePath2 = Constants.BaseSiteUrl + "/uploads/temp/" + filePath2.Substring(index + 1);
            filePath3 = Constants.BaseSiteUrl + "/uploads/temp/" + filePath3.Substring(index + 1);
            string[] str = { filePath1, filePath2, filePath3 };
            MergeFile.AddDocument(str[0]); MergeFile.AddDocument(str[1]); MergeFile.AddDocument(str[2]);
            string pdfFilePath = Path.Combine(Constants.TEMP_FOLDER_PATH, "Accessory" + "-" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".pdf");
            MergeFile.Merge(pdfFilePath);
            return Constants.BaseSiteUrl + "/uploads/temp/" + pdfFilePath.Substring(index + 1);
        }


        [WebMethod(EnableSession = true)]
        public string GeneratePDFNew()
        {
            //CourierControllerInstance.GeneratePDFNew(iKandi.Common.Constants.SCREEN_SHOT_FOLDER_PATH + "test.pdf", "Quote Tool", Session["quotetool1"] as DataTable);

            return Constants.BaseSiteUrl + "/uploads/screenshots/test.pdf";
        }


        [WebMethod(EnableSession = true)]
        public void BackgroundProcess()
        {
            BackgroundProcessingController bgController = new BackgroundProcessingController();
            bgController.ExecuteProcess();
        }

        [WebMethod(EnableSession = true)]
        public string[] GetStatusModeNameAndColor(int currentStatusId)
        {
            string[] statusModeAndColor = new string[2];
            statusModeAndColor[0] = Constants.GetStatusModeName(currentStatusId);
            statusModeAndColor[1] = Constants.GetStatusModeColor(currentStatusId);
            return statusModeAndColor;
        }

        [WebMethod(EnableSession = true)]
        public bool ChangeStatusToOnHold(int orderDetailId, string remarks)
        {
            // System.Diagnostics.Debugger.Break();
            return this.WorkflowControllerInstance.ChangeStatusToOnHold(orderDetailId, remarks);
        }

        [WebMethod(EnableSession = true)]
        public string GetOrdersForShipmentPlanningAdvise(int shipmentId)
        {
            DataSet dsOrderDetail = this.DeliveryControllerInstance.GetOrderDetailByShipmentId(shipmentId);

            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("OrderDetailsForShipmentAdvise", dsOrderDetail);
            return PageHelper.GetControlHtml("~/UserControls/Lists/ShipmentPlanningAdviseOrdersPopup.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public bool ChangeStatusToPrevious(int orderDetailId, string remarks)
        {
            return this.WorkflowControllerInstance.ChangeStatusToPrevious(orderDetailId, remarks);
        }

        [WebMethod(EnableSession = true)]
        public List<Category> GetSubGroupByGroupID(int CategoryID)
        {
            //System.Diagnostics.Debugger.Break();
            return this.AdminControllerInstance.GetSubCategories(CategoryID);
        }

        [WebMethod(EnableSession = true)]
        public string GetIdentification(int CategoryID, int SubCategoryID, int Type)
        {
            //System.Diagnostics.Debugger.Break();
            return this.CommonControllerInstance.GetIdentification(CategoryID, SubCategoryID, Type);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestForRegisteredTradeNamesAutoComplete(string searchValue, int limit)
        {
            List<string> searchResults = this.CommonControllerInstance.SuggestForRegisteredTradeNamesAutoComplete(searchValue);

            List<string> filteredSearchResults = new List<string>();

            // Looping through the datasource to select the items that match
            foreach (string result in searchResults)
            {
                if (result.ToLower().Contains(searchValue.ToLower()))
                {
                    filteredSearchResults.Add(result);
                }
            }

            // Sort the list
            filteredSearchResults.Sort();

            // Return the items that contained the text in alphabetical order
            return filteredSearchResults;
        }


        [WebMethod(EnableSession = true)]
        public List<string> SuggestForRegisteredTradeNamesAutoCompleteForOrder(string searchValue, int limit)
        {
            List<string> searchResults = this.CommonControllerInstance.SuggestForRegisteredTradeNamesAutoCompleteForOrder(searchValue);

            List<string> filteredSearchResults = new List<string>();

            // Looping through the datasource to select the items that match
            foreach (string result in searchResults)
            {
                if (result.ToLower().Contains(searchValue.ToLower()))
                {
                    filteredSearchResults.Add(result);
                }
            }

            // Sort the list
            filteredSearchResults.Sort();

            // Return the items that contained the text in alphabetical order
            return filteredSearchResults;
        }



        [WebMethod(EnableSession = true)]
        public string GetBookingCalculatorView()
        {
            return PageHelper.GetControlHtml("~/UserControls/Forms/BookingCalculator.ascx", null);
        }

        [WebMethod(EnableSession = true)]
        public string GetLeaveInformationView(int LeaveID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("LeaveID", LeaveID);

            return PageHelper.GetControlHtml("~/UserControls/Lists/LeaveDetailsControl.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestContractNumbers(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.ContractNumber.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestFitsFiveDigitStyleCode(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.FitsFiveDigitStyleCode.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestFitsStyleCodeVersion(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.FitsStyleCodeVersion.ToString(), limit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="q"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public List<string> GetAllClientsNames(string q, int limit)
        {
            return this.ReportControllerInstance.GetAllClientNames(q);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="q"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetAllClientsIds(string q)
        {
            return this.ReportControllerInstance.GetAllClientsId(q);
        }

        [WebMethod(EnableSession = true)]
        public int CreateDepartment(string deptName, int compId)
        {
            return this.AdminControllerInstance.CreateDepartment(deptName, compId);
        }

        [WebMethod(EnableSession = true)]
        public string ShowDepartmentPopUp(int compId)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("CompanyId", compId);

            return PageHelper.GetControlHtml("~/UserControls/Forms/AddDeptToUF.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public int CreateDesignation(string desigName, int deptId, int linemanager, bool isHod)
        {
            return this.AdminControllerInstance.CreateDesignation(desigName, deptId, linemanager, isHod);
        }

        [WebMethod(EnableSession = true)]
        public string ShowDesignationPopUp(int deptId)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("DepartmentId", deptId);

            return PageHelper.GetControlHtml("~/UserControls/Forms/AddDesgToUF.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public List<QualityContract> GetContractBYOrder(string OrderId, string InspectionID)
        {
            return this.QualityControllerInstance.GetContractBYOrder(OrderId, InspectionID);
        }

        [WebMethod(EnableSession = true)]
        public string CreateQualityProxy(string OrderDetailID, string InspectionID, string None, string RefOrderDetailID)
        {
            return QualityControllerInstance.CreateQualityProxy(OrderDetailID, InspectionID, None, RefOrderDetailID);
        }

        [WebMethod(EnableSession = true)]
        public string CreateQCContractsProxy(string OrderDetailID, string InspectionID, bool IsTaskDone, string RefOrderDetailID, int InLineFromPopUp, int Status, int QualityControlId)
        {
            return QualityControllerInstance.CreateQCContractsProxy(OrderDetailID, InspectionID, IsTaskDone, RefOrderDetailID, InLineFromPopUp, Status, QualityControlId);
        }


        //Add by Prabhaker  on 31-aug-18
        [WebMethod(EnableSession = true)]
        public string CreateQCContractsProxy_Rescan(string OrderDetailID, string RescanDate, int QualityControlId, bool IsTaskDone)
        {
            return QualityControllerInstance.CreateQCContractsProxy_Rescan(OrderDetailID, RescanDate, QualityControlId, IsTaskDone);
        }


        //End Of Code


        //Gajendra New Costing
        [WebMethod(EnableSession = true)]
        public List<string> GetFabricList_ByTradeName(string searchValue, int limit)
        {
            List<string> searchResults = this.CommonControllerInstance.GetFabricList_ByTradeName(searchValue);
            List<string> filteredSearchResults = new List<string>();
            foreach (string result in searchResults)
            {
                if (result.ToLower().Contains(searchValue.ToLower()))
                {
                    filteredSearchResults.Add(result);
                }
            }
            filteredSearchResults.Sort();
            return filteredSearchResults;
        }
        [WebMethod(EnableSession = true)]
        public List<string> GetAccessoryList_ByTradeName(string searchValue, int limit, int ClientId, int ParentDeptId, int DeptId)
        {
            List<string> searchResults = this.CommonControllerInstance.GetAccessoryList_ByTradeName(searchValue, -1, ClientId, ParentDeptId, DeptId);
            List<string> filteredSearchResults = new List<string>();
            foreach (string result in searchResults)
            {
                if (result.ToLower().Contains(searchValue.ToLower()))
                {
                    filteredSearchResults.Add(result);
                }
            }
            filteredSearchResults.Sort();
            return filteredSearchResults;
        }

        [WebMethod(EnableSession = true)]
        public List<string> GetAccessoryList_ByTradeName_newtubularAutoComp(string searchValue, int limit, int StyleId, int ClientId, int ParentDeptId, int DeptId)
        {
            List<string> searchResults = this.CommonControllerInstance.GetAccessoryList_ByTradeName(searchValue, StyleId, ClientId, ParentDeptId, DeptId);
            List<string> filteredSearchResults = new List<string>();
            foreach (string result in searchResults)
            {
                //if (result.ToLower().Contains(searchValue.ToLower()))
                //{
                filteredSearchResults.Add(result);
                //}
            }
            //filteredSearchResults.Sort(); we don't need sorting
            return filteredSearchResults;
        }

        [WebMethod(EnableSession = true)]
        public List<string> GetAccessoryList_ByTradeName_newtubularAutoComp_Design(string searchValue, int limit)
        {
            List<string> searchResults = this.CommonControllerInstance.GetAccessoryList_ByTradeName_Design(searchValue);
            List<string> filteredSearchResults = new List<string>();
            foreach (string result in searchResults)
            {
                //if (result.ToLower().Contains(searchValue.ToLower()))
                //{
                filteredSearchResults.Add(result);
                //}
            }
            //filteredSearchResults.Sort(); we don't need sorting
            return filteredSearchResults;
        }

        [WebMethod(EnableSession = true)]
        public DataSet GetAccessoryList_Size_Rate_AutoComp(string searchValue, int ClientId)
        {
            return this.CommonControllerInstance.GetAccessory_Size_Rate(searchValue, ClientId);
        }

        [WebMethod(EnableSession = true)]
        public List<string> GetProcessList_ByName(string searchValue, int limit)
        {
            List<string> searchResults = this.CommonControllerInstance.GetProcessList_ByName(searchValue);
            List<string> filteredSearchResults = new List<string>();
            foreach (string result in searchResults)
            {
                //if (result.ToLower().Contains(searchValue.ToLower()))
                //{
                filteredSearchResults.Add(result);
                //}
            }
            //filteredSearchResults.Sort();
            return filteredSearchResults;
        }

        [WebMethod(EnableSession = true)]
        public string VAlidateSerialNumber(string SerialNumber)
        {
            return QualityControllerInstance.VAlidateSerialNumber(SerialNumber);
        }
        ////abhishek===================================================================================================================//
        //// fro Factory Representatives====================================================//
        [WebMethod(EnableSession = true)]
        public List<string> GetUserName_ByDptID_Factory(string q, int limit)
        {
            int Deptid = 0;//TODO Remove hard cord value

            List<string> searchResults = this.CommonControllerInstance.GetUserNameByDeptID(q, Deptid);
            List<string> filteredSearchResults = new List<string>();
            foreach (string result in searchResults)
            {
                //if (result.ToLower().Contains(q.ToLower()))
                //{
                filteredSearchResults.Add(result);
                // }
            }
            filteredSearchResults.Sort();
            return filteredSearchResults;
        }
        // fro QA Representatives====================================================//
        [WebMethod(EnableSession = true)]
        public List<string> GetUserName_ByDptID_QA(string q, int limit)
        {
            int Deptid = 9;//TODO Remove hard cord value

            List<string> searchResults = this.CommonControllerInstance.GetUserNameByDeptID(q, Deptid);
            List<string> filteredSearchResults = new List<string>();
            foreach (string result in searchResults)
            {
                //if (result.ToLower().Contains(q.ToLower()))
                //{
                filteredSearchResults.Add(result);
                //  }
            }
            filteredSearchResults.Sort();
            return filteredSearchResults;
        }
        // fro Merchandiser Representatives====================================================//
        [WebMethod(EnableSession = true)]
        public List<string> GetUserName_ByDptID_Merchandiser(string q, int limit)
        {
            int Deptid = 6;//TODO Remove hard cord value

            List<string> searchResults = this.CommonControllerInstance.GetUserNameByDeptID(q, Deptid);
            List<string> filteredSearchResults = new List<string>();
            foreach (string result in searchResults)
            {
                //if (result.ToLower().Contains(q.ToLower()))
                //{
                filteredSearchResults.Add(result);
                // }
            }
            filteredSearchResults.Sort();
            return filteredSearchResults;
        }
        // fro IE Representatives====================================================//
        [WebMethod(EnableSession = true)]
        public List<string> GetUserName_ByDptID_IE(string q, int limit)
        {
            int Deptid = 15;//TODO Remove hard cord value

            List<string> searchResults = this.CommonControllerInstance.GetUserNameByDeptID(q, Deptid);
            List<string> filteredSearchResults = new List<string>();
            foreach (string result in searchResults)
            {
                //if (result.ToLower().Contains(q.ToLower()))
                //{
                filteredSearchResults.Add(result);
                //}
            }
            filteredSearchResults.Sort();
            return filteredSearchResults;
        }
        // fro Sampling Representatives====================================================//
        [WebMethod(EnableSession = true)]
        public List<string> GetUserName_ByDptID_Sampling(string q, int limit)
        {
            int Deptid = 0;//TODO Remove hard cord value

            List<string> searchResults = this.CommonControllerInstance.GetUserNameByDeptID(q, Deptid);
            List<string> filteredSearchResults = new List<string>();
            foreach (string result in searchResults)
            {
                //if (result.ToLower().Contains(q.ToLower()))
                //{
                filteredSearchResults.Add(result);
                //}
            }
            filteredSearchResults.Sort();
            return filteredSearchResults;
        }
        // fro Fabric Representatives====================================================//
        [WebMethod(EnableSession = true)]
        public List<string> GetUserName_ByDptID_Fabric(string q, int limit)
        {
            int Deptid = 7;//TODO Remove hard cord value

            List<string> searchResults = this.CommonControllerInstance.GetUserNameByDeptID(q, Deptid);
            List<string> filteredSearchResults = new List<string>();
            foreach (string result in searchResults)
            {
                //if (result.ToLower().Contains(q.ToLower()))
                //{
                filteredSearchResults.Add(result);
                //}
            }
            filteredSearchResults.Sort();
            return filteredSearchResults;
        }
        // fro Accessory Representatives====================================================//
        [WebMethod(EnableSession = true)]
        public List<string> GetUserName_ByDptID_Accessory(string q, int limit)
        {
            int Deptid = 8;//TODO Remove hard cord value

            List<string> searchResults = this.CommonControllerInstance.GetUserNameByDeptID(q, Deptid);
            List<string> filteredSearchResults = new List<string>();
            foreach (string result in searchResults)
            {
                //if (result.ToLower().Contains(q.ToLower()))
                //{
                filteredSearchResults.Add(result);
                //}
            }
            filteredSearchResults.Sort();
            return filteredSearchResults;
        }
        // fro Out Representatives====================================================//
        [WebMethod(EnableSession = true)]
        public List<string> GetUserName_ByDptID_Out(string q, int limit)
        {
            int Deptid = 0;//TODO Remove hard cord value

            List<string> searchResults = this.CommonControllerInstance.GetUserNameByDeptID(q, Deptid);
            List<string> filteredSearchResults = new List<string>();
            foreach (string result in searchResults)
            {
                //if (result.ToLower().Contains(q.ToLower()))
                //{
                filteredSearchResults.Add(result);
                // }
            }
            filteredSearchResults.Sort();
            return filteredSearchResults;
        }
        [WebMethod(EnableSession = true)]
        public List<string> SuggestForAutoCompletesupplier(string searchValue, string searchContext, int limit)
        {
            List<string> searchResults = this.CommonControllerInstance.SuggestForAutoComplete_supplier(searchValue, searchContext);

            List<string> filteredSearchResults = new List<string>();

            // Looping through the datasource to select the items that match
            foreach (string result in searchResults)
            {
                if (result.ToLower().Contains(searchValue.ToLower()))
                {
                    filteredSearchResults.Add(result.ToUpper());
                }
            }

            // Sort the list
            filteredSearchResults.Sort();

            // Return the items that contained the text in alphabetical order
            return filteredSearchResults;
        }
        [WebMethod(EnableSession = true)]
        public List<string> SuggestForAutoCompleteUnitLine(string searchValue, int unitid, int LineNumber, string status)
        {
            List<string> searchResults = this.CommonControllerInstance.SuggestForAutoCompleteByunitidLine(searchValue, unitid, LineNumber, status);
            //List<string> searchResults = this.CommonControllerInstance.SuggestForAutoCompleteByunitidLine(searchValue, searchContext, UnitID);

            List<string> filteredSearchResults = new List<string>();
            foreach (string result in searchResults)
            {
                if (result.ToLower().Contains(searchValue.ToLower()))
                {
                    filteredSearchResults.Add(result.ToUpper());
                }
            }
            filteredSearchResults.Sort();
            return filteredSearchResults;

        }

        [WebMethod(EnableSession = true)]
        public int check_for_auto_complete(string searchValue, string searchContext)
        {
            return CommonControllerInstance.check_for_auto_complete(searchValue, searchContext);
        }
        [WebMethod(EnableSession = true)]
        public List<string> GetFabricList_ByTradeName_newtubularAutoComp(string searchValue, int limit, string Print_Details, int PrintCategory, string StyleId)
        {
            List<string> searchResults = this.CommonControllerInstance.GetFabricList_ByTradeName_New(searchValue, Print_Details, PrintCategory, StyleId);
            List<string> filteredSearchResults = new List<string>();
            foreach (string result in searchResults)
            {
                //if (result.ToLower().Contains(searchValue.ToLower()))
                //{
                filteredSearchResults.Add(result);
                // }
            }
            //filteredSearchResults.Sort(); we don't need sorting
            return filteredSearchResults;
        }
        [WebMethod(EnableSession = true)]
        public string[] GetStatusModeNameAndColor_New(int currentStatusId)
        {
            string[] statusModeAndColor = new string[2];
            statusModeAndColor[0] = Constants.GetStatusModeName(currentStatusId);
            statusModeAndColor[1] = Constants.GetStatusModeColor(currentStatusId);
            return statusModeAndColor;
        }
        //Added by abhishek on 28/3/2019
        [WebMethod(EnableSession = true)]
        public List<iKandi.Common.QCFormSupport> UpdateSupportIssue(string Flag, int OrderdetailID, string createdon, int QAtype)
        {
            return QualityControllerInstance.UpdateSupportIssue(Flag, OrderdetailID, createdon, QAtype);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateQCSheetStatus(string flag, int QCID)
        {
            return QualityControllerInstance.UpdateQCSheetStatus(flag, QCID);
        }
        [WebMethod(EnableSession = true)]
        public bool PendingOrderSummaryUpdate(string flag, string StagesCount, int OrderDetailID, int fabricMasterID, string ColorPrin, int Stagevalt, int FabricPending_Orders_Id, Boolean finlized)
        {
            return QualityControllerInstance.PendingOrderSummaryUpdate(flag, StagesCount, OrderDetailID, fabricMasterID, ColorPrin, Stagevalt, FabricPending_Orders_Id, finlized);
        }
        [WebMethod(EnableSession = true)]
        public bool updatePendingGreigeOrdersSupplier(string flag, int Fabric_MasterID, float QuotedLandedRate, int Supplier_master_ID, int SupplierGreigedOrder_Id, int fabQtyID, string fabricdetails,int DeliveryType)
        {
            return QualityControllerInstance.updatePendingGreigeOrdersSupplier(flag, Fabric_MasterID, QuotedLandedRate,Supplier_master_ID, SupplierGreigedOrder_Id, fabQtyID, fabricdetails,DeliveryType);
        }
        //Added by shubhendu for quotation update 25/05/2022
          [WebMethod(EnableSession = true)]
        public int UpdateCategorySupplierDays(int CategoryID, int grgDays, int grgrange, int dyedDays, int dyedrange, int ProcessDays, int Process_drange, int PrintDays, int PrintRange, int FinishDays, int FinishRange, int RFDstg1day, int RFDstg1Range, int RFDstg2Days, int RFDstg2range, int embrDays, int embrRange, int embllDays, int embllRange, int Userid)
        {
            return AdminControllerInstance.UpdateCategorySupplierDays(CategoryID, grgDays, grgrange, dyedDays, dyedrange, ProcessDays, Process_drange, PrintDays, PrintRange, FinishDays, FinishRange, RFDstg1day, RFDstg1Range, RFDstg2Days, RFDstg2range, embrDays, embrRange, embllDays, embllRange, Userid);
        }
        [WebMethod(EnableSession = true)]
        public bool updateGreigeValue(string Flag, string FlagOption, float GreigedShrinkage, int FabricQualityID, float Isresidualshrnkpplyongerige)
        {
            FabricController objFabricController = new FabricController();
            return objFabricController.updateGreigeValue(Flag, FlagOption, GreigedShrinkage, FabricQualityID, Isresidualshrnkpplyongerige);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateComment_ON_PO(string Po_Number, string CommentRemarks)
        {
            FabricController objFabricController = new FabricController();
            return objFabricController.UpdateComment_ON_PO(Po_Number, CommentRemarks);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateFabricPurchasedDetails(string Flag, string FlagOption, int FabricQualityID, int SuppliermasterID, string Po_Number, string Podate, int UserID, int ReceviedQty, float rate, string ENDETA, int garmentunits, int sendqty, string colorprintdetail, int IsAuthSign, int IsPartySign, int IsJuniorSign, float gerige, float residual, int Currentstage, int previousstage, bool isstylespecific, int styleid, int stage1, int stage2, int stage3, int stage4, int Converttounit, float conversionvalue, string History, float cutwastage, string eta,int RateType)
        {
            FabricController objFabricController = new FabricController();
            System.DateTime pddates = DateTime.ParseExact(Podate, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
            System.DateTime endpodate = DateTime.ParseExact(ENDETA, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
            // bool isdeletepoeta = fabobj.UpdateFabricPurchasedETA(Podate, "GETPOSUPPLIERETA_DELETE", DateTime.ParseExact(DateTime.Now.ToString(), "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture), ApplicationHelper.LoggedInUser.UserData.UserID, 1, 1, MasterPoIDETA, hdintialsuppliercode.Value, IsAuthIsg, IsPartySign);

            bool a = objFabricController.UpdateFabricPurchasedDetails(Flag, FlagOption, FabricQualityID, SuppliermasterID, Po_Number, pddates, UserID, ReceviedQty, rate, endpodate, garmentunits, sendqty, colorprintdetail, IsAuthSign, IsPartySign, IsJuniorSign, gerige, residual, Currentstage, previousstage, isstylespecific, styleid, stage1, stage2, stage3, stage4, Converttounit, conversionvalue, History, cutwastage, RateType);
            bool delete = fabobj.UpdateFabricPurchasedETA(Flag, "GETPOSUPPLIERETA_DELETE", pddates, ApplicationHelper.LoggedInUser.UserData.UserID, 0, 0, 0, Po_Number, IsAuthSign, IsPartySign, IsJuniorSign);

            string str = eta;
            string[] t = str.Split(new string[] { "##" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < t.Length; i++)
            {
                string[] t2 = t[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (t2[0] != null && t2[0].ToString() != "" && t2[1] != null && t2[1].ToString() != "")
                {
                    string f = t2[0].ToString();
                    string tq = t2[1].ToString();
                    string td = t2[2].ToString();

                    System.DateTime ETAdate_ = DateTime.ParseExact(td, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
                    bool ass = fabobj.UpdateFabricPurchasedETA(Flag, "GETPOSUPPLIERETA_INSERT", ETAdate_, ApplicationHelper.LoggedInUser.UserData.UserID, Convert.ToInt32(f.Replace(",", "")), Convert.ToInt32(tq.Replace(",", "")), 0, Po_Number, IsAuthSign, IsPartySign, IsJuniorSign);
                }
            }
            return true;
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateFabricPurchasedETA(string Flag, string FlagOption, string ETAdate, int UserID, int FromQty, int ToQty, int MasterPoID, string Po_Number, int IsAuthSign, int IsPartySign, int IsJuniorSign)
        {
            FabricController objFabricController = new FabricController();

            System.DateTime ETAdate_ = DateTime.ParseExact(ETAdate, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
            return objFabricController.UpdateFabricPurchasedETA(Flag, FlagOption, ETAdate_, UserID, FromQty, ToQty, MasterPoID, Po_Number, IsAuthSign, IsPartySign, IsJuniorSign);
        }
        [WebMethod(EnableSession = true)]
        public bool deletechallanbool(string Flag, int ChallanID, int ProcessID = 0, int SrNumber = 0, int Meter = 0, int CM = 0, string ChallanNumber = "")
        {
            FabricController objFabricController = new FabricController();
            return objFabricController.deletechallanbool(Flag, ChallanID, ProcessID, SrNumber, Meter, CM, ChallanNumber);
        }

        [WebMethod(EnableSession = true)]
        public bool updatePendingGreigeOrdersProxy(string flag, string FlagOption, int QtyToOrder, int PendingQtyToOrder, int FabricQualityID, string FabricDetails)
        {
            FabricController objFabricController = new FabricController();
            return objFabricController.updatePendingGreigeOrdersProxy(flag, FlagOption, QtyToOrder, PendingQtyToOrder, FabricQualityID, FabricDetails);
        }

        [WebMethod(EnableSession = true)]
        public bool updateDayedValue(string Flag, string FlagOption, float GreigedShrinkage, int FabricQualityID, float ResidualShrinkage)
        {
            FabricController objFabricController = new FabricController();
            return objFabricController.updateDayedValue(Flag, FlagOption, GreigedShrinkage, FabricQualityID, ResidualShrinkage);
        }
        [WebMethod(EnableSession = true)]
        public List<string> SuggestPartyBillNo(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.GETALLBILLNO.ToString(), limit);
        }
        [WebMethod(EnableSession = true)]
        public List<string> SuggestPartyBillNoAcc(string q, int limit)
        {
            return SuggestForAutoComplete(q, "ACCGETALLBILLNO", limit);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateQuatationEmbellishmentVA(string flag, int QualityID, int VAID, float QuotedLandedRate, int SuppliermasterID, string fabricdetails, int Styleid, int stage1, int stage2, int stage3, int stage4,int DeliveryType)
        {
            return QualityControllerInstance.UpdateQuatationEmbellishmentVA(flag, QualityID, VAID, QuotedLandedRate,  SuppliermasterID, fabricdetails, Styleid, stage1, stage2, stage3, stage4,DeliveryType);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateQuatationotherVA(string flag, int QualityID, int VAID, float QuotedLandedRate, int SuppliermasterID, string fabricdetails, int Styleid, int stage1, int stage2, int stage3, int stage4,int DeliveryType)
        {
            return QualityControllerInstance.UpdateQuatationotherVA(flag, QualityID, VAID, QuotedLandedRate, SuppliermasterID, fabricdetails, Styleid, stage1, stage2, stage3, stage4,DeliveryType);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateQuatationDayedVA(string flag, int QualityID, int VAID, float QuotedLandedRate, int SuppliermasterID, string fabricdetails, int Styleid,int DeliveryType)
        {
            return QualityControllerInstance.UpdateQuatationDayedVA(flag, QualityID, VAID, QuotedLandedRate, SuppliermasterID, fabricdetails, Styleid,DeliveryType);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateQuatationPrintVA(string flag, int QualityID, int VAID, float QuotedLandedRate, int SuppliermasterID, string fabricdetails, int Styleid, int stage1, int stage2, int stage3, int stage4,int DeliveryType)
        {
            return QualityControllerInstance.UpdateQuatationPrintVA(flag, QualityID, VAID, QuotedLandedRate, SuppliermasterID, fabricdetails, Styleid, stage1, stage2, stage3, stage4,DeliveryType);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateQuatationStyleBasedVA(string flag, int QualityID, int VAID, float QuotedLandedRate, int LeadTimes, int SuppliermasterID, string fabricdetails, int Styleid, int stage1, int stage2, int stage3, int stage4)
        {
            return QualityControllerInstance.UpdateQuatationStyleBasedVA(flag, QualityID, VAID, QuotedLandedRate, LeadTimes, SuppliermasterID, fabricdetails, Styleid, stage1, stage2, stage3, stage4);
        }
        //end abhishek 


    }
}


