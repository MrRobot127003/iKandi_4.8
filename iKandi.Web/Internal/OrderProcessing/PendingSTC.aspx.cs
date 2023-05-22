using System;

namespace iKandi.Web
{
    public partial class PendingSTC : BasePage
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            // Route to the Page level callback 'handler'
            //this.HandleCallbacks();
        }

        #endregion

        //#region Private Methods

        //// Callback routing handler
        //private void HandleCallbacks()
        //{
        //    string callback = Request.Params["callback"];

        //    if (string.IsNullOrEmpty(callback))
        //        return;

        //    // *** We have an action try and match it to a handler
        //    if (callback == "savependingstc")
        //        this.SaveData();
        //}

        //private void SaveData()
        //{
        //    int i = 1;
        //    int styleID = -1;
        //    int clientDepartmentID = -1;

        //    if (!Request.Params.AllKeys.Contains<string>("styleID1"))
        //        return;

        //    while (!string.IsNullOrEmpty(Request.Params["styleID" + i.ToString()]))
        //    {
        //        if (!string.IsNullOrEmpty(Request.Params["styleID" + i.ToString()]))
        //            styleID = Convert.ToInt32(Request.Params["styleID" + i.ToString()]);
        //        else
        //            styleID = -1;

        //        if (!string.IsNullOrEmpty(Request.Params["clientDepartmentID" + i.ToString()]))
        //            clientDepartmentID = Convert.ToInt32(Request.Params["clientDepartmentID" + i.ToString()]);
        //        else
        //            clientDepartmentID = -1;

        //        string dateToday = DateTime.Today.ToString("dd MMM yy (ddd)");
        //        string sealerRemarksBIPL = Request.Params["sealerRemarksBIPL" + i.ToString()];
        //        string sealerRemarksiKandi = Request.Params["sealerRemarksiKandi" + i.ToString()];

        //        if (sealerRemarksBIPL.Trim() != string.Empty)
        //            sealerRemarksBIPL = dateToday + ": " + sealerRemarksBIPL;
        //        else
        //            sealerRemarksBIPL = string.Empty;

        //        if (sealerRemarksiKandi.Trim() != string.Empty)
        //            sealerRemarksiKandi = dateToday + ": " + sealerRemarksiKandi;
        //        else
        //            sealerRemarksiKandi = string.Empty;

        //        if (sealerRemarksBIPL.Trim() == string.Empty && sealerRemarksiKandi.Trim() == string.Empty)
        //        {
        //            i++;
        //            continue;
        //        }

        //        this.OrderControllerInstance.UpdateSealerRemarks(styleID, clientDepartmentID, sealerRemarksiKandi, sealerRemarksBIPL);

        //        i++;
        //    }

        //    // Must
        //    Response.End();
        //}


        //private void BindControls()
        //{


        //}

        //#endregion
    }
}