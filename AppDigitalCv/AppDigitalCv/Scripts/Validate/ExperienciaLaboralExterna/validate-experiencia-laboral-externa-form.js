$(document).ready(function () {

    $('#txtPuesto').prop('disabled', true);
    $('#ddlPeriodo').prop('disabled', true);
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
            $('#ddlPeriodo').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#txtActividades').prop('disabled', true);
            $('#txtMotivoConclusion').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtPuesto').val('');
            $('#ddlPeriodo').val(0);
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
            $('#ddlPeriodo').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#txtActividades').prop('disabled', true);
            $('#txtMotivoConclusion').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlPeriodo').val(0);
            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#txtActividades').val('');
            $('#txtMotivoConclusion').val('');
            $('#inputFileUpload').val('');
        } else {

            $('#ddlPeriodo').prop('disabled', false);

        }

    })

    $('#ddlPeriodo').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == 0 || dato == '0' || dato == "0") {
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
            toastr.success('Periodo Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
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