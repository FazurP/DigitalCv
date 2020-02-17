$(document).ready(function ()
{
    $('#idCategoria').change(function () {
        let data = $(this).val();

        if (data == 1) {
            $('#docente').show();
        } else
        {
            $('#docente').hide();
        }
    });
});