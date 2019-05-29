$(document).ready(function () {

    $('#Premio').attr('disabled', true);
    $('#Institucion').attr('disabled', true);
    $('#btnGuardar').attr('disabled', true);
    $('#fechaInicio').prop('disabled', true);
    $('#fechaFin').prop('disabled', true);
    $('#fechaObtencion').prop('disabled', true);

    $('#Actividad').keyup(function () {

        var text = $('#Actividad').val();

        if (text == "") {
            $('#Premio').attr('disabled', true);
            $('#Institucion').attr('disabled', true);
            $('#fechaInicio').prop('disabled', true);
            $('#fechaFin').prop('disabled', true);
            $('#fechaObtencion').prop('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#Premio').val("");
            $('#Institucion').val("");
            $('#fechaInicio').val('');
            $('#fechaFin').val('');
            $('#fechaObtencion').val();
        }
        else
        {
            $('#fechaInicio').prop('disabled', false);
        }

    })

    $('#fechaInicio').change(function () {

        var fecha = $('#fechaInicio').val();

        if (fecha == null || fecha == "" || fecha == '') {

            $('#fechaFin').prop('disabled', true);
            $('#Premio').attr('disabled', true);
            $('#Institucion').attr('disabled', true);
            $('#fechaObtencion').prop('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#fechaFin').val('');
            $('#Premio').val('');
            $('Institucion').val('');
            $('#fechaObtencion').val('');
        } else {
            $('#fechaFin').prop('disabled', false);
        }

    })

    $('#fechaFin').change(function () {

        var fecha = $('#fechaFin').val();

        if (fecha == null || fecha == '' || fecha == "") {

            $('#Premio').attr('disabled', true);
            $('#Institucion').attr('disabled', true);
            $('#fechaObtencion').prop('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#Premio').val('');
            $('Institucion').val('');
            $('#fechaObtencion').val('');
        } else {
            $('#Premio').attr('disabled', false);
        }
    })

    $('#Premio').keyup(function () {

        var text = $('#Premio').val();

        if (text == "") {
          
            $('#Institucion').attr('disabled', true);
            $('#fechaObtencion').prop('disabled', true);
            $('#btnGuardar').attr('disabled', true);
           
            $('Institucion').val('');
            $('#fechaObtencion').val('');
        }
        else
        {
            $('#Institucion').attr('disabled', false);
        }

    })

    $('#Institucion').keyup(function () {

        var text = $('#Institucion').val();

        if (text == "") {

            $('#fechaObtencion').prop('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#fechaObtencion').val('');
        }
        else {
            $('#fechaObtencion').prop('disabled', false);
        }

    })

    $('#fechaObtencion').change(function () {

        var fecha = $('#fechaObtencion').val();

        if (fecha == null || fecha == '' || fecha == "") {
            $('#btnGuardar').attr('disabled', true);
        } else {
            $('#btnGuardar').attr('disabled', false);
        }
    })

})