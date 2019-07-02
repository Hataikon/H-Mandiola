$(document).ready(function () {
    $('#btnAceptar').click(function (e) { 
        e.preventDefault();
        var Prefijo = $('#prefijoBox').val();
        var Descripcion = $('#descripcionDropdown').val();
        var CODIGO_CONSECUTIVO = $('#consecutivoBox').val();
        var resJSON = JSON.stringify({Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO});
        alert(resJSON);
        $.ajax({
            type: "post",
            url: "api/VerJSON",
            data: JSON.stringify({Prefijo: Prefijo, Descripcion: Descripcion, CODIGO_CONSECUTIVO: CODIGO_CONSECUTIVO}),
            dataType: "json",
            contentType: "application/json",
            success: function (response) {
                console.log(response.msg)
                alert(response.msg)
            }
        });
    });
});