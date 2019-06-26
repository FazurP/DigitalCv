$(document).ready(function () {

    $('#StrTipoEvento').prop('disabled', true);
    $('#StrParticipacion').prop('disabled', true);

    $('#StrEvento').keyup(function () {

        var evento = $('#StrEvento').val();

        if (evento == null || evento == '' || evento == "") {

            $('#StrTipoEvento').prop('disabled', true);
        } else {
            $('#StrTipoEvento').prop('disabled', false);
        }

    })

    $('#StrTipoEvento').keyup(function () {

        var tipoEvento = $('#StrTipoEvento').val();

        if (tipoEvento == null || tipoEvento == '' || tipoEvento == "") {
            $('#StrParticipacion').prop('disabled', true);
        }
        else
        {
            $('#StrParticipacion').prop('disabled', false);
        }
    })


    $('#StrParticipacion').keyup(function () {


    })


});