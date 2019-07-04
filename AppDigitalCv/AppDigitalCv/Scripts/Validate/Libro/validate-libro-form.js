$(document).ready(function () {

    $('#TituloLibro').prop('disabled',true);
    $('#TipoParticipacion').prop('disabled',true);
    $('#EstadoActual').prop('disabled',true);
    $('#Editorial').prop('disabled',true);
    $('#Pais').prop('disabled',true);
    $('#Paginas').prop('disabled',true);
    $('#Edicion').prop('disabled',true);
    $('#Tiraje').prop('disabled',true);
    $('#ISBN').prop('disabled',true);
    $('#FechaPublicacion').prop('disabled',true);
    $('#Prosito').prop('disabled',true);
    $('#btnGuardar').prop('disabled', true);

    $('#Autor').keyup(function () {

        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#TituloLibro').prop('disabled', true);
            $('#TipoParticipacion').prop('disabled', true);
            $('#EstadoActual').prop('disabled', true);
            $('#Editorial').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#Paginas').prop('disabled', true);
            $('#Edicion').prop('disabled', true);
            $('#Tiraje').prop('disabled', true);
            $('#ISBN').prop('disabled', true);
            $('#FechaPublicacion').prop('disabled', true);
            $('#Prosito').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#TituloLibro').val('');
            $('#TipoParticipacion').get(0).selectedIndex = 0;
            $('#EstadoActual').get(0).selectedIndex = 0;
            $('#Editorial').val('');
            $('#Pais').val(0);
            $('#Paginas').val('');
            $('#Edicion').val('');
            $('#Tiraje').val('');
            $('#ISBN').val('');
            $('#FechaPublicacion').val('');
            $('#Prosito').get(0).selectedIndex = 0;

        } else {
            $('#TituloLibro').prop('disabled', false);
        }

    })

    $('#TituloLibro').keyup(function () {

        let data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#TipoParticipacion').prop('disabled', true);
            $('#EstadoActual').prop('disabled', true);
            $('#Editorial').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#Paginas').prop('disabled', true);
            $('#Edicion').prop('disabled', true);
            $('#Tiraje').prop('disabled', true);
            $('#ISBN').prop('disabled', true);
            $('#FechaPublicacion').prop('disabled', true);
            $('#Prosito').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#TipoParticipacion').get(0).selectedIndex = 0;
            $('#EstadoActual').get(0).selectedIndex = 0;
            $('#Editorial').val('');
            $('#Pais').val(0);
            $('#Paginas').val('');
            $('#Edicion').val('');
            $('#Tiraje').val('');
            $('#ISBN').val('');
            $('#FechaPublicacion').val('');
            $('#Prosito').get(0).selectedIndex = 0;

        } else {
            $('#TipoParticipacion').prop('disabled', false);
        }

    })

    $('#TipoParticipacion').change(function () {

        let data = $(this).get(0).selectedIndex;

        if (data == null || data == 0 || data == '0' || data == "0") {

            $('#EstadoActual').prop('disabled', true);
            $('#Editorial').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#Paginas').prop('disabled', true);
            $('#Edicion').prop('disabled', true);
            $('#Tiraje').prop('disabled', true);
            $('#ISBN').prop('disabled', true);
            $('#FechaPublicacion').prop('disabled', true);
            $('#Prosito').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#EstadoActual').get(0).selectedIndex = 0;
            $('#Editorial').val('');
            $('#Pais').val(0);
            $('#Paginas').val('');
            $('#Edicion').val('');
            $('#Tiraje').val('');
            $('#ISBN').val('');
            $('#FechaPublicacion').val('');
            $('#Prosito').get(0).selectedIndex = 0;

        } else {
            $('#EstadoActual').prop('disabled', false);
            toastr.success('Tipo de Participación Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton: true })
        }

    })

    $('#EstadoActual').change(function () {

        let data = $(this).get(0).selectedIndex;

        if (data == null || data == 0 || data == '0' || data == "0") {

            $('#Editorial').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#Paginas').prop('disabled', true);
            $('#Edicion').prop('disabled', true);
            $('#Tiraje').prop('disabled', true);
            $('#ISBN').prop('disabled', true);
            $('#FechaPublicacion').prop('disabled', true);
            $('#Prosito').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Editorial').val('');
            $('#Pais').val(0);
            $('#Paginas').val('');
            $('#Edicion').val('');
            $('#Tiraje').val('');
            $('#ISBN').val('');
            $('#FechaPublicacion').val('');
            $('#Prosito').get(0).selectedIndex = 0;

        } else {
            $('#Editorial').prop('disabled', false);
            toastr.success('Estado Actual Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }

    })

    $('#Editorial').keyup(function () {

        let data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#Pais').prop('disabled', true);
            $('#Paginas').prop('disabled', true);
            $('#Edicion').prop('disabled', true);
            $('#Tiraje').prop('disabled', true);
            $('#ISBN').prop('disabled', true);
            $('#FechaPublicacion').prop('disabled', true);
            $('#Prosito').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Pais').val(0);
            $('#Paginas').val('');
            $('#Edicion').val('');
            $('#Tiraje').val('');
            $('#ISBN').val('');
            $('#FechaPublicacion').val('');
            $('#Prosito').get(0).selectedIndex = 0;

        } else {
            $('#Pais').prop('disabled', false);
        }

    })

    $('#Pais').change(function () {

        let data = $(this).val();

        if (data == null || data == 0 || data == '0' || data == "0") {

            $('#Paginas').prop('disabled', true);
            $('#Edicion').prop('disabled', true);
            $('#Tiraje').prop('disabled', true);
            $('#ISBN').prop('disabled', true);
            $('#FechaPublicacion').prop('disabled', true);
            $('#Prosito').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Paginas').val('');
            $('#Edicion').val('');
            $('#Tiraje').val('');
            $('#ISBN').val('');
            $('#FechaPublicacion').val('');
            $('#Prosito').get(0).selectedIndex = 0;

        } else {
            $('#Paginas').prop('disabled', false);
            toastr.success('Pais Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }

    })

    $('#Paginas').keyup(function () {

        let data = $(this).val();

        if (data == null|| data == '' || data == "") {

            $('#Edicion').prop('disabled', true);
            $('#Tiraje').prop('disabled', true);
            $('#ISBN').prop('disabled', true);
            $('#FechaPublicacion').prop('disabled', true);
            $('#Prosito').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Edicion').val('');
            $('#Tiraje').val('');
            $('#ISBN').val('');
            $('#FechaPublicacion').val('');
            $('#Prosito').get(0).selectedIndex = 0;

        } else {
            $('#Edicion').prop('disabled', false);
        }

    })

    $('#Edicion').keyup(function () {

        let data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#Tiraje').prop('disabled', true);
            $('#ISBN').prop('disabled', true);
            $('#FechaPublicacion').prop('disabled', true);
            $('#Prosito').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Tiraje').val('');
            $('#ISBN').val('');
            $('#FechaPublicacion').val('');
            $('#Prosito').get(0).selectedIndex = 0;

        } else {
            $('#Tiraje').prop('disabled', false);
        }

    })

    $('#Tiraje').keyup(function () {

        let data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#ISBN').prop('disabled', true);
            $('#FechaPublicacion').prop('disabled', true);
            $('#Prosito').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ISBN').val('');
            $('#FechaPublicacion').val('');
            $('#Prosito').get(0).selectedIndex = 0;

        } else {
            $('#ISBN').prop('disabled', false);
        }

    })

    $('#ISBN').keyup(function () {

        let data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#FechaPublicacion').prop('disabled', true);
            $('#Prosito').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#FechaPublicacion').val('');
            $('#Prosito').get(0).selectedIndex = 0;

        } else {
            $('#FechaPublicacion').prop('disabled', false);
        }

    })

    $('#FechaPublicacion').change(function () {

        let data = $(this).val();

        if (data == null || data == '' || data == "") {

            $('#Prosito').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Prosito').get(0).selectedIndex = 0;

        } else {
            $('#Prosito').prop('disabled', false);
        }

    })

    $('#Prosito').change(function () {

        let data = $(this).get(0).selectedIndex;

        if (data == null || data == 0 || data == '0' || data == "0") {

            $('#btnGuardar').prop('disabled', true);
        } else {
            $('#btnGuardar').prop('disabled', false);
            toastr.success('Proposito Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }

    })
})