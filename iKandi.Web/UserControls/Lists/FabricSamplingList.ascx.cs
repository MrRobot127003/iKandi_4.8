using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.BLL;
using iKandi.Common;
using System.Collections.Generic;
using iKandi.Web.Components;


namespace iKandi.Web
{
    public partial class FabricSamplingList : BaseUserControl
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            // Route to the Page level callback 'handler'
            this.HandleCallbacks();

            if (!IsPostBack)
            {
                this.BindControls();
            }
        }

        #endregion

        #region Private Methods

        // Callback routing handler
        private void HandleCallbacks()
        {
            string callback = Request.Params["callback"];

            if (string.IsNullOrEmpty(callback))
                return;

            // *** We have an action try and match it to a handler
            if (callback == "savesamplingfabric")
                this.SaveData();
        }

        private void SaveData()
        {
            int i = 1;

            if (!Request.Params.AllKeys.Contains<string>("printNumber1"))
                return;

            while (!string.IsNullOrEmpty(Request.Params["printNumber" + i.ToString()]))
            {
                SamplingFabric fabric = new SamplingFabric();

                if (!string.IsNullOrEmpty(Request.Params["samplingFabricID" + i.ToString()]))
                    fabric.SamplingFabricID = Convert.ToInt32(Request.Params["samplingFabricID" + i.ToString()]);
                else
                    fabric.SamplingFabricID = -1;

                // Default
                fabric.IsNew = false;
                fabric.PrintNumber = Request.Params["printNumber" + i.ToString()];
                fabric.MillName = Request.Params["millName" + i.ToString()];
                fabric.MillDesignNumber = Request.Params["millDesignNumber" + i.ToString()];
                fabric.Fabric = Request.Params["fabric" + i.ToString()];
                fabric.PrintType = (PrintType)Convert.ToInt32(Request.Params["printTypeID" + i.ToString()]);
                fabric.PrintTechnology = (PrintTechnology)Convert.ToInt32(Request.Params["printTechnologyID" + i.ToString()]);
                if (!string.IsNullOrEmpty(Request.Params["quantityOrdered" + i.ToString()]))
                    fabric.QuantityOrdered = Convert.ToInt32(Request.Params["quantityOrdered" + i.ToString()]);
                if (!string.IsNullOrEmpty(Request.Params["quantityReceived" + i.ToString()]))
                    fabric.QuantityReceived = Convert.ToInt32(Request.Params["quantityReceived" + i.ToString()]);
                fabric.Origin = (Origin)Convert.ToInt32(Request.Params["originID" + i.ToString()]);
                if (!string.IsNullOrEmpty(Request.Params["numberOfScreens" + i.ToString()]))
                    fabric.NumberOfScreens = Convert.ToInt32(Request.Params["numberOfScreens" + i.ToString()]);
                if (!string.IsNullOrEmpty(Request.Params["costPerScreen" + i.ToString()]))
                    fabric.CostPerScreen = Convert.ToDouble(Request.Params["costPerScreen" + i.ToString()]);
                fabric.CostCurrency = (Currency)Convert.ToInt32(Request.Params["costCurrencyID" + i.ToString()]);
                fabric.Remarks = Request.Params["remarks" + i.ToString()];
                fabric.DateOfReceiving = DateHelper.ParseDate(Request.Params["dateOfReceiving" + i.ToString()]).Value;
                fabric.ExpectedIssueDate = DateHelper.ParseDate(Request.Params["expectedIssueDate" + i.ToString()]).Value;
                fabric.ActualIssueDate = DateHelper.ParseDate(Request.Params["actualIssueDate" + i.ToString()]).Value;
                fabric.ExpectedReceiptDate = DateHelper.ParseDate(Request.Params["ExpectedReceiptDate" + i.ToString()]).Value;
                fabric.ActualReceiptDate = DateHelper.ParseDate(Request.Params["actualReceiptDate" + i.ToString()]).Value;

                if (fabric.SamplingFabricID == -1)
                    this.FabricSmplingControllerInstance.InsertSamplingFabric(fabric);
                else
                    this.FabricSmplingControllerInstance.UpdateSamplingFabric(fabric);

                i++;
            }

            // Must
            Response.End();
        }


        private void BindControls()
        {


        }

        #endregion
    }
}