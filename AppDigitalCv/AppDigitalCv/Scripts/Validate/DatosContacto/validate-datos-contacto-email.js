
$(document).ready(function () {

    $('#btnGuardar').click(function () {

        var correoP = $('#EmailPersonal').val();

        var regex = new RegExp("^[a-zA-Z0-9._-]{3,25}[@]{1}(live|hotmail|gmail|outlook|yahoo){1}[.]{1}(com|mx|net)[.]?(mx)?$");
        debugger;
        if (!regex.test(correoP)) {
            toastr.warning("Ingresa un Correo Valido", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            return false;
        }
         else {
            return true;
        }

    })
})


