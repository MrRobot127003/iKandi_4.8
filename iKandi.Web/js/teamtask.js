function GetTeamTaskCount() {
    $(".teamtaskloadingimage").show();
    proxy.invoke("GetTeamTasks", {}, function (result) {
        $(".AllTeamTask").html(result);
        var val = $("#" + hfTeamTask).val();
        if (val != "0") {
            $(".TeamTaskcount").html($("#" + hfTeamTask).val());
            //$("#" + TotalTaskCount).html(parseInt($("#" + hfTeamTask).val()) + parseInt($("#" + MyTaskCount).html()));
            $("#" + TotalTaskCount).html(parseInt($("#" + hfTeamTask).val()) + parseInt($("#" + MyTaskCount).html()));
        }
        else {
            $("#teamtask").hide();
            $(".AllTeamTask").hide();
        }
        $(".teamtaskloadingimage").hide();
    }, onPageError, false, false);
}

GetTeamTaskCount();