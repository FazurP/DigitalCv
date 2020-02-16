$(document).ready(function ()
{
    $("#txtInstitucion").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9., ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Cadenas de Texto.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            e.preventDefault();
            return false;
        }
    });

    $("#txtPuesto").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ,. ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Cadenas de Texto.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            e.preventDefault();
            return false;
        }
    });

    $("#txtActividades").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ,. ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Cadenas de Texto.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            e.preventDefault();
            return false;
        }
    });

    $("#txtMotivoConclusion").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ,. ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Cadenas de Texto.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            e.preventDefault();
            return false;
        }
    });
});