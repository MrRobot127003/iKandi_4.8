<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessorySupplierDetails.aspx.cs" Inherits="iKandi.Web.Internal.Accessory.AccessorySupplierDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style type="text/css">
   

    table {
	    font-family: arial;
	    border-color: gray;
	    border-collapse: collapse;
    }

  
    .grdgsmcom td {
	    font-size: 10px;
	    text-align: center;
	    border-color: #aaa;
	    text-transform: capitalize;
	    color: gray;
	    padding: 2px 0px;
	    font-family: arial;
	    border-color: #999;
	    padding:5px 0px;
	     font-weight:500;
    }
   #sb-body-inner
   {
         background: #fff;
   }

    .grdgsmcom th {
	       background: #dddfe4;
            color: #575759;
            text-align: center;
            border: 1px solid #999;
            font-size: 10px;
           font-family: arial;
            padding: 3px 0px;
            font-weight:500;
    }


    .maincontentcontainer {
	        width: 700px;
            margin: 0px auto;
            height: 220px;
            background: #f3f3f3;
               overflow-y: hidden;
    }

    .decoratedErrorField {
	    width: 27% !important;
	    border: 2px solid red !important;
    }

    .UsernameColor {
	    font-weight: 600;
    }
     
      .tab1greige
      {
          cursor:pointer;
      } 
      .clsDivHdr
      {
           background: #dddfe4;
	    font-weight:500;
	    color:#575759;
	    font-family:arila;
	    font-size: 11px;
	    padding: 5px 0px;
	    text-align: center;
	    text-transform: capitalize;
	    width:544px;
	   
      }
      .color_black
      {
          color:Black;          
      }
      td[colspan="6"]
      {
          padding:0px 0px !important;
          border:0px;
      }
    </style>
    <script>
        function HideSupplierDiv() {
          //  alert();
            self.parent.Shadowbox.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="maincontentcontainer">
         <div class="clsDivHdr" id="dvHeader" runat="server" style="width:100%;background:#39589c !important;color:#fff">All Quotations
         <span style="float:right;padding-right:10px;cursor: pointer;color:#fff" title="Close" onclick="HideSupplierDiv();">x</span>
         </div>
           <asp:GridView ID="grdSupplier" CssClass="grdgsmcom" runat="server" AutoGenerateColumns="False" ShowHeader="true" 
            EmptyDataText="No Record Found!" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
            BorderWidth="0" CellPadding="0" rules="all" HeaderStyle-CssClass="ths" 
             ondatabound="grdSupplier_DataBound" style="border:1px solid #999;width:100%" onrowdatabound="grdSupplier_RowDataBound">
            <SelectedRowStyle BackColor="#A1DCF2" />
            <RowStyle CssClass="RowCountDy" />
            <Columns>
                <asp:TemplateField HeaderText="Accessory Quality (Size)<br> Color/Print">
                    <ItemStyle HorizontalAlign="Center" Width="130px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblAccessoryQuality" ForeColor="blue" Text='<%# Eval("AccessoryName")%>' runat="server"></asp:Label>
                        <asp:Label ID="lblSize" ForeColor="gray" Text='<%# Eval("Size")%>' runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblcolorprint" Font-Bold="true" CssClass="color_black" Text='<%# Eval("Color_Print")%>' runat="server"></asp:Label> 
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField Visible="false" HeaderText="Shrinkage %">
                    <ItemTemplate>
                        <asp:Label ID="lblShrinkage" runat="server" CssClass="color_black" Text='<%# Convert.ToString(Eval("Shrinkage")) == "0" ? "" : Convert.ToString(Eval("Shrinkage")) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>

                 <asp:TemplateField Visible="false" HeaderText="Wastage %">
                    <ItemTemplate>
                        <asp:Label ID="lblWastage" runat="server" CssClass="color_black" Text='<%# Convert.ToString(Eval("Wastage")) == "0" ? "" : Convert.ToString(Eval("Wastage")) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Best Quote">
                    <ItemTemplate>                        
                        <asp:Label ID="lblIdealRate" CssClass="color_black" Text='<%# Convert.ToString(Eval("IdealRate")) == "0" ? "" : Convert.ToString(Eval("IdealRate"))%>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" BackColor="lightgreen" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Supplier Name">
                    <ItemTemplate>                                       
                        <asp:Label ID="lblsuppliername" ForeColor="gray" Text='<%# Convert.ToString(Eval("SupplierName")) == "0" ? "" : Convert.ToString(Eval("SupplierName"))%>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="180px" />
                </asp:TemplateField>             
               
                <asp:TemplateField HeaderText="Quoted (Rate & Lead Time)">
                    <ItemTemplate>
                        <asp:Label ID="lblQuotedLandedRate" CssClass="color_black" runat="server" Text='<%# Convert.ToString(Eval("QuotedLandedRate")) == "0" ? "" : Convert.ToString(Eval("QuotedLandedRate"))%>'></asp:Label>
                        &nbsp;<asp:Label ID="lblQuotedLeadTime" ForeColor="gray" runat="server" Text='<%# Convert.ToString(Eval("QuotedLeadTime")) == "0" ? "" : Convert.ToString(Eval("QuotedLeadTime"))%>'></asp:Label>
                        <asp:HiddenField ID="hdAccessoryMasterId" Value='<%# Eval("AccessoryMasterId")%>' runat="server" />
                        <asp:HiddenField ID="hdnAccessoryQualitySize" Value='<%# Eval("Size")%>' runat="server" />
                        <asp:HiddenField ID="hdnColorprint" Value='<%# Eval("Color_Print")%>' runat="server" />                         
                    </ItemTemplate>
                    <ItemStyle Width="80px" />
                </asp:TemplateField>
                                 
            </Columns>
            <EmptyDataTemplate>
            <table class="topsupplier" style="width:100%">
             <tr>
                <th>Accessory Quality (Size) <br />Color/Print</th>
                <th style="display:none;">Shrinkage %</th>
                <th style="display:none;">Wastage %</th>
                <th> Best Quote</th>
                <th>Supplier Name</th>
                <th>Quoted (Rate & Lead Time)</th>
            </tr>
            <tr>
               <td colspan="5" style="text-align:center">
                 <img src="../../images/sorry.png" alt="No record found" class="ImgCenter">
               </td>
            </tr>
            </table>
         
                <asp:Label ID="lblEmptyRow" style="font-size:12px; color:Red;display:none;" runat="server" Text="Data not available"></asp:Label>
            </EmptyDataTemplate>
        </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
