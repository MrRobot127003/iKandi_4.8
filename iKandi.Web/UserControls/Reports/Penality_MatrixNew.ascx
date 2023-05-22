<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Penality_MatrixNew.ascx.cs"
    Inherits="iKandi.Web.UserControls.Reports.Penality_MatrixNew" %>
<style type="text/css">
    body
    {
        background: #f9f9fa none repeat scroll 0 0;
        font-family: verdana;
    }
    table
    {
        font-family: verdana;
        border-color: gray;
    }
    th
    {
        background: #39589C;
        color: #fff;
        font-weight: normal;
        padding: 5px 0px;
        color: #98a9ca;
        font-family: arial,halvetica;
        font-size: 10px; 
        border-collapse:collapse;
        border:1px solid #98a9ca
    }
    table td
    {
        font-size: 11px;
        text-align: center;
        border-color: #aaa;
    }
    .per
    {
        color: blue;
    }
    .gray
    {
        color: gray;
    }
    h2
    {
        font-size: 16px;
        font-weight: bold;
        padding: 0px;
        margin: 0px;
    }
    .row-fir th
    {
        color: #98a9ca;
        font-family: arial,halvetica;
        font-size: 10px;
    }
    table td table td
    {
        border-color: #ddd;
    }
    .top-header
    {
        display: none;
    }
    .head-in-bottom
    {
        background: #eeeeee;
        font-weight:bold;
    }
  
</style>
<table cellpadding="0" cellspacing="0" width="1213" border="1" style="border-collapse: collapse;border-color:#98a9ca;">
    <thead>
        <tr>
            <th colspan="10">
                <h2>
                    Penalty Metrics
                </h2>
            </th>
        </tr>
        <tr class="row-fir">
            <th width="127" rowspan="2">
                Company
            </th>
            <th width="90" rowspan="2">
                Time
            </th>
            <%--<th style="display:none" colspan="4" valign="bottom">
               <div style="width:100%; border-bottom:1px solid"> Airing </div>
              
                Inspection Fail & Transport
            </th>--%>
          <!-- Increased the colspan here for new factory-->
            <th  colspan="4">
               <div style="width:100%; border-bottom:1px solid #98a9ca"> Total Penalty</div>
               
               <div style="width:100%; border-bottom:1px solid #98a9ca"> Shipped Value</div>
             
                %Age To shipped value
            </th>
            <!-- Increased the colspan here for new factory-->
            <th colspan="4">
                CTSL
            </th>
        </tr>
        <tr>
            <%--<th style="display:none" width="87">
                C 45-46
            </th>
            <th style="display:none" width="61">
                C 47
            </th>
            <th style="display:none" width="60">
                B 45
            </th>
            <th style="display:none" width="57">
                BIPL
            </th>--%>
            <th width="84">
                C 45-46
            </th>
            <th width="65">
                C 47
            </th>
            <!-- Added for new factory-->
          
           
            <!-- End of adding for new factory-->
            <th width="74">
                BIPL
            </th>
            <th width="101">
                C 45-46
            </th>
            <th width="91">
                C 47
            </th>
            <!-- Added for new factory-->
            <th width="101">
                D 169
            </th>
            <!-- End of adding for new factory-->
            <th width="109">
                BIPL
            </th>
        </tr>
    </thead>
</table>
<asp:GridView ID="gvPenalty_Matrix" runat="server" AutoGenerateColumns="false" Width="1213px"
    ShowFooter="true" ShowHeader="true" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
    HeaderStyle-CssClass="top-header" BorderColor="#dbddff" Style="border-collapse: collapse;
    padding: 0px; margin: 0px;" CellPadding="0">
    <Columns>
        <asp:TemplateField ItemStyle-Width="127" HeaderStyle-Width="127" HeaderStyle-CssClass="Unit-header"
            ItemStyle-CssClass="gray" FooterStyle-CssClass="gray" HeaderText="Company">
            <ItemTemplate>
                <%# Eval("CompanyName") %>
                <asp:HiddenField ID="hdnfClientID" runat="server" Value='<%# Eval("ClientId") %>' />
            </ItemTemplate>
            <FooterTemplate>
                <b>BIPL</b>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="90" HeaderStyle-Width="90" HeaderStyle-CssClass="Unit-header"
            ItemStyle-CssClass="gray" FooterStyle-CssClass="gray" HeaderText="Time">
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            1 Month
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            3 Month
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;">
                            Financial Year
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            1 Month
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            3 Month
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;">
                            Financial Year
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:TemplateField>
        <%--====================Airing============--%>
        <asp:TemplateField ItemStyle-Width="87" HeaderStyle-Width="87" ItemStyle-CssClass="hide-grid" FooterStyle-CssClass="hide-grid" HeaderStyle-CssClass="Unit-header hide-grid">
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray; vertical-align:top;">
                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                                    <asp:Label ID="lblAir_C45_46_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    <asp:Label ID="lblInsp_C45_46_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>                             
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray; vertical-align:top;">
                         <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">

                            <asp:Label ID="lblAir_C45_46_3Month" runat="server"></asp:Label>
                           </td>
                           </tr>
                           <tr>
                           <td>
                           <asp:Label ID="lblInsp_C45_46_3Month" runat="server"></asp:Label>
                           </td>
                           </tr>
                             </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px; vertical-align:top;">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                        <asp:Label ID="lblAir_C45_46_1Year" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                        <asp:Label ID="lblInsp_C45_46_1Year" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                        
                             
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                         <asp:Label ID="lblFAir_C45_46_1Week" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                        <asp:Label ID="lblFInsp_C45_46_1Week" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>                             
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray; vertical-align:top;">

                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                        <asp:Label ID="lblFAir_C45_46_3Month" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                        <asp:Label ID="lblFInsp_C45_46_3Month" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                    
                             
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;  vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                        <asp:Label ID="lblFAir_C45_46_1Year" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                        <asp:Label ID="lblFInsp_C45_46_1Year" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>

                             
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="61" HeaderStyle-Width="61" ItemStyle-CssClass="hide-grid" FooterStyle-CssClass="hide-grid" HeaderStyle-CssClass="Unit-header hide-grid">
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                        <asp:Label ID="lblAir_C47_1Week" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                         <asp:Label ID="lblInsp_C47_1Week" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>

                   
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                        <asp:Label ID="lblAir_C47_3Month" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                         <asp:Label ID="lblInsp_C47_3Month" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                      
                             
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;  vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                         <asp:Label ID="lblAir_C47_1Year" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                        <asp:Label ID="lblInsp_C47_1Year" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                   
                             
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                        <asp:Label ID="lblFAir_C47_1Week" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                        <asp:Label ID="lblFInsp_C47_1Week" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                        
                             
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                        <asp:Label ID="lblFAir_C47_3Month" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                         <asp:Label ID="lblFInsp_C47_3Month" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                   
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;  vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                        <asp:Label ID="lblFAir_C47_1Year" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                         <asp:Label ID="lblFInsp_C47_1Year" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                     
                            
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="60" HeaderStyle-Width="60" ItemStyle-CssClass="hide-grid" FooterStyle-CssClass="hide-grid" HeaderStyle-CssClass="Unit-header hide-grid hide-b-45" Visible="true">
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                        <asp:Label ID="lblAir_D169_1Week" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                        <asp:Label ID="lblInsp_D169_1Week" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                        
                             
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                        <asp:Label ID="lblAir_D169_3Month" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                         <asp:Label ID="lblInsp_D169_3Month" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                      
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                         <asp:Label ID="lblAir_D169_1Year" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                         <asp:Label ID="lblInsp_D169_1Year" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                     
                            
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                         <asp:Label ID="lblFAir_D169_1Week" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                         <asp:Label ID="lblFInsp_D169_1Week" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                       
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                         <asp:Label ID="lblFAir_D169_3Month" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                         <asp:Label ID="lblFInsp_D169_3Month" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                    
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                         <asp:Label ID="lblFAir_D169_1Year" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                        <asp:Label ID="lblFInsp_D169_1Year" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                       
                             
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="57" HeaderStyle-Width="57" ItemStyle-CssClass="hide-grid" FooterStyle-CssClass="hide-grid" HeaderStyle-CssClass="Unit-header hide-grid">
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                        <asp:Label ID="lblAir_BIPL_1Week" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                        <asp:Label ID="lblInsp_BIPL_1Week" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                      
                             
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                        <asp:Label ID="lblAir_BIPL_3Month" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                         <asp:Label ID="lblInsp_BIPL_3Month" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                    
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                        <asp:Label ID="lblAir_BIPL_1Year" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                         <asp:Label ID="lblInsp_BIPL_1Year" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                     
                            
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                        <asp:Label ID="lblFAir_BIPL_1Week" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                         <asp:Label ID="lblFInsp_BIPL_1Week" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                      
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                         <asp:Label ID="lblFAir_BIPL_3Month" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                        <asp:Label ID="lblFInsp_BIPL_3Month" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                       
                             
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px; vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td style="width:100%; height:23px; border-bottom:1px solid #dddddd; ">
                        <asp:Label ID="lblFAir_BIPL_1Year" runat="server"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                        <asp:Label ID="lblFInsp_BIPL_1Year" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>                   
                            
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:TemplateField>
        <%--=================Inspection============--%>
       
        <%--================TotalPenality==========--%>
        <asp:TemplateField ItemStyle-Width="84" HeaderStyle-Width="84" HeaderStyle-CssClass="Unit-header">
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblPlt_C45_46_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblShip_C45_46_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblPerc_C45_46_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblPlt_C45_46_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblShip_C45_46_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblPerc_C45_46_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblPlt_C45_46_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblShip_C45_46_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblPerc_C45_46_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFPlt_C45_46_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFShip_C45_46_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblFPerc_C45_46_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFPlt_C45_46_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFShip_C45_46_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblFPerc_C45_46_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFPlt_C45_46_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFShip_C45_46_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblFPerc_C45_46_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="65" HeaderStyle-Width="65" HeaderStyle-CssClass="Unit-header">
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblPlt_C47_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblShip_C47_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblPerc_C47_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblPlt_C47_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblShip_C47_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblPerc_C47_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblPlt_C47_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblShip_C47_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblPerc_C47_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFPlt_C47_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFShip_C47_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblFPerc_C47_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFPlt_C47_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFShip_C47_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblFPerc_C47_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFPlt_C47_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFShip_C47_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblFPerc_C47_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="67" HeaderStyle-Width="67" HeaderStyle-CssClass="Unit-header" >
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblPlt_D169_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblShip_D169_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblPerc_D169_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblPlt_D169_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblShip_D169_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblPerc_D169_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblPlt_D169_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblShip_D169_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblPerc_D169_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFPlt_D169_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFShip_D169_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblFPerc_D169_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFPlt_D169_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFShip_D169_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblFPerc_D169_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFPlt_D169_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFShip_D169_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblFPerc_D169_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="74" HeaderStyle-Width="74" HeaderStyle-CssClass="Unit-header">
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblPlt_BIPL_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblShip_BIPL_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblPerc_BIPL_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblPlt_BIPL_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblShip_BIPL_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblPerc_BIPL_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblPlt_BIPL_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblShip_BIPL_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblPerc_BIPL_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFPlt_BIPL_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFShip_BIPL_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblFPerc_BIPL_1Week" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFPlt_BIPL_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFShip_BIPL_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblFPerc_BIPL_3Month" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFPlt_BIPL_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px; border-bottom: 1px solid #dddddd;">
                                        <asp:Label ID="lblFShip_BIPL_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="per">
                                        <asp:Label ID="lblFPerc_BIPL_1Year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:TemplateField>
        <%--===================CTSL================--%>
        <asp:TemplateField ItemStyle-Width="101" HeaderStyle-Width="101" HeaderStyle-CssClass="Unit-header">
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            <asp:Label ID="lblCTSL_C45_46_1Week" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            <asp:Label ID="lblCTSL_C45_46_3Month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;">
                            <asp:Label ID="lblCTSL_C45_46_1Year" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            <asp:Label ID="lblFCTSL_C45_46_1Week" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            <asp:Label ID="lblFCTSL_C45_46_3Month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;">
                            <asp:Label ID="lblFCTSL_C45_46_1Year" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="91" HeaderStyle-Width="91" HeaderStyle-CssClass="Unit-header">
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            <asp:Label ID="lblCTSL_C47_1Week" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            <asp:Label ID="lblCTSL_C47_3Month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;">
                            <asp:Label ID="lblCTSL_C47_1Year" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            <asp:Label ID="lblFCTSL_C47_1Week" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            <asp:Label ID="lblFCTSL_C47_3Month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;">
                            <asp:Label ID="lblFCTSL_C47_1Year" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="101" HeaderStyle-Width="101" HeaderStyle-CssClass="Unit-header ">
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            <asp:Label ID="lblCTSL_D169_1Week" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            <asp:Label ID="lblCTSL_D169_3Month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;">
                            <asp:Label ID="lblCTSL_D169_1Year" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            <asp:Label ID="lblFCTSL_D169_1Week" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            <asp:Label ID="lblFCTSL_D169_3Month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;">
                            <asp:Label ID="lblFCTSL_D169_1Year" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="109" HeaderStyle-Width="109" HeaderStyle-CssClass="Unit-header">
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            <asp:Label ID="lblCTSL_BIPL_1Week" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            <asp:Label ID="lblCTSL_BIPL_3Month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;">
                            <asp:Label ID="lblCTSL_BIPL_1Year" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
                <table width="100%" cellpadding="0" cellspacing="0" class="bold" frame="void" rules="all">
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            <asp:Label ID="lblFCTSL_BIPL_1Week" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in" style="height: 47px; border-bottom: 1px solid gray;">
                            <asp:Label ID="lblFCTSL_BIPL_3Month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-in-bottom" style="height: 47px;">
                            <asp:Label ID="lblFCTSL_BIPL_1Year" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
