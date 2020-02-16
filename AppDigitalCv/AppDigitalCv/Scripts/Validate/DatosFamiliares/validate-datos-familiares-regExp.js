$(document).ready(function () {

    //Eventos para las validacion de las expresiones regulares del padre

    $("#nombrepadre").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Cadenas de Texto", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            e.preventDefault();
            return false;
        }
    })

    $("#ApellidoPaternoPadre").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Cadenas de Texto", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            e.preventDefault();
            return false;
        }
    })

    $("#ApellidoMaternoPadre").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Cadenas de Texto", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            e.preventDefault();
            return false;
        }
    })

    $("#domicilio").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9.#/, ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Ingresa una Direccion que sea Valida", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            e.preventDefault();
            return false;
        }
    })

    $("#ocupacion").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Permiten Cadenas de Texto", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            e.preventDefault();
            return false;
        }
    })
});

