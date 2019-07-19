$(document).ready(function () {
    document.cookie = "username=;path=/";
    document.cookie = "isAdmin=;path=/";
    document.cookie = "isSeguridad=;path=/";
    document.cookie = "isConsecutivo=;path=/";
    document.cookie = "isMantenimiento=;path=/";
    document.cookie = "isConsulta=;path=/";

    $('#btnAceptar').click(function (e) {
        e.preventDefault();
        var username = $('#usernameBox').val();
        var password = $('#passwordBox').val();
        $.getJSON("/api/Usuarios/BuscarUsuario?username=" + username + "&password=" + password, function (data) {
            console.log("/api/Usuarios/BuscarUsuario?username=" + username + "&password=" + password);
            if (data == null) {
                alert("El usuario o la contraseña es erronea, por favor intente otra vez");
            }
            else {
                document.cookie = "username=" + data["Username"] + ";path=/";
                document.cookie = "isAdmin=" + data["isAdmin"] + ";path=/";
                document.cookie = "isSeguridad=" + data["isSeguridad"] + ";path=/";
                document.cookie = "isConsecutivo=" + data["isConsecutivo"] + ";path=/";
                document.cookie = "isMantenimiento=" + data["isMantenimiento"] + ";path=/";
                document.cookie = "isConsulta=" + data["isConsulta"] + ";path=/";
                window.location.replace("default.html");
            }
            console.log(data);
        });
    });


});