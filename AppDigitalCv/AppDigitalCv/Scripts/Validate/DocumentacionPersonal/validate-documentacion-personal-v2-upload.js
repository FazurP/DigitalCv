$('#fUpload').change(function () {

    let data = $(this).get(0).files[0];

        var file = $(this).val();
        var expReg = /.pdf/

        if (!expReg.exec(file)) {
            toastr.warning('Solo se Permiten Archivos PDF', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#btnGuardar').prop('disabled', true);
            $(this).val('');
        } else {
            if (data.size <= 2097152) {
                toastr.success('Archivo Cargado Correctamente', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
                $('#btnGuardar').prop('disabled', false);
            } else {
                toastr.error("No Pueder Cargar Archivos Mayores a 2MB", "Digital-Cv dice", { timeout: 1000, closeButton: true });
                $(this).val('');
            }         
        }
})