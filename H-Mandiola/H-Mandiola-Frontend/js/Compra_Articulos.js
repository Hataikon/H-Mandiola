$(document).ready(function () {
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

window['gapiStart'] = function () {
    gapi.load('auth2', function () {
        gapi.auth2.init();
    });
}