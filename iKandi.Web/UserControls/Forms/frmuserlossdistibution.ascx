<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmuserlossdistibution.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.frmuserlossdistibution" %>
<style type="text/css">
    .style1
    {
        width: 12%;
    }
    .style2
    {
        width: 21%;
    }
    .style3
    {
        width: 22%;
    }
    .font
    {
        font-size: 13px;
    }
    .border td
    {
        border: 1px solid #000000;
        border-collapse: collapse;
    }
    .border2 th
    {
        background-image: url(../../images/cs_bg.jpg);
        background-repeat: repeat-x;
        padding: 10px;
        color: White;
        text-transform: capitalize;
    }
    .submit
    {
        background-color: White;
        background-image: url(../../App_Themes/ikandi/images/submit.jpg);
        background-repeat: no-repeat;
        width: 105px;
        height: 28px;
        background-position: 0px 0px;
        border: none;
    }
    .submit:hover
    {
        background-color: White;
        background-image: url(../../App_Themes/ikandi/images/submit.jpg);
        background-repeat: no-repeat;
        width: 105px;
        height: 28px;
        background-position: 0px -28px;
    }
    
</style>
<script type="text/javascript">
//    function UpdateLineLineDesignation(elem) {
//        debugger;
//        var Ids = elem.id;
//        var cId = Ids.split("_")[6].substr(3);

//        var userId = '<%=this.UserId%>';

//        var DesignationID = $("#<%= grdslot.ClientID %> select[id*='ctl" + cId + "_ddlDesignationItem" + "']").val();
//        var factoryId = $("#<%= grdslot.ClientID %> select[id*='ctl" + cId + "_ddlFactoryItem" + "']").val();
//        //var IsAct = $("#<%= grdslot.ClientID %> radio[id*='ctl" + cId + "_rbtnIsActiveItem" + "']").val();

//        var IsAct = $("#<%= grdslot.ClientID %> radio[id*='ctl" + cId + "_rbtnIsActiveItem" + "'] :radio:checked").val();
//        //var IsAct = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_rbtnIsActiveItem" + "'] :checked:checked").val();
//        var Name = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_txtNameItem" + "']").val();
//        if (Name.length < 0) {
//            alert('Enter name')
//        }
//        var id = parseInt($("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_hdnID" + "']").val());



//        proxy.invoke("updateSlot", { DesignationID: DesignationID, factoryId: factoryId, IsAct: IsAct, UserId: userId, Names: Name, id: id }, function (result) {

//            jQuery.facebox('Record updated');
//        }, onPageError, false, false);
//    }
    
</script>
