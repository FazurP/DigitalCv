$(document).ready(function () {

    $('#Pais').prop('disabled', true);
    $('#Autor').prop('disabled', true);
    $('#Nombre').prop('disabled', true);
    $('#Descripcion').prop('disabled', true);
    $('#Investigacion').prop('disabled', true);
    $('#Metodologia').prop('disabled', true);
    $('#Diseño').prop('disabled', true);
    $('#Innovacion').prop('disabled', true);
    $('#Publicacion').prop('disabled', true);
    $('#Presentacion').prop('disabled', true);
    $('#Proposito').prop('disabled', true);
    $('#inputFileUpload').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);


    $('#Produccion').change(function () {

        let data = $(this).val();

        if (data == null || data == 0 || data == "0" || data == '0') {
            $('#Pais').prop('disabled', true);
            $('#Autor').prop('disabled', true);
            $('#Nombre').prop('disabled', true);
            $('#Descripcion').prop('disabled', true);
            $('#Investigacion').prop('disabled', true);
            $('#Metodologia').prop('disabled', true);
            $('#Diseño').prop('disabled', true);
            $('#Innovacion').prop('disabled', true);
            $('#Publicacion').prop('disabled', true);
            $('#Presentacion').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Pais').val(0);
            $('#Autor').val('');
            $('#Nombre').val('');
            $('#Descripcion').val('');
            $('#Investigacion').val('');
            $('#Metodologia').val('');
            $('#Diseño').val('');
            $('#Innovacion').val('');
            $('#Publicacion').val('');
            $('#Presentacion').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else
        {
            $('#Pais').prop('disabled', false);
        }

    })

    $('#Pais').change(function () {

        let data = $(this).val();

        if (data == null || data == 0 || data == "0" || data == '0') {
            $('#Autor').prop('disabled', true);
            $('#Nombre').prop('disabled', true);
            $('#Descripcion').prop('disabled', true);
            $('#Investigacion').prop('disabled', true);
            $('#Metodologia').prop('disabled', true);
            $('#Diseño').prop('disabled', true);
            $('#Innovacion').prop('disabled', true);
            $('#Publicacion').prop('disabled', true);
            $('#Presentacion').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Autor').val('');
            $('#Nombre').val('');
            $('#Descripcion').val('');
            $('#Investigacion').val('');
            $('#Metodologia').val('');
            $('#Diseño').val('');
            $('#Innovacion').val('');
            $('#Publicacion').val('');
            $('#Presentacion').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#Autor').prop('disabled', false);
        }

    })

    $('#Autor').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#Nombre').prop('disabled', true);
            $('#Descripcion').prop('disabled', true);
            $('#Investigacion').prop('disabled', true);
            $('#Metodologia').prop('disabled', true);
            $('#Diseño').prop('disabled', true);
            $('#Innovacion').prop('disabled', true);
            $('#Publicacion').prop('disabled', true);
            $('#Presentacion').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Nombre').val('');
            $('#Descripcion').val('');
            $('#Investigacion').val('');
            $('#Metodologia').val('');
            $('#Diseño').val('');
            $('#Innovacion').val('');
            $('#Publicacion').val('');
            $('#Presentacion').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#Nombre').prop('disabled', false);
        }

    })

    $('#Nombre').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#Descripcion').prop('disabled', true);
            $('#Investigacion').prop('disabled', true);
            $('#Metodologia').prop('disabled', true);
            $('#Diseño').prop('disabled', true);
            $('#Innovacion').prop('disabled', true);
            $('#Publicacion').prop('disabled', true);
            $('#Presentacion').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Descripcion').val('');
            $('#Investigacion').val('');
            $('#Metodologia').val('');
            $('#Diseño').val('');
            $('#Innovacion').val('');
            $('#Publicacion').val('');
            $('#Presentacion').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#Descripcion').prop('disabled', false);
        }

    })

    $('#Descripcion').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#Investigacion').prop('disabled', true);
            $('#Metodologia').prop('disabled', true);
            $('#Diseño').prop('disabled', true);
            $('#Innovacion').prop('disabled', true);
            $('#Publicacion').prop('disabled', true);
            $('#Presentacion').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Investigacion').val('');
            $('#Metodologia').val('');
            $('#Diseño').val('');
            $('#Innovacion').val('');
            $('#Publicacion').val('');
            $('#Presentacion').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#Investigacion').prop('disabled', false);
        }

    })

    $('#Investigacion').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#Metodologia').prop('disabled', true);
            $('#Diseño').prop('disabled', true);
            $('#Innovacion').prop('disabled', true);
            $('#Publicacion').prop('disabled', true);
            $('#Presentacion').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Metodologia').val('');
            $('#Diseño').val('');
            $('#Innovacion').val('');
            $('#Publicacion').val('');
            $('#Presentacion').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#Metodologia').prop('disabled', false);
        }

    })

    $('#Metodologia').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#Diseño').prop('disabled', true);
            $('#Innovacion').prop('disabled', true);
            $('#Publicacion').prop('disabled', true);
            $('#Presentacion').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Diseño').val('');
            $('#Innovacion').val('');
            $('#Publicacion').val('');
            $('#Presentacion').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#Diseño').prop('disabled', false);
        }

    })

    $('#Diseño').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#Innovacion').prop('disabled', true);
            $('#Publicacion').prop('disabled', true);
            $('#Presentacion').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Innovacion').val('');
            $('#Publicacion').val('');
            $('#Presentacion').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#Innovacion').prop('disabled', false);
        }

    })

    $('#Innovacion').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#Publicacion').prop('disabled', true);
            $('#Presentacion').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Publicacion').val('');
            $('#Presentacion').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#Publicacion').prop('disabled', false);
        }

    })

    $('#Publicacion').change(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#Presentacion').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Presentacion').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#Presentacion').prop('disabled', false);
        }

    })

    $('#Presentacion').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#Proposito').prop('disabled', false);
        }

    })

    $('#Proposito').change(function () {

        let data = $(this).get(0).selectedIndex;

        if (data == null || data == 0 || data == "0" || data == '0') {
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#inputFileUpload').val('');
        } else {
            $('#inputFileUpload').prop('disabled', false);
        }

    })

    $('#inputFileUpload').change(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#btnGuardar').prop('disabled', true);

        } else {
            $('#btnGuardar').prop('disabled', false);
        }

    })
})