$(document).ready(function () {

    $('#idCatTipoActividad').prop('disabled', true)
    $('#idCatPeriodo').prop('disabled', true)
    $('#txtActividad').prop('disabled', true)
    $('#dteFechaInicio').prop('disabled', true)
    $('#dteFechaTerminio').prop('disabled', true)
    $('#inputUploadFile').prop('disabled', true)
    $('#btnGuardar').prop('disabled', true)

    $('#idCatProgramaEducativo').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == 0 || dato == '0' || dato == "0") {
            $('#idCatTipoActividad').prop('disabled', true)
            $('#idCatPeriodo').prop('disabled', true)
            $('#txtActividad').prop('disabled', true)
            $('#dteFechaInicio').prop('disabled', true)
            $('#dteFechaTerminio').prop('disabled', true)
            $('#inputUploadFile').prop('disabled', true)
            $('#btnGuardar').prop('disabled', true)

            $('#idCatTipoActividad').val(0);
            $('#idCatPeriodo').val(0);
            $('#txtActividad').val('');
            $('#dteFechaInicio').val('');
            $('#dteFechaTerminio').val('');
            $('#inputUploadFile').val('');
        } else {
            $('#idCatTipoActividad').prop('disabled', false)
            toastr.success('Programa Educativo Seleccionado', 'Digital-Cv dice', {
                timeOut: 1000, closeButton: true
            });
        }

    })

    $('#idCatTipoActividad').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == 0 || dato == '0' || dato == "0") {
            $('#idCatPeriodo').prop('disabled', true)
            $('#txtActividad').prop('disabled', true)
            $('#dteFechaInicio').prop('disabled', true)
            $('#dteFechaTerminio').prop('disabled', true)
            $('#inputUploadFile').prop('disabled', true)
            $('#btnGuardar').prop('disabled', true)

            $('#idCatPeriodo').val(0);
            $('#txtActividad').val('');
            $('#dteFechaInicio').val('');
            $('#dteFechaTerminio').val('');
            $('#inputUploadFile').val('');
        } else {
            $('#idCatPeriodo').prop('disabled', false)
            toastr.success('Tipo de Actividad Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton:true });
        }

    })

    $('#idCatPeriodo').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == 0 || dato == '0' || dato == "0") {
            $('#txtActividad').prop('disabled', true)
            $('#dteFechaInicio').prop('disabled', true)
            $('#dteFechaTerminio').prop('disabled', true)
            $('#inputUploadFile').prop('disabled', true)
            $('#btnGuardar').prop('disabled', true)

            $('#txtActividad').val('');
            $('#dteFechaInicio').val('');
            $('#dteFechaTerminio').val('');
            $('#inputUploadFile').val('');
        } else {
            $('#txtActividad').prop('disabled', false)
            toastr.success('Periodo Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }

    })

    $('#txtActividad').keyup(function () {

        var dato = $(this).val();

        if (dato == null || dato == '' || dato == "") {
            $('#dteFechaInicio').prop('disabled', true)
            $('#dteFechaTerminio').prop('disabled', true)
            $('#inputUploadFile').prop('disabled', true)
            $('#btnGuardar').prop('disabled', true)

            $('#dteFechaInicio').val('');
            $('#dteFechaTerminio').val('');
            $('#inputUploadFile').val('');
        } else {
            $('#dteFechaInicio').prop('disabled', false)
        }

    })

    $('#dteFechaInicio').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == '' || dato == "") {
            $('#dteFechaTerminio').prop('disabled', true)
            $('#inputUploadFile').prop('disabled', true)
            $('#btnGuardar').prop('disabled', true)

            $('#dteFechaTerminio').val('');
            $('#inputUploadFile').val('');
        } else {
            $('#dteFechaTerminio').prop('disabled', false)
        }

    })

    $('#dteFechaTerminio').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == '' || dato == "") {
            $('#inputUploadFile').prop('disabled', true)
            $('#btnGuardar').prop('disabled', true)

            $('#inputUploadFile').val('');
        } else {
            $('#inputUploadFile').prop('disabled', false)
        }

    })

    $('#inputUploadFile').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == '' || dato == "") {
            $('#btnGuardar').prop('disabled', true)
        } else {
            $('#btnGuardar').prop('disabled', false)
        }

    })



})