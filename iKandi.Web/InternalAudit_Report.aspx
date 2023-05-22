<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalAudit_Report.aspx.cs"
    Inherits="iKandi.Web.InternalAudit_Report" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="http://192.168.0.4/js/jszip.min.js" type="text/javascript"></script>
    <script src="http://192.168.0.4/js/jquery.min.js" type="text/javascript"></script>
    <script src="http://192.168.0.4/js/kendo.all.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ExportPdf() {
            kendo.drawing.drawDOM("#innerdiv",
    {
        paperSize: "A4",
        margin: { top: "1cm", bottom: "1cm" },
        scale: 0.57,
        height: 800,
        landscape: false
    })
        .then(function (group) {
            kendo.drawing.pdf.saveAs(group, "MonthlyAuditReport.pdf");
        });
        };
    </script>
    <style type="text/css">
        @media print
        {
            #btnpdf
            {
                display: none;
            }
        }
        
        .fontsize
        {
            font-size: 12px !important;
            color: #fff;
        }
        .InternalAdminTable
        {
            border: 1px solid #999;
            border-collapse: collapse;
            font-family: "Lucida Sans Unicode";
            width: 950px;
            border-spacing: 0px;
        }
        .InternalAdminTable th
        {
            background: #e4e2e2;
            border: 1px solid #999;
            border-collapse: collapse;
            font-size: 11px;
            font-weight: 500;
            padding: 3px 3px;
            color: #272626;
            font-family: "Lucida Sans Unicode";
            color: #575759;
            text-align: center;
            border-spacing: 0px;
        }
        .InternalAdminTable td
        {
            border: 1px solid #e4e0e0;
            font-size: 11px;
            padding: 3px 3px;
            color: #272626;
            height: 12px;
            font-family: "Lucida Sans Unicode";
            color: #696868;
            border-spacing: 0px;
            line-height: 14px;
        }
        
        .InternalAdminTable td:first-child
        {
            border-left-color: #999 !important;
        }
        
        .InternalAdminTable td:last-child
        {
            border-right-color: #999 !important;
        }
        .InternalAdminTable tr:last-child > td
        {
            border-bottom-color: #999 !important;
        }
        .InternalAdminTable td input[type="text"]
        {
            width: 98%;
            height: 9px;
            font-size: 10px;
            font-family: Arial;
        }
        .textCenter
        {
            text-align: center;
        }
        .textLeft
        {
            text-align: left; /* background: yellow !important; */
        }
        
        .facolor
        {
            color: grey;
        }
        
        .selectDiv
        {
            margin: 5px 0px 5px;
        }
        .InternalAdminTable td p
        {
            color: #716e6e;
            text-decoration: none;
        }
        .InternalAdminTable td a
        {
            text-decoration: none;
        }
        .topHeading
        {
            background: #39589c;
            text-align: center;
            padding: 2px 0px;
            border: 1px solid #999;
            border-radius: 2px;
        }
        .colorDate
        {
            color: blue !important;
        }
        .colorPass
        {
            color: green !important;
        }
        .colorFail
        {
            color: red !important;
        }
        .colorFail label
        {
            position: relative;
            top: -2px;
        }
        .colorPass label
        {
            position: relative;
            top: -2px;
        }
        .btnbutton
        {
            background: green;
            color: #fff;
            border: 1px solid green;
            padding: 1px 8px;
            border-radius: 2px;
            font-size: 11px;
            font-family: Arial;
            cursor: pointer;
            margin-top: 10px;
        }
        .m-t-10
        {
            margin-top: 10px;
        }
        .blobkdis
        {
            display: block;
            line-height: 14px;
        }
        a
        {
            text-decoration: none;
        }
        select
        {
            min-width: 65px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="min-width: 950px;max-width: 950px; margin: 5px auto;">
            <div style="min-width: 867px;display: inline-block;">
                <span runat="server" id="spanDDL">Select Factory:
                    <asp:DropDownList ID="ddlUnit" Width="70px" runat="server" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp; Select Month:
                    <asp:DropDownList ID="ddlMonth" Width="87px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp; Select Year:
                    <asp:DropDownList ID="ddlYear" Width="56px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                    </asp:DropDownList>
                </span>
            </div>
                <span><span id="btnpdf"
                    class="btnbutton m-t-10" onclick="ExportPdf();">Save As Pdf</span>
                 </span>
            </div>
            <div id="innerdiv" runat="server" style="max-width: 950px; margin: 5px auto;">
                <div style="width: 948px;" class="topHeading">
                    <span class="fontsize">Internal Audit Report For </span>
                    <asp:Label ID="lblUnitName" runat="server" Font-Bold="true" ForeColor="#ffffff" Text=""></asp:Label>
                    <span style="float: right; padding-right: 3px;">
                        <%--<asp:DropDownList ID="ddlUnit" runat="server" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged" AutoPostBack = "true">
                </asp:DropDownList>--%>
                    </span>
                </div>
                <asp:Repeater ID="rpt" OnItemDataBound="rpt_ItemDataBound" runat="server">
                    <ItemTemplate>
                        <div class="selectDiv" runat="server" id="auditCatgName">
                            <span class="facolor">Category Name: </span><span>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("InternalAuditCatgName")%>'></asp:Label>
                                <asp:HiddenField ID="hdnCategoryId" runat="server" Value='<%# Bind("Id") %>' />
                            </span>
                        </div>
                        <asp:GridView ID="grv" AutoGenerateColumns="False" CssClass="InternalAdminTable"
                            runat="server" BorderWidth="0" OnRowDataBound="grv_RowDataBound" CellPadding="0"
                            CellSpacing="0">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr. No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnId" runat="server" Value='<%# Bind("Id") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="39px" CssClass="textCenter" />
                                    <HeaderStyle Width="39px" CssClass="textCenter" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Details">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDetails" ForeColor="#000" runat="server" Text='<%# Bind("QuestionName") %>'></asp:Label>
                                        <asp:HiddenField ID="hdnQusId" runat="server" Value='<%# Bind("CategoryQuesId") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle Width="180px" CssClass="textCenter" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Designation (Dept.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignation" CssClass="blobkdis" runat="server" Text='<%# Bind("DesignationName") %>'></asp:Label>
                                        <asp:HiddenField ID="hdnDesigId" runat="server" Value='<%# Bind("DesignationId") %>' />
                                        <asp:Label ID="lblDepartment" CssClass="blobkdis" runat="server" Text='<%# Bind("DepartmentName") %>'></asp:Label>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("DepartmentId") %>' />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="textCenter" />
                                    <HeaderStyle Width="115px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:RadioButton ID="rbtFail" CssClass="colorFail" Text='<%# Bind("Monthly_Status") %>'
                                            GroupName="status" runat="server" /><br />
                                        <asp:RadioButton ID="rbtPass" CssClass="colorPass" Text='<%# Bind("Monthly_Status") %>'
                                            GroupName="status" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="textCenter" />
                                    <HeaderStyle Width="55px" CssClass="textCenter" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Previous Month Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrevMonthStatus" runat="server" Text='<%# Bind("PrevMonthStatus") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="textCenter" />
                                    <HeaderStyle Width="40px" CssClass="textCenter" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CAP Date">
                                    <ItemTemplate>
                                        <asp:Label ID="capDuration" runat="server" Text='<%# Bind("CAPDuration") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="textCenter" />
                                    <HeaderStyle Width="55px" CssClass="textCenter" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CAP/Observation">
                                    <ItemTemplate>
                                        <div style="text-align: left">
                                            <b style="color: #000; font-weight: 700; display: block; margin-bottom: -3px;" id="CapHide"
                                                runat="server"></b>
                                            <asp:Label ID="lblCAP" runat="server" ForeColor="#000" Text='<%# Bind("Cap") %>'></asp:Label>
                                        </div>
                                        <div style="text-align: left">
                                            <b style="color: #000; font-weight: 700; display: block; margin-bottom: -3px;" id="ObservaHide"
                                                runat="server"></b>
                                            <asp:Label ID="lblObservation" runat="server" ForeColor="#000" Text='<%# Bind("Observation") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="textCenter" />
                                    <HeaderStyle Width="200px" CssClass="textCenter" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Audit By">
                                    <ItemTemplate>
                                        <div>
                                            <asp:Label ID="lblAuditBy" runat="server" ForeColor="#000" Text='<%# Bind("AuditBy") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="textCenter" />
                                    <HeaderStyle Width="100px" CssClass="textCenter" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Files">
                                    <ItemTemplate>
                                        <asp:Repeater ID="rptFileLink" runat="server">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="lnkFile" Target="_blank" NavigateUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("ImagePath"))) %>'
                                                    runat="server">File Link</asp:HyperLink><br />
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="textCenter" />
                                    <HeaderStyle Width="50px" CssClass="textCenter" />
                                </asp:TemplateField>
                                <%--  <asp:TemplateField HeaderText="Audit By">
                            <ItemTemplate>
                                <asp:Label ID="lblAuditBy" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="textCenter" />
                        </asp:TemplateField>--%>
                            </Columns>
                            <%-- <EmptyDataTemplate>
                        <div align="center">
                            No records found.</div>
                    </EmptyDataTemplate>--%>
                        </asp:GridView>
                    </ItemTemplate>
                </asp:Repeater>
                <%-- <asp:Button ID="btnPrint" runat="server" OnClientClick="javascript:window.print();"
            Text="Print" BackColor="Green" />--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
