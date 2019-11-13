$(document).ready(function () {

    $('#ApellidoPaterno').attr('disabled', true);
    $('#ApellidoMaterno').attr('disabled', true);
    $('#TelefonoCelular').attr('disabled', true);
    $('#TelefonoCasa').attr('disabled', true);
    $('#TelefonoRecados').attr('disabled', true);
    $('#EmailPersonal').attr('disabled', true);
    $('#Direccion').attr('disabled', true);
    $('#Facebook').attr('disabled', true);
    $('#Twitter').attr('disabled', true);
    $('#btnGuardar').attr('disabled', true);

    $('#Nombre').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#ApellidoPaterno').attr('disabled', true);
            $('#ApellidoMaterno').attr('disabled', true);
            $('#TelefonoCelular').attr('disabled', true);
            $('#TelefonoCasa').attr('disabled', true);
            $('#TelefonoRecados').attr('disabled', true);
            $('#EmailPersonal').attr('disabled', true);
            $('#Direccion').attr('disabled', true);
            $('#Facebook').attr('disabled', true);
            $('#Twitter').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#ApellidoPaterno').val("");
            $('#ApellidoMaterno').val("");
            $('#TelefonoCelular').val("");
            $('#TelefonoCasa').val("");
            $('#TelefonoRecados').val("");
            $('#EmailPersonal').val("");
            $('#Direccion').val("");
            $('#Facebook').val("");
            $('#Twitter').val("");

        } else {

            $('#ApellidoPaterno').attr('disabled', false);

        }

    })

    $('#ApellidoPaterno').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#ApellidoMaterno').attr('disabled', true);
            $('#TelefonoCelular').attr('disabled', true);
            $('#TelefonoCasa').attr('disabled', true);
            $('#TelefonoRecados').attr('disabled', true);
            $('#EmailPersonal').attr('disabled', true);
            $('#Direccion').attr('disabled', true);
            $('#Facebook').attr('disabled', true);
            $('#Twitter').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#ApellidoMaterno').val("");
            $('#TelefonoCelular').val("");
            $('#TelefonoCasa').val("");
            $('#TelefonoRecados').val("");
            $('#EmailPersonal').val("");
            $('#Direccion').val("");
            $('#Facebook').val("");
            $('#Twitter').val("");

        } else {

            $('#ApellidoMaterno').attr('disabled', false);

        }

    })

    $('#ApellidoMaterno').keyup(function () {

        var text = $(this).val();

        if (text == "") {
            $('#TelefonoCelular').attr('disabled', true);
            $('#TelefonoCasa').attr('disabled', true);
            $('#TelefonoRecados').attr('disabled', true);
            $('#EmailPersonal').attr('disabled', true);
            $('#Direccion').attr('disabled', true);
            $('#Facebook').attr('disabled', true);
            $('#Twitter').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#TelefonoCelular').val("");
            $('#TelefonoCasa').val("");
            $('#TelefonoRecados').val("");
            $('#EmailPersonal').val("");
            $('#Direccion').val("");
            $('#Facebook').val("");
            $('#Twitter').val("");

        } else {

            $('#TelefonoCelular').attr('disabled', false);

        }

    })

    $('#TelefonoCelular').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#TelefonoCasa').attr('disabled', true);
            $('#TelefonoRecados').attr('disabled', true);
            $('#EmailPersonal').attr('disabled', true);
            $('#Direccion').attr('disabled', true);
            $('#Facebook').attr('disabled', true);
            $('#Twitter').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#TelefonoCasa').val("");
            $('#TelefonoRecados').val("");
            $('#EmailPersonal').val("");
            $('#Direccion').val("");
            $('#Facebook').val("");
            $('#Twitter').val("");


        } else {

            $('#TelefonoCasa').attr('disabled', false);

        }

    })

    $('#TelefonoCasa').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#TelefonoRecados').attr('disabled', true);
            $('#EmailPersonal').attr('disabled', true);
            $('#Direccion').attr('disabled', true);
            $('#Facebook').attr('disabled', true);
            $('#Twitter').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#TelefonoRecados').val("");
            $('#EmailPersonal').val("");
            $('#Direccion').val("");
            $('#Facebook').val("");
            $('#Twitter').val("");

        } else {

            $('#TelefonoRecados').attr('disabled', false);

        }

    })

    $('#TelefonoRecados').keyup(function () {

        var text = $(this).val();

        if (text == "") {
            $('#EmailPersonal').attr('disabled', true);
            $('#Direccion').attr('disabled', true);
            $('#Facebook').attr('disabled', true);
            $('#Twitter').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#EmailPersonal').val("");
            $('#Direccion').val("");
            $('#Facebook').val("");
            $('#Twitter').val("");
        } else {

            $('#EmailPersonal').attr('disabled', false);

        }

    })

    $('#EmailPersonal').keyup(function () {

        var text = $(this).val();

        if (text == "") {
            $('#Direccion').attr('disabled', true);
            $('#Facebook').attr('disabled', true);
            $('#Twitter').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#Direccion').val("");
            $('#Facebook').val("");
            $('#Twitter').val("");
        } else {

            $('#Direccion').attr('disabled', false);

        }

    })

    $('#Direccion').keyup(function () {

        var text = $(this).val();

        if (text == "") {
            $('#Facebook').attr('disabled', true);
            $('#Twitter').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#Facebook').val("");
            $('#Twitter').val("");
        } else {

            $('#Facebook').attr('disabled', false);
            $('#btnGuardar').attr('disabled', false);

        }

    })

    $('#Facebook').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#Twitter').attr('disabled', true);

        } else {

            $('#Twitter').attr('disabled', false);

        }

    })
})