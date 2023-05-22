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
  public class FabricApprovalController : BaseController
  {
    #region

    public FabricApprovalController(SessionInfo LoggedInUser)
      : base(LoggedInUser)
    {
    }

    #endregion

    public bool InsertFabricApproval(FabricApproval fabricApproval)
    {
      return this.FabricApprovalDataProviderInstance.InsertFabricApproval(fabricApproval);
    }

    //public bool UpdateFabricApproval(FabricApproval fabricApproval)
    //{
    //  return this.FabricApprovalDataProviderInstance.UpdateFabricApproval(fabricApproval);
    //}

    public FabricApproval GetFabricApproval(int FabricApprovalID)
    {
      return this.FabricApprovalDataProviderInstance.GetFabricApproval(FabricApprovalID);
    }

    public DataSet GetLabDipHistory(int clientID, string fabric, int orderid, int styleid, string fabricDetails)
    {
        return this.FabricApprovalDataProviderInstance.GetLabDipHistory(clientID, fabric, orderid,styleid, fabricDetails);
    }
   
    public DataSet GetBulkHistory(int clientID, string fabric, int orderid, int styleid, string fabricDetails)
    {
        return this.FabricApprovalDataProviderInstance.GetBulkHistory(clientID, fabric, orderid, styleid, fabricDetails);
    }
    public string GetCcGsm(string fabricname)
    {
        return this.FabricApprovalDataProviderInstance.GetCcGsm(fabricname);
    }
  }
}
