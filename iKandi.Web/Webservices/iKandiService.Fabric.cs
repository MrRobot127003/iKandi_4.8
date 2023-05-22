using System;
using System.Web;
using System.Web.Services;
using System.Collections.Generic;
using iKandi.Common;
using iKandi.Web.Components;
using iKandi.BLL;
using iKandi.BLL.Production;

using Pechkin;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.IO;

using System.Text;
using System.Text.RegularExpressions;

namespace iKandi.Web
{
    public partial class iKandiService
    {
        FabricController fabobjs = new FabricController();

        [WebMethod(EnableSession = true)]
        public List<string> SuggestFabricMill(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.FabricMill.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public void ExportToExcel(string str)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=PendingPayment.xls");
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestFabricType(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.FabricType.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestFabric(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.Fabric.ToString(), limit);
        }

        //[WebMethod(EnableSession = true)]
        //public List<SamplingFabric> GetAllSamplingFabric(string SearchText)
        //{
        //    System.Diagnostics.Debugger.Break();

        //    List<SamplingFabric> samplingFabrics = this.FabricSmplingControllerInstance.GetAllSamplingFabric(SearchText);

        //    SamplingFabric sf = new SamplingFabric();
        //    sf.PrintID = -1;
        //    sf.PrintTechnology = (PrintTechnology)(-1);
        //    sf.Origin = (Origin)(-1);
        //    sf.PrintType = (PrintType)(-1);
        //    sf.CostCurrency = Currency.INR;
        //    samplingFabrics.Add(sf);

        //    return samplingFabrics;
        //}

        [WebMethod(EnableSession = true)]
        public List<SamplingFabric> GetSamplingFabricByPrintNumber(String PrintNumber)
        {
            //System.Diagnostics.Debugger.Break();
            List<SamplingFabric> samplingFabrics = this.FabricSmplingControllerInstance.GetSamplingFabricByPrintNumber(PrintNumber);

            return samplingFabrics;
        }

        [WebMethod(EnableSession = true)]
        public List<SamplingFabric> GetSamplingFabricByPrintNumber_And_StyleId(String PrintNumber, string StyleId)
        {
            //System.Diagnostics.Debugger.Break();
            // List<SamplingFabric> samplingFabrics = this.FabricSmplingControllerInstance.GetSamplingFabricByPrintNumber_And_StyleId(PrintNumber, StyleId);
            List<SamplingFabric> samplingFabrics = this.FabricSmplingControllerInstance.GetSamplingFabricByPrintNumber(PrintNumber);

            return samplingFabrics;
        }

        [WebMethod(EnableSession = true)]
        public string GetPrintFabricHistoryView(string PrintNumber)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("PrintNumber", PrintNumber);

            return PageHelper.GetControlHtml("~/UserControls/Lists/PrintFabricHistory.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetPrintFabricHistoryStyleId(string PrintNumber, string parameter2)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("PrintNumber", PrintNumber);
            properties.Add("StyleId", parameter2);

            return PageHelper.GetControlHtml("~/UserControls/Lists/PrintFabricHistory.ascx", properties);
        }


        [WebMethod(EnableSession = true)]
        public string GetPrintFabricHistoryViewByStyleNumber(string StyleNumber)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StyleNumber", StyleNumber);

            return PageHelper.GetControlHtml("~/UserControls/Lists/PrintFabricHistory.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestAccessorySupplierName(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.AccessoryQualitySupplierName.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestAccessoryCategory(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.AccessoryQualityCategory.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestFabricQualitySupplierReference(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.FabricQualitySupplierReference.ToString(), limit);
        }
        #region Quantity Reallocation
        [WebMethod(EnableSession = true)]
        public List<string> SuggestFabricNameByName1(string q, string limit)
        {
            return this.FabricControllerInstance.GeFabricNameByName1(q);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestColorPrintName(string q, string limit, int Qualityid)
        {
            return this.FabricControllerInstance.SuggestColorPrintName(q, Qualityid);
        }
        #endregion
        [WebMethod(EnableSession = true)]
        public List<string> SuggestFabricQualityTradeName(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.FabricQualityTradeName.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public int GetIdBySupplierReferenceNo(string SupplierReferenceNo)
        {
            int Id = this.FabricQualityControllerInstance.GetIdBySupplierReferenceNo(SupplierReferenceNo);
            return Id;

        }

        [WebMethod(EnableSession = true)]
        public int GetIdBySupplierRef(string SupplierRef)
        {
            int Id = this.AccessoryQualityControllerInstance.GetIdBySupplierRef(SupplierRef);
            return Id;

        }

        [WebMethod(EnableSession = true)]
        public string GetFabricSamplingView(string SearchText)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("SearchText", SearchText);
            return PageHelper.GetControlHtml("~/UserControls/Lists/FabricSamplingList1.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestFabricSamplingFabric(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.FabricSamplingFabric.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<String> SuggestFabricQualitySupplierName(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.FabricQualitySupplierName.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public int GetIdByTradeName(string TradeName)
        {
            //System.Diagnostics.Debugger.Break();
            return this.FabricQualityControllerInstance.GetIdByTradeName(TradeName);
        }

        [WebMethod(EnableSession = true)]
        public bool ImageDelete(int ImageId)
        {
            //System.Diagnostics.Debugger.Break();
            return this.FabricQualityControllerInstance.DeleteFabricQualityPicture(ImageId);
        }

        [WebMethod(EnableSession = true)]
        public int UpdateFourPointPattaHole(int patta, int hole)
        {
            //System.Diagnostics.Debugger.Break();
            return this.FourPointControllerInstance.UpdateFourPointCheckHolePatta(patta, hole);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestRegisteredTradeNamesForOrder(string q, int limit)
        {
            List<string> Results = new List<string>();
            List<string> fabrics = SuggestForRegisteredTradeNamesAutoCompleteForOrder(q, limit);

            foreach (string fabric in fabrics)
            {
                Results.Add(fabric);
            }
            return Results;
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestRegisteredTradeNames(string q, int limit)
        {
            List<string> Results = new List<string>();
            List<string> fabrics = SuggestForRegisteredTradeNamesAutoComplete(q, limit);

            foreach (string fabric in fabrics)
            {
                Results.Add(fabric);
            }
            return Results;
        }

        [WebMethod(EnableSession = true)]
        public FabricQuality GetFabricQualityDetailsByTradeName(string TradeName, string Details, int Mode)
        {
            //System.Diagnostics.Debugger.Break();

            return this.FabricQualityControllerInstance.GetFabricQualityDetailsByTradeName(TradeName, Details, Mode);

        }


        [WebMethod(EnableSession = true)]
        public FabricQuality GetFabricQualityDetailsByTradeNameForPrint(string PrintNumber)
        {
            //System.Diagnostics.Debugger.Break();

            return this.FabricQualityControllerInstance.GetFabricQualityDetailsByTradeNameForPrint(PrintNumber);

        }
        [WebMethod(EnableSession = true)]
        public FabricQuality GetFabricQualityDetailsByTradeNameForPrint_New(string PrintNumber)
        {
            //System.Diagnostics.Debugger.Break();

            return this.FabricQualityControllerInstance.GetFabricQualityDetailsByTradeNameForPrint_New(PrintNumber);

        }

        [WebMethod(EnableSession = true)]
        public List<string> Get_Vender_NameForReallocation(string VenderName)
        {
            //System.Diagnostics.Debugger.Break();

            return this.FabricQualityControllerInstance.Get_Vender_NameForReallocation(VenderName);

        }

        [WebMethod(EnableSession = true)]
        public List<string> Get_Finsh_Value(string ID, string Name)
        {
            return this.FabricQualityControllerInstance.Get_Finsh_Value(ID, Name);
        }

        [WebMethod(EnableSession = true)]
        public List<string> GetFQHeaderforSupplier(string ID)
        {
            return this.FabricQualityControllerInstance.GetFQHeaderforSupplier(ID);
        }

        [WebMethod(EnableSession = true)]
        public List<string> Get_Greige_Value(string ID)
        {
            return this.FabricQualityControllerInstance.Get_Griege_Value(ID);
        }

        [WebMethod(EnableSession = true)]
        public FabricQuality GetFabricQualityDetailsByTradeNameForPrintOnLoad(string PrintNumber)
        {
            //System.Diagnostics.Debugger.Break();

            // return this.FabricQualityControllerInstance.GetFabricQualityDetailsByTradeNameYatenOnLoad(PrintNumber);
            return this.FabricQualityControllerInstance.GetFabricQualityDetailsByTradeNameForPrintOnLoad(PrintNumber);
        }

        [WebMethod(EnableSession = true)]
        public string ShowPopUpAQLWise(double AQLType)
        {
            string dt = this.FabricQualityControllerInstance.GetAllAqlExistingStanderdBAL(AQLType);
            return dt;
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestRegisteredFabricTradeNames(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.RegisteredTradeName.ToString(), limit);
        }
        //add code b6y bharat
        [WebMethod(EnableSession = true)]
        public List<string> SuggestMarketingTag(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.MarketingTags.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public string GetFabricQualityView(int FabricQualityID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("FabricQualityID", FabricQualityID);

            return PageHelper.GetControlHtml("~/UserControls/Lists/FabricQualityPopup.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public List<SupplierContact> GetContactsBySupplierId(int supplierId)
        {
            return this.SupplierControllerInstance.GetContactsBySupplierId(supplierId);
        }

        [WebMethod(EnableSession = true)]
        public string GetGroupName(string gName)
        {
            return this.SupplierControllerInstance.GetGroupName(gName);
        }

        [WebMethod(EnableSession = true)]
        public int GetDuplicateSupplier(string gName, string sName, int sid)
        {
            return this.SupplierControllerInstance.GetDuplicateSupplier(gName, sName, sid);
        }

        [WebMethod(EnableSession = true)]
        public string GetDuplicateGroupInit(string gName, int sid)
        {
            return this.SupplierControllerInstance.GetDuplicateGroupInit(gName, sid);
        }

        [WebMethod(EnableSession = true)]
        public int GetDuplicateSupplierInit(string sName, int sid)
        {
            return this.SupplierControllerInstance.GetDuplicateSupplierInit(sName, sid);
        }

        [WebMethod(EnableSession = true)]
        public int GetDuplicateGroupName(string gName, int sid)
        {
            return this.SupplierControllerInstance.GetDuplicateGroupName(gName, sid);

        }

        [WebMethod(EnableSession = true)]
        public FabricGroupAdmin GetFabricBIPLInfo(string StyleID)
        {
            return this.GreigeControllerInstance.getFabricBIPLinfoBAL(StyleID);
        }

        //[WebMethod(EnableSession = true)]
        //public List<StyleFabric> GetStyleByStyleId_Multiple(string StyleID)
        //{
        //    return this.StyleControllerInstance.GetStyleByStyleId_Multiple(StyleID);
        //}

        //[WebMethod(EnableSession = true)]
        //public List<FabricGroupAdmin> GetStyleByStyleId_Multiple(string StyleID)
        //{
        //    return this.StyleControllerInstance.GetStyleByStyleId_Multiple(StyleID);
        //}

        [WebMethod(EnableSession = true)]
        public string GetGateEntryNo(string entryType, string gateNo)
        {
            return this.AdminControllerInstance.GetGateEntryNo(entryType, gateNo);
        }


        //below created by Girish
        [WebMethod(EnableSession = true)]
        public List<string> GetAutoPopulateResult(string q, string limit, string timestamp, int DropDownType, int POStatus, string Type)
        {
            List<string> str = new List<string>();

            str = this.FabricControllerInstance.GetSuggestions(q, limit, timestamp, DropDownType, POStatus, Type);

            return str;
        }


        [WebMethod(EnableSession = true)]
        public List<string> SuggestFabricNameByName(string q, string limit)
        {
            return this.FabricControllerInstance.GeFabricNameByName(q);
        }

        //26042023-RajeevS
        [WebMethod(EnableSession = true)]
        public List<String> SuggestFabricSupplier(string q, int limit)
        {
            return FabricControllerInstance.SuggestFabricSupplier(q);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestPONumber(string q, string limit)
        {
            return this.FabricControllerInstance.GetPONumber(q);
        }
        [WebMethod(EnableSession = true)]
        public List<string> SuggestColorPrint(string q, string limit)
        {
            return this.FabricControllerInstance.GetColorPrint(q);
        }
        //27042023
        [WebMethod(EnableSession = true)]
        public List<string> SuggestAccQuality(string q, int limit)
        {
            return SuggestForAccAutoComplete(q, AutoComplete.AccQuality.ToString(), limit);
        }
        [WebMethod(EnableSession = true)]
        public List<string> SuggestAccColorPrint(string q, int limit)
        {
            return SuggestForAccAutoComplete(q, AutoComplete.AccColorPrint.ToString(), limit);
        }
        [WebMethod(EnableSession = true)]
        public List<string> SuggestAccPONumber(string q, int limit)
        {
            return SuggestForAccAutoComplete(q, AutoComplete.AccPONumber.ToString(), limit);
        }
        [WebMethod(EnableSession = true)]
        public List<string> SuggestAccSupplier(string q, int limit)
        {
            return SuggestForAccAutoComplete(q, AutoComplete.AccSupplier.ToString(), limit);
        }
        //27042023
        //26042023-RajeevS       
        [WebMethod(EnableSession = true)]
        public string GetSupplierAddressByNameWithGroup(string type)
        {
            return this.SupplierControllerInstance.GetSupplierAddressByNameWithGroup(type);
        }

        [WebMethod(EnableSession = true)]
        public int GetStockUnitByTradeName(string tradeName)
        {
            return this.FabricControllerInstance.GetStockUnitByTradeName(tradeName);
        }
        [WebMethod(EnableSession = true)]
        public int GetSupplierIdByNameWithGroup(string type)
        {
            return this.SupplierControllerInstance.GetSupplierIdByNameWithGroup(type);
        }


        // Add By Ravi kumar on 11-12-2014
        [WebMethod(EnableSession = true)]
        public string[] GetCostingAvg(int OrderId, int SeqNo)
        {
            return this.FabricWorkingControllerInstance.GetCostingAvg(OrderId, SeqNo);
        }

        // End By Ravi kumar on 11-12-2014

        // Add By Ravi on 21/9/2015 for Slot entry
        [WebMethod(EnableSession = true)]
        public int SaveSlotWiseDistributionLoss(int SlotWiseFactoryId, int UnitId, int DeprtmentId, int SlotId, int LossDepartmentValue, string SlotDate)
        {
            ProductionController objProductionController = new ProductionController();
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int Id = objProductionController.SaveSlotWiseDistributionLoss(SlotWiseFactoryId, UnitId, DeprtmentId, SlotId, LossDepartmentValue, UserId, SlotDate);
            return Id;

        }

        [WebMethod(EnableSession = true)]
        public int SaveSlot_LinePlanning_FactoryIE(int LinePlanningId, int UnitId, int OrderID, int OrderDetailId, int Lineno, int SlotId, string SlotDate, string SlotComment)
        {
            ProductionController objProductionController = new ProductionController();
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int Id = objProductionController.SaveSlot_LinePlanning_FactoryIE(LinePlanningId, UnitId, OrderID, OrderDetailId, Lineno, SlotId, SlotDate, SlotComment, UserId);
            return Id;

        }

        // Add by Ravi kumar on 18/2/2016
        [WebMethod(EnableSession = true)]
        public int SaveSlotWiseFactoryId_Ref(string SlotWiseFactoryIdAll, int UnitId, int SlotId, string SlotDate)
        {
            ProductionController objProductionController = new ProductionController();
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int Id = objProductionController.SaveSlotWiseFactoryId_Ref(SlotWiseFactoryIdAll, UnitId, SlotId, UserId, SlotDate);
            return Id;

        }

        // Add By Gajendra on 12-08-2016
        [WebMethod(EnableSession = true)]
        public string GetSupplier_SupplyType(string SupplierID)
        {
            return this.FabricQualityControllerInstance.GetSupplier_SupplyType(SupplierID);
        }
        //Gajendra Costing
        [WebMethod(EnableSession = true)]
        public FabricQuality GetFabricQualityDetailsByTradeName_New(string TradeName, string Details, int Mode, int FabricType, string Suplier)
        {
            //System.Diagnostics.Debugger.Break();GetFabricQualityDetailsByTradeName

            return this.FabricQualityControllerInstance.GetFabricQualityDetailsByTradeName_New(TradeName, Details, Mode, FabricType, Suplier);

        }
        [WebMethod(EnableSession = true)]
        public FabricQuality GetFabricQualityDetailsByTradeNameForPrintOnLoad_New(string PrintNumber)
        {
            return this.FabricQualityControllerInstance.GetFabricQualityDetailsByTradeNameForPrintOnLoad_New(PrintNumber);
        }

        [WebMethod(EnableSession = true)]
        public List<string> GetAdminHistory(int typeflag, string FieldName)
        {
            DateTime FromDate = DateTime.MinValue;
            DateTime ToDate = DateTime.MinValue;
            return this.AdminControllerInstance.GetAdminHistory(typeflag, FieldName, FromDate, ToDate);
        }
        [WebMethod(EnableSession = true)]
        public int UpdateFabricWastage(int CuttingRequest_IssueSheet_Id, decimal wastage, string flag, int OrderDetailID, int FabQtyID)
        {
            return this.fabobjs.UpdateFabricWastage(CuttingRequest_IssueSheet_Id, wastage, flag, OrderDetailID, FabQtyID);
        }
        [WebMethod(EnableSession = true)]
        public int UpdateFabricRaise(int IsCheck, string flag, int OrderDetailID, int FabQtyID, string FabricDetails, int Unitid)
        {
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            return this.fabobjs.UpdateFabricRaise(IsCheck, flag, OrderDetailID, FabQtyID, FabricDetails, Unitid, UserId);
        }
        [WebMethod(EnableSession = true)]
        public List<iKandi.Common.FabricGroupAdmin.FabricDetailsHistory> GetFabricHistory(string Flag, int OrderDetailID, int FabQtyID, string FabricDetails)
        {
            return this.fabobjs.GetFabricHistory(Flag, OrderDetailID, FabQtyID, FabricDetails);
        }

        [WebMethod(EnableSession = true)]
        public List<iKandi.Common.FabricGroupAdmin.FabricDetailsHistory> ListChallan(string Flag, int OrderDetailID, int FabQtyID, string FabricDetails)
        {
            return this.fabobjs.ListChallan(Flag, OrderDetailID, FabQtyID, FabricDetails);
        }


        [WebMethod(EnableSession = true)]
        public int UpdateStockQty(string flag, int FabQtyID, string FabricDetails, int StockQty, int orderdetailid, int debitqty, string particular, int ResiShrinkQty,int ExtraWastageQty)
        {
            return this.fabobjs.UpdateStockQty(flag, FabQtyID, FabricDetails, StockQty, orderdetailid, debitqty, particular, ResiShrinkQty, ExtraWastageQty);
        }

        //added by raghvinder on 10-11-2020 start
        [WebMethod(EnableSession = true)]
        public int FabricApproved_History(string Type, int OrderID, int CheckValue, int CreatedBy)
        {
            return this.fabobjs.FabricApproved_History(Type, OrderID, CheckValue, CreatedBy);
        }

        //added by raghvinder on 10-11-2020 end

        #region Mail Function by sanjeev

        [WebMethod(EnableSession = true)]
        public void SendFabricPoMail(int SupplierPO_Id)
        {
            FabricController fabobj = new FabricController();
            DataTable Dt = fabobj.GetRaisedPOWorkingDetails("GETPODETAIL", "", SupplierPO_Id).Tables[0];
            if (Dt.Rows.Count > 0)
            {
                string PO_Number = Dt.Rows[0]["PO_Number"].ToString();
                string PoStatus = Dt.Rows[0]["PoStatus"].ToString();

                int SupplierId = Convert.ToInt32(Dt.Rows[0]["SupplierID"]); // added by Girish On 2023-03-24 as passing this Valud in randorFabricHtmlAndSendMail as function GetSuppliarDetails() expects SupplierId not SupplierPOID

                string QueryString = @"Potype=RERAISE&Fabtype=" + Dt.Rows[0]["Fabtype"].ToString() +
                                      "&currentstage=" + Dt.Rows[0]["CurrentStage"].ToString() +
                                      "&previousstage=" + Dt.Rows[0]["PreviousStage"].ToString() +
                                      "&IsStyleSpecific=" + Dt.Rows[0]["IsStyleSpecific"].ToString() +
                                      "&FabricQualityID=" + Dt.Rows[0]["Fabric_QualityID"].ToString() +
                                      "&colorprintdetail=" + Dt.Rows[0]["PrintName"].ToString() +
                                      "&Stage1=" + Dt.Rows[0]["Stage1"].ToString() +
                                      "&Stage2=" + Dt.Rows[0]["Stage2"].ToString() +
                                      "&Stage3=" + Dt.Rows[0]["Stage3"].ToString() +
                                      "&Stage4=" + Dt.Rows[0]["Stage4"].ToString() +
                                      "&SupplierMasterID=" + Dt.Rows[0]["SupplierID"].ToString() +
                                      "&MasterPO_Id=" + Dt.Rows[0]["MasterPO_Id"].ToString() +
                                      "&FabricQuality=" + Dt.Rows[0]["FabricQuality"].ToString() +
                                      "&PoNumberPrint=" + Dt.Rows[0]["PO_Number"].ToString();


                //randorFabricHtmlAndSendMail(SupplierPO_Id, PO_Number, QueryString, PoStatus);
                randorFabricHtmlAndSendMail(SupplierId, PO_Number, QueryString, PoStatus); //changed SupplierPO_Id to SupplierId

            }

        }

        public void randorFabricHtmlAndSendMail(int SupplierPO_Id, string PO_Number, string QueryString, string PoStatus)
        {
            try
            {

                AdminController objadmin = new AdminController();

                string strHTML = "";
                string ss = "http://" + HttpContext.Current.Request.Url.Authority + "/../../FabricPurChasedFormPrint.aspx?" + QueryString;
                Uri requestUri = null;
                Uri.TryCreate((ss), UriKind.Absolute, out requestUri);
                NetworkCredential nc = new NetworkCredential(ApplicationHelper.LoggedInUser.UserData.Username, ApplicationHelper.LoggedInUser.UserData.Password);
                CredentialCache cache = new CredentialCache();
                cache.Add(requestUri, "Basic", nc);
                cache.Add(new Uri(ss), "NTLM", new NetworkCredential(ApplicationHelper.LoggedInUser.UserData.Username, ApplicationHelper.LoggedInUser.UserData.Password));

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUri);
                request.Credentials = cache;

                request.Method = WebRequestMethods.Http.Get;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader respStream = new StreamReader(response.GetResponseStream());
                strHTML = respStream.ReadToEnd();

                string filename = "POFabric_view" + PO_Number + ".HTML";
                string strFileNameashtml = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "" + filename);

                if ((File.Exists(strFileNameashtml))) { File.Delete(strFileNameashtml); }
                using (FileStream fs = File.Create(strFileNameashtml))
                {
                    Byte[] title = new UTF8Encoding(true).GetBytes(strHTML);
                    fs.Write(title, 0, title.Length);
                }
                if ("1" == "1")
                {
                    genertaeFabricPdf(strHTML, "ss", PO_Number);
                    DataTable dtgrid = new DataTable();
                    dtgrid = objadmin.GetSuppliarDetails(Convert.ToInt32(SupplierPO_Id)).Tables[0];
                    if (dtgrid.Rows.Count > 0)
                    {
                        DataRow dr = dtgrid.Select("IsUserlogin1 = " + "True")[0];
                        string SupplierMailID = dr["Email"].ToString();
                        try
                        {
                            List<Attachment> atts = new List<Attachment>();
                            String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                            List<String> to = new List<String>();
                            NotificationController objcontroller = new NotificationController();
                            to.Add(SupplierMailID);
                            //to.Add("bipl_itsupport@boutique.in");
                            string name = "POFabric_" + PO_Number + ".pdf";
                            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + name);
                            if (File.Exists(Constants.FITS_FOLDER_PATH + name))
                            {
                                string FitsPath = Path.Combine(Constants.FITS_FOLDER_PATH, name);
                                atts.Add(new Attachment(FitsPath));
                            }
                            this.SendFabricEmail(fromName, to, null, null, "Fabric PO (" + PO_Number + ")", name, atts, false, false, QueryString, PO_Number, PoStatus);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  randorHtml function  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }
        public Boolean SendFabricEmail(String FromEmail, List<String> To, List<String> CC, List<String> BCC, String Subject, String Content, List<Attachment> Attachments, Boolean hasAppendAttachment, Boolean isAsync, string QueryString, string PO_Number, string PoStatus)
        {
            string hdnStageName = "";
            var uri = new Uri("http://" + HttpContext.Current.Request.Url.Authority + "/../../FabricPurChasedFormPrint.aspx?" + QueryString);
            var query = HttpUtility.ParseQueryString(uri.Query);
            var FabricQuality = query.Get("FabricQuality");
            hdnStageName = query.Get("FabType").ToString();

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = Subject;
            if (PoStatus == "1")
            {
                mailMessage.Body = @"<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a <span style='color:gray'>Purchase Order</span><span style='color:#2f5597'> " + PO_Number + "</span> is Canceled for <span style='color:gray'>" + "Fabric Quality - </span><span style='color:#2f5597'>" + FabricQuality + "</span><span style='color:gray'> for stage </span> <span style='color:#2f5597'> " + hdnStageName + "</span>. Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> Disclaimer: This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
            }
            else
            {
                mailMessage.Body = @"<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a <span style='color:gray'>Purchase Order</span><span style='color:#2f5597'> " + PO_Number + "</span> is raised  for <span style='color:gray'>" + "Fabric Quality - </span><span style='color:#2f5597'>" + FabricQuality + "</span><span style='color:gray'> for stage </span> <span style='color:#2f5597'> " + hdnStageName + "</span>. Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> Disclaimer: This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
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
                    }
                    i++;
                }
            }
            else
            {
                mailMessage.Body = mailMessage.Body;
            }

            Boolean isDebug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["isDebug"]);

            if (isDebug)
            {
                // TODO
                mailMessage.To.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.Bcc.Add(Constants.WEBMASTER_EMAIL);
                mailMessage.CC.Add("sanjeev.v@boutique.in");
            }
            else
            {
                foreach (String to in To) { mailMessage.To.Add(to); }

                if (CC != null) { foreach (String to in CC) { mailMessage.CC.Add(to); } }

                if (BCC != null) { foreach (String to in BCC) { mailMessage.Bcc.Add(to); } }

                mailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.CC.Add("Bipl_fabric@boutique.in");
            }

            SmtpClient smtpClient = new SmtpClient(Constants.SMTP_HOST, Constants.SMTP_PORT);

            if (!hasAppendAttachment && Attachments != null) { foreach (Attachment att in Attachments) { mailMessage.Attachments.Add(att); } }

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
                System.Diagnostics.Trace.WriteLine("Email Having Subject of --" + Subject.ToString() + " is send successfully on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                return true;
            }
            catch (Exception ex)
            {
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
        public void genertaeFabricPdf(string HTMLCode, string PolicyFile, string PO_Number)
        {
            string strFileName = "";
            HTMLCode = getFabricImage(HTMLCode);
            getvartypeFabricHTML(HTMLCode, strFileName, PO_Number);
        }
        public void getvartypeFabricHTML(string HTMLCode, string PolicyFile, string PO_Number)
        {
            try
            {
                string filename = "POFabric_" + PO_Number + ".pdf";
                string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "" + filename);
                using (var pechkin = Factory.Create(new GlobalConfig()))
                {
                    var pdf = pechkin.Convert(new ObjectConfig()
                                            .SetLoadImages(true).SetZoomFactor(1.5)
                                            .SetPrintBackground(true)
                                            .SetScreenMediaType(true)
                                            .SetCreateExternalLinks(true), (HTMLCode.Replace("flow-root;", "none;")));

                    using (FileStream file = System.IO.File.Create(strFileName))
                    {
                        file.Write(pdf, 0, pdf.Length);
                    }
                }

            }
            catch { }
        }
        public string getFabricImage(string input)
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

        #endregion
        [WebMethod(EnableSession = true)]
        public string[] GetReturnedChallanQty(string Flag, string ChallanNumber)
        {
            return this.fabobjs.GetReturnedChallanQty(Flag, ChallanNumber);
        }

        [WebMethod(EnableSession = true)]
        public string CheckIfChallanNumberExist(string ChallanNumber, int ReturnQty)
        {
            return this.fabobjs.CheckIfChallanNumberExist(ChallanNumber, ReturnQty);
        }


    }

}
