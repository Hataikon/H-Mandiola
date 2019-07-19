$(document).ready(function () {
    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    $("#usernameNavBar").text(getCookie("username"));

    if (getCookie("isAdmin") == "" && getCookie("isMantenimiento") == "" && getCookie("isConsecutivo") == "") {
        alert("Ud no posee los permisos necesarios para acceder a esta pagina. Por favor contactar al administrador del sitio para solicitarlos");
        window.location.replace("default.html");
    }

    var cargarDatos = function () {
        $.getJSON("/api/Consecutivos", function (data) {
            console.log(data);
            var filas = '';
            data.forEach(function (fila) {
                filas += '<tr><td>' + fila['Prefijo'] + '</td><td>' + fila['Codigo_Consecutivo'] +
                    '</td><td>' + fila['Descripcion'] + '</td><td><a href=' + 'consecutivos.html?prefijo=' + fila['Prefijo'] + '>' + "Editar" + '</a>' + '</td></tr>';
            })
            $('#tbDatos tbody').append(filas);

        });
    };
    cargarDatos();

    $('#btnNuevo').click(function (e) {
        e.preventDefault();
        window.location.replace("consecutivos.html");
    });
});