$(document).ready(function () {
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

window.fbAsyncInit = function () {
    FB.init({
        appId: '325295755065651',
        cookie: true,
        xfbml: true,
        version: 'v3.3'
    });

    // Now that we've initialized the JavaScript SDK, we call
    // FB.getLoginStatus().  This function gets the state of the
    // person visiting this page and can return one of three states to
    // the callback you provide.  They can be:
    //
    // 1. Logged into your app ('connected')
    // 2. Logged into Facebook, but not your app ('not_authorized')
    // 3. Not logged into Facebook and can't tell if they are logged into
    //    your app or not.
    //
    // These three cases are handled in the callback function.

    FB.Login(function (response) {
        if (response.authResponse) {
            var access_token = FB.getAuthResponse()['accessToken'];
            console.log('Access Token = ' + access_token);
            FB.api('/me', function (response) {
                console.log('Good to see you, ' + response.name + '.');
            });
        } else {
            console.log('User cancelled login or did not fully authorize.');
        }
    }, { scope: '' });
};

// Load the SDK asynchronously
(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "https://connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

// Here we run a very simple test of the Graph API after login is
// successful.  See statusChangeCallback() for when this call is made.
function testAPI() {
    console.log('Welcome!  Fetching your information.... ');
    FB.api('/me', function (response) {
        console.log('Successful login for: ' + response.name);
        document.getElementById('status').innerHTML =
            'Thanks for logging in, ' + response.name + '!';
    });
}

function handleSessionResponse(response) {
    //if we dont have a session (which means the user has been logged out, redirect the user)
    if (!response.session) {
        window.location = "Login.html";
        return;
    }
}


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