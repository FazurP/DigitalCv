$(document).ready(function () {



    $('#vigencia').prop('disabled', true);
    $('#fUpload').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#tipoDocumento').change(function ()
    {
        let data = $(this).val();

        if (data == 0 || data == '0' || data == "0") {

            $('#vigencia').prop('disabled', true);
            $('#fUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#vigencia').val(0);
            $('#fUpload').val('');
        } else
        {
            toastr.success('Documento Seleccionado.', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#vigencia').prop('disabled', false);
        }

    });

    $('#vigencia').change(function () {
        let data = $(this).val();

        if (data == '') {

            $('#fUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#fUpload').val('');
        } else {
            toastr.success('Vigencia Seleccionada.', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#fUpload').prop('disabled', false);
        }

    });

    $('#fUpload').change(function () {
        let data = $(this).val();

        if (data == '') {
            $('#btnGuardar').prop('disabled', true);
        }

    });

})