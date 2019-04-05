$(document).ready(function () {

    var a = $('#IdAsociacion').val();
    $('#btnGuardar').attr("disabled", true);
    $('#Participacion').attr('disabled', true);

    if (a == "0" || a == "") {
        $('#btnGuardar').attr("disabled", true);

    }
    $('#IdAsociacion').change(function () {

        var pp = $("#IdAsociacion").val();

        if (pp == "0" || pp == "") {
            $('#btnGuardar').attr("disabled", true);
            $('#Participacion').attr('disabled', true);

            $('#Participacion').val("");
        } else {
            toastr.success("Asociacion Seleccionada");
        }

    })
    $('#TipoEmpresa').change(function () {

        var ee = $("#TipoEmpresa").val();

        if (ee == "0" || ee == "") {
            $('#btnGuardar').attr("disabled", true);
            $('#Participacion').attr('disabled', true);

            $('#Participacion').val("");
        } else {
            toastr.success("Empresa Seleccionada");
            $('#Participacion').attr('disabled', false);
        }
    })

    $('#Participacion').keyup(function () {

        var text = $('#Participacion').val();

        if (text == "") {
            $('#btnGuardar').attr("disabled", true);
        } else {
            $('#btnGuardar').attr("disabled", false);
        }

    })
});