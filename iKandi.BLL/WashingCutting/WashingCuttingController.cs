using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.Common.Entities;

namespace iKandi.BLL
{
    public class WashingCuttingController : BaseController
    {
        #region Ctor(s)
        public WashingCuttingController()
        {
        }

        public WashingCuttingController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }
        #endregion

        #region Methods

        public WashingCutting GetWashingCuttingDetails(int orderId)
        {
            return this.WashingCuttingDataProviderInstance.GetWashingCuttingDetails(orderId);
        }

        public int InsertWashing(WashingCuttingTotal wc)
        {
            return this.WashingCuttingDataProviderInstance.InsertWashing(wc);
        }

        public int InsertWashingList(WCTList wc,int userId)
        {
            return this.WashingCuttingDataProviderInstance.InsertWashingList(wc, userId);
        }

        public WashingCuttingTotal GetWcDetailByOdIdAndFabric(int orderDetailId, string fabricName,string fabricdetails)
        {
            return this.WashingCuttingDataProviderInstance.GetWcDetailByOdIdAndFabric(orderDetailId, fabricName,
                                                                                      fabricdetails);
        }

        public int WashingCuttingComplete(WashingCuttingTotal wc)
        {
            return this.WashingCuttingDataProviderInstance.WashingCuttingComplete(wc);
        }

        public WashingCuttingList GetWashingCuttingDetailList(int OrderId)
        {
            return this.WashingCuttingDataProviderInstance.GetWashingCuttingDetailList(OrderId);
        }

        public WashingCuttingList GetWcDetailListProgress(int orderId)
        {
            return this.WashingCuttingDataProviderInstance.GetWcDetailListProgress(orderId);
        }

        public IICDList GetChallanDetailByOdId(int odId,int type,string fabricname,string printcolor)
        {
            return this.WashingCuttingDataProviderInstance.GetChallanDetailByOdId(odId, type, fabricname, printcolor);
        }

        public IicdPage GetChallanDetailByChallanId(int cid, int type)
        {
            return this.WashingCuttingDataProviderInstance.GetChallanDetailByChallanId(cid, type);
        }

        public int InsertChallanPage(IicdPage iicdPage)
        {
            return this.WashingCuttingDataProviderInstance.InsertChallanPage(iicdPage);
        }
        #endregion
    }
}
