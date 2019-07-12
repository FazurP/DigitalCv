$(document).ready(function () {


    $('#Nombre').prop('disabled', true);
    $('#Descripcion').prop('disabled', true);
    $('#Institucion').prop('disabled', true);
    $('#Pais').prop('disabled', true);
    $('#Fecha').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#Autor').keyup(function () {

        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#Nombre').prop('disabled', true);
            $('#Descripcion').prop('disabled', true);
            $('#Institucion').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#Fecha').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Nombre').val('');
            $('#Descripcion').val('');
            $('#Institucion').val('');
            $('#Pais').val(0);
            $('#Fecha').val('');
        } else
        {
            $('#Nombre').prop('disabled', false);
        }

    })

    $('#Nombre').keyup(function () {

        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#Descripcion').prop('disabled', true);
            $('#Institucion').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#Fecha').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Descripcion').val('');
            $('#Institucion').val('');
            $('#Pais').val(0);
            $('#Fecha').val('');
        } else {
            $('#Descripcion').prop('disabled', false);
        }

    })

    $('#Descripcion').keyup(function () {

        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#Institucion').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#Fecha').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Institucion').val('');
            $('#Pais').val(0);
            $('#Fecha').val('');
        } else {
            $('#Institucion').prop('disabled', false);
        }

    })

    $('#Institucion').keyup(function () {

        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#Pais').prop('disabled', true);
            $('#Fecha').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Pais').val(0);
            $('#Fecha').val('');
        } else {
            $('#Pais').prop('disabled', false);
        }

    })

    $('#Pais').change(function () {

        let data = $(this).val();

        if (data == null || data == 0 || data == '0' || data == "0") {
            $('#Fecha').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Fecha').val('');
        } else {
            $('#Fecha').prop('disabled', false);
        }

    })

    $('#Fecha').change(function () {

        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#btnGuardar').prop('disabled', true);
        } else {
            $('#btnGuardar').prop('disabled', false);
        }

    })
})