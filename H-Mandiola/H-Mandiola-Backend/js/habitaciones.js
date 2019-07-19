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
            if (fila['Descripcion'] == "Habitacion") {
                $('#consecutivoDropdown').append('<option value="' + fila['Prefijo'].trim() + "-" + fila["Codigo_Consecutivo"].trim() + '">' + fila['Prefijo'].trim() + "-" + fila["Codigo_Consecutivo"].trim() + '</option>');
            }
        })
        $("#codigoBox").val($('#consecutivoDropdown').val());

    });

    $("#consecutivoDropdown").change(function (e) {
        e.preventDefault();
        $("#codigoBox").val($(this).children("option:selected").val());
    });

    $("#btnImagen").change(function (e) {
        e.preventDefault();
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                base64 = e.target.result;
                $('#imagen').attr('src', e.target.result).width(150).height(200);
                $('#imageString').text(e.target.result);
            };

            reader.readAsDataURL(this.files[0])
        };
    });

    $('#btnAceptar').click(function (e) {
        e.preventDefault();
        var Codigo_Consecutivo = $('#codigoBox').val();
        var Prefijo;
        var Numero;
        var Descripcion;
        var image = $('#imageString').text();
        
        console.log(image);
        /*resJSON = JSON.stringify({ Username: Username, isAdmin: isAdmin, isSeguridad: isSeguridad, isConsecutivo: isConsecutivo, isMantenimiento: isMantenimiento, isConsulta: isConsulta });
        alert(resJSON);
        console.log(resJSON);
        $.ajax({
            type: "post",
            url: "api/Usuarios/ActualizarRoles",
            data: JSON.stringify({ Username: Username, isAdmin: isAdmin, isSeguridad: isSeguridad, isConsecutivo: isConsecutivo, isMantenimiento: isMantenimiento, isConsulta: isConsulta }),
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
        });*/
    });


});