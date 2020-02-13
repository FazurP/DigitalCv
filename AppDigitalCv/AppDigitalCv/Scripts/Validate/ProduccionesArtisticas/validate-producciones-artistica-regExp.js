$(document).ready(function(){

    $(document).ready(function () {


        $("#Autor").bind('keypress', function (e) {
            var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ, ]+$");
            var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
            if (!regex.test(key)) {
                toastr.warning("Solo se Admiten Cadenas de Texto.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
                e.preventDefault();
                return false;
            }
        });

        $("#Nombre").bind('keypress', function (e) {
            var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ, ]+$");
            var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
            if (!regex.test(key)) {
                toastr.warning("Solo se Admiten Cadenas de Texto.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
                e.preventDefault();
                return false;
            }
        });

        $("#Descripcion").bind('keypress', function (e) {
            var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ, ]+$");
            var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
            if (!regex.test(key)) {
                toastr.warning("Solo se Admiten Cadenas de Texto.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
                e.preventDefault();
                return false;
            }
        });

        $("#Investigacion").bind('keypress', function (e) {
            var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ, ]+$");
            var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
            if (!regex.test(key)) {
                toastr.warning("Solo se Admiten Cadenas de Texto.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
                e.preventDefault();
                return false;
            }
        });

        $("#Metodologia").bind('keypress', function (e) {
            var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ, ]+$");
            var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
            if (!regex.test(key)) {
                toastr.warning("Solo se Admiten Cadenas de Texto.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
                e.preventDefault();
                return false;
            }
        });

        $("#Diseño").bind('keypress', function (e) {
            var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ, ]+$");
            var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
            if (!regex.test(key)) {
                toastr.warning("Solo se Admiten Cadenas de Texto.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
                e.preventDefault();
                return false;
            }
        });

        $("#Innovacion").bind('keypress', function (e) {
            var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ, ]+$");
            var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
            if (!regex.test(key)) {
                toastr.warning("Solo se Admiten Cadenas de Texto.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
                e.preventDefault();
                return false;
            }
        });

        $("#Presentacion").bind('keypress', function (e) {
            var regex = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9, ]+$");
            var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
            if (!regex.test(key)) {
                toastr.warning("Solo se Admiten Cadenas de Texto.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
                e.preventDefault();
                return false;
            }
        });

    })

});