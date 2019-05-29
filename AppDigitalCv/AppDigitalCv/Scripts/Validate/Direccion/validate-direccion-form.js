$(document).ready(function () {

    $('#Estados').prop('disabled',true);
    $('#Municipios').prop('disabled',true);
    $('#IdColonia').prop('disabled',true);
    $('#codigoPostal').prop('disabled',true);
    $('#Calle').prop('disabled',true);
    $('#NInterior').prop('disabled',true);
    $('#NExterior').prop('disabled',true);
    $('#Enviar').prop('disabled', true);

    $('#Pais').change(function () {

        var pais = $('#Pais').val();

        if (pais == null || pais == 0 || pais == '0' || pais == "0") {

            $('#Estados').prop('disabled', true);
            $('#Municipios').prop('disabled', true);
            $('#IdColonia').prop('disabled', true);
            $('#codigoPostal').prop('disabled', true);
            $('#Calle').prop('disabled', true);
            $('#NInterior').prop('disabled', true);
            $('#NExterior').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#Estados').val(0);
            $('#Municipios').val(0);
            $('#IdColonia').val(0);
            $('#codigoPostal').val('');
            $('#Calle').val('');
            $('#NInterior').val('');
            $('#NExterior').val('');
        } else {
            $('#Estados').prop('disabled', false);
            toastr.success("Pais Seleccionado.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
        }

    })

    $('#Estados').change(function () {

        var estado = $('#Estados').val();

        if (estado == null || estado == 0 || estado == '0' || estado == "0") {

            $('#Municipios').prop('disabled', true);
            $('#IdColonia').prop('disabled', true);
            $('#codigoPostal').prop('disabled', true);
            $('#Calle').prop('disabled', true);
            $('#NInterior').prop('disabled', true);
            $('#NExterior').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#Municipios').val(0);
            $('#IdColonia').val(0);
            $('#codigoPostal').val('');
            $('#Calle').val('');
            $('#NInterior').val('');
            $('#NExterior').val('');
        } else {
            $('#Municipios').prop('disabled', false);
            toastr.success("Estado Seleccionado.", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
        }
    })

    $('#Municipios').change(function () {

        var municipio = $('#Municipios').val();

        if (municipio == null || municipio == 0 || municipio == '0' || municipio == "0") {

            $('#IdColonia').prop('disabled', true);
            $('#codigoPostal').prop('disabled', true);
            $('#Calle').prop('disabled', true);
            $('#NInterior').prop('disabled', true);
            $('#NExterior').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#IdColonia').val(0);
            $('#codigoPostal').val('');
            $('#Calle').val('');
            $('#NInterior').val('');
            $('#NExterior').val('');
        } else {
            $('#IdColonia').prop('disabled', false);
            toastr.success("Municipio Seleccionado.", "Digital-Cv dice", { timeOut: 1000, closeButton: true  });
        }
    })

    $('#IdColonia').change(function () {

        var colonia = $('#IdColonia').val();

        if (colonia == null || colonia == 0 || colonia == '0' || colonia == "0") {

            $('#codigoPostal').prop('disabled', true);
            $('#Calle').prop('disabled', true);
            $('#NInterior').prop('disabled', true);
            $('#NExterior').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#codigoPostal').val('');
            $('#Calle').val('');
            $('#NInterior').val('');
            $('#NExterior').val('');
        } else {
            $('#Calle').prop('disabled', false);
            toastr.success("Colonia Seleccionada.", "Digital-Cv dice", { timeOut: 1000, closeButton: true })
        }
    })

    $('#Calle').keyup(function () {

        var calle = $('#Calle').val();

        if (calle == null || calle == '' || calle == "" || calle === '' || calle === "") {

            $('#NInterior').prop('disabled', true);
            $('#NExterior').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#NInterior').val('');
            $('#NExterior').val('');
        } else {
            $('#NInterior').prop('disabled', false);
        }

    })

    $('#NInterior').keyup(function () {

        var nInterior = $('#NInterior').val();

        if (nInterior == null || nInterior == '' || nInterior == "" || nInterior === '' || nInterior === "") {

            $('#NExterior').prop('disabled', true);
            $('#Enviar').prop('disabled', true);

            $('#NExterior').val('');
        } else {
            $('#NExterior').prop('disabled', false);
        }
    })

    $('#NExterior').keyup(function () {

        var nExterior = $('#NExterior').val();

        if (nExterior == null || nExterior == '' || nExterior == "" || nExterior === '' || nExterior === "") {
            $('#Enviar').prop('disabled', true);
        } else {
            $('#Enviar').prop('disabled', false);
        }
    })


})