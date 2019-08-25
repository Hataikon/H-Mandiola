$(document).ready(function () {
    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    if (getCookie("username") != 0) {
        location.href = 'Home.html';
    }
    else {
        document.cookie = "username=;path=/";
    }

    var a = Math.ceil(Math.random() * 9) + '';
    var b = Math.ceil(Math.random() * 9) + '';
    var c = Math.ceil(Math.random() * 9) + '';
    var d = Math.ceil(Math.random() * 9) + '';
    var e = Math.ceil(Math.random() * 9) + '';

    var code = a + b + c + d + e;
    document.getElementById("txtCaptcha").value = code;
    document.getElementById("CaptchaDiv").innerHTML = code;

    $('#btnAceptar').click(function (e) {
        e.preventDefault();
        var username = $('#usernameBox').val();
        var password = $('#passwordBox').val();
        if (ValidCaptcha()) {
            $.getJSON("https://localhost:44331/api/Cliente/BuscarCliente?username=" + username + "&password=" + password, function (data) {
                console.log("/api/Usuarios/BuscarUsuario?username=" + username + "&password=" + password);
                if (data == null) {
                    alert("El usuario o la contraseña es erronea, por favor intente otra vez");
                }
                else {
                    document.cookie = "username=" + data["Username"] + ";path=/";
                    window.location.replace("Home.html");
                }
                console.log(data);
            });
        }
        else {
            alert("Captcha Incorrecto");
            changeCaptchaVal();
        }
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

function changeCaptchaVal() {
    var a = Math.ceil(Math.random() * 9) + '';
    var b = Math.ceil(Math.random() * 9) + '';
    var c = Math.ceil(Math.random() * 9) + '';
    var d = Math.ceil(Math.random() * 9) + '';
    var e = Math.ceil(Math.random() * 9) + '';

    var code = a + b + c + d + e;
    document.getElementById("txtCaptcha").value = code;
    document.getElementById("CaptchaDiv").innerHTML = code;
}
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
    location.href = 'Home.html';
}

function signOut() {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        console.log('User signed out.');
    });
}

//Facebook Stuff
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
        AddCookieFB();
    });
}

function AddCookieFB() {
    document.cookie = "username=facebook;path=/";
    document.cookie = "token=" + FB.getAccessToken() + ";path=/";
    location.href = 'Home.html';
}