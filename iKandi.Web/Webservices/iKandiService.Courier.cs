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

namespace iKandi.Web
{
    public partial class iKandiService
    {
        [WebMethod(EnableSession = true)]
        public List<string> SuggestCourierBuyer(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.CourierBuyer.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestCourierFabric(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.CourierFabric.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestCourierContact(string q, int limit)
        {
          List<string> sss=new List<string>();
            sss= SuggestForAutoComplete(q, AutoComplete.CourierContact.ToString(), limit);
            return sss;
        }        

        [WebMethod(EnableSession = true)]
        public List<string> SuggestCourierBuyerDepartment(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.CourierBuyerDepartment.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestCourierStyleNumber(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.CourierStyleNumber.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestCourierItem(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.CourierItem.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestCourierPurpose(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.CourierPurpose.ToString(), limit);
        }


        [WebMethod(EnableSession = true)]
        public List<string> SuggestCourierCompany(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.CourierCompany.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public Couriers GetAllCourier(DateTime courierDate, string searchKeyword, int type)//, int BHType)
        {
            Couriers couriers = this.CourierControllerInstance.GetAllCourierByDate(courierDate, searchKeyword, type);//, BHType);

            Courier blankRow = new Courier();
            blankRow.CourierID = -1;
            blankRow.SentByUserID = -1;

            couriers.Add(blankRow);

            return couriers;
        }
    }
}
