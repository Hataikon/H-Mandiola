$(document).ready(function () {
    function getCookie(name) {
        var v = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
        return v ? v[2] : null;
    };

    $("#usernameNavBar").text(getCookie("username"));

    var cargarDatos = function () {
        $.getJSON("/api/Error", function (data) {
            console.log(data);
            var filas = '';
            data.forEach(function (fila) {
                filas += '<tr><td>' + fila['Numero_Error'] + '</td><td>' + fila['Mensaje_Error'] +
                    '</td><td>' + fila['Fecha_Error'] + '</td></tr>';
            })
            $('#tbDatos tbody').append(filas);

        });
    };
    cargarDatos();

    $(".searchInput").on("input", function () {
        var from = stringToDate($("#desde").val());
        var to = stringToDate($("#hasta").val());

        $("#tbDatos tr").each(function () {
            var row = $(this);
            var date = stringToDate(row.find("td").eq(2).text());

            //show all rows by default
            var show = true;

            //if from date is valid and row date is less than from date, hide the row
            if (from && date < from)
                show = false;

            //if to date is valid and row date is greater than to date, hide the row
            if (to && date > to)
                show = false;

            if (show)
                row.show();
            else
                row.hide();
        });
    });

    //parse entered date. return NaN if invalid
    function stringToDate(s) {
        var ret = NaN;
        var parts = s.split("/");
        date = new Date(parts[2], parts[0], parts[1]);
        if (!isNaN(date.getTime())) {
            ret = date;
        }
        return ret;
    }

});