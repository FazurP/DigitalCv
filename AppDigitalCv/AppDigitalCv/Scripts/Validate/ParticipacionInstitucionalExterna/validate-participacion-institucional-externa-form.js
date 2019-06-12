$(document).ready(function () {

    $('#ddlInstitucion').prop('disabled', true);
    $('#ddlPeriodo').prop('disabled', true);
    $('#dteFechaInicio').prop('disabled', true);
    $('#dteFechaTerminio').prop('disabled', true);
    $('#inputUploadFile').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#txtActividad').keyup(function () {

        var actividad = $('#txtActividad').val();

        if (actividad == null || actividad == '' || actividad == "") {
            $('#ddlInstitucion').prop('disabled', true);
            $('#ddlPeriodo').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTerminio').prop('disabled', true);
            $('#inputUploadFile').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlInstitucion').val(0);
            $('#ddlPeriodo').val(0);
            $('#dteFechaInicio').val('');
            $('#dteFechaTerminio').val('');
            $('#inputUploadFile').val('');
        } else {
            $('#ddlInstitucion').prop('disabled', false);
        }

    })

    $('#ddlInstitucion').change(function () {

        var institucion = $('#ddlInstitucion').val();

        if (institucion == null || institucion == 0 || institucion == '0' || institucion == "0") {
            $('#ddlPeriodo').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTerminio').prop('disabled', true);
            $('#inputUploadFile').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlPeriodo').val(0);
            $('#dteFechaInicio').val('');
            $('#dteFechaTerminio').val('');
            $('#inputUploadFile').val('');
        } else {
            $('#ddlPeriodo').prop('disabled', false);
            toastr.info('Institución Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton: true })
        }

    })

    $('#ddlPeriodo').change(function () {

        var periodo = $('#ddlPeriodo').val();

        if (periodo == null || periodo == 0 || periodo == '0' || periodo == "0") {
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTerminio').prop('disabled', true);
            $('#inputUploadFile').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaInicio').val('');
            $('#dteFechaTerminio').val('');
            $('#inputUploadFile').val('');
        } else {
            $('#dteFechaInicio').prop('disabled', false);
            toastr.info('Periodo Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true })
        }

    })

    $('#dteFechaInicio').change(function () {
        var fecha = $(this).val();

        if (fecha == null || fecha == "" || fecha == '') {
            $('#dteFechaTerminio').prop('disabled', true);
            $('#inputUploadFile').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaTerminio').val('');
            $('#inputUploadFile').val('');
        } else {
            $('#dteFechaTerminio').prop('disabled', false);
        }

    })

    $('#dteFechaTerminio').change(function () {
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