using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls.Adapters;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Collections;


namespace iKandi.Common
{
    public class DropDownListAdapter : System.Web.UI.WebControls.Adapters.WebControlAdapter
    {

        public static readonly string OPTGROUPATTR = "OptionGroup";

        Dictionary<string, string> optionGroups = new Dictionary<string, string>();

        protected override void RenderContents(HtmlTextWriter writer)
        {
            DropDownList list = this.Control as DropDownList;

            string currentOptionGroup;
            List<string> renderedOptionGroups = new List<string>();

            foreach (ListItem item in list.Items)
            {
                string keyString = item.Value + item.Text;
                if (item.Attributes[OPTGROUPATTR] == null && !optionGroups.ContainsKey(keyString))
                {
                    RenderListItem(item, writer);
                }
                else
                {
                    if (item.Attributes[OPTGROUPATTR] != null)
                        currentOptionGroup = item.Attributes[OPTGROUPATTR];
                    else
                    {
                        currentOptionGroup = optionGroups[keyString];
                    }

                    if (renderedOptionGroups.Contains(currentOptionGroup))
                    {
                        RenderListItem(item, writer);
                    }
                    else
                    {
                        if (renderedOptionGroups.Count > 0)
                        {
                            RenderOptionGroupEndTag(writer);
                        }

                        RenderOptionGroupBeginTag(currentOptionGroup, writer);
                        renderedOptionGroups.Add(currentOptionGroup);

                        RenderListItem(item, writer);
                    }
                }
            }

            if (renderedOptionGroups.Count > 0)
            {
                RenderOptionGroupEndTag(writer);
            }
        }

        private void RenderOptionGroupBeginTag(string name, HtmlTextWriter writer)
        {
            writer.WriteBeginTag("optgroup");
            writer.WriteAttribute("label", name);
            writer.Write(HtmlTextWriter.TagRightChar);
            writer.WriteLine();
        }

        private void RenderOptionGroupEndTag(HtmlTextWriter writer)
        {
            writer.WriteEndTag("optgroup");
            writer.WriteLine();
        }

        private void RenderListItem(ListItem item, HtmlTextWriter writer)
        {

            this.Page.ClientScript.RegisterForEventValidation(this.Control.UniqueID, item.Value);

            writer.WriteBeginTag("option");
            writer.WriteAttribute("value", item.Value, true);

            if (item.Selected)
            {
                writer.WriteAttribute("selected", "selected", false);
            }

            foreach (string key in item.Attributes.Keys)
            {
                writer.WriteAttribute(key, item.Attributes[key]);
            }

            writer.Write(HtmlTextWriter.TagRightChar);
            HttpUtility.HtmlEncode(item.Text, writer);
            writer.WriteEndTag("option");
            writer.WriteLine();
        }

        //
        // Summary:
        //     Saves view state information for the control adapter.
        //
        // Returns:
        //     An System.Object that contains the adapter view state information as a System.Web.UI.StateBag.
        protected override object SaveAdapterViewState()
        {
            DropDownList list = this.Control as DropDownList;
            string currentOptionGroup;
            string keyString;

            foreach (ListItem item in list.Items)
            {
                if (item.Attributes[OPTGROUPATTR] != null)
                {
                    currentOptionGroup = item.Attributes[OPTGROUPATTR];
                    keyString = item.Value + item.Text;
                    optionGroups[keyString] = currentOptionGroup;
                }
            }


            return optionGroups;
        }


        //
        // Summary:
        //     Loads adapter view state information that was saved by System.Web.UI.Adapters.ControlAdapter.SaveAdapterViewState()
        //     during a previous request to the page where the control associated with this
        //     control adapter resides.
        //
        // Parameters:
        //   state:
        //     An System.Object that contains the adapter view state information as a System.Web.UI.StateBag.
        protected override void LoadAdapterViewState(object state)
        {

            optionGroups = state as Dictionary<string, string>;
        }

    }
}
