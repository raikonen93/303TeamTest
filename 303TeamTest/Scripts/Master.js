$(document).ready(function () {  
    $("#lbcustomers").click(function () {
        $("#lbcustomerroles").removeClass("activetab");
        $("#lbcustomerroles").addClass("nonactivetab");
        $("#lbcustomers").addClass("activetab");
        $("#lbcustomers").removeClass("nonactivetab");
        $.ajax({
            url: '/Home/CustomersPart',
            success: function (data) {              
                $("#partialContent").html(data);
            },
            error: function (jqXHR, exception) { AjaxError(jqXHR, exception); }
        })
    });

    $("#lbcustomerroles").click(function () {
        $("#lbcustomers").removeClass("activetab");
        $("#lbcustomers").addClass("nonactivetab");
        $("#lbcustomerroles").removeClass("nonactivetab");
        $("#lbcustomerroles").addClass("activetab");
        $.ajax({
            url: '/Home/CustomerRoles',
            success: function (data) {
                $("#partialContent").html(data);
            },
            error: function (jqXHR, exception) { AjaxError(jqXHR, exception); }
        })
    });   
});