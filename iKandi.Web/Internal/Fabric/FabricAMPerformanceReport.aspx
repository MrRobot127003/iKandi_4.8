<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricAMPerformanceReport.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.FabricAMPerformanceReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <title></title>
    <style>
        .AddClass_Table
        {
            width: 100%;
        }
        .AddClass_Table th
        {
            padding: 5px 3px;
            font-size: 10px;
        }
        .minColwidth
        {
            width: 65px;
        }
        .AddClass_Table td
        {
            padding: 3px 3px;
            color: #717171;
            height: 14px;
            text-align: center;
            font-size: 10px;
        }
        .AddClass_Table td:first-child
        {
            text-align: left;
            height: 27px;
        }
        td span
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
        .AddClass_Table th.minColwidthOne
        {
            width: 30%;
        }
        .minColwidth_2
        {
            width: 25%;
        }
        .AddClass_Table td span:hover
        {
            cursor: pointer;
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
            
            }
        .ShowPORelatedDetails
        {
            display: none;
            position: absolute;
            left: -170px;
            top: 20%;
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
        
        .tdclass
        {
            position: relative;
        }
            
    </style>


    <script type="application/javascript">
        function closeAMFabButtion() {
            self.parent.Shadowbox.close();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 0 auto; width: 100%;">
        <div id="DynamicHeaderWidth" runat="server">
            <h2 style="width: 99.5%; margin: -2px auto 0px; font-weight: 500; background: #3b5998;
                color: White; text-align: center; padding: 6px 0px; line-height: 11px; height: 12px;
                font-size: 13px;" id="PopTableW">
                Fabric AM Performance Report <span style="float: right; padding-right: 5px; margin-top: 0px;
                    font-size: 14px; cursor: pointer" onclick="closeAMFabButtion()">x</span>
                <asp:HiddenField ID="hdnorderTabClose" runat="server" />
            </h2>
        </div>
        <div id="FabricperFormance" runat="server">
        </div>
    </div>
    </form>
</body>
</html>
