﻿$(document).ready(function () {

    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    $("#usernameNavBar").text(getCookie("username"));
    console.log(getCookie("isAdmin"));
    //if ((getCookie("isAdmin") == "" || getCookie.("isAdmin") == " ") && (getCookie("isSeguridad") == "" || getCookie("isSeguridad") == " ")) {
    if (getCookie("isAdmin") == "" && getCookie("isSeguridad") == "") {
        alert("Ud no posee los permisos necesarios para acceder a esta pagina. Por favor contactar al administrador del sitio para solicitarlos");
        window.location.replace("default.html");
    }

    $('#btnGuardar').click(function (e) {
        e.preventDefault();
        var Username = $('#usernameBox').val();
        var Password = $('#passwordBox').val();
        var Email = $('#emailBox').val();
        var Pregunta = $('#preguntaDropdown').val();
        var Respuesta = $('#respuestaBox').val();
        var resJSON = JSON.stringify({ Username: Username, Password: Password, Email: Email, Pregunta: Pregunta, Respuesta: Respuesta });
        alert(resJSON);
        console.log(resJSON);
        $.ajax({
            type: "post",
            url: "api/Usuarios/AgregarUsuario",
            data: JSON.stringify({ Username: Username, Password: Password, Email: Email, Pregunta: Pregunta, Respuesta: Respuesta }),
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