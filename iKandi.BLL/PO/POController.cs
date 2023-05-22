using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;
using System.Data;

namespace iKandi.BLL
{
    //created by manisha on 20 Dec 2011
    public class POController : BaseController
    {
        #region constructors

        public POController()
        {
        }

        public POController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }
        #endregion

        public PO GetPOByID(int POID)
        {
            return this.PODataProviderInstance.GetPOByID(POID);
        }

        public MasterPO GetMasterPOByID(int MID)
        {
            return this.PODataProviderInstance.GetMasterPOByID(MID);
        }

        public Supplier GetSupplierBySID(int SID)
        {
            return this.PODataProviderInstance.GetSupplierBySID(SID);
        }

        public POProcess GetProcessByPID(int PID)
        {
            return this.PODataProviderInstance.GetProcessByPID(PID);
        }

        public MasterPO GetMasterPOByPOID(int POID)
        {
            return this.PODataProviderInstance.GetMasterPOByPOID(POID);
        }

        public List<PO> GetPOByMasterPOID(int MID)
        {
            return this.PODataProviderInstance.GetPOByMasterPOID(MID);
        }

        public List<POProcess> GetProcessByMasterPOID(int MID)
        {
            return this.PODataProviderInstance.GetProcessByMasterPOID(MID);
        }

        public Supplier GetSupplierByPOID(int POID)
        {
            return this.PODataProviderInstance.GetSupplierByPOID(POID);
        }

        public PO GetPODetails(int MOID, int SID, int POType, int ProcessID)
        {
            return this.PODataProviderInstance.GetPODetails(MOID, SID, POType, ProcessID);
        }


        public PO GetPODetailsByFabric(string fabric, string print, int SID, int POType, int ProcessID, int ClientID, int Washing)
        {
            return this.PODataProviderInstance.GetPODetailsByFabric(fabric, print, SID, POType, ProcessID, ClientID, Washing);
        }

        public List<PO> GetALLPOByID(int POID)
        {
            return this.PODataProviderInstance.GetALLPOByID(POID);
        }

        public DataSet GetAllProcessDetails(int MainPOID, int ProcessID)
        {
            return this.PODataProviderInstance.GetAllProcessDetails(MainPOID, ProcessID);
        }

        public DataSet GetPOInstruction(int MOID, int POType, int GroupType, int POID)
        {
            return this.PODataProviderInstance.GetPOInstruction(MOID, POType, GroupType, POID);
        }

        public List<OrderDetail> GetOrderByMasterPOID(MasterPO masterPO)
        {
            return this.PODataProviderInstance.GetOrderByMasterPOID(masterPO);
        }

        public DataSet GetMainPODeliveryDetails(int MOID, int ClientID, string fabricName, string PrintName, int OrderType, int POType)
        {
            return this.PODataProviderInstance.GetMainPODeliveryDetails(MOID, ClientID, fabricName, PrintName, OrderType, POType);
        }

        public DataSet GetMainPOGreigeDetails(string Fab, int MasterPOID, int ProcessID, string Params)
        {
            return this.PODataProviderInstance.GetMainPOGreigeDetails(Fab, MasterPOID, ProcessID, Params);
        }

        #region Save
        public int SavePODetails(PO currentPO, int TaskID, int IsUpdate)
        {
            return this.PODataProviderInstance.SavePODetails(currentPO, TaskID, IsUpdate);
        }

        public int SaveReprocessingDetails(ReprocessPO currentPO, int ReType, string TypeID)
        {
            return this.PODataProviderInstance.SaveReprocessingDetails(currentPO, ReType, TypeID);
        }

        public int SaveMainPODetails(MasterPO masterPO)
        {
            return this.PODataProviderInstance.SaveMainPODetails(masterPO);
        }

        public int SaveProcessDetails(string strXML, int MID)
        {
            return this.PODataProviderInstance.SaveProcessDetails(strXML, MID);
        }

        public int SaveOrderDetails(string strXML, int MID)
        {
            return this.PODataProviderInstance.SaveOrderDetails(strXML, MID);
        }
        #endregion

        //CancelReason
        public int CancelPO(int POID, string CancelReason)
        {
            return this.PODataProviderInstance.CancelPO(POID, CancelReason);
        }

        public DataSet GetAllClosedPO(int MainPOID)
        {
            return this.PODataProviderInstance.GetAllClosedPO(MainPOID);
        }

        public ListCM GetAllCurrency()
        {
            return this.PODataProviderInstance.GetAllCurrency();
        }

        public int SaveSamplingPo(ListSID lsd)
        {
            return this.PODataProviderInstance.SaveSamplingPo(lsd);
        }
    }
}
