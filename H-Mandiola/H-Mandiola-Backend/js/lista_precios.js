$(document).ready(function () {
    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    $("#usernameNavBar").text(getCookie("username"));

    if (getCookie("isAdmin") == "" && getCookie("isMantenimiento") == "") {
        alert("Ud no posee los permisos necesarios para acceder a esta pagina. Por favor contactar al administrador del sitio para solicitarlos");
        window.location.replace("default.html");
    }

    var cargarDatos = function () {
        $.getJSON("/api/Precios", function (data) {
            console.log(data);
            var filas = '';
            data.forEach(function (fila) {
                filas += '<tr><td>' + fila['Codigo_Consecutivo'] + '</td><td>' + fila['Prefijo'] +
                    '</td><td>' + fila['Tipo'] + '</td><td>' + fila['Precio'] +
                    '</td><td><a href=' + 'precios.html?codigo=' + fila['Codigo_Consecutivo'] + '>' + "Editar" + '</a>' + '</td></tr>';
            })
            $('#tbDatos tbody').append(filas);

        });
    };
    cargarDatos();

    $('#btnNuevo').click(function (e) {
        e.preventDefault();
        window.location.replace("precios.html");
    });

});