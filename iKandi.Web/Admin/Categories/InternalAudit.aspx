<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="InternalAudit.aspx.cs" Inherits="iKandi.Web.Admin.Categories.InternalAudit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <script src="../../js/jquery.datePicker.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/form.js"></script>
    <script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function OpenFileUpload(elem) {
             debugger;
            var datatmp = elem.id.split("_")[5];
            idval = $("#ctl00_cph_main_content_internalAuditGD_" + datatmp + "_hdnQusId").val();
            var unitId = $("[id*=rbtUnit] input:checked").val();
            sURL = 'InternalCatMultipleFileUpload.aspx?Id=' + idval + '&UnitId=' + unitId;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 290, width: 509, modal: true, animate: true, animateFade: true });
            return false;
        }
        function pageLoad() {
            var $gv = $("table[id$=internalAuditGD]");
            var $rows = $("> tbody > tr:not(:has(th, table))", $gv);
            var $inputs = $(".myDatePickerClass", $rows);
            $inputs.datepicker({
                minDate: 0,
                dateFormat: 'd M y'
            });
        }
        $(document).ready(function () {
                        var $gv = $("table[id$=internalAuditGD]");
                        var $rows = $("> tbody > tr:not(:has(th, table))", $gv);
                        var $inputs = $(".myDatePickerClass", $rows);
                        $inputs.datepicker({
                            minDate: 0,
                            dateFormat: 'd M y'
                        });
                    });
    </script>
    <style type="text/css">
        .colorPass label
        {
            position: relative;
            top: -3px;
        }
        .colorFail label
        {
            position: relative;
            top: -3px;
        }
        h2 span
        {
            color: #fff;
            background: #39589c;
            text-align: center;
            margin: 3px 0px;
            font-weight: normal;
            font-size: 15px;
        }
        .mycentertext
        {
            text-align: center;
        }
        .CommoAdmin_Table .mycentertext td
        {
            padding: 0px 0px !important;
            border: 0px;
        }
        .CommoAdmin_Table td
        {
            padding: 0px 3px;
        }
        #sb-wrapper-inner
        {
            background: #fff;
            border: 5px solid #999;
            border-radius: 4px;
        }
       select
        {
            visibility: visible !important;
            min-width: 50%;
            max-width: 97%;
            
        }
        .CategoryRadio input[type="radio"]
        {
            position:relative;
            top:2px;
         }
         .CommoAdmin_Table td[colspan="10"]
         {
             border:0px;
          }
        .CommoAdmin_Table td[colspan="10"] table td
         {
             border:0px;
          }
          .CommoAdmin_Table td[colspan="10"] table td span {
           color:Blue;
           font-weight:600; 
        }
        .CommoAdmin_Table td[colspan="10"] table td a {
           color:gray; 
           text-decoration:none;
        }
       /* .CommoAdmin_Table tr:nth-last-child(2)>td
         {
             border-bottom-color:#999 !important;
          }*/
           input[type="text"]
        {
            margin: 1px 0px;
            text-transform:capitalize !important;
        }
        .CommoAdmin_Table_margin
        {
            margin:0 auto;
            }
        .btn_center
        {
            width:1200px;
            margin:0 auto;
            }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2 style="width: 1200px; background: #39589c; border: 1px solid gray; margin: 3px 0px 2px;
                text-align: center; margin:0 auto;">
                <span style="position:relative;left:12%;">Internal Audit</span></h2>
        <table border="0" cellpadding="0" cellspacing="0" style="width:57%; margin:0 auto;"> 
        <tr>
        <td style="width: 52%;display: flex;">
           <div>
                <span class="facolor" style="display: block;margin-bottom: 10px;font-size: 14px;">Select Category: </span>
                    <asp:DropDownList ID="ddlcategory" runat="server" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged" AutoPostBack = "true">
                    </asp:DropDownList>
                    
             </div>
        </td>
           <td>
                <span style="position:relative;right:5px" class="CategoryRadio">
                    <asp:RadioButtonList ID="rbtUnit" RepeatDirection="Vertical" runat="server" OnSelectedIndexChanged="rbtUnit_SelectedIndexChanged" AutoPostBack = "true" RepeatColumns="6" style="white-space: nowrap;color: gray;border: 1px solid lightgray;margin-bottom: 10px;">
                    </asp:RadioButtonList>
                </span>
          </td>
        </tr>
        </table>
           
               <%-- <span>
                    <asp:Button ID="btnGo" runat="server" Text="Go" class="btnGo" OnClick="btnGo_Click" />
                </span>--%>
                

               
           
            <asp:GridView ID="internalAuditGD" CssClass="CommoAdmin_Table CommoAdmin_Table_margin" AllowPaging="true" OnPageIndexChanging="internalAuditGD_PageIndexChanging"
                AutoGenerateColumns="False" Width="1200px" ShowHeader="true" EmptyDataText="No records Found" PageSize="15"
                ShowHeaderWhenEmpty="True" runat="server" BorderWidth="0" OnRowDataBound="internalAuditGD_RowDataBound">
               
                <EmptyDataRowStyle CssClass="mycentertext" />
                <Columns>
                    <asp:TemplateField HeaderText="Sr. No.">
                        <ItemTemplate>
                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnId" runat="server" Value='<%# Bind("Id") %>' />
                        </ItemTemplate>
                        <ItemStyle Width="37px" CssClass="textCenter" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Details">
                        <ItemTemplate>
                            <asp:Label ID="lblDetails" runat="server" Text='<%# Bind("QuestionName") %>'></asp:Label>
                            <asp:HiddenField ID="hdnQusId" runat="server" Value='<%# Bind("CategoryQuesId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Department">
                        <ItemTemplate>
                            <asp:Label ID="lblDepartment" runat="server" Text='<%# Bind("DepartmentName") %>'></asp:Label>
                            <asp:HiddenField ID="hdnDeptId" runat="server" Value='<%# Bind("DepartmentId") %>' />
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Designation">
                        <ItemTemplate>
                            <asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("DesignationName") %>'></asp:Label>
                            <asp:HiddenField ID="hdnDesigId" runat="server" Value='<%# Bind("DesignationId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:RadioButton ID="rbtFail" CssClass="colorFail" Text='<%# Bind("Monthly_Status") %>'
                                GroupName="status" runat="server"/>
                            <asp:RadioButton ID="rbtPass" CssClass="colorPass" Text='<%# Bind("Monthly_Status") %>'
                                GroupName="status" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Previous Month Status">
                        <ItemTemplate>
                            <asp:Label ID="lblPrevMonthStatus" runat="server" Text='<%# Bind("PrevMonthStatus") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" CssClass="textCenter" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CAP Date">
                        <ItemTemplate>
                            <div style="text-align: center">
                                <asp:TextBox ID="capDuration" CssClass="myDatePickerClass" autocomplete="off" runat="server"
                                    Text='<%# Bind("CAPDuration") %>' Width="60px"></asp:TextBox>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CAP">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCAP" TextMode="MultiLine" runat="server" Text='<%# Bind("Cap") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observation">
                        <ItemTemplate>
                            <asp:TextBox ID="txtObservation" TextMode="MultiLine" runat="server" Text='<%# Bind("Observation") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="File Upload">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkFileUpload" onclick='return OpenFileUpload(this);' Style="cursor: pointer;
                                color: blue; font-size: 9px;" runat="server">File Upload & View</asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle CssClass="textCenter" Width="82px" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table style="max-width: 100%; width: 100%" border="0" cellpadding="0" cellspacing="0"
                        class="CommoAdmin_Table">
                        <tr>
                            <th>
                                Sr.No.
                            </th>
                            <th>
                                Details
                            </th>
                            <th>
                                Department
                            </th>
                            <th>
                                Designation
                            </th>
                            <th>
                                Status
                            </th>
                            <th style="width: 66px;">
                                Previous Month Status
                            </th>
                            <th>
                                Duration
                            </th>
                            <th>
                                CAP
                            </th>
                            <th>
                                Observation
                            </th>
                            <th>
                                File Upload
                            </th>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <img src="../../images/sorry.png" alt="No record found" class="ImgCenter">
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
            <div class="btn_center">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbutton" OnClick="btnSubmit_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
