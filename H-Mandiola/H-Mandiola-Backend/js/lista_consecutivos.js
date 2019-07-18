$(document).ready(function () {
    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    $("#usernameNavBar").text(getCookie("username"));

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
});