$(document).ready(function () {
    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    $("#usernameNavBar").text(getCookie("username"));

    if (getCookie("isAdmin") == "" && getCookie("isMantenimiento") == "") {
        alert("Ud no posee los permisos necesarios para acceder a esta pagina. Por favor contactar al administrador del sitio para solicitarlos");
        window.location.replace("default.html");
    }

    $.getJSON("/api/Consecutivos", function (data) {
        console.log(data);
        var filas = '';
        data.forEach(function (fila) {
            if (fila['Descripcion'] == "Precio") {
                $('#consecutivoDropdown').append('<option value="' + fila['Prefijo'].trim() + "-" + fila["Codigo_Consecutivo"].trim() + '">' + fila['Prefijo'].trim() + "-" + fila["Codigo_Consecutivo"].trim() + '</option>');
            }
        })
        $("#codigoBox").val($('#consecutivoDropdown').val());

    });

    $("#consecutivoDropdown").change(function (e) {
        e.preventDefault();
        $("#codigoBox").val($(this).children("option:selected").val());
    });

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

    var codigo = getUrlParam('codigo', '0');

    if (codigo != '0') {
        $.getJSON("/api/Precios/BuscarPrecio?codigo=" + codigo, function (data) {
            $('#consecutivoDropdown').append('<option value="' + data["Codigo_Consecutivo"] + '">' + data["Codigo_Consecutivo"] + '</option>');
            $("#consecutivoDropdown").val(data["Codigo_Consecutivo"]);
            $("#codigoBox").val(data["Codigo_Consecutivo"]);
            $("#precioDropdown").val(data["Tipo"]);
            $("#precioBox").val(data["Precio"])

        });
    }

    $('#btnAceptar').click(function (e) {
        e.preventDefault();
        if (codigo != '0') {
            var Codigo_Consecutivo = $('#codigoBox').val();
            var Tipo = $('#precioDropdown').val();
            var Precio = $('#precioBox').val();
            resJSON = JSON.stringify({ Codigo_Consecutivo: Codigo_Consecutivo, Tipo: Tipo, Precio: Precio });
            $.ajax({
                type: "post",
                url: "api/Precios/ModificarPrecio",
                data: JSON.stringify({ Codigo_Consecutivo: Codigo_Consecutivo, Tipo: Tipo, Precio: Precio }),
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

            var Codigo_Registro = Codigo_Consecutivo;
            var Usuario = getCookie("username");
            var today = new Date();
            var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
            var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
            var Fecha_Hora = date + ' ' + time;
            var Tipo = "Modificar";
            var Descripcion = "Precio";
            var Detalle = JSON.stringify({ Codigo_Consecutivo: Codigo_Consecutivo, Tipo: Tipo, Precio: Precio });
            $.ajax({
                type: "post",
                url: "api/Bitacora/AgregarRegistro",
                data: JSON.stringify({ Codigo_Registro: Codigo_Registro, Usuario: Usuario, Fecha_Hora: Fecha_Hora, Tipo: Tipo, Descripcion: Descripcion, Detalle: Detalle }),
                dataType: "json",
                contentType: "application/json",
                success: function (response) {
                    console.log(response.msg)
                    window.location.replace("lista_precios.html");
                },

                error: function (response) {
                    console.log(response);
                    window.location.replace("error.html?error=" + response.status + "&men=Error_Agregando_Consecutivo");
                }
            });

        }
        else {
            var Codigo_Consecutivo = $('#codigoBox').val();
            var Prefijo = Codigo_Consecutivo.substring(0, Codigo_Consecutivo.indexOf('-'));
            var Tipo = $('#precioDropdown').val();
            var Precio = $('#precioBox').val();
            resJSON = JSON.stringify({ Codigo_Consecutivo: Codigo_Consecutivo, Prefijo: Prefijo, Tipo: Tipo, Precio: Precio });
            $.ajax({
                type: "post",
                url: "api/Precios/AgregarPrecio",
                data: JSON.stringify({ Codigo_Consecutivo: Codigo_Consecutivo, Prefijo: Prefijo, Tipo: Tipo, Precio: Precio }),
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

            var Codigo_Registro = Codigo_Consecutivo;
            var Usuario = getCookie("username");
            var today = new Date();
            var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
            var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
            var Fecha_Hora = date + ' ' + time;
            var Tipo = "Agregar";
            var Descripcion = "Habitacion";
            var Detalle = JSON.stringify({ Codigo_Consecutivo: Codigo_Consecutivo, Prefijo: Prefijo, Tipo: Tipo, Precio: Precio });
            $.ajax({
                type: "post",
                url: "api/Bitacora/AgregarRegistro",
                data: JSON.stringify({ Codigo_Registro: Codigo_Registro, Usuario: Usuario, Fecha_Hora: Fecha_Hora, Tipo: Tipo, Descripcion: Descripcion, Detalle: Detalle }),
                dataType: "json",
                contentType: "application/json",
                success: function (response) {
                    console.log(response.msg)
                    window.location.replace("lista_precios.html");
                },

                error: function (response) {
                    console.log(response);
                    window.location.replace("error.html?error=" + response.status + "&men=Error_Agregando_Consecutivo");
                }
            });
        }

    });

    $('#btnCerrar').click(function (e) {
        e.preventDefault();
        window.location.replace("lista_precios.html");
    });

    $('#btnBorrar').click(function (e) {
        e.preventDefault();
        window.location.replace("precios.html");
    });

});