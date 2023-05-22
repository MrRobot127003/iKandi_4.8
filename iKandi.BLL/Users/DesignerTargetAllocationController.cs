using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.DAL;
using iKandi.Common;
using System.Data;

namespace iKandi.BLL
{
  public class DesignerTargetAllocationController:BaseController
    {

         #region

        public DesignerTargetAllocationController()
        {
        }

        public DesignerTargetAllocationController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public DataSet GetDesignerTargetAllocationById(int DesignerID)
        {
            return this.DesignerTargetAllocationDataproviderInstance.GetDTAByDesignerId(DesignerID);
        }

        public DataSet GetDesignerTargetAllocationGetAll(int iBHId,int iClientId)
        {
            return this.DesignerTargetAllocationDataproviderInstance.GetAllDTA(iBHId,iClientId);
        }

        public int UpdateDesignerTargetAllocation(DesignerTargetAllocation objDesignerTarget)
        {
            return this.DesignerTargetAllocationDataproviderInstance.UpdateDesignerTargetAllocation(objDesignerTarget);
        }
      


    }
}
