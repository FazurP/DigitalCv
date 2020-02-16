$(document).ready(function ()
{

    $('#lugar').prop('disabled', true);
    $('#año').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);


    $('#nombre').keyup(function ()
    {
        let data = $(this).val();

        if (data == "") {
            $('#lugar').prop('disabled', true);
            $('#año').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#lugar').val("");
            $('#año').val("");
        } else
        {
            $('#lugar').prop('disabled', false);
        }
    });

    $('#lugar').keyup(function () {
        let data = $(this).val();

        if (data == "") {
            $('#año').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#año').val("");
        } else {
            $('#año').prop('disabled', false);
        }
    });

    $('#año').change(function () {
        let data = $(this).val();

        if (data == "") {
            $('#btnGuardar').prop('disabled', true);

        } else {
            $('#btnGuardar').prop('disabled', false);
        }
    });
});