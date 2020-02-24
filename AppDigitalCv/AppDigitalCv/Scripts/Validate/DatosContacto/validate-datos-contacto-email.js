
$(document).ready(function () {

    $('#btnGuardar').click(function () {

        var correoP = $('#EmailPersonal').prop("disabled", true);

        var regex = new RegExp("^[a-zA-Z0-9._-]{3,25}[@]{1}(hotmail|gmail|outlook|yahoo){1}[.]{1}(com|mx|net){1}$");

        if (!regex.test(correoP)) {
            toastr.warning("Ingresa un Correo Valido", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            return false;
        }
         else {
            return true;
        }

    })
})


