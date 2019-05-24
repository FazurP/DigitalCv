$(document).ready(function () {

    $('#TipoEmpresa').attr('disabled', true);
    $('#fecha').attr('disabled', true);
    $('#Participacion').attr('disabled', true);
    $('#IdAsociacion').attr('disabled', true);
    $('#btnGuardar').attr('disabled', true);


    $('#rdbSi').change(function () {
        toastr.info("Selecciona tu(s) Asociacion(es)", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
        $('#IdAsociacion').attr('disabled', false);
    })

    $('#rdbNo').change(function () {
        $('#TipoEmpresa').attr('disabled', true);
        $('#fecha').attr('disabled', true);
        $('#Participacion').attr('disabled', true);
        $('#IdAsociacion').attr('disabled', true);
        $('#btnGuardar').attr('disabled', true);

        $('#IdAsociacion').val('0');
        $('#TipoEmpresa').val('0');
        $('#fecha').val('');
        $('#Participacion').val('');
    })


    $('#IdAsociacion').change(function () {
        var asociacion = $('#IdAsociacion').val();

        if (asociacion == 0 || asociacion == "0" || asociacion == '0') {
            $('#TipoEmpresa').attr('disabled', true);
            $('#fecha').attr('disabled', true);
            $('#Participacion').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#TipoEmpresa').val('0');
            $('#fecha').val('');
            $('#Participacion').val('');

        } else {
            $('#TipoEmpresa').attr('disabled', false);
            toastr.success("Asociacion Seleccionada", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
        }
    })

    $('#TipoEmpresa').change(function () {
        var empresa = $('#TipoEmpresa').val();

        if (empresa == 0 || empresa == "0" || empresa == '0') {
            $('#fecha').attr('disabled', true);
            $('#Participacion').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#fecha').val('');
            $('#Participacion').val('');
        } else {
            $('#fecha').attr('disabled', false);
            toastr.success("Empresa Seleccionada", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
        }
    })

    $('#fecha').change(function () {
        var fecha = $('#fecha').val();

        if (fecha == null || fecha == '') {
            $('#Participacion').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#Participacion').val('');
        } else {
            $('#Participacion').attr('disabled', false);
            toastr.success("Fecha Seleccionada", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
        }
    })

    $('#Participacion').keyup(function () {
        var participacion = $('#Participacion').val();

        if (participacion == "") {
            $('#btnGuardar').attr('disabled', true);
        } else {
            $('#btnGuardar').attr('disabled', false);
        }

    })

});