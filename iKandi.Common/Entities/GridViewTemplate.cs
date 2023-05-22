using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace iKandi.Common
{
  public class GridViewTemplate : ITemplate
  {

    //A variable to hold the column name.
    string _controlType;
    string _columnName;
    string _ID;
    string _Value;

    //Constructor where we define the template type and column name.
    public GridViewTemplate(string type, string colname, string id, string val = "")
    {
      //Stores the template type.
      _controlType = type;

      //Stores the column name.
      _columnName = colname;

      _ID = id;

      _Value = val;


    }


    void ITemplate.InstantiateIn(Control container)
    {

      switch (_controlType)
      {
        case "label":
          //Creates a new label control and add it to the container.
          Label lbl = new Label();
          lbl.ID = _columnName;
          container.Controls.Add(lbl);
          break;

        case "text":
          //Creates a new text box control and add it to the container.
          TextBox objtext = new TextBox();
          objtext.ID = _columnName;
          //objtext.Text = _columnName;
          container.Controls.Add(objtext);
          break;

        case "textmultiline":
          //Creates a new text box control and add it to the container.
          TextBox objmultiline = new TextBox();
          objmultiline.ID = _columnName;
          //objtext.Text = _columnName;
          objmultiline.TextMode = TextBoxMode.MultiLine;
          container.Controls.Add(objmultiline);
          break;


        case "textBox":
          //Creates a new text box control and add it to the container.
          HtmlInputText objTb = new HtmlInputText();
          objTb.ID = _columnName;
          objTb.Name = _columnName;
          container.Controls.Add(objTb);
          break;

        case "hidden":

          HtmlInputHidden objhid = new HtmlInputHidden();
          objhid.ID = _columnName;
          objhid.Name = _columnName;
          objhid.Name = _Value;
          container.Controls.Add(objhid);
          break;

        case "checkbox":

          CheckBox objchk = new CheckBox();
          objchk.ID = _columnName;
          //objchk.Name = _columnName;
          container.Controls.Add(objchk);
          break;

        case "file":

          FileUpload objFile = new FileUpload();
          objFile.ID = _columnName;
          //objchk.f = _columnName;
          container.Controls.Add(objFile);
          break;

        case "LinkButton":

          LinkButton objhyp = new LinkButton();
          objhyp.ID = _columnName;
          objhyp.Text = _columnName;
          //objhyp.CommandName = "insert"; 
          container.Controls.Add(objhyp);
          break;

        case "btn":

          Button objbtn = new Button();
          objbtn.ID = _columnName;
          objbtn.Text = _columnName;
          //objhyp.CommandName = "insert"; 
          container.Controls.Add(objbtn);
          break;

        case "img":

          Image objimg = new Image();
          objimg.ID = _columnName;
          objimg.ImageUrl = _columnName;
          //objhyp.CommandName = "insert"; 
          container.Controls.Add(objimg);
          break;

        case "imgbtn":

          ImageButton objimgbtn = new ImageButton();
          objimgbtn.ID = _columnName;
          objimgbtn.ImageUrl = _columnName;
          //objhyp.CommandName = "insert"; 
          container.Controls.Add(objimgbtn);
          break;


        case "Dropdown":

          DropDownList objDropdown = new DropDownList();
          objDropdown.ID = _columnName;           
          //objimg.ImageUrl = _columnName;
          //objhyp.CommandName = "insert"; 
          container.Controls.Add(objDropdown);
          break;

        case "AccessoryUnit":
            TextBox objtxtUnit = new TextBox();
            objtxtUnit.ID = _ID + "_TextBox_" + _Value;
            container.Controls.Add(objtxtUnit);

            DropDownList objDrp = new DropDownList();
            objDrp.ID = _ID + "_DropDown_" + _Value;
            container.Controls.Add(objDrp);
            break;

        case "itemimgbutton":

          ImageButton objitemimgbutton1 = new ImageButton();
          objitemimgbutton1.ID = _columnName + "1";
          objitemimgbutton1.ImageUrl = _columnName + "1";
          container.Controls.Add(objitemimgbutton1);

          ImageButton objitemimgbutton2 = new ImageButton();
          objitemimgbutton2.ID = _columnName + "2";
          objitemimgbutton2.ImageUrl = _columnName + "2";
          container.Controls.Add(objitemimgbutton2);
          break;

        case "itemtext":

          TextBox objitemtext = new TextBox();
          objitemtext.ID = _columnName + "1";
          container.Controls.Add(objitemtext);

          HiddenField objitemHidden = new HiddenField();
          objitemHidden.ID = _columnName + "2";
          container.Controls.Add(objitemHidden);
          break;

        case "itemlablehdn":

          Label objitemlable = new Label();
          objitemlable.ID = _columnName + "1";
          container.Controls.Add(objitemlable);

          HiddenField objitemHiddenlbl = new HiddenField();
          objitemHiddenlbl.ID = _columnName + "2";
          container.Controls.Add(objitemHiddenlbl);
          break;

        case "itemCheckboxhdn":

          CheckBox objitemchk = new CheckBox();
          objitemchk.ID = _columnName + "1";
          container.Controls.Add(objitemchk);

          HiddenField objitemHiddenchk = new HiddenField();
          objitemHiddenchk.ID = _columnName + "2";
          container.Controls.Add(objitemHiddenchk);
          break;

        case "textlable":

          TextBox objtextlbl = new TextBox();
          objtextlbl.ID = _columnName + "1";
          container.Controls.Add(objtextlbl);

          Label objlabletxt = new Label();
          objlabletxt.ID = _columnName + "2";
          container.Controls.Add(objlabletxt);

          HiddenField objHiddenlbl = new HiddenField();
          objHiddenlbl.ID = _columnName + "3";
          container.Controls.Add(objHiddenlbl);
          break;

        case "Headerth":

          //Label objlbl = new Label();
          //objlbl.ID = "lbl_" + _Value;
          //objlbl.Text = _columnName;
          //container.Controls.Add(objlbl);

          TextBox objtxt = new TextBox();
          objtxt.ID = _ID + "_" + _Value;
          container.Controls.Add(objtxt);

          //HiddenField objhdnAccMasterId = new HiddenField();
          //objhdnAccMasterId.ID = "hdn_" + _Value;
          //objhdnAccMasterId.Value = _Value;
          //container.Controls.Add(objhdnAccMasterId);

          break;

        case "iteamlable":

          Label lbl1 = new Label();
          lbl1.ID = _columnName + "1"; ;
          lbl1.Text = _Value;
          container.Controls.Add(lbl1);

          Label lbl2 = new Label();
          lbl2.ID = _columnName + "2"; ;
          lbl2.Text = _Value;
          container.Controls.Add(lbl2);

          Label lbl3 = new Label();
          lbl3.ID = _columnName + "3"; ;
          lbl3.Text = _Value;
          container.Controls.Add(lbl3);

          HiddenField hdnAccMasterId = new HiddenField();
          hdnAccMasterId.ID = _columnName + "4";
          hdnAccMasterId.Value = _Value;
          container.Controls.Add(hdnAccMasterId);

          Label lbl4 = new Label();
          lbl4.ID = _columnName + "5"; ;
          lbl4.Text = _Value;
          container.Controls.Add(lbl4);

          break;

      }
    }

  }
}
