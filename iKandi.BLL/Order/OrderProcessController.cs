#region Assembly Reference
using System;
using System.Collections.Generic;
using System.Data;
using iKandi.Common;
using System.Data.SqlClient;
using iKandi.Common.Entities;
#endregion

namespace iKandi.BLL
{
  public class OrderProcessController : BaseController
  {
    #region

    public OrderProcessController()
    {
    }

    public OrderProcessController(SessionInfo loggedInUser)
      : base(loggedInUser)
    {
    }

    #endregion

    public List<Style> GetQAReusestyles(int styleid, int whichtab = 1)
    {
      return OrderProcessFlow_Instance.GetQAReusestyles(styleid, whichtab);
    }
    // create function for getting repeat order's by sushil on date 7/10/2014
    public List<OrderDetail> Getstyleinfo(int styleno)
    {
      return OrderProcessFlow_Instance.Getstyleinfo(styleno);
    }

    public int insertRiskAnalysisRemark(int sid, int Istrue, string sRemark, int ReusestyleID)
    {

      return OrderProcessFlow_Instance.insertRiskAnalysisRemark(sid, Istrue, sRemark, ReusestyleID);
    }
    public int insertHoPPM(int sid, string scode, string HoppmAttendName, string PPMRemark, int factoryppm, int Hoppm, string jhoppmfile, int jReusestyleID)
    {
      return OrderProcessFlow_Instance.insertHoPPM(sid, scode, HoppmAttendName, PPMRemark, factoryppm, Hoppm, jhoppmfile, jReusestyleID);
    }

    public string InsertOBSAMOrderProcess(string root_breakdown, int jstyleId, string jstylenumber, int jSAMval, int jOBval, string jOBfile, float jAvailminval, int jReusestyleID)
    {
      return OrderProcessFlow_Instance.InsertOBSAMOrderProcess(root_breakdown, jstyleId, jstylenumber, jSAMval, jOBval, jOBfile, jAvailminval, jReusestyleID);
    }

    public DataSet GetRiskAnalysis(string StyleCode, int StyleID, int ClientId, int DeptID, int OrderId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
    {
      return OrderProcessFlow_Instance.GetRiskAnalysis(StyleCode, StyleID, ClientId, DeptID, OrderId, CreateNew, NewRef, ReUse, ReUseStyleId);
    }
    // update by ravi for risk analysis work on 18/8/2015 :
    public int SaveRiskAnalysis(string StyleCode, int StyleID, int ClientId, int DeptID, int OrderID, int CreateNew, int ReUse, int ReUseStyleId, bool IsAccountMgr, bool IsQAPreProd, bool IsQAProd, bool IsMerchandisingMgr, bool isVa, string QaRepresentativeIds, string QaRepresentativeNames, string FactoryRepresentativeIds, string FactoryRepresentativeNames, string MerchandiserId, string MerchandiserName,
        string IERepresentativesId, string IERepresentativesName, string SamplingRepresentativesId, string SamplingRepresentativesName,
            string FabricRepresentativesId, string FabricRepresentativesName, string AccessoryRepresentativesId, string AccessoryRepresentativesName, string OutRepresentativesId, string OutRepresentativesName)
    {
        return OrderProcessFlow_Instance.SaveRiskAnalysis(StyleCode, StyleID, ClientId, DeptID, OrderID, CreateNew, ReUse, ReUseStyleId, IsAccountMgr, IsQAPreProd, IsQAProd, IsMerchandisingMgr, isVa, QaRepresentativeIds,  QaRepresentativeNames,  FactoryRepresentativeIds,  FactoryRepresentativeNames,  MerchandiserId, MerchandiserName
            , IERepresentativesId,  IERepresentativesName,  SamplingRepresentativesId,  SamplingRepresentativesName,

             FabricRepresentativesId,  FabricRepresentativesName,  AccessoryRepresentativesId,  AccessoryRepresentativesName,  OutRepresentativesId,OutRepresentativesName
            );
    }

    public DataSet CheckRiskAnalysis(string StyleCode, int StyleID, int ClientId, int DeptID)
    {
      return OrderProcessFlow_Instance.CheckRiskAnalysis(StyleCode, StyleID, ClientId, DeptID);
    }
    // HO PPM work 

    public DataSet GetHOPPM(string StyleCode, int StyleID, int ClientId, int DeptID, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
    {
      return OrderProcessFlow_Instance.GetHOPPM(StyleCode, StyleID, ClientId, DeptID, CreateNew, NewRef, ReUse, ReUseStyleId);
    }

    public int SaveHOPPM(string StyleCode, int StyleID, int ClientId, int DeptID, int CreateNew, int ReUse, int ReUseStyleId, string QaRepresentativeIds, string QaRepresentativeNames, string FactoryRepresentativeIds, string FactoryRepresentativeNames, string MerchandiserId, string MerchandiserName, bool IsMerchandisingManagerApprovedOn, bool IsQAProdApprovedOn, bool IsFactoryPPMComplete, bool IsHOPPMComplete, string FileUploadUrl1, string FileUploadUrl2, int UserId, bool Seam_Slippage_OK)
    {
        return OrderProcessFlow_Instance.SaveHOPPM(StyleCode, StyleID, ClientId, DeptID, CreateNew, ReUse, ReUseStyleId, QaRepresentativeIds, QaRepresentativeNames, FactoryRepresentativeIds, FactoryRepresentativeNames, MerchandiserId, MerchandiserName, IsMerchandisingManagerApprovedOn, IsQAProdApprovedOn, IsFactoryPPMComplete, IsHOPPMComplete, FileUploadUrl1, FileUploadUrl2, UserId,Seam_Slippage_OK);
    }

    //Added By Ashish on 19/8/2015

    public int UpdateHoppmFile(int StyleID, string FileUploadUrl1, string FileUploadUrl2)
    {
      return OrderProcessFlow_Instance.UpdateHoppmFile(StyleID, FileUploadUrl1, FileUploadUrl2);
    }

    //END

    public DataSet CheckHOPPM(string StyleCode, int StyleID, int ClientId, int DeptID)
    {
      return OrderProcessFlow_Instance.CheckHOPPM(StyleCode, StyleID, ClientId, DeptID);
    }

    public List<OrderFlow> CheckOrderProcess(int styleid, int ClientId, int DeptID, int whichtab = 1)
    {
      return OrderProcessFlow_Instance.CheckOrderProcess(styleid, ClientId, DeptID, whichtab);
    }

    public DataSet CheckOrderProcessStyle(int styleid, int ClientId, int DeptID, int whichtab = 1)
    {
      return OrderProcessFlow_Instance.CheckOrderProcessStyle(styleid, ClientId, DeptID, whichtab);
    }

    public DataSet GetStyleNumberClientDept(int StyleID, int ReUseStyleId, int ClientId, int DeptID, int CreateNew, int NewRef, int ReUse, int Tab)
    {
      return OrderProcessFlow_Instance.GetStyleNumberClientDept(StyleID, ReUseStyleId, ClientId, DeptID, CreateNew, NewRef, ReUse, Tab);
    }

    //Added By Ashish on 17/8/2015
    public DataSet GetStyleClientAndDept(int StyleID, int ReUseStyleId, int ClientId, int DeptID, int CreateNew, int NewRef, int ReUse, int Tab)
    {
      return OrderProcessFlow_Instance.GetStyleClientAndDept(StyleID, ReUseStyleId, ClientId, DeptID, CreateNew, NewRef, ReUse, Tab);
    }

    //Added By Ashish on 21/5/2015
    public DataSet GetRiskRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string RemarksType)
    {
      return OrderProcessFlow_Instance.GetRiskFabricRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
    }
      //abhishek 11/7/2016
    public DataSet GetRiskRemarkForLimitation(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string RemarksType)
    {
        return OrderProcessFlow_Instance.GetRiskRemarkForLimitation(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
    }
      //end
    public bool CheckIsRiskDone(int OrderId)
    {
      return OrderProcessFlow_Instance.CheckIsRiskDone(OrderId);
    }




    public int InsertUpdateRiskRemarks(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence, string RemarksType, int UserId)
    {
      return OrderProcessFlow_Instance.InsertUpdateRiskRemarks(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence, RemarksType, UserId);
    }


    public int InsertUpdateValueAddtion(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence, string RemarksType, int UserId, int fromst, int tost, int valid, bool isuse, bool isuseva, int orderid)
    {
      return OrderProcessFlow_Instance.InsertUpdateValueAddtion(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence, RemarksType, UserId, fromst, tost, valid, isuse, isuseva, orderid);
    }



    public int InsertForReuseRiskData(int styleid, int ReUse, string RemarksType, int UserId)
    {
      return OrderProcessFlow_Instance.InsertForReuseRiskData(styleid, ReUse, RemarksType, UserId);
    }

    /*
      //For Risk Accessories
     public DataSet GetRiskAccessoryRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
     {
         return OrderProcessFlow_Instance.GetRiskAccessoryRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);
     }
     public int InsertUpdateRiskAccessoryRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence)
     {
         return OrderProcessFlow_Instance.InsertUpdateRiskAccessoryRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence);
     }
     public int InsertForReuseOldDataAccessory(int styleid, int ReUse)
     {
         return OrderProcessFlow_Instance.InsertForReuseOldDataAccessory(styleid, ReUse);
     } 
    //Fiting
     public DataSet GetRiskFittingRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
     {
         return OrderProcessFlow_Instance.GetRiskFittingRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);
     } 
     public int InsertUpdateRiskFittingRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence)
     {
         return OrderProcessFlow_Instance.InsertUpdateRiskFittingRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence);
     }
     public int InsertForReuseOldDataFitting(int styleid, int ReUse)
     {
         return OrderProcessFlow_Instance.InsertForReuseOldDataFitting(styleid, ReUse);
     }
    //Making
     public DataSet GetRiskMakingRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
     {
         return OrderProcessFlow_Instance.GetRiskMakingRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);
     }
     public int InsertUpdateMakingRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence)
     {
         return OrderProcessFlow_Instance.InsertUpdateMakingRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence);
     }
     public int InsertForReuseOldDataMaking(int styleid, int ReUse)
     {
         return OrderProcessFlow_Instance.InsertForReuseOldDataMaking(styleid, ReUse);
     } 
     //Imbroidery
     public DataSet GetRiskImbroideryRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
     {
         return OrderProcessFlow_Instance.GetRiskImbroideryRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);
     }
     public int InsertUpdateImbroideryRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence)
     {
         return OrderProcessFlow_Instance.InsertUpdateImbroideryRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence);
     }
     public int InsertForReuseOldDataImbroidery(int styleid, int ReUse)
     { 
         return OrderProcessFlow_Instance.InsertForReuseOldDataImbroidery(styleid, ReUse);
     }
     //Washing
     public DataSet GetRiskWashingRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
     {
         return OrderProcessFlow_Instance.GetRiskWashingRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);
     }
     public int InsertUpdateWashingRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence)
     {
         return OrderProcessFlow_Instance.InsertUpdateWashingRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence);
     }
     public int InsertForReuseOldDataWashing(int styleid, int ReUse)
     {
         return OrderProcessFlow_Instance.InsertForReuseOldDataWashing(styleid, ReUse); 
     }
     //Finishing
     public DataSet GetRiskFinishingRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
     {
         return OrderProcessFlow_Instance.GetRiskFinishingRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);
     }
     public int InsertUpdateFinishingRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence)
     {
         return OrderProcessFlow_Instance.InsertUpdateFinishingRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence);
     }
     public int InsertForReuseOldDataFinishing(int styleid, int ReUse)
     {
         return OrderProcessFlow_Instance.InsertForReuseOldDataFinishing(styleid, ReUse); 
     }
    */
    //For Fits BH
    public DataSet GetFitsRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string RemarksType)
    {
      return OrderProcessFlow_Instance.GetFitsRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
    }
    public int InsertUpdateFitsRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence, string RemarksType, int UserId)
    {
      return OrderProcessFlow_Instance.InsertUpdateFitsRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence, RemarksType, UserId);
    }
    public int InsertForReuseFitsRemark(int styleid, int ReUseStyleId, string RemarksType, int UserId)
    {
      return OrderProcessFlow_Instance.InsertForReuseFitsRemark(styleid, ReUseStyleId, RemarksType, UserId);
    }

    /*
     //For Fits BIPLRemark
     public DataSet GetFitsFitsBIPLRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
     {
         return OrderProcessFlow_Instance.GetFitsFitsBIPLRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);
     }
     public int InsertUpdateBIPLRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence)
     {
         return OrderProcessFlow_Instance.InsertUpdateBIPLRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence);
     }
     public int InsertForReuseOldDataFitsBIPLRemark(int styleid, int ReUse)
     {
         return OrderProcessFlow_Instance.InsertForReuseOldDataFitsBIPLRemark(styleid, ReUse);
     }
    */
    //For HOPPM Remarks
    public DataSet GetHOPPMRemarks(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string RemarksType)
    {
      return OrderProcessFlow_Instance.GetHOPPMRemarks(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
    }
    public int InsertUpdateHOPPMRemarks(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence, string RemarksType, int UserId)
    {
      return OrderProcessFlow_Instance.InsertUpdateHOPPMRemarks(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence, RemarksType, UserId);
    }
    public int ReuseHoppmRemarks(int styleid, int ReUse, string RemarksType, int UserId)
    {
      return OrderProcessFlow_Instance.ReuseHoppmRemarks(styleid, ReUse, RemarksType, UserId);
    }
    /*
     //For HOPPM Accessories Remark
     public DataSet GetHOPPMAccessoryRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
     {
         return OrderProcessFlow_Instance.GetHOPPMAccessoryRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);
     }
     public int InsertUpdateHOPPMAccessoryRemarks(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence)
     {
         return OrderProcessFlow_Instance.InsertUpdateHOPPMAccessoryRemarks(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence);
     }
     public int InsertForReuseOldDataAccessoryHOPPM(int styleid, int ReUse)
     {
         return OrderProcessFlow_Instance.InsertForReuseOldDataAccessoryHOPPM(styleid, ReUse);
     }

     //For HOPPM Fiting Remark
     public DataSet GetHOPPMFitingRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
     {
         return OrderProcessFlow_Instance.GetHOPPMFitingRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);
     }
     public int InsertUpdateHOPPMFitingRemarks(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence)
     {
         return OrderProcessFlow_Instance.InsertUpdateHOPPMFitingRemarks(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence);
     }
     public int InsertForReuseOldDataHoppmFiting(int styleid, int ReUse)
     {
         return OrderProcessFlow_Instance.InsertForReuseOldDataHoppmFiting(styleid, ReUse);
     }

     //For HOPPM Making Remark
     public DataSet GetHOPPMMakingRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
     {
         return OrderProcessFlow_Instance.GetHOPPMMakingRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);
     }
     public int InsertUpdateHOPPMMakingRemarks(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence)
     {
         return OrderProcessFlow_Instance.InsertUpdateHOPPMMakingRemarks(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence);
     }
     public int InsertForReuseOldDataHoppmMaking(int styleid, int ReUse)
     {
         return OrderProcessFlow_Instance.InsertForReuseOldDataHoppmMaking(styleid, ReUse);
     }


     //For HOPPM Imbroidery Remark
     public DataSet GetHOPPMImbroideryRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
     {
         return OrderProcessFlow_Instance.GetHOPPMImbroideryRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);
     }
     public int InsertUpdateHOPPMImbroideryRemarks(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence)
     {
         return OrderProcessFlow_Instance.InsertUpdateHOPPMImbroideryRemarks(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence);
     }
     public int InsertForReuseOldDataHoppmImbroidery(int styleid, int ReUse)
     {
         return OrderProcessFlow_Instance.InsertForReuseOldDataHoppmImbroidery(styleid, ReUse);
     }

     //For HOPPM Washing Remark
     public DataSet GetHOPPMWashingRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
     {
         return OrderProcessFlow_Instance.GetHOPPMWashingRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);
     }
     public int InsertUpdateHOPPMWashingRemarks(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence)
     {
         return OrderProcessFlow_Instance.InsertUpdateHOPPMWashingRemarks(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence);
     }
     public int InsertForReuseOldDataHoppmWashing(int styleid, int ReUse)
     {
         return OrderProcessFlow_Instance.InsertForReuseOldDataHoppmWashing(styleid, ReUse);
     }


    //
     //For HOPPM Finishing Remark
     public DataSet GetHOPPMFinishingRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
     {
         return OrderProcessFlow_Instance.GetHOPPMFinishingRemark(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);
     }
     public int InsertUpdateHOPPMFinishingRemarks(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence)
     {
         return OrderProcessFlow_Instance.InsertUpdateHOPPMFinishingRemarks(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence);
     }
     public int InsertForReuseOldDataHoppmFinishing(int styleid, int ReUse)
     {
         return OrderProcessFlow_Instance.InsertForReuseOldDataHoppmFinishing(styleid, ReUse);
     }
    */

    public int DeleteRiskRemarkById(int RiskId, string RemarksType)
    {
      return OrderProcessFlow_Instance.DeleteRiskRemarkById(RiskId, RemarksType);
    }

    public int DeleteHoppmRemarkById(int RiskId, string RemarksType)
    {
      return OrderProcessFlow_Instance.DeleteHoppmRemarkById(RiskId, RemarksType);
    }

    public int DeleteFitingRemarkById(int RiskId, string RemarksType)
    {
      return OrderProcessFlow_Instance.DeleteFitingRemarkById(RiskId, RemarksType);
    }


    //END 
    //Added By abhishek on 25/5/2015
    public DataSet GetRiskAllRemark(string StyleCode, int StyleID)
    {
      return OrderProcessFlow_Instance.GetRiskAllRemark(StyleCode, StyleID);
    }
    public DataSet GetHoppm_AllRemark(string StyleCode, int StyleID)
    {
      return OrderProcessFlow_Instance.GetHoppm_AllRemark(StyleCode, StyleID);
    }
    public DataSet GetFitingRemark(string StyleCode, int StyleID)
    {
      return OrderProcessFlow_Instance.GetFitingRemark(StyleCode, StyleID);
    }

    public DataTable GetOBSheet_CMT(int Styleid)
    {
      return OrderProcessFlow_Instance.GetOBSheet_CMT(Styleid);
    }
    //END

    public int GetStcApproved(int styleid)
    {
      return OrderProcessFlow_Instance.GetStcApproved(styleid);
    }

    public DataTable GetStiched_OBSAM(int Styleid)
    {
      return OrderProcessFlow_Instance.GetStiched_OBSAM(Styleid);
    }

    public InlinePPM Get_InlineTopSection_by_style_id(int StyleID, string StyleNumber)
    {
      return OrderProcessFlow_Instance.Get_InlineTopSection_by_style_id(StyleID, StyleNumber);
    }
    public InlinePPM Get_PPSample_OrderDetaiLDID(int OrderDetailID)
    {
        return OrderProcessFlow_Instance.Get_PPSample_OrderDetaiLDID(OrderDetailID);
    }
    public InlinePPM Get_PPSample_History_OrderDetaiLDID(int OrderDetailID)
    {
        return OrderProcessFlow_Instance.Get_PPSample_History_OrderDetaiLDID(OrderDetailID);
    }

    public void SaveOrderContractTOPDetails(InlinePPMOrderContract InlinePPMData)
    {
      this.OrderProcessFlow_Instance.SaveOrderContractTOPDetails(InlinePPMData);
    }
    public void SavePPMDetails(InlinePPMOrderContract InlinePPMData)
    {
        this.OrderProcessFlow_Instance.SavePPMDetails(InlinePPMData);
    }
    public void SaveSrv(InlinePPMOrderContract SrvDetail)
    {
        this.OrderProcessFlow_Instance.SaveSrv(SrvDetail);
    }
    public void Save_FabricDebitNote(InlinePPMOrderContract DebitNotesDetail, ref int DebitNoteID, int PO_id)
    {
        this.OrderProcessFlow_Instance.Save_FabricDebitNote(DebitNotesDetail, ref DebitNoteID, PO_id);
    }
    public void Save_FabricCreditNote(InlinePPMOrderContract DebitNotesDetail, ref int CreditNoteID, int PO_id)
    {
        this.OrderProcessFlow_Instance.Save_FabricCreditNote(DebitNotesDetail, ref CreditNoteID, PO_id);
    }
    public void Update_FabricDebitNote(InlinePPMOrderContract DebitNotesDetail, int Debit_Note_ID)
    {
        this.OrderProcessFlow_Instance.Update_FabricDebitNote(DebitNotesDetail,Debit_Note_ID);
    }
    public void Update_FabricCreditNote(InlinePPMOrderContract DebitNotesDetail, int CreditNoteID)
    {
        this.OrderProcessFlow_Instance.Update_FabricCreditNote(DebitNotesDetail, CreditNoteID);
    }
   
    public DataTable OB_HeaderExist(int Styleid)
    {
      return OrderProcessFlow_Instance.OB_HeaderExist(Styleid);
    }

    public int CreateNewRef_ReUse_All_OBdata(int styleid, string StyleCode, int ClientId, int DeptId, int ReUseStyleId, int ReUse, int NewRef, int UserId)
    {
      return OrderProcessFlow_Instance.CreateNewRef_ReUse_All_OBdata(styleid, StyleCode, ClientId, DeptId, ReUseStyleId, ReUse, NewRef, UserId);
    }
    public DataTable GET_OB_ReUseStyle(int StyleID)
    {
      return OrderProcessFlow_Instance.GET_OB_ReUseStyle(StyleID);
    }

    //Added By Ashish on 28/7/2015
    public int OBWSSAMachieved(int StyleID)
    {
      return OrderProcessFlow_Instance.OBWSSAMachieved(StyleID);
    }

    //END

    public List<HOPPMOB> GetHOPPMRemarksTest(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string RemarksType)
    {
      return OrderProcessFlow_Instance.GetHOPPMRemarksTest(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
    }

    public DataTable GetStyleNumber(int StyleID)
    {
      return OrderProcessFlow_Instance.GetStyleNumber(StyleID);
    }
    //added by abhishek 21/10/2015
    public DataTable Hoppm_OBComplete_Check(int StyleID)
    {
      return OrderProcessFlow_Instance.Hoppm_OBComplete_Check(StyleID);
    }
    //end abhishek on 21/10/2015

    public DataTable GetPackingListSizeDetails(int OrderDetailId)
    {
      return OrderProcessFlow_Instance.GetPackingListSizeDetails(OrderDetailId);
    }

    public DataTable GetPackingListQuantityDetails(int OrderDetailId)
    {
      return OrderProcessFlow_Instance.GetPackingListQuantityDetails(OrderDetailId);
    }

    public DataTable GetValueAdditionDetails(int OrderDetailId)
    {
      return OrderProcessFlow_Instance.GetValueAdditionDetails(OrderDetailId);
    }
    public DataTable GetValueAdditionDetailss(int OrderDetailId, int vaid)
    {
      return OrderProcessFlow_Instance.GetValueAdditionDetailss(OrderDetailId,vaid);
    }
    public int GetValueAddQty(int OrderDetailId, int SizeId, int ValueAdditionId, int UnitId)
    {
      return OrderProcessFlow_Instance.GetValueAddQty(OrderDetailId, SizeId, ValueAdditionId, UnitId);
    }

    public DataTable GetValueAdditionHistoryDetails(int OrderDetailId, int UnitId)
    {
      return OrderProcessFlow_Instance.GetValueAdditionHistoryDetails(OrderDetailId, UnitId);
    }

    public int GetValueAddQtyHistory(int OrderDetailId, int ValueAdditionId, DateTime Date, int UnitId)
    {
      return OrderProcessFlow_Instance.GetValueAddQtyHistory(OrderDetailId, ValueAdditionId, Date, UnitId);
    }

    public int UpdateQty(int OrderDetailId, int ValueAddQty, int ValueAdditionId, int UnitId)
    {
      return OrderProcessFlow_Instance.UpdateQty(OrderDetailId, ValueAddQty, ValueAdditionId, UnitId);
    }
    public int UpdateQtywithflag(int OrderDetailId, int ValueAddQty, int ValueAdditionId, int UnitId, string flag, string val)
    {
      return OrderProcessFlow_Instance.UpdateQtywithflag(OrderDetailId, ValueAddQty, ValueAdditionId, UnitId, flag, val);
    }
    public string GetUnitName(int UnitId)
    {
      return OrderProcessFlow_Instance.GetUnitName(UnitId);
    }

    //added by raghvinder on 03-09-2020 start
    public DataSet Get_Reallocation_History(int StyleId)
    {
        return OrderProcessFlow_Instance.Get_Reallocation_History(StyleId);
    }
    //added by raghvinder on 03-09-2020 end

    public DataTable Get_OBOperations_History(int StyleID)
    {
        return OrderProcessFlow_Instance.Get_OBOperations_History(StyleID);
    }

      //Add By Prabhaker 29-05-17

    public DataTable GetCostingComplete(int StyleID)
    {
        return OrderProcessFlow_Instance.GetCostingComplete(StyleID);
    }

    //Add By bharat 27-jan-19

    public InlinePPM Get_Srv_details(int PoDetailID,string Type,string flag)
    {
        return OrderProcessFlow_Instance.Get_Srv_details(PoDetailID, Type, flag);
    }
    public string[] Get_Srv_detailsProxy(string PartyBillNo, string Flag, string SrvId)
    {
        return OrderProcessFlow_Instance.Get_Srv_detailsProxy(PartyBillNo, Flag, SrvId);
    }
    public DataTable getmaxvouchernumber(int PoDetailID, string Type, string Flag, int PartyBillId = 0)
    {
      return OrderProcessFlow_Instance.getmaxvouchernumber(PoDetailID, Type, Flag, PartyBillId);
    }
    public DataTable Accgetmaxvouchernumber(int PoDetailID, string Type, string Flag, int PartyBillId = 0, string PartyBillNo = "", int SupplierMasterID = 0)
    {
        return OrderProcessFlow_Instance.Accgetmaxvouchernumber( PoDetailID,  Type,  Flag,  PartyBillId,  PartyBillNo, SupplierMasterID);
    }
    public DataTable GetPartyBillAmt(int SupplierMasterID, string PartyNumber)
    {
        return OrderProcessFlow_Instance.GetPartyBillAmt(SupplierMasterID, PartyNumber);
    }
    public DataTable getmaxvouchernumber(int PoDetailID, string Type, string Flag, int PartyBillId = 0, string PartyBillNo = "", int SupplierMasterID = 0)
    {
        return OrderProcessFlow_Instance.getmaxvouchernumber(PoDetailID, Type, Flag, PartyBillId, PartyBillNo, SupplierMasterID);
    }

    public DataTable getDataToBindGridWithId_grdbill(int MasterPoId,int SrvID,string BillNumber,string flag)
    {
        return OrderProcessFlow_Instance.getDataToBindGridWithId_grdbill(MasterPoId, SrvID, BillNumber, flag);
    }


    public DataTable getmaxvouchernumbeAcc(int PoDetailID, string Type, string Flag, int PartyBillId = 0, string PartyBillNo = "", int SupplierMasterID = 0)
    {
        return OrderProcessFlow_Instance.getmaxvouchernumbeAcc(PoDetailID, Type, Flag, PartyBillId, PartyBillNo, SupplierMasterID);
    }
    public DataTable Getbipladdress(int PoDetailID, string types, string flag)
    {
        return OrderProcessFlow_Instance.Getbipladdress(PoDetailID,types,flag);
    }
    public InlinePPM Get_DebitChallan_details(int DebitNoteId, int Flag,string Type)
    {
        return OrderProcessFlow_Instance.Get_DebitChallan_details(DebitNoteId, Flag, Type);
    }
    public InlinePPM Get_CreditChallan_details(int CreditNoteId, int Flag, string Type)
    {
        return OrderProcessFlow_Instance.Get_CreditChallan_details(CreditNoteId, Flag, Type);
    }
    public DataTable Get_DebitChallan_detailsTable(int DebitNoteId, int Flag, string Type)
    {
        return OrderProcessFlow_Instance.Get_DebitChallan_detailsTable(DebitNoteId, Flag, Type);
    }
    public DataTable Get_CreditChallan_detailsTable(int CreditNoteId, int Flag, string Type)
    {
        return OrderProcessFlow_Instance.Get_CreditChallan_detailsTable(CreditNoteId, Flag, Type);
    }
    public DataTable Get_DebitChallan_details_id(int DebitNoteId, int Flag, string type)
    {
      return OrderProcessFlow_Instance.Get_DebitChallan_details_id(DebitNoteId, Flag, type);
    }
    public DataTable Get_CreditChallan_details_id(int CreditNoteId, int Flag, string type)
    {
        return OrderProcessFlow_Instance.Get_CreditChallan_details_id(CreditNoteId, Flag, type);
    }
    public DataTable Get_DebitChallan_details_id2(int DebitNoteId, int Flag, string type)
    {
        return OrderProcessFlow_Instance.Get_DebitChallan_details_id2(DebitNoteId, Flag, type);
    }
    public DataTable Get_CreditChallan_details_id2(int CreditNoteId, int Flag, string type)
    {
        return OrderProcessFlow_Instance.Get_CreditChallan_details_id2(CreditNoteId, Flag, type);
    }
    public void Save_FabricDebitNote_Particulers(InlinePPMOrderContract DebitNotesDetails, int Scope_Identity)
    {
        this.OrderProcessFlow_Instance.Save_FabricDebitNote_Particulers(DebitNotesDetails, Scope_Identity);
    }
    public void Save_FabricCreditNote_Particulers(InlinePPMOrderContract DebitNotesDetails, int Scope_Identity)
    {
        this.OrderProcessFlow_Instance.Save_FabricCreditNote_Particulers(DebitNotesDetails, Scope_Identity);
    }
    public void Update_FabricDebitNote_Particulers(InlinePPMOrderContract DebitNotesDetails, int Debit_Note_ID,int DebitParticulersID)
    {
        this.OrderProcessFlow_Instance.Update_FabricDebitNote_Particulers(DebitNotesDetails, Debit_Note_ID, DebitParticulersID);
    }
    public int UpdateFabricDebitNote_Particulers(int PO_id, string Particulars, int qty, decimal rate, int ParticulersID, string Type)
    {
        return this.OrderProcessFlow_Instance.UpdateFabricDebitNote_Particulers(PO_id, Particulars, qty, rate, ParticulersID, Type);
    }
   
    public int DeleteDebinoteID(int DebinoteID)
    {
        return this.OrderProcessFlow_Instance.DeleteDebinoteID(DebinoteID);
    }
// this code added by bharat on 3-july for am FabricPerformance report
    public DataSet Get_FabricFinish_details(int QualityId, int OrderDetail, string FabricDetails)
    {
        return OrderProcessFlow_Instance.Get_FabricFinish_details(QualityId, OrderDetail, FabricDetails);
    }
      // end

    //new code 12 feb 2020 start
    public string[] GetCMTCalcualtor(int Quantity, float SAM1, int OB, float Eff, DateTime StartDate, string flag)
    {
        return OrderProcessFlow_Instance.GetCMTCalcualtor(Quantity, SAM1, OB, Eff, StartDate, flag);
    }

    public DataSet GetCMTInfo(int OrderDetailID)
    {
        return OrderProcessFlow_Instance.GetCMTInfo(OrderDetailID);
    }

      
    //new code 12 feb 2020 end
    public int UpdateValueAddition(int OrderDetailId, int ValueAdditionId, int ValueAddQty, int ManPower, int QCId, int CheckerId, int UnitId, bool IsComplete, int UserID)
    {
        return OrderProcessFlow_Instance.UpdateValueAddition(OrderDetailId, ValueAdditionId, ValueAddQty, ManPower, QCId, CheckerId, UnitId, IsComplete, UserID);
    }
  }
}
