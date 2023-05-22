<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnRagisterFabricQuality.aspx.cs" Inherits="iKandi.Web.Internal.Fabric.UnRagisterFabricQuality" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />

    <style>
     .CommoAdmin_Table
     {
        width:600px;
      }
     .CommoAdmin_Table td input[type="text"]
     {
         text-transform:capitalize;
         width:90%;
      }
     .CommoAdmin_Table td
     {
        text-align:center;
      }
      .CommoAdmin_Table td:nth-child(1)
     {
       
        width:40px;
      }
     .CommoAdmin_Table td:nth-child(2)
     {
        text-align:left !important;
        width:160px;
      }
       .CommoAdmin_Table td:nth-child(4)
     {
        
        width:120px;
      }
      .borderEmpty td[colspan="7"]
      {
          border:0px;
       }
       .headertext
       {
             background: #39589c;
            margin: 0px;
            padding: 3px 10px;
            color: #fff;
            text-transform: capitalize;
            border-radius: 1px 1px 0px 0px;
            display: block;
            text-align:center
         }
         .CommoAdmin_Table th
         {
            position: sticky;
            top: -1px;
             }
    </style>
     <script type="text/javascript">
         function myFunction(e) {
             debugger;
             if ((event.which != 46 || e.value.indexOf('.') != -1) &&
            ((event.which < 48 || event.which > 57) &&
              (event.which != 0 && event.which != 8))) {
                         event.preventDefault();
                     }
            var t = e.value;
            e.value = (t.indexOf(".") >= 0) ? (t.substr(0, t.indexOf(".")) + t.substr(t.indexOf("."), 2)) : t;
        }

        function closeAccesButtion() {
                self.parent.Shadowbox.close();
        }
  
    </script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="headertext">
        <span>UnRegister Fabric Quality Entry Form</span>
      <span style="float: right; padding-right: 5px; margin-top: 0px; font-size: 14px;
                cursor: pointer" onclick="closeAccesButtion()">x</span>
    </div>
     <table class="CommoAdmin_Table" style="margin-bottom:5px;margin-top:5px">
	     	 <tbody>
               <tr>
			        
                    <th>Fabric Quality</th>
                    <th>GSM</th>
                    <th>Count Construction</th>
                    <th>Cost Width</th>
                    <th>Finish Rate</th>
                    <th>Action</th>
	     	</tr>
            <tr>
			     
                 <td style="width:160px;">
                   <asp:TextBox ID="txtEmptyFabQuality" runat="server"></asp:TextBox>
                </td>
                <td style="width:50px;">
                <asp:TextBox ID="txtEmptyGsm" onkeypress="myFunction(this)" runat="server"></asp:TextBox>
               </td>
               <td style="width:160px;">
                 <asp:TextBox ID="txtEmptyCountCounstruction" runat="server"></asp:TextBox>
               </td>
               <td style="width:60px;">
                  <asp:TextBox ID="txtEmptyCostWidth" onkeypress="myFunction(this)" MaxLength="7" runat="server"></asp:TextBox>
               </td>
               <td>
                 <asp:TextBox ID="txtEmptyFinishRate" onkeypress="myFunction(this)" MaxLength="7" runat="server"></asp:TextBox>
               </td>
               <td>
               <asp:LinkButton ID="submit" runat="server" OnClick="DataSave_Click">
                                    <img src="../../images/add-butt.png" alt="Add Items" title="Add more"
                                     border="0" />
                        </asp:LinkButton>
             
               </td>
		</tr>
	</tbody></table>
      <asp:GridView ID="GrdUnRagisterFabQuality" CssClass="CommoAdmin_Table" 
            runat="server" AutoGenerateColumns="False" OnRowDataBound="GrdUnRagisterFabQuality_RowDataBound" BorderWidth="0" ShowFooter="false">
            <FooterStyle CssClass="footerRoe" />
            <EmptyDataRowStyle CssClass="borderEmpty" />
         <Columns>
            <asp:TemplateField HeaderText="Sr. No.">
               <ItemTemplate>
                   <%# Container.DataItemIndex + 1 %>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fabric Quality">
                <ItemTemplate>
                   <asp:Label ID="lblFabQuality" Text='<%# Eval("TradeName") %>' runat="server"></asp:Label>
                </ItemTemplate>
              
            </asp:TemplateField>

            <asp:TemplateField HeaderText="GSM">
               <ItemTemplate>
                   <asp:Label ID="lblGsm" Text='<%# Eval("Gsm") %>' runat="server"></asp:Label>
               </ItemTemplate>
              
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Count Construction">
               <ItemTemplate>
                  <asp:Label ID="lblCountConstruction" Text='<%# Eval("CountConstruction") %>' runat="server"></asp:Label>
               </ItemTemplate>
            
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Cost Width">
               <ItemTemplate>
                  <asp:Label ID="lblCostWidth" Text='<%# Eval("CostWidth") %>' runat="server"></asp:Label>
               </ItemTemplate>
              
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Finish Rate">
               <ItemTemplate>
                 <asp:Label ID="lblFinishRate" Text='<%# Eval("FinishRate") %>' runat="server"></asp:Label>
               </ItemTemplate>
             
            </asp:TemplateField>

            <%-- <asp:TemplateField HeaderText="Action">
               <ItemTemplate></ItemTemplate>
               <FooterTemplate>
                <asp:LinkButton ID="lkbInsert" runat="server" CausesValidation="true" CommandName="Insert">
                                    <img src="../../images/add-butt.png" alt="Add Items" title="Add more"
                                     border="0" />
                        </asp:LinkButton>
               </FooterTemplate>
            </asp:TemplateField>--%>
         </Columns>
       <%--  <EmptyDataTemplate>
            <table class="CommoAdmin_Table">
	     	 <tbody>
               <tr>
			        <th>Sr. No.</th>
                    <th>Fabric Quality</th>
                    <th>GSM</th>
                    <th>Count Construction</th>
                    <th>Cost Width</th>
                    <th>Finish Rate</th>
                    <th>Action</th>
	     	</tr>
            <tr>
			     <td>&nbsp;</td>
                 <td>
                   <asp:TextBox ID="txtEmptyFabQuality" runat="server"></asp:TextBox>
                </td>
                <td>
                <asp:TextBox ID="txtEmptyGsm" onkeypress="myFunction(this)" runat="server"></asp:TextBox>
               </td>
               <td>
                 <asp:TextBox ID="txtEmptyCountCounstruction" runat="server"></asp:TextBox>
               </td>
               <td>
                  <asp:TextBox ID="txtEmptyCostWidth" onkeypress="myFunction(this)" MaxLength="7" runat="server"></asp:TextBox>
               </td>
               <td>
                 <asp:TextBox ID="txtEmptyFinishRate" onkeypress="myFunction(this)" MaxLength="7" runat="server"></asp:TextBox>
               </td>
               <td>
               <asp:LinkButton ID="submit" runat="server" CausesValidation="true" CommandName="EmptyRow">
                                    <img src="../../images/add-butt.png" alt="Add Items" title="Add more"
                                     border="0" />
                        </asp:LinkButton>
             
               </td>
		</tr>
	</tbody></table>
         </EmptyDataTemplate>--%>
      </asp:GridView>
    </div>
    </form>
</body>
</html>
