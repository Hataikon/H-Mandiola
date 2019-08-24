$(document).ready(function () {
    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    if (getCookie("username") != 0) {
        location.href = 'Reservaciones_Pagadas.html';
    }
    else {
        document.cookie = "username=;path=/";
    }

    $('#btnAceptar').click(function (e) {
        e.preventDefault();
        var username = $('#usernameBox').val();
        var password = $('#passwordBox').val();
        $.getJSON("https://localhost:44331/api/Usuarios/BuscarUsuario?username=" + username + "&password=" + password, function (data) {
            console.log("/api/Usuarios/BuscarUsuario?username=" + username + "&password=" + password);
            if (data == null) {
                alert("El usuario o la contraseña es erronea, por favor intente otra vez");
            }
            else {
                document.cookie = "username=" + data["Username"] + ";path=/";
                if (ValidCaptcha()) {
                    window.location.replace("Reservaciones_Pagadas.html");
                }
                else {
                    alert("El captcha es incorrecto");
                }
                
            }
            console.log(data);
        });
    });

});

//Captcha Stuff

function checkform(theform) {
    var why = "";

    if (theform.CaptchaInput.value == "") {
        why += "- Please Enter CAPTCHA Code.\n";
    }
    if (theform.CaptchaInput.value != "") {
        if (ValidCaptcha(theform.CaptchaInput.value) == false) {
            why += "- The CAPTCHA Code Does Not Match.\n";
        }
    }
    if (why != "") {
        alert(why);
        return false;
    }
}

var a = Math.ceil(Math.random() * 9) + '';
var b = Math.ceil(Math.random() * 9) + '';
var c = Math.ceil(Math.random() * 9) + '';
var d = Math.ceil(Math.random() * 9) + '';
var e = Math.ceil(Math.random() * 9) + '';

var code = a + b + c + d + e;
document.getElementById("txtCaptcha").value = code;
document.getElementById("CaptchaDiv").innerHTML = code;

// Validate input against the generated number
function ValidCaptcha() {
    var str1 = removeSpaces(document.getElementById('txtCaptcha').value);
    var str2 = removeSpaces(document.getElementById('CaptchaInput').value);
    if (str1 == str2) {
        return true;
    } else {
        return false;
    }
}

// Remove the spaces from the entered and generated code
function removeSpaces(string) {
    return string.split(' ').join('');
}

//Google Stuff
function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
    console.log('Name: ' + profile.getName());
    console.log('Image URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail()); // This is null if the 'email' scope is not present.
    var id_token = googleUser.getAuthResponse().id_token;
    console.log(id_token);
    document.cookie = "username=google;path=/";
    console.log("Redirecting...")
    location.href = 'Reservaciones_Pagadas.html';
}

function signOut() {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        console.log('User signed out.');
    });
}

//Facebook Stuff
// This is called with the results from from FB.getLoginStatus().
function statusChangeCallback(response) {
    console.log('statusChangeCallback');
    console.log(response);
    // The response object is returned with a status field that lets the
    // app know the current login status of the person.
    // Full docs on the response object can be found in the documentation
    // for FB.getLoginStatus().
    if (response.status === 'connected') {
        // Logged into your app and Facebook.
        testAPI();
    } else {
        // The person is not logged into your app or we are unable to tell.
        document.getElementById('status').innerHTML = 'Please log ' +
            'into this app.';
    }
}

// This function is called when someone finishes with the Login
// Button.  See the onlogin handler attached to it in the sample
// code below.
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

function AddCookieFB() {
    document.cookie = "username=facebook;path=/";
    document.cookie = "token=" + FB.getAccessToken() + ";path=/";
    location.href = 'Reservaciones_Pagadas.html';
}