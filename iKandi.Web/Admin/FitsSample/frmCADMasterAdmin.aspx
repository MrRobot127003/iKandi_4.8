<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCADMasterAdmin.aspx.cs"
    Inherits="iKandi.Web.Admin.FitsSample.frmCADMasterAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            font-family: arial, halvetica;
            font-size: 12px;
        }
        
        .clroxxbutton
        {
            background-image: url(../../images/del-butt.png);
            height: 17px;
            width: 17px;
            border: 0px;
        }
        .addbuyyon
        {
            background-image: url(../../images/add-butt.png);
            height: 17px;
            width: 17px;
            border: 0px;
        }
        .editbutton
        {
            background-image: url(../../App_Themes/ikandi/images/editIcon.gif);
            height: 23px;
            width: 23px;
        }
        select, input
        {
            padding: 5px;
        }
        select
        {
            border-radius: 5px;
            padding: 5px;
            border: 1px solid gray;
            text-transform: capitalize;
        }
        
        .button-move
        {
            padding: 0px;
            width: 80%;
            margin: 1px 0px;
        }
        .button-move1
        {
            padding: 0px;
            width: 25px;
            height: 30px;
            vertical-align: top;
        }
        .checkbox_checked input
        {
            vertical-align: middle;
            margin-bottom: 5px;
        }
        .checkbox_checked
        {
            position:relative;
            top:1px;
         }
        .plus
        {
            background-image: url(../../App_Themes/ikandi/images/plus_icon.gif);
            height: 8px;
            width: 8px;
            border: 0px;
        }
        .minus
        {
            background-image: url(../../App_Themes/ikandi/images/minus_icon.gif);
            height: 8px;
            width: 8px;
        }
        input[type=text]
        {
            font-size: 11px !important;
            height: 12px!important;
            font-family: arial!important;
            border-radius: 3px!important;
        }
       Select
        {
            font-size: 11px !important;
            height: 24px;
            font-family: arial!important;
            border-radius: 3px!important;
            overflow: auto;
            margin: 1px 0px;
        }
        .font td {
    border: 1px solid #e4e1e1;
    color: Gray;
    font-size: 11px;
}
#grdMasterType td:first-child
{
    border-left-color:#999 !important;
 }
 #grdMasterType td:last-child
{
    border-right-color:#999 !important;
 }
 #grdMasterType tr:last-child > td
{
    border-bottom-color:#999 !important;
 }
 .submit
 {
     cursor:pointer;
     border-radius:2px;
  }
    </style>
    <script src="../../CommonJquery/JqueryLibrary/jquery.min.js" type="text/javascript"></script>
    <script src="../../CommonJquery/JqueryLibrary/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        //        $(document).ready(
        //            function () {
        //                $('#btnAdd').click(
        //                    function (e) {
        //                        $('#list1 > option:selected').appendTo('#list2');
        //                       
        //                       
        //                        e.preventDefault();
        //                    });

        //                $('#btnAddAll').click(
        //                function (e) {
        //                    $('#list1 > option').appendTo('#list2');
        //                    e.preventDefault();
        //                });

        //                $('#btnRemove').click(
        //                function (e) {
        //                    $('#list2 > option:selected').appendTo('#list1');
        //                    e.preventDefault();
        //                });

        //                $('#btnRemoveAll').click(
        //                function (e) {
        //                    $('#list2 > option').appendTo('#list1');
        //                    e.preventDefault();
        //                });



        //                $('#btnAdd2').click(
        //                    function (e) {
        //                        $('#list1 > option:selected').appendTo('#list3');
        //                        e.preventDefault();
        //                    });

        //                $('#btnAddAll2').click(
        //                function (e) {
        //                    $('#list1 > option').appendTo('#list3');
        //                    e.preventDefault();
        //                });

        //                $('#btnRemove2').click(
        //                function (e) {
        //                    $('#list3 > option:selected').appendTo('#list1');
        //                    e.preventDefault();
        //                });

        //                $('#btnRemoveAll2').click(
        //                function (e) {
        //                    $('#list3 > option').appendTo('#list1');
        //                    e.preventDefault();
        //                });



        //                $('#btnAdd3').click(
        //                    function (e) {
        //                        $('#list2 > option:selected').appendTo('#list3');
        //                        e.preventDefault();
        //                    });

        //                $('#btnAddAll3').click(
        //                function (e) {
        //                    $('#list2 > option').appendTo('#list3');
        //                    e.preventDefault();
        //                });

        //                $('#btnRemove3').click(
        //                function (e) {
        //                    $('#list3 > option:selected').appendTo('#list2');
        //                    e.preventDefault();
        //                });

        //                $('#btnRemoveAll3').click(
        //                function (e) {
        //                    $('#list3 > option').appendTo('#list2');
        //                    e.preventDefault();
        //                });

        //            });

                    


                    

    </script>
    <%--<script type="text/javascript">

        function showalert() {
           alert('You can t deactivate due to existing allocation!');
        }
</script>--%>
</head>
<body style="background-color: #F8F8FF;">
    <form id="form1" runat="server">
    <div>
        <h2 style="width: 598px; background: #39589c; color: white; text-align: center; font-size: 15px;
                padding: 3px 0px; margin: 3px auto;">
            Fits Master Admin</h2>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table cellpadding="0" cellspacing="0" style="width: 500px" align="center">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%" align="center">
                                <tr>
                                    <td style="width: 170px;">
                                        <asp:TextBox ID="txtMasterName" MaxLength="50" Style="text-transform: capitalize;"
                                            CssClass="mastertxt" runat="server" placeholder="Enter MasterName"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ValidationGroup="master"
                                            ControlToValidate="txtMasterName" runat="server" ErrorMessage="Enter master name"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                                            ValidationGroup="master" runat="server" ControlToValidate="txtMasterName" ValidationExpression="[a-zA-Z ]*$"
                                            ErrorMessage="*Valid characters: Alphabets and space." />
                                    </td>
                                    <td style="width: 204px;">
                                        <asp:DropDownList ID="ddlMastertype" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="master"
                                            runat="server" ControlToValidate="ddlMastertype" ErrorMessage="select type!"
                                            InitialValue="-1"></asp:RequiredFieldValidator>
                                    </td>
                                    <td style="text-align:left">
                                        <asp:Button ID="btnAddMAster" runat="server" ValidationGroup="master" Text="Add"
                                            CssClass="submit" OnClick="btnAddMAster_Click" />
                                    </td>
                                </tr>
                            </table>
                         
                            <table cellpadding="0" cellspacing="0" border="1" width="100%" class="item_list" style="margin-top:5px;">
                                <tr>
                                    <th width="27px">
                                        <asp:Button ID="btnopen" Visible="false" runat="server" OnClick="btnopen_Click" CssClass="plus" />
                                        <asp:Button ID="btnclose" Visible="false" runat="server" CssClass="minus" OnClick="btnclose_Click" />
                                    </th>
                                    <th width="250px">
                                        Master Name
                                    </th>
                                    <th width="200px">
                                        Master Type
                                    </th>
                                </tr>
                            </table>
                            <asp:GridView ID="grdMasterType" Visible="false" AllowPaging="false" runat="server"
                                CssClass="font" ShowHeader="false" AutoGenerateColumns="False" Width="100%" HeaderStyle-CssClass="border2"
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="13px" OnRowDataBound="grdMasterType_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderStyle Width="25px" />
                                        <HeaderTemplate>
                                            <asp:Image ID="imgTab" onclick="javascript:Toggle(this);" runat="server" ImageUrl="../../App_Themes/ikandi/images/minus_icon.gif"
                                                ToolTip="Collapse" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="25px" BackColor="White" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Master Name">
                                        <ItemTemplate>
                                            <div style="padding-left: 10px; text-transform: capitalize;">
                                                <asp:Label runat="server" ID="lblMAterName" Text='<%#Eval("Name")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnmasterid" runat="server" Value='<%#Eval("ID")%>' />
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Width="250px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Master Type">
                                        <ItemTemplate>
                                            <div style="padding-left: 10px; text-transform: capitalize;">
                                                <asp:DropDownList ID="ddlMasterTypeType" OnSelectedIndexChanged="ddlMasterTypeType_SelectedIndexChanged"
                                                    AutoPostBack="true" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Width="200px" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />
                                <EmptyDataTemplate>
                                    N/A
                                </EmptyDataTemplate>
                            </asp:GridView>
                           
                            <table width="600px" border="0" cellpadding="0" cellspacing="0"  style="margin-top:5px;">
                                <tr>
                                    <td width="40px">
                                        <b>Name</b>
                                    </td>
                                    <td width="130px">
                                        <asp:DropDownList ID="ddlcadmaster" runat="server" AutoPostBack="True" Width="100%"
                                            OnSelectedIndexChanged="ddlcadmaster_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="100px">
                                        &nbsp;
                                        <asp:Label runat="server" Visible="false" ID="lblTailor" Text="Tailor name" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td width="70px">
                                        <asp:CheckBox runat="server" ID="chkdeactivate" Visible="false" TextAlign="Left"
                                            Text="Is Active" CssClass="checkbox_checked" AutoPostBack="true" OnCheckedChanged="chkdeactivate_CheckedChanged"
                                            Checked="true" />
                                        <%--<asp:Button ID="btndeactivate" runat="server" CssClass="clroxxbutton" OnClick="btndeactivate_Click" />--%>
                                        <%--<asp:Button ID="btnactivatemaster" runat="server" CssClass="addbuyyon" OnClick="btnactivatemaster_Click" />--%>
                                        <asp:Button ID="btnreplace" runat="server" Visible="false" CssClass="editbutton"
                                            OnClick="btnreplace_Click" />
                                    </td>
                                    <td style="width: 260px;">
                                        <asp:Label ID="lblerrormsg" Font-Size="11px" runat="server" Visible="false" ForeColor="Red"
                                            Text="*You can't deactivate due to existing allocation!"></asp:Label>
                                        <div id="divreplace" runat="server" visible="false">
                                            Replace with
                                            <asp:DropDownList ID="ddlreplacemaster" runat="server" Width="180px">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            
                            <table cellpadding="0" cellspacing="0" width="100%" align="center" style="margin-top:5px;">
                                <asp:Panel ID="pnlcad" runat="server" Visible="false">
                                    <tr>
                                        <td align="left">
                                            <b>Client List</b>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <b>Primary Client </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="4" width="250px">
                                            <asp:ListBox ID="list1" SelectionMode="Multiple" runat="server" Width="250px" Height="275px">
                                            </asp:ListBox>
                                        </td>
                                        <td rowspan="2" valign="top" align="center" width="50px">
                                            <asp:Button ID="btnAdds" runat="server" OnClick="btnAdds_Click" Text="&#62;" class="button-move" />
                                            <br />
                                            <asp:Button ID="btnAddAlls" runat="server" OnClick="btnAddAlls_Click" Text="&#62;&#62;"
                                                class="button-move" />
                                            <br />
                                            <asp:Button ID="btnRemoves" runat="server" OnClick="btnRemoves_Click" Text="&#60;"
                                                class="button-move" />
                                            <br />
                                            <asp:Button ID="btnRemoveAlls" runat="server" OnClick="btnRemoveAlls_Click" Text="&#60;&#60;"
                                                class="button-move" />
                                        </td>
                                        <td valign="top">
                                            <asp:ListBox ID="list2" EnableViewState="true" SelectionMode="Multiple" runat="server"
                                                Width="300px" Height="100px"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">
                                            <%--
                <asp:Button  runat="server"  id="btnAdd3" value=">" />  
                <asp:Button  runat="server"  id="btnAddAll3" value=">>" />  
                <asp:Button  runat="server"  id="btnRemove3" value="<"/>  
                <asp:Button  runat="server"  id="btnRemoveAll3" value="<<"/> --%>
                                            <div>
                                                <asp:Button ID="btnAdd3s" runat="server" OnClick="btnAdd3s_Click" Text="&#x2C5;"
                                                    class="button-move1" />
                                                <asp:Button ID="btnAddAll3s" runat="server" Text="&#x2C5;&#x00A;&#x2C5;" Style="line-height: 8px;"
                                                    class="button-move1" OnClick="btnAddAll3s_Click" />
                                                <asp:Button ID="btnRemove3s" runat="server" Text="&#x2C4;" OnClick="btnRemove3s_Click"
                                                    class="button-move1" />
                                                <asp:Button ID="btnRemoveAll3s" runat="server" Text="&#x2C4;&#x00A;&#x2C4;" class="button-move1"
                                                    Style="line-height: 8px;" OnClick="btnRemoveAll3s_Click" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2" valign="bottom" align="center">
                                            <asp:Button ID="btnAdd2s" runat="server" OnClick="btnAdd2s_Click" Text="&#62;" class="button-move" />
                                            <br />
                                            <asp:Button ID="btnAddAll2s" runat="server" OnClick="btnAddAll2s_Click" Text="&#62;&#62;"
                                                class="button-move" />
                                            <br />
                                            <asp:Button ID="btnRemove2s" runat="server" OnClick="btnRemove2s_Click" Text="&#60;"
                                                class="button-move" />
                                            <br />
                                            <asp:Button ID="btnRemoveAll2s" runat="server" OnClick="btnRemoveAll2s_Click" Text="&#60;&#60;"
                                                class="button-move" />
                                        </td>
                                        <td>
                                            <b>Secondary Client </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom">
                                            <asp:ListBox ID="list3" SelectionMode="Multiple" AppendDataBoundItems="true" runat="server"
                                                Width="300px" Height="100px"></asp:ListBox>
                                        </td>
                                    </tr>
                                </asp:Panel>
                               
                                <tr>
                                    <td height="30px">
                                        <asp:Button ID="btnsubmit" Text="Submit" runat="server" CssClass="submit" OnClick="btnsubmit_Click" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
