$(document).ready(function () {

    $('#Actividad').attr('disabled', true);
    $('#Institucion').attr('disabled', true);
    $('#btnGuardar').attr('disabled', true);
    $('#fechaObtencion').prop('disabled', true);
    $('#documentoInputFile').prop('disabled', true);

    $('#Premio').keyup(function () {

        var text = $('#Premio').val();

        if (text == "") {

            $('#Actividad').attr('disabled', true);
            $('#Institucion').attr('disabled', true);
            $('#fechaObtencion').prop('disabled', true);
            $('#documentoInputFile').prop('disabled', true);
            $('#btnGuardar').attr('disabled', true);
           

            $('#Institucion').val('');
            $('#fechaObtencion').val('');
            $('#Actividad').val('');
            $('#documentoInputFile').val('');
        }
        else {
            $('#Actividad').attr('disabled', false);
        }

    })

    $('#Actividad').keyup(function () {

        var text = $('#Actividad').val();

        if (text == "") {

            $('#Institucion').attr('disabled', true);
            $('#fechaObtencion').prop('disabled', true);
            $('#documentoInputFile').prop('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#Institucion').val("");
            $('#fechaObtencion').val("");
            $('#documentoInputFile').val("");
        }
        else
        {
            $('#Institucion').prop('disabled', false);
        }

    })

    $('#Institucion').keyup(function () {

        var text = $('#Institucion').val();

        if (text == "") {

            $('#fechaObtencion').prop('disabled', true);
            $('#documentoInputFile').prop('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#fechaObtencion').val('');
            $('#documentoInputFile').val('');
        }
        else {
            $('#fechaObtencion').prop('disabled', false);
        }

    })

    $('#fechaObtencion').change(function () {

        var fecha = $('#fechaObtencion').val();

        if (fecha == null || fecha == '' || fecha == "") {
            $('#documentoInputFile').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);
        } else {
            $('#documentoInputFile').attr('disabled', false);
        }
    })

})