$(document).ready(function () {

    $('#ApellidoPaternoPadre').prop('disabled', true);
    $('#ApellidoMaternoPadre').prop('disabled', true);
    $('#domicilio').prop('disabled', true);
    $('#ocupacion').prop('disabled', true);
    $('#tipo').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#nombrepadre').keyup(function () {

        let data = $(this).val();

        if (data == "") {
            $('#ApellidoPaternoPadre').prop('disabled', true);
            $('#ApellidoMaternoPadre').prop('disabled', true);
            $('#domicilio').prop('disabled', true);
            $('#ocupacion').prop('disabled', true);
            $('#parentesco').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ApellidoPaternoPadre').val("");
            $('#ApellidoMaternoPadre').val("");
            $('#domicilio').val("");
            $('#ocupacion').val("");
            $('#parentesco').val(0);
        } else
        {
            $('#ApellidoPaternoPadre').prop('disabled', false);
        }

    });

    $('#ApellidoPaternoPadre').keyup(function () {

        let data = $(this).val();

        if (data == "") {
            $('#ApellidoMaternoPadre').prop('disabled', true);
            $('#domicilio').prop('disabled', true);
            $('#ocupacion').prop('disabled', true);
            $('#tipo').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ApellidoMaternoPadre').val("");
            $('#domicilio').val("");
            $('#ocupacion').val("");
            $('#tipo').val(0);
        } else {
            $('#ApellidoMaternoPadre').prop('disabled', false);
        }

    });

    $('#ApellidoMaternoPadre').keyup(function () {

        let data = $(this).val();

        if (data == "") {
            $('#domicilio').prop('disabled', true);
            $('#ocupacion').prop('disabled', true);
            $('#tipo').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#domicilio').val("");
            $('#ocupacion').val("");
            $('#tipo').val(0);
        } else {
            $('#domicilio').prop('disabled', false);
        }

    });

    $('#domicilio').keyup(function () {

        let data = $(this).val();

        if (data == "") {
            $('#ocupacion').prop('disabled', true);
            $('#tipo').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ocupacionpadre').val("");
            $('#tipo').val(0);
        } else {
            $('#ocupacion').prop('disabled', false);
        }

    });

    $('#ocupacion').keyup(function () {

        let data = $(this).val();

        if (data == "") {
            $('#tipo').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#tipo').val(0);
        } else {
            $('#tipo').prop('disabled', false);
        }

    });

    $('#tipo').change(function () {

        let data = $(this).val();

        if (data == 0) {
            $('#btnGuardar').prop('disabled', true);
        } else {
            toastr.success("Parentesco Seleccionado", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#btnGuardar').prop('disabled', false);
        }

    });

})