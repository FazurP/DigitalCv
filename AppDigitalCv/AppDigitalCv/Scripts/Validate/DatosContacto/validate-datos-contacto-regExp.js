$(document).ready(function () {

    $("#TelefonoCelular").bind('keypress', function (e) {
        var regex = new RegExp("^[0-9]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Numeros", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            e.preventDefault();
            return false;
        }
    });

    $("#TelefonoCasa").bind('keypress', function (e) {
        var regex = new RegExp("^[0-9]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Numeros.", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            e.preventDefault();
            return false;
        }
    });

    $("#TelefonoRecados").bind('keypress', function (e) {
        var regex = new RegExp("^[0-9]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Numeros.", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            e.preventDefault();
            return false;
        }
    });

    $("#Facebook").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Cadenas de Texto.", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            e.preventDefault();
            return false;
        }
    });

    $("#Twitter").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Cadenas de Texto.", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            e.preventDefault();
            return false;
        }
    });



})