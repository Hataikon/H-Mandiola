$(document).ready(function () {
    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    $("#usernameNavBar").text(getCookie("username"));

    if (getCookie("isAdmin") == "" && getCookie("isConsulta") == "") {
        alert("Ud no posee los permisos necesarios para acceder a esta pagina. Por favor contactar al administrador del sitio para solicitarlos");
        window.location.replace("default.html");
    }

    var cargarDatos = function () {
        $.getJSON("/api/Bitacora", function (data) {
            console.log(data);
            var filas = '';
            data.forEach(function (fila) {
                filas += '<tr><td>' + fila['Codigo_Registro'] + '</td><td>' + fila['Usuario'] +
                    '</td><td>' + fila['Fecha_Hora'] + '</td><td>' + fila['Tipo'] + '</td><td>' + fila['Descripcion'] + '</td><td><a href=' + 'detalle_bitacora.html?detalle=' + fila['Detalle'] + '>' + "Detalle" + '</a>' + '</td></tr>';
            })
            $('#tbDatos tbody').append(filas);

        });
    };
    cargarDatos();

});