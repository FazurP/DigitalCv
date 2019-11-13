$(document).ready(function () {

    $('#asociacion').attr('disabled', true);
    $('#organizacionPertenece').prop('disabled', true);
    $('#fecha').prop('disabled', true);
    $('#participacion').prop('disabled', true);
    $('#funcion').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#rdbSi').change(function () {
        toastr.info("Selecciona tu(s) Asociacion(es)", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
        $('#asociacion').attr('disabled', false);
    });

    $('#rdbNo').change(function () {

        $('#asociacion').attr('disabled', true);
        $('#organizacionPertenece').prop('disabled', true);
        $('#fecha').prop('disabled', true);
        $('#participacion').prop('disabled', true);
        $('#funcion').prop('disabled', true);
        $('#btnGuardar').prop('disabled', true);

        $('#asociacion').val(0);
        $('#organizacionPertenece').val('');
        $('#fecha').val('');
        $('#participacion').val('');
        $('#funcion').val('');

    });

    $('#asociacion').change(function ()
    {
        let data = $(this).val();

        if (data == 0 || data == '0' || data == "0" || data == null) {

            $('#organizacionPertenece').prop('disabled', true);
            $('#fecha').prop('disabled', true);
            $('#participacion').prop('disabled', true);
            $('#funcion').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#organizacionPertenece').val('');
            $('#fecha').val('');
            $('#participacion').val('');
            $('#funcion').val('');

        } else
        {
            $('#organizacionPertenece').prop('disabled', false);
        }
    });

    $('#organizacionPertenece').keyup(function () {

        let data = $(this).val();

        if (data == "") {

            $('#fecha').prop('disabled', true);
            $('#participacion').prop('disabled', true);
            $('#funcion').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#fecha').val('');
            $('#participacion').val('');
            $('#funcion').val('');

        } else {
            $('#fecha').prop('disabled', false);
        }
    });

    $('#fecha').change(function () {

        let data = $(this).val();

        if (data == "") {

            $('#participacion').prop('disabled', true);
            $('#funcion').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#participacion').val('');
            $('#funcion').val('');

        } else {
            $('#participacion').prop('disabled', false);
        }
    });

    $('#participacion').keyup(function () {

        let data = $(this).val();

        if (data == "") {

            $('#funcion').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#funcion').val('');

        } else {
            $('#funcion').prop('disabled', false);
        }
    });

    $('#funcion').keyup(function () {

        let data = $(this).val();

        if (data == "") {

            $('#btnGuardar').prop('disabled', true);

        } else {
            $('#btnGuardar').prop('disabled', false);
        }
    });
});