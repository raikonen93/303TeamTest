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
    
    $("#btnCreateCustomer").click(function () {       
        $.ajax({
            url: '/Home/CustomerRoles',
            success: function (data) {
                $("#partialContent").html(data);
            },
            error: function (jqXHR, exception) { AjaxError(jqXHR, exception); }
        })
    });  

});

function AjaxError(jqXHR, exception) {
    var msg = '';
    if (jqXHR.status === 0) {
        msg = 'Not connect.\n Verify Network.';
    } else if (jqXHR.status == 404) {
        msg = 'Requested page not found. [404]';
    } else if (jqXHR.status == 500) {
        msg = 'Internal Server Error [500].';
    } else if (exception === 'parsererror') {
        msg = 'Requested JSON parse failed.';
    } else if (exception === 'timeout') {
        msg = 'Time out error.';
    } else if (exception === 'abort') {
        msg = 'Ajax request aborted.';
    } else {
        msg = 'Uncaught Error.\n' + jqXHR.responseText;
    }
    console.log(msg);
}

function setCookie(key, value) {
    var expires = new Date();
    expires.setTime(expires.getTime() + (1 * 24 * 60 * 60 * 1000));
    document.cookie = key + '=' + value + ';expires=' + expires.toUTCString();
}

function getCookie(key) {
    var keyValue = document.cookie.match('(^|;) ?' + key + '=([^;]*)(;|$)');
    return keyValue ? keyValue[2] : null;
}

String.prototype.includes = function (str) {
    var returnValue = false;

    if (this.indexOf(str) !== -1) {
        returnValue = true;
    }

    return returnValue;
}

function pageClick(pageElem) {
    var selectedElem = document.getElementsByClassName("selectedpage");
    for (var i = 0; i < selectedElem.length; i++) {
        selectedElem[i].classList.remove("selectedpage");
    };   
    pageElem.classList.add("selectedpage");
    getNewTable();
}

function sortClick(id) {
    var clickElem = document.getElementById(id);
    var elems = document.getElementsByClassName('visiblesort');
    var src = clickElem.src;
    for (var i = 0; i < elems.length; i++) {
        elems[i].src = "";
    };   
    if (src == "") {
        clickElem.src = "/Content/Images/sort-asc.png";
    }
    else if (src.includes("/Content/Images/sort-asc.png")) {
        clickElem.src = "/Content/Images/sort-desc.png";
    }
    else {
        clickElem.src = "/Content/Images/sort-asc.png";
    }
    getNewTable();
}

function getSortedColumn() {
    var elems = document.getElementsByClassName('visiblesort');
    var sortedColumn = new Object();       
    for (var i = 0; i < elems.length; i++) {
        if (elems[i].src.includes('.png')) {
            sortedColumn.columnId = elems[i].id;
            sortedColumn.src = elems[i].src;
        }
    }
    return sortedColumn;
}

function getPage() {
    var elems = document.getElementsByClassName('enabledpagination');
    var page = new Object();     
    for (var i = 0; i < elems.length; i++) {
        if (elems[i].classList.contains('selectedpage')) {
            page = elems[i];
        }
    }
    return page.value;
}

function getNewTable() {
    var page = getPage();
    var sortedColumn = getSortedColumn();   
    
    var dataPost = { page: page, columnId: sortedColumn.columnId, src: sortedColumn.src };
    $.ajax({
        url: '/Home/CustomersPart',
        data: dataPost,
        success: function (data) {
            $("#partialContent").html(data);
        },
        error: function (jqXHR, exception) { AjaxError(jqXHR, exception); }
    })
}

function prevPage(elem, pageNum) {    
    var elems = document.getElementsByClassName("selectedpage");
    var $prev = $(elems[0]).prev();
    var val = $prev[0].defaultValue;
    if (val != "prev" && val != undefined) {
        $(elems[0]).prev().click();
    }
    else {
        var page = pageNum-1;
        var sortedColumn = getSortedColumn();        
        var dataPost = { page: page, columnId: sortedColumn.columnId, src: sortedColumn.src};
        $.ajax({
            url: '/Home/CustomersPart',
            data: dataPost,
            success: function (data) {
                $("#partialContent").html(data);
            },
            error: function (jqXHR, exception) { AjaxError(jqXHR, exception); }
        })
    }

}

function nextPage(elem) {
    var elems = document.getElementsByClassName("selectedpage");
    $(elems[0]).next().click();    
}

function searchClick() {
    var searchtext = $('#searchText').val();
    setCookie('searchtext', searchtext);
    getNewTable();
}

function editCustomer(customerId) {    
    $.ajax({
        url: '/Home/EditOrNewCustomer',
        data: { customerId: customerId },
        success: function (data) {
            $("#partialContent").html(data);
        },
        error: function (jqXHR, exception) { AjaxError(jqXHR, exception); }
    })
}

function cancelEdit() {
    window.location.href = '/Home/Customers';
}

function saveEdit() {
    $("#customerEditForm").submit();
}