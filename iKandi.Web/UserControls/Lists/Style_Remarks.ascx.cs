using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Web.Components;

namespace iKandi.Web.UserControls.Lists
{
    public partial class Style_Remarks : BaseUserControl
    {
        public int StyleId
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            GetRemarks();

        }

        public void GetRemarks()
        {
            string sComment = "";
            if (StyleId != -1)
            {
                sComment = StyleControllerInstance.GetStyleRemarks(StyleId);
                hdnStyleId.Value = StyleId.ToString();
                if (sComment != "")
                {
                    string Comment = "";
                    string[] ArrComment = sComment.Trim().Split('~');
                    if (ArrComment.Length > 0)
                    {
                        for (int i = 0; i < ArrComment.Length; i++)
                        {
                            Comment = Comment + ArrComment[i].Trim().ToString() + "</br>";
                        }
                        lblCommentShow.Text = Comment.ToString();
                    }
                }

            }
        }

    }
}