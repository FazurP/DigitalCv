$(document).ready(function () {

    //Eventos para las validacion de las expresiones regulares del padre

    $("#nombrepadre").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se admiten cadenas de texto");
            e.preventDefault();
            return false;
        }
    })

    $("#domiciliopadre").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9.#/ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Ingresa una direccion que sea valida");
            e.preventDefault();
            return false;
        }
    })

    $("#ocupacionpadre").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se permiten cadenas de texto");
            e.preventDefault();
            return false;
        }
    })

    //Eventos para las validacion de las expresiones regulares de la madre

    $("#nombremadre").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se admiten cadenas de texto");
            e.preventDefault();
            return false;
        }
    })

    $("#domiciliomadre").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9.#/ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Ingresa una direccion que sea valida");
            e.preventDefault();
            return false;
        }
    })

    $("#ocupacionmadre").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se permiten cadenas de texto");
            e.preventDefault();
            return false;
        }
    })

    //Eventos para las validaciones de las expresiones regulares de la pareja

    $("#nombrepareja").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se admiten cadenas de texto");
            e.preventDefault();
            return false;
        }
    })

    $("#domiciliopareja").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9.#/ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Ingresa una direccion que sea valida");
            e.preventDefault();
            return false;
        }
    })

    $("#ocupacionpareja").bind('keypress', function (e) {
        var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se permiten cadenas de texto");
            e.preventDefault();
            return false;
        }
    })


});

