﻿$(document).ready(function () {
    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    $("#usernameNavBar").text(getCookie("username"));

    var cargarDatos = function () {
        $.getJSON("/api/Bitacora", function (data) {
            console.log(data);
            var filas = '';
            data.forEach(function (fila) {
                filas += '<tr><td>' + fila['Codigo_Registro'] + '</td><td>' + fila['Usuario'] +
                    '</td><td>' + fila['Fecha_Hora'] + '</td><td>' + fila['Tipo'] + '</td><td>' + fila['Descripcion'] + '</td><td>' + fila['Detalle'] + '</td></tr>';
            })
            $('#tbDatos tbody').append(filas);

        });
    };
    cargarDatos();

});