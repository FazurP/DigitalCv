$(document).ready(function () {


    $('#Premio').attr('disabled', true);
    $('#Institucion').attr('disabled', true);
    $('#btnGuardar').attr('disabled', true);

    $('#Actividad').keyup(function () {


        var text = $('#Actividad').val();

        if (text == "") {
            $('#Premio').attr('disabled', true);
            $('#Institucion').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#Premio').val("");
            $('#Institucion').val("");
        }
        else
        {

            $('#Premio').attr('disabled', false);

        }

    })

    $('#Premio').keyup(function () {


        var text = $('#Premio').val();

        if (text == "") {
          
            $('#Institucion').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

           
            $('#Institucion').val("");
        }
        else {

            $('#Institucion').attr('disabled', false);

        }

    })

    $('#Institucion').keyup(function () {


        var text = $('#Institucion').val();

        if (text == "") {

         
            $('#btnGuardar').attr('disabled', true);

        }
        else {

            $('#btnGuardar').attr('disabled', false);

        }

    })

})