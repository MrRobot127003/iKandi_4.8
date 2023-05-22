using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class iKandiService
    {
        [WebMethod(EnableSession = true)]
        public string GetOutStandingPopUp(string supplierGroup,int poType,int fortNight)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("SupplierGroup", supplierGroup);
            properties.Add("PoType", poType);
            properties.Add("FortNight", fortNight);
            return PageHelper.GetControlHtml("~/FabricAndAccessories/Form/Financial_PopUp1.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetBillManagementPopUp(int BillId)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("BillId", BillId);
            return PageHelper.GetControlHtml("~/FabricAndAccessories/Form/Financial_BillManagement_PopUp.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetIIChallanPopUp(int OrderDetailId,int Type,string FabricName,string PrintColor)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("OrderDetailId", OrderDetailId);
            properties.Add("Type", Type);
            properties.Add("FabricName", FabricName);
            properties.Add("PrintColor", PrintColor);
            return PageHelper.GetControlHtml("~/FabricAndAccessories/Form/FIHMWCPopUp.ascx", properties);
        }
    }
}
