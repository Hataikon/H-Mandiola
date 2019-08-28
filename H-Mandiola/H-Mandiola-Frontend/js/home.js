$(document).ready(function () {
    function statusChangeCallback(response) {
        console.log('statusChangeCallback');
        console.log(response);
        if (response.status === 'connected') {
            testAPI();
        } else {
        }
    }

    function checkLoginState() {
        FB.getLoginStatus(function (response) {
            statusChangeCallback(response);
        });
    }

    window.fbAsyncInit = function () {
        FB.init({
            appId: '325295755065651',
            cookie: true,
            xfbml: true,
            version: 'v4.0'
        });

        FB.getLoginStatus(function (response) {
            statusChangeCallback(response);
        });
    };

    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "https://connect.facebook.net/en_US/sdk.js";
        fjs.parentNode.insertBefore(js, fjs);
    }(document, 'script', 'facebook-jssdk'));


    function testAPI() {
        console.log('Welcome!  Fetching your information.... ');
        FB.api('/me', function (response) {
            console.log('Successful login for: ' + response.name);
            document.cookie = "username=facebook;path=/";
            document.cookie = "token=" + FB.getAccessToken() + ";path=/";
        });
    }

    if (getCookie("username") != 0) {
        $('#navBar').append('<li><a href="Ajustes_Cuenta.html">Cuenta</a></li>');
        $('#navBar').append('<li><a href="Reservaciones_Pagadas.html">Reservaciones</a></li>');
        $('#navBar').append('<li class="float-right bg-light"><a class="active" onclick="signOut()">Cerrar Sesion</a></li>');
    }
    else {
        $('#navBar').append('<li><a href="Login.html">Iniciar sesion</a></li>');
        $('#navBar').append('<li><a href="Registro.html">Registrarse</a></li>');
    }

});

window['gapiStart'] = function () {
    gapi.load('auth2', function () {
        gapi.auth2.init();
    });
}

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
    else if (getCookie("username") == "facebook") {
        FB.logout(function (response) {
            document.cookie = "username=;path=/";
            location.href = 'Home.html';
        });
    }
    else {
        document.cookie = "username=;path=/";
        location.href = 'Home.html';
    }
}
