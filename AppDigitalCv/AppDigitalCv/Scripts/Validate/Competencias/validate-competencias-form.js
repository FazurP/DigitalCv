$(document).ready(function () {

    $('#Enviar').click(function () {
        if (!$("#check input[id='idC']").is(':checked')) {
            toastr.warning('Debes seleccionar una competencia', "Digital-Cv dice", { timeOut: 1000 });
            return false;
        } else {
            return true;
        }

    })
})