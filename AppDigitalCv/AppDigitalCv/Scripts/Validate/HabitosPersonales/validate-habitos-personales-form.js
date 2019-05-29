$(document).ready(function () {

    $('#IdDeporte').prop('disabled', true);
    $('#IdFrecuencia').prop('disabled', true);
    $('#IdPasatiempo').prop('disabled', true);
    $('#btnSubmit').prop('disabled', true);


    $('#rdbSi').change(function () {
        $('#IdDeporte').prop('disabled', false);
        toastr.info("Seleccione su(s) Deporte(s).", "Digital-Cv dice", { timeOut: 1000, closeButton: true })
    })

    $('#rdbNo').change(function () {
        $('#IdDeporte').prop('disabled', true);
        $('#IdFrecuencia').prop('disabled', true);
        $('#IdPasatiempo').prop('disabled', true);

        $('#IdDeporte').val(0);
        $('#IdFrecuencia').val(0);
        $('#IdPasatiempo').val('');
    })

    $('#IdDeporte').change(function () {

        var deporte = $('#IdDeporte').val();

        if (deporte == null || deporte == 0 || deporte == '0' || deporte == "0") {
            $('#IdFrecuencia').prop('disabled', true);
            $('#IdPasatiempo').prop('disabled', true);
            $('#btnSubmit').prop('disabled', true);

            $('#IdFrecuencia').val(0);
            $('#IdPasatiempo').val('');
        } else {
            $('#IdFrecuencia').prop('disabled', false);
            toastr.success('Deporte Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }

    })

    $('#IdFrecuencia').change(function () {

        var frecuencia = $('#IdFrecuencia').val();

        if (frecuencia == null || frecuencia == 0 || frecuencia == '0' || frecuencia == "0") {
            $('#IdPasatiempo').prop('disabled', true);
            $('#btnSubmit').prop('disabled', true);
        } else {
            $('#IdPasatiempo').prop('disabled', false);
            toastr.success('Frecuencia Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }
    })

    $('#IdPasatiempo').keyup(function () {

        var pasatiempo = $('#IdPasatiempo').val();

        if (pasatiempo == null || pasatiempo == '' || pasatiempo == "") {
            $('#btnSubmit').prop('disabled', true);
        } else {
            $('#btnSubmit').prop('disabled', false);
        }
    })
})