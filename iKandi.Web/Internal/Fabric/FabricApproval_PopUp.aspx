<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricApproval_PopUp.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.FabricApproval_PopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fabric Approval</title>
    <link href="../../App_Themes/ikandi/ikandi1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
      body{text-transform:capitalize !important; font-family: arial; font-size: 12px;
    font-weight: bold;} 
      .pop-head
      {
         background: #3a5795; padding: 5px 0px; color: #fff; margin:0px;
         margin:0px;
         font-family:Arial;
         font-size:14px;
         text-align:center; 
      } 
      .drop-dwn
      {
          line-height:25px;
          padding:0px 10px;
          font-size:11px;
      }
       .drop-dwn td span
       {
   color: Blue;
    font-size: 11px;
    font-weight: bold;
    font-family: arial;
       }
     span
       {
  
    font-size: 12px;
    font-weight: bold;
    font-family: arial;
       }
        .drop-dwn td select
        {
            color:Blue;
            text-transform:capitalize;
        }
        .form_heading
        {
    text-align: center;
    font-size: 12px;
    margin-top: 5px;
    padding-bottom: 5px;
    border-bottom: 7px solid #000000;
     color: #000; 
        }
     #lblRemarks span
     {
         font-size:10px;
     }
     #ui-datepicker-div
     {
         display:none;
     }
     
    </style>
   <%-- <script src="../../js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function showHide(prmThis) {
            debugger;
            var isExpanded = false;
            if (isExpanded == false) {

                $("#divHistory").show();

                isExpanded = true;
                $(prmThis).html("Collapse");
            }
            else {
                $("#divHistory").hide();
                isExpanded = false;
                $(prmThis).html("View Remarks");
            }
        }
    
    </script>--%>

    <script src="../../js/Calender_new.js" type="text/javascript"></script>
<script src="../../js/Calender_new2.js" type="text/javascript"></script>
<%--abhishek --%>
    <script type="text/javascript">

        $(function () {
            $(".th").datepicker({ dateFormat: 'dd M y (D)' });

            $('.th').focus(function () {
                $(this).val('')
            });
        });

        function Validation() {

        }

       
  </script>
</head>
<body>
    <form id="form1" runat="server" style="margin-top:0px;">
    <div style ="width:99.6%; margin:0px auto;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
         <h2 style=""  class="pop-head">
        Fabric Approval For <asp:Literal ID="ltrlfabricname" runat="server"></asp:Literal></h2>
        <div style="border:1px solid grey;">
            <div id="DivFabricSection_1" runat="server" visible ="false">
       
            
                <%--<asp:CheckBox ID="chkQualityApproved_1" runat="server" Text="Fabric QTY Aprd" />--%>
                <table width="100%" cellpadding="0" cellspacing="0" class="drop-dwn">


                <tr>
                <td>
                 Color/Print Ref. Received
                 </td>
                  <td>
                 <asp:Label ID="lblrefupdateddate_1" runat="server" Text="" style="font-size:11px;"></asp:Label>
                </td>
                <td>
                 <asp:TextBox ID="txtprintqnty1" Width="63px" height="15px" runat="server" class="th" 
                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                </td>

                <td>
                 <asp:CheckBox ID="chkREFReceived_1" runat="server" Text="" />
                </td>
                
                </tr>
                    <tr>
                        <td class="my-readmore-css-class">

                            Fabric Quality Approved
                            </td>
                            <td>
                            <asp:Label ID="lblQualityupdatedate_1"  runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                             <asp:TextBox ID="TxtFabricqty1"  Width="63px" height="15px" runat="server" class="th" 
                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td width="120px">
                            <asp:UpdatePanel ID="UpdatePanelddlQtyApvd_1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlQtyApvd_1" AutoPostBack="true" runat="server" Enabled="true"
                                        Style="width: 95%" OnSelectedIndexChanged="ddlQtyApvd_1_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <%-- <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlQtyApvd_1" />
                                                        </Triggers>--%>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Initial Approved
                            </td>
                            <td>
                            <asp:Label ID="lblinitialupdatedate_1" runat="server" Text=""></asp:Label>
                             </td>
                            <td>
                            <asp:TextBox ID="txtInitial1" Width="63px" Height="15px" runat="server" class="th"
                                Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanelddlinitial_1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlinitial_1" AutoPostBack="true" runat="server" Enabled="false"
                                        Style="width: 95%" OnSelectedIndexChanged="ddlinitial_1_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlinitial_1" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Bulk Approved
                            </td>
                            <td>
                            <asp:Label ID="lblBulkupdatedate_1" runat="server" Text=""></asp:Label>
                             </td>
                            <td>
                            <asp:TextBox ID="txtbulk1" Width="63px" Height="15px" runat="server" class="th" Style="font-size: 8px !important;
                                text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlbulkApvd_1" runat="server" AutoPostBack="true" Enabled="false"
                                        Style="width: 95%">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlbulkApvd_1" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>

            <div id="DivFabricSection_2" runat="server" visible="false">
               
                <%--<asp:CheckBox ID="chkQualityApproved_2" runat="server" />--%>
                <table width="100%" cellpadding="0" cellspacing="0" class="drop-dwn">

                <tr>
                <td>
                Color/Print Ref. Received
                </td>

                <td> 
                 <asp:Label ID="lblrefupdateddate_2" runat="server" Text="" Style="font-size: 11px;"></asp:Label>
                </td>
                <td>
                <asp:TextBox ID="txtprintqty2" Width="63px" height="15px" runat="server" class="th" 
                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                </td>
                <td>
                 <asp:CheckBox ID="chkREFReceived_2" runat="server" />
                </td>
                </tr>
                    <tr>
                        <td class="my-readmore-css-class">
                            Fabric Quality Approved
                            </td>
                            <td>
                            <asp:Label ID="lblQualityupdatedate_2" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            <asp:TextBox ID="TxtFabricqty2" Width="63px" Height="15px" runat="server" class="th"
                                Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanelddlQtyApvd_2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlQtyApvd_2" AutoPostBack="true" runat="server" Enabled="true"
                                        Style="width:95%" OnSelectedIndexChanged="ddlQtyApvd_2_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlQtyApvd_2" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Initial Approved
                            </td>
                            <td>
                            <asp:Label ID="lblinitialupdatedate_2" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            <asp:TextBox ID="txtInitial2" Width="63px" Height="15px" runat="server" class="th"
                                Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanelddlinitial_2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlinitial_2" AutoPostBack="true" runat="server" Enabled="false"
                                        Style="width:95%" OnSelectedIndexChanged="ddlinitial_2_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlinitial_2" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Bulk Approved
                            </td>
                            <td>
                            <asp:Label ID="lblBulkupdatedate_2" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            <asp:TextBox ID="txtbulk2" Width="63px" Height="15px" runat="server" class="th" Style="font-size: 8px !important;
                                text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlbulkApvd_2" runat="server" AutoPostBack="true" Enabled="false"
                                        Style="width: 95%">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlbulkApvd_2" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>
     
            <div id="DivFabricSection_3" runat="server" visible="false">
          
                <table width="100%" cellpadding="0" cellspacing="0" class="drop-dwn">
                <tr>
                <td>
                Color/Print Ref. Received
                </td>
                <td>
                <asp:Label ID="lblrefupdateddate_3" runat="server" Text="" Style="font-size: 11px;"></asp:Label>
                </td>
                <td>
                 <asp:TextBox ID="txtprintqty3" Width="63px" height="15px" runat="server" class="th" 
                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                </td>
                <td>
                <asp:CheckBox ID="chkREFReceived_3" runat="server" />
                </td>
                </tr>
                    <tr>
                        <td class="my-readmore-css-class">
                            Fabric Quality Approved
                            </td>
                            <td>
                            <asp:Label ID="lblQualityupdatedate_3" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            <asp:TextBox ID="TxtFabricqty3" Width="63px" Height="15px" runat="server" class="th"
                                Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanelddlQtyApvd_3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlQtyApvd_3" AutoPostBack="true" runat="server" Enabled="true"
                                        Style="width: 95%" OnSelectedIndexChanged="ddlQtyApvd_3_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlQtyApvd_3" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Initial Approved
                            </td>
                            <td>
                            <asp:Label ID="lblinitialupdatedate_3" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            <asp:TextBox ID="txtInitial3" Width="63px" Height="15px" runat="server" class="th"
                                Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanelddlinitial_3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlinitial_3" runat="server" AutoPostBack="true" Enabled="false"
                                        Style="width: 95%" OnSelectedIndexChanged="ddlinitial_3_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlinitial_3" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Bulk Approved
                            </td>
                            <td>
                            <asp:Label ID="lblBulkupdatedate_3" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            <asp:TextBox ID="txtbulk3" Width="63px" Height="15px" runat="server" class="th" Style="font-size: 8px !important;
                                text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlbulkApvd_3" runat="server" AutoPostBack="true" Enabled="false"
                                        Style="width: 95%">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlinitial_3" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>
       
            <div id="DivFabricSection_4" runat="server" visible ="false">
            
                <table width="100%" cellpadding="0" cellspacing="0" class="drop-dwn">
                <tr>
                <td>
                Color/Print Ref. Received
                </td>
                <td>
                 <asp:Label  ID="lblrefupdateddate_4" runat="server" Text="" Style="font-size:11px;"></asp:Label>
                </td>
                <td>
                 <asp:TextBox ID="txtprintqty4" Width="63px" height="15px" runat="server" class="th" 
                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                </td>
                <td>
                <asp:CheckBox ID="chkREFReceived_4" runat="server" />
                </td>
                </tr>
                    <tr>
                        <td class="my-readmore-css-class">
                            Fabric Quality Approved 
                            </td>
                            <td>
                            <asp:Label ID="lblQualityupdatedate_4" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                             <asp:TextBox ID="TxtFabricqty4" Width="63px" height="15px" runat="server" class="th" 
                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanelddlQtyApvd_4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlQtyApvd_4" AutoPostBack="true" runat="server" Enabled="true"
                                        Style="width: 95%" OnSelectedIndexChanged="ddlQtyApvd_4_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlQtyApvd_4" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Initial Approved
                            </td>
                            <td>
                            <asp:Label ID="lblinitialupdatedate_4" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            
<asp:TextBox ID="txtInitial4" Width="63px" height="15px" runat="server" class="th" 
                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanelddlinitial_4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlinitial_4" AutoPostBack="true" runat="server" Enabled="false"
                                        Style="width: 95%" OnSelectedIndexChanged="ddlinitial_4_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlinitial_4" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Bulk Approved
                            </td>
                            <td>
                            <asp:Label ID="lblBulkupdatedate_4" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            
<asp:TextBox ID="txtbulk4" Width="63px" height="15px" runat="server" class="th" 
                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlbulkApvd_4" runat="server" AutoPostBack="true" Enabled="false"
                                        Style="width: 95%" >
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlbulkApvd_4" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>

             <div id="DivFabricSection_5" runat="server" visible ="false">
            
                <table width="100%" cellpadding="0" cellspacing="0" class="drop-dwn">
                <tr>
                <td>
                Color/Print Ref. Received
                </td>
                <td>
                 <asp:Label  ID="lblrefupdateddate_5" runat="server" Text="" Style="font-size:11px;"></asp:Label>
                </td>
                <td>
                 <asp:TextBox ID="txtprintqty5" Width="63px" height="15px" runat="server" class="th" 
                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                </td>
                <td>
                <asp:CheckBox ID="chkREFReceived_5" runat="server" />
                </td>
                </tr>
                    <tr>
                        <td class="my-readmore-css-class">
                            Fabric Quality Approved 
                            </td>
                            <td>
                            <asp:Label ID="lblQualityupdatedate_5" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                             <asp:TextBox ID="TxtFabricqty5" Width="63px" height="15px" runat="server" class="th" 
                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanelddlQtyApvd_5" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlQtyApvd_5" AutoPostBack="true" runat="server" Enabled="true"
                                        Style="width: 95%" OnSelectedIndexChanged="ddlQtyApvd_5_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlQtyApvd_5" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Initial Approved
                            </td>
                            <td>
                            <asp:Label ID="lblinitialupdatedate_5" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            
<asp:TextBox ID="txtInitial5" Width="63px" height="15px" runat="server" class="th" 
                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanelddlinitial_5" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlinitial_5" AutoPostBack="true" runat="server" Enabled="false"
                                        Style="width: 95%" OnSelectedIndexChanged="ddlinitial_5_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlinitial_4" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Bulk Approved
                            </td>
                            <td>
                            <asp:Label ID="lblBulkupdatedate_5" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            
<asp:TextBox ID="txtbulk5" Width="63px" height="15px" runat="server" class="th" 
                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlbulkApvd_5" runat="server" AutoPostBack="true" Enabled="false"
                                        Style="width: 95%" >
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlbulkApvd_5" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>

                 <div id="DivFabricSection_6" runat="server" visible ="false">
            
                <table width="100%" cellpadding="0" cellspacing="0" class="drop-dwn">
                <tr>
                <td>
                Color/Print Ref. Received
                </td>
                <td>
                 <asp:Label  ID="lblrefupdateddate_6" runat="server" Text="" Style="font-size:11px;"></asp:Label>
                </td>
                <td>
                 <asp:TextBox ID="txtprintqty6" Width="63px" height="15px" runat="server" class="th" 
                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                </td>
                <td>
                <asp:CheckBox ID="chkREFReceived_6" runat="server" />
                </td>
                </tr>
                    <tr>
                        <td class="my-readmore-css-class">
                            Fabric Quality Approved 
                            </td>
                            <td>
                            <asp:Label ID="lblQualityupdatedate_6" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                             <asp:TextBox ID="TxtFabricqty6" Width="63px" height="15px" runat="server" class="th" 
                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanelddlQtyApvd_6" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlQtyApvd_6" AutoPostBack="true" runat="server" Enabled="true"
                                        Style="width: 95%" OnSelectedIndexChanged="ddlQtyApvd_6_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlQtyApvd_6" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Initial Approved
                            </td>
                            <td>
                            <asp:Label ID="lblinitialupdatedate_6" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            
<asp:TextBox ID="txtInitial6" Width="63px" height="15px" runat="server" class="th" 
                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanelddlinitial_6" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlinitial_6" AutoPostBack="true" runat="server" Enabled="false"
                                        Style="width: 95%" OnSelectedIndexChanged="ddlinitial_6_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlinitial_6" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Bulk Approved
                            </td>
                            <td>
                            <asp:Label ID="lblBulkupdatedate_6" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            
                             <asp:TextBox ID="txtbulk6" Width="63px" height="15px" runat="server" class="th" 
                            Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlbulkApvd_6" runat="server" AutoPostBack="true" Enabled="false"
                                        Style="width: 95%" >
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlbulkApvd_6" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>

            <div style="padding :0px 10px">
                <span style="vertical-align: top;">Remarks:&nbsp;</span>
                <br />
                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Height="40" Style="width:100%"></asp:TextBox>
            </div>
            <div style="color:Red; font-weight:600;text-align:center">
            <asp:Label ID="lblErrormsg" runat="server" Visible="false"></asp:Label>
            </div>
            <div style="padding:0px 5px 5px ; float:left; margin-top:15px; font-size:10px; width:auto;">
                <asp:Label ID="lblFabricDetails"  runat="server" Text=""></asp:Label>
            </div>
             <div style="padding:0px 5px 5px ; float:right; margin-top:15px;">
                <asp:Button ID="btnSubmit" CssClass="submit" runat="server" Text="Submit" OnClick="btnSubmit_Click"  Visible="false"/>&nbsp;&nbsp;
                <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close" Width="65px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
            </div>
            <div style="clear:both;"></div>
      </div>
    </div>

     <br />
            <%--<a href="javascript:void(0)" onclick="showHide( this)">View Remarks</a><br />
            <br />--%>
            <div id="divHistory" style="  width:450px; margin:0px auto;" runat="server" visible="false">
                <div class="form_box">
                    <div class="form_heading" style="    border-bottom: 0px; margin-top: 0; color: #fff;line-height: 15px;height: 15px;">
                        Remarks</div>
         
                <div style="height: 150px ! important; overflow: scroll; overflow-x:hidden;">
                        <table width="100%" cellpadding="5px">
                            <tr>
                                <td style="width: 100%;">
                                     <asp:Label ID="lblRemarks" runat="server" style="font-size:10px !important; text-transform:capitalize !important; font-weight:normal; font-family:Lucida Sans Unicode;;"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        </div>
                    </div>
             
            </div>
    </form>
</body>
</html>
