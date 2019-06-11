$(document).ready(function () {

    $('#DocumentoPDF').change(function () {
        var element = $('#DocumentoPDF');
        var extend = element.val();
        var regExp = /(.pdf)/

        if (!regExp.exec(extend)) {
            toastr.warning("Solo se Permite Formato PDF.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#DocumentoPDF').val('');
        } else {
            toastr.success("Archivo Cargado Correctamente.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
        }

    })
})