<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientCostingDefaultList_old.ascx.cs"
    Inherits="iKandi.Web.UserControls.Lists.ClientCostingDefaultList_old" %>

<script type="text/javascript">
    var gvClientCostingDefaultsClientID = '<%=gvClientCostingDefaults.ClientID %>';


    function change(evntSrc) {
        //debugger;
        var pairs = evntSrc.id.split("-");
        pairs[1];
        var rowCount = $("#" + gvClientCostingDefaultsClientID + " tr").length - 2;
        var rowCount1 = $("#" + gvClientCostingDefaultsClientID).find("tr").length;
        if (evntSrc.checked == true) 
         {
            for (var j = 1; j <= rowCount1 - 1; j++) {
                var objRow = $("#" + gvClientCostingDefaultsClientID).find("tr").filter("tr:eq(" + j + ")");
                var i = objRow.get(0).rowIndex - 1;
                if (i == 0) {
                    if (pairs[1] == 12) {                       
                        var ddlconversion = objRow.find(".CONVERSION").val();
                    }
                    if (pairs[1] == 111) {
                        //debugger;
                        var ddlAchivement = objRow.find(".ACHIEVE").val();
                    }

                    else {
                        var firsttxtval = objRow.find(".commission" + pairs[1]).val();
                    }
                }
                objRow.find(".commission" + pairs[1]).val(firsttxtval);
                objRow.find(".CONVERSION").val(ddlconversion);
                objRow.find(".ACHIEVE").val(ddlAchivement);

                //ACHIEVEMENT
            }
        }
         evntSrc.checked = false;
        //setTimeout("evntSrc.checked = false", 1000);
    }
    function uncheck(evntArg) {
      
  }
</script>

<div class="print-box">
    <div class="form_box">
        <div class="form_heading">
            Client Costing Defaults
        </div>
        <div>
            <asp:GridView runat="server" ID="gvClientCostingDefaults" CssClass="item_list fixed-header"
                AutoGenerateColumns="true" OnRowDataBound="gvClientCostingDefaults_RowDataBound">
            </asp:GridView>
        </div>
        <br />
    </div>
    <br />
    <asp:Button ID="btnSubmit" runat="server" CssClass="submit" OnClick="btnSubmit_Click" />
</div>
