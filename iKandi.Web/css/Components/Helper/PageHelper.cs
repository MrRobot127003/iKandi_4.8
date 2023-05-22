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
using System.Collections.Generic;
using System.Text;
using System.Collections;
using iKandi.Common;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;

namespace iKandi.Web.Components
{
    public static class PageHelper
    {
        private static Dictionary<string, object> JScriptVariables
        {
            get
            {
                if (!HttpContext.Current.Items.Contains(Constants.JSCRIPT_VARIABLE_NAMES))
                    HttpContext.Current.Items[Constants.JSCRIPT_VARIABLE_NAMES] = new Dictionary<string, object>();

                return HttpContext.Current.Items[Constants.JSCRIPT_VARIABLE_NAMES] as Dictionary<string, object>;
            }
            set
            {
                HttpContext.Current.Items[Constants.JSCRIPT_VARIABLE_NAMES] = value;
            }
        }

        public static void AddJScriptVariable(string variableName, object value)
        {
            if (JScriptVariables.ContainsKey(variableName))
                throw new Exception("javascript variable name : " + variableName + " already exists in the JScriptVariable values in the HttpContext");

            JScriptVariables.Add(variableName, value);
        }

        public static void RemoveJScriptVariable(string variableName)
        {
            if (JScriptVariables.ContainsKey(variableName))
                JScriptVariables.Remove(variableName);
        }

        public static bool HasJScriptVariables
        {
            get { return JScriptVariables.Count > 0; }
        }

        public static void RegisterJScriptVariables(Page currentPage)
        {
            if (JScriptVariables.Count == 0)
                return;

            RegisterScriptHelper.RegisterStartupScript(currentPage, currentPage.GetType(), "JscriptPageVariables", GetRegisterJScriptVariableScripts(), true);
            HttpContext.Current.Items.Remove(Constants.JSCRIPT_VARIABLE_NAMES);
        }

        public static string GetRegisterJScriptVariableScripts()
        {
            if (JScriptVariables.Count == 0)
                return string.Empty;

            StringBuilder jscript = new StringBuilder();

            jscript.Append(@" 
                if (jscriptPageVariables == undefined)
                {
                        function JScriptPageVariables() { }
                        var jscriptPageVariables = JScriptPageVariables;
                }" + Environment.NewLine);

            foreach (string key in JScriptVariables.Keys)
            {
                string value = string.Empty;

                //if (JScriptVariables[key].GetType() == typeof(string))
                //    value = JScriptVariables[key].ToString() ; //value = "'" + JScriptVariables[key].ToString() + "'";
                //else if (JScriptVariables[key].GetType() == typeof(int))


                value = JScriptVariables[key].ToString();

                jscript.Append(@"if (jscriptPageVariables." + key + @" != undefined)
                {
                    if (jscriptPageVariables." + key + @" == " + value + @")
                        alert('Multiple JscriptPageVaribles error. New PropertyName = + " + key + @"');
                }" + Environment.NewLine);

                jscript.Append("jscriptPageVariables." + key + " = " + value + ";" + Environment.NewLine);

            }

            return jscript.ToString();
        }

        public static string GetControlHtml(string controlLocation, Dictionary<string, object> controlProperties)
        {
            // Create instance of the page control
            Page page = new Page();

            // Create instance of the user control
            UserControl userControl = (UserControl)page.LoadControl(controlLocation);
            userControl.EnableViewState = false; 


            Type viewControlType = userControl.GetType();
            PropertyInfo prop = null;

            if (controlProperties != null)
            {
                foreach (string key in controlProperties.Keys)
                {
                    prop = viewControlType.GetProperty(key);
                    if (prop != null)
                    {
                        prop.SetValue(userControl, controlProperties[key], null);
                    }
                    else
                    {
                        throw new Exception("View file: " + controlLocation + " does not have a public  " + key + " property");
                    }
                }
            }

            //Form control is mandatory on page control to process User Controls
            HtmlForm form = new HtmlForm();
            //Add user control to the form
            form.Controls.Add(userControl);

            //Add form to the page 
            page.Controls.Add(form);
            //page.Controls.Add(userControl);--Kuldeep rolled back athar's Change on 11 Aug'11
            DisableViewState(page);

            //Write the control Html to text writer
            StringWriter textWriter = new StringWriter();

            //execute page on server 
            HttpContext.Current.Server.Execute(page, textWriter, false);

            // Clean up code and return html

            return CleanHtml(textWriter.ToString());
        }

        public static string GetControlHtmlWithForm(string controlLocation, Dictionary<string, object> controlProperties)
        {
            // Create instance of the page control
            Page page = new Page();

            // Create instance of the user control
            UserControl userControl = (UserControl)page.LoadControl(controlLocation);
            userControl.EnableViewState = false;


            Type viewControlType = userControl.GetType();
            PropertyInfo prop = null;

            if (controlProperties != null)
            {
                foreach (string key in controlProperties.Keys)
                {
                    prop = viewControlType.GetProperty(key);
                    if (prop != null)
                    {
                        prop.SetValue(userControl, controlProperties[key], null);
                    }
                    else
                    {
                        throw new Exception("View file: " + controlLocation + " does not have a public  " + key + " property");
                    }
                }
            }

            //Form control is mandatory on page control to process User Controls
            HtmlForm form = new HtmlForm();
            //Add user control to the form
            form.Controls.Add(userControl);

            //Add form to the page 
            page.Controls.Add(form);
            //page.Controls.Add(userControl);--Kuldeep rolled back athar's Change on 11 Aug'11
            DisableViewState(page);

            //Write the control Html to text writer
            StringWriter textWriter = new StringWriter();

            //execute page on server 
            HttpContext.Current.Server.Execute(page, textWriter, false);

            // Clean up code and return html

            //return CleanHtml(textWriter.ToString());

            return textWriter.ToString();
        }

        public static string GetControlPrintableHtml(string controlLocation, Dictionary<string, object> controlProperties)
        {
            // Create instance of the page control
            Page page = new Page();

            // Create instance of the user control
            UserControl userControl = (UserControl)page.LoadControl(controlLocation);

            userControl.EnableViewState = false;


            Type viewControlType = userControl.GetType();
            PropertyInfo prop = null;

            if (controlProperties != null)
            {
                foreach (string key in controlProperties.Keys)
                {
                    prop = viewControlType.GetProperty(key);
                    if (prop != null)
                    {
                        prop.SetValue(userControl, controlProperties[key], null);
                    }
                    else
                    {
                        throw new Exception("View file: " + controlLocation + " does not have a public  " + key + " property");
                    }
                }
            }

            //Form control is mandatory on page control to process User Controls
            HtmlForm form = new HtmlForm();

            //Add user control to the form
            form.Controls.Add(userControl);

            //Add form to the page 
            page.Controls.Add(form);

            DisableViewState(page);

            //ReplaceControls(page);

            SetControlsReadonly(page);

            //Write the control Html to text writer
            StringWriter textWriter = new StringWriter();

            //execute page on server 
            HttpContext.Current.Server.Execute(page, textWriter, false);

            return (CleanHtml(textWriter.ToString()));

        }

        private static void ReplaceControls(Control control)
        {
            int i = 0;

            List<Control> list = new List<Control>();

            foreach (Control ctrl in control.Controls)
                list.Add(ctrl);

            foreach (Control ctrl in list)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    (ctrl as TextBox).Visible = false;
                    Label lbl = new Label();
                    lbl.Text = (ctrl as TextBox).Text;
                    //control.Controls[i++] = lbl;
                }
                i++;
                ReplaceControls(ctrl);
            }

        }

        #region Private Methods

        private static void SetControlsReadonly(System.Web.UI.Control master_control)
        {
            int i = 0;
            System.Web.UI.Control ctl = default(System.Web.UI.Control);
            System.Web.UI.Control ctl_new = default(System.Web.UI.Control);
            string textBuffer = null;

            //First thing is we step through all of the controls passed
            for (i = 0; i <= (master_control.Controls.Count - 1); i++)
            {
                ctl = master_control.Controls[i];

                if (ctl is System.Web.UI.WebControls.DropDownList)
                {
                    if (((System.Web.UI.WebControls.DropDownList)ctl).SelectedItem == null)
                    {
                        textBuffer = "";
                    }
                    else
                    {
                        textBuffer = ((System.Web.UI.WebControls.DropDownList)ctl).SelectedItem.Text;
                    }

                    ctl_new = new System.Web.UI.WebControls.Label();
                    ((System.Web.UI.WebControls.Label)ctl_new).Text = textBuffer;
                    ((System.Web.UI.WebControls.Label)ctl_new).CssClass = "breadpurple";

                    master_control.Controls.RemoveAt(i);
                    master_control.Controls.AddAt(i, ctl_new);
                }
                //CType(ctl, System.Web.UI.WebControls.DropDownList).Enabled = False

                else if (ctl is System.Web.UI.WebControls.TextBox)
                {
                    textBuffer = ((System.Web.UI.WebControls.TextBox)ctl).Text;
                    //textBuffer = textBuffer.Replace(Strings.Chr(13), "<br>");

                    ctl_new = new System.Web.UI.WebControls.Label();
                    ((System.Web.UI.WebControls.Label)ctl_new).Text = textBuffer;

                    master_control.Controls.RemoveAt(i);
                    master_control.Controls.AddAt(i, ctl_new);
                }

                //For the remaining types in this if check, we make a recursive call to step through
                // those particular controls
                else if (ctl is System.Web.UI.WebControls.CompareValidator | ctl is System.Web.UI.WebControls.CustomValidator | ctl is System.Web.UI.WebControls.RangeValidator | ctl is System.Web.UI.WebControls.RequiredFieldValidator)
                {
                    ctl_new = new System.Web.UI.WebControls.Label();

                    master_control.Controls.RemoveAt(i);
                    master_control.Controls.AddAt(i, ctl_new);
                }
                else if (ctl is System.Web.UI.WebControls.CheckBox)
                {
                    ((System.Web.UI.WebControls.CheckBox)ctl).Enabled = false;
                }
                else if (ctl is System.Web.UI.WebControls.Table)
                {
                    SetControlsReadonly(ctl);
                }
                else if (ctl is System.Web.UI.WebControls.TableRow)
                {
                    SetControlsReadonly(ctl);
                }
                else if (ctl is System.Web.UI.WebControls.TableCell)
                {
                    SetControlsReadonly(ctl);
                }
                else if (ctl is System.Web.UI.WebControls.CheckBoxList)
                {
                    ((System.Web.UI.WebControls.CheckBoxList)ctl).Enabled = false;
                }
                else if (ctl is System.Web.UI.WebControls.RadioButtonList)
                {
                    ((System.Web.UI.WebControls.RadioButtonList)ctl).Enabled = false;
                }

                SetControlsReadonly(ctl);
            }
        }

        /// <summary>
        /// Removes Form tags using Regular Expression
        /// </summary>
        private static string CleanHtml(string html)
        {
            return Regex.Replace(html, @"<[/]?(form)[^>]*?>", "", RegexOptions.IgnoreCase);
        }

        private static void DisableViewState(Control ctrl)
        {
            ctrl.EnableViewState = false;

            foreach (Control c in ctrl.Controls)
            {
                DisableViewState(c);
            }
        }

        #endregion

    }
}
