<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionPlanning.aspx.cs" Inherits="iKandi.Web.Internal.Production.ProductionPlanning" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register src="../../UserControls/Reports/frmProductionMatrix.ascx" tagname="frmProductionMatrix" tagprefix="uc1" %>

<%@ Register src="~/UserControls/Forms/ProductionPlanningMatrix.ascx" tagname="ProductionPlanningMatrix" tagprefix="ProductionPlanningMatrix" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" type="text/css" href="../../App_Themes/ikandi/ikandi1.css" />
    <style type="text/css">
        body
        {
            font-size:11px;
            font-family: Arial;
        }
    h2
    {
        color: #98a9ca !important;
    font-family: Arial,sans-serif;
    font-size: 11px;
    padding:10px 0px;
    background-color: #39589c;
    text-transform: capitalize !important;
    width:100%;    
    text-align:center;
    }
  
    .item_list th
    {
    background-color: #e9e9e9 !important;
    color: #575759 !important;
    font-size: 10px !important;
    font-weight: normal;
    line-height: 15px;
    text-align: left;
    padding: 5px 0px !important;
    height: auto;text-transform: capitalize !important;
    }
    .item_list td span
    {
        color:Blue;
        font-size:9px;
        text-transform: capitalize !important;
    }
        .item_list td 
    {
        font-size:9px;
        text-transform: capitalize !important;
        border-color:Gray;
       border-color: #c1c0c099 !important;
        padding: 2px !important;
    }
    .align-left
    {
        text-align:left !important;
    }
    .align-center
    {
         text-align:center !important;
    }
    .TotalBackColor td
    {
        background-color:#e9e9e9 !important;
        font-size:10px;
        font-weight:bold;
        color:Gray;
        text-align:center;
        vertical-align:middle;
        font-family:Arial;
        border-color: #c1c0c099 !important;
    }
     .item_list td:first-child
        {
                border-left-color: #a9a4a4 !important;
        }
        .item_list td:last-child
        {
                border-right-color: #a9a4a4 !important;
        }
        .item_list tr:last-child > td
        {
                border-bottom-color: #d2cfcf !important;
        }
       
    </style>
     <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
      <script type="text/javascript" src="../../js/service.min.js"></script>
 <script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>  
 
    <script type="text/javascript">
        function ChangeLineFrame(obj) {
            //debugger;
            var LinePlanframeId = obj.value;        
            $(".LineFrame").val(LinePlanframeId);         
            
        }

    </script>
</head>
<body>
    <form id="form1" runat="server" style="width:99%">
    <asp:ScriptManager ID="sm" runat="server" enablepagemethods="true" AsyncPostBackTimeOut="600" >
    </asp:ScriptManager>   
   
    <div>
      <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server"><ContentTemplate>
     <div style="text-align: center; padding-left:5px; width:100%; text-transform: capitalize;">
     
                          <div style="text-align: center; padding:5px 0px; background-color: #405D99;
                                color: #FFFFFF; font-weight: bold; font-family:Verdana; width:100%;">
      <div style="float:left; margin-left:10px; width:auto;">
      <span style="font-weight: bold;">Style Code </span> <asp:Label ID="lblStylecode"
                                    runat="server" ForeColor="#f5f5f5"></asp:Label>                            
      </div>
                                Production Planning
                            
                            <div style="float:right; margin-right:10px; width:auto;">
                                <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" style="padding:0px;" Text="Close" Width="86px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
                          </div> 
                          <div style="clear:both;"></div>
    </div>
    <br />

        <table cellpadding="0" cellspacing="0" border="1" style="width:400px;" class="item_list">
            <tr>
                <th width="300px" style="padding-left:2px;">
                    Total quantity on order
                </th>
                <td style="border: 1px solid #bdbdbd;">
                    <asp:Label ID="lblqtyorder" Font-Bold="true" Font-Size="10px" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th style="padding-left:2px;">
                    Total quantity Shipped
                </th>
                <td style="border: 1px solid #bdbdbd;">
                    <asp:Label ID="lblshipedqty" Font-Bold="true" Font-Size="10px" runat="server"></asp:Label>
                </td>
            </tr>
       
        </table>       
     <uc1:frmProductionMatrix ID="frmProductionMatrix1" runat="server" />
          <%--  <asp:GridView ID="gvPending" AutoGenerateColumns="false" CssClass="item_list" 
                runat="server" onrowdatabound="gvPending_RowDataBound" HeaderStyle-HorizontalAlign="Center" 
                              style="min-width:400px; width:auto;" ondatabound="gvPending_DataBound">
            <Columns> 
            <%-- Column 0--%>        
            <%-- <asp:TemplateField HeaderStyle-Width="90px" HeaderText="Style No." ItemStyle-Font-Size="10px" ItemStyle-Width="90px">                
                    <ItemTemplate>
                        <asp:Label ID="lblStyleNo" runat="server" Text='<%# Eval("StyleNumber") %>' ForeColor="Gray"></asp:Label>
                        <asp:HiddenField ID="hdnStyleId" Value='<%# Eval("StyleId") %>' runat="server" />
                    </ItemTemplate> 
                    <ItemStyle VerticalAlign="Top" CssClass="align-left" />  
                    <HeaderStyle CssClass="align-center" />                                
                </asp:TemplateField> --%>

            <%-- Column 1--%>             
                <%--<asp:TemplateField HeaderStyle-Width="175px" HeaderText="Sealing Status" ItemStyle-Width="150px">               
                    <ItemTemplate>
                        <asp:Label ID="lblFitsStatus" ForeColor="Black" runat="server" Text='<%# Eval("FitsStatus") %>'></asp:Label>
                        <asp:HiddenField ID="hdnDetail" Value='<%# Eval("Detail") %>' runat="server" />
                    </ItemTemplate> 
                    <ItemStyle VerticalAlign="Top" CssClass="align-left" />    
                    <HeaderStyle CssClass="align-center" />                            
                </asp:TemplateField> 
--%>
                <%-- Column 2--%>
              <%--  <asp:TemplateField HeaderStyle-Width="65px" ItemStyle-Width="65px" HeaderStyle-CssClass="align-center">              
                    <ItemTemplate>                      
                    </ItemTemplate>                   
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> 
--%>
                <%-- Column 3--%>
               <%-- <asp:TemplateField HeaderStyle-Width="65px" ItemStyle-Width="65px" HeaderStyle-CssClass="align-center">              
                    <ItemTemplate>                       
                    </ItemTemplate>                 
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> 
--%>
                <%-- Column 4--%>
        <%--        <asp:TemplateField HeaderStyle-Width="65px" ItemStyle-Width="65px" HeaderStyle-CssClass="align-center">             
                    <ItemTemplate>                        
                    </ItemTemplate>                  
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> --%>

                <%-- Column 5--%>
                <%--<asp:TemplateField HeaderStyle-Width="65px" ItemStyle-Width="65px" HeaderStyle-CssClass="align-center">                
                    <ItemTemplate>                      
                    </ItemTemplate>                    
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> --%>

                <%-- Column 6--%>
               <%-- <asp:TemplateField HeaderStyle-Width="65px" ItemStyle-Width="65px" HeaderStyle-CssClass="align-center">             
                    <ItemTemplate>                        
                    </ItemTemplate>                    
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> --%>

                <%-- Column 7--%>
       <%--         <asp:TemplateField HeaderStyle-Width="65px" ItemStyle-Width="65px" HeaderStyle-CssClass="align-center">              
                    <ItemTemplate>                       
                    </ItemTemplate>                   
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> --%>

                <%-- Column 8--%>
                <%--<asp:TemplateField HeaderStyle-Width="65px" ItemStyle-Width="65px" HeaderStyle-CssClass="align-center">            
                    <ItemTemplate>                       
                    </ItemTemplate>                    
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> --%>

                <%-- Column 9--%>
               <%-- <asp:TemplateField HeaderStyle-Width="65px" ItemStyle-Width="65px" HeaderStyle-CssClass="align-center">              
                    <ItemTemplate>                      
                    </ItemTemplate>                   
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> --%>

                <%-- Column 10--%>
               <%-- <asp:TemplateField HeaderStyle-Width="65px" ItemStyle-Width="65px" HeaderStyle-CssClass="align-center">            
                    <ItemTemplate>                       
                    </ItemTemplate>                    
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> --%>

                 <%-- Column 11--%>
              <%--  <asp:TemplateField HeaderStyle-Width="65px" ItemStyle-Width="65px" HeaderStyle-CssClass="align-center">              
                    <ItemTemplate>                       
                    </ItemTemplate>                   
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> --%>

                 <%-- Column 12--%>
         <%--       <asp:TemplateField HeaderStyle-Width="68px" ItemStyle-Width="68px" HeaderStyle-CssClass="align-center">              
                    <ItemTemplate>                      
                    </ItemTemplate>                   
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField>  --%>            
                
                <%-- Column 13--%>
                <%-- <asp:TemplateField HeaderStyle-Width="70px" HeaderStyle-Font-Bold="true"  ItemStyle-Width="70px" HeaderStyle-CssClass="align-center">              
                    <ItemTemplate>                       
                    </ItemTemplate>                  
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField>

                </Columns>
            </asp:GridView>--%>

            <div>&nbsp;</div>
        
          <div style="text-align:right; padding-right:20px; text-transform:capitalize;">
              <span id="dvLinePlanFrame" visible="false" runat="server" style="padding:4px; border:1px solid gray; text-transform:capitalize;">
                  <asp:Label ID="lblLinePlanFrame" runat="server" Text="Select Frame No."></asp:Label>&nbsp;&nbsp;<asp:DropDownList ID="ddlLinePlanFrame" onclick="javascript:ChangeLineFrame(this);" runat="server">
              </asp:DropDownList>
                
              </span>&nbsp;
              <asp:Button ID="btnShowMatrix" runat="server" Text="Show Matrix"  class="da_submit_button"  onclick="btnShowMatrix_Click" />
              <asp:Button ID="btnHideMatrix" runat="server" CssClass="da_submit_button" Visible="false" 
                  Text="Hide Matrix" onclick="btnHideMatrix_Click" />                  
              <asp:TextBox ID="txtLineFrame" CssClass="LineFrame" style="display:none;" Text="-1" runat="server"></asp:TextBox>
              <asp:Label ID="lblMessage" Font-Bold="true" Font-Size="12px" ForeColor="Red" runat="server" Text=""></asp:Label>
          </div>                 
    </div>
    <div class="DivMatrix">
        <asp:PlaceHolder ID="MatrixPlaceHolder" runat="server"></asp:PlaceHolder>
    </div>

     </ContentTemplate>
    </asp:UpdatePanel>
    <div style="text-align:center;">
              <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="modal">
                    <div class="center" style="removed:absolute; z-index:1; removed 50%;removed 50%;">
                        <img alt="" src="../../images/loading36.gif" />
                    </div>
                </div>
            </ProgressTemplate>
            </asp:UpdateProgress></div>
    </div>
    </form>
</body>
</html>
