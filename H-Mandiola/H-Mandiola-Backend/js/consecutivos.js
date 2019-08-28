$(document).ready(function () {

    $("#usernameNavBar").text(getCookie("username"));

    if (getCookie("isAdmin") == "" && getCookie("isMantenimiento") == "" && getCookie("isConsecutivo") == "") {
        alert("Ud no posee los permisos necesarios para acceder a esta pagina. Por favor contactar al administrador del sitio para solicitarlos");
        window.location.replace("default.html");
    }

    var prefijo = getUrlParam('prefijo', '0');

    if (prefijo != '0') {
        $.getJSON("/api/Consecutivos/BuscarConsecutivo?prefijo=" + prefijo, function (data) {
            $("#descripcionDropdown").val(data["Descripcion"]);
            $("#consecutivoBox").val(data["Codigo_Consecutivo"]);
            $("#prefijoBox").val(data["Prefijo"]);
            $("#riBox").val(data["Rango_Inicial"]);
            $("#rfBox").val(data["Rango_Final"]);
            $("#consecutivoBox").prop("disabled", true);
            if (isNaN(parseInt(data["Prefijo"]))) {
                $("#prefijoBox").prop("disabled", false);
            }
            else {
                $("#radioPrefijo-1").prop("checked", true);
                $("#prefijoBox").prop("disabled", true);
            }

            if (data["Rango_Inicial"] == " ") {
                $("#radioRango-1").prop("checked", true);
                $("#riBox").prop("disabled", true);
                $("#riBox").val(" ");
                $("#rfBox").prop("disabled", true);
                $("#rfBox").val(" ");
            }

        });
    }

    $('#radioPrefijo-1').click(function () {
        if ($(this).is(':checked')) {
            $("#prefijoBox").prop("disabled", true);
            if (prefijo != '0') {
                $("#prefijoBox").val(prefijo);
            }
            else {
                $.getJSON("/api/Consecutivos/MaxConsecutivo", function (data) {
                    $("#prefijoBox").val(data["Row_Num"]);

                });
            }
        }
    });

    $('#radioPrefijo-0').click(function () {
        if ($(this).is(':checked')) {
            $("#prefijoBox").prop("disabled", false);
        }
    });

    $('#radioRango-1').click(function () {
        if ($(this).is(':checked')) {
            $("#riBox").prop("disabled", true);
            $("#riBox").val(" ");
            $("#rfBox").prop("disabled", true);
            $("#rfBox").val(" ");
        }
    });

    $('#radioRango-0').click(function () {
        if ($(this).is(':checked')) {
            $("#riBox").prop("disabled", false);
            $("#rfBox").prop("disabled", false);
        }
    });

    $('#btnAceptar').click(function (e) {
        if (prefijo != '0') {
            e.preventDefault();
            var Prefijo = $('#prefijoBox').val();
            var Descripcion = $('#descripcionDropdown').val();
            var CODIGO_CONSECUTIVO = $('#consecutivoBox').val();
            var Rango_Inicial = $('#riBox').val();
            var Rango_Final = $('#rfBox').val();
            var resJSON = JSON.stringify({ Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO, Rango_Inicial: Rango_Inicial, Rango_Final: Rango_Final });
            console.log(resJSON);
            if ($('#riBox').prop("disabled")) {
                $.ajax({
                    type: "post",
                    url: "api/Consecutivos/ModificarConsecutivo",
                    data: JSON.stringify({ Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO, Rango_Inicial: Rango_Inicial, Rango_Final: Rango_Final }),
                    dataType: "json",
                    contentType: "application/json",
                    success: function (response) {
                        console.log(response.msg);
                        AgregarBitacora(Prefijo, Descripcion, CODIGO_CONSECUTIVO, Rango_Inicial, Rango_Final, "Modificar");
                    },

                    error: function (response) {
                        console.log(response);
                        window.location.replace("error.html?error=" + response.status + "&men=Error_Agregando_Consecutivo");
                    }
                });
            }
            else if (parseInt(CODIGO_CONSECUTIVO) >= parseInt(Rango_Inicial) && parseInt(CODIGO_CONSECUTIVO) <= parseInt(Rango_Final)) {
                $.ajax({
                    type: "post",
                    url: "api/Consecutivos/ModificarConsecutivo",
                    data: JSON.stringify({ Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO, Rango_Inicial: Rango_Inicial, Rango_Final: Rango_Final }),
                    dataType: "json",
                    contentType: "application/json",
                    success: function (response) {
                        console.log(response.msg);
                        AgregarBitacora(Prefijo, Descripcion, CODIGO_CONSECUTIVO, Rango_Inicial, Rango_Final, "Modificar");
                    },

                    error: function (response) {
                        console.log(response);
                        window.location.replace("error.html?error=" + response.status + "&men=Error_Agregando_Consecutivo");
                    }
                });
            }
            else {
                alert("El Consecutivo debe estar entre el rango inicial y final")
            }
        }
        else {
            e.preventDefault();
            var Prefijo = $('#prefijoBox').val();
            var Descripcion = $('#descripcionDropdown').val();
            var CODIGO_CONSECUTIVO = $('#consecutivoBox').val();
            var Rango_Inicial = $('#riBox').val();
            var Rango_Final = $('#rfBox').val();
            var resJSON = JSON.stringify({ Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO, Rango_Inicial: Rango_Inicial, Rango_Final: Rango_Final });
            console.log(resJSON);
            if ($('#riBox').prop("disabled")) {
                $.ajax({
                    type: "post",
                    url: "api/Consecutivos/AgregarConsecutivo",
                    data: JSON.stringify({ Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO, Rango_Inicial: Rango_Inicial, Rango_Final: Rango_Final }),
                    dataType: "json",
                    contentType: "application/json",
                    success: function (response) {
                        console.log(response.msg);
                        AgregarBitacora(Prefijo, Descripcion, CODIGO_CONSECUTIVO, Rango_Inicial, Rango_Final, "Agregar");
                    },
                    error: function (response) {
                        console.log(response);
                        window.location.replace("error.html?error=" + response.status + "&men=Error_Agregando_Consecutivo");
                    }
                });
            }
            else if (parseInt(CODIGO_CONSECUTIVO) >= parseInt(Rango_Inicial) && parseInt(CODIGO_CONSECUTIVO) <= parseInt(Rango_Final)) {
                $.ajax({
                    type: "post",
                    url: "api/Consecutivos/AgregarConsecutivo",
                    data: JSON.stringify({ Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO, Rango_Inicial: Rango_Inicial, Rango_Final: Rango_Final }),
                    dataType: "json",
                    contentType: "application/json",
                    success: function (response) {
                        console.log(response.msg);
                        AgregarBitacora(Prefijo, Descripcion, CODIGO_CONSECUTIVO, Rango_Inicial, Rango_Final, "Agregar");
                    },
                    error: function (response) {
                        console.log(response);
                        window.location.replace("error.html?error=" + response.status + "&men=Error_Agregando_Consecutivo");
                    }
                });
            }
            else {
                alert("El Consecutivo debe estar entre el rango inicial y final")
            }

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

function getCookie(name) {
    var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
    return v ? v[2] : null;
};

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

function AgregarBitacora(Prefijo, Descripcion, CODIGO_CONSECUTIVO, Rango_Inicial, Rango_Final, Tipo) {
    var Codigo_Registro = Prefijo;
    var Usuario = getCookie("username");
    var today = new Date();
    var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
    var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
    var Fecha_Hora = date + ' ' + time;
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
            window.location.replace("lista_consecutivos.html")
        },

        error: function (response) {
            console.log(response);
            window.location.replace("error.html?error=" + response.status + "&men=Error_Agregando_Consecutivo");
        }
    });
}