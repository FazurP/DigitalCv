$(document).ready(function () {

    $('#TelefonoCelular').val("");
    $('#TelefonoCasa').val("");
    $('#TelefonoRecados').val("");
    $('#EmailInstitucional').val("");
    $('#EmailPersonal').val("");
    $('#Facebook').val("");
    $('#Twitter').val("");

    $('#TelefonoCasa').attr('disabled', true);
    $('#TelefonoRecados').attr('disabled', true);
    $('#EmailInstitucional').attr('disabled', true);
    $('#EmailPersonal').attr('disabled', true);
    $('#Facebook').attr('disabled', true);
    $('#Twitter').attr('disabled', true);
    $('#btnGuardar').attr('disabled', true);

    $('#TelefonoCelular').keyup(function () {

        var text = $('#TelefonoCelular').val();

        if (text == "") {

            $('#TelefonoCasa').attr('disabled', true);
            $('#TelefonoRecados').attr('disabled', true);
            $('#EmailInstitucional').attr('disabled', true);
            $('#EmailPersonal').attr('disabled', true);
            $('#Facebook').attr('disabled', true);
            $('#Twitter').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#TelefonoCasa').val("");
            $('#TelefonoRecados').val("");
            $('#EmailInstitucional').val("");
            $('#EmailPersonal').val("");
            $('#Facebook').val("");
            $('#Twitter').val("");

        } else {

            $('#TelefonoCasa').attr('disabled', false);

        }

    })

    $('#TelefonoCasa').keyup(function () {

        var text = $('#TelefonoCasa').val();

        if (text == "") {

            $('#TelefonoRecados').attr('disabled', true);
            $('#EmailInstitucional').attr('disabled', true);
            $('#EmailPersonal').attr('disabled', true);
            $('#Facebook').attr('disabled', true);
            $('#Twitter').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#TelefonoRecados').val("");
            $('#EmailInstitucional').val("");
            $('#EmailPersonal').val("");
            $('#Facebook').val("");
            $('#Twitter').val("");

        } else {

            $('#TelefonoRecados').attr('disabled', false);

        }

    })

    $('#TelefonoRecados').keyup(function () {

        var text = $('#TelefonoRecados').val();

        if (text == "") {

            $('#EmailInstitucional').attr('disabled', true);
            $('#EmailPersonal').attr('disabled', true);
            $('#Facebook').attr('disabled', true);
            $('#Twitter').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#EmailInstitucional').val("");
            $('#EmailPersonal').val("");
            $('#Facebook').val("");
            $('#Twitter').val("");

        } else {

            $('#EmailInstitucional').attr('disabled', false);

        }

    })

    $('#EmailInstitucional').keyup(function () {

        var text = $('#EmailInstitucional').val();

        if (text == "") {

            $('#EmailPersonal').attr('disabled', true);
            $('#Facebook').attr('disabled', true);
            $('#Twitter').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#EmailPersonal').val("");
            $('#Facebook').val("");
            $('#Twitter').val("");

        } else {

            $('#EmailPersonal').attr('disabled', false);

        }

    })

    $('#EmailPersonal').keyup(function () {

        var text = $('#EmailPersonal').val();

        if (text == "") {

            $('#Facebook').attr('disabled', true);
            $('#Twitter').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#Facebook').val("");
            $('#Twitter').val("");


        } else {

            $('#Facebook').attr('disabled', false);

        }

    })

    $('#Facebook').keyup(function () {

        var text = $('#Facebook').val();

        if (text == "") {

            $('#Twitter').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#Twitter').val("");

        } else {

            $('#Twitter').attr('disabled', false);

        }

    })

    $('#Twitter').keyup(function () {

        var text = $('#Twitter').val();

        if (text == "") {
            $('#btnGuardar').attr('disabled', true);
        } else {

            $('#btnGuardar').attr('disabled', false);

        }

    })
})