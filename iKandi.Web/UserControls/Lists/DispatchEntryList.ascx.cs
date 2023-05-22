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
using System.Collections.Generic;
using iKandi.Common;
using iKandi.Web.Components;



namespace iKandi.Web
{
    public partial class DispatchEntryList : BaseUserControl
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            //ddlUsers.DataSource = this.UserControllerInstance.GetAllUsers();
            //ddlUsers.DataBind();

            ddlUsers.DataSource = this.UserControllerInstance.GetAllUsersForCor();
            ddlUsers.DataBind();

            // Route to the Page level callback 'handler'
            this.HandleCallbacks();

            if (!IsPostBack)
            {
                //txtSentOnDate.Text = DateTime.Today.ToString("MM/dd/yyy");

                BindControls();

            }
        }



        protected void btnGo_Click(object sender, EventArgs e)
        {
            BindControls();
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
            if (callback == "savecourier")
                this.SaveData();
        }

        private void BindControls()
        { 
            //CourierController controller = new CourierController();
            //Couriers couriers = controller.GetAllCourierByDate(Convert.ToDateTime(txtSentOnDate.Text));

            //Courier blankRow = new Courier();
            //blankRow.CourierID = -1;
            //blankRow.SentByUserID = -1;
            //blankRow.ClientName = "UTK";

            //couriers.Add(blankRow);

            //blankRow = new Courier();
            //blankRow.CourierID = -1;
            //blankRow.SentByUserID = -1;

            //couriers.Add(blankRow);


            //blankRow = new Courier();
            //blankRow.CourierID = -1;
            //blankRow.SentByUserID = -1;

            //couriers.Add(blankRow);

            //  grdCourierDetails.DataSource = couriers;
            //  grdCourierDetails.DataBind();
        }

        public void SaveData()
        {
            int i = 1;

            if (!Request.Params.AllKeys.Contains<string>("contactName1"))
                return;

            DateTime dateSentOn = DateHelper.ParseDate(Request.Params["senton"]).Value;

            while (!string.IsNullOrEmpty(Request.Params["contactName" + i.ToString()]))
            {
                Courier courier = new Courier();
                iKandi.Common.SamplingStatus st = new iKandi.Common.SamplingStatus();
               // style.fabr
                string str = "";

                string f1 = Request.Params["fabrica" + i.ToString()].Trim(); //string f1 = st.Fab11;
                string f2 = Request.Params["fabricb" + i.ToString()].Trim(); //string f2 = st.Fab21;
                string f3 = Request.Params["fabricc" + i.ToString()].Trim();// string f3 = st.Fab31;
                string f4 = Request.Params["fabricd" + i.ToString()].Trim(); //string f4 = st.Fab41;
                string f5 = Request.Params["fabrice" + i.ToString()].Trim(); //string f4 = st.Fab41;
                string f6 = Request.Params["fabricf" + i.ToString()].Trim(); //string f4 = st.Fab41;

                if (f1 != "")
                    str += f1;
                if (f2 != "")
                    str += "#$#" + f2;
                if (f3 != "")
                    str += "#$#" + f3;
                if (f4 != "")
                    str += "#$#" + f4;
                if (f5 != "")
                    str += "#$#" + f5;
                if (f6 != "")
                    str += "#$#" + f6;

                string stringFab = str;
                //string stringFab = Request.Params["fabric1a" + i.ToString()] + Request.Params["fabric2" + i.ToString()] + Request.Params["fabric3" + i.ToString()] + Request.Params["fabric4" + i.ToString()];

                //string s2 = Request.Params["fabric2" + i.ToString()];

                //string s3 = Request.Params["fabric3" + i.ToString()];

                //string s4 = Request.Params["fabric4" + i.ToString()];
                  
                courier.ContactName = Request.Params["contactName" + i.ToString()];
                courier.ClientName = Request.Params["clientName" + i.ToString()];
                courier.CourierCompany = Request.Params["courierCompany" + i.ToString()];

                if (!string.IsNullOrEmpty(Request.Params["courierID" + i.ToString()]))
                    courier.CourierID = Convert.ToInt32(Request.Params["courierID" + i.ToString()]);
                else
                    courier.CourierID = -1;

                courier.CourierNumber = Request.Params["courierNumber" + i.ToString()];
                // TODO: date issue
                courier.CourierSentOn = dateSentOn;
                courier.Department = Request.Params["clientDepartment" + i.ToString()];
                if (Request.Params["SampleSent" + i.ToString()] == "")
                    courier.SampleSent = true;
                else
                    courier.SampleSent = false;

               // courier.Fabric = Request.Params["fabric" + i.ToString()];
                courier.Fabric = stringFab;
                courier.Item = Request.Params["item" + i.ToString()];
                courier.Purpose = Request.Params["purpose" + i.ToString()];
                courier.Quantity = Request.Params["quantity" + i.ToString()];
                courier.SentByUserID = Convert.ToInt32(Request.Params["sentByUserID" + i.ToString()]);
                courier.StyleNumber = Request.Params["styleNumber" + i.ToString()];

                if (courier.CourierID == -1) { this.CourierControllerInstance.InsertCourier(courier); }
                // 
                else
                { this.CourierControllerInstance.UpdateCourier(courier); }
                   // 

                i++;
            }

            // Must
            Response.End();
        }

        #endregion
    }
}