using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using System.Collections.Generic;
using iKandi.Common;
using iKandi.BLL;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class iKandiService
    {

        [WebMethod(EnableSession = true)]
        public string GetPackingOrderView(int PackingID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("PackingID", PackingID);

            return PageHelper.GetControlHtml("~/UserControls/Lists/PackingOrders.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GeneratePackingList(int PackingId, int OrderID)
        {
            string fileName = "Packing_List";
            return this.DeliveryControllerInstance.GeneratePackingListExcel(OrderID, PackingId, fileName);
        }
        //abhishek 9/11/2017 
        [WebMethod(EnableSession = true)]
        public List<PackingDelivery> UpdateBankRefNo(int ShipemntPkID, string OldBankRefNo, string NewBankRefNo)
        {
            return this.InvoiceControllerInstance.UpdateBankRefNo(ShipemntPkID, OldBankRefNo, NewBankRefNo);
            
        }

    }
}
