

$(document).ready(function ()
{
    $('#idFrecuencia').prop('disabled', true);
    $('#strTiempoPractica').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#idHobbie').change(function () {

        let data = $(this).val();

        if (data == 0 || data == '0' || data == "0" || data == null) {
            $('#idFrecuencia').prop('disabled', true);
            $('#strTiempoPractica').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#idFrecuencia').val(0);
            $('#strTiempoPractica').val('');
        } else
        {
            $('#idFrecuencia').prop('disabled', false);
        }

    });

    $('#idFrecuencia').change(function () {

        let data = $(this).val();

        if (data == 0 || data == '0' || data == "0" || data == null) {
            $('#strTiempoPractica').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#strTiempoPractica').val('');
        } else {
            $('#strTiempoPractica').prop('disabled', false);
        }

    });

    $('#strTiempoPractica').keyup(function () {

        let data = $(this).val();

        if (data == "" || data == '') {
            $('#btnGuardar').prop('disabled', true);

        } else {
            $('#btnGuardar').prop('disabled', false);
        }

    });

});