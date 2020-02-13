$(document).ready(function () {

    $("#txtActividad").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9, ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Cadenas de Texto.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            e.preventDefault();
            return false;
        }
    });


})