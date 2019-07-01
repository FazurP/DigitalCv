﻿$(document).ready(function () {

    $('#Paterno').attr('disabled', true);
    $('#Materno').attr('disabled', true);
    $('#Curp').attr('disabled', true);
    $('#Rfc').attr('disabled', true);
    $('#Semblanza').attr('disabled', true);
    $('#Enviar').attr('disabled', true);
    $('#IdEstadoCivil').attr('disabled', true);
    $('input[id=sexo]').attr('disabled', true);
    $('#Homoclave').attr('readonly', true);

    //Evento para el campo de texto Nombre
    $('#Nombre').keyup(function () {

        var texto = $('#Nombre').val();

        if (texto == "") {
            $('#Paterno').attr('disabled', true);
            $('#Materno').attr('disabled', true);
            $('#Curp').attr('disabled', true);
            $('#Rfc').attr('disabled', true);
            //$('#Homoclave').attr('disabled', true);
            $('#Semblanza').attr('disabled', true);
            $('#Enviar').attr('disabled', true);
            $('#IdEstadoCivil').attr('disabled', true);
            $('input[id=sexo]').attr('disabled', true);

            $('#Paterno').val("");
            $('#Materno').val("");
            $('#Curp').val("");
            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#Semblanza').val("");
            $('#IdEstadoCivil').val(0);
            $('input[id=sexo]').prop('checked', false);

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
            //$('#Homoclave').attr('disabled', true);
            $('#Semblanza').attr('disabled', true);
            $('#Enviar').attr('disabled', true);
            $('#IdEstadoCivil').attr('disabled', true);
            $('input[id=sexo]').attr('disabled', true);


            $('#Materno').val("");
            $('#Curp').val("");
            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#Semblanza').val("");
            $('#IdEstadoCivil').val(0);
            $('input[id=sexo]').prop('checked', false);
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
            //$('#Homoclave').attr('disabled', true);
            $('#Semblanza').attr('disabled', true);
            $('#Enviar').attr('disabled', true);
            $('#IdEstadoCivil').attr('disabled', true);
            $('input[id=sexo]').attr('disabled', true);


            $('#Curp').val("");
            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#Semblanza').val("");
            $('#IdEstadoCivil').val(0);
            $('input[id=sexo]').prop('checked', false);

        } else {

            $('#IdEstadoCivil').attr('disabled', false);

        }

    })
    //Evento para el campo de Estado Civil
    $('#IdEstadoCivil').change(function () {
        var estadoCivil = $('#IdEstadoCivil').val();
        if (estadoCivil == 0 || estadoCivil == '0' || estadoCivil == "0") {
            $('#Curp').attr('disabled', true);
            $('#Rfc').attr('disabled', true);
            //$('#Homoclave').attr('disabled', true);
            $('#Semblanza').attr('disabled', true);
            $('#Enviar').attr('disabled', true);
            $('input[id=sexo]').attr('disabled', true);

            $('#Curp').val("");
            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#Semblanza').val("");
            $('input[id=sexo]').prop('checked', false);
        } else {
            $('input[id=sexo]').attr('disabled', false);
            toastr.info("Estado Civil Seleccionado", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
        }
    })
    //Evento para el campo de Sexo
    $('input[id=sexo]').change(function () {
        var sexo = $('input[id=sexo]:checked').val();
        if (sexo == null || sexo == '' || sexo == "") {
            $('#Curp').attr('disabled', true);
            $('#Rfc').attr('disabled', true);
            //$('#Homoclave').attr('disabled', true);
            $('#Semblanza').attr('disabled', true);
            $('#Enviar').attr('disabled', true);

            $('#Curp').val("");
            $('#Rfc').val("");
            $('#Homoclave').val("");
            $('#Semblanza').val("");

        } else {
            toastr.success('Sexo Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#Curp').attr('disabled', false);
        }
    })
    //Evento para el campo de texto Curp
    $('#Curp').keyup(function () {

        var texto = $('#Curp').val();

        if (texto == "") {

            $('#Rfc').attr('disabled', true);
            //$('#Homoclave').attr('disabled', true);
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

            //$('#Homoclave').attr('disabled', true);
            $('#Semblanza').attr('disabled', true);
            $('#Enviar').attr('disabled', true);


            $('#Homoclave').val("");
            $('#Semblanza').val("");

        } else {

            

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


