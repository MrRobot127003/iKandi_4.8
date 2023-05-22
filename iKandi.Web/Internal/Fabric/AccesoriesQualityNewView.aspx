<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccesoriesQualityNewView.aspx.cs" Inherits="iKandi.Web.Internal.Fabric.AccesoriesQualityNewView" MasterPageFile="~/layout/Secure.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
     <script type="text/javascript" src="../../js/facebox.js"></script>
    <script type="text/javascript" src="../../js/jquery.jcarousel.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <style type="text/css">
        .tablegrid
        {
            border-top: thin solid #dddfe4;
        }
        
        body
        {
            background: #f9f9fa none repeat scroll 0 0;
            font-family: verdana;
        }
        table
        {
            font-family: verdana;
            border-color: gray;
            border-collapse: collapse;
        }
        th
        {
            background: #dddfe4;
            font-weight: normal;
            color: #575759;
            font-family: arial,halvetica;
            font-size: 10px;
            padding: 5px 0px 5px 0px;
            text-transform: capitalize;
            text-align: center;
        }
        td
        {
              height: 25px;
         }
        th span
        {
            color: #575759 !important;
        }
        table td
        {
            font-size: 10px;
            text-align: center;
            border-color: #e0d9d9;
            text-transform: capitalize;
        }
        .per
        {
            color: blue;
        }
        .gray
        {
            color: gray;
        }
        h2
        {
            width: 70%;
        }
        .row-fir th
        {
            font-weight: bold;
            font-size: 11px;
        }
        table td table td
        {
            border-color: #e0d9d9;
        }
        input, select
        {
            width: 86%;
            padding: 0px;
        }
        div select option
        {
            padding: 4px 0px;
            width: 86%;
        }
        div input
        {
            width: 95%;
            color: blue;
            padding: 4px 0px;
        }
        .style_number_box_background
        {
            opacity: 0.9;
            background: grey;
            width: 2400px;
        }
        .style_number_box
        {
            padding: 0px !important;
            width: 550px !important;
            border: none;
        }
        .style_number_box table
        {
            border: 1px solid gray;
            padding-bottom: 5px;
        }
        .style_number_box div
        {
            background-color: #39589c;
            color: #fff;
            font-size: 14px;
            font-weight: bold;
            text-align: center;
            text-transform: capitalize;
            width: 100%;
            padding: 5px 0px;
        }
        .style_number_box
        {
            top: 50px !important;
            left: 50% !important;
            position: absolute !important;
        }
        .hover_row td
        {
            background-color: #A1DCF2;
        }
        .inner-table
        {
            border-color: #f2f2f2;
            text-align: left;
        }
        .inner-table td
        {
            text-align: left;
            padding: 0px 0px 0px 3px;
        }
        .foo-input, foo-select
        {
            font-size: 9px;
            height: 13px;
        }
        .inner-table td input
        {
            padding: 0px;
        }
        
        .inner-table select, .inner-table select option
        {
            padding: 0px;
            width: 97%;
            font-size: 9px;
            height: 16px;
        }
        select
        {
             height: 23px;
         }
        .disable, .disableF
        {
            background-image: url('../../images/n_a.png');
            height: 16px;
            width: 20px;
            background-repeat: no-repeat;
            opacity: 0.35;
            border: 1px solid gray !important;
        }
        #Img1
        {
            height: 10px;
        }
        
        /* The Modal (background) */
        .modal
        {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }
        
        /* Modal Content */
        .modal-content
        {
            background-color: #fefefe;
            margin: auto;
            padding: 0px 1px 1px;
            border: 5px solid #888;
            width: 750px;
            margin-top: 12%;
            border-radius:5px;
        }
        
        /* The Close Button */
        .close
        {
            color: #aaaaaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }
        
        .close:hover, .close:focus
        {
            color: #000;
            text-decoration: none;
            cursor: pointer;
        }
        .submit
        {
            color: Yellow !important;
            border-radius:2px;
            
        }
        input[type="text"], select
        {
            color: Gray !important;
        }
        .item_list TD .ValidationBorder, .item_list TD input[type=text].ValidationBorder, .item_list TD textarea.ValidationBorder
        {
            border: 1px solid #FF0000 !important;
        }
        .minwidthsup
        {
           min-width:255px;
            
           }
           .moqwidth
           {
               min-width:57px;
            }
            .item_list TD input[type=text]{
                width: 96%;
                height: 12px;
                font-size: 11px;
            }
           @-moz-document url-prefix() {
            .ShowDiv table
               {
                border-color:#847c7c66 !important;
               }
               .ShowDiv table th{
                 border-color:#999; 
               }
               .toptablegroup 
               {
                    border-color:#999 !important;
                }
                   .toptablegroup th
               {
                    border-color:#999 !important;
                }
            }
           table.bottomtable tr:nth-last-child(1) > td
            {
                border-bottom-color: #999 !important;
            }
              ::-webkit-scrollbar-thumb {
                background: #b8b4b4  !important;
                border: 1px solid #b8b4b4  !important;
                border-radius: 10px;
            }
              ::-webkit-scrollbar-thumb:hover {
                background: #999 !important;
                border: 1px solid #999 !important;
                border-radius: 10px;
            }
            
             td[colspan="8"] {
              border-left-color: #999;
               border-right-color: #999;
                border-bottom-color: #999;
                border:0px;
                padding: 2px 0px !important;
            }
              td[colspan="8"] span
              {
                  color:Blue;
                cursor: default;
              }
               td[colspan="8"] a
              {
                  color:gray
              }
            
            #ctl00_cph_main_content_gdvFQMaster
            {
                 border-left:0px;
                 border-right:0px;
                 border-bottom:0px;
             }
            .border_top_color
            {
                border-top-color: #999 !important;;
                
              }
              .grouptable input
              {
                  height:12px;
                }
        .validation_messagebox  td[rowspan="4"]
         {
            width: 70px;
           padding-left: 5px;
          }
          .grouptable.bottomtable
          {
              border-right-color:#999!important;
               border-left-color:#999!important;
           }
            .grouptable.bottomtable td:first-child
          {
              
               border-left-color:#999!important;
           }
          .grouptable.bottomtable td:last-child
          {
              
               border-right-color:#999!important;
           }
        ::-webkit-scrollbar
        {
            width: 8px;
            height: 5px;
        }
       .item_list a:hover {
        text-decoration: none !important;
    }
     .borderBottom td
        {
            border-bottom:1px solid #999;
        }
       .modalNew
        {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }
        .modal-content
        {
           
            width: 800px;
            margin: auto;
            background: #fff;
            border: 5px solid #999;
            border-radius: 5px;
             min-height: 300px;
            max-height: 320px;
            overflow:auto;
             
        }
        .HistoryHeader
        {
            background:#39589c;
            color:#fff;
            text-align: center;
            font-size: 14px;
            position:fixed;
            width:792px;
        }
        #HistoryDescription
        {
             padding: 7px !important;
             margin-top:17px;
         }
         img.imgWidth2
         {
             width:19px !important;
             height:19px !important;
          }
            img.imgWidth
         {
             width:18px !important;
            
          }
          .LeftRightNone
          {
              border-left:0px !important;
                border-right:0px !important
           }
            .LeftNone
          {
              border-left:0px !important;
           }
           .RightNone {
              border-right:0px !important;
           }
    </style>
  
    <div style="width: 800px; margin: 0 auto">
        <h2 style="margin-left: 20px; width: 809px; border: 1px solid gray">
            Accessories Quality Admin View
        </h2>
        <table cellspacing="0" style="margin-left: 20px; margin-bottom: 2px; border-color: #f2f2f2; width: 810px" cellpadding="0" width="810px" border="1" align="center" runat="server" id="Table2">
            <tr>
                <th style="width: 60px;">
                    IsDefault
                </th>
                <td>
                    <asp:DropDownList ID="ddlIsDefault" Width="95%" runat="server">
                        <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Default" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Exclude Default" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <th style="width: 60px;">
                    Group
                </th>
                <td>
                    <asp:DropDownList ID="ddlgroupSrach" Width="95%" runat="server">
                    </asp:DropDownList>
                </td>
                <th style="width: 60px;">
                    Quality
                </th>
                <td>
                    <asp:TextBox ID="txtQualitySearch" Width="95%" runat="server"></asp:TextBox>
                </td>
                <th style="width: 60px;">
                    Unit
                </th>
                <td>
                    <asp:DropDownList ID="ddlunitsearch" Width="95%" runat="server">
                        <asp:ListItem Selected="True" Value="0">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 60px;">
                    <asp:Button ID="btnGoProcess" runat="server" OnClick="btn_Go" CssClass="go" Text="Go" />
                </td>
            </tr>
        </table>
    </div>
     <div style="height: 20px;">
        &nbsp;
        </div>
    <div style="width: 95%; margin: 0 auto" class="addClass">
        <asp:GridView ID="GrdCatgoryAdd" runat="server" AutoGenerateColumns="true" Width="100%" CssClass="item_list bottomRow" 
        ShowHeader="true" ShowFooter="false" EmptyDataText="No Record Found!" HeaderStyle-Font-Names="Arial" 
        HeaderStyle-HorizontalAlign="Center" rules="all" HeaderStyle-CssClass="ths" PageSize="50" >
        </asp:GridView>
        <br />
    </div>
</asp:Content>
