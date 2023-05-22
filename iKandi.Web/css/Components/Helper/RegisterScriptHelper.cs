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
    public class RegisterScriptHelper
    {
        private static readonly object ReflectionLock = new object();

        public static void RegisterClientScriptResource(Control control, Type type, string resourceName)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }
            if (control.Page == null)
            {
                throw new ArgumentException("The control must be on a page.", "control");
            }

            control.Page.ClientScript.RegisterClientScriptResource(type, resourceName);
        }

        public static void RegisterClientScriptBlock(Control control, Type type, string key, string script, bool addScriptTags)
        {
            control.Page.ClientScript.RegisterClientScriptBlock(type, key, script, addScriptTags);
        }

        public static void RegisterClientScriptBlock(Page page, Type type, string key, string script, bool addScriptTags)
        {
            page.ClientScript.RegisterClientScriptBlock(type, key, script, addScriptTags);
        }

        public static void RegisterStartupScript(Page page, Type type, string key, string script, bool addScriptTags)
        {
            if (page == null)
                throw new ArgumentNullException("page is null");

            page.ClientScript.RegisterStartupScript(type, key, script, addScriptTags);
        }

        public static void RegisterStartupScript(Control control, Type type, string key, string script, bool addScriptTags)
        {
            if (control == null)
                throw new ArgumentNullException("control is null");
            if (control.Page == null)
                throw new ArgumentException("The control must be on a page.", "control");

            control.Page.ClientScript.RegisterStartupScript(type, key, script, addScriptTags);
        }

        public static void RegisterOnSubmitStatement(Page page, Type pageType, string key, string script)
        {
            page.ClientScript.RegisterOnSubmitStatement(pageType, key, script);
        }

        public static void RegisterHiddenField(Page page, string hiddenFieldName, string hiddenFieldInitialValue)
        {
            //page.RegisterHiddenField(hiddenFieldName, hiddenFieldInitialValue);
            page.ClientScript.RegisterHiddenField(hiddenFieldName, hiddenFieldInitialValue);
        }

    }
}
