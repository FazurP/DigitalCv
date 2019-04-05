$(document).ready(function () {

    $("#Nombre").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se admiten cadenas de texto.");
            e.preventDefault();
            return false;
        }
    });

    $("#Paterno").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se admiten cadenas de texto.");
            e.preventDefault();
            return false;
        }
    });

    $("#Materno").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se admiten cadenas de texto.");
            e.preventDefault();
            return false;
        }
    });

    $("#Curp").bind('keypress', function (e) {

        var regex = new RegExp("^[a-zñA-ZÑ0-9]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {

            toastr.warning("Ingresa un formato de curp valido");
            e.preventDefault();
            return false;

        }
    });
    /*
    $("#Rfc").bind('keypress', function (e) {

        var regex = new RegExp("/^([A-ZÑ&]{3,4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$/");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {

            toastr.warning("Ingresa un formato de RFC valido");
            e.preventDefault();
            return false;

        }
    });
    */

    $("#Semblanza").bind('keypress', function (e) {

        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ. ]$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {

            toastr.warning("Solo se admiten cadenas de texto.");
            e.preventDefault();
            return false;

        }
    });

})