$(document).ready(function () {

    $('#Numero').prop('disabled', true);
    $('#Vigencia').prop('disabled', true);
    $('#Evidencia').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#Documentos').change(function () {
        var documento = $('#Documentos').val();

        if (documento == '--Seleccionar--') {

            $('#Numero').prop('disabled', true);
            $('#Vigencia').prop('disabled', true);
            $('#Evidencia').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Numero').val('');
            $('#Vigencia').val('');
            $('#Evidencia').val('');

        } else {
            $('#Numero').prop('disabled', false);
            toastr.success("Tipo de Documento Seleccionado", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
        }

    })

    $('#Numero').keyup(function () {
        var numero = $('#Numero').val();

        if (numero == null || numero == "" || numero == '') {
            $('#Vigencia').prop('disabled', true);
            $('#Evidencia').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Vigencia').val('');
            $('#Evidencia').val('');
        } else {
            $('#Vigencia').prop('disabled', false);
        }
    })

    $('#Vigencia').change(function () {
        var vigencia = $('#Vigencia').val();

        if (vigencia == null || vigencia == "" || vigencia == '') {

            $('#Evidencia').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#Evidencia').val('');
        } else {
            $('#Evidencia').prop('disabled', false);
        }
    })

    $('#Evidencia').change(function () {
        var evidencia = $('#Evidencia').val();

        if (evidencia == "") {
            $('#btnGuardar').prop('disabled', true);
        } else {
            $('#btnGuardar').prop('disabled', false);
        }
    })



})