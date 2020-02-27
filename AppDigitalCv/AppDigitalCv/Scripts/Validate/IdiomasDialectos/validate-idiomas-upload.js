$(document).ready(function () {

    $('#fUpload').change(function () {

        let data = $(this).get(0).files[0];

        if (data != undefined) {
            if (data.type != "application/pdf") {
                toastr.warning("Solo se Permiten Archivos en PDF", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
                $(this).val("");
                $('#btnSubmit').prop('disabled', true);
            } else {
                if (data.size <= 2097152) {
                    toastr.success('Archivo Cargado Correctamente', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
                    $('#btnSubmit').prop('disabled', false);
                } else {
                    toastr.error("No Pueder Cargar Archivos Mayores a 2MB", "Digital-Cv dice", { timeout: 1000, closeButton: true });
                    $(this).val('');
                    $('#btnSubmit').prop('disabled', true);
                }
            }
        } else {
            $('#btnSubmit').prop('disabled', true);
        }       
    });

})