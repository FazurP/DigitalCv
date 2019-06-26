$(document).ready(function () {

    $('#StrTipoEvento').prop('disabled', true);
    $('#StrParticipacion').prop('disabled', true);
    $('input[id=si]').prop('disabled', true);
    $('#StrNombrePonencia').prop('disabled', true);
    $('#StrNombreInstitucionEmpresa').prop('disabled', true);
    $('#StrLugar').prop('disabled', true);
    $('#DteFecha').prop('disabled', true);



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

        var participacion = $('#StrParticipacion').val();
        if (participacion == null || participacion == '' || participacion == "") {
            $('#StrNombrePonencia').prop('disabled', true);
            $('input[id=si]').prop('disabled', true);
        }
        else
        {
            $('input[id=si]').prop('disabled', false);
        }
    })
    $('input[id=si]').change(function () {

        let si = $('input[id=si]:checked').val();
        if (si == null || si == '' || si == "") {
            $('#StrNombrePonencia').prop('disabled', true);
            $('input[id=si]').prop('disabled', true);
        }
        else
        {
            $('#StrNombrePonencia').prop('disabled', false);
        }

    })

    $('#StrNombrePonencia').keyup(function () {

        var nombrePonencia = $('#StrNombrePonencia').val();
        if (nombrePonencia == null || nombrePonencia == '' || nombrePonencia == "") {
            
            $('#StrNombreInstitucionEmpresa').prop('disabled', true);
        }
        else
        {
            $('#StrNombrePonencia').prop('disabled', false);
            $('#StrNombreInstitucionEmpresa').prop('disabled', false);
        }

    })

    $('#StrNombreInstitucionEmpresa').keyup(function () {

        var institucion = $('#StrNombreInstitucionEmpresa').val();
        if (institucion == null || institucion == '' || institucion == "") {
            
            $('#StrLugar').prop('disabled', true);
        }
        else {
            $('#StrNombreInstitucionEmpresa').prop('disabled', false);
            $('#StrLugar').prop('disabled', false);
        }
    })
    $('#StrLugar').keyup(function () {

        var lugar = $('#StrLugar').val();
        if (lugar == null || lugar == '' || lugar == "") {
            
            $('#DteFecha').prop('disabled', true);
        }
        else
        {
            $('#StrLugar').prop('disabled', false);
            $('#DteFecha').prop('disabled', false);
        }


    })

    $('#DteFecha').change(function () {
        let fecha = $('#DteFecha').val();
        if (fecha == '' || fecha == "" || fecha == null)
        {
            $('#DteFecha').prop('disabled', true);

        }
        else {
            $('#DteFecha').prop('disabled', false);
        }


    })


});