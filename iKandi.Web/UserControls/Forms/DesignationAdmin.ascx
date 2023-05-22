<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DesignationAdmin.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.DesignationAdmin" %>

<style type="text/css">
    .style3
    {
        width: 223px;
    }
    .style5
    {
        width: 261px;
    }
</style>

<script type="text/javascript">

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);
    $(document).ready(function() {

        $(".lbTag").slideUp();
        $(".lb").slideUp();
        $(".lbc").slideUp();
        proxy.invoke("GetClientTest", { ClientID: "0" },
                       function(result) {
                           $.each(result, function(index, value) {
                           $(".company").append($('<option></option>').val(this.StyleID).html(this.StyleNumber));
                           });
                       });

                       $(".company").change(function() {
                       $(".dept").find('option').remove();
            proxy.invoke("GetClientTest", { ClientID: $('select.company option:selected').val() },
                         function(result) {
                             $.each(result, function(index, value) {
                             $(".dept").append($('<option></option>').val(this.StyleID).html(this.StyleNumber));
                         }); if ($('select.company option:selected').val() == "0") { $(".dept").find('option').remove(); $(".dept").append($('<option></option>').val("0").html("Select")); }
                         });
                         var ee = $('select.company option:selected').val();
            if (ee > 0) {
                $(".lbTag").slideUp();
            }
        });
        $(".dept").change(function() {

        var ee = $('select.dept option:selected').val();
            if (ee > 0) {
                $(".lb").slideUp();
            }
        });
        $(".txtManagerName").keyup(function() { $(".lbc").slideUp(); });

    });

    function valid() {       
        var IsTrue = true;
        var s1 = $('select.company option:selected').val();
        var s2 = $('select.dept option:selected').val();
        var Manager = $(".txtManagerName").val();       
        $(".txtManagerName").val($.trim(Manager));
        var ws = $(".txtManagerName").val();
        if (ws == "") {
            $(".lbc").show("slow");IsTrue = false;
        }
        if (s1 == "0") {
            $(".lbTag").show("slow"); IsTrue = false;
        }
        if (s2 == "0") {
            $(".lb").show("slow"); IsTrue = false;
        }
        var AllValues = $(".desId").val() + "$" + $('select.dept option:selected').val() + "$" + ws;    
        if (IsTrue) {
            var s="33";
            proxy.invoke("GetClientTest", { ClientID: AllValues },
                         function(result) {                       
                             if (result[0].StyleID == "0") {                             
                                 $(".IsUpdate").val("0");
                                 alert(result[0].StyleNumber);
                                 window.location.href = window.location.href;                               
                             }
                             if (result[0].StyleID == "1") {
                                 alert(result[0].StyleNumber);
                                 $(".IsUpdate").val("1");                             
                             }
                         });                         
                     }
                         return false;          
    }

    function test(Com, Dep, DesId,Des) {
        $('select.company option[value=' + Com + ']').attr("selected", "selected");
        $(".dept").find('option').remove();
        var rr = $('select.company option:selected').val();
        proxy.invoke("GetClientTest", { ClientID: $('select.company option:selected').val() },
                         function(result) {
                             $.each(result, function(index, value) {
                             $(".dept").append($('<option></option>').val(this.StyleID).html(this.StyleNumber));
                         }); $('select.dept option[value=' + Dep + ']').attr("selected", "selected");
                         });
                         $(".txtManagerName").val(Des);

                         $(".desId").val(DesId);                 
        return false;
    }
    
</script>

<table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
    <caption class="caption_headings">
        Designation Admin</caption>
    
    <tr>
        <td class="tbl_bordr">
            <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
                <tr>
                    <td>
                        <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0" style="margin: 0px;">
                            <tr class="td-sub_headings">
                                <td >
                                    Company Name
                                    <asp:Label ID="lblTag"  CssClass="lbTag" ForeColor="Red" runat="server"
                                        Text="Enter Company Name."></asp:Label>
                                </td>
                                <td class="style5" >
                                    Department Name&nbsp;
                                    <asp:Label CssClass="lb"  ForeColor="Red" ID="lblSym" runat="server"
                                        Text="Enter Department Name."></asp:Label>
                                </td>
                                <td >
                                    Designation
                                    <asp:Label ID="lblCon" CssClass="lbc"  runat="server" ForeColor="Red"
                                        Text="Enter Designation."></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    <select name="select2" style="width:100px;" class="company">
                                    </select>
                                </td>
                                <td class="style5" >
                                    <select name="select2" style="width: 100px;" class="dept">
                                        <option value="0">Select</option>
                                    </select>
                                </td>
                                <td >
                                    <input type="text" class="txtManagerName" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnsubmit" Text="submit" OnClientClick="javascript:return valid();"
                                        CssClass="da_submit_button" runat="server" OnClick="btnsubmit_Click" /> <input type="hidden" value="0" class="desId" />
                                        <input type="hidden" value="NotFound"
                                         class="IsUpdate" />
                                </td>
                                
                            </tr>
                           
                           
                        </table>
                        <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="10" class="da_table_heading_bg_left">
                                                &nbsp;
                                            </td>
                                            <td class="da_table_heading_bg">
                                                <span class="da_h1">Designation List</span>
                                            </td>
                                            <td width="13" class="da_table_heading_bg_right">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <!--table2-->
                                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td align="left">
                                                <asp:GridView ID="grdDes" runat="server" CssClass="font" AutoGenerateColumns="False"
                                                    Width="100%" HeaderStyle-BackColor="#bdc3cf" AllowPaging="true" PageIndex="0"
                                                    PageSize="20" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="13px"
                                                    OnPageIndexChanged="grdDes_PageIndexChanged" OnPageIndexChanging="grdDes_PageIndexChanging">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Designation" HeaderStyle-Font-Bold="false" HeaderStyle-Width="25%">
                                                            <ItemTemplate>
                                                                <div style="text-align: center;">
                                                                    <%#Eval("Des")%>
                                                                    <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("Des") %>' />
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Department" HeaderStyle-Font-Bold="false" HeaderStyle-Width="25%">
                                                            <ItemTemplate>
                                                                <div style="text-align: center;">
                                                                    <asp:Label runat="server" ID="txtCurrencySymbol" Text='<%#Eval("DepName")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="company" HeaderStyle-Font-Bold="false" HeaderStyle-Width="25%">
                                                            <ItemTemplate>
                                                                <div style="text-align: center;">
                                                                    <%#Eval("ComName")%></div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Action" HeaderStyle-Font-Bold="false" HeaderStyle-Width="25%">
                                                            <ItemTemplate>
                                                                <div style="text-align: center;">
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" ForeColor="black" OnClientClick='<%#Server.HtmlDecode(string.Format("test(\&#39;{0}&#39;,&#39;{1}&#39;,&#39;{2}&#39;,&#39;{3}&#39;);return false;",Eval("ComID"),Eval("DepId"),Eval("DesID"),Eval("Des"))) %>'>
                                                                    
                                                                    
                                                                    
                                                                    Edit</asp:LinkButton>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    <!--end-->
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            
            &nbsp;<br />
            <br />
            &nbsp;</td>
   </tr>
   </table>