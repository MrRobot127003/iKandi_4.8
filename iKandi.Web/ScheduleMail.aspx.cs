using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using iKandi.Common;
using iKandi.BLL;

namespace iKandi.Web
{
    public partial class ScheduleMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ExecuteProcess();
        }
        public void ExecuteProcess()
        {
            //ProcessEmails();
            iKandi.BLL.BackgroundProcessingController cc = new iKandi.BLL.BackgroundProcessingController();
            cc.ExecuteProcess();
            Response.Write("mail send sucessfully");
          
        }
    }
}