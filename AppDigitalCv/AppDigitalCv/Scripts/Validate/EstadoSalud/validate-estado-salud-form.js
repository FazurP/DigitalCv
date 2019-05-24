$(document).ready(function () {

    $('#Enfermedades').prop('disabled', true);
    $('#btnAgregar').prop('disabled', true);


    $('#rdbSi').change(function () {
        $('#Enfermedades').prop('disabled', false);
        toastr.info("Selecciona tu(s) Enfermedad(es)", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
    })

    $('#rdbNo').change(function () {
        $('#Enfermedades').prop('disabled', true);
        $('#btnAgregar').prop('disabled', true);

        $('#Enfermedades').val(0);
    })

    $('#Enfermedades').change(function () {

        var enfermedad = $('#Enfermedades').val();

        if (enfermedad == null || enfermedad == 0 || enfermedad == '0' || enfermedad == "0") {
            $('#btnAgregar').prop('disabled', true);
        } else {
            $('#btnAgregar').prop('disabled', false);
            toastr.success("Enfermedad Seleccionada", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
        }

    })


})