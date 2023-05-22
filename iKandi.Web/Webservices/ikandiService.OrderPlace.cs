using System;
using System.Web.Services;
using iKandi.BLL;
using System.Collections.Generic;
using iKandi.Common;
using iKandi.Web.Components;
using iKandi.Common.Entities;
using System.Data;
using System.Globalization;
using iKandi.BLL.CmtAdmin;
using iKandi.BLL.Production;


namespace iKandi.Web
{
    
    public partial class iKandiService
    {
        OrderPlaceController objOrderPlaceController = new OrderPlaceController();

        [WebMethod(EnableSession = true)]
        public List<string> SuggestStyleNumberForOrderPlace(string q, int limit)
        {
            List<string> allStyles = SuggestForAutoComplete(q, AutoComplete.StyleWithCosting.ToString(), limit);

            if (ApplicationHelper.LoggedInUser.UserData.Designation != Designation.BIPL_Sales_Manager)
            {
                List<string> styles = new List<string>();

                foreach (string style in allStyles)
                {
                    if (!style.Contains("$"))
                        styles.Add(style);
                }

                return styles;
            }
            return allStyles;
        }

        [WebMethod(EnableSession = true)]
        public int StyleExistForThisClient(int OrderId, string StyleNumber)
        {
            return objOrderPlaceController.StyleExistForThisClient(OrderId, StyleNumber);
        }

        [WebMethod(EnableSession = true)]
        public iKandi.Common.OrderPlace GetOrderInfoByStyleNumber(string StyleNumber)
        {
            return this.objOrderPlaceController.GetOrderInfoByStyleNumber(StyleNumber);
        }

        [WebMethod(EnableSession = true)]
        public List<OrderPlace> Get_modes_For_OrderPlace(bool IsikandiClient, int CostingId, int ClientId, int DepartmentID, int OrderDetailId)
        {
            return this.objOrderPlaceController.Get_modes_For_OrderPlace(IsikandiClient, CostingId, ClientId, DepartmentID, OrderDetailId);
        }

        [WebMethod(EnableSession = true)]
        public iKandi.Common.ContractDetails Get_ModeDetails_ByModeId(bool IsikandiClient, int CostingId, int ClientId, int DepartmentID, int ModeId)
        {
            return this.objOrderPlaceController.Get_ModeDetails_ByModeId(IsikandiClient, CostingId, ClientId, DepartmentID, ModeId);
        }

        [WebMethod(EnableSession = true)]
        public int OpenOrderForikandi(int OrderId, int IsClose)
        {
            return objOrderPlaceController.OpenOrderForikandi(OrderId, IsClose);
        }

        [WebMethod(EnableSession = true)]
        public List<string> GetAllPrintNumber(string q, int ClientId, int PrintCategory)
        {
            return objOrderPlaceController.GetAllPrintNumber(q, ClientId, PrintCategory);
            //List<string> Results = new List<string>();
            //if (PrintCategory == 1 || PrintCategory == 2)
            //    return objOrderPlaceController.GetAllPrintNumber(q, ClientId, PrintCategory);
            //else
            //{
            //    return Results;
            //}
        }

        //[WebMethod(EnableSession = true)]
        //public List<string> GetAllPrintNumberRow(string q, int PrintCategory)
        //{
        //    List<string> Results = new List<string>();
        //    if (PrintCategory == 1 || PrintCategory == 2)
        //        return objOrderPlaceController.GetAllPrintNumber(q, PrintCategory);
        //    else
        //    {
        //        return Results;
        //    }
        //}

        [WebMethod(EnableSession = true)]
        public int CheckAccessories(string searchValue)
        {
            return objOrderPlaceController.CheckAccessories(searchValue);
        }

        [WebMethod(EnableSession = true)]
        public string GetAccessoresPopup(int OrderId)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("orderid", OrderId);
            return PageHelper.GetControlHtml("~/UserControls/Lists/AccessoriesPopup.ascx", properties);
        }
        [WebMethod(EnableSession = true)]
        public List<ContractDetailSize> GetSizeSetDetails(int ClientId, int DeptId, int OptionId, int OrderDetailId)
        {
            return this.objOrderPlaceController.GetSizeSetDetails(ClientId, DeptId, OptionId, OrderDetailId);
        }

        [WebMethod(EnableSession = true)]
        public bool Insert_Update_OrderDetail_Size(int OrderDetailId, int SizeOption, string Size, int Singles, int RatioPack, int Ratio)
        {
            ContractDetailSize objOrderDetailSize = new ContractDetailSize();
            objOrderDetailSize.OrderDetailID = OrderDetailId;
            objOrderDetailSize.SizeOption = SizeOption;
            objOrderDetailSize.Size = Size;
            objOrderDetailSize.Singles = Singles;
            objOrderDetailSize.RatioPack = RatioPack;
            objOrderDetailSize.Ratio = Ratio;
            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

            return objOrderPlaceController.Insert_Update_OrderDetail_Size(objOrderDetailSize, UserId);
        }

        [WebMethod(EnableSession = true)]
        public List<OrderHistory> Get_Order_History(int OrderId, int Typeflag)
        {
            return this.objOrderPlaceController.Get_Order_History(OrderId, Typeflag);
        }

        //added by raghvinder on 07-12-2020 start
        [WebMethod(EnableSession = true)]
        public List<OrderOldHistoryComments> Get_Old_Order_History(int OrderId, int Typeflag, int Type)
        {
            return this.objOrderPlaceController.Get_Old_Order_History(OrderId, Typeflag, Type);
        }
        //added by raghvinder on 07-12-2020 end

        [WebMethod(EnableSession = true)]
        public bool Create_Order_Comment(int OrderId, string SerialNo, int TypeFlag, string Comment)
        {
            OrderComment objOrderComment = new OrderComment();
            objOrderComment.OrderId = OrderId;
            objOrderComment.SerialNumber = SerialNo;
            objOrderComment.TypeFlag = TypeFlag;            
            objOrderComment.Comment = Comment;
            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

            return objOrderPlaceController.Create_Order_Comment(objOrderComment, UserId);
        }

        [WebMethod(EnableSession = true)]
        public List<OrderComment> Get_Order_Comment(int OrderId, string SerialNo, int Typeflag)
        {
            return this.objOrderPlaceController.Get_Order_Comment(OrderId, SerialNo, Typeflag);
        }

        [WebMethod(EnableSession = true)]
        public List<ClientCountryCode> GetClientCountryCode(int ClientId)
        {
            return this.objOrderPlaceController.GetClientCountryCode(ClientId);
        }

        [WebMethod(EnableSession = true)]
        public List<DeliveryMode> GetLeadTime_Days_ByMode(int ModeID, string CountryCode)
        {
            return this.objOrderPlaceController.GetLeadTime_Days_ByMode(ModeID, CountryCode);
        }

        [WebMethod(EnableSession = true)]
        public List<AccessoryPending> GetOrderAccesoryHistory(int OrderId)
        {
            return this.objOrderPlaceController.GetOrderAccesoryHistory(OrderId);

        }
    }
}
