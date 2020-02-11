$(document).ready(function () {

    $('#inputFileUpload').change(function () {

        let data = $(this).get(0).files[0];
        if (data != undefined) {
            if (data.type != "application/pdf") {
                $(this).val("");
                toastr.warning("Solo se Permiten Archivos en PDF", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
                $('#btnGuardar').prop('disabled', true);
            } else {
                toastr.success("Archivo Cargado Correctamente", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
                $('#btnGuardar').prop('disabled', false);
            }
        } else {
            $('#btnGuardar').prop('disabled', true);
        }
       

    });

});