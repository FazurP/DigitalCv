$(document).ready(function () {


  
    $('#edad').attr('disabled', true);
    $('#fecha').prop('disabled', true);
    $('#btnGuardar').attr('disabled', true);

    $('#nombrehijo').keyup(function () {

        var text = $('#nombrehijo').val();

        if (text == "") {
          
            $('#edad').attr('disabled', true);
            $('#fecha').prop('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#fecha').val("");
            $('#edad').val("");
        } else
        {

            $('#fecha').prop('disabled', false);

        }


    })

    $('#fecha').change(function () {

        var fecha = $('#fecha').val();

        if (fecha == '' || fecha == null || fecha == "") {
            $('#edad').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#edad').val('');
        } else {
            $('#edad').attr('disabled', false);
        }

    })

    $('#edad').keyup(function () {

        var text = $('#edad').val();

        if (text == "") {

           
            $('#btnGuardar').attr('disabled', true);

        } else {

            $('#btnGuardar').attr('disabled', false);

        }


    })



});