﻿$(document).ready(function () {
    gapi.load('auth2', function () {
        gapi.auth2.init();
    });
    

    $('#btnAceptar').click(function (e) {
        e.preventDefault();
        var Itinerario = $('#itinerario').val();
        var Cantidad_De_Dias = $('#cantDias').val();
        var Codigo_De_Habitacion = $('#tipoHabitacion').val();
        var Cantidad_De_Habitaciones = $('#cantHabitaciones"').val();
        var Cantidad_De_Personas = $('#cantPersonas').val();
        var Codigo_De_Precio = $('#promoCode').val();
        var resJSON = JSON.stringify({ Itinerario: Itinerario, Cantidad_De_Dias: Cantidad_De_Dias, Codigo_De_Habitacion: Codigo_De_Habitacion, Cantidad_De_Habitaciones: Cantidad_De_Habitaciones, Cantidad_De_Personas: Cantidad_De_Personas, Codigo_De_Precio: Codigo_De_Precio });
        alert(resJSON);
        $.ajax({
            type: "post",
            url: "api/ReservacionesDeHabitaciones/AgregarReservacion",
            data: JSON.stringify({ Itinerario: Itinerario, Cantidad_De_Dias: Cantidad_De_Dias, Codigo_De_Habitacion: Codigo_De_Habitacion, Cantidad_De_Habitaciones: Cantidad_De_Habitaciones, Cantidad_De_Personas: Cantidad_De_Personas, Codigo_De_Precio: Codigo_De_Precio }),
            dataType: "json",
            contentType: "application/json",
            success: function (response) {
                console.log(response.msg)
                alert(response.msg)
            },

            error: function (response) {
                console.log(response);
                window.location.replace("error.html?error=" + response.status + "&men=Error_Agregando_Consecutivo");
            }
        });


    })
});

function getCookie(name) {
    var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
    return v ? v[2] : null;
};

function signOut() {
    if (getCookie("username") == "google") {
        var auth2 = gapi.auth2.getAuthInstance();
        auth2.signOut().then(function () {
            console.log('User signed out.');
            document.cookie = "username=;path=/";
            location.href = 'Home.html';
        });
    }
    else {
        document.cookie = "username=;path=/";
        location.href = 'Home.html';
    }
}