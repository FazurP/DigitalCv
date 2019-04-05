$(document).ready(function () {

    $('#Paterno').attr('disabled', true);
    $('#Materno').attr('disabled', true);
    $('#Curp').attr('disabled', true);
    $('#Rfc').attr('disabled', true);
    $('#Homoclave').attr('disabled', true);
    $('#Semblanza').attr('disabled', true);
    $('#Enviar').attr('disabled', true);


    //Evento para el campo de texto Nombre
    $('#Nombre').keyup(function () {

        var texto = $('#Nombre').val();

        if (texto == "") {
            $('#Paterno').attr('disabled', true);
            $('#Materno').attr('disabled', true);
            $('#Curp').attr('disabled', true);
            $('#Rfc').attr('disabled', true);
            $('#Homoclave').attr('disabled', true);
            $('#Semblanza').attr('disabled', true);
            $('#Enviar').attr('disabled', true);

            $('#Paterno').val("");
            $('#Materno').val("");
            $('#Curp').val("");
            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#Semblanza').val("");

        } else {

            $('#Paterno').attr('disabled', false);

        }

    })


    //Evento para el campo de texto ApellidoPaterno
    $('#Paterno').keyup(function () {

        var texto = $('#Paterno').val();

        if (texto == "") {

            $('#Materno').attr('disabled', true);
            $('#Curp').attr('disabled', true);
            $('#Rfc').attr('disabled', true);
            $('#Homoclave').attr('disabled', true);
            $('#Semblanza').attr('disabled', true);
            $('#Enviar').attr('disabled', true);


            $('#Materno').val("");
            $('#Curp').val("");
            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#Semblanza').val("");

        } else {

            $('#Materno').attr('disabled', false);

        }

    })

    //Evento para el campo de texto ApellidoMaterno
    $('#Materno').keyup(function () {

        var texto = $('#Materno').val();

        if (texto == "") {


            $('#Curp').attr('disabled', true);
            $('#Rfc').attr('disabled', true);
            $('#Homoclave').attr('disabled', true);
            $('#Semblanza').attr('disabled', true);
            $('#Enviar').attr('disabled', true);



            $('#Curp').val("");
            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#Semblanza').val("");

        } else {

            $('#Curp').attr('disabled', false);

        }

    })

    //Evento para el campo de texto Curp
    $('#Curp').keyup(function () {

        var texto = $('#Curp').val();

        if (texto == "") {



            $('#Rfc').attr('disabled', true);
            $('#Homoclave').attr('disabled', true);
            $('#Semblanza').attr('disabled', true);
            $('#Enviar').attr('disabled', true);




            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#Semblanza').val("");

        } else {

            $('#Rfc').attr('disabled', false);

        }

    })

    //Evento para el campo de texto Rfc
    $('#Rfc').keyup(function () {

        var texto = $('#Rfc').val();

        if (texto == "") {

            $('#Homoclave').attr('disabled', true);
            $('#Semblanza').attr('disabled', true);
            $('#Enviar').attr('disabled', true);


            $('#Homoclave').val("");
            $('#Semblanza').val("");

        } else {

            $('#Homoclave').attr('disabled', false);

        }

    })

    //Evento para el campo de texto Homoclave
    $('#Homoclave').keyup(function () {

        var texto = $('#Homoclave').val();

        if (texto == "") {


            $('#Semblanza').attr('disabled', true);
            $('#Enviar').attr('disabled', true);



            $('#Semblanza').val("");

        } else {

            $('#Semblanza').attr('disabled', false);

        }

    })

    //Evento para el campo de texto Homoclave
    $('#Semblanza').keyup(function () {

        var texto = $('#Semblanza').val();

        if (texto == "") {



            $('#Enviar').attr('disabled', true);

        } else {

            $('#Enviar').attr('disabled', false);

        }

    })


});


