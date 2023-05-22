using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using iKandi.BLL;
using System.Data.SqlClient;


using System.Collections.Generic;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class iKandiService
    {
        [WebMethod(EnableSession = true)]
        public iKandi.Common.CostingCollection GetCostingByStyleNumber(string styleNumber, byte isGetMultiple, int SingleVersion)
        {
            // System.Diagnostics.Debugger.Break();
            Session["CostingCollection"] = null;

            CostingCollection objCostingCollection = this.CostingControllerInstance.GetCostingByStyleNumber(styleNumber, isGetMultiple, SingleVersion);

            if (null != objCostingCollection && objCostingCollection.Count > 1)
            {
                Session["CostingCollection"] = objCostingCollection;
            }

            return objCostingCollection;
        }

        [WebMethod(EnableSession = true)]
        public iKandi.Common.CostingCollection GetCostingByStyleNumber_New(string styleNumber, byte isGetMultiple,int SingleVersion)
        {
            // System.Diagnostics.Debugger.Break();
            Session["CostingCollection"] = null;

            CostingCollection objCostingCollection = this.CostingControllerInstanceNew.GetCostingByStyleNumber_New(styleNumber, isGetMultiple, SingleVersion);

            if (null != objCostingCollection && objCostingCollection.Count > 1)
            {
                Session["CostingCollection"] = objCostingCollection;
            }

            return objCostingCollection;
        }


        [WebMethod(EnableSession = true)]
        public CostingCollection GetCostingCollectionForStyleNumberFromSession(string styleNumber)
        {
            if (null == Session["CostingCollection"])
                return GetCostingByStyleNumber(styleNumber, 1, 0);

            return (CostingCollection)Session["CostingCollection"];
        }

        [WebMethod(EnableSession = true)]
        public string GetCurrencySumbol(string enumCurrencyValue)
        {
           // string currencySymbol = "£";

          //  switch (enumCurrencyValue)
           // {
              //  case "1":
              //      currencySymbol = "$";
               //     break;
               // case "2":
               //     currencySymbol = "£";
               //     break;
               // case "3":
                //    currencySymbol = "Rs";
                //    break;
          //  }
            return this.CostingControllerInstance.GetCurrencySymbolBAL(enumCurrencyValue);
        
        }

        [WebMethod(EnableSession = true)]
        public bool DeleteStyleAndCostingSheet(int styleId, int costingId)
        {
            return this.CostingControllerInstance.DeleteStyleAndCostingSheet(styleId, costingId);
        }

        // Move this to Order Webservice
        [WebMethod(EnableSession = true)]
        public string GetOrdersByStyleVariations(string StyleNumber)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StyleNumber", StyleNumber);
            return PageHelper.GetControlHtml("~/UserControls/Lists/OrdersByStyleVariation.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetExistingOrdersByStyleVariations(int CostingID, string StyleNumber)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StyleNumber", StyleNumber);
            properties.Add("CostingID", CostingID);
            return PageHelper.GetControlHtml("~/UserControls/Lists/OrdersByStyleVariation.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public void UpdateOrderAgreedCosting(int CostingID, string OrderIDs)
        {           
            this.OrderControllerInstance.UpdateOrderAgreedCosting(OrderIDs, CostingID);
        }


        [WebMethod(EnableSession = true)]
        public string GetPriceForGarmentTypeSAM(int PutSAM, int ExpectedQty)
        {
            return this.CostingControllerInstance.GetPriceForGarmentTypeSAM(PutSAM, ExpectedQty);
        }

        [WebMethod(EnableSession = true)]
        public string[] GetCMT_Value(double SAM, int OB_WS, int Achivement, int ClientId, int DeptId, int StyleId, int Quantity)
        {
            return this.CostingControllerInstance.GetCMT_Value(SAM, OB_WS, Achivement, ClientId, DeptId, StyleId, Quantity);
        }

        //[WebMethod(EnableSession = true)]
        //public string [] GetClient_Costing_ByClient(int ClientId, int DeptId)
        //{
        //    this.CostingControllerInstance.GetClient_Costing_ByClient(ClientId, DeptId);
        //}

        [WebMethod(EnableSession = true)]
        public string UpdateClientCostingValues_ByClient(int ClientId, int DeptId, int HeaderNo, double Values)
        {
            return this.CostingControllerInstance.UpdateClientCostingValues_ByClient( ClientId,  DeptId,  HeaderNo,  Values);
        }
        [WebMethod(EnableSession = true)]
        public string UpdateClientCostingValues_ByClient_ApplicableCoffinBox(int ClientID, int DeptId, int HeaderNo, string ExpectedQuantity)
        {
            return this.CostingControllerInstance.UpdateClientCostingValues_ByClient_ApplicableCoffinBox(ClientID, DeptId, HeaderNo, ExpectedQuantity);
        }

        [WebMethod(EnableSession = true)]
        public string UpdateExpectedByClient(int ClientID, int DeptId, int HeaderNo, double ExpectedQuantity)
        {
            return this.CostingControllerInstance.UpdateExpectedByClient(ClientID, DeptId, HeaderNo, ExpectedQuantity);
        }

        [WebMethod(EnableSession = true)]
        public string UpdateClientCostingValues_ByClient_New(int ClientId, int DeptId, int HeaderNo, double Values)
        {
            return this.CostingControllerInstanceNew.UpdateClientCostingValues_ByClient_New(ClientId, DeptId, HeaderNo, Values);
        }
        //Add BY Prabhaker
        [WebMethod(EnableSession = true)]
        public string UpdateClientCostingMode_ByClient_New(int ClientId, int DeptId, string HeaderName, int AchiveValue)
        {
            return this.CostingControllerInstanceNew.UpdateClientCostingMode_ByClient_New(ClientId, DeptId, HeaderName, AchiveValue);
        }
        //End Of Code
        [WebMethod(EnableSession = true)]
        public string UpdateExpectedByClient_New(int ClientID, int DeptId, int HeaderNo, double ExpectedQuantity)
        {
            return this.CostingControllerInstanceNew.UpdateExpectedByClient_New(ClientID, DeptId, HeaderNo, ExpectedQuantity);
        }

        [WebMethod(EnableSession = true)]
        public List<Costing> GetClientCostingBy(int ClientId, int DeptId)
        {
            return this.CostingControllerInstance.GetClientCostingBy(ClientId, DeptId);
        }
        [WebMethod(EnableSession = true)]
        public List<Costing> GetWastage(int ExpectedQty)
        {
            return this.CostingControllerInstance.GetWastage(ExpectedQty);
        }


        //[WebMethod(EnableSession = true)]
        //public int UpdateClientCosting(string ClientName, string DeptName, double commission, int Conversion, double coffinbox, double Hangerloops, double lblTags, double OverHeadcost, double ProfitMargin, double Test, double Hangers, double DesignCommision, int Achievement, double ExpectedQuantity)
        //{
        //    return this.CostingControllerInstance.UpdateClientCosting(ClientName, DeptName, commission, Conversion, coffinbox, Hangerloops, lblTags, OverHeadcost, ProfitMargin, Test, Hangers, DesignCommision, Achievement, ExpectedQuantity);
        //}

         #region ExpectedQuantity on Costing Sheet
        //manisha 13th may 2011
        [WebMethod(EnableSession = true)]
        public string GetPriceForGarmentType(string GarmentType,int ExpectedQty,string DdlType)
        {
            return this.CostingControllerInstance.GetPriceForGarmentType(GarmentType, ExpectedQty, DdlType);
        }

        //manisha 25th may 2011
        [WebMethod(EnableSession = true)]
        public int GetCurrencyConversion(int currencyID, string StyleNumber)
        {
            return this.CostingControllerInstance.GetCurrencyConversion(currencyID, StyleNumber);
        }

        #endregion
        // end
        [WebMethod(EnableSession = true)]
        public List<Costing> GetExpWastageQty(int ClientId, int DeptId)
        {
            return this.CostingControllerInstance.GetExpWastageQty(ClientId, DeptId);
        }
        [WebMethod(EnableSession = true)]
        public List<Costing> GetStyleNumber_From_Order(string sn)
        {
            return this.CostingControllerInstance.GetStyleNumber_From_Order(sn);
        }
        [WebMethod(EnableSession = true)]
        public List<Costing> GetClientCostingBy_New(int ClientId, int DeptId, string StyleNumber, int ExpectedQty)
        {
            return this.CostingControllerInstanceNew.GetClientCostingBy_New(ClientId, DeptId, StyleNumber, ExpectedQty);
        }
        [WebMethod(EnableSession = true)]
        public string GetRegisterFebric_New(string TradeName)
        {
            return (this.CostingControllerInstanceNew.GetRegisterFabric_Details(TradeName)).Tables[0].Rows.Count > 0 ? (this.CostingControllerInstanceNew.GetRegisterFabric_Details(TradeName)).GetXml() : ""; 
        }
        [WebMethod(EnableSession=true)]
        public string ShowBiplHistoryPopup(string CostingId, string type)
        {
            return (this.CostingControllerInstanceNew.GetBiplHistory_Details(CostingId, type)).GetXml(); 
            
        }
        [WebMethod(EnableSession = true)]
        public string ShowIkandiHistoryPopup(string CostingId, string type)
        {
            return (this.CostingControllerInstanceNew.GetIkandiHistory_Details(CostingId, type)).GetXml();

        }
        [WebMethod(EnableSession = true)]
        public string GetCurrencySumbol_New(string enumCurrencyValue)
        {
            // string currencySymbol = "£";

            //  switch (enumCurrencyValue)
            // {
            //  case "1":
            //      currencySymbol = "$";
            //     break;
            // case "2":
            //     currencySymbol = "£";
            //     break;
            // case "3":
            //    currencySymbol = "Rs";
            //    break;
            //  }
            return this.CostingControllerInstanceNew.GetCurrencySymbolBAL_New(enumCurrencyValue);

        }
        [WebMethod(EnableSession = true)]
        public List<string> GetAccessoryList_newtubularAutoComp(string q, int limit, int StyleId, int ClientId, int ParentDeptId, int DeptId)
        {
            List<string> Results = new List<string>();
            List<string> Accessories = GetAccessoryList_ByTradeName_newtubularAutoComp(q, limit, StyleId, ClientId, ParentDeptId, DeptId);
            foreach (string Accessory in Accessories)
            {
                Results.Add(Accessory);
            }
            return Results;
        }
        [WebMethod(EnableSession = true)]
        public List<string> GetAccessoryList_newtubularAutoComp_Design(string q, int limit)
        {
            List<string> Results = new List<string>();
            List<string> Accessories = GetAccessoryList_ByTradeName_newtubularAutoComp_Design(q, limit);
            foreach (string Accessory in Accessories)
            {
                Results.Add(Accessory);
            }
            return Results;
        }

        [WebMethod(EnableSession = true)]
        public string GetSize_Rate(string search, int ClientId)
        {
            DataSet ds = GetAccessoryList_Size_Rate_AutoComp(search, ClientId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.GetXml();
            }
            else
            {
                return "";
            }
        }

        [WebMethod(EnableSession = true)]
        public List<Accessories> GetCostingUnitQtyBy_Client_Dept(int ClientId, int DeptId)
        {
            return this.CostingControllerInstanceNew.GetCostingUnitQtyBy_Client_Dept_New(ClientId, DeptId);
        }
        [WebMethod(EnableSession = true)]
        public Accessories GetAccessoryQualityDataByTradeName(string TradeName, string Suplier)
        {
            //System.Diagnostics.Debugger.Break();
            return this.CostingControllerInstanceNew.GetAccessoryQualityDataByTradeName_New(TradeName, Suplier);
        }
        [WebMethod(EnableSession = true)]
        public Processes GetProcessDataByName(string Name, string ExpectedQty)
        {
            return this.CostingControllerInstanceNew.GetProcessDataByProcessName_New(Name, ExpectedQty);
        }
        [WebMethod(EnableSession = true)]
        public List<Costing> GetCostingVariance(int id)
        {
            return this.CostingControllerInstanceNew.GetCostingVariance(id);
        }
        [WebMethod(EnableSession = true)]
        public string[] GetCMT_Value_New(double SAM, int OB_WS, int Achivement, int ClientId, int DeptId, int StyleId, int Quantity)
        {
            return this.CostingControllerInstanceNew.GetCMT_Value_New(SAM, OB_WS, Achivement, ClientId, DeptId, StyleId, Quantity);
        }
        [WebMethod(EnableSession = true)]
        public int GetCurrencyConversion_New(int currencyID)
        {
            return this.CostingControllerInstanceNew.GetCurrencyConversion_New(currencyID);
        }
        [WebMethod(EnableSession = true)]
        public bool DeleteStyleAndCostingSheet_New(int styleId, int costingId)
        {
            return this.CostingControllerInstanceNew.DeleteStyleAndCostingSheet_New(styleId, costingId);
        }
        

        [WebMethod(EnableSession = true)]
        public List<string> GetProcessList(string q, int limit)
        {
            List<string> Results = new List<string>();
            List<string> Processes = GetProcessList_ByName(q, limit);
            foreach (string Process in Processes)
            {
                Results.Add(Process);
            }
            return Results;
        }
        [WebMethod(EnableSession = true)]
        public List<Costing> GetIsCheckOrderConfirmed(string StyleNumber)
        {
            return this.CostingControllerInstanceNew.GetIsCheckOrderConfirmed(StyleNumber);
        }
        //add code by bhrarat on 1-27-2020 
         [WebMethod(EnableSession = true)]
        public string SaveLikeCountProduct(int ProdStyleid, int ProDCount)
        {
            return this.CostingControllerInstance.SaveLikeCountProduct(ProdStyleid, ProDCount);
        }
         //add code by bhrarat on 30-oct-2020 
         [WebMethod(EnableSession = true)]
         public string CheckCancelPO(int OrderDetailId)
         {
             return this.CostingControllerInstance.CheckCancelPO(OrderDetailId);
         }

         [WebMethod(EnableSession = true)]
         public string SaveLikeCountProductDetails(int ProdedatailStyleid, int ProDCountDetail)
         {
             return this.CostingControllerInstance.SaveLikeCountProductDetails(ProdedatailStyleid, ProDCountDetail);
         }

         //[WebMethod(EnableSession = true)]
         //public string GetLikeCountProductDetails(int GetdedatailStyleid, int GetDCountDetail)
         //{
         //    return this.CostingControllerInstance.SaveLikeCountProductDetails(GetdedatailStyleid, GetDCountDetail);
         //}
         [WebMethod(EnableSession = true)]
         public List<ValueAddition> GetValueAdditionDDL(int ValueAdditionId)
         {
             return this.CostingControllerInstanceNew.GetValueAdditionDDL(ValueAdditionId);
         }

        [WebMethod(EnableSession = true)]
         public ValueAddition Get_Wastage_Rate_For_Costing(int StyleId, int SequenceNo, int ValueAdditionId, int WastageId, int type)
         {
             return this.CostingControllerInstanceNew.Get_Wastage_Rate_For_Costing(StyleId, SequenceNo, ValueAdditionId, WastageId, type);
         }

        //added by raghvinder on 09-12-2020 start
        [WebMethod(EnableSession = true)]
        public List<OrderOldHistoryComments> Get_Costing_Old_History(int CostingId)
        {
            return this.CostingControllerInstanceNew.Get_Costing_Old_History(CostingId);
        }
        //added by raghvinder on 09-12-2020 end

        [WebMethod(EnableSession = true)]
        public List<Accessories> GetAccessoryBy_Client_Dept_Change(int ClientId, int DeptId, int CostingId)
        {
            return this.CostingControllerInstanceNew.GetAccessoryBy_Client_Dept_Change(ClientId, DeptId, CostingId);
        }
    }
}
