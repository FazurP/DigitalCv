$(document).ready(function()
{


    $('#strNombre').prop('disabled', true);
    $('#strTotalHoras').prop('disabled', true);
    $('#strInstitucionAcredita').prop('disabled', true);
    $('#file').prop('disabled', true);
    $('#Enviar').prop('disabled', true);


    $('#idTipoCapacitacion').change(function ()
    {
        let data = $(this).val();

        if (data == 0) {

            $('#strNombre').prop('disabled', true);
            $('#strTotalHoras').prop('disabled', true);
            $('#strInstitucionAcredita').prop('disabled', true);
            $('#file').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#strNombre').val("");
            $('#strTotalHoras').val("");
            $('#strInstitucionAcredita').val("");
            $('#file').val("");
        } else
        {
            toastr.success("Tipo de Capacitación Seleccionada", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#strNombre').prop('disabled', false);
        }
    });

    $('#strNombre').keyup(function () {
        let data = $(this).val();

        if ($.isEmptyObject(data)) {

            $('#strTotalHoras').prop('disabled', true);
            $('#strInstitucionAcredita').prop('disabled', true);
            $('#file').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#strTotalHoras').val("");
            $('#strInstitucionAcredita').val("");
            $('#file').val("");
        } else {
            $('#strTotalHoras').prop('disabled', false);
        }
    });

    $('#strTotalHoras').keyup(function () {
        let data = $(this).val();

        if ($.isEmptyObject(data)) {

            $('#strInstitucionAcredita').prop('disabled', true);
            $('#file').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#strInstitucionAcredita').val("");
            $('#file').val("");
        } else {
            $('#strInstitucionAcredita').prop('disabled', false);
        }
    });

    $('#strInstitucionAcredita').keyup(function () {
        let data = $(this).val();

        if ($.isEmptyObject(data)) {

            $('#file').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#file').val("");
        } else {
            $('#file').prop('disabled', false);
        }
    });
});