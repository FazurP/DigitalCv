$(document).ready(function () {

    $('#documentoInputFile').change(function () {
        var element = $('#documentoInputFile');
        var extend = element.val();
        var regExp = /(.pdf)/

        if (!regExp.exec(extend)) {
            toastr.warning("Solo se Permite Formato PDF.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#documentoInputFile').val('');
            $('#btnGuardar').prop('disabled',true);
        } else {
            toastr.success("Archivo Cargado Correctamente.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#btnGuardar').prop('disabled', false);
        }

    })

})