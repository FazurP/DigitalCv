$(document).ready(function () {

    $('#fecha').prop('disabled', true);
    $('#participacion').prop('disabled', true);
    $('#funcion').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#asociacion').change(function ()
    {
        let data = $(this).val();

        if (data == 0 || data == '0' || data == "0" || data == null) {

            $('#fecha').prop('disabled', true);
            $('#participacion').prop('disabled', true);
            $('#funcion').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#fecha').val('');
            $('#participacion').val('');
            $('#funcion').val('');

        } else
        {
            toastr.success("Asociación y/o Colectivo Seleccionado", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#fecha').prop('disabled', false);
        }
    });


    $('#fecha').change(function () {

        let data = $(this).val();

        if (data == "") {

            $('#participacion').prop('disabled', true);
            $('#funcion').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#participacion').val('');
            $('#funcion').val('');

        } else {
            toastr.success("Fecha Seleccionada", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#participacion').prop('disabled', false);
        }
    });

    $('#participacion').keyup(function () {

        let data = $(this).val();

        if (data == "") {

            $('#funcion').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#funcion').val('');

        } else {
            $('#funcion').prop('disabled', false);
        }
    });

    $('#funcion').keyup(function () {

        let data = $(this).val();

        if (data == "") {

            $('#btnGuardar').prop('disabled', true);

        } else {
            $('#btnGuardar').prop('disabled', false);
        }
    });
});