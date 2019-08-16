$(document).ready(function () {

    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    $("#usernameNavBar").text(getCookie("username"));
    console.log(getCookie("isAdmin"));
    //if ((getCookie("isAdmin") == "" || getCookie.("isAdmin") == " ") && (getCookie("isSeguridad") == "" || getCookie("isSeguridad") == " ")) {
    if (getCookie("isAdmin") == "" && getCookie("isSeguridad") == "") {
        alert("Ud no posee los permisos necesarios para acceder a esta pagina. Por favor contactar al administrador del sitio para solicitarlos");
        window.location.replace("default.html");

