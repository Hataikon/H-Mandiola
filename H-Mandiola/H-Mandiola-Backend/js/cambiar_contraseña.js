$(document).ready(function () {

    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    $("#usernameNavBar").text(getCookie("username"));

    $('#btnGuardar').click(function (e) {
        e.preventDefault();
        var Password = $('#newPasswordBox').val();
        var Username = getCookie("username");
        var resJSON = JSON.stringify({ Username: Username, Password: Password });
        alert(resJSON);
        console.log(resJSON);
        $.ajax({
            type: "post",
            url: "api/Usuarios/CambiarContraseña",
            data: JSON.stringify({ Username: Username, Password: Password }),
            dataType: "json",
            contentType: "application/json",
            success: function (response) {
                console.log(response.msg)
                alert(response.msg)
            }
        });
    });

    $('#btnCancelar').click(function (e) {
        e.preventDefault();
        window.location.replace("default.html");
    });
});