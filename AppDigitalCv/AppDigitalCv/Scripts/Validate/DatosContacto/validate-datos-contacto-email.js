
$(document).ready(function () {

    $('#btnGuardar').click(function () {

        var correoP = $('#EmailPersonal').val();
        var correoI = $('#EmailInstitucional').val();

        var regex = new RegExp("^[a-zA-Z0-9._-]{3,25}[@]{1}(hotmail|gmail|outlook|yahoo){1}[.]{1}(com|mx|net){1}$");
        var regex2 = new RegExp("^[a-zA-Z0-9._-]{3,25}[@]{1}(uttt){1}[.]{1}(edu){1}[.]{1}(mx){1}$");

        if (!regex.test(correoP)) {
            toastr.error("Ingresa un correo valido");
            return false;


        } else if (!regex2.test(correoI)) {
            toastr.error("Ingresa un correo institucional valido");
            return false;
        } else {

            return true;

        }

    })

})


