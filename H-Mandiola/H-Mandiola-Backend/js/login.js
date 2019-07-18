$(document).ready(function () {
    document.cookie = "username=;path=/";

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
                window.location.replace("default.html");
            }
            console.log(data);
        });
    });


});