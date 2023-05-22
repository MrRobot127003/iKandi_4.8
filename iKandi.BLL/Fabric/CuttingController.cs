using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;

namespace iKandi.BLL
{
  public class CuttingController : BaseController
  {

    #region

    public CuttingController(SessionInfo LoggedInUser)
      : base(LoggedInUser)
    {
    }

    #endregion

    public bool InsertCutting(Cutting cutting)
    {
      return this.CuttingDataProviderInstance.InsertCutting(cutting);
    }

    public bool UpdateCutting(Cutting cutting)
    {
        return this.CuttingDataProviderInstance.UpdateCutting(cutting);
    }

    public Cutting GetCuttingByOrderID(int orderID)
    {
      return this.CuttingDataProviderInstance.GetCuttingByOrderID(orderID);
    }

  }
}
