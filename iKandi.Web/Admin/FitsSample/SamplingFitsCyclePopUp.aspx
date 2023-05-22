<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SamplingFitsCyclePopUp.aspx.cs"
    Inherits="iKandi.Web.Admin.FitsSample.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../CommonJquery/JqueryLibrary/jquery.min.js" type="text/javascript"></script>
    <script src="../../CommonJquery/JqueryLibrary/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function CheckValida(elem) {
            if (elem.value == "Select") {
                alert("Please select sample request first!");
                elem.value = elem.defaultValue;
                return false;
            }
        }
    </script>
</head>
<style type="text/css">
    body
    {
        font-family: verdana;
        font-size: 10px;
    }
    table
    {
        font-family: arial, halvetica;
        border-color: gray;
        border-collapse: collapse;
    }
    .item_list TH
    {
        border-color: #999;
    }
    .item_list TD
    {
        text-align: center;
        border: 1px solid #e1e0e0;
        padding: 4px 0px !important;
        background-color: none !important;
        text-transform: capitalize;
    }
    .item_list TD:first-child
    {
        border-left-color:#999 !important;
    }
     .item_list TD:last-child
    {
        border-right-color:#999 !important;
    }
     .item_list tr:nth-last-child(1)>td
    {
        border-bottom-color:#999 !important;
    }
    .foo-back
    {
        background: #f5f2f1;
    }
    .gray
    {
        color: gray;
    }
    input
    {
        height: 18px;
    }
    .blank-item
    {
        color: gray;
    }
    select
    {
        font-size: 11px;
        width: 80%;
        border: 1px solid gray;
    }
    textarea
    {
        width: 70%;
    }
    
    
    select
    {
        text-transform: capitalize;
        width: 95% !important;
    }
    
    .Hide
    {
        display: none;
    }
    
    .headStyle
    {
        background: #3a5795;
        padding: 5px 0px 5px 5px;
        color: White;
        width: 345px;
        margin-top: 10px;
    }
    .headStyle span
    {
        color: #d9dff3;
    }
    .Headertext
    {
        background: #dddfe4;
        padding: 5px 0px;
        color: #575759 !important;
        margin: 0px;
        margin: 0px;
        font-family: Arial;
        font-size: 10px;
        text-align: center;
        width: 348px;
        border: 1px solid #b7b4b4;
        border-bottom: none;
        text-transform: capitalize;
    }
    #divpattern
    {
        width: 350px;
        margin: 0px auto;
    }
    th
    {
        text-transform: capitalize !important;
        padding: 2px 5px !important;
    }
    .submit
    {
        border-radius:2px;
        cursor:pointer;
     }
</style>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="divpattern" runat="server">
                <div class="headStyle">
                    <b>Style No:- </b>
                    <asp:Label runat="server" ID="lblStyleNo"> </asp:Label>
                </div>
                <div id="divheaderpattern" runat="server" style="margin-top: 5px">
                    <h2 class="Headertext">
                        Ref./Production pattern after STC(Before 20% pcs cut)</h2>
                    <asp:GridView runat="server" ID="grdsamplebefore" RowStyle-ForeColor="Gray" CssClass="item_list"
                        AutoGenerateColumns="false" AllowPaging="true" Width="350px" OnRowDataBound="grdsamplebefore_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderStyle-Width="250px" HeaderText="PD">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlrequestsample" onchange="CheckValida(this);" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlrequestsample_SelectedIndexChanged" Enabled="false"
                                        runat="server">
                                        <asp:ListItem Selected="True" Value="Select">Select</asp:ListItem>
                                        <asp:ListItem Value="Ref. sample 1">Ref. sample 1</asp:ListItem>
                                        <asp:ListItem Value="Ref. sample 2">Ref. sample 2</asp:ListItem>
                                        <asp:ListItem Value="Ref. sample 3">Ref. sample 3</asp:ListItem>
                                        <asp:ListItem Value="Ref. sample 4">Ref. sample 4</asp:ListItem>
                                        <asp:ListItem Value="Ref. sample 5">Ref. sample 5</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("FitsRequest_AfterSTCApproved") %>' />
                                    <asp:HiddenField ID="hdnrequestsample" runat="server" Value='<%# Eval("ReqSample") %>' />
                                </ItemTemplate>
                                <ItemStyle VerticalAlign="Top" CssClass="mar-remove" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Pattern Ready">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkPatternReady" Enabled="false" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                                <ItemStyle CssClass="gray F8" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Sample Sent">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkSampleSent" Enabled="false" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                                <ItemStyle CssClass="gray F8" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div runat="server" id="proddiv" style="margin-top: 5px">
                    <h2 class="Headertext">
                        Production pattern</h2>
                    <asp:GridView runat="server" ID="grdProdSetCycle" RowStyle-ForeColor="Gray" CssClass="item_list"
                        AutoGenerateColumns="false" AllowPaging="true" Width="350px" OnRowDataBound="grdProdSetCycle_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderStyle-Width="250px" HeaderText="PPC Exec.">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlrequestProduction" onchange="CheckValida(this);" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlrequestProduction_SelectedIndexChanged" Enabled="false"
                                        runat="server">
                                        <asp:ListItem Selected="True" Value="Select">Select</asp:ListItem>
                                        <asp:ListItem Value="Production Pattern 1">Production Pattern 1</asp:ListItem>
                                        <asp:ListItem Value="Production Pattern 2">Production Pattern 2</asp:ListItem>
                                        <asp:ListItem Value="Production Pattern 3">Production Pattern 3</asp:ListItem>
                                        <asp:ListItem Value="Production Pattern 4">Production Pattern 4</asp:ListItem>
                                        <asp:ListItem Value="Production Pattern 5">Production Pattern 5</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("FitsRequest_AfterSTCApproved") %>' />
                                    <asp:HiddenField ID="hdnrequestsample" runat="server" Value='<%# Eval("ReqSample") %>' />
                                </ItemTemplate>
                                <ItemStyle VerticalAlign="Top" CssClass="mar-remove" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Pattern Ready">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkPatternReady" Enabled="false" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                                <ItemStyle CssClass="gray F8" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
                <asp:Button ID="btnsubmit" Text="Submit" runat="server" Height="24px" CssClass="submit"
                    OnClick="btnsubmit_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
