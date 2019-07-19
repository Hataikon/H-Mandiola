$(document).ready(function () {
    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    $("#usernameNavBar").text(getCookie("username"));

    var cargarDatos = function () {
        $.getJSON("/api/Usuarios", function (data) {
            console.log(data);
            var filas = '';
            data.forEach(function (fila) {
                $('#selectmultiple').append('<option value="' + fila['Username'] + '">' + fila['Username'] + '</option>');
            })

        });
    };

    cargarDatos();

    $("#selectmultiple").change(function (e) {
        e.preventDefault();
        var username = $(this).children("option:selected").val();

        $.getJSON("/api/Usuarios/BuscarUsuario2?username=" + username, function (data) {
            console.log("/api/Usuarios/BuscarUsuario2?username=" + username);
            if (data["isAdmin"] == 1) {
                $('#rolesCheckboxes-1').prop('checked', true);
            }
            else {
                $('#rolesCheckboxes-1').prop('checked', false);
            }

            if (data["isSeguridad"] == 1) {
                $('#rolesCheckboxes-2').prop('checked', true);
            }
            else {
                $('#rolesCheckboxes-2').prop('checked', false);
            }

            if (data["isConsecutivo"] == 1) {
                $('#rolesCheckboxes-3').prop('checked', true);
            }
            else {
                $('#rolesCheckboxes-3').prop('checked', false);
            }

            if (data["isMantenimiento"] == 1) {
                $('#rolesCheckboxes-4').prop('checked', true);
            }
            else {
                $('#rolesCheckboxes-4').prop('checked', false);
            }

            if (data["isConsulta"] == 1) {
                $('#rolesCheckboxes-5').prop('checked', true);
            }
            else {
                $('#rolesCheckboxes-5').prop('checked', false);
            }
        });

    });

    $('#btnActualizar').click(function (e) {
        e.preventDefault();
        var Username = $('#selectmultiple').children("option:selected").val();
        var isAdmin = " ";
        var isSeguridad = " ";
        var isConsecutivo = " ";
        var isMantenimiento = " ";
        var isConsulta = " ";
        if ($("#rolesCheckboxes-1").prop("checked")) {
            isAdmin = 1;
        }
        if ($("#rolesCheckboxes-2").prop("checked")) {
            isSeguridad = 1;
        }
        if ($("#rolesCheckboxes-3").prop("checked")) {
            isConsecutivo = 1;
        }
        if ($("#rolesCheckboxes-4").prop("checked")) {
            isMantenimiento = 1;
        }
        if ($("#rolesCheckboxes-5").prop("checked")) {
            isConsulta = 1;
        }
        var resJSON = JSON.stringify({ Username: Username, isAdmin: isAdmin, isSeguridad: isSeguridad, isConsecutivo: isConsecutivo, isMantenimiento: isMantenimiento, isConsulta: isConsulta });
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
        });
    });

});