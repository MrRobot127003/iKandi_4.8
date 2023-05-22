using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using iKandi.BLL;

namespace iKandi.Web
{
    public partial class CustomError : System.Web.UI.Page
    {
        //protected Label errorMessage;

        protected void Page_Load(object sender, EventArgs e)
        {

            StringBuilder sblErrMessag = new StringBuilder();
            Exception appException = HttpContext.Current.Server.GetLastError();

            string[] queryStrings = HttpContext.Current.Request.Url.Query.Split(';');

            if (queryStrings.Length >= 2)
            {
                string errorCode = queryStrings[0].Substring(1);
                string url = queryStrings[1];

                switch (errorCode)
                {
                    case "403":
                        {
                            sblErrMessag.Append("HTTP Code 403: You are not allowed to view that page.<br />");
                            break;
                        }
                    case "404":
                        {
                            sblErrMessag.Append("HTTP Code 404: The page you requested cannot be found.<br />");

                            // Just return, do not send email
                            return;

                        }
                    case "408":
                        {
                            sblErrMessag.Append("HTTP Code 408: The request has timed out.<br />");
                            break;
                        }
                    case "500":
                        {
                            sblErrMessag.Append("HTTP Code 500: The server cannot fullfill your request.<br />");
                            break;
                        }
                    default:
                        {
                            sblErrMessag.Append("The server has experienced an error.<br />");
                            break;
                        }
                }
            }

            if (appException is HttpException)
            {
                var checkException = (HttpException) appException;
                switch (checkException.GetHttpCode())
                {
                    case 403:
                        {
                            sblErrMessag.Append("HTTP Code 403: You are not allowed to view that page.<br />");
                            break;
                        }
                    case 404:
                        {
                            sblErrMessag.Append("HTTP Code 404: The page you requested cannot be found.<br />");

                            // Just return, do not send email
                            return;

                        }
                    case 408:
                        {
                            sblErrMessag.Append("HTTP Code 408: The request has timed out.<br />");
                            break;
                        }
                    case 500:
                        {
                            sblErrMessag.Append("HTTP Code 500: The server cannot fullfill your request.<br />");
                            break;
                        }
                    default:
                        {
                            sblErrMessag.Append("The server has experienced an error.<br />");
                            break;
                        }
                }
            }


            if (appException != null)
            {
                sblErrMessag.Append("Source: " + appException.Source + "<br />");
                string strEx = "";

                Exception newException = appException;
                if (appException.GetBaseException() != null)
                {
                    newException = appException.GetBaseException();
                }
                if (appException.Message != null)
                {
                    strEx = appException.Message;
                }

                String completeErrorMessage =
                    String.Format(
                        "Message:{0}{1}{0}{0} Stack Trace:{0}{2}{0}{0} Request:{0}" + Request.Path + ", " +
                        Request.QueryString,
                        "<br/>", newException.Message, newException.GetBaseException().StackTrace);

                String pageErrorMessage = String.Format("Message: {1}{0} Request: {2} {1}Main Message----: {3}",
                                                        "<br/>", newException.Message,
                                                        Request.Path + ", " + Request.QueryString, strEx);
                sblErrMessag.Append(pageErrorMessage);

                var controller = new NotificationController();
                //controller.SendErrorEmail(completeErrorMessage);
            }
            sblErrMessag.Append(
                "<br /><br />Please contact System Administrator with error details. Click <a class='tdcontent' href='javascript:history.go(-1);'>here</a> to go back to previous page.");

            
            
            
            Server.ClearError();
        }
       
    }
}