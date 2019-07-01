$(document).ready(function () {

    $('#Titulo').prop('disabled', true);
    $('#EstadoActual').prop('disabled', true);
    $('#Pais').prop('disabled', true);
    $('#Editorial').prop('disabled', true);
    $('#Edicion').prop('disabled', true);
    $('#Fecha').prop('disabled', true);
    $('#Tiraje').prop('disabled', true);
    $('#ISBN').prop('disabled', true);
    $('#Proposito').prop('disabled', true);
    $('#TituloCapitulo').prop('disabled', true);
    $('#Autores').prop('disabled', true);
    $('#PaginaInicio').prop('disabled', true);
    $('#PaginaFin').prop('disabled', true);
    //$('input[id=cv]').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#Autor').keyup(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#Titulo').prop('disabled', true);
            $('#EstadoActual').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#Editorial').prop('disabled', true);
            $('#Edicion').prop('disabled', true);
            $('#Fecha').prop('disabled', true);
            $('#Tiraje').prop('disabled', true);
            $('#ISBN').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#TituloCapitulo').prop('disabled', true);
            $('#Autores').prop('disabled', true);
            $('#PaginaInicio').prop('disabled', true);
            $('#PaginaFin').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Titulo').val('');
            $('#EstadoActual').val(0);
            $('#Pais').val(0);
            $('#Editorial').val('');
            $('#Edicion').val('');
            $('#Fecha').val('');
            $('#ISBN').val('');
            $('#Proposito').val(0);
            $('#TituloCapitulo').val('');
            $('#Autores').val('');
            $('#PaginaInicio').val('');
            $('#PaginaFin').val('');

        } else {
            $('#Titulo').prop('disabled', false);
        }

    })

    $('#Titulo').keyup(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#EstadoActual').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#Editorial').prop('disabled', true);
            $('#Edicion').prop('disabled', true);
            $('#Fecha').prop('disabled', true);
            $('#Tiraje').prop('disabled', true);
            $('#ISBN').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#TituloCapitulo').prop('disabled', true);
            $('#Autores').prop('disabled', true);
            $('#PaginaInicio').prop('disabled', true);
            $('#PaginaFin').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#EstadoActual').val(0);
            $('#Pais').val(0);
            $('#Editorial').val('');
            $('#Edicion').val('');
            $('#Fecha').val('');
            $('#ISBN').val('');
            $('#Proposito').val(0);
            $('#TituloCapitulo').val('');
            $('#Autores').val('');
            $('#PaginaInicio').val('');
            $('#PaginaFin').val('');

        } else {
            $('#EstadoActual').prop('disabled', false);
        }

    })

    $('#EstadoActual').change(function () {

        var data = $(this).val();

        if (data == null || data == 0 || data == '0' || data == "0") {

            $('#Pais').prop('disabled', true);
            $('#Editorial').prop('disabled', true);
            $('#Edicion').prop('disabled', true);
            $('#Fecha').prop('disabled', true);
            $('#Tiraje').prop('disabled', true);
            $('#ISBN').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#TituloCapitulo').prop('disabled', true);
            $('#Autores').prop('disabled', true);
            $('#PaginaInicio').prop('disabled', true);
            $('#PaginaFin').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Pais').val(0);
            $('#Editorial').val('');
            $('#Edicion').val('');
            $('#Fecha').val('');
            $('#ISBN').val('');
            $('#Proposito').val(0);
            $('#TituloCapitulo').val('');
            $('#Autores').val('');
            $('#PaginaInicio').val('');
            $('#PaginaFin').val('');

        } else {
            toastr.success('Estado Actual Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#Pais').prop('disabled', false);
        }

    })

    $('#Pais').change(function () {

        var data = $(this).val();

        if (data == null || data == 0 || data == '0' || data == "0") {

            $('#Editorial').prop('disabled', true);
            $('#Edicion').prop('disabled', true);
            $('#Fecha').prop('disabled', true);
            $('#Tiraje').prop('disabled', true);
            $('#ISBN').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#TituloCapitulo').prop('disabled', true);
            $('#Autores').prop('disabled', true);
            $('#PaginaInicio').prop('disabled', true);
            $('#PaginaFin').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Editorial').val('');
            $('#Edicion').val('');
            $('#Fecha').val('');
            $('#ISBN').val('');
            $('#Proposito').val(0);
            $('#TituloCapitulo').val('');
            $('#Autores').val('');
            $('#PaginaInicio').val('');
            $('#PaginaFin').val('');

        } else {
            toastr.success('Pais Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#Editorial').prop('disabled', false);
        }

    })

    $('#Editorial').keyup(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "" ) {

            $('#Edicion').prop('disabled', true);
            $('#Fecha').prop('disabled', true);
            $('#Tiraje').prop('disabled', true);
            $('#ISBN').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#TituloCapitulo').prop('disabled', true);
            $('#Autores').prop('disabled', true);
            $('#PaginaInicio').prop('disabled', true);
            $('#PaginaFin').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Edicion').val('');
            $('#Fecha').val('');
            $('#ISBN').val('');
            $('#Proposito').val(0);
            $('#TituloCapitulo').val('');
            $('#Autores').val('');
            $('#PaginaInicio').val('');
            $('#PaginaFin').val('');

        } else {
            $('#Edicion').prop('disabled', false);
        }

    })

    $('#Edicion').keyup(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#Fecha').prop('disabled', true);
            $('#Tiraje').prop('disabled', true);
            $('#ISBN').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#TituloCapitulo').prop('disabled', true);
            $('#Autores').prop('disabled', true);
            $('#PaginaInicio').prop('disabled', true);
            $('#PaginaFin').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Fecha').val('');
            $('#ISBN').val('');
            $('#Proposito').val(0);
            $('#TituloCapitulo').val('');
            $('#Autores').val('');
            $('#PaginaInicio').val('');
            $('#PaginaFin').val('');

        } else {
            $('#Fecha').prop('disabled', false);
        }

    })

    $('#Fecha').change(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#Tiraje').prop('disabled', true);
            $('#ISBN').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#TituloCapitulo').prop('disabled', true);
            $('#Autores').prop('disabled', true);
            $('#PaginaInicio').prop('disabled', true);
            $('#PaginaFin').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Tiraje').val('');
            $('#ISBN').val('');
            $('#Proposito').val(0);
            $('#TituloCapitulo').val('');
            $('#Autores').val('');
            $('#PaginaInicio').val('');
            $('#PaginaFin').val('');

        } else {
            $('#Tiraje').prop('disabled', false);
        }

    })

    $('#Tiraje').keyup(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#ISBN').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#TituloCapitulo').prop('disabled', true);
            $('#Autores').prop('disabled', true);
            $('#PaginaInicio').prop('disabled', true);
            $('#PaginaFin').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ISBN').val('');
            $('#Proposito').val(0);
            $('#TituloCapitulo').val('');
            $('#Autores').val('');
            $('#PaginaInicio').val('');
            $('#PaginaFin').val('');

        } else {
            $('#ISBN').prop('disabled', false);
        }

    })

    $('#ISBN').keyup(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#Proposito').prop('disabled', true);
            $('#TituloCapitulo').prop('disabled', true);
            $('#Autores').prop('disabled', true);
            $('#PaginaInicio').prop('disabled', true);
            $('#PaginaFin').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Proposito').val(0);
            $('#TituloCapitulo').val('');
            $('#Autores').val('');
            $('#PaginaInicio').val('');
            $('#PaginaFin').val('');

        } else {
            $('#Proposito').prop('disabled', false);
        }

    })

    $('#Proposito').change(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#TituloCapitulo').prop('disabled', true);
            $('#Autores').prop('disabled', true);
            $('#PaginaInicio').prop('disabled', true);
            $('#PaginaFin').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#TituloCapitulo').val('');
            $('#Autores').val('');
            $('#PaginaInicio').val('');
            $('#PaginaFin').val('');

        } else {
            toastr.success('Proposito Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#TituloCapitulo').prop('disabled', false);
        }

    })

    $('#TituloCapitulo').keyup(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#Autores').prop('disabled', true);
            $('#PaginaInicio').prop('disabled', true);
            $('#PaginaFin').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Autores').val('');
            $('#PaginaInicio').val('');
            $('#PaginaFin').val('');

        } else {
            $('#Autores').prop('disabled', false);
        }

    })

    $('#Autores').keyup(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#PaginaInicio').prop('disabled', true);
            $('#PaginaFin').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#PaginaInicio').val('');
            $('#PaginaFin').val('');

        } else {
            $('#PaginaInicio').prop('disabled', false);
        }

    })

    $('#PaginaInicio').keyup(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#PaginaFin').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#PaginaFin').val('');

        } else {
            $('#PaginaFin').prop('disabled', false);
        }

    })

    $('#PaginaFin').keyup(function () {

        var data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#btnGuardar').prop('disabled', true);

        } else {
            $('#btnGuardar').prop('disabled', false);
        }

    })


})