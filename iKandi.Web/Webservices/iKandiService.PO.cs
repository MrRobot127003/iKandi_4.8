using System;
using System.Web.Services;
using System.Collections.Generic;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class iKandiService
    {
        //by manisha
        [WebMethod(EnableSession = true)]
        public string GetPOSupplier(string fabric, string ProcessID, string MainPOID, string Params)
        {
            /* Stock,TaskId,ProcessType */
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("Fabric", fabric);
            properties.Add("ProcessID", Convert.ToInt32(ProcessID));
            properties.Add("MainPOID", Convert.ToInt32(MainPOID));
            properties.Add("Params", Params);
            return PageHelper.GetControlHtml("~/UserControls/Lists/SupplierListCommon.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetAssociatedContracts(string MID, string CID, string fabric, string print)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("OrderFabric", fabric);
            properties.Add("OrderPrint", print);
            properties.Add("MID", Convert.ToInt32(MID));
            properties.Add("OrderClient", Convert.ToInt32(CID));
            return PageHelper.GetControlHtml("~/UserControls/Lists/OrderListCommon.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public List<POProcess> GetProcessByMasterPOID(string MID)
        {
            return this.POControllerInstance.GetProcessByMasterPOID(Convert.ToInt32(MID));
        }
        /// <summary>
        /// Yaten:Get all Task by ID
        /// </summary>
        /// <param name="TaskId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetTaskById(int TaskId)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();

            properties.Add("TaskId", Convert.ToInt32(TaskId));
            properties.Add("MainTaskID", -1);
            properties.Add("TaskName", "All");
            return PageHelper.GetControlHtml("~/UserControls/Forms/FnATasks.ascx", properties);
        }

        /// <summary>
        /// Yaten : Get Debitnote Detail for Debit Mgmt PopUp
        /// </summary>
        /// <param name="TaskId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string DebitNotePopUpById(int Id)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();

            properties.Add("Id", Convert.ToInt32(Id));//E:\iKandiTFSServer\iKandi\iKandi.Web\FabricAndAccessories\Form\DebitNotePopUp.ascx
            return PageHelper.GetControlHtml("~/FabricAndAccessories/Form/DebitNotePopUp.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetReprocessingDetails(string type, string TypeID, string number)
        {
            /* Stock,TaskId,ProcessType */
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("ReType", type);
            properties.Add("TypeID", TypeID);
            properties.Add("ReNumber", number);
            return PageHelper.GetControlHtml("~/UserControls/Lists/ReprocessingPopUp.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public int CancelPO(string POID, string CancelReason)
        {
            return this.POControllerInstance.CancelPO(Convert.ToInt32(POID), CancelReason);
        }

  [WebMethod(EnableSession = true)]
        public void RefreshDashBoard()
        {

            this.AdminControllerInstance.RefreshDashBoard();
        }

    }
}