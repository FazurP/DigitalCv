$(document).ready(function () {

    $('#txtPuesto').prop('disabled', true);
    $('#dteFechaInicio').prop('disabled', true);
    $('#dteFechaTermino').prop('disabled', true);
    $('#txtActividades').prop('disabled', true);
    $('#txtMotivoConclusion').prop('disabled', true);
    $('#inputFileUpload').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#txtInstitucion').keyup(function () {

        var dato = $(this).val();

        if (dato == null || dato == '' || dato == "") {
            
            $('#txtPuesto').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#txtActividades').prop('disabled', true);
            $('#txtMotivoConclusion').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtPuesto').val('');
            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#txtActividades').val('');
            $('#txtMotivoConclusion').val('');
            $('#inputFileUpload').val('');
        } else {
            $('#txtPuesto').prop('disabled', false);
        }

    })

    $('#txtPuesto').keyup(function () {

        var dato = $(this).val();

        if (dato == null || dato == '' || dato == "") {
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#txtActividades').prop('disabled', true);
            $('#txtMotivoConclusion').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#txtActividades').val('');
            $('#txtMotivoConclusion').val('');
            $('#inputFileUpload').val('');
        } else {

            $('#dteFechaInicio').prop('disabled', false);

        }

    })

    $('#dteFechaInicio').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == '' || dato == "") {
            $('#dteFechaTermino').prop('disabled', true);
            $('#txtActividades').prop('disabled', true);
            $('#txtMotivoConclusion').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaTermino').val('');
            $('#txtActividades').val('');
            $('#txtMotivoConclusion').val('');
            $('#inputFileUpload').val('');
        } else {
            $('#dteFechaTermino').prop('disabled', false);

        }

    })

    $('#dteFechaTermino').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == '' || dato == "") {
            $('#txtActividades').prop('disabled', true);
            $('#txtMotivoConclusion').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtActividades').val('');
            $('#txtMotivoConclusion').val('');
            $('#inputFileUpload').val('');
        } else {
            $('#txtActividades').prop('disabled', false);

        }

    })

    $('#txtActividades').keyup(function () {

        var dato = $(this).val();

        if (dato == null || dato == '' || dato == "") {
            $('#txtMotivoConclusion').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtMotivoConclusion').val('');
            $('#inputFileUpload').val('');
        } else {

            $('#txtMotivoConclusion').prop('disabled', false);

        }

    })

    $('#txtMotivoConclusion').keyup(function () {

        var dato = $(this).val();

        if (dato == null || dato == '' || dato == "") {
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#inputFileUpload').val('');
        } else {

            $('#inputFileUpload').prop('disabled', false);

        }

    })

    $('#inputFileUpload').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == '' || dato == "") {
            $('#btnGuardar').prop('disabled', true);

        } else {

            $('#btnGuardar').prop('disabled', false);

        }

    })


})