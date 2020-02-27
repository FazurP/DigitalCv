$(document).ready(function () {


    $('#expedicion').prop('disabled', true);
    $('#fUpload').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);
    $('#lblvigencia').hide();

    $('#tipoDocumento').change(function ()
    {

        let data = $(this).val();

        if (data == 0 || data == 6 || data == 7 || data == 8) {
            $('#lblvigencia').hide();
        } else if (data == 1 || data == 2 || data == 3 || data == 4 || data == 5) {
            $('#lblvigencia').show();
        }
    });

    $('#tipoDocumento').change(function ()
    {
        let data = $(this).val();

        if (data == 0 || data == '0' || data == "0") {                      
            $('#expedicion').prop('disabled', true);
            $('#fUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#expedicion').val("");
            $('#fUpload').val('');
        } else
        {
            toastr.success('Documento Seleccionado.', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            
            $('#expedicion').prop('disabled', false);
        }

    });

    $('#expedicion').change(function () {
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