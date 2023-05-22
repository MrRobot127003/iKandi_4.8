<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserAccountInformation.ascx.cs"
    Inherits="iKandi.Web.UserAccountInformation" %>
<style type="text/css">
    .dashboard_accountText
    {
        font: bold 12px Arial, Helvetica, sans-serif;
        color: #212121;
        text-align: left;
        text-decoration: none;
        text-transform: capitalize;
        float: left;
    }
    .dashboard_subaccountText
    {
        font: normal 11px/13px Arial, Helvetica, sans-serif;
        color: #212121;
        text-align: left;
        text-decoration: none;
        text-transform: capitalize;
        float: left;
    }
    .dashboard_accountText_headings
    {
        font: bold 12px/13px Arial, Helvetica, sans-serif;
        color: #212121;
        text-align: left;
        text-decoration: none;
        text-transform: uppercase;
    }
    .dashboard_edit_delete_link
    {
        font: bold 10px/7px Arial, Helvetica, sans-serif;
        color: #1e23f1;
        text-align: left;
        text-decoration: none;
        text-transform: none;
        background: #fafafa;
        width: auto;
        border: none;
        cursor: pointer;
    }
    .dashboard_edit_delete_link a:hover
    {
        color: #1e23f1;
        text-decoration: none;
        text-transform: none;
        background: #f0f0f0;
        width: auto;
        cursor: pointer;
        border: none;
    }
    .dashboard-holiday-app-tbl th
    {
        border: solid 1px #dbdbdb;
        background: #fafafa;
        font: bold 10px/16px Arial, Helvetica, sans-serif;
        color: #000000;
        text-align: center;
        text-decoration: none;
        text-transform: uppercase;
    }
    .dashboard-holiday-app-tbl td
    {
        border: solid 1px #dbdbdb;
        font: normal 9px/16px Arial, Helvetica, sans-serif;
        color: #000000;
        background: #fff;
        text-align: center;
        text-decoration: none;
        text-transform: uppercase;
    }
    #div1
    {
        width: 170px;
        display: none;
        padding: 3px;
        border: 2px solid #EFEFEF;
        background-color: #FEFEFE;
        position: absolute;
        left: 300px;
        top: 30px;
        margin-left:-110px;
    }
    #click_here
    {
        background-color: none;
    }
</style>
<%--<script type="text/javascript">
    var imgPhoto = '<%=imgPhoto.ClientID%>';
    $(document).ready(function () {
        //       $(".HideDiv").slideUp();
        //        $(".EmpName").hover(function() {
        //            $(".HideDiv").slideDown();
        //        },
        //         function() {
        //             $(".HideDiv").slideUp();
        //         }
        //         );

       $('.EmpName').click(function () {
        //alert('1')
            $('#div1').slideUp();
        });
        $("#click_here").click(function (event) {
       // alert('2')
            event.preventDefault();
            $("#div1").slideDown();
        });

    });
    
    

</script>--%>
<div>
    <div class="EmpName1">
        <div id="click_here1">
            <table width="400px">
                <tr>
                    <td width="50px" valign="top" class="fdsfds">
                        <asp:Image runat="server" ID="imgPhoto" Visible="false" Height="40px" Width="40px" />
                    </td>
                    <td class="EmpName" width="auto" align="left">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblName" Style="text-transform: uppercase;" CssClass="dashboard_accountText"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label Style="text-transform: none;" runat="server" ID="lblDesignation" CssClass="dashboard_subaccountText"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div class="HideDiv" id="div1" class="yaten" style="display: none;">
            <table>
                <tr>
                    <td>
                        <asp:Label Style="text-align: center; padding-bottom: 0px; font-size: smaller; padding-top: 0px;"
                            Width="170px" runat="server" ID="lblAddress"></asp:Label>
                    </td>
                </tr>
                <tr style="text-align: left;">
                    <td align="center">
                        <asp:HyperLink Style="text-align: center; padding-left: 0px; font-size: smaller;
                            padding-bottom: 0px; padding-top: 0px;" runat="server" ID="lnkEmail" BorderStyle="none"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Style="text-align: center; padding-bottom: 0px; font-size: smaller; padding-top: 0px;"
                            Width="170px" runat="server" ID="lblPhone"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:HyperLink Style="text-align: center; color: #0066FF; font-size: 10px; padding-left: 0px;
                            padding-bottom: 0px; padding-top: 0px;" runat="server" ID="hlkChangePassword"
                            BorderStyle="none" NavigateUrl="~/internal/ChangePassword.aspx" Visible="true"
                            Text="Change Password"></asp:HyperLink>
                        <asp:HyperLink Style="text-align: center; color: #0066FF; font-size: 10px; padding-left: 0px;
                            padding-bottom: 0px; padding-top: 0px;" runat="server" ID="lnkEditProfile" BorderStyle="none"
                            Visible="false" Text="|  Edit"></asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>


