﻿$(document).ready(function () {
    $('#btnEnviar').attr('disabled', true);
    $('#StrObservacion').attr('disabled', true);

    $('#StrDescripcion').keyup(function () {

        var texto = $('#StrDescripcion').val();

        if (texto == "") {
            $('#btnEnviar').attr('disabled', true);
            $('#StrObservacion').attr('disabled', true);

        } else {

            $('#btnEnviar').attr('disabled', false);
            $('#StrObservacion').attr('disabled', false);
        }

    });

});