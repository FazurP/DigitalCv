$(document).ready(function () {

    $("#Curp").bind('keypress', function (e) {

        var regex = new RegExp("^[a-zñA-ZÑ0-9]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {

            toastr.warning("Ingresa un Formato de Curp Valido", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            e.preventDefault();
            return false;

        }
    });

    $("#Semblanza").bind('keypress', function (e) {

        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ.,?¿ ]$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {

            toastr.warning("Solo se Admiten Cadenas de Texto.");
            e.preventDefault();
            return false;

        }
    });

})