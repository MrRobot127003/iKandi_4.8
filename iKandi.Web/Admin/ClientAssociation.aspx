<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientAssociation.aspx.cs" Inherits="iKandi.Web.Admin.ClientAssociation" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function CloseWin() {
            // alert('Saved successfully!');
            window.parent.Shadowbox.close();
        }
    </script>
    <style>
        .btnSubmit {
            color: rgb(255, 255, 255);
            font-size: 12px !important;
            float: left;
            font-weight: bold;
            width: 52px;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 24px;
            line-height: 23px;
            border: none !important;
            border-radius: 2px;
        }
        .btnSubmit:hover {
            color: Yellow !important;
        }
        .btnCancel {
            margin-left: 10px;
            font-size: 12px !important;
            float: left;
            color: rgb(255, 255, 255);
            font-weight: bold;
            width: 52px;
            cursor: pointer;
            background: red !important;
            height: 24px;
            line-height: 23px;
            border: none !important;
            border-radius: 2px;
        }
        .btnCancel:hover {
            color: Yellow !important;
        }
        table {
            border-collapse: collapse;
            width: 99%;
        }
        table, th, td {
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width: 100%; padding: 10px 10px; position: fixed; top: 5; background: #fff; z-index: 9; border: 3px">
            <h2 style="text-align: center">
                <asp:Label ID="lblModeName" runat="server"></asp:Label>
            </h2>
            <h3>
            <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="True" 
                    oncheckedchanged="chkSelectAll_CheckedChanged" Text="Select All"/></h3>
            <asp:CheckBoxList ID="chkClientAssociation" runat="server" RepeatColumns="6" RepeatDirection="Vertical" RepeatLayout="Table">
            </asp:CheckBoxList>
            <br />
            <br />
            <asp:Button ID="BtnSaveClientAssoc" runat="server" Text="Save" CssClass="btnSubmit" OnClick="BtnSaveClientAssoc_Click" />
            <input type="button" id="btnClose" value="close" onclick="CloseWin();" class="btnCancel" />
        </div>
    </div>
    </form>
</body>
</html>
