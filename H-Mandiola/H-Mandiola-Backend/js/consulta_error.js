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

    $('#tbDatos').DataTable({
        columns: [
            { data: 'Numero_Error' },
            { data: 'Mensaje_Error' },
            { data: 'Fecha_Error' }
        ],
        ajax: {
            url: "/api/Error",
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