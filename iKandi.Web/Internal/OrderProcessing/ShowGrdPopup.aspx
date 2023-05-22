<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowGrdPopup.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.ShowGrdPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">

.pras th {

background-color: #717171; 
color:#fff; 
padding:5px 0px;font-size:11px;font-weight:normal;
}
.pras td{ color:gray; 
               font-size:11px !important;
               font-family:Lucida Sans Unicode;
               
               
               }
</style>
</head>
<body>
    <form id="form1" runat="server"> 
    <div style="  width:900px;">
    <table width="100%">   
    <tr id="tr1" runat="server" visible="false">
    <td>
    <div style="background:#717171; color:#fff; padding:5px; font-weight:bold; margin-bottom:5px">
    <asp:Label ID="lblGarmentName1" runat="server"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblCutting" runat="server" Text="Cutting"></asp:Label>
    </div>
    
     <asp:GridView ID="grdOBCutting" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowFooter="True" PageSize="10" AllowPaging="true" HeaderStyle-CssClass="pras"
                    HeaderStyle-Height="23px" HeaderStyle-Font-Names="Lucida Sans Unicode" HeaderStyle-HorizontalAlign="Center" >
                    <Columns>
                        <asp:TemplateField HeaderText="No. Of Operations" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblOperation"   BorderStyle="None"
                                    Text='<%#Eval("NoOfOperation")%>' Width="60px" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Operation Type" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblOperationType"  Style="text-align: center;color:gray"  BorderStyle="None"
                                        Width="60px" runat="server" Text='<%#Eval("FactoryWorkSpace")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblMachine"  BorderStyle="None" Width="60px"
                                        runat="server" Text='<%#Eval("WorkerType")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblAttachment"  Style="text-align: center;color:gray" Width="60px"
                                    runat="server" Text='<%#Eval("AttachmentName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SAM" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblSAM"   Width="60px"
                                        runat="server" Text='<%#Eval("CuttingSam")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblMachineCount" Style="text-align: center;color:gray" Text='<%#Eval("MachineCalc")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Final Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblFinalCount" Style="text-align: center;color:gray"  Text='<%#Eval("FinalOB")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div >
                                    <asp:Label ID="lblComments"   Width="60px"
                                        runat="server" Text='<%#Eval("Commentes")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    
                </asp:GridView>
                <asp:HiddenField ID="hdnStyleCode" runat="server" />
                <asp:HiddenField ID="hdnClientID" runat="server" />
                <asp:HiddenField ID="hdnDeptId" runat="server" />
    </td>
    </tr>
    <tr id="tr2" runat="server" visible="false">
    <td>
    <div style="background:#717171; color:#fff; padding:5px; font-weight:bold; margin-bottom:5px">
    <asp:Label ID="lblFront" runat="server" Text="Front"></asp:Label>
    </div>
    
    <asp:GridView ID="grdOBFront" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowFooter="True" PageSize="10" AllowPaging="true" HeaderStyle-CssClass="pras"
                    HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" >
                    <Columns>
                        <asp:TemplateField HeaderText="No. Of Operations" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblOperation" Style="text-align: center;color:gray"  BorderStyle="None"
                                    Text='<%#Eval("NoOfOperation")%>' Width="60px" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Operation Type" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblOperationType"  Style="text-align: center;color:gray" BorderStyle="None"
                                        Width="60px" runat="server" Text='<%#Eval("FactoryWorkSpace")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray" >
                                    <asp:Label ID="lblMachine" Style="text-align: center;color:gray"  BorderStyle="None" Width="60px"
                                        runat="server" Text='<%#Eval("WorkerType")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblAttachment" Style="text-align: center;color:gray"   Width="60px"
                                    runat="server" Text='<%#Eval("AttachmentName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SAM" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray" >
                                    <asp:Label ID="lblSAM"  Style="text-align: center;color:gray"  Width="60px"
                                        runat="server" Text='<%#Eval("CuttingSam")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray" >
                                    <asp:Label ID="lblMachineCount" Style="text-align: center;color:gray"  Text='<%#Eval("MachineCalc")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Final Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray" >
                                    <asp:Label ID="lblFinalCount" Style="text-align: center;color:gray"   Text='<%#Eval("FinalOB")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray" >
                                    <asp:Label ID="lblComments"  Style="text-align: center;color:gray"   Width="60px"
                                        runat="server" Text='<%#Eval("Commentes")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    
                </asp:GridView>
    </td>
    </tr>
    <tr id="tr3" runat="server" visible="false">
    <td>
     <div style="background:#717171; color:#fff; padding:5px; font-weight:bold; margin-bottom:5px">
    <asp:Label ID="lblBack" runat="server" Text="Back"></asp:Label>
    </div>
    <asp:GridView ID="grdOBBack" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowFooter="True" PageSize="10" AllowPaging="true" HeaderStyle-CssClass="pras"
                    HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" >
                    <Columns>
                        <asp:TemplateField HeaderText="No. Of Operations" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblOperation" Style="text-align: center;color:gray"  BorderStyle="None"
                                    Text='<%#Eval("NoOfOperation")%>' Width="60px" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Operation Type" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblOperationType" Style="text-align: center;color:gray"   BorderStyle="None"
                                        Width="60px" runat="server" Text='<%#Eval("FactoryWorkSpace")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblMachine" Style="text-align: center;color:gray"  BorderStyle="None" Width="60px"
                                        runat="server" Text='<%#Eval("WorkerType")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblAttachment" Style="text-align: center;color:gray"  Width="60px"
                                    runat="server" Text='<%#Eval("AttachmentName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SAM" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblSAM" Style="text-align: center;color:gray"  Width="60px"
                                        runat="server" Text='<%#Eval("CuttingSam")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblMachineCount" Style="text-align: center;color:gray"  Text='<%#Eval("MachineCalc")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Final Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblFinalCount" Style="text-align: center;color:gray"   Text='<%#Eval("FinalOB")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblComments" Style="text-align: center;color:gray"  Width="60px"
                                        runat="server" Text='<%#Eval("Commentes")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    
                </asp:GridView>
    </td>
    </tr>
    <tr id="tr4" runat="server" visible="false">
    <td>
    <div style="background:#717171; color:#fff; padding:5px; font-weight:bold; margin-bottom:5px">
    <asp:Label ID="lblcoller" runat="server" Text="collar"></asp:Label>
    </div>
    <asp:GridView ID="grdOBcoller" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowFooter="True" PageSize="10" AllowPaging="true" HeaderStyle-CssClass="pras"
                    HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" >
                    <Columns>
                        <asp:TemplateField HeaderText="No. Of Operations" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblOperation" Style="text-align: center;color:gray"  BorderStyle="None"
                                    Text='<%#Eval("NoOfOperation")%>' Width="60px" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Operation Type" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray" >
                                    <asp:Label ID="lblOperationType" Style="text-align: center;color:gray"   BorderStyle="None"
                                        Width="60px" runat="server" Text='<%#Eval("FactoryWorkSpace")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray" >
                                    <asp:Label ID="lblMachine"  Style="text-align: center;color:gray" BorderStyle="None" Width="60px"
                                        runat="server" Text='<%#Eval("WorkerType")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblAttachment" Style="text-align: center;color:gray"  Width="60px"
                                    runat="server" Text='<%#Eval("AttachmentName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SAM" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray" >
                                    <asp:Label ID="lblSAM"  Style="text-align: center;color:gray"  Width="60px"
                                        runat="server" Text='<%#Eval("CuttingSam")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray" >
                                    <asp:Label ID="lblMachineCount" Style="text-align: center;color:gray" Text='<%#Eval("MachineCalc")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Final Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblFinalCount"  Style="text-align: center;color:gray"  Text='<%#Eval("FinalOB")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblComments" Style="text-align: center;color:gray"   Width="60px"
                                        runat="server" Text='<%#Eval("Commentes")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    
                </asp:GridView>
    </td>
    </tr>
    <tr id="tr5" runat="server" visible="false">
    <td>
    <div style="background:#717171; color:#fff; padding:5px; font-weight:bold; margin-bottom:5px">
    <asp:Label ID="lblsleep" runat="server" Text="sleep"></asp:Label>
    </div>
    <asp:GridView ID="grdOBsleep" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowFooter="True" PageSize="10" AllowPaging="true" HeaderStyle-CssClass="pras"
                    HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" >
                    <Columns>
                        <asp:TemplateField HeaderText="No. Of Operations" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblOperation" Style="text-align: center;color:gray"   BorderStyle="None"
                                    Text='<%#Eval("NoOfOperation")%>' Width="60px" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Operation Type" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray" >
                                    <asp:Label ID="lblOperationType"   BorderStyle="None"
                                        Width="60px" runat="server" Text='<%#Eval("FactoryWorkSpace")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray" >
                                    <asp:Label ID="lblMachine" Style="text-align: center;color:gray"  BorderStyle="None" Width="60px"
                                        runat="server" Text='<%#Eval("WorkerType")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblAttachment"   Width="60px"
                                    runat="server" Text='<%#Eval("AttachmentName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SAM" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblSAM" Style="text-align: center;color:gray"  Width="60px"
                                        runat="server" Text='<%#Eval("CuttingSam")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblMachineCount" Style="text-align: center;color:gray"  Text='<%#Eval("MachineCalc")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Final Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblFinalCount"  Style="text-align: center;color:gray"  Text='<%#Eval("FinalOB")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblComments" Style="text-align: center;color:gray"  Width="60px"
                                        runat="server" Text='<%#Eval("Commentes")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    
                </asp:GridView>
    </td>
    </tr>
    <tr id="tr6" runat="server" visible="false">
    <td>
     <div style="background:#717171; color:#fff; padding:5px; font-weight:bold; margin-bottom:5px">
    <asp:Label ID="lblneck" runat="server" Text="neck"></asp:Label>
    </div>
    <asp:GridView ID="grdOBneck" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowFooter="True" PageSize="10" AllowPaging="true" HeaderStyle-CssClass="pras"
                    HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" >
                    <Columns>
                        <asp:TemplateField HeaderText="No. Of Operations" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblOperation"   BorderStyle="None"
                                    Text='<%#Eval("NoOfOperation")%>' Width="60px" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Operation Type" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray" >
                                    <asp:Label ID="lblOperationType" Style="text-align: center;color:gray"  BorderStyle="None"
                                        Width="60px" runat="server" Text='<%#Eval("FactoryWorkSpace")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray" >
                                    <asp:Label ID="lblMachine" Style="text-align: center;color:gray"  BorderStyle="None" Width="60px"
                                        runat="server" Text='<%#Eval("WorkerType")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblAttachment"   Width="60px"
                                    runat="server" Text='<%#Eval("AttachmentName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SAM" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblSAM" Style="text-align: center;color:gray"  Width="60px"
                                        runat="server" Text='<%#Eval("CuttingSam")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblMachineCount" Style="text-align: center;color:gray"  Text='<%#Eval("MachineCalc")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Final Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblFinalCount"  Style="text-align: center;color:gray"  Text='<%#Eval("FinalOB")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblComments" Style="text-align: center;color:gray"  Width="60px"
                                        runat="server" Text='<%#Eval("Commentes")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    
                </asp:GridView>
    </td>
    </tr>
    <tr id="tr7" runat="server" visible="false">
    <td>
    <div style="background:#717171; color:#fff; padding:5px; font-weight:bold; margin-bottom:5px">
    <asp:Label ID="lblLining" runat="server" Text="Lining"></asp:Label>
  </div>
    <asp:GridView ID="grdOBLining" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowFooter="True" PageSize="10" AllowPaging="true" HeaderStyle-CssClass="pras"
                    HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" >
                    <Columns>
                        <asp:TemplateField HeaderText="No. Of Operations" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblOperation"   BorderStyle="None"
                                    Text='<%#Eval("NoOfOperation")%>' Width="60px" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Operation Type" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblOperationType" Style="text-align: center;color:gray"  BorderStyle="None"
                                        Width="60px" runat="server" Text='<%#Eval("FactoryWorkSpace")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblMachine" Style="text-align: center;color:gray" BorderStyle="None" Width="60px"
                                        runat="server" Text='<%#Eval("WorkerType")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblAttachment" Style="text-align: center;color:gray"  Width="60px"
                                    runat="server" Text='<%#Eval("AttachmentName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SAM" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblSAM" Style="text-align: center;color:gray"   Width="60px"
                                        runat="server" Text='<%#Eval("CuttingSam")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div >
                                    <asp:Label ID="lblMachineCount"  Text='<%#Eval("MachineCalc")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Final Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblFinalCount"   Text='<%#Eval("FinalOB")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblComments" Style="text-align: center;color:gray"   Width="60px"
                                        runat="server" Text='<%#Eval("Commentes")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    
                </asp:GridView>
    </td>
    </tr>
    <tr id="tr8" runat="server" visible="false">
    <td>
    <div style="background:#717171; color:#fff; padding:5px; font-weight:bold; margin-bottom:5px">
    <asp:Label ID="lbllower" runat="server" Text="lower"></asp:Label>
    </div>
    <asp:GridView ID="grdOBlower" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowFooter="True" PageSize="10" AllowPaging="true" HeaderStyle-CssClass="pras"
                    HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" >
                    <Columns>
                        <asp:TemplateField HeaderText="No. Of Operations" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblOperation"  Style="text-align: center;color:gray"  BorderStyle="None"
                                    Text='<%#Eval("NoOfOperation")%>' Width="60px" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Operation Type" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblOperationType"  Style="text-align: center;color:gray"  BorderStyle="None"
                                        Width="60px" runat="server" Text='<%#Eval("FactoryWorkSpace")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div >
                                    <asp:Label ID="lblMachine"  BorderStyle="None" Width="60px"
                                        runat="server" Text='<%#Eval("WorkerType")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblAttachment" Style="text-align: center;color:gray"  Width="60px"
                                    runat="server" Text='<%#Eval("AttachmentName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SAM" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray" >
                                    <asp:Label ID="lblSAM" Style="text-align: center;color:gray"  Width="60px"
                                        runat="server" Text='<%#Eval("CuttingSam")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblMachineCount" Style="text-align: center;color:gray"  Text='<%#Eval("MachineCalc")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Final Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblFinalCount" Style="text-align: center;color:gray"   Text='<%#Eval("FinalOB")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblComments" Style="text-align: center;color:gray"   Width="60px"
                                        runat="server" Text='<%#Eval("Commentes")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    
                </asp:GridView>
    </td>
    </tr>
    <tr id="tr9" runat="server" visible="false">
    <td>
    <div style="background:#717171; color:#fff; padding:5px; font-weight:bold; margin-bottom:5px">
    <asp:Label ID="lblbottom" runat="server" Text="bottom"></asp:Label>
   </div>
    <asp:GridView ID="grdOBbottom" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowFooter="True" PageSize="10" AllowPaging="true" HeaderStyle-CssClass="pras"
                    HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" >
                    <Columns>
                        <asp:TemplateField HeaderText="No. Of Operations" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblOperation"   BorderStyle="None"
                                    Text='<%#Eval("NoOfOperation")%>' Width="60px" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Operation Type" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblOperationType" Style="text-align: center;color:gray"  BorderStyle="None"
                                        Width="60px" runat="server" Text='<%#Eval("FactoryWorkSpace")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div >
                                    <asp:Label ID="lblMachine"  BorderStyle="None" Width="60px"
                                        runat="server" Text='<%#Eval("WorkerType")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblAttachment"  Style="text-align: center;color:gray" Width="60px"
                                    runat="server" Text='<%#Eval("AttachmentName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SAM" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblSAM"  Style="text-align: center;color:gray"  Width="60px"
                                        runat="server" Text='<%#Eval("CuttingSam")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblMachineCount" Style="text-align: center;color:gray" Text='<%#Eval("MachineCalc")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Final Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblFinalCount" Style="text-align: center;color:gray"  Text='<%#Eval("FinalOB")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblComments" Style="text-align: center;color:gray"   Width="60px"
                                        runat="server" Text='<%#Eval("Commentes")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    
                </asp:GridView>
    </td>
    </tr>
    <tr id="tr10" runat="server" visible="false">
    <td>
    <div style="background:#717171; color:#fff; padding:5px; font-weight:bold; margin-bottom:5px">
    <asp:Label ID="lblassembly" runat="server" Text="assembly"></asp:Label>
    </div>
    <asp:GridView ID="grdOBassembly" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowFooter="True" PageSize="10" AllowPaging="true" HeaderStyle-CssClass="pras"
                    HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" >
                    <Columns>
                        <asp:TemplateField HeaderText="No. Of Operations" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblOperation" Style="text-align: center;color:gray"  BorderStyle="None"
                                    Text='<%#Eval("NoOfOperation")%>' Width="60px" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Operation Type" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblOperationType" Style="text-align: center;color:gray"  BorderStyle="None"
                                        Width="60px" runat="server" Text='<%#Eval("FactoryWorkSpace")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblMachine" Style="text-align: center;color:gray"  BorderStyle="None" Width="60px"
                                        runat="server" Text='<%#Eval("WorkerType")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblAttachment" Style="text-align: center;color:gray"  Width="60px"
                                    runat="server" Text='<%#Eval("AttachmentName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SAM" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblSAM"  Style="text-align: center;color:gray"  Width="60px"
                                        runat="server" Text='<%#Eval("CuttingSam")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblMachineCount" Style="text-align: center;color:gray"  Text='<%#Eval("MachineCalc")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Final Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblFinalCount" Style="text-align: center;color:gray"   Text='<%#Eval("FinalOB")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblComments" Style="text-align: center;color:gray"  Width="60px"
                                        runat="server" Text='<%#Eval("Commentes")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    
                </asp:GridView>
    </td>
    </tr>
    <tr id="tr11" runat="server" visible="false">
    <td>
    <div style="background:#717171; color:#fff; padding:5px; font-weight:bold; margin-bottom:5px">
    <asp:Label ID="lblFinishing" runat="server" Text="Finishing"></asp:Label>
    </div>
    <asp:GridView ID="grdOBFinishing" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowFooter="True" PageSize="10" AllowPaging="true" HeaderStyle-CssClass="pras"
                    HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" >
                    <Columns>
                        <asp:TemplateField HeaderText="No. Of Operations" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblOperation" Style="text-align: center;color:gray"  BorderStyle="None"
                                    Text='<%#Eval("NoOfOperation")%>' Width="60px" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Operation Type" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblOperationType" Style="text-align: center;color:gray"  BorderStyle="None"
                                        Width="60px" runat="server" Text='<%#Eval("FactoryWorkSpace")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblMachine" Style="text-align: center;color:gray" BorderStyle="None" Width="60px"
                                        runat="server" Text='<%#Eval("WorkerType")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <asp:Label ID="lblAttachment" Style="text-align: center;color:gray"  Width="60px"
                                    runat="server" Text='<%#Eval("AttachmentName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SAM" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblSAM" Style="text-align: center;color:gray"   Width="60px"
                                        runat="server" Text='<%#Eval("CuttingSam")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblMachineCount" Style="text-align: center;color:gray"  Text='<%#Eval("MachineCalc")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Final Machine/Manual Count" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblFinalCount" Style="text-align: center;color:gray"  Text='<%#Eval("FinalOB")%>'
                                        Width="60px" runat="server"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <div Style="text-align: center;color:gray">
                                    <asp:Label ID="lblComments" Style="text-align: center;color:gray"  Width="60px"
                                        runat="server" Text='<%#Eval("Commentes")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    
                </asp:GridView>
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
