<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryAMPerformanceReport.aspx.cs"
    Inherits="iKandi.Web.Internal.Accessory.AccessoryAMPerformanceReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../../css/report.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .AddClass_Table td:first-child
    {
        text-align: left;
        height: 35px;
        color: gray;
    }
    .AddClass_Table
    {
        position: relative;
    }
    td > span > span
    {
        color: Blue;
    }
    .AddClass_Table td:nth-child(2)
    {
        color: #4c4a4a;
    }
    .AddClass_Table td:nth-child(3)
    {
        color: #191818;
    }
    .AddClass_Table td:nth-child(4)
    {
        color: #090909;
    }
    .AddClass_Table td:nth-child(5)
    {
        color: #000;
    }
    .AddClass_Table th
    {
        padding: 7px 3px;
        font-size: 10px;
    }
    .AddClass_Table
    {
        width: 100%;
    }
    .AddClass_Table td
    {
        font-size: 10px;
        text-align: center;
        position:relative;
    }
    
        .AddClass_Table .AM_Performance_Report_ToolTip tr th
        {
            text-align:center;
            background-color:#A5E5FF;
            border:1px solid #b9edff;
            color:Black;
            
        }
        .AddClass_Table .AM_Performance_Report_ToolTip tr td
        {
            text-align:center;
            border:1px solid #b9edff;
            color:#6b6464;
            padding: 0 5px;
            height:25px;
            }
        .ShowPORelatedDetails
        {
            display: none;
            position: absolute;
            left: -205px;
            top: 40%;
            background-color: white;
            z-index: 999;
            border:1px solid #b9edff;
            box-shadow: 2px 3px 6px 2px #cccc;
                }
        .ShowPORelatedDetails::after
        {
            content: '';
            position: absolute;
            right: -10px;
            top: 0;
            border-top: 10px solid transparent;
            border-bottom: 10px solid transparent;
            border-left: 10px solid #A5E5FF;
            
            }
        
        .AMPerformanceToolTip:hover + .ShowPORelatedDetails
        {
            display: block !important;
        }
    .ValueWidth
    {
        position: relative;
    }
    
    
  ::-webkit-scrollbar-track
{
	-webkit-box-shadow: inset 0 0 6px rgba(0,0,0,0.3);
	border-radius: 10px;
	background-color: #F5F5F5;
}
    ::-webkit-scrollbar
    {
    width: 8px;
	background-color: #F5F5F5;
        }
        
  ::-webkit-scrollbar-thumb
{
	border-radius: 10px;
	-webkit-box-shadow: inset 0 0 6px rgba(0,0,0,.3);
	background-color: gray;
}
</style>
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">

        function closeAMFabButtion() {
            self.parent.Shadowbox.close();
        }
    </script>
    <form id="form1" runat="server">
    <div style="margin: 0 auto; width: 100%;">
        <div id="DynamicHeaderWidth" runat="server">
            <h2 style="width: 99.5%; margin: -2px auto 0px; font-weight: 500; background: #3b5998;
                color: White; text-align: center; padding: 6px 0px; line-height: 11px; height: 12px;
                font-size: 13px;" id="PopTableW">
                Accessory AM Performance Report <span style="float: right; padding-right: 5px; margin-top: 0px;
                    font-size: 14px; cursor: pointer" onclick="closeAMFabButtion()">x</span>
                <asp:HiddenField ID="hdnorderTabClose" runat="server" />
            </h2>
        </div>
        <asp:GridView ID="grdFinish" runat="server" CssClass="AddClass_Table" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblTitle" Text='<%# Eval("Title") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="TitleWidth" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblFinishValue" Text='<%# Eval("Finished") == "01 Jan (Mon)" ? "" : Eval("Finished") %>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="ValueWidth" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:GridView ID="grdGriegePrintDyed" CssClass="AddClass_Table" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblGriegeTitle" Text='<%# Eval("Title") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="TitleWidthPri" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Greige">
                    <ItemTemplate>
                        <asp:Label ID="lblGriege" Text='<%# Eval("Finished") == "01 Jan (Mon)" ? "" : Eval("Finished") %>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="ValueWidthGri" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Process">
                    <ItemTemplate>
                        <asp:Label ID="lblGriegePrint" Text='<%# Eval("Finished_2") == "01 Jan (Mon)" ? "" : Eval("Finished_2") %>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="ValueWidthPri" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
