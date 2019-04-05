$(document).ready(function () {


    $("#Actividad").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se admiten cadenas de texto.");
            e.preventDefault();
            return false;
        }
    });

    $("#Premio").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9 ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se admiten cadenas de texto.");
            e.preventDefault();
            return false;
        }
    });

    $("#Institucion").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9 ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se admiten cadenas de texto.");
            e.preventDefault();
            return false;
        }
    });

})