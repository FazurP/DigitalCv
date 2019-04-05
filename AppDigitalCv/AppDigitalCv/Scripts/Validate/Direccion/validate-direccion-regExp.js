$(document).ready(function () {

    $("#Calle").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9.# ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se admiten cadenas de texto.");
            e.preventDefault();
            return false;
        }
    });

    $("#NInterior").bind('keypress', function (e) {
        var regex = new RegExp("^[0-9]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se admiten numeros.");
            e.preventDefault();
            return false;
        }
    });

    $("#NExterior").bind('keypress', function (e) {
        var regex = new RegExp("^[0-9]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se admiten numeros.");
            e.preventDefault();
            return false;
        }
    });







})