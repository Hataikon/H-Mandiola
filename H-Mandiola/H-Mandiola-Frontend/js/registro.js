$(document).ready(function () {

    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    if (getCookie("username") != 0) {
        location.href = 'Home.html';
    }


    $('#btnAceptar').click(function (e) {
        e.preventDefault();
        var Username = $('#usernameBox').val();
        var Password = $('#passwordBox').val();
        var Email = $('#emailBox').val();
        var Nombre = $('#nombreBox').val();
        var Primer_Apellido = $('#primerApellidoBox').val();
        var Segundo_Apellido = $('#segundoApellidoBox').val();
        var resJSON = JSON.stringify({ Username: Username, Password: Password, Email: Email, Nombre: Nombre, Primer_Apellido: Primer_Apellido, Segundo_Apellido: Segundo_Apellido });
        alert(resJSON);
        console.log(resJSON);
        $.ajax({
            type: "post",
            url: "https://localhost:44331/api/Cliente/AgregarCliente",
            data: JSON.stringify({ Username: Username, Password: Password, Email: Email, Nombre: Nombre, Primer_Apellido: Primer_Apellido, Segundo_Apellido: Segundo_Apellido }),
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
        window.location.replace("Home.html");
    });
});