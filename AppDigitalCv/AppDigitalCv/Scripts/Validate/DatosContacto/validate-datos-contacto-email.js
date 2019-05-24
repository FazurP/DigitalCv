
$(document).ready(function () {

    $('#btnGuardar').click(function () {

        var correoP = $('#EmailPersonal').val();
        var correoI = $('#EmailInstitucional').val();

        var regex = new RegExp("^[a-zA-Z0-9._-]{3,25}[@]{1}(hotmail|gmail|outlook|yahoo){1}[.]{1}(com|mx|net){1}$");
        var regex2 = new RegExp("^[a-zA-Z0-9._-]{3,25}[@]{1}(uttt){1}[.]{1}(edu){1}[.]{1}(mx){1}$");

        if (!regex.test(correoP)) {
            toastr.warning("Ingresa un Correo Valido", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            return false;


        } else if (!regex2.test(correoI)) {
            toastr.warning("Ingresa un Correo Institucional Valido", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
            return false;
        } else {

            return true;

        }

    })

})


