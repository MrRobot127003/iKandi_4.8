using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data;

namespace iKandi.Web.UserControls.Lists
{
    public partial class MOETARemarks : BaseUserControl
    {
        public string Flag1
        {
            get;
            set;
        }
        public int OrderDetailId
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["Flag1"])
            {
                Flag1 = Request.QueryString["Flag1"].ToString();
            }
            if (null != Request.QueryString["OrderDetailId"])
            {
                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
            }

            if (!IsPostBack)
            {
                bindRemarks();
            }
        }

        //updated by abhishek on 8/9/2015
        public void bindRemarks()
        {
            int checkcomment = 0;

            string strRemarks = "";
            strRemarks = this.OrderControllerInstance.GetMoETARemarksAll(Flag1, OrderDetailId, out checkcomment);

            

            if (strRemarks != "")
            {
                string[] separators = { "`","$$" };
                string[] words = strRemarks.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                
            
                foreach (string word in words)
                {
                 // updated code by bharat 8-jan-19
                    string[] str = word.Split(':');
                    string str1 = "";
                    string str2 = "";
                    if (str.Length > 0)
                        str1 = str[0].ToString();
                    if (str.Length > 1)
                        str2 = str[1].ToString();

                    //int index = word.IndexOf(':');
                    //int lastindex = word.IndexOf(')');
                    //string first = word.Substring(0, index).Trim();
                    //string second = word.Substring(index + 1, lastindex).Trim();
                    litRemarks.Text = litRemarks.Text + "<span style='color:grey;'>" + str1 + "</span>"+"<span>" + str2 + "</span>" + "</br>";
                    //end
                }


            }

            if (checkcomment == 0)
            {
                if (Flag1 == "Technical")
                {
                    string strOrderComment = this.OrderControllerInstance.GetMoOrderComment(OrderDetailId);
                    if (strOrderComment != "")
                    {
                        string[] OrderSeparators = { "~" };
                        string[] Orderwords = strOrderComment.Split(OrderSeparators, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var Orderword in Orderwords)
                        {
                            litRemarks.Text = litRemarks.Text + "</br>" + "<span style='color:blue'>Order Remarks : </span>" + Orderword;
                            // litRemarks.Text = "<span style='color:red'>" +litRemarks.Text+ "</span>";
                        }
                    }
                }
            }
            
            //end abhishek

            // bCheckTechnical remarks=false
            //{
            //string strOrderComment = this.OrderControllerInstance.GetMoOrderComment(OrderDetailId);
            //if (strOrderComment != "")
            //{
            //    string[] OrderSeparators = { "~" };
            //    string[] Orderwords = strOrderComment.Split(OrderSeparators, StringSplitOptions.RemoveEmptyEntries);
            //    foreach (var Orderword in Orderwords)
            //    {
            //        litRemarks.Text = litRemarks.Text + "</br>" + "<span style='color:blue'>Order Remarks : </span>" + Orderword;
            //        litRemarks.Text = "<span style='color:red'>" + litRemarks.Text + "</span>";
            //    }
            //}
            //}
            //else
            //{

            //}

        }

        //end by abhishek 
    }
}