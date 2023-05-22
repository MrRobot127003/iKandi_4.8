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

namespace iKandi.Web.Components
{
    public class DateHelper
    {
        public static DateTime? ParseDate(string date)
        {
            if (string.IsNullOrEmpty(date))
                return System.Data.SqlTypes.SqlDateTime.MinValue.Value;// DateTime.Parse("1/1/1957");
               // return DateTime.MinValue;

            try
            {
                return DateTime.ParseExact(date.Trim(), "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                try
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    return DateTime.ParseExact(date.Trim(), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    
                }
                catch (Exception ex1)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex1.Message, ex.StackTrace));
                    return DateTime.MinValue;
                }
            }
        }

        public static string GetNextMondayDate()
        {
            string strNextMondayDate = string.Empty;

            switch (DateTime.Today.DayOfWeek.ToString().ToLower())
            {
                case "monday":
                    strNextMondayDate = DateTime.Today.AddDays(7).ToString("dd MMM yy (ddd)");
                    break;

                case "tuesday":
                    strNextMondayDate = DateTime.Today.AddDays(6).ToString("dd MMM yy (ddd)");
                    break;

                case "wednesday":
                    strNextMondayDate = DateTime.Today.AddDays(5).ToString("dd MMM yy (ddd)");
                    break;

                case "thursday":
                    strNextMondayDate = DateTime.Today.AddDays(4).ToString("dd MMM yy (ddd)");
                    break;

                case "friday":
                    strNextMondayDate = DateTime.Today.AddDays(3).ToString("dd MMM yy (ddd)");
                    break;

                case "saturday":
                    strNextMondayDate = DateTime.Today.AddDays(2).ToString("dd MMM yy (ddd)");
                    break;

                case "sunday":
                    strNextMondayDate = DateTime.Today.AddDays(1).ToString("dd MMM yy (ddd)");
                    break;
            }

            return strNextMondayDate;
        }
        
      //Added by abhishek convert any format to sql specific
        private static DateTime ConvertToDateTime(string strDateTime,string[] Chars)
        {
          try
          {
            //string[] con = confirmValue.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            DateTime dtFinaldate; string sDateTime;
            string[] sDate = strDateTime.Split(Chars, StringSplitOptions.RemoveEmptyEntries);
            sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
            dtFinaldate = Convert.ToDateTime(sDateTime);
            return dtFinaldate;
          }
          catch (Exception ex)
          {
            try
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
              return DateTime.ParseExact(strDateTime.Trim(), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex1)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex1.Message, ex.StackTrace));
              return DateTime.MinValue;
            }
          }
        }
    }
}
