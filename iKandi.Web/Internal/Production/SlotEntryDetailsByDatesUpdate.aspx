<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SlotEntryDetailsByDatesUpdate.aspx.cs"
    Inherits="iKandi.Web.Internal.Production.SlotEntryDetailsByDatesUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <script src="../../js/service.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
    <style type="text/css">     

        input[type=text]
        {
            width:30px !important;
                       
        }
         input[type=checkbox]
         {
              float:right; 
              width:15px; 
              padding:0px;
              margin:2px 1px;
         }
        .w-80
        {
            width:90px;
        }
        .w-35{ width:35px; padding:1px;}
        th{ font-size:11px; padding:2px 0px !important;}
        td{ padding:2px 0px !important;}
        .fll{float:left; text-align:center;}
    </style>
    <title></title>
     <script type="text/javascript">

         function fncInputNumericValuesOnly(evt) {
             var e = event || evt; // for trans-browser compatibility
             var charCode = e.which || e.keyCode;
             if (charCode < 48 || charCode > 57)
                 return false;
             return true;
         }

         function IsNilProdCheck(obj, type) {
             if (obj.checked) {
                 if (type == 1) {
                     document.getElementById("txtSlot1Stitch").value = '';
                 }
                 if (type == 2) {
                     document.getElementById("txtSlot2Stitch").value = '';
                 }
                 if (type == 3) {
                     document.getElementById("txtSlot3Stitch").value = '';
                 }
                 if (type == 4) {
                     document.getElementById("txtSlot4Stitch").value = '';
                 }
                 if (type == 5) {
                     document.getElementById("txtSlot5Stitch").value = '';
                 }
                 if (type == 6) {
                     document.getElementById("txtSlot6Stitch").value = '';
                 }
                 if (type == 7) {
                     document.getElementById("txtSlot7Stitch").value = '';
                 }
                 if (type == 8) {
                     document.getElementById("txtSlot8Stitch").value = '';
                 }
                 if (type == 9) {
                     document.getElementById("txtSlot9Stitch").value = '';
                 }
                 if (type == 10) {
                     document.getElementById("txtSlot10Stitch").value = '';
                 }
                 if (type == 11) {
                     document.getElementById("txtSlot11Stitch").value = '';
                 }
                 if (type == 12) {
                     document.getElementById("txtSlot12Stitch").value = '';
                 }                
             }
         }

         function IsNilProdText(obj, type) {
             var StitchVal = obj.value;
             if (parseInt(StitchVal) == 0) {
                 StitchVal = '';
                 obj.value = '';
             }            

             if (StitchVal != '') {
                 if (type == 1) {
                     var Chk = document.getElementById("chkSlot1check");
                     if (Chk.checked) {
                         document.getElementById("txtSlot1Stitch").value = '';
                     }
                 }
                 if (type == 2) {
                     var Chk = document.getElementById("chkSlot2check");
                     if (Chk.checked) {
                         document.getElementById("txtSlot2Stitch").value = '';
                     }
                 }
                 if (type == 3) {
                     var Chk = document.getElementById("chkSlot3check");
                     if (Chk.checked) {
                         document.getElementById("txtSlot3Stitch").value = '';
                     }
                 }
                 if (type == 4) {
                     var Chk = document.getElementById("chkSlot4check");
                     if (Chk.checked) {
                         document.getElementById("txtSlot4Stitch").value = '';
                     }
                 }
                 if (type == 5) {
                     var Chk = document.getElementById("chkSlot5check");
                     if (Chk.checked) {
                         document.getElementById("txtSlot5Stitch").value = '';
                     }
                 }
                 if (type == 6) {
                     var Chk = document.getElementById("chkSlot6check");
                     if (Chk.checked) {
                         document.getElementById("txtSlot6Stitch").value = '';
                     }
                 }
                 if (type == 7) {
                     var Chk = document.getElementById("chkSlot7check");
                     if (Chk.checked) {
                         document.getElementById("txtSlot7Stitch").value = '';
                     }
                 }
                 if (type == 8) {
                     var Chk = document.getElementById("chkSlot8check");
                     if (Chk.checked) {
                         document.getElementById("txtSlot8Stitch").value = '';
                     }
                 }
                 if (type == 9) {
                     var Chk = document.getElementById("chkSlot9check");
                     if (Chk.checked) {
                         document.getElementById("txtSlot9Stitch").value = '';
                     }
                 }
                 if (type == 10) {
                     var Chk = document.getElementById("chkSlot10check");
                     if (Chk.checked) {
                         document.getElementById("txtSlot10Stitch").value = '';
                     }
                 }
                 if (type == 11) {
                     var Chk = document.getElementById("chkSlot11check");
                     if (Chk.checked) {
                         document.getElementById("txtSlot11Stitch").value = '';
                     }
                 }
                 if (type == 12) {
                     var Chk = document.getElementById("chkSlot12check");
                     if (Chk.checked) {
                         document.getElementById("txtSlot12Stitch").value = '';
                     }
                 }
             }
             else {
                 if (type == 1) {
                     var Chk = document.getElementById("chkSlot1check");
                     Chk.checked = true;
                 }
                 if (type == 2) {
                     var Chk = document.getElementById("chkSlot2check");
                     Chk.checked = true;
                 }
                 if (type == 3) {
                     var Chk = document.getElementById("chkSlot3check");
                     Chk.checked = true;
                 }
                 if (type == 4) {
                     var Chk = document.getElementById("chkSlot4check");
                     Chk.checked = true;
                 }
                 if (type == 5) {
                     var Chk = document.getElementById("chkSlot5check");
                     Chk.checked = true;
                 }
                 if (type == 6) {
                     var Chk = document.getElementById("chkSlot6check");
                     Chk.checked = true;
                 }
                 if (type == 7) {
                     var Chk = document.getElementById("chkSlot7check");
                     Chk.checked = true;
                 }
                 if (type == 8) {
                     var Chk = document.getElementById("chkSlot8check");
                     Chk.checked = true;
                 }
                 if (type == 9) {
                     var Chk = document.getElementById("chkSlot9check");
                     Chk.checked = true;
                 }
                 if (type == 10) {
                     var Chk = document.getElementById("chkSlot10check");
                     Chk.checked = true;
                 }
                 if (type == 11) {
                     var Chk = document.getElementById("chkSlot11check");
                     Chk.checked = true;
                 }
                 if (type == 12) {
                     var Chk = document.getElementById("chkSlot12check");
                     Chk.checked = true;
                 }

             }
         }
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:1480px; margin:0px auto;">
<div style="text-align: center; padding:5px 0px; background-color: #405D99;
                                color: #FFFFFF; font-weight: bold; text-transform:capitalize;
                                font-family:Verdana; width:100%;">
                                <div style="float:left; margin-left:10px; width:auto;">
                                <asp:Label ID="lblDate"
                                    runat="server" ForeColor="#cec8c8"></asp:Label></div> 
    <asp:Label ID="lblHeader" runat="server" Text="Label"></asp:Label></div>

    <table style="text-align:center;" cellpadding="0" cellspacing="0" border="1"  class="item_list2" width="100%">
    <tr>
        <th style="width:80px;">Factory</th>
        <th style="width:120px">Serial Number</th>
        <th style="width:100px">Quantity</th>
        <th class="w-80"> <b>Slot 1</b></th>
        <th class="w-80"> <b>Slot 2 </b></th>
        <th class="w-80"> <b>Slot 3 </b></th>
        <th class="w-80"><b>Slot 4 </b></th>
        <th class="w-80"> <b>Slot 5 </b></th>
        <th class="w-80" ><b>Slot 6 </b></th>
        <th class="w-80"><b>Slot 7 </b></th>
        <th class="w-80"><b>Slot 8 </b></th>
        <th class="w-80"><b>Slot 9 </b></th>
        <th class="w-80"><b>Slot 10 </b></th>
        <th class="w-80"><b>Slot 11 </b></th>
        <th class="w-80"><b>Slot 12 </b></th>
    </tr>
     <tr>  
     <th rowspan="2">
         <asp:Label ID="lblLineHeader" runat="server" Text=""></asp:Label></th> 
     <th rowspan="2">Color/Print</th>
        <th rowspan="2">ExFactory</th>
        <th> St. Pass/Nil Prd.</th>
        <th> St. Pass/Nil Prd.</th>
        <th> St. Pass/Nil Prd.</th>
        <th> St. Pass/Nil Prd.</th>
        <th> St. Pass/Nil Prd.</th>
        <th> St. Pass/Nil Prd.</th>
        <th> St. Pass/Nil Prd.</th>
        <th> St. Pass/Nil Prd.</th>
        <th> St. Pass/Nil Prd.</th>
        <th> St. Pass/Nil Prd.</th>
        <th> St. Pass/Nil Prd.</th>
        <th> St. Pass/Nil Prd.</th>
    </tr>     
     <tr>     
      <th>Finish Pass</th>
      <th>Finish Pass</th>
      <th>Finish Pass</th>
      <th>Finish Pass</th>
      <th>Finish Pass</th>
      <th>Finish Pass</th>
      <th>Finish Pass</th>
      <th>Finish Pass</th>
      <th>Finish Pass</th>
      <th>Finish Pass</th>
      <th>Finish Pass</th>
      <th>Finish Pass</th>                    
    </tr>

     <tr>
        <td style="font-weight:bold; font-size:14px;"><asp:Label ID="lblFactory" runat="server" Text=""></asp:Label> </td>
        <td style="color:Blue;"> <asp:Label ID="lblserial" runat="server" Text=""></asp:Label> </td>
        <td style="font-weight:bold;"> <asp:Label ID="lblQuantity" runat="server" Text=""></asp:Label> </td>
        <td> 
        <div class="fll w-35">
        <asp:Label ID="lblSlot1Stitch" CssClass="ZeroCheck" runat="server" Text=""></asp:Label>
        </div> 
         <asp:TextBox ID="txtSlot1Stitch" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" onblur="IsNilProdText(this, 1)" runat="server" CssClass="fll"></asp:TextBox>
        <asp:CheckBox ID="chkSlot1check" Enabled="false" onclick="IsNilProdCheck(this, 1)" runat="server" />

        </td>
        <td> 
        <div class="fll w-35"> 
        <asp:Label ID="lblSlot2Stitch" CssClass="ZeroCheck" runat="server" Text=""> &nbsp;</asp:Label>
         </div>
         <asp:TextBox ID="txtSlot2Stitch" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" onblur="IsNilProdText(this, 2)" runat="server" CssClass="fll"></asp:TextBox>
         <asp:CheckBox ID="chkSlot2check" Enabled="false" onclick="IsNilProdCheck(this, 2)" runat="server" />
        </td>
        <td> 
        <div class="fll w-35">
        <asp:Label ID="lblSlot3Stitch" CssClass="ZeroCheck" runat="server" Text=""> &nbsp;</asp:Label>
         </div>
         <asp:TextBox ID="txtSlot3Stitch" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" onblur="IsNilProdText(this, 3)" runat="server" CssClass="fll"></asp:TextBox>
         <asp:CheckBox ID="chkSlot3check" Enabled="false" onclick="IsNilProdCheck(this, 3)" runat="server" />
        </td>
        <td>  
        <div class="fll w-35">
        <asp:Label ID="lblSlot4Stitch" CssClass="ZeroCheck" runat="server" Text=""> &nbsp;</asp:Label>
         </div>
         <asp:TextBox ID="txtSlot4Stitch" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" onblur="IsNilProdText(this, 4)" runat="server" CssClass="fll"></asp:TextBox>
         <asp:CheckBox ID="chkSlot4check" Enabled="false" onclick="IsNilProdCheck(this, 4)" runat="server" />
        </td>
        <td>
        <div class="fll w-35"> 
        <asp:Label ID="lblSlot5Stitch" CssClass="ZeroCheck" runat="server" Text=""> &nbsp;</asp:Label>
         </div>
         <asp:TextBox ID="txtSlot5Stitch" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" onblur="IsNilProdText(this, 5)" runat="server" CssClass="fll"></asp:TextBox>
         <asp:CheckBox ID="chkSlot5check" Enabled="false" onclick="IsNilProdCheck(this, 5)" runat="server" />
        </td>
        <td> 
        <div class="fll w-35"> 
        <asp:Label ID="lblSlot6Stitch" CssClass="ZeroCheck" runat="server" Text=""> &nbsp;</asp:Label>
         </div>
         <asp:TextBox ID="txtSlot6Stitch" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" onblur="IsNilProdText(this, 6)" runat="server" CssClass="fll"></asp:TextBox>
         <asp:CheckBox ID="chkSlot6check" Enabled="false" onclick="IsNilProdCheck(this, 6)" runat="server" />
        </td>
        <td>
        <div class="fll w-35">
        <asp:Label ID="lblSlot7Stitch" CssClass="ZeroCheck" runat="server" Text=""> &nbsp;</asp:Label>
        </div>
         <asp:TextBox ID="txtSlot7Stitch" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" onblur="IsNilProdText(this, 7)" runat="server" CssClass="fll"></asp:TextBox>
         <asp:CheckBox ID="chkSlot7check" Enabled="false" onclick="IsNilProdCheck(this, 7)" runat="server" />
        </td>
        <td>
        <div class="fll w-35">
        <asp:Label ID="lblSlot8Stitch" CssClass="ZeroCheck" runat="server" Text=""> &nbsp;</asp:Label>
        </div>
         <asp:TextBox ID="txtSlot8Stitch" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" onblur="IsNilProdText(this, 8)" runat="server" CssClass="fll"></asp:TextBox>
         <asp:CheckBox ID="chkSlot8check" Enabled="false" onclick="IsNilProdCheck(this, 8)" runat="server" />
        </td>
        <td>
        <div class="fll w-35">
        <asp:Label ID="lblSlot9Stitch" CssClass="ZeroCheck" runat="server" Text=""> &nbsp;</asp:Label>
         </div>
         <asp:TextBox ID="txtSlot9Stitch" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" onblur="IsNilProdText(this, 9)" runat="server" CssClass="fll"></asp:TextBox>
         <asp:CheckBox ID="chkSlot9check" Enabled="false" onclick="IsNilProdCheck(this, 9)" runat="server" />
        </td>
        <td> 
        <div class="fll w-35">
        <asp:Label ID="lblSlot10Stitch" CssClass="ZeroCheck" runat="server" Text=""> &nbsp;</asp:Label>
        </div>
         <asp:TextBox ID="txtSlot10Stitch" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" onblur="IsNilProdText(this, 10)" runat="server" CssClass="fll"></asp:TextBox>
         <asp:CheckBox ID="chkSlot10check" Enabled="false" onclick="IsNilProdCheck(this, 10)" runat="server" />
        </td>
        <td>
        <div class="fll w-35">
        <asp:Label ID="lblSlot11Stitch" CssClass="ZeroCheck" runat="server" Text=""> &nbsp;</asp:Label>
         </div>
         <asp:TextBox ID="txtSlot11Stitch" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" onblur="IsNilProdText(this, 11)" runat="server" CssClass="fll"></asp:TextBox>
         <asp:CheckBox ID="chkSlot11check" Enabled="false" onclick="IsNilProdCheck(this, 11)" runat="server" />
        </td>
        <td> 
        <div class="fll w-35"> 
        <asp:Label ID="lblSlot12Stitch" CssClass="ZeroCheck" runat="server" Text=""> &nbsp;</asp:Label>
         </div>
         <asp:TextBox ID="txtSlot12Stitch" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" onblur="IsNilProdText(this, 12)" runat="server" CssClass="fll"></asp:TextBox>
         <asp:CheckBox ID="chkSlot12check" Enabled="false" onclick="IsNilProdCheck(this, 12)" runat="server" />
        </td>
    </tr>     
     <tr>
     <td style="font-size:10px;"><asp:Label runat="server" ID="lblLineNo"></asp:Label></td>
          <td style="font-size:10px;"><asp:Label ID="lblColor" runat="server" Text=""></asp:Label></td>
          <td style="font-size:10px;"><asp:Label ID="lblExFactory" runat="server" Text=""></asp:Label></td>
        <td> 
         <div class="fll w-35"> 
         <asp:Label ID="lblSlot1Finish" CssClass="ZeroCheck" runat="server" Text=""></asp:Label>
       </div>
        <asp:TextBox ID="txtSlot1Finish" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" runat="server"  CssClass="fll"></asp:TextBox>          
        </td>
        <td>
         <div class="fll w-35">
         <asp:Label ID="lblSlot2Finish" CssClass="ZeroCheck" runat="server" Text=""></asp:Label>
        </div>
        <asp:TextBox ID="txtSlot2Finish" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" runat="server"  CssClass="fll"></asp:TextBox>          
        </td>
        <td>
         <div class="fll w-35">
         <asp:Label ID="lblSlot3Finish" CssClass="ZeroCheck" runat="server" Text=""></asp:Label>
        </div> 
        <asp:TextBox ID="txtSlot3Finish" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" runat="server"  CssClass="fll"></asp:TextBox>          
        </td>
        <td>
         <div class="fll w-35"> 
         <asp:Label ID="lblSlot4Finish" CssClass="ZeroCheck" runat="server" Text=""></asp:Label>
       </div>
        <asp:TextBox ID="txtSlot4Finish" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" runat="server"  CssClass="fll"></asp:TextBox>          
        </td>
        <td>
         <div class="fll w-35"> 
         <asp:Label ID="lblSlot5Finish" CssClass="ZeroCheck" runat="server" Text=""></asp:Label>
       </div>
        <asp:TextBox ID="txtSlot5Finish" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" runat="server"  CssClass="fll"></asp:TextBox>          
        </td>
        <td>
         <div class="fll w-35"> 
         <asp:Label ID="lblSlot6Finish" CssClass="ZeroCheck" runat="server" Text=""></asp:Label>
        </div>
        <asp:TextBox ID="txtSlot6Finish" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" runat="server"  CssClass="fll"></asp:TextBox>          
        </td>
        <td>
         <div class="fll w-35"> 
         <asp:Label ID="lblSlot7Finish" CssClass="ZeroCheck" runat="server" Text=""></asp:Label>
        </div> 
        <asp:TextBox ID="txtSlot7Finish" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" runat="server"  CssClass="fll"></asp:TextBox>          
        </td>
        <td>
         <div class="fll w-35"> 
         <asp:Label ID="lblSlot8Finish" CssClass="ZeroCheck" runat="server" Text=""></asp:Label>
        </div> 
        <asp:TextBox ID="txtSlot8Finish" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" runat="server"  CssClass="fll"></asp:TextBox>          
        </td>
        <td>
         <div class="fll w-35"> 
         <asp:Label ID="lblSlot9Finish" CssClass="ZeroCheck" runat="server" Text=""></asp:Label>
        </div>
        <asp:TextBox ID="txtSlot9Finish" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" runat="server"  CssClass="fll"></asp:TextBox>          
        </td>
        <td>
         <div class="fll w-35">
         <asp:Label ID="lblSlot10Finish" CssClass="ZeroCheck" runat="server" Text=""></asp:Label>
       </div>
        <asp:TextBox ID="txtSlot10Finish" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" runat="server"  CssClass="fll"></asp:TextBox>          
        </td>
        <td>
         <div class="fll w-35"> 
         <asp:Label ID="lblSlot11Finish" CssClass="ZeroCheck" runat="server" Text=""></asp:Label>
        </div>
        <asp:TextBox ID="txtSlot11Finish" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" runat="server"  CssClass="fll"></asp:TextBox>          
        </td>
        <td>
         <div class="fll w-35"> 
         <asp:Label ID="lblSlot12Finish" CssClass="ZeroCheck" runat="server" Text=""></asp:Label>
       </div>
        <asp:TextBox ID="txtSlot12Finish" Enabled="false" style="border: 1px solid grey"  MaxLength="4" onkeypress="return fncInputNumericValuesOnly();" runat="server" CssClass="fll"></asp:TextBox>          
        </td>
    </tr>
    </table>        
           
    </div>
    <div style="margin: 10px auto; text-align: center">
                    <asp:Button ID="btnSubmit" runat="server" title="Save record !" CssClass="do-not-include submit tooltip"
                        Text="Submit" OnClick="btnSubmit_Click" />
                
      </div>
    </form>
</body>
</html>
