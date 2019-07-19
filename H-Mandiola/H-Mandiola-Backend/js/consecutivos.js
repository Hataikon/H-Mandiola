$(document).ready(function () {

    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    $("#usernameNavBar").text(getCookie("username"));

    function getUrlVars() {
        var vars = {};
        var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
            vars[key] = value;
        });
        return vars;
    };

    function getUrlParam(parameter, defaultvalue) {
        var urlparameter = defaultvalue;
        if (window.location.href.indexOf(parameter) > -1) {
            urlparameter = getUrlVars()[parameter];
        }
        return urlparameter;
    };

    var prefijo = getUrlParam('prefijo', '0');

    if (prefijo != '0') {
        $.getJSON("/api/Consecutivos/BuscarConsecutivo?prefijo=" + prefijo, function (data) {
            $("#descripcionDropdown").val(data["Descripcion"]);
            $("#consecutivoBox").val(data["Codigo_Consecutivo"]);
            $("#prefijoBox").val(data["Prefijo"]);
            $("#riBox").val(data["Rango_Inicial"]);
            $("#rfBox").val(data["Rango_Final"]);

        });
    }

    $('#btnAceptar').click(function (e) {
        if (prefijo != '0') {
            e.preventDefault();
            var Prefijo = $('#prefijoBox').val();
            var Descripcion = $('#descripcionDropdown').val();
            var CODIGO_CONSECUTIVO = $('#consecutivoBox').val();
            var Rango_Inicial = $('#riBox').val();
            var Rango_Final = $('#rfBox').val();
            var resJSON = JSON.stringify({ Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO, Rango_Inicial: Rango_Inicial, Rango_Final: Rango_Final });
            alert(resJSON);
            $.ajax({
                type: "post",
                url: "api/Consecutivos/ModificarConsecutivo",
                data: JSON.stringify({ Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO, Rango_Inicial: Rango_Inicial, Rango_Final: Rango_Final }),
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

            var Codigo_Registro = Prefijo;
            var Usuario = getCookie("username");
            var today = new Date();
            var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
            var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
            var Fecha_Hora = date + ' ' + time;
            var Tipo = "Modificar";
            var Descripcion = "Consecutivo";
            var Detalle = JSON.stringify({ Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO, Rango_Inicial: Rango_Inicial, Rango_Final: Rango_Final });
            $.ajax({
                type: "post",
                url: "api/Bitacora/AgregarRegistro",
                data: JSON.stringify({ Codigo_Registro: Codigo_Registro, Usuario: Usuario, Fecha_Hora: Fecha_Hora, Tipo: Tipo, Descripcion: Descripcion, Detalle: Detalle }),
                dataType: "json",
                contentType: "application/json",
                success: function (response) {
                    console.log(response.msg);
                },

                error: function (response) {
                    console.log(response);
                    window.location.replace("error.html?error=" + response.status + "&men=Error_Agregando_Consecutivo");
                }
            });
        }
        else {
            e.preventDefault();
            var Prefijo = $('#prefijoBox').val();
            var Descripcion = $('#descripcionDropdown').val();
            var CODIGO_CONSECUTIVO = $('#consecutivoBox').val();
            var Rango_Inicial = $('#riBox').val();
            var Rango_Final = $('#rfBox').val();
            var resJSON = JSON.stringify({ Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO, Rango_Inicial: Rango_Inicial, Rango_Final: Rango_Final });
            alert(resJSON);
            console.log(resJSON);
            $.ajax({
                type: "post",
                url: "api/Consecutivos/AgregarConsecutivo",
                data: JSON.stringify({ Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO, Rango_Inicial: Rango_Inicial, Rango_Final: Rango_Final }),
                dataType: "json",
                contentType: "application/json",
                success: function (response) {
                    console.log(response.msg);
                },
                error: function (response) {
                    console.log(response);
                    window.location.replace("error.html?error=" + response.status + "&men=Error_Agregando_Consecutivo");
                }
            });

            var Codigo_Registro = Prefijo;
            var Usuario = getCookie("username");
            var today = new Date();
            var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
            var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
            var Fecha_Hora = date + ' ' + time;
            var Tipo = "Agregar";
            var Descripcion = "Consecutivo";
            var Detalle = JSON.stringify({ Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO, Rango_Inicial: Rango_Inicial, Rango_Final: Rango_Final });
            $.ajax({
                type: "post",
                url: "api/Bitacora/AgregarRegistro",
                data: JSON.stringify({ Codigo_Registro: Codigo_Registro, Usuario: Usuario, Fecha_Hora: Fecha_Hora, Tipo: Tipo, Descripcion: Descripcion, Detalle: Detalle }),
                dataType: "json",
                contentType: "application/json",
                success: function (response) {
                    console.log(response.msg)
                },

                error: function (response) {
                    console.log(response);
                    window.location.replace("error.html?error=" + response.status + "&men=Error_Agregando_Consecutivo");
                }
            });
        }
    });

    $('#btnCancelar').click(function (e) {
        e.preventDefault();
        window.location.replace("lista_consecutivos.html");
    });

    $('#btnNuevo').click(function (e) {
        e.preventDefault();
        window.location.replace("consecutivos.html");
    });
});