$(document).ready(function () {

    $('#UCurp').change(function () {
        let data = $(this).get(0).files[0];

        if (data.type != "application/pdf") {
            toastr.warning("Solo se Permite Formato PDF.", "Digital-Cv dice:", { timeOut: 1000, closeButton: true });
            $('#UCurp').val('');
            $('#Rfc').prop('disabled', true);

        } else {
            toastr.success("Archivo Cargado Correctamente.", "Digital-Cv dice:", { timeOut: 1000, closeButton: true });
        }

    })

    $('#URfc').change(function () {
        let data = $(this).get(0).files[0];

        if (data.type != "application/pdf") {
            toastr.warning("Solo se Permite Formato PDF.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#URfc').val('');
            $('#InstitucionSalud').prop('disabled', true);
        } else {
            toastr.success("Archivo Cargado Correctamente.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
        }

    })

});