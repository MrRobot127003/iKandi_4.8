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
using iKandi.Common.Entities;

namespace iKandi.BLL
{
    public class FabricQualityController : BaseController
    {
        #region

        public FabricQualityController()
        {
        }

        public FabricQualityController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion


        public FabricQuality Save(FabricQuality FabricQualityData, string UserName)
        {
            int id = -1;
            if (FabricQualityData.FabricQualityID == -1)
            {
                id = this.FabricQualityDataProviderInstance.InsertFabricQuality(FabricQualityData);
                FabricQualityData.FabricQualityID = id;
            }
            else
            {
                id = this.FabricQualityDataProviderInstance.UpdateFabricQuality(FabricQualityData, UserName);
            }

            return FabricQualityData;
        }




        //public int InsertFabricQuality(FabricQuality fabricquality)
        //{
        //    return this.FabricQualityDataProviderInstance.InsertFabricQuality(fabricquality);

        //}

        //public void UpdateFabricQuality(FabricQuality FabricQualityUpdate)
        //{
        //    this.FabricQualityDataProviderInstance.UpdateFabricQuality(FabricQualityUpdate);

        //}

        public void InsertFabricQualityBuyer(FabricQualityBuyer buyer)
        {
            this.FabricQualityDataProviderInstance.InsertFabricQualityBuyer(buyer);

        }

        public FabricQuality GetFabricQualityByID(int ID)
        {
            return this.FabricQualityDataProviderInstance.GetFabricQualityByID(ID);
        }

        public List<FabricQuality> GetFabricQuality(int PageSize, int PageIndex, out int TotalPageCount, string SearchText, int GroupId, int SubGroupId, String GsmFrom, String GsmTo, String WidthFrom, String WidthTo, String PriceFrom, String PriceTo, int IsReg, int OrderBy1, int OrderBy2, int OrderBy3, int OrderBy4)
        {
            return this.FabricQualityDataProviderInstance.GetAllFabricQuality(PageSize, PageIndex, out TotalPageCount, SearchText, GroupId, SubGroupId, GsmFrom, GsmTo, WidthFrom, WidthTo, PriceFrom, PriceTo, IsReg, OrderBy1, OrderBy2, OrderBy3, OrderBy4);

        }


        public bool DeleteFabricQualityBuyer(int fabricqualityid)
        {

            return this.FabricQualityDataProviderInstance.DeleteFabricQualityBuyer(fabricqualityid);


        }

        public string GetNewCountConstruction()
        {
            return this.FabricQualityDataProviderInstance.GetNewCountConstruction();
        }

        public int GetIdBySupplierReferenceNo(string SupplierReference)
        {
            return this.FabricQualityDataProviderInstance.GetIdBySupplierReferenceNo(SupplierReference);
        }


        public void InsertFabricQualityPicture(FabricQualityPicture picture)
        {
            this.FabricQualityDataProviderInstance.InsertFabricQualityPicture(picture);
        }

        public bool DeleteFabricQualityPicture(int imageId)
        {
            return this.FabricQualityDataProviderInstance.DeleteFabricQualityPicture(imageId);
        }

        public DataSet GetAllFabricPhotos(int FabricQualityId)
        {
            return this.FabricQualityDataProviderInstance.GetAllFabricPhotos(FabricQualityId);
        }

        public int GetIdByTradeName(string TradeName)
        {
            return this.FabricQualityDataProviderInstance.GetIdByTradeName(TradeName);
        }

        public bool DeleteFabricQuality(int fabricqualityid)
        {
            return this.FabricQualityDataProviderInstance.DeleteFabricQuality(fabricqualityid);
        }

        public FabricQuality GetFabricQualityDetailsByTradeName(string TradeName, string Details, int Mode)
        {
            return this.FabricQualityDataProviderInstance.GetFabricQualityDetailsByTradeName(TradeName, Details, Mode);
        }

        public FabricQuality GetFabricQualityDetailsByTradeNameForPrint(string TradeName)
        {
            return this.FabricQualityDataProviderInstance.GetFabricQualityDetailsByTradeNameForPrint(TradeName);
        }
        ////add code by bharat on 6-2-20
        //public FabricQuality GetMarketingTagName(string TradeName, string Details, int Mode)
        //{
        //    return this.FabricQualityDataProviderInstance.GetMarketingTagName(TradeName, Details, Mode);
        //}
        public List<string> Get_Vender_NameForReallocation(string VenderName)
        {
            return this.FabricQualityDataProviderInstance.Get_Vender_NameForReallocation(VenderName);
        }
        public FabricQuality GetFabricQualityDetailsByTradeNameForPrintOnLoad(string TradeName)
        {
            //return this.FabricQualityDataProviderInstance.GetFabricQualityDetailsByTradeNameYatenOnLoad(TradeName);
            return this.FabricQualityDataProviderInstance.GetFabricQualityDetailsByTradeNameForPrintOnLoad(TradeName);
        }


        public DataSet GetRegisteredFabrics()
        {
            return this.FabricQualityDataProviderInstance.GetRegisteredFabrics();
        }

        public DataSet GetUnRegisteredFabrics()
        {
            return this.FabricQualityDataProviderInstance.GetUnRegisteredFabrics();
        }

        public string GetAllAqlExistingStanderdBAL(double AQLType)
        {
            string dt = this.FabricQualityDataProviderInstance.GetAllAqlExistingStanderdDAL(AQLType);
            return dt;
        }

        #region New FQ 04-08-2016
        public DataSet GetFabricsQualityMaster(string SearchItem, string GroupID, string SubGroupID, string TradeName, string UnitID, string Origin, string FabricType)
        {
            return this.FabricQualityDataProviderInstance.GetFabricsQualityMaster(SearchItem, GroupID, SubGroupID, TradeName, UnitID, Origin, FabricType);
        }

        //Add by Surendra2 on 09-07-2018.
        public DataSet GetFabricsQualityMaster(string SearchItem, string Category, string Quality, string UnitID)
        {
            return this.FabricQualityDataProviderInstance.GetFabricsQualityMaster(SearchItem, Category, Quality, UnitID);
        }
        public DataSet GetCetegory()
        {
            return this.FabricQualityDataProviderInstance.GetCetegory();
        }
        public DataSet GetCetegoryByID(int Id)
        {
            return this.FabricQualityDataProviderInstance.GetCetegoryByID(Id);
        }
        public List<string> Get_Finsh_Value(string ID, string Name)
        {
            return this.FabricQualityDataProviderInstance.Get_Finsh_Value(ID, Name);
        }
        public List<string> Get_Griege_Value(string ID)
        {
            return this.FabricQualityDataProviderInstance.Get_Griege_Value(ID);
        }
        public DataSet Get_GriegeRate_Value(string ID)
        {
            return this.FabricQualityDataProviderInstance.Get_GriegeRate_Value(ID);
        }
        public DataSet Get_GriegeRate_Value_By_Supplier(string ID)
        {
            return this.FabricQualityDataProviderInstance.Get_GriegeRate_Value_By_Supplier(ID);
        }
        public DataSet GetUnit()
        {
            return this.FabricQualityDataProviderInstance.GetUnit();
        }
        public int FabricQualityMaster_InstUpdt(FabricQuality FabricQualityData, int UserId)
        {
            return this.FabricQualityDataProviderInstance.FabricQualityMaster_InstUpdt(FabricQualityData, UserId);
        }
        public DataTable FabricQualityMastEdt(string ID)
        {
            return this.FabricQualityDataProviderInstance.FabricQualityMastEdt(ID);
        }
        public DataTable UnitMastEdt(string ID)
        {
            return this.FabricQualityDataProviderInstance.UnitMastEdt(ID);
        }

        public bool GetIS_CANDC_VALUE(int FabricMaster_ID)
        {
            return this.FabricQualityDataProviderInstance.GetIS_CANDC_VALUE(FabricMaster_ID);
        }

        public DataSet GetGreigeDetails(int ID)
        {
            return this.FabricQualityDataProviderInstance.GetGreigeDetails(ID);
        }
        public int GreigetoFinish_InstUpdt(int Id, int FabricMaster_Id, double GreigeRate, double CutWidth, double CostWidth, string GSM, string CountConstruction, int OptionNo, int CreatedBy, double GriegeWidth,string greigeCC)
        {
            return this.FabricQualityDataProviderInstance.GreigetoFinish_InstUpdt(Id, FabricMaster_Id, GreigeRate, CutWidth, CostWidth, GSM, CountConstruction, OptionNo, CreatedBy, GriegeWidth,greigeCC);
        }
        public int GreigetoFinish_Delete(int Id)
        {
            return this.FabricQualityDataProviderInstance.GreigetoFinish_Delete(Id);
        }

        public DataSet GetFinishDetails(int ID)
        {
            return this.FabricQualityDataProviderInstance.GetFinishDetails(ID);
        }
        public int Finish_InstUpdt(int Id, int FabricMaster_Id, double GreigeWidth, double CutWidth, double CostWidth, string GSM, string CountConstruction, int CreatedBy)
        {
            return this.FabricQualityDataProviderInstance.Finish_InstUpdt(Id, FabricMaster_Id, GreigeWidth, CutWidth, CostWidth, GSM, CountConstruction, CreatedBy);
        }
        public DataSet GetFQHeader(int ID)
        {
            return this.FabricQualityDataProviderInstance.GetFQHeader(ID);
        }
        public List<string> GetFQHeaderforSupplier(string ID)
        {
            return this.FabricQualityDataProviderInstance.GetFQHeaderforSupplier(ID);
        }
        public DataSet GetFQDetails(int ID)
        {
            return this.FabricQualityDataProviderInstance.GetFQDetails(ID);
        }
        public DataSet GetBindSupplier(int FabricMaster_Id)
        {
            return this.FabricQualityDataProviderInstance.GetBindSupplier(FabricMaster_Id);
        }
        public int FQ_Details_Greige_InstUpdate(int Id, int Fabric_Quality_DetailsID, int Supplier, bool Greige, bool Dyed, bool Print, bool DigitalPrint, double MinimumOrderQuantity, int CreatedBy, double GreigeRate, double GreigeFinalRate, int DyedRate, int PrintRate, int DigitalPrintRate)
        {
            return this.FabricQualityDataProviderInstance.FQ_Details_Greige_InstUpdate(Id, Fabric_Quality_DetailsID, Supplier, Greige, Dyed, Print, DigitalPrint, MinimumOrderQuantity, CreatedBy, GreigeRate, GreigeFinalRate, DyedRate, PrintRate, DigitalPrintRate);
        }
        public int FQ_Details_Finish_InstUpdate(int Id, int Fabric_Quality_DetailsID, int Supplier, double GreigeShrinkage, double ResidualShrinkage, double GreigeRate, double GreigeFinalRate, double DyedRate, double PrintRate, double DigitalPrint, double MinimumOrderQuantity, int CreatedBy)
        {
            return this.FabricQualityDataProviderInstance.FQ_Details_Finish_InstUpdate(Id, Fabric_Quality_DetailsID, Supplier, GreigeShrinkage, ResidualShrinkage, GreigeRate, GreigeFinalRate, DyedRate, PrintRate, DigitalPrint, MinimumOrderQuantity, CreatedBy);
        }
        public DataSet GetFQ_Details_By_Fabric_Quality_DetailsID(int ID, int supplier)
        {
            return this.FabricQualityDataProviderInstance.GetFQ_Details_By_Fabric_Quality_DetailsID(ID, supplier);
        }
        public int FQ_Details_Delete(string Id)
        {
            return this.FabricQualityDataProviderInstance.FQ_Details_Delete(Id);
        }
        //End

        public DataTable FabricsQualityMasterEdit(string ID)
        {
            return this.FabricQualityDataProviderInstance.FabricsQualityMasterEdit(ID);
        }

        public int FabricsQualityMaster_InsUpdt(FabricQuality FabricQualityData)
        {
            return this.FabricQualityDataProviderInstance.FabricsQualityMaster_InsUpdt(FabricQualityData);
        }

        public List<FabricQuality> GetFabricQualityDetails(string FQMID, int FabricQualityID)
        {
            return this.FabricQualityDataProviderInstance.GetFabricQualityDetails(FQMID, FabricQualityID);
        }
        //added by abhishek on 16/6/2017
        public List<FabricQuality> GetFabricQualityDetails_history(string FQMID, int FabricQualityID, string Identification)
        {
            return this.FabricQualityDataProviderInstance.GetFabricQualityDetails_history(FQMID, FabricQualityID, Identification);
        }
        //end
        public DataTable GetSuplier(int FabricMasterID, int Type)
        {
            return this.FabricQualityDataProviderInstance.GetSuplier(FabricMasterID, Type);
        }

        public int FabricQualityDetail_InsUpdt(FabricQuality FabricQualityData)
        {
            return this.FabricQualityDataProviderInstance.FabricQualityDetail_InsUpdt(FabricQualityData);
        }

        public int DeleteFabricQualityDetails(string FQMID, int FabricQualityID)
        {
            return this.FabricQualityDataProviderInstance.DeleteFabricQualityDetails(FQMID, FabricQualityID);
        }

        public string GetSupplier_SupplyType(string SupplierID)
        {
            return this.FabricQualityDataProviderInstance.GetSupplier_SupplyType(SupplierID);
        }
        #endregion
        public FabricQuality GetFabricQualityDetailsByTradeName_New(string TradeName, string Details, int Mode, int FabricType, string Suplier)
        {
            return this.FabricQualityDataProviderInstance.GetFabricQualityDetailsByTradeName_New(TradeName, Details, Mode, FabricType, Suplier);
        }
        public FabricQuality GetFabricQualityDetailsByTradeNameForPrint_New(string TradeName)
        {
            return this.FabricQualityDataProviderInstance.GetFabricQualityDetailsByTradeNameForPrint_New(TradeName);
        }
        public FabricQuality GetFabricQualityDetailsByTradeNameForPrintOnLoad_New(string TradeName)
        {
            //return this.FabricQualityDataProviderInstance.GetFabricQualityDetailsByTradeNameYatenOnLoad(TradeName);
            return this.FabricQualityDataProviderInstance.GetFabricQualityDetailsByTradeNameForPrintOnLoad_New(TradeName);
        }

        public DataTable GetFabricQualityDetailsByTradeName_New(string TradeName, string CategoryID, string UnitId)
        {
            return this.FabricQualityDataProviderInstance.GetFabricQualityDetailsByTradeName_New(TradeName, CategoryID, UnitId);
        }
    }
}
