

$(document).ready(function () {

    $("#strTiempoPractica").bind('keypress', function (e) {
        var regex = new RegExp("^[0-9. ]+$");
        var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (!regex.test(key)) {
            toastr.warning("Solo se Admiten Numeros.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            e.preventDefault();
            return false;
        }
    });

})