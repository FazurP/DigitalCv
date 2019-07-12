$(document).ready(function () {

    $('#NombreProyecto').prop('disabled', true);
    $('#Alcance').prop('disabled', true);
    $('#Institucion').prop('disabled', true);
    $('#FechaInicio').prop('disabled', true);
    $('#EstadoActual').prop('disabled', true);
    $('#ElaboracionInforme').prop('disabled', true);
    $('#NumeroPaginas').prop('disabled', true);
    $('#Pais').prop('disabled', true);
    $('#Proposito').prop('disabled', true);
    $('#inputFileUpload').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#Autor').keyup(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#NombreProyecto').prop('disabled', true);
            $('#Alcance').prop('disabled', true);
            $('#Institucion').prop('disabled', true);
            $('#FechaInicio').prop('disabled', true);
            $('#EstadoActual').prop('disabled', true);
            $('#ElaboracionInforme').prop('disabled', true);
            $('#NumeroPaginas').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#NombreProyecto').val('');
            $('#Alcance').val('');
            $('#Institucion').val('');
            $('#FechaInicio').val('');
            $('#EstadoActual').val(0);
            $('#ElaboracionInforme').val('');
            $('#Pais').val(0);
            $('#Proposito').val(0);
            $('#inputFileUpload').val('');
        } else {
            $('#NombreProyecto').prop('disabled', false);
        }

    })

    $('#NombreProyecto').keyup(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#Alcance').prop('disabled', true);
            $('#Institucion').prop('disabled', true);
            $('#FechaInicio').prop('disabled', true);
            $('#EstadoActual').prop('disabled', true);
            $('#ElaboracionInforme').prop('disabled', true);
            $('#NumeroPaginas').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Alcance').val('');
            $('#Institucion').val('');
            $('#FechaInicio').val('');
            $('#EstadoActual').val(0);
            $('#ElaboracionInforme').val('');
            $('#Pais').val(0);
            $('#Proposito').val(0);
            $('#inputFileUpload').val('');
        } else {
            $('#Alcance').prop('disabled', false);
        }

    })

    $('#Alcance').keyup(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#Institucion').prop('disabled', true);
            $('#FechaInicio').prop('disabled', true);
            $('#EstadoActual').prop('disabled', true);
            $('#ElaboracionInforme').prop('disabled', true);
            $('#NumeroPaginas').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Institucion').val('');
            $('#FechaInicio').val('');
            $('#EstadoActual').val(0);
            $('#ElaboracionInforme').val('');
            $('#Pais').val(0);
            $('#Proposito').val(0);
            $('#inputFileUpload').val('');
        } else {
            $('#Institucion').prop('disabled', false);
        }

    })

    $('#Institucion').keyup(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#FechaInicio').prop('disabled', true);
            $('#EstadoActual').prop('disabled', true);
            $('#ElaboracionInforme').prop('disabled', true);
            $('#NumeroPaginas').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#FechaInicio').val('');
            $('#EstadoActual').val(0);
            $('#ElaboracionInforme').val('');
            $('#Pais').val(0);
            $('#Proposito').val(0);
            $('#inputFileUpload').val('');
        } else {
            $('#FechaInicio').prop('disabled', false);
        }

    })

    $('#FechaInicio').change(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#EstadoActual').prop('disabled', true);
            $('#ElaboracionInforme').prop('disabled', true);
            $('#NumeroPaginas').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#EstadoActual').val(0);
            $('#ElaboracionInforme').val('');
            $('#Pais').val(0);
            $('#Proposito').val(0);
            $('#inputFileUpload').val('');
        } else {
            $('#EstadoActual').prop('disabled', false);
        }

    })

    $('#EstadoActual').change(function () {

        var data = $(this).val();

        if (data == null || data == 0 || data == '0' || data == "0") {

            $('#ElaboracionInforme').prop('disabled', true);
            $('#NumeroPaginas').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ElaboracionInforme').val('');
            $('#Pais').val(0);
            $('#Proposito').val(0);
            $('#inputFileUpload').val('');
        } else {
            $('#ElaboracionInforme').prop('disabled', false);
        }

    })

    $('#ElaboracionInforme').change(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#NumeroPaginas').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#NumeroPaginas').val('');
            $('#Pais').val(0);
            $('#Proposito').val(0);
            $('#inputFileUpload').val('');
        } else {
            $('#NumeroPaginas').prop('disabled', false);
        }

    })

    $('#NumeroPaginas').keyup(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#Pais').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Pais').val(0);
            $('#Proposito').val(0);
            $('#inputFileUpload').val('');
        } else {
            $('#Pais').prop('disabled', false);
        }

    })

    $('#Pais').change(function () {

        var data = $(this).val();

        if (data == null || data == 0 || data == '0' || data == "0") {

            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Proposito').val(0);
            $('#inputFileUpload').val('');
        } else {
            $('#Proposito').prop('disabled', false);
        }

    })

    $('#Proposito').change(function () {

        var data = $(this).val();

        if (data == null || data == 0 || data == '0' || data == "0") {

            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#inputFileUpload').val('');
        } else {
            $('#inputFileUpload').prop('disabled', false);
        }

    })

    $('#inputFileUpload').change(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#btnGuardar').prop('disabled', true);

        } else {
            $('#btnGuardar').prop('disabled', false);
        }

    })
})