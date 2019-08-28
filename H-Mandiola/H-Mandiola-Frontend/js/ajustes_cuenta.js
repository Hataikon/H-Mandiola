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

    $('#btnGuardar').click(function (e) {
        e.preventDefault();
        var Password = $('#newPasswordBox').val();
        var Username = getCookie("username");
        var resJSON = JSON.stringify({ Username: Username, Password: Password });
        alert(resJSON);
        console.log(resJSON);
        $.ajax({
            type: "post",
            url: "https://localhost:44331/api/Cliente/CambiarContraseña",
            data: JSON.stringify({ Username: Username, Password: Password }),
            dataType: "json",
            contentType: "application/json",
            success: function (response) {
                console.log(response.msg)
                alert(response.msg)
            },
            error: function (response) {
                console.log(response);
            }
        });
    });

    $('#btnCancelar').click(function (e) {
        e.preventDefault();
        window.location.replace("Home.html");
    });
});

function getCookie(name) {
    var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
    return v ? v[2] : null;
};

window['gapiStart'] = function () {
    gapi.load('auth2', function () {
        gapi.auth2.init();
    });
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