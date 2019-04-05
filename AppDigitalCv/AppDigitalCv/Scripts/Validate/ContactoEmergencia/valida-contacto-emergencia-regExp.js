$(document).ready(function () {

    $("#Direccion").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9.# ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Ingresa una Direccion Valida");
            e.preventDefault();
            return false;
        }
    });

    $("#Nombre").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se admiten cadenas de texto.");
            e.preventDefault();
            return false;
        }
    });


})