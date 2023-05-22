<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryForm.ascx.cs" Inherits="iKandi.Web.CategoryForm" %>

<style type="text/css">
    .style1
    {
        background: #f7f7f7;
        border: solid 1px #d7d7d7;
        padding: 5px;
        height: 29px;
    }
    
      .TextColor
    {
   
       color:#0088cc;
       text-transform:none;
       font:12px/14px Arial, Helvetica, sans-serif;
     
    }
    .ColorAndAlign
    {
    text-align:left;
    font:bold 14px/14px Arial, Helvetica, sans-serif;
    height:23px;
    background: #324e79;
    text-transform:none;
    color:#FFFFFF;
    width: 194px;
    }
      
</style>



<asp:Panel runat="server" ID="pnlForm">
<script type="text/javascript">



    function CatInValid() {
        //alert("keypress");
        $("#" + '<%=hfCatValid.ClientID%>').val("0");
        $("#" + '<%=btnSubmit.ClientID%>').attr("disabled", true);
    }

    function CheckCatValid() {
        if ($("#" + '<%=hfCatValid.ClientID%>').val() == "0") {
            alert("Category is not valid");
            return false;
        }
        return true;

    }

   

</script>

<div class="print-box">

<div class="client_form">
   <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <%--<td width="10" class="ColorAndAlign">&nbsp;</td>--%>
        <td width="1205" class="ColorAndAlign"><span class="da_h1"><b>&nbsp;New Category</b></span><span class="da_required_field"><b>(<span class="da_astrx_mand">*</span> Please fill all required fields)</b></span></td>
       <%-- <td width="13" class="ColorAndAlign">&nbsp;</td>--%>
      </tr>
    </table>
    <asp:HiddenField Value="1" runat="server" ID="hfCatValid" />
    <div class="form_box">
     <asp:Panel ID="pnlmain" runat="server">
        
        <div>
            <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0" style="margin:0px;">
            <tr class="td-sub_headings">
              <td width="7%" valign="bottom">Category Name<span class="da_astrx_mand">*</span></td>
              <td width="7%" valign="bottom">Category Code<span class="da_astrx_mand">*</span></td>
              <td width="8%" valign="bottom">Type</td>
              <td width="8%" valign="bottom">Parent Category</td>
              <td width="8%" valign="bottom">B.I.H Date</td>
              <td width="26%" valign="bottom"></td>
              
              </tr>
            <tr>
              <td class="style1"><asp:TextBox ID="tbCategoryName" CssClass="category-name client-company TextColor" runat="server" MaxLength="50" onpaste="return false;"></asp:TextBox>
                        <%--<div class="form_error da_error_msg">
                            <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" Display="Dynamic" ControlToValidate="tbCategoryName"
                                ErrorMessage="Category Name is required"></asp:RequiredFieldValidator></div>--%>
                                </td>
              <td class="style1"><asp:TextBox ID="tbCategoryCode" CssClass="TextColor" runat="server" MaxLength="3"></asp:TextBox>
                        <%--<div class="form_error da_error_msg">
                            <asp:RequiredFieldValidator ID="rqvCategoryCode" runat="server" Display="Dynamic" ControlToValidate="tbCategoryCode"
                                ErrorMessage="Category Code is required"></asp:RequiredFieldValidator></div>--%>
                                </td>
              <td class="style1"><asp:DropDownList ID="ddlCategoryType" CssClass="TextColor" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlCategoryType_SelectedIndexChanged"></asp:DropDownList></td>
              <td class="style1"><asp:DropDownList ID="ddlParentCategory" CssClass="input_in TextColor" runat="server"></asp:DropDownList></td>
             <td class="style1">
             <asp:DropDownList ID="ddlweeks" runat="server" CssClass="TextColor"></asp:DropDownList>
             <%--<asp:TextBox ID="txtWeeks" runat="server" CssClass="input_in"></asp:TextBox>--%>
             </td>
              </tr>
              <tr>
              <td>
              <asp:Label ID="lblmsg" runat="server"></asp:Label>
              </td>
              </tr>
            </table>
           
        </div>
        </asp:Panel>
    </div>
   </div>
  </div> 
    <div class="form_buttom">
        <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="da_submit_button submit" OnClick="Submit_Click" OnClientClick="JavaScript:return CheckCatValid();" />
         <input type="button" id="btnPrint" value="Print" class="da_submit_button"   onclick="return PrintPDF();" />
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
       <%-- <td width="10" class="da_table_heading_bg_left">&nbsp;</td>--%>
        <td width="1205" class="ColorAndAlign"><span class="da_h1">&nbsp; Confirmation</span></td>
        <%--<td width="13" class="da_table_heading_bg_right">&nbsp;</td>--%>
      </tr>
    </table>
    <div class="form_box">               
        <div class="text-content">
            Category have been saved into the system successfully!
            <br />
            <a id="A1" href="~/Admin/Categories/CategoryListing.aspx" runat="server">Click here</a> to Category List.</div>
        </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlError" Visible="false">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="10" class="da_table_heading_bg_left">&nbsp;</td>
        <td width="1205" class="da_table_heading_bg"><span class="da_h1"> Confirmation</span></td>
        <td width="13" class="da_table_heading_bg_right">&nbsp;</td>
      </tr>
    </table>
    <div class="form_box">
        <div class="text-content">
            Category has not been saved due to duplicate code or some error occurs into system while saving data!
            <br />
            <a id="A2" href="~/Admin/Categories/CategoryListing.aspx" runat="server">Click here</a> to Category List.</div>
        </div>
</asp:Panel>