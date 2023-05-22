<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SopFileUpload.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.SopFileUpload" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<style type="text/css">
 .item_list TD input[type="text"].inputborder0 {
     color: #000 !important;
     font-size: 11px;
     text-align:left;
     padding-left: 2px;
}
 .sop_table
 {
     color:Black; 
     border: 1px solid #999;
     border-bottom: 0px;
 }
 .sop_table td
 {
     text-transform:capitalize;
     padding:2px 2px;
     border-collapse:collapse;
     border:1px solid #9999 !important;
 }
 .sop_table td:first-child
 {
     border-left-color:#999 !important;
  }
 .sop_table td:last-child
 {
     border-right-color:#999 !important;
  }
 .sop_table tr:last-child>td
 {
     border-bottom-color:#999 !important;
  }
 input[type="file"].fileupload
 {
    border:0px;
    font-size: 8px;
    width: 65px !important;
  }
  input[type="text"]
  {
      width:67%;
   }
input[type="file"] {
    height: 22px;
    font-size: 10px;
}
.item_list TD img {
    width: 12px;
    border: 0px;
}

.tab {
  overflow: hidden;
  width: 45%;
}
.tab span {
    float: left;
    cursor: pointer;
    transition: 0.3s;
    font-size: 12px;
    width: 23%;
    color: #fff;
    background: gray;
    height: 17px;
    margin-right: 3px;
    border-top-right-radius:4px;
    border-top-left-radius:4px;
    line-height: 18px;
    text-align: center;
}

.tab span:hover {
  background-color: green;
}

.tab span.active {
  background-color:green;
}

.tabcontent {
  /*display: none;*/
  padding: 0px 0px;
  border: 0px solid #ccc;
  border-top: none;
}
</style>

<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />


        <table id="idTbaleNew" runat="server" cellpadding="0" cellspacing="0" width="100%" border="0" align="center" class="sop_table">
            <tr>
                <td style="width:110px;">
                    <b style="padding-bottom:10px;color:gray;">Name </b>
                    <asp:TextBox ID="txtsopname" runat="server" MaxLength="30" style="width:70%;"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Required" ControlToValidate="txtsopname"
                      runat="server" Display="Dynamic" ValidationGroup="g1" ForeColor="Red" />
                </td>
                <td style="width:73px;">
                    <asp:DropDownList ID="ddlTypeEntry" Width="100%" CssClass="selectcolor" runat="server">
                                        <asp:ListItem Text="Select Type" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="SOP" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="KPI" Value="2"></asp:ListItem>
                                       <asp:ListItem Text="Policy" Value="3"></asp:ListItem>
                                        <%-- <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>--%>
                      </asp:DropDownList>
                </td>
                <td style="width:175px;">
                    <b style="padding-bottom:10px;color:gray;"> Upload File </b>
                    <asp:FileUpload ID="fileUpload" runat="server" width="150px"/>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ControlToValidate="fileUpload"
                      runat="server" Display="Dynamic" ValidationGroup="g1" ForeColor="Red" />
                </td>
                <td style="width:45px; text-align:center;">
                <asp:Button ID="btnsubmit" runat="server"  ValidationGroup="g1" CssClass="submit" Text="Submit" onclick="btnsubmit_Click" style="line-height: 11px;" />
                
                </td>
            </tr>
        </table>

          <br />
         
             <div class="tab">
              <span class="tablinks active" onclick="openShop(event, 'SOP')">SOP</span>
              <span class="tablinks" onclick="openShop(event, 'KPI')">KPI</span>
              <span class="tablinks" onclick="openShop(event, 'Policy')">Policy</span>
         
            </div>
         <div style="overflow-y:auto;max-height:420px">
            <div id="SOP" class="tabcontent active">
               <asp:GridView ID="grdshopedit" runat="server" rules="all" OnRowEditing="grdshopedit_RowEditing"  OnRowDataBound="grdshopedit_RowDataBound" AutoGenerateColumns="False" ShowHeader="true" OnRowCommand="grdshopedit_RowCommand" CellPadding="0" CellSpacing="0" Width="100%" class="sop_table item_list">
                   <Columns>
          
                   <asp:TemplateField HeaderText="Name">
                         <ItemTemplate>
                         <asp:TextBox  ID="txtShopNameGrd" Text='<%#Eval("SOPNAME")%>' Width="98%" runat="server" CssClass="inputborder0"  MaxLength="30"></asp:TextBox>
                         <asp:HiddenField ID="hdnshopId" runat="server" Value='<%#Eval("Id")%>' />
                           </ItemTemplate>
                           <ItemStyle Width="160" />
                     </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="Type">
                         <ItemTemplate>
                             <asp:DropDownList ID="ddlType" CssClass="selectcolor" Width="100%" runat="server">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="SOP" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="KPI" Value="2"></asp:ListItem>
                                               <asp:ListItem Text="Policy" Value="3"></asp:ListItem>
                                              
                              </asp:DropDownList>
                             <asp:HiddenField ID="hdnTypeId" runat="server" Value='<%#Eval("TypeId")%>' />   
                         </ItemTemplate>
                          <ItemStyle Width="55" />
                   </asp:TemplateField>--%>
                     <asp:TemplateField HeaderText="Upload">
                         <ItemTemplate>
                         <asp:FileUpload id="fileuploadgrd" runat="server" CssClass="fileupload"  Width="58px" />
                         <asp:HiddenField ID="hdnfilename" runat="server" Value='<%#Eval("FilePath")%>' />
                         <asp:HyperLink ID="hlkViewSnap1" runat="server"  Target="_blank"> 
                            <img src="../../images/view-icon.png" style="vertical-align: middle;" /> </asp:HyperLink>
                           </ItemTemplate>
                            <ItemStyle Width="80" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Last modified">
                         <ItemTemplate>
                         <asp:Label ID="lbllastmodifiedgrd" Font-Size="8px" ForeColor="gray" runat="server" Text='<%#Eval("UpdatedDate")%>' ></asp:Label>
                           </ItemTemplate>
                             <ItemStyle Width="80" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <div style="text-align: center;" class="iSlnkHide">
                                <asp:LinkButton ForeColor="blue" Width="50px" ID="lnkDelete" runat="server" CommandName="Edit"
                                    > Update </asp:LinkButton>
                            </div>
                    
                        </ItemTemplate>
                       <ItemStyle Width="50" />
              
                    </asp:TemplateField> 
                   </Columns>
                </asp:GridView>
            </div>

            <div id="KPI" class="tabcontent" style="display:none;">
              <asp:GridView ID="grdkipedit" runat="server" rules="all" OnRowEditing="grdkipedit_RowEditing"  OnRowDataBound="grdkipedit_RowDataBound" AutoGenerateColumns="False" ShowHeader="true" OnRowCommand="grdkipedit_RowCommand" CellPadding="0" CellSpacing="0" Width="100%" class="sop_table item_list">
                   <Columns>
          
                   <asp:TemplateField HeaderText="Name">
                         <ItemTemplate>
                         <asp:TextBox ID="txtShopNameGrd" Text='<%#Eval("SOPNAME")%>' Width="98%" runat="server" CssClass="inputborder0"  MaxLength="30"></asp:TextBox>
                         <asp:HiddenField ID="hdnshopId" runat="server" Value='<%#Eval("Id")%>' />
                           </ItemTemplate>
                           <ItemStyle Width="160" />
                     </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="Type">
                         <ItemTemplate>
                             <asp:DropDownList ID="ddlType" CssClass="selectcolor" Width="100%" runat="server">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="SOP" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="KPI" Value="2"></asp:ListItem>
                                               <asp:ListItem Text="Policy" Value="3"></asp:ListItem>
                                               
                              </asp:DropDownList>
                             <asp:HiddenField ID="hdnTypeId" runat="server" Value='<%#Eval("TypeId")%>' />   
                         </ItemTemplate>
                          <ItemStyle Width="55" />
                   </asp:TemplateField>--%>
                     <asp:TemplateField HeaderText="Upload">
                         <ItemTemplate>
                         <asp:FileUpload id="fileuploadgrd" runat="server" CssClass="fileupload"  Width="58px" />
                         <asp:HiddenField ID="hdnfilename" runat="server" Value='<%#Eval("FilePath")%>' />
                         <asp:HyperLink ID="hlkViewSnap1" runat="server"  Target="_blank"> <img src="../../images/view-icon.png" style="vertical-align: middle;" /> </asp:HyperLink>
                 
                           </ItemTemplate>
                            <ItemStyle Width="80" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Last modified">
                         <ItemTemplate>
                         <asp:Label ID="lbllastmodifiedgrd" runat="server" Font-Size="8px" ForeColor="gray" Text='<%#Eval("UpdatedDate")%>' ></asp:Label>
                           </ItemTemplate>
                            <ItemStyle Width="80" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <div style="text-align: center;" class="iSlnkHide">
                                <asp:LinkButton ForeColor="blue" Width="50px" ID="lnkDelete" runat="server" CommandName="Edit"
                                    > Update </asp:LinkButton>
                            </div>
                    
                        </ItemTemplate>
                       <ItemStyle Width="50" />
              
                    </asp:TemplateField> 
                   </Columns>
                </asp:GridView>
            </div>

            <div id="Policy" class="tabcontent"  style="display:none;">
               <asp:GridView ID="grdPolicyedit" runat="server" rules="all" OnRowEditing="grdPolicyedit_RowEditing"  OnRowDataBound="grdPolicyedit_RowDataBound" AutoGenerateColumns="False" ShowHeader="true" OnRowCommand="grdPolicyedit_RowCommand" CellPadding="0" CellSpacing="0" Width="100%" class="sop_table item_list">
                   <Columns>
          
                   <asp:TemplateField HeaderText="Name">
                         <ItemTemplate>
                         <asp:TextBox ID="txtShopNameGrd" Text='<%#Eval("SOPNAME")%>' Width="98%" runat="server" CssClass="inputborder0"  MaxLength="30"></asp:TextBox>
                         <asp:HiddenField ID="hdnshopId" runat="server" Value='<%#Eval("Id")%>' />
                           </ItemTemplate>
                           <ItemStyle Width="160" />
                     </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="Type">
                         <ItemTemplate>
                             <asp:DropDownList ID="ddlType" Width="100%" CssClass="selectcolor" runat="server">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="SOP" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="KPI" Value="2"></asp:ListItem>
                                               <asp:ListItem Text="Policy" Value="3"></asp:ListItem>
                                             
                              </asp:DropDownList>
                             <asp:HiddenField ID="hdnTypeId" runat="server" Value='<%#Eval("TypeId")%>' />   
                         </ItemTemplate>
                          <ItemStyle Width="55" />
                   </asp:TemplateField>--%>
                     <asp:TemplateField HeaderText="Upload">
                         <ItemTemplate>
                         <asp:FileUpload id="fileuploadgrd" runat="server" CssClass="fileupload"  Width="58px" />
                         <asp:HiddenField ID="hdnfilename" runat="server" Value='<%#Eval("FilePath")%>' />
                         <asp:HyperLink ID="hlkViewSnap1" runat="server"  Target="_blank"> <img src="../../images/view-icon.png" style="vertical-align: middle;" /> </asp:HyperLink>
                 
                           </ItemTemplate>
                            <ItemStyle Width="80" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Last modified">
                         <ItemTemplate>
                         <asp:Label ID="lbllastmodifiedgrd" Font-Size="8px" ForeColor="gray" runat="server" Text='<%#Eval("UpdatedDate")%>' ></asp:Label>
                           </ItemTemplate>
                            <ItemStyle Width="80" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <div style="text-align: center;" class="iSlnkHide">
                                <asp:LinkButton ForeColor="blue" Width="50px" ID="lnkDelete" runat="server" CommandName="Edit"
                                    > Update </asp:LinkButton>
                            </div>
                    
                        </ItemTemplate>
                       <ItemStyle Width="50" />
              
                    </asp:TemplateField> 
                   </Columns>
                </asp:GridView>
            </div>
   </div>
   <script type="text/javascript">
       function openShop(evt, ShopName) {
           var i, tabcontent, tablinks;
           tabcontent = document.getElementsByClassName("tabcontent");
           for (i = 0; i < tabcontent.length; i++) {
               tabcontent[i].style.display = "none";
           }
           tablinks = document.getElementsByClassName("tablinks");
           for (i = 0; i < tablinks.length; i++) {
               tablinks[i].className = tablinks[i].className.replace(" active", "");
           }
           document.getElementById(ShopName).style.display = "block";
           evt.currentTarget.className += " active";
       }
</script>
