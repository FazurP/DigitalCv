$(document).ready(function () {

    $("#Calle").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9.# ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Cadenas de Texto.", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            e.preventDefault();
            return false;
        }
    });

    $("#NInterior").bind('keypress', function (e) {
        var regex = new RegExp("^[0-9a-zA-Z-]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Numeros.", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            e.preventDefault();
            return false;
        }
    });

    $("#NExterior").bind('keypress', function (e) {
        var regex = new RegExp("^[0-9a-zA-Z-]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Numeros.", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            e.preventDefault();
            return false;
        }
    });







})