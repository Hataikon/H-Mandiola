$(document).ready(function () {
    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    $("#usernameNavBar").text(getCookie("username"));

    if (getCookie("isAdmin") == "" && getCookie("isConsulta") == "") {
        alert("Ud no posee los permisos necesarios para acceder a esta pagina. Por favor contactar al administrador del sitio para solicitarlos");
        window.location.replace("default.html");
    }

    $("#usuario").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#tbDatos tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#tipo").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#tbDatos tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#fi").on("keyup", function () {
        var fi = $(this).val();
        if ($('#fn').val() != 0) {
            var fn = $('#fn').val();
        }
        else {
            fn = new Date(2019, 12, 31);
        }
        $("#tbDatos tr").filter(function () {
            console.log(fi);
            console.log(fn);
            console.log($(this).val());
            $(this).toggle($(this).val() > fi && $(this).val() < fn)
        });
    });

    $('#tbDatos').DataTable({
        columns: [
            { data: 'Codigo_Registro' },
            { data: 'Usuario' },
            { data: 'Fecha_Hora' },
            { data: 'Tipo' },
            { data: 'Descripcion' }
        ],
        ajax: {
            url: "/api/Bitacora",
            dataSrc: ''
        }
    });

    $.fn.dataTable.ext.search.push(
        function (settings, data, dataIndex) {
            var min = $('#min').datepicker("getDate");
            var max = $('#max').datepicker("getDate");
            var Fecha = new Date(data[2]);
            if (min == null && max == null) { return true; }
            if (min == null && Fecha <= max) { return true; }
            if (max == null && Fecha >= min) { return true; }
            if (Fecha <= max && Fecha >= min) { return true; }
            return false;
        }
    );


    $("#min").datepicker({ onSelect: function () { table.draw(); }, changeMonth: true, changeYear: true });
    $("#max").datepicker({ onSelect: function () { table.draw(); }, changeMonth: true, changeYear: true });
    var table = $('#example').DataTable();

    // Event listener to the two range filtering inputs to redraw on input
    $('#min, #max').change(function () {
        table.draw();
    });

});