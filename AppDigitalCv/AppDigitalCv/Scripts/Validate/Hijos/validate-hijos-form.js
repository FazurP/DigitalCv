$(document).ready(function () {


  
    $('#ApellidoPaterno').attr('disabled', true);
    $('#ApellidoMaterno').attr('disabled', true);
    $('#fecha').prop('disabled', true);
    $('#btnGuardar').attr('disabled', true);

    $('#nombrehijo').keyup(function () {

        var text = $('#nombrehijo').val();

        if (text == "") {
          
            $('#ApellidoPaterno').attr('disabled', true);
            $('#ApellidoMaterno').attr('disabled', true);
            $('#fecha').prop('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#ApellidoPaterno').val("");
            $('#ApellidoMaterno').val("");
            $('#fecha').val("");
        } else
        {

            $('#ApellidoPaterno').prop('disabled', false);

        }


    })

    $('#ApellidoPaterno').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#ApellidoMaterno').attr('disabled', true);
            $('#fecha').prop('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#ApellidoMaterno').val("");
            $('#fecha').val("");
        } else {

            $('#ApellidoMaterno').prop('disabled', false);

        }


    })

    $('#ApellidoMaterno').keyup(function () {

        var text = $(this).val();

        if (text == "") {

            $('#fecha').prop('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#fecha').val("");
        } else {

            $('#fecha').prop('disabled', false);

        }


    })


    $('#fecha').change(function () {

        var text = $(this).val();

        if (text == "") {

            $('#btnGuardar').attr('disabled', true);

        } else {

            $('#btnGuardar').prop('disabled', false);

        }


    })
});