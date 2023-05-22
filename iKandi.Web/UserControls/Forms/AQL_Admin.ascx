<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AQL_Admin.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.AQL_Admin" %>


<link href="../../css/report.css" rel="stylesheet" type="text/css" />
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .border2 th
    {
        font-weight: bold !important;
        padding: 4px;
        text-align: center;
    }
    .border2 td
    {
        padding: 2px;
        text-align: center;
    }
    .border2 td input
    {
        width: 70%;
    }
    .final_select_text
    {
        float: left;
        width: 66%;
    }
    
    .error
    {
        border: 1px solid;
    
        border-color: #FF0000; /* Red */
    }
    .yy
    {
       background-color:#39589c;
    }
    
       #AQL_Admin1_grdAQL input[type="text"], textarea {
    border: 1px solid #cccccc;
    color: #666;
    font-family: Verdana,sans-serif,Aparajita;
    font-size: 12px;
    height: 15px;
    text-transform: capitalize;
    width: 90%;
}
#AQL_Admin1_grdAQL td
{
    text-align:center;
}
#AQL_Admin1_UP div
{
    background:#fff !important;
    padding:0px 0px 10px;
    width:100% !important;
    
}
#AQL_Admin1_grdAQL
{
    width:99.8% !important;
    
}
.AddClass_Table 
{
    margin-left:1px;
 }
.AddClass_Table td
    {
        padding: 5px 3px;
    }
</style>
<script type="text/javascript">
    






</script>

<asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UP" runat="server">
<ContentTemplate>


     <div style="width:100%; vertical-align:top;" >
           <div class="form_heading" id="divheading" runat="server">
               AQL Admin
           </div>  
           
            <div id="divAqlfilter" runat="server" style="width:800px; vertical-align:top; margin:10px 0px;" >
            <div class="final_select_text" runat="server" id="divfinal"> 
            <asp:Label ID="lblExistingAQL" Text="Existing AQL" runat="server" ></asp:Label>
              <asp:DropDownList ID="ddlExistingAQL"   
                         Width="100px" runat="server"></asp:DropDownList>

                          <asp:Button ID="btnGO"  
                         runat="server" onclick="btnGO_Click" CssClass="go" Text="Search" />

                         <asp:TextBox ID="txtAddNew"  runat="server"></asp:TextBox>

                         <asp:Button ID="btnAddNew" runat="server" onclick="btnAddNew_Click" CssClass="add da_submit_button" Text="Add"  />
            
            </div>
            <div style="float:left; width:30%">  <asp:RadioButton ID="rdofinal" AutoPostBack="true" Text="Final" runat="server" Checked="true" 
                          GroupName="abhishek" oncheckedchanged="rdofinal_CheckedChanged" />
              <asp:RadioButton ID="rdomid" runat="server" AutoPostBack="true" text="Mid/Online" GroupName="abhishek" 
                          oncheckedchanged="rdomid_CheckedChanged"  />
                 <asp:RadioButton ID="rdoinline" runat="server" AutoPostBack="true" text="InLine" GroupName="abhishek" oncheckedchanged="rdoinline_CheckedChanged" 
                            />          
                           </div>
            <div style="clear:both"></div>
            </div>   
       
         <asp:GridView ID="grdAQL" runat="server"  AutoGenerateColumns="false" 
          Width="100%" onrowcreated="grdAQL_RowCreated" 
               onrowdatabound="grdAQL_RowDataBound" CssClass="AddClass_Table" ShowHeader="False" >
              
         <Columns>
         
          <asp:TemplateField HeaderText="AQLType">
            <ItemTemplate>
                    <asp:HiddenField ID="hdnRangeId" runat="server" Value='<%#Eval("RangeId") %>' />
                    <asp:TextBox ID="txtAQLType" style="text-align:center;" runat="server" BorderStyle="None" Text='<%#Eval("AQLType")%>'></asp:TextBox>                         
            </ItemTemplate>           
          </asp:TemplateField>
        
            <asp:TemplateField HeaderText="SampleSizeFrom">
            <ItemTemplate>
                    <asp:TextBox ID="txtSampleSizeFrom" style="text-align:center;" BorderStyle="None" runat="server"  Text='<%#Eval("SampleSizeFrom")%>'></asp:TextBox>                         
            </ItemTemplate>           
          </asp:TemplateField>
          
              <asp:TemplateField HeaderText="SampleSizeTo">
            <ItemTemplate>
                    <asp:TextBox ID="txtSampleSizeTo" style="text-align:center;" BorderStyle="None" runat="server"  Text='<%#Eval("SampleSizeTo")%>'></asp:TextBox>                         
            </ItemTemplate>           
          </asp:TemplateField>
        
            <asp:TemplateField HeaderText="SampleSize">
            <ItemTemplate>
                    <asp:TextBox ID="txtSampleSize" style="text-align:center;" BorderStyle="None"  runat="server"  Text='<%#Eval("SampleSize")%>'></asp:TextBox>                         
            </ItemTemplate>           
          </asp:TemplateField>
          
              <asp:TemplateField HeaderText="MajorDefectsPass">
            <ItemTemplate>
                    <asp:TextBox ID="txtMajorDefectsPass" style="text-align:center;" BorderStyle="None" runat="server" class="textbox" Text='<%#Eval("MajorDefectsPass")%>'></asp:TextBox>                         
            </ItemTemplate>           
          </asp:TemplateField>
          
              <asp:TemplateField HeaderText="MajorDefectsFail">
            <ItemTemplate>
                    <asp:TextBox ID="txtMajorDefectsFail" style="text-align:center;" BorderStyle="None" runat="server" class="textbox" Text='<%#Eval("MajorDefectsFail")%>'></asp:TextBox>                         
            </ItemTemplate>           
          </asp:TemplateField>
          
              <asp:TemplateField HeaderText="MinorDefectsPass">
            <ItemTemplate>
                    <asp:TextBox ID="txtMinorDefectsPass" style="text-align:center;" BorderStyle="None" runat="server" class="textbox" Text='<%#Eval("MinorDefectsPass")%>'></asp:TextBox>                         
            </ItemTemplate>           
          </asp:TemplateField>
          
            <asp:TemplateField HeaderText="MinorDefectsFail">
            <ItemTemplate>
                    <asp:TextBox ID="txtMinorDefectsFail" style="text-align:center;" BorderStyle="None" runat="server" class="textbox" Text='<%#Eval("MinorDefectsFail")%>'></asp:TextBox>                         
            </ItemTemplate>           
          </asp:TemplateField>
        
        
         </Columns>         
         </asp:GridView>
       <div>
       
           <asp:Button ID="btnClose" runat="server" Visible="false" CssClass="close da_submit_button" style="margin-left:1px;" Text="Close" Width="86px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
           <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click"  Text="Save" CssClass="save da_submit_button" Visible="false" />
       </div>
               
                          
     </div>
    <div id="DivMidLine" runat="server" visible="false">
        <table cellpadding="0" cellspacing="0" border="1" class="border2" style="width:800px">
            <thead>
                <tr>
                    <th rowspan="2">
                        AQL SAMPLE SIZEfghfd
                    </th>
                    <th colspan="2">
                        MAJOR DEFECTS
                    </th>
                    <th colspan="2">
                        MINOR DEFECTS
                    </th>
                </tr>
                <tr>
                    <th>
                        PASS
                    </th>
                    <th>
                        FAIL
                    </th>
                    <th>
                        PASS
                    </th>
                    <th>
                        FAIL
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <asp:TextBox ID="txtSampleSize" MaxLength="6" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator runat="server" id="reqSampleSize" controltovalidate="txtSampleSize"  Display="Dynamic" ValidationGroup="NumericValidate" errormessage="Please enter Sample Size value!" />
                        
                        <asp:RegularExpressionValidator ID="SampleSize" runat="server" ControlToValidate="txtSampleSize"  Display="Dynamic"
                            ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"
                            ValidationGroup="NumericValidate">
                        </asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="MajorPass" MaxLength="6" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" Display="Dynamic" controltovalidate="MajorPass"  ValidationGroup="NumericValidate" errormessage="Please enter Major Pass value!" />
                          <asp:RegularExpressionValidator ID="RegularMajorPass" runat="server" Display="Dynamic" ControlToValidate="MajorPass"
                            ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"
                            ValidationGroup="NumericValidate">
                        </asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="MajorFail" MaxLength="6" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="MajorFail" Display="Dynamic"  ValidationGroup="NumericValidate" errormessage="Please enter Major Fail value!" />
                        <asp:RegularExpressionValidator ID="RegularMajorFail" runat="server" ControlToValidate="MajorFail" Display="Dynamic"
                            ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"
                            ValidationGroup="NumericValidate">
                        </asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="MinorPass" MaxLength="6" runat="server"></asp:TextBox>
                        <br />
                         <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" controltovalidate="MinorPass" Display="Dynamic"  ValidationGroup="NumericValidate" errormessage="Please enter Major Fail value!" />
                        <asp:RegularExpressionValidator ID="RegularMinorPass" runat="server" ControlToValidate="MinorPass" Display="Dynamic"
                            ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"
                            ValidationGroup="NumericValidate"> </asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="MinorFail" MaxLength="6" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator4" controltovalidate="MinorFail" Display="Dynamic"  ValidationGroup="NumericValidate" errormessage="Please enter Minor Fail value!" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="MinorFail" Display="Dynamic"
                            ErrorMessage="Only numeric allowed." ForeColor="Red" ValidationExpression="^[0-9]*$"
                            ValidationGroup="NumericValidate"> </asp:RegularExpressionValidator>
                    </td>
                </tr>
            </tbody>
        </table>
        <br />
        <asp:Button ID="btnsavemid" runat="server" ValidationGroup="NumericValidate" 
            CssClass="save da_submit_button" Text="Save" Visible="true" onclick="btnsavemid_Click" />
    </div>
      
               
     
</ContentTemplate>
</asp:UpdatePanel>
