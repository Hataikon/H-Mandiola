﻿$(document).ready(function () {
    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    $("#usernameNavBar").text(getCookie("username"));

    var cargarDatos = function () {
        $.getJSON("/api/Activos", function (data) {
            console.log(data);
            var filas = '';
            data.forEach(function (fila) {
                filas += '<tr><td>' + fila['Codigo_Consecutivo'] + '</td><td>' + fila['Prefijo'] +
                    '</td><td>' + fila['Nombre'] + '</td><td>' + fila['Descripcion'] +
                    '</td><td><a href=' + 'activos.html?codigo=' + fila['Codigo_Consecutivo'] + '>' + "Editar" + '</a>' + '</td></tr>';
            })
            $('#tbDatos tbody').append(filas);

        });
    };
    cargarDatos();

    $('#btnNuevo').click(function (e) {
        e.preventDefault();
        window.location.replace("activos.html");
    });


});