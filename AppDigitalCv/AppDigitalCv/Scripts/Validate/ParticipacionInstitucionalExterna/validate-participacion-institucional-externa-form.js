$(document).ready(function () {

    $('#ddlInstitucion').prop('disabled', true);
    $('#dteFechaInicio').prop('disabled', true);
    $('#dteFechaTermino').prop('disabled', true);
    $('#inputUploadFile').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#txtActividad').keyup(function () {

        var actividad = $('#txtActividad').val();

        if (actividad == null || actividad == '' || actividad == "") {
            $('#ddlInstitucion').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#inputUploadFile').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlInstitucion').val(0);
            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#inputUploadFile').val('');
        } else {
            $('#ddlInstitucion').prop('disabled', false);
        }

    })

    $('#ddlInstitucion').change(function () {

        var institucion = $('#ddlInstitucion').val();

        if (institucion == null || institucion == 0 || institucion == '0' || institucion == "0") {
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#inputUploadFile').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#inputUploadFile').val('');
        } else {
            $('#dteFechaInicio').prop('disabled', false);
            toastr.success('Institución Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton: true })
        }

    })

    $('#dteFechaInicio').change(function () {
        var fecha = $(this).val();

        if (fecha == null || fecha == "" || fecha == '') {
            $('#dteFechaTermino').prop('disabled', true);
            $('#inputUploadFile').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaTermino').val('');
            $('#inputUploadFile').val('');
        } else {
            $('#dteFechaTermino').prop('disabled', false);
        }

    })

    $('#dteFechaTermino').change(function () {
        var fecha = $(this).val();

        if (fecha == null || fecha == '' || fecha == "") {
            $('#inputUploadFile').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#inputUploadFile').val('');
        } else {
            $('#inputUploadFile').prop('disabled', false);
        }
    })

    $('#inputUploadFile').change(function () {

        var file = $(this).val();
        if (file == null || file == '' || file == "") {
            $('#btnGuardar').prop('disabled', true);
        } else {
            $('#btnGuardar').prop('disabled', false);
        }

    })

})