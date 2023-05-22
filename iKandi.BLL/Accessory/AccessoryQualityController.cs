using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;
using System.Web.Security;
using iKandi.BLL.Security;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.BLL
{
    public class AccessoryQualityController : BaseController
    {

        #region

        public AccessoryQualityController()
        {
        }

        public AccessoryQualityController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion



        public AccessoryQuality save(AccessoryQuality objAccessoryQuality)
        {
            int id = -1;
            if (objAccessoryQuality.AccessoryQualityID == -1)
            {
                id = this.AccessoryQualityDataProviderInstance.InsertAccessoryQuality(objAccessoryQuality);
                objAccessoryQuality.AccessoryQualityID = id;
            }
            else
            {
                id = this.AccessoryQualityDataProviderInstance.UpdateAccessoryQuality(objAccessoryQuality);
            }

            return objAccessoryQuality;

        }

        public string UpdateAccQuality(Boolean isDefalt, int CatGroupID, int AccessoryMasterId, string AccQuality, int ClientId, int ParentDeptId, int DeptId, string DefaultTradeName, int Wastage, int Shrinkage, int GarmentUnit, int UserID)
        {
            return this.AccessoryQualityDataProviderInstance.UpdateAccQuality(isDefalt, CatGroupID, AccessoryMasterId, AccQuality, ClientId, ParentDeptId, DeptId, DefaultTradeName, Wastage, Shrinkage, GarmentUnit,UserID);
        }

        //public int InsertAccessoryQuality(AccessoryQuality AccessoryQualityInsert)
        //{

        //    return this.AccessoryQualityDataProviderInstance.InsertAccessoryQuality(AccessoryQualityInsert);

        //}

        public void InsertAccessoryQualityBuyer(AccessoryQualityBuyer buyer)
        {
            this.AccessoryQualityDataProviderInstance.InsertAccessoryQualityBuyer(buyer);
        }

        public void InsertAccessoryQualityPicture(AccessoryQualityPicture accessorypicture)
        {
            this.AccessoryQualityDataProviderInstance.InsertAccessoryQualityPicture(accessorypicture);
        }
        public List<AccessoryPending> UnitMastEdt(string ID)
        {
            return this.AccessoryQualityDataProviderInstance.UnitMastEdt(ID);
        }
        public DataSet GetUnit()
        {
            return this.AccessoryQualityDataProviderInstance.GetUnit();
        }
        //public void UpdateAccessoryQuality(AccessoryQuality objAccessoryQuality)
        //{
        //    this.AccessoryQualityDataProviderInstance.UpdateAccessoryQuality(objAccessoryQuality);
        //}

        public AccessoryQuality GetAccessoryQualityById(int ID)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessoryQualiyById(ID);
        }

        public List<AccessoryQuality> GetAccessoryQuality(int PageSize, int PageIndex, out int TotalPageCount, string SearchText, int GroupId, int SubGroupId, String PriceFrom, String PriceTo, int IsReg, int OrderBy1, int OrderBy2, int OrderBy3)
        {
            return this.AccessoryQualityDataProviderInstance.GetAllAccessoryQuality(PageSize, PageIndex, out TotalPageCount, SearchText, GroupId, SubGroupId, PriceFrom, PriceTo, IsReg, OrderBy1, OrderBy2, OrderBy3);
        }


        public bool DeleteAccessoryQualityBuyer(int AccessoryQualityID)
        {
            return this.AccessoryQualityDataProviderInstance.DeleteAccessoryQualityBuyer(AccessoryQualityID);
        }

        public string GetNewAccRef()
        {
            return this.AccessoryQualityDataProviderInstance.GetNewAccRefNo();
        }


        public bool DeleteAccessoryQualityPicture(int imageId)
        {
            return this.AccessoryQualityDataProviderInstance.DeleteAccessoryQualityPicture(imageId);
        }

        public int GetIdBySupplierRef(string SupplierRef)
        {
            return this.AccessoryQualityDataProviderInstance.GetIdBySupplierRef(SupplierRef);
        }

        public DataSet GetAllAccessoryPhotos(int AccessoryQualityId)
        {
            return this.AccessoryQualityDataProviderInstance.GetAllAccessoryPhotos(AccessoryQualityId);
        }

        public int GetAccIdByTradeName(string TradeName)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccIdByTradeName(TradeName);
        }

        public bool DeleteAccessoryQuality(int AccessoryQualityId)
        {
            return this.AccessoryQualityDataProviderInstance.DeleteAccessoryQuality(AccessoryQualityId);
        }

        #region New AQ 22-08-2016
        public DataSet GetAccessoryQualityMaster(string SearchItem, string GroupID, string SubGroupID, string TradeName, string UnitID, string Origin, string AccsessoryType)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessoryQualityMaster(SearchItem, GroupID, SubGroupID, TradeName, UnitID, Origin, AccsessoryType);
        }
        public DataTable AccessoryQualityMasterEdit(string ID)
        {
            return this.AccessoryQualityDataProviderInstance.AccessoryQualityMasterEdit(ID);
        }

        public int AccessoryQualityMaster_InsUpdt(AccessoryQuality AccessoryQualityData)
        {
            return this.AccessoryQualityDataProviderInstance.AccessoryQualityMaster_InsUpdt(AccessoryQualityData);
        }

        public List<AccessoryQuality> GetAccessoryQualityDetails(string AQMID, int AccessoryQualityID)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessoryQualityDetails(AQMID, AccessoryQualityID);
        }

        public int AccessoryQualityDetail_InsUpdt(AccessoryQuality AccessoryQualityData)
        {
            return this.AccessoryQualityDataProviderInstance.AccessoryQualityDetail_InsUpdt(AccessoryQualityData);
        }

        public int DeleteAccessoryQualityDetails(string AQMID, int AccessoryQualityID)
        {
            return this.AccessoryQualityDataProviderInstance.DeleteAccessoryQualityDetails(AQMID, AccessoryQualityID);
        }

        #endregion

        //added by abhishek on 27//12/2018
        public DataSet GetAccessoryOrderSizedeatils(string Flag, int orderid, string SizeOption, int OrderDetailID=0,string SizeNo="")
        {
          return this.AccessoryQualityDataProviderInstance.GetAccessoryOrderSizedeatils(Flag, orderid, SizeOption,  OrderDetailID, SizeNo);
        }
        public DataSet GetAccOrderShrinkage(int Flag, int orderid, int AccMasterId = 0)
        {
          return this.AccessoryQualityDataProviderInstance.GetAccOrderShrinkage(Flag, orderid, AccMasterId);
        }
        public int UpdateAccWorkingdetails(int Flag, int AccessoryworkingdetailId = 0, decimal numberacc = 0, int orderid = 0, int OrderDetailID = 0)
        {
          return this.AccessoryQualityDataProviderInstance.UpdateAccWorkingdetails(Flag, AccessoryworkingdetailId, numberacc, orderid, OrderDetailID);
        }
        public DataTable GetPrintNo(int Flag, int OrderDetailID, int AccessoryworkingdetailId)
        {
          return this.AccessoryQualityDataProviderInstance.GetPrintNo(Flag, OrderDetailID, AccessoryworkingdetailId);
        }
        public int Stock_Qty_Update_ToRaise_DebitNote(int SupplierPO_Id, int InspectionID, int flag, int StockQty)
        {
            return this.AccessoryQualityDataProviderInstance.Stock_Qty_Update_ToRaise_DebitNote(SupplierPO_Id, InspectionID, flag, StockQty);
        }
        // Added by shubhendu on 28/01/2021
        public int UpdateAccessoryGMSignature(int isGmChecked, decimal FailedRaisedDebit, decimal FailedStock, decimal FailedGoodStock, decimal InspectRaisedDebit, decimal InspectUsableStock, int srv_id)
        {
            return this.AccessoryQualityDataProviderInstance.UpdateAccessoryGMSignature( isGmChecked,  FailedRaisedDebit,  FailedStock,  FailedGoodStock,  InspectRaisedDebit,  InspectUsableStock, srv_id);
        }

        // Added by Shubhendu 28/08/2022
        public List<string> SuggestAccessoryByName(string q, string Flag, string TradeName)
        {
            return this.AccessoryQualityDataProviderInstance.SuggestAccessoryByName(q, Flag, TradeName);
        }
       //add code by bharat on 18-Aug-20
        public DataTable GetAllActive_ClientCode()
        {
            return this.AccessoryQualityDataProviderInstance.GetAllActive_ClientCode();
        }
        //End
        //add code by bharat on 18-Aug-20
        public DataTable Get_AccessoryProductionUnit()
        {
            return this.AccessoryQualityDataProviderInstance.Get_AccessoryProductionUnit();
        }
        //End
        //add code by bharat on 18-Aug-20

        //public string Save_UnRagisterAccessories(string Tradename, string AccessoriesSize, string AccessoriesRate)
        //{
        //    return this.AccessoryQualityDataProviderInstance.Save_UnRagisterAccessories(Tradename, AccessoriesSize, AccessoriesRate);
        //}

        public string Save_UnRagisterAccessories(string AccessoriesName, string AccessoryRateSize)
        {
            return this.AccessoryQualityDataProviderInstance.Save_UnRagisterAccessories(AccessoriesName, AccessoryRateSize);
        }

        public string Get_UnRagisterAccessories(string Tradename)
        {
            DataSet ds = new DataSet();
            ds = AccessoryQualityDataProviderInstance.Get_UnRagisterAccessories(Tradename);                
            return ds.GetXml().ToString();
        }
        //End
        //add code by bharat on 14-Dec-20
        public DataSet Get_AccessoryPrintOrderSummary(int orderid, int AccessoryworkingdetailId, int type)
        {
            return this.AccessoryQualityDataProviderInstance.Get_AccessoryPrintOrderSummary(orderid, AccessoryworkingdetailId, type);
        }
        public List<GroupUnit> Get_AccessoryDDL_ForOrder(int OrderId, int AccessoryWorkingDetailId)
        {
            return this.AccessoryQualityDataProviderInstance.Get_AccessoryDDL_ForOrder(OrderId, AccessoryWorkingDetailId);
        }

        public DataTable GetAccessoryQualityDetailsByTradeName_New(string TradeName, string CategoryID, string UnitId,int SearchDefault )
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessoryQualityDetailsByTradeName_New(TradeName, CategoryID, UnitId, SearchDefault);
        }

        public DataSet GetAccessoryOrderSummaryPrint(int Flag, int orderid)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessoryOrderSummaryPrint(Flag, orderid);
        }


    }
}
