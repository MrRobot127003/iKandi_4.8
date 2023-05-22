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
        public List<string> SuggestPrintNumber(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.PrintNumber.ToString().ToUpper().Replace("PRD", "").Replace(":", "").Trim(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestPrintCompany(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.PrintCompany.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestSuggestPrintCompanyRef(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.PrintCompanyReference.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public Print GetPrintDetailByPrintNumber(string PrintNumber)
        {
            //System.Diagnostics.Debugger.Break();
            return this.PrintControllerInstance.GetPrintByPrintNumber(PrintNumber);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestPrintNumbers(string q, int limit, int clientId, int PrintCategory)
        {
            List<string> Results = new List<string>();
            // List<string> prd = SuggestForAutoComplete(q, AutoComplete.PrintNumbers.ToString(), limit);
            List<string> prd = SuggestForPrintNumberAutoComplete2(q, AutoComplete.PrintNumbers.ToString().ToUpper().Replace("PRD", "").Replace(":", "").Trim(), limit, clientId, PrintCategory);

            foreach (string p in prd)
            {
                Results.Add(p);
            }
            return Results;
        }

        // Adding new service for the color suggestion in design form by Bharat veer dated on 22 may 2019

        //[WebMethod(EnableSession = true)]
        //public List<string> SuggestColorforfabric_style(string q, int limit, int clientId, int PrintCategory)
        //{
        //    List<string> Results = new List<string>();
        //    // List<string> prd = SuggestForAutoComplete(q, AutoComplete.PrintNumbers.ToString(), limit);
        //    //List<string> prd = CommonControllerInstance(q, clientId, PrintCategory);

        //    List<string> prd = this.CommonControllerInstance.SuggestForColorAutoComplete2(q, clientId, PrintCategory);

        //    foreach (string p in prd)
        //    {
        //        Results.Add(p);
        //    }
        //    return Results;
        //}

      
        [WebMethod(EnableSession = true)]
        public List<string> SuggestPrintNumbers_ForMultiplePrints(string q, int limit, int clientId, string stno)
        {
            List<string> Results = new List<string>();
            //   List<string> prd = SuggestForAutoComplete(q, AutoComplete.PrintNumbers.ToString(), limit);
            List<string> prd = SuggestPrintNumbers_ForMultiplePrints2(q, AutoComplete.PrintNumbers.ToString().ToUpper().Replace("PRD", "").Replace(":", "").Trim(), limit, clientId, stno, 0);

            foreach (string p in prd)
            {
                Results.Add(p);
            }
            return Results;
        }
        
        [WebMethod(EnableSession = true)]
        public List<string> abc(string q, int limit)
        {
            List<string> Results = new List<string>();
            List<string> fabrics = SuggestForRegisteredTradeNamesAutoCompleteForOrder(q, limit);

            foreach (string fabric in fabrics)
            {
                Results.Add(fabric);
            }
            return Results;
        }

        // Yaten : Add new WebMethod for ForMultiplePrints 
        [WebMethod(EnableSession = true)]
        public List<string> SuggestPrintNumbers_ForMultiplePrintsStyleNumber(string q, int limit, int clientId, string stno)
        {
            List<string> Results = new List<string>();
            //  List<string> prd = SuggestForAutoComplete(q, AutoComplete.PrintNumbers.ToString(), limit);
            List<string> prd = SuggestPrintNumbers_ForMultiplePrintsStyleNumber2(q, AutoComplete.PrintNumbers.ToString().ToUpper().Replace("PRD", "").Replace(":", "").Trim(), limit, clientId, stno);

            foreach (string p in prd)
            {
                Results.Add(p);
            }
            return Results;
        }
        

        [WebMethod(EnableSession = true)]
        public string GetPrintImageUrlByPrintNumber(string PrintNumber)
        {
            string[] strTemp;

            if (PrintNumber.IndexOf(":") != -1)
            {
                strTemp = PrintNumber.Split(':');
                if (strTemp[1] != "" && strTemp != null)
                {
                    return this.PrintControllerInstance.GetPrintNumberByRefBAL(strTemp[1]);
                }
                else
                    return this.PrintControllerInstance.GetPrintImageUrlByPrintNumber(PrintNumber);
            }
            else
                return this.PrintControllerInstance.GetPrintImageUrlByPrintNumber(PrintNumber);
        }


        [WebMethod(EnableSession = true)]
        public string GetPrintNumberByRefWeb(string REFNumber)
        {
            return this.PrintControllerInstance.GetPrintNumberByRefBAL(REFNumber);
            // return "test";
        }


        [WebMethod(EnableSession = true)]
        public List<string> SuggestFabricQuality(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.FabricQuality.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestAllPrintNumbers(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.PrintNumbers.ToString().ToUpper().Replace("PRD", "").Replace(":", "").Trim(), limit);
        }

        //Gajendra New Costing
        [WebMethod(EnableSession = true)]
        public List<string> G2(string q, int limit)
        {
            List<string> Results = new List<string>();
            List<string> fabrics = GetFabricList_ByTradeName(q, limit);

            foreach (string fabric in fabrics)
            {
                Results.Add(fabric);
            }
            return Results;
        }
        
        [WebMethod(EnableSession = true)]
        public List<SamplePattern> Get_ClientDeptsParent(int ClientId, string type, int ParentDeptID)
        {
            return this.FITsControllerInstance.Get_ClientDeptsParent(ClientId, type, ParentDeptID);
        }
        //added by abhishek on 12/5/2017 without sort
        [WebMethod(EnableSession = true)]
        public List<string> G2_new(string q, int limit, string Print_Details, int PrintCategory, string StyleId)
        {
            List<string> Results = new List<string>();
            List<string> fabrics = GetFabricList_ByTradeName_newtubularAutoComp(q, limit, Print_Details, PrintCategory, StyleId);

            foreach (string fabric in fabrics)
            {
                Results.Add(fabric);
            }
            return Results;
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestPrintNumbers_ForMultiplePrints_New(string q, int limit, int clientId, string stno, int PrintCategory)
        {
            List<string> Results = new List<string>();
            //if (PrintCategory == 0)
            //    return Results;
            //else
            //{
                List<string> prd = SuggestPrintNumbers_ForMultiplePrints2(q, AutoComplete.PrintNumbers.ToString().ToUpper().Replace("PRD", "").Replace(":", "").Trim(), limit, clientId, stno, PrintCategory);

                foreach (string p in prd)
                {
                    Results.Add(p);
                }
                return Results;
            //}
        }
        //added on 07 Jan 2021 start
        [WebMethod(EnableSession = true)]
        public List<string> AutoComplete_Fabric_Pending_OrderSummary(string q, int limit, int clientId, string stno, int PrintCategory)
        {
            List<string> Results = new List<string>();

            List<string> str = AutoComplete_Fabric_Pending_OrderSummary1(q, AutoComplete.PrintNumbers.ToString().ToUpper().Replace("PRD", "").Replace(":", "").Trim(), limit, clientId, stno, PrintCategory);

                foreach (string p in str)
                {
                    Results.Add(p);
                }
                return Results;
            //}
        }
        //added on 07 Jan 2021 end

        //added on 27 Jan 2021 start
        [WebMethod(EnableSession = true)]
        public List<string> AutoComplete_Accessory_Pending_OrderSummary(string q, int limit, int clientId, string stno, int PrintCategory)
        {
            List<string> Results = new List<string>();

            List<string> str = AutoComplete_Accessory_Pending_OrderSummary1(q, AutoComplete.PrintNumbers.ToString().ToUpper().Replace("PRD", "").Replace(":", "").Trim(), limit, clientId, stno, PrintCategory);

            foreach (string p in str)
            {
                Results.Add(p);
            }
            return Results;
            //}
        }
        //added on 27 Jan 2021 end
        

        [WebMethod(EnableSession = true)]
        public string GetPrintImageUrlByPrintNumber_New(string PrintNumber)
        {
            string[] strTemp;

            if (PrintNumber.IndexOf(":") != -1)
            {
                strTemp = PrintNumber.Split(':');
                if (strTemp[1] != "" && strTemp != null)
                {
                    return this.PrintControllerInstance.GetPrintNumberByRefBAL_New(strTemp[1]);
                }
                else
                    return this.PrintControllerInstance.GetPrintImageUrlByPrintNumber_New(PrintNumber);
            }
            else
                return this.PrintControllerInstance.GetPrintImageUrlByPrintNumber_New(PrintNumber);
        }
        
        [WebMethod(EnableSession = true)]
        public string CheckPrintAlreadyExists(string PrintNumber, int printId)
        {
          return this.PrintControllerInstance.CheckPrintAlreadyExists(PrintNumber, printId);
          // return "test";
        }

    }
}
