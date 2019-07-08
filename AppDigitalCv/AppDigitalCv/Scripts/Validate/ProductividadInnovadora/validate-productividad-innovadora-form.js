$(document).ready(function () {

    $('#Innovadora').prop('disabled', true);
    $('#Titulo').prop('disabled', true);
    $('#Descripcion').prop('disabled', true);
    $('#Patentes').prop('disabled', true);
    $('#Uso').prop('disabled', true);
    $('#EstadoActual').prop('disabled', true);
    $('#NumeroRegistro').prop('disabled', true);
    $('#Usuario').prop('disabled', true);
    $('#Pais').prop('disabled', true);
    $('#FechaRegistro').prop('disabled', true);
    $('#Proposito').prop('disabled', true);
    $('#inputFileUpload').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#Autor').keyup(function () {
        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#Innovadora').prop('disabled', true);
            $('#Titulo').prop('disabled', true);
            $('#Descripcion').prop('disabled', true);
            $('#Patentes').prop('disabled', true);
            $('#Uso').prop('disabled', true);
            $('#EstadoActual').prop('disabled', true);
            $('#NumeroRegistro').prop('disabled', true);
            $('#Usuario').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#FechaRegistro').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Innovadora').get(0).selectedIndex = 0;
            $('#Titulo').val('');
            $('#Descripcion').val('');
            $('#Patentes').get(0).selectedIndex = 0;
            $('#Uso').val('');
            $('#EstadoActual').get(0).selectedIndex = 0;
            $('#NumeroRegistro').val('');
            $('#Usuario').val('');
            $('#Pais').val(0);
            $('#FechaRegistro').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else
        {
            $('#Innovadora').prop('disabled', false);
        }
    })

    $('#Innovadora').change(function () {
        let data = $(this).get(0).selectedIndex;

        if (data == null || data == 0 || data == '0' || data == "0") {
            $('#Titulo').prop('disabled', true);
            $('#Descripcion').prop('disabled', true);
            $('#Patentes').prop('disabled', true);
            $('#Uso').prop('disabled', true);
            $('#EstadoActual').prop('disabled', true);
            $('#NumeroRegistro').prop('disabled', true);
            $('#Usuario').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#FechaRegistro').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Titulo').val('');
            $('#Descripcion').val('');
            $('#Patentes').get(0).selectedIndex = 0;
            $('#Uso').val('');
            $('#EstadoActual').get(0).selectedIndex = 0;
            $('#NumeroRegistro').val('');
            $('#Usuario').val('');
            $('#Pais').val(0);
            $('#FechaRegistro').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            toastr.success('Productividad Innovadora Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#Titulo').prop('disabled', false);
        }
    })

    $('#Titulo').keyup(function () {
        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#Descripcion').prop('disabled', true);
            $('#Patentes').prop('disabled', true);
            $('#Uso').prop('disabled', true);
            $('#EstadoActual').prop('disabled', true);
            $('#NumeroRegistro').prop('disabled', true);
            $('#Usuario').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#FechaRegistro').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Descripcion').val('');
            $('#Patentes').get(0).selectedIndex = 0;
            $('#Uso').val('');
            $('#EstadoActual').get(0).selectedIndex = 0;
            $('#NumeroRegistro').val('');
            $('#Usuario').val('');
            $('#Pais').val(0);
            $('#FechaRegistro').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#Descripcion').prop('disabled', false);
        }
    })

    $('#Descripcion').keyup(function () {
        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#Patentes').prop('disabled', true);
            $('#Uso').prop('disabled', true);
            $('#EstadoActual').prop('disabled', true);
            $('#NumeroRegistro').prop('disabled', true);
            $('#Usuario').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#FechaRegistro').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Patentes').get(0).selectedIndex = 0;
            $('#Uso').val('');
            $('#EstadoActual').get(0).selectedIndex = 0;
            $('#NumeroRegistro').val('');
            $('#Usuario').val('');
            $('#Pais').val(0);
            $('#FechaRegistro').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#Patentes').prop('disabled', false);
        }
    })

    $('#Patentes').change(function () {
        let data = $(this).get(0).selectedIndex;

        if (data == null || data == 0 || data == '0' || data == "0") {
            $('#Uso').prop('disabled', true);
            $('#EstadoActual').prop('disabled', true);
            $('#NumeroRegistro').prop('disabled', true);
            $('#Usuario').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#FechaRegistro').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Uso').val('');
            $('#EstadoActual').get(0).selectedIndex = 0;
            $('#NumeroRegistro').val('');
            $('#Usuario').val('');
            $('#Pais').val(0);
            $('#FechaRegistro').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            toastr.success('Clasificación de Patentes Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton: true })
            $('#Uso').prop('disabled', false);
        }
    })

    $('#Uso').keyup(function () {
        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#EstadoActual').prop('disabled', true);
            $('#NumeroRegistro').prop('disabled', true);
            $('#Usuario').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#FechaRegistro').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#EstadoActual').get(0).selectedIndex = 0;
            $('#NumeroRegistro').val('');
            $('#Usuario').val('');
            $('#Pais').val(0);
            $('#FechaRegistro').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#EstadoActual').prop('disabled', false);
        }
    })

    $('#EstadoActual').change(function () {
        let data = $(this).get(0).selectedIndex;

        if (data == null || data == 0 || data == '0' || data == "0") {
            $('#NumeroRegistro').prop('disabled', true);
            $('#Usuario').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#FechaRegistro').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#NumeroRegistro').val('');
            $('#Usuario').val('');
            $('#Pais').val(0);
            $('#FechaRegistro').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            toastr.success('Estado Actual Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true })
            $('#NumeroRegistro').prop('disabled', false);
        }
    })

    $('#NumeroRegistro').keyup(function () {
        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#Usuario').prop('disabled', true);
            $('#Pais').prop('disabled', true);
            $('#FechaRegistro').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Usuario').val('');
            $('#Pais').val(0);
            $('#FechaRegistro').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#Usuario').prop('disabled', false);
        }
    })

    $('#Usuario').keyup(function () {
        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#Pais').prop('disabled', true);
            $('#FechaRegistro').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Pais').val(0);
            $('#FechaRegistro').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            $('#Pais').prop('disabled', false);
        }
    })

    $('#Pais').change(function () {
        let data = $(this).val();

        if (data == null || data == 0 || data == '0' || data == "0") {
            $('#FechaRegistro').prop('disabled', true);
            $('#Proposito').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#FechaRegistro').val('');
            $('#Proposito').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');
        } else {
            toastr.success('Pais Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#FechaRegistro').prop('disabled', false);
        }
    })

    $('#FechaRegistro').change(function () {
        let data = $(this).val();

        if (data == null || data == '' || data == "") {
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

        if (data == null || data == 0 || data == '0' || data == "0") {
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#inputFileUpload').val('');
        } else {
            toastr.success('Proposito Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#inputFileUpload').prop('disabled', false);
        }
    })

    $('#inputFileUpload').change(function () {
        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#btnGuardar').prop('disabled', true);
        } else {
            $('#btnGuardar').prop('disabled', false);
        }
    })
})