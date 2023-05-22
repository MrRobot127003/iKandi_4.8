<%@ Control Language="C#" AutoEventWireup="true"   CodeBehind="FactorySpecificLineAdminControl.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.FactorySpecificLineAdminControl" %>
<%--<script type="text/javascript" src="../../js/jquery-1.8.2.js"></script>--%>
<script type="text/javascript">
  function SaveFloor(elem) {
   
    var UserId = $("#<%= hdnUserId.ClientID %>").val();
    var RowId = elem.id.replace(elem.id.split("_")[8], "");
    var str = RowId.substring(0, RowId.length - 9);

    var UnitId = $("#" + str + "_hdnUnitId").val();
    var LineNo = $("#" + str + "_lblLine").text().replace("Line ", "");
    var FloorNo = $("#" + str + "_ddlFloor").val();

    if (FloorNo > 0) {
      proxy.invoke("UpdateLineFloor", { UnitId: UnitId, FloorNoId: FloorNo, LineNoId: LineNo, UserId: UserId }, function (result) {
        if (result > 1 || result > -1) {
          //debugger;
          alert('Saved Successfully');
          $("#" + str + "_hdnFloor").val(FloorNo);
        }
      }, onPageError, false, false);
    }
    else {
      alert("Please select Floor No.");
      var hdnFloor = $("#" + str + "_hdnFloor").val();
      document.getElementById(elem.id).value = hdnFloor;
      return false;
    }
  }

  function SaveIsClosed(elem) {
      //debugger;
    var IsClosed;
    var UserId = $("#<%= hdnUserId.ClientID %>").val();
    var RowId = elem.id.replace(elem.id.split("_")[8], "");
    var str = RowId.substring(0, RowId.length - 5);

    var UnitId = $("#" + str + "_hdnUnitId").val();
    var LineNo = $("#" + str + "_lblLine").text().replace("Line ", "");
    var FloorNo = $("#" + str + "_ddlFloor").val();

    if ($('#' + elem.id + ' input:checked').val() == "Yes") {
      IsClosed = true;
    }
    else {
      IsClosed = false;
    }
    if (FloorNo > 0) {
      proxy.invoke("UpdateLineIsClosed", { UnitId: UnitId, FloorNoId: FloorNo, LineNoId: LineNo, IsClosed: IsClosed, UserId: UserId }, function (result) {
        if (result > 1 || result > -1) {
          //debugger;
          alert('Saved Successfully');
        }
      }, onPageError, false, false);
    }
    else {
      alert("Please select Floor No.");
      return false;
    }
  }

  function SaveFactoryLine(elem) {
    //debugger;
    //var UserId = $("#<%= hdnUserId.ClientID %>").val();
    var RowId = elem.id.replace(elem.id.split("_")[9], "");
    var str = RowId.substring(0, RowId.length - 6);
    var LineDesignationId = elem.id.split("_")[8].substr(0);

    var UnitId = $("#" + str + "_hdnUnitId").val();
    var LineNo = $("#" + str + "_lblLine").text().replace("Line ", "");
    var FloorNo = $("#" + str + "_ddlFloor").val();
    var DesignationName = $("#" + str + "_ddl_" + LineDesignationId).find('option:selected').text();
    var UserId = $("#" + str + "_ddl_" + LineDesignationId).find('option:selected').val();
    if (UserId <=0) {
        alert("Please select User.");
        return false;
    }
    if (FloorNo > 0) {
      proxy.invoke("UpdateLineStatusDesignation", { UnitId: UnitId, LineNoId: LineNo, LineDesignationId: LineDesignationId, DesignationName: DesignationName, UserId: UserId }, function (result) {
        if (result > 1 || result > -1) {
          //debugger;
          alert('Saved Successfully');
        }
      }, onPageError, false, false);
    }
    else {
      alert("Please select Floor No.");
      return false;
    }
}



function SaveManpower(elem) {
   
    var UserId = $("#<%= hdnUserId.ClientID %>").val();
    var RowId = elem.id.replace(elem.id.split("_")[8], "");
    var str = RowId.substring(0, RowId.length - 12);

    var UnitId = $("#" + str + "_hdnUnitId").val();
    var LineNo = $("#" + str + "_lblLine").text().replace("Line ", "");
    var Manpower = $("#" + str + "_txtmanpower").val();
    
    

    if (Manpower > 0) {
        proxy.invoke("UpdateLineManPower", { UnitId: UnitId, manPower: Manpower, LineNoId: LineNo, UserId: UserId }, function (result) {
            if (result > 1 || result > -1) {
               
                alert('Saved Successfully');

            }
        }, onPageError, false, false);
    }
    else {
        alert("Please enter valid manpower value ");
//        var hdnFloor = $("#" + str + "_hdnFloor").val();
//        document.getElementById(elem.id).value = hdnFloor;
        return false;
    }
}
</script>

<script type="text/javascript">
    function SaveFloorcluster(elem) {

        var UserId = $("#<%= hdnUserId.ClientID %>").val();
        var RowId = elem.id.replace(elem.id.split("_")[8], "");
        var str = RowId.substring(0, RowId.length - 9);

        var UnitId = $("#" + str + "_hdnUnitId").val();
        var LineNo = $("#" + str + "_lblLine").text().replace("Cluster ", "");
        var FloorNo = $("#" + str + "_ddlFloor").val();

        if (FloorNo > 0) {
            proxy.invoke("UpdateLineFloorCluster", { UnitId: UnitId, FloorNoId: FloorNo, LineNoId: LineNo, UserId: UserId }, function (result) {
                if (result > 1 || result > -1) {
                    //debugger;
                    alert('Saved Successfully');
                    $("#" + str + "_hdnFloor").val(FloorNo);
                }
            }, onPageError, false, false);
        }
        else {
            alert("Please select Floor No.");
            var hdnFloor = $("#" + str + "_hdnFloor").val();
            document.getElementById(elem.id).value = hdnFloor;
            return false;
        }
    }

    function SaveIsClosedcluster(elem) {
        //  debugger;
        var IsClosed;
        var UserId = $("#<%= hdnUserId.ClientID %>").val();
        var RowId = elem.id.replace(elem.id.split("_")[8], "");
        var str = RowId.substring(0, RowId.length - 5);

        var UnitId = $("#" + str + "_hdnUnitId").val();
        var LineNo = $("#" + str + "_lblLine").text().replace("Cluster ", "");
        var FloorNo = $("#" + str + "_ddlFloor").val();

        if ($('#' + elem.id + ' input:checked').val() == "Yes") {
            IsClosed = true;
        }
        else {
            IsClosed = false;
        }
        if (FloorNo > 0) {
            proxy.invoke("UpdateLineIsClosedCluster", { UnitId: UnitId, FloorNoId: FloorNo, LineNoId: LineNo, IsClosed: IsClosed, UserId: UserId }, function (result) {
                if (result > 1 || result > -1) {
                    //debugger;
                  
                    alert('Saved Successfully');
                }
            }, onPageError, false, false);
        }
        else {
            alert("Please select Floor No.");
            return false;
        }
    }

    function SaveFactoryLinecluster(elem) {
        //debugger;
        //var UserId = $("#<%= hdnUserId.ClientID %>").val();
        var RowId = elem.id.replace(elem.id.split("_")[9], "");
        var str = RowId.substring(0, RowId.length - 6);
        var LineDesignationId = elem.id.split("_")[8].substr(0);

        var UnitId = $("#" + str + "_hdnUnitId").val();
        var LineNo = $("#" + str + "_lblLine").text().replace("Cluster ", "");
        var FloorNo = $("#" + str + "_ddlFloor").val();
        var DesignationName = $("#" + str + "_ddl_" + LineDesignationId).find('option:selected').text();
        var UserId = $("#" + str + "_ddl_" + LineDesignationId).find('option:selected').val();
        if (UserId <= 0) {
            alert("Please select User.");
            return false;
        }
        if (FloorNo > 0) {
            proxy.invoke("UpdateLineStatusDesignationCluster", { UnitId: UnitId, LineNoId: LineNo, LineDesignationId: LineDesignationId, DesignationName: DesignationName, UserId: UserId }, function (result) {
                if (result > 1 || result > -1) {
                    //debugger;
                    alert('Saved Successfully');
                }
            }, onPageError, false, false);
        }
        else {
            alert("Please select Floor No.");
            return false;
        }
    } 



    function SaveManpowercluster(elem) {
        //debugger;
        var UserId = $("#<%= hdnUserId.ClientID %>").val();
        var RowId = elem.id.replace(elem.id.split("_")[8], "");
        var str = RowId.substring(0, RowId.length - 12);

        var UnitId = $("#" + str + "_hdnUnitId").val();
        var LineNo = $("#" + str + "_lblLine").text().replace("Cluster ", "");
        var Manpower = $("#" + str + "_txtmanpower").val();
//        alert(Manpower);


        if (Manpower > 0) {
            proxy.invoke("UpdateLineManPowerCluster", { UnitId: UnitId, manPower: Manpower, LineNoId: LineNo, UserId: UserId }, function (result) {
                if (result > 1 || result > -1) {

                    alert('Saved Successfully');

                }
            }, onPageError, false, false);
        }
        else {
            alert("Please enter valid manpower value ");
            //        var hdnFloor = $("#" + str + "_hdnFloor").val();
            //        document.getElementById(elem.id).value = hdnFloor;
            return false;
        }
    }







    function SaveclusterName(elem) {
       // debugger;
        var UserId = $("#<%= hdnUserId.ClientID %>").val();
        var RowId = elem.id.replace(elem.id.split("_")[8], "");
        
        var str = RowId.substring(0, RowId.length - 15);
       
        var UnitId = $("#" + str + "_hdnUnitId").val();
        var LineNo = $("#" + str + "_lblLine").text().replace("Cluster ", "");
        var ClusterName = $("#" + str + "_txtClusterName").val();

        //alert(ClusterName);

        if (ClusterName.length > 0) {
            proxy.invoke("UpdateClusterName", { UnitId: UnitId, ClusterName: ClusterName, LineNoId: LineNo, UserId: UserId }, function (result) {
                if (result > 1 || result > -1) {

                    alert('Saved Successfully');

                }
            }, onPageError, false, false);
        }
//        else {
//            alert("Please enter valid ClusterName value ");
//            //        var hdnFloor = $("#" + str + "_hdnFloor").val();
//            //        document.getElementById(elem.id).value = hdnFloor;
//            return false;
//        }
    }



</script>

<table runat="server" id="tblserver" border="0" cellpadding="0" cellspacing="0" width="100%" align="center" style="text-transform:none !important;">
  <tr>
    <td align="center" style="padding-left: 25px; height: 30px; background-color: #405D99; color: #FFFFFF;">
      <span style="font-weight: 500; font-size:15px;">Line Status</span>
      <asp:HiddenField ID="hdnUserId" runat="server" />
    </td>
  </tr>
  <tr>
    <td align="left" style="padding-top:15px; padding-left:15px;">
      <asp:DropDownList ID="ddlFactorySearch"  runat="server" Visible="true"  AutoPostBack="true" Width="85px" Height="25px" Font-Size="15px" OnSelectedIndexChanged="ddlFactorySearch_SelectedIndexChanged"></asp:DropDownList>
      <asp:HiddenField ID="hdnTableCount" runat="server" />
      <asp:HiddenField ID="hdnIdCount" runat="server" />
    </td>
  </tr>
  <tr>
    <td align="center" style="padding-top:15px;">
      <asp:GridView ID="gvLineStatus" runat="server"  AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="30px" HeaderStyle-Font-Size="12px" Width="100%"
        HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" RowStyle-Height="35px"
        RowStyle-HorizontalAlign="Center"  RowStyle-ForeColor="#7E7E7E" OnRowDataBound="gvLineStatus_RowDataBound">
        <Columns>
          <asp:TemplateField HeaderText="Factory Name" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
              <asp:Label ID="lblFactory" runat="server" Text='<%#Eval("UnitName") %>'></asp:Label>
              <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("UnitID") %>' />
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Line" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
              <asp:Label ID="lblLine" runat="server" Text='<%#Eval("Line_No") %>' Font-Bold="true"></asp:Label>
            </ItemTemplate>
          </asp:TemplateField>

           

          <asp:TemplateField HeaderText="Floor No" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
              <asp:DropDownList ID="ddlFloor" runat="server" Width="60px" onchange="SaveFloor(this)"></asp:DropDownList>
              <asp:HiddenField ID="hdnFloor" runat="server" />
            </ItemTemplate>
          </asp:TemplateField>

           <asp:TemplateField HeaderText="Man Power" ItemStyle-HorizontalAlign="Center">
           <HeaderStyle Width="100" />
            <ItemStyle Width="100" />
            <ItemTemplate>
             
              <asp:TextBox ID="txtmanpower" Text='<%#Eval("Line_No") %>' style="width:43px;" runat="server" onchange="SaveManpower(this)" ToolTip="Enter man power value" MaxLength="2" CssClass="numeric-field-without-decimal-places"></asp:TextBox>
              <asp:HiddenField ID="hdnmanPower" runat="server" />
            </ItemTemplate>
            
          </asp:TemplateField>

        </Columns>
      </asp:GridView>
    </td>
    
    
  </tr>
  <tr>

  <td align="center" style="padding-top:15px;">
      <asp:GridView ID="gvLineStatusCluster" runat="server"  AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="30px" HeaderStyle-Font-Size="12px" Width="100%"
        HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" RowStyle-Height="35px"
        RowStyle-HorizontalAlign="Center" RowStyle-ForeColor="#7E7E7E" OnRowDataBound="gvLineStatusCluster_RowDataBound">
        <Columns>
          <asp:TemplateField HeaderText="Factory Name" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
              <asp:Label ID="lblFactory" runat="server" Text='<%#Eval("UnitName") %>'></asp:Label>
              <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("UnitID") %>' />
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Cluster" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
              <asp:Label ID="lblLine" runat="server" Text='<%#Eval("NoOfClustered") %>' Font-Bold="true"></asp:Label>
            </ItemTemplate>
          </asp:TemplateField>

          <asp:TemplateField HeaderText="Cluster Name" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
            <asp:TextBox runat="server" ID="txtClusterName" Text='<%#Eval("Cluster_Name") %>' onchange="SaveclusterName(this)"  Width="70px"></asp:TextBox>
              
            </ItemTemplate>
          </asp:TemplateField>

          <asp:TemplateField HeaderText="Floor No" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
              <asp:DropDownList ID="ddlFloor" runat="server" Width="60px" onchange="SaveFloorcluster(this)"></asp:DropDownList>
              <asp:HiddenField ID="hdnFloor" runat="server" />
            </ItemTemplate>
          </asp:TemplateField>

           <asp:TemplateField HeaderText="Man Power" ItemStyle-HorizontalAlign="Center">
           <HeaderStyle Width="100" />
            <ItemStyle Width="100" />
            <ItemTemplate>
             
              <asp:TextBox ID="txtmanpower" Text='<%#Eval("NoOfClustered") %>' style="width:43px;" runat="server" onchange="SaveManpowercluster(this)" ToolTip="Enter man power value" MaxLength="2" CssClass="numeric-field-without-decimal-places"></asp:TextBox>
              <asp:HiddenField ID="hdnmanPower" runat="server" />
            </ItemTemplate>
            
          </asp:TemplateField>

        </Columns>
      </asp:GridView>
    </td>
  </tr>
</table>