$(document).ready(function () {
    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    $("#usernameNavBar").text(getCookie("username"));

    function getUrlVars() {
        var vars = {};
        var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
            vars[key] = value;
        });
        return vars;
    };

    function getUrlParam(parameter, defaultvalue) {
        var urlparameter = defaultvalue;
        if (window.location.href.indexOf(parameter) > -1) {
            urlparameter = getUrlVars()[parameter];
        }
        return urlparameter;
    };

    $("#error_msg").text("Numero de Error: " + getUrlParam('error', '0') + " // Mensaje de Error: " + getUrlParam('men', '0'));

    if (getUrlParam('error', '0') != '0') {
        var Numero_Error = getUrlParam('error', '0');
        var today = new Date();
        var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
        var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
        var Fecha_Error = date + ' ' + time;
        var Mensaje_Error = getUrlParam('men', '0');
        $.ajax({
            type: "post",
            url: "api/Error/AgregarError",
            data: JSON.stringify({ Numero_Error: Numero_Error, Fecha_Error: Fecha_Error, Mensaje_Error: Mensaje_Error }),
            dataType: "json",
            contentType: "application/json",
            success: function (response) {
                console.log(response.msg)
            }
        });
    }

});