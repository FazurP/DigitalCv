$(document).ready(function () {

    $('#Estados').prop('disabled', true);
    $('#Municipios').prop('disabled', true);
    $('#IdColonia').prop('disabled', true);
    $('#codigoPostal').prop('disabled', true);
    $('#NInterior').prop('disabled', true);
    $('#NExterior').prop('disabled', true);
    $('#Enviar').prop('disabled', true);
    $('input[name=bitActual]').prop("disabled", true);

    $('#Calle').keyup(function ()
    {
        let data = $(this).val();

        if (data == "") {
            $('#Estados').prop('disabled', true);
            $('#Municipios').prop('disabled', true);
            $('#IdColonia').prop('disabled', true);
            $('#codigoPostal').prop('disabled', true);
            $('#NInterior').prop('disabled', true);
            $('#NExterior').prop('disabled', true);
            $('#Enviar').prop('disabled', true);
            $('input[name=bitActual]').prop("disabled", true);

            $('#Estados').val(0);
            $('#Municipios').val(0);
            $('#IdColonia').val(0);
            $('#codigoPostal').val("");
            $('#NInterior').val("");
            $('#NExterior').val("");
        } else
        {
            $('#NExterior').prop('disabled', false);
        }
    });

    $('#NExterior').keyup(function () {
        let data = $(this).val();

        if (data == "") {
            $('#Estados').prop('disabled', true);
            $('#Municipios').prop('disabled', true);
            $('#IdColonia').prop('disabled', true);
            $('#codigoPostal').prop('disabled', true);
            $('#NInterior').prop('disabled', true);
            $('#Enviar').prop('disabled', true);
            $('input[name=bitActual]').prop("disabled", true);

            $('#Estados').val(0);
            $('#Municipios').val(0);
            $('#IdColonia').val(0);
            $('#codigoPostal').val("");
            $('#NInterior').val("");
        } else {
            $('#NInterior').prop('disabled', false);
        }
    });

    $('#NInterior').keyup(function () {
        let data = $(this).val();

        if (data == "") {
            $('#Estados').prop('disabled', true);
            $('#Municipios').prop('disabled', true);
            $('#IdColonia').prop('disabled', true);
            $('#codigoPostal').prop('disabled', true);
            $('#Enviar').prop('disabled', true);
            $('input[name=bitActual]').prop("disabled", true);

            $('#Estados').val(0);
            $('#Municipios').val(0);
            $('#IdColonia').val(0);
            $('#codigoPostal').val("");
        } else {
            $('#Estados').prop('disabled', false);
        }
    });

    $('#Estados').change(function () {
        let data = $(this).val();

        if (data == "") {
            $('#Municipios').prop('disabled', true);
            $('#IdColonia').prop('disabled', true);
            $('#codigoPostal').prop('disabled', true);
            $('#Enviar').prop('disabled', true);
            $('input[name=bitActual]').prop("disabled", true);

            $('#Municipios').val(0);
            $('#IdColonia').val(0);
            $('#codigoPostal').val("");
        } else {
            toastr.success("Estado Seleccionado", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#Municipios').prop('disabled', false);
        }
    });

    $('#Municipios').change(function () {
        let data = $(this).val();

        if (data == "") {

            $('#IdColonia').prop('disabled', true);
            $('#codigoPostal').prop('disabled', true);
            $('#Enviar').prop('disabled', true);
            $('input[name=bitActual]').prop("disabled", true);

            $('#IdColonia').val(0);
            $('#codigoPostal').val("");
        } else {
            toastr.success("Municipio Seleccionado", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#IdColonia').prop('disabled', false);
        }
    });

    $('#IdColonia').change(function () {
        let data = $(this).val();

        if (data == "") {

            $('#codigoPostal').prop('disabled', true);
            $('#Enviar').prop('disabled', true);
            $('input[name=bitActual]').prop("disabled", true);

            $('#codigoPostal').val("");
        } else {
            toastr.success("Colonia Seleccionado", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('input[name=bitActual]').prop("disabled", false);
        }
    });

    $('input[name=bitActual]').on('ifChecked', function () {
        if ($('input[id=si]:checked')) {
            $('#Enviar').prop('disabled', false);
        } else {
            $('#Enviar').prop('disabled', true);
        }
    });


})