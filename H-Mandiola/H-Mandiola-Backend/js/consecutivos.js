$(document).ready(function () {

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
            var resJSON = JSON.stringify({ Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO });
            alert(resJSON);
            $.ajax({
                type: "post",
                url: "api/Consecutivos/ModificarConsecutivo",
                data: JSON.stringify({ Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO }),
                dataType: "json",
                contentType: "application/json",
                success: function (response) {
                    console.log(response.msg)
                    alert(response.msg)
                }
            });
        }
        else {
            e.preventDefault();
            var Prefijo = $('#prefijoBox').val();
            var Descripcion = $('#descripcionDropdown').val();
            var CODIGO_CONSECUTIVO = $('#consecutivoBox').val();
            var resJSON = JSON.stringify({ Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO });
            alert(resJSON);
            $.ajax({
                type: "post",
                url: "api/Consecutivos/AgregarConsecutivo",
                data: JSON.stringify({ Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO }),
                dataType: "json",
                contentType: "application/json",
                success: function (response) {
                    console.log(response.msg)
                    alert(response.msg)
                }
            });
        }
    });
});