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
  public class LiabilityController : BaseController
  {
    #region Ctors

    public LiabilityController(SessionInfo LoggedInUser)
      : base(LoggedInUser)
    {
    }

    #endregion

    #region Insertion Methods

    public bool InsertLiability(Liability liability)
    {
      return this.LiabilityDataProviderInstance.InsertLiability(liability);
    }

    public void InsertLiabilityMerchantRemarks(int OrderDetailID, string Remarks, int Option)
    {
        bool success = false;
        success = this.LiabilityDataProviderInstance.InsertLiabilityMerchantRemarks(OrderDetailID, Remarks,Option);

        if (success)
        {
                  //WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(OrderDetailID);
                  //WorkflowInstanceDetail newtask = this.WorkflowControllerInstance.CreateTask(StatusMode.CANCELLED, instance.WorkflowInstanceID, DateTime.Now);
                  //this.WorkflowControllerInstance.CompleteTask(newtask, this.LoggedInUser.UserData.UserID);                 
        }
    }

    #endregion

    #region Get Methods

    public Liability GetLiability(int orderDetailID, int LiabilityID)
    {
        return this.LiabilityDataProviderInstance.GetLiability(orderDetailID, LiabilityID);
    }

    public Liability GetLiabilityData(int orderDetailID, int LiabilityID)
    {
        return this.LiabilityDataProviderInstance.GetLiabilityData(orderDetailID, LiabilityID);
    }

    public DataSet GetLiabilityReport(int PageSize, int PageIndex, out int TotalPageCount, int PaymentStatus, DateTime FromDate, DateTime ToDate, int Year,int ClientId,string StrSearch)
    {
        return this.LiabilityDataProviderInstance.GetLiabilityReport(PageSize, PageIndex, out TotalPageCount, PaymentStatus, FromDate, ToDate, Year, ClientId, StrSearch);
    }

    public int GetOrderDetailIDByContractNumber(String ContractNumber)
    {
        return this.LiabilityDataProviderInstance.GetOrderDetailIDByContractNumber(ContractNumber);
    }

      /// <summary>
      /// For  getting Accessory Total 18 Aug : Yaten
      /// </summary>
      /// <param name="intLiabilityID"></param>
      /// <returns></returns>
    public int GetAccessoryTotalBAL(int intLiabilityID)
    {
        return this.LiabilityDataProviderInstance.GetAccessoryTotalDAL(intLiabilityID);
    }

    public string GetNewLiabilityNumber()
    {
        return this.LiabilityDataProviderInstance.GetNewLiabilityNumber();
    }

    #endregion

    #region Updation Methods

    public bool UpdateLiability(Liability liability)
    {
      return this.LiabilityDataProviderInstance.UpdateLiability(liability);
    }

/// <summary>
/// yaten: update Avg value
/// </summary>
/// <param name="liability"></param>
/// <returns></returns>
    public void UpdateAvgLiabilityBAL(string Avg1, string Avg2, string Avg3, string Avg4,int Id)
    {
        this.LiabilityDataProviderInstance.UpdateAvgLiabilityDAL(Avg1,Avg2,Avg3,Avg4,Id);
    }



    #endregion

  
  }
}
