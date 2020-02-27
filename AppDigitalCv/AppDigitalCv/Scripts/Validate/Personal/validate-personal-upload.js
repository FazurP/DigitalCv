$(document).ready(function () {

    $('#UCurp').change(function () {
        let data = $(this).get(0).files[0];

        if (data.type != "application/pdf") {
            toastr.warning("Solo se Permite Formato PDF.", "Digital-Cv dice:", { timeOut: 1000, closeButton: true });
            $('#UCurp').val('');
            $('#Rfc').prop('disabled', true);
        } else {
            if (data.size <= 2097152) {
                toastr.success("Archivo Cargado Correctamente.", "Digital-Cv dice:", { timeOut: 1000, closeButton: true });
            } else
            {
                toastr.error("No Puedes Cargar Archivos Mayores a 2MB", "Digital-Cv dice: ", { timeOut: 1000, closeButton: true });
                $('#UCurp').val('');
                $('#Rfc').prop('disabled', true);
            }
           
        }

    })

    $('#URfc').change(function () {
        let data = $(this).get(0).files[0];

        if (data.type != "application/pdf") {
            toastr.warning("Solo se Permite Formato PDF.", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#URfc').val('');
            $('#InstitucionSalud').prop('disabled', true);
        } else {
            if (data.size <= 2097152) {
                toastr.success("Archivo Cargado Correctamente.", "Digital-Cv dice:", { timeOut: 1000, closeButton: true });
            } else {
                toastr.error("No Puedes Cargar Archivos Mayores a 2MB", "Digital-Cv dice: ", { timeOut: 1000, closeButton: true });
                $('#URfc').val('');
                $('#InstitucionSalud').prop('disabled', true);
            }
        }

    })

});