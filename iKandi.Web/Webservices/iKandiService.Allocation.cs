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
using iKandi.BLL;
using System.Collections.Generic;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class iKandiService
    {
        [WebMethod(EnableSession = true)]
        public bool DeleteProductionUnit(int productionUnitId)
        {
            return this.AllocationControllerInstance.DeleteProductionUnit(productionUnitId);
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateOrderDetailWithAllocationData(int[] orderDetailIds, int[] productionUnitIds, int[] allocatedIds,
            string[] fabricDetails, string[] accessoriesDetails, string[] cuttingDetails, bool isReallocated)
        {
            bool success = this.AllocationControllerInstance.UpdateOrderDetailWithAllocationData(orderDetailIds, productionUnitIds, allocatedIds,
                fabricDetails, accessoriesDetails, cuttingDetails, isReallocated);
            Session["adc"] = this.AllocationControllerInstance.GetAllocationData();
            return success;
        }

        [WebMethod(EnableSession = true)]
        public ProductionUnit GetProductionUnitByCode(string code)
        {
            ProductionUnitCollection objProductionUnitCollection = (ProductionUnitCollection)Session["pu"];

            ProductionUnit objProductionUnit = objProductionUnitCollection.Find(delegate(ProductionUnit unit) { return (unit.FactoryCode == code); });

            if (null != objProductionUnit)
                return objProductionUnit;

            return null;
        }

        [WebMethod(EnableSession = true)]
        public Allocation GetAllocationByOrderDetailId(int orderDetailId, int  productionUnitId)
        {
           // System.Diagnostics.Debugger.Break();
            if (productionUnitId > 0)
            {
                AllocationCollection objAllocationCollection = ApplicationHelper.AllocatedUnitData;
                return objAllocationCollection.Find(delegate(Allocation a) { return (a.Unit.ProductionUnitId == productionUnitId); });
            }
            else
            {
                AllocationCollection objAllocationCollection = (AllocationCollection)Session["adc"];
                return objAllocationCollection.Find(delegate(Allocation a) { return (a.OrderDetailID == orderDetailId); });
            }
        }

        [WebMethod(EnableSession = true)]
        public AllocationHistoryCollection GetAllocationHistory(int productionUnitId)
        {
            return this.AllocationControllerInstance.GetAllocationHistory(productionUnitId);
        }

        [WebMethod(EnableSession = true)]
        public List<Allocation> SearchAllocatedOrders(string iKandiSerial, string styleNumber)
        {
            AllocationCollection objAllocationCollection = (AllocationCollection)Session["adc"];

            if (null == objAllocationCollection)
            {
                objAllocationCollection = this.AllocationControllerInstance.GetAllocationData();
                Session["adc"] = objAllocationCollection;
            }

            List<Allocation> filteredAllocationCollection = objAllocationCollection.FindAll(delegate(Allocation a) { return (a.SerialNumber.ToLower().Contains(iKandiSerial.ToLower()) && a.StyleNumber.ToLower().Contains(styleNumber.ToLower()) && a.IsAllocated); });
            return filteredAllocationCollection;
        }

        [WebMethod(EnableSession = true)]
        public string GetUnitColor(string factoryCode)
        {
            return ApplicationHelper.GetUnitColor(factoryCode);
        }
    }
}
