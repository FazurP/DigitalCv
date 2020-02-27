$(document).ready(function(){

    $('#inputUploadFile').change(function () {

        let data = $(this).get(0).files[0];

        if (data != undefined) {
            if (data.type != "application/pdf") {
                toastr.warning("Solo se Permiten Archivos en PDF", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
                $(this).val("");
                $('#btnGuardar').prop('disabled', true);
            } else {
                if (data.size <= 2097152) {
                    toastr.success('Archivo Cargado Correctamente', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
                    $('#btnGuardar').prop('disabled', false);
                } else {
                    toastr.error("No Pueder Cargar Archivos Mayores a 2MB", "Digital-Cv dice", { timeout: 1000, closeButton: true });
                    $(this).val('');
                    $('#btnGuardar').prop('disabled', true);
                }
            }
        } else {
            $('#btnGuardar').prop('disabled', true);
        }
    });

})