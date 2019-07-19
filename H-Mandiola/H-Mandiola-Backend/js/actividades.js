$(document).ready(function () {
    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    $("#usernameNavBar").text(getCookie("username"));

    $.getJSON("/api/Consecutivos", function (data) {
        console.log(data);
        var filas = '';
        data.forEach(function (fila) {
            if (fila['Descripcion'] == "Actividad") {
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
        $.getJSON("/api/Actividades/BuscarActividad?codigo=" + codigo, function (data) {
            $('#consecutivoDropdown').append('<option value="' + data["Codigo_Consecutivo"] + '">' + data["Codigo_Consecutivo"] + '</option>');
            $("#consecutivoDropdown").val(data["Codigo_Consecutivo"]);
            $("#codigoBox").val(data["Codigo_Consecutivo"]);
            $("#descripcionBox").val(data["Descripcion"]);
            $("#nombreBox").val(data["Nombre"]);
            $('#imagen').attr('src', data["Imagen"])

        });
    }

    $("#btnImagen").change(function (e) {
        e.preventDefault();
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                base64 = e.target.result;
                $('#imagen').attr('src', e.target.result);
                //$('#imageString').text(e.target.result);
            };

            reader.readAsDataURL(this.files[0])
        };
    });

    $('#btnAceptar').click(function (e) {
        e.preventDefault();
        if (codigo != '0') {
            var Codigo_Consecutivo = $('#codigoBox').val();
            var Nombre = $('#nombreBox').val();
            var Descripcion = $('#descripcionBox').val();;
            var Imagen = $('#imagen').attr('src');
            resJSON = JSON.stringify({ Codigo_Consecutivo: Codigo_Consecutivo, Nombre: Nombre, Descripcion: Descripcion, Imagen: Imagen });
            $.ajax({
                type: "post",
                url: "api/Actividades/ModificarActividad",
                data: JSON.stringify({ Codigo_Consecutivo: Codigo_Consecutivo, Nombre: Nombre, Descripcion: Descripcion, Imagen: Imagen }),
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

            var Codigo_Registro = Codigo_Consecutivo;
            var Usuario = getCookie("username");
            var today = new Date();
            var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
            var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
            var Fecha_Hora = date + ' ' + time;
            var Tipo = "Modificar";
            var Descripcion = "Habitacion";
            var Detalle = JSON.stringify({ Codigo_Consecutivo: Codigo_Consecutivo, Nombre: Nombre, Descripcion: Descripcion, Imagen: Imagen });
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
        else {
            var Codigo_Consecutivo = $('#codigoBox').val();
            var Prefijo = Codigo_Consecutivo.substring(0, Codigo_Consecutivo.indexOf('-'));
            var Nombre = $('#nombreBox').val();
            var Descripcion = $('#descripcionBox').val();;
            var Imagen = $('#imagen').attr('src');
            resJSON = JSON.stringify({ Codigo_Consecutivo: Codigo_Consecutivo, Prefijo: Prefijo, Nombre: Nombre, Descripcion: Descripcion, Imagen: Imagen });
            $.ajax({
                type: "post",
                url: "api/Actividades/AgregarActividad",
                data: JSON.stringify({ Codigo_Consecutivo: Codigo_Consecutivo, Prefijo: Prefijo, Nombre: Nombre, Descripcion: Descripcion, Imagen: Imagen }),
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

            var Codigo_Registro = Codigo_Consecutivo;
            var Usuario = getCookie("username");
            var today = new Date();
            var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
            var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
            var Fecha_Hora = date + ' ' + time;
            var Tipo = "Agregar";
            var Descripcion = "Habitacion";
            var Detalle = JSON.stringify({ Codigo_Consecutivo: Codigo_Consecutivo, Prefijo: Prefijo, Nombre: Nombre, Descripcion: Descripcion, Imagen: Imagen });
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

    $('#btnCerrar').click(function (e) {
        e.preventDefault();
        window.location.replace("lista_actividades.html");
    });

    $('#btnBorrar').click(function (e) {
        e.preventDefault();
        window.location.replace("actividades.html");
    });

});